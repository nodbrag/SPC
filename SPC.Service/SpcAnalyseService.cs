using System;
using System.Collections.Generic;
using System.Text;
using SPC.IService;
using SPC.Models.DtoModel;
using System.Linq;
using SPC.Core.ChartAlgorithm.RunningChart;
using SPC.Core.ChartAlgorithm;
using SPC.Core.ChartAlgorithm.Histogram;
using SPC.Core.ChartAlgorithm.QualityControlChart;
using SPC.Core.ChartAlgorithm.PChart;
using SPC.Core.ChartAlgorithm.PlatoChart;
using SPC.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SPC.Core.Models;
using SPC.Core.Extensions;

namespace SPC.Service
{
    public class SpcAnalyseService : ISpcAnalyseService
    {
        
        private readonly SPCContext _context;
        private readonly IOptions<AppSettings> _appsetting;
        public SpcAnalyseService(SPCContext context, IOptions<AppSettings> settings)
        {
            _context = context;
            _appsetting = settings;
        }
        public SpcAnalyseDtos.FourPlistDto getFourPlistDto(SpcAnalyseDtos.SpcAnalyseFilter filter) {

            var tasks = (from p in this._context.Task
                            where p.WorkProcessId == _appsetting.Value.VisionWPID && p.EquipmentId == filter.EquipmentID && p.ProductId == filter.ProductID && p.BeginDateTime >= filter.BeginDateTime && p.BeginDateTime < filter.EndDateTime&&(p.UserDefine1.ConvertToNullableInt(0).Value / (double)p.Quantity) < _appsetting.Value.VKRate && p.Quantity > 1000 
                            select new { p.TaskId, p.Quantity,p.UserDefine2,badQuantity = p.UserDefine1.ConvertToNullableInt(0).Value, BatchNo = "PC-" + p.BatchNo.ToUpper() }).ToList();
            List<int> taskids= tasks.Select(c => c.TaskId).ToList();
            int defectItemNum = tasks.Select(c => c.UserDefine2.ConvertToNullableInt(0).Value).ToList().Sum();
            string equipmentName = _context.Equipment.Where(c => c.EquipmentId == filter.EquipmentID).FirstOrDefault().EquipmentName;

            //var JoinQuery =  from o in _context.VinspectionOrder 
            //                join vd in _context.VinspectionOrderDetail on o.VinspectionOrderId equals vd.VinspectionOrderId
            //                join d in _context.DefectItem on vd.DefectItemId equals d.DefectItemId
            //                where taskids.Contains(o.TaskId)
            //                select new { DefectItemName = d.DefectItemName };

            var JoinQuery = from o in _context.VtaskDefectReport
                            join d in _context.DefectItem on o.DefectItemId equals d.DefectItemId
                            where taskids.Contains(o.TaskId)
                            select new { DefectItemName = d.DefectItemName, o.DefectItemNum };

            var groupPQuery = tasks.Select(c=>new { c.Quantity,c.badQuantity,c.BatchNo }).Distinct().GroupBy(c => new { c.BatchNo }).Select(c => new PData
            {
                errorCount = c.Sum(s => s.badQuantity)/100,
                totalCount = c.Sum(s => s.Quantity) /100,
                xAxisValue = c.Key.BatchNo

            });
            var groupQuery = JoinQuery.GroupBy(c => new { c.DefectItemName }).Select(c => new PlatoData
            {
                key = c.Key.DefectItemName,
                value = c.Sum(s=>s.DefectItemNum)
            });
            int totolnum = defectItemNum == 0 ? JoinQuery.Count() : defectItemNum;

            List<PlatoData> platoDatas= groupQuery.ToList();
            var groupPlistQuery= platoDatas.Select(c => new SpcAnalyseDtos.PListDto { badNum = c.value, EquipmentName = equipmentName, DefectItemName = c.key, totalNum = totolnum, BadRate = (Math.Round((double)c.value / totolnum, 3) * 100) + "%" });
            SpcAnalyseDtos.FourPlistDto tp = new SpcAnalyseDtos.FourPlistDto();
            tp.pDto = PChart.getPChart(groupPQuery.ToList());
            tp.platoDto = PlatoChart.getPlatoChart(platoDatas);
            tp.pListDtos = groupPlistQuery.ToList();
            return tp;
        }
        public PDto GetPChartData(SpcAnalyseDtos.SpcAnalyseFilter filter)
        {
            #region 模拟数据
            //List<PData> samples = new List<PData>()
            //{
            //    new PData(98,20,"001x")
            //    ,new PData(104,18,"002c")
            //    ,new PData(97,14,"003x")
            //    ,new PData(99,16,"004x")
            //    ,new PData(97,13,"005x")
            //    ,new PData(102,29,"006x")
            //    ,new PData(104,21,"007x")
            //    ,new PData(101,14,"008x")

            //    ,new PData(55,6,"010x")
            //    ,new PData(48,6,"011x")
            //    ,new PData(50,7,"012x")
            //    ,new PData(53,7,"013x")
            //    ,new PData(56,9,"014x")
            //    ,new PData(49,5,"015x")
            //    ,new PData(56,8,"016x")
            //    ,new PData(53,9,"017x")
            //    ,new PData(52,9,"018x")
            //    ,new PData(51,10,"019x")
            //    ,new PData(52,9,"020x")
            //    ,new PData(47,10,"021x")
            //};
            #endregion
            var JoinQuery = from p in this._context.Task
                            join e in _context.Equipment on p.EquipmentId equals e.EquipmentId
                            where p.WorkProcessId == _appsetting.Value.VisionWPID && e.EquipmentId == filter.EquipmentID && p.ProductId == filter.ProductID && p.BeginDateTime >= filter.BeginDateTime && p.BeginDateTime < filter.EndDateTime
                            select new { p.Quantity, badQuantity=p.UserDefine1.ConvertToNullableInt(0).Value, BatchNo = "PC-" + p.BatchNo.ToUpper() };
            JoinQuery = JoinQuery.Where(p => ((double)p.badQuantity / p.Quantity) < _appsetting.Value.VKRate && p.Quantity > 1000);

            var groupQuery = JoinQuery.GroupBy(c => new { c.BatchNo }).Select(c => new PData
            {
                errorCount =c.Sum(s=>s.badQuantity)/100,
                totalCount = c.Sum(s=>s.Quantity)/100,
                 xAxisValue=c.Key.BatchNo
            });
            return PChart.getPChart(groupQuery.ToList());  
        }
        public PlatoDto GetPlatoChartData(SpcAnalyseDtos.SpcAnalyseFilter filter)
        {
            var tasks = (from p in this._context.Task
                         where p.WorkProcessId == _appsetting.Value.VisionWPID && p.EquipmentId == filter.EquipmentID && p.ProductId == filter.ProductID && p.BeginDateTime >= filter.BeginDateTime && p.BeginDateTime < filter.EndDateTime && (p.UserDefine1.ConvertToNullableInt(0).Value / (double)p.Quantity) < _appsetting.Value.VKRate && p.Quantity > 1000
                         select new { p.TaskId }).ToList();
            List<int> taskids = tasks.Select(c => c.TaskId).ToList();

            //var JoinQuery = from o in _context.VinspectionOrder
            //                join vd in _context.VinspectionOrderDetail on o.VinspectionOrderId equals vd.VinspectionOrderId
            //                join d in _context.DefectItem on vd.DefectItemId equals d.DefectItemId
            //                where taskids.Contains(o.TaskId)
            //                select new { DefectItemName = d.DefectItemName };

            var JoinQuery = from o in _context.VtaskDefectReport
                            join d in _context.DefectItem on o.DefectItemId equals d.DefectItemId
                            where taskids.Contains(o.TaskId)
                            select new { DefectItemName = d.DefectItemName,o.DefectItemNum };
            var groupQuery = JoinQuery.GroupBy(c => new { c.DefectItemName}).Select(c => new PlatoData
            {
                  key=c.Key.DefectItemName,value=c.Sum(s=>s.DefectItemNum)
            });
            #region 模拟数据
            //List<PlatoData> platoDatas = new List<PlatoData>()
            //{
            //    new PlatoData("毛边",10)
            //    ,new PlatoData("裂痕",15)
            //    ,new PlatoData("瑕疵",9)
            //    ,new PlatoData("底纹",40)
            //    ,new PlatoData("测试",7)

            //};
            #endregion
            PlatoDto plato = PlatoChart.getPlatoChart(groupQuery.ToList());
            return plato;
        }
        public List<SpcAnalyseDtos.PListDto> GetPlistData(SpcAnalyseDtos.SpcAnalyseFilter filter) {


            var tasks = (from p in this._context.Task
                         where p.WorkProcessId == _appsetting.Value.VisionWPID && p.EquipmentId == filter.EquipmentID && p.ProductId == filter.ProductID && p.BeginDateTime >= filter.BeginDateTime && p.BeginDateTime < filter.EndDateTime && (p.UserDefine1.ConvertToNullableInt(0).Value / (double)p.Quantity) < _appsetting.Value.VKRate && p.Quantity > 1000
                         select new { p.TaskId,p.UserDefine2 }).ToList();
            int defectItemNum = tasks.Select(c => c.UserDefine2.ConvertToNullableInt(0).Value).ToList().Sum();
            List<int> taskids = tasks.Select(c => c.TaskId).ToList();
            string equipmentName = _context.Equipment.Where(c => c.EquipmentId == filter.EquipmentID).FirstOrDefault().EquipmentName;

            //var JoinQuery = from o in _context.VinspectionOrder
            //                join vd in _context.VinspectionOrderDetail on o.VinspectionOrderId equals vd.VinspectionOrderId
            //                join d in _context.DefectItem on vd.DefectItemId equals d.DefectItemId
            //                where taskids.Contains(o.TaskId)
            //                select new { DefectItemName = d.DefectItemName };
            var JoinQuery = from o in _context.VtaskDefectReport
                            join d in _context.DefectItem on o.DefectItemId equals d.DefectItemId
                            where taskids.Contains(o.TaskId)
                            select new { DefectItemName = d.DefectItemName, o.DefectItemNum };

            int totolnum = defectItemNum==0?JoinQuery.Sum(c=>c.DefectItemNum):defectItemNum;

            //var groupQuery=JoinQuery.GroupBy(c => new { c.DefectItemName }).Select(c=>new SpcAnalyseDtos.PListDto {
            //    badNum=c.Count(), BadRate= (Math.Round((double)c.Count()/ totolnum, 3)*100)+"%", totalNum= totolnum, EquipmentName= equipmentName, DefectItemName=c.Key.DefectItemName
            //});
            var groupQuery=JoinQuery.GroupBy(c => new { c.DefectItemName }).Select(c=>new SpcAnalyseDtos.PListDto {
               badNum=c.Sum(s=>s.DefectItemNum), BadRate= (Math.Round((double)c.Sum(s => s.DefectItemNum)/ totolnum, 3)*100)+"%", totalNum= totolnum, EquipmentName= equipmentName, DefectItemName=c.Key.DefectItemName
            });
            return groupQuery.ToList();
        }
        public List<SpcAnalyseDtos.PListDto> GetPlistData(string batchNo) {

            batchNo = batchNo.Replace("PC-", "");


            var tasks = (from p in this._context.Task
                         join e in _context.Equipment on p.EquipmentId equals e.EquipmentId
                         where p.WorkProcessId == _appsetting.Value.VisionWPID && p.BatchNo == batchNo 
                         select new { p.TaskId, p.UserDefine2,e.EquipmentName }).ToList();
            int defectItemNum = tasks.Select(c => c.UserDefine2.ConvertToNullableInt(0).Value).ToList().Sum();
            List<int> taskids = tasks.Select(c => c.TaskId).ToList();

            var JoinQuery = from o in _context.VtaskDefectReport
                            join d in _context.DefectItem on o.DefectItemId equals d.DefectItemId
                            join t in tasks on o.TaskId equals t.TaskId
                            where taskids.Contains(o.TaskId)
                            select new { DefectItemName = d.DefectItemName, EquipmentName = t.EquipmentName, o.DefectItemNum };

            int totolnum = defectItemNum == 0 ? JoinQuery.Sum(c => c.DefectItemNum) : defectItemNum;

            /* var JoinQuery =  from p in this._context.Task
                              join e in _context.Equipment on p.EquipmentId equals e.EquipmentId
                              join o in _context.VinspectionOrder on p.TaskId equals o.TaskId
                              join vd in _context.VinspectionOrderDetail on o.VinspectionOrderId equals vd.VinspectionOrderId
                              join d in _context.DefectItem on vd.DefectItemId equals d.DefectItemId
                              where p.WorkProcessId==_appsetting.Value.VisionWPID&&p.BatchNo==batchNo
                             select new { DefectItemName = d.DefectItemName, EquipmentName = e.EquipmentName };
             int totalnum = JoinQuery.Count();
            var groupQuery = JoinQuery.GroupBy(c => new { c.DefectItemName,  c.EquipmentName }).Select(c => new SpcAnalyseDtos.PListDto
            {
                badNum = c.Count(),
                BadRate = (Math.Round((double)c.Count() / totalnum, 3)*100)+"%",
                totalNum = totalnum,
                EquipmentName = c.Key.EquipmentName,
                DefectItemName = c.Key.DefectItemName
            });*/
            var groupQuery = JoinQuery.GroupBy(c => new { c.DefectItemName, c.EquipmentName }).Select(c => new SpcAnalyseDtos.PListDto
            {
                badNum = c.Sum(s => s.DefectItemNum),
                BadRate = (Math.Round((double)c.Sum(s => s.DefectItemNum) / totolnum, 3) * 100) + "%",
                totalNum = totolnum,
                EquipmentName = c.Key.EquipmentName,
                DefectItemName = c.Key.DefectItemName
            });
            return groupQuery.OrderBy(c=>c.EquipmentName).ToList();
        }
        public CPKDto GetCPKData()
        {
            List<double> samples = new List<double>() {
                9.48,9.37,9.48,9.44,9.4,9.2,9.43,9.42,9.56,9.43,9.44,9.56,9.41,9.39,9.45,9.4,9.45,9.41,9.34,9.33
            };
            double LSL = 9.1;
            double USL = 9.9;
            return  CPK.getCPK(samples, LSL, USL);
        }

        public RunningChartDto GetRunningChartData()
        {
            List<double> x1 = new List<double>() { 45, 26, 25, 33, 30, 37, 44, 35, 38, 39 };
            List<double> x2 = new List<double>() { 33, 46, 32, 22, 26, 34, 43, 38, 45, 39 };

           return RunningChart.getRunningChart(x1, x2);
        }

        public QualityControlDto GetQualityControlData() {
           

            List<double> x1 = new List<double>() { 0.91, 0.94, 0.925, 0.899, 0.886, 0.933, 0.883, 0.893 };
            List<double> x2 = new List<double>() { 0.882, 0.916, 0.943, 0.926, 0.938, 0.936, 0.929, 0.934 };
            List<double> x3 = new List<double>() { 0.922, 0.977, 0.911, 0.9, 0.878, 0.9, 0.88, 0.96 };
            List<double> x4 = new List<double>() { 0.934, 0.951, 0.92, 0.927, 0.941, 0.941, 0.898, 1.09 };
            List<double> x5= new List<double>()  { 0.945, 0.938, 0.892, 0.928, 0.895, 0.913, 0.904, 0.935 };
            //组数
            int groupNum = 5;
            //直方图
            //上限
            double USL = 1;
            //下限
            double LSL = 0.89;
            // 区间间隔数
            int IntervalNum = 8;
            //样本数的小数点数
            int floatNum = 3;
            return QualityControlChart.GetQualityControlChart(groupNum, LSL, USL, IntervalNum, floatNum,x1, x2, x3, x4, x5);
        }

        public List<HistogramDto> GetHistogramData(string BatchNo)
        {
            var query = (from t in _context.Task
                        join o in _context.InspectionOrder on t.TaskId equals o.TaskId
                        join d in _context.InspectionOrderDetail on o.InspectionOrderId equals d.InspectionOrderId
                        join p in _context.Parameter on d.ParameterId equals p.ParameterId
                        where t.BatchNo == BatchNo
                        orderby o.OrderDateTime
                        select new { p.ParameterName,p.ParameterId, p.MaxValue,p.MinValue, d.ParameterValue }).ToList();

            var parameter= query.Select(c => new { c.ParameterName,c.ParameterId, c.MinValue, c.MaxValue }).Distinct().ToList();
            int IntervalNum = 10;
            List<HistogramDto> histogramDtos = new List<HistogramDto>();
            foreach (var p in parameter) {

               List<double> samples= query.Where(c => c.ParameterId == p.ParameterId).Select(c => System.Convert.ToDouble(c.ParameterValue)).ToList();
               double USL = Convert.ToDouble(p.MaxValue);
               double LSL = Convert.ToDouble(p.MinValue);
               histogramDtos.Add(Histogram.GetHistogram(samples,p.ParameterName,USL, LSL, IntervalNum, 3));
            }
            #region 模拟数据
            //List<double> samples = new List<double>() {
            //    24,14,18,27,17,32,31,27,21,27,24,21,24,26,31,34,28,32,24,16,22,37,36,21,16,17,22,34,20,19,16,16,18,30,21,16,14,15,14,14,25,15,16,15,19,15,15,19,19,30,24,10,15,17,17,21,34,22,17,15,17,20,17,20,15,17,24,20
            //};
            //int IntervalNum = 10;
            //double USL = 36; //客户给定
            //double LSL = 12; //客户给定
            #endregion
            return histogramDtos;
        }
       
    }
}
