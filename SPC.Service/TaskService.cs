/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： TaskService                                    
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.IService;
using SPC.Models.DtoModel;
using SPC.Models.DataModel;
using SPC.Core.Dtos;
using SPC.Core.Extensions;
using System.Reflection;
using System.Linq;
using SPC.Core.Attribute;
using SPC.Core.Utility;
using SPC.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SPC.Core.NPOI;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;


namespace SPC.Service
{
    public class TaskService : ITaskService
    {
        private readonly SPCContext _context;
        private readonly IOptions<AppSettings> _appsetting;
        public TaskService(SPCContext context, IOptions<AppSettings> settings)
        {
            _context = context;
            _appsetting = settings;
        }

        
        public void CreateTask(TaskDtos.TaskDto model)
        {
            _context.Task.Add(model.MapTo<Task>());
            _context.SaveChanges();
        }
        public void CreateTasks(List<TaskDtos.TaskDto> models)
        {
            List<Task> tasks = new List<Task>();
            foreach (TaskDtos.TaskDto taskDto in models) {
                tasks.Add(taskDto.MapTo<Task>());
            }
            _context.Task.AddRange(tasks);
            _context.SaveChanges();
        }
        public void DeleteTask(int id)
        {
            Task entity= _context.Task.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的Task不存在!");
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public TaskDtos.TaskDto GetTaskByID(int id)
        {
            Task entity = _context.Task.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的Task不存在!");
            return entity.MapTo<TaskDtos.TaskDto>();
        }
        public List<TaskDtos.TaskDto> getTaskByBatch(string batchNo) {

            return _context.Task.Where(c=>c.BatchNo==batchNo&&c.WorkProcessId!=_appsetting.Value.VisionWPID&&c.WorkProcessId!=_appsetting.Value.SizeWPID).SelectMap<TaskDtos.TaskDto>().AsNoTracking().ToList();
        }
        public void deleteTaskByBatch(string batchNo)
        {
            List< Task> tasks= _context.Task.Where(c => c.BatchNo == batchNo && c.WorkProcessId != _appsetting.Value.VisionWPID && c.WorkProcessId != _appsetting.Value.SizeWPID).AsNoTracking().ToList();
            _context.Task.RemoveRange(tasks);
            _context.SaveChanges();
        }
        public List<TaskDtos.TaskDto> GetTaskList()
        {
            return _context.Task.SelectMap<TaskDtos.TaskDto>().AsNoTracking().ToList();
        }

        public Tuple<List<TaskDtos.TaskDto>, int> GetTaskListForPagination(FiterConditionBase<TaskDtos.TaskFilterDto> fiterCondition)
        {

            var query = _context.Task.SelectMap<TaskDtos.TaskDto>().AsNoTracking();
           
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<TaskDtos.TaskDto>(item));
            if (fiterCondition.Filter.WorkProcessName.Contains("视觉"))
            {
                query= query.Where(c => (c.UserDefine1.ConvertToNullableInt(0).Value /(double) c.Quantity) < _appsetting.Value.VKRate&&c.Quantity>1000);
                query = query.Select(c => new TaskDtos.TaskDto { BatchNo="PC-"+c.BatchNo.ToUpper(), Quantity=c.Quantity, BeginDateTime=c.BeginDateTime, Description=c.Description, EndDateTime=c.EndDateTime, EquipmentCode=c.EquipmentCode, EquipmentId=c.EquipmentId, EquipmentName=c.EquipmentName, ProductId=c.ProductId, ProductName=c.ProductName, TaskId=c.TaskId, UserDefine1=c.UserDefine1, UserDefine2=c.UserDefine2, WorkProcessId=c.WorkProcessId,WorkProcessName=c.WorkProcessName });
            }
            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<TaskDtos.TaskDto> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }

            return query.OrderByDescending(c=>c.BeginDateTime).GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }
        public Tuple<List<TaskDtos.TaskDiscreteDto>, int> GetDiscreteList(FiterConditionBase<TaskDtos.TaskDiscreteFilterDto> fiterCondition) {

            string batchNo = string.Empty;
            DateTime? upper = null;
            DateTime? lower = null;
            if (fiterCondition.Filter != null) {
                batchNo = fiterCondition.Filter.BatchNo;
                upper = fiterCondition.Filter.BeginDateTime.ConvertToNullableDateTime();
                lower = fiterCondition.Filter.EndDateTime.ConvertToNullableDateTime();
             }
            //1.查出符合条件注塑任务记录的批次号
           var query= _context.Task.Where(c => c.WorkProcessId == _appsetting.Value.InjectionWPID).Select(c=>new { c.BatchNo,c.BeginDateTime });
            if (batchNo.IsNotNullAndEmpty())
            {
                query = query.Where(c => c.BatchNo.Contains(batchNo));
            }
            if (upper != null) {
                query = query.Where(c=> upper >= c.BeginDateTime);
            }
            if (lower != null)
            {
                query = query.Where(c => lower<= c.BeginDateTime);
            }
            List<string> batchNoList = query.Skip((fiterCondition.SkipCount - 1) * fiterCondition.MaxResultCount).Take(fiterCondition.MaxResultCount).Select(c => c.BatchNo).ToList();

            List<Task> tasks = _context.Task.Include(c=>c.Equipment).Include(c=>c.Product).Where(c => batchNoList.Contains(c.BatchNo)).ToList();
            List<TaskDtos.TaskDiscreteDto> taskDiscreteDtos = new List<TaskDtos.TaskDiscreteDto>();
            foreach (string bno in batchNoList)
            {
                TaskDtos.TaskDiscreteDto taskDiscreteDto = new TaskDtos.TaskDiscreteDto();
                Task injectiontask = tasks.Where(c => c.BatchNo == bno && c.WorkProcessId == _appsetting.Value.InjectionWPID).FirstOrDefault();
                if (injectiontask != null)
                {
                    taskDiscreteDto.BatchNo = injectiontask.BatchNo;
                    taskDiscreteDto.ProductID = injectiontask.ProductId;
                    taskDiscreteDto.ProductName = injectiontask.Product.ProductName;
                    taskDiscreteDto.InjectionEquipmentName = injectiontask.Equipment.EquipmentName;
                    taskDiscreteDto.STime = injectiontask.BeginDateTime;
                    taskDiscreteDto.MatrixName = injectiontask.UserDefine2;
                    taskDiscreteDto.CavityName = injectiontask.UserDefine1;
                }
                Task Swaytask = tasks.Where(c => c.BatchNo == bno && c.WorkProcessId == _appsetting.Value.SwayWPID).FirstOrDefault();
                if (Swaytask != null)
                {
                    taskDiscreteDto.SwayEquipmentName = Swaytask.Equipment.EquipmentName;
                }
                Task firingtask = tasks.Where(c => c.BatchNo == bno && c.WorkProcessId == _appsetting.Value.FiringWPID).FirstOrDefault();
                if (firingtask != null)
                {
                    taskDiscreteDto.FiringEquipmentName = firingtask.Equipment.EquipmentName;
                }
                Task plastictask = tasks.Where(c => c.BatchNo == bno && c.WorkProcessId == _appsetting.Value.PlasticWPID).FirstOrDefault();
                if (plastictask != null)
                {
                    taskDiscreteDto.PlasticEquipmentName = plastictask.Equipment.EquipmentName;
                }
                taskDiscreteDtos.Add(taskDiscreteDto);
            }

            return new Tuple<List<TaskDtos.TaskDiscreteDto>, int>(taskDiscreteDtos, query.Count());

        }
        public void UpdateTask(TaskDtos.TaskDto model)
        {
             _context.Task.Update(model.MapTo<Task>());
            _context.SaveChanges();
        }
        public int ImportVisionCheckData(TaskDtos.TaskVisionCheckDto taskVisionCheckDto)
        {
            //如果taskid 不等于零
            int taskid = taskVisionCheckDto.TaskId;
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    if (taskid == 0)
                    {
                        Task task = new Task();
                        task.BatchNo = taskVisionCheckDto.BatchNo;
                        task.BeginDateTime = taskVisionCheckDto.BeginDateTime == null ? DateTime.Now : taskVisionCheckDto.BeginDateTime.Value;
                        task.EndDateTime = taskVisionCheckDto.EndDateTime == null ? DateTime.Now : taskVisionCheckDto.EndDateTime.Value; ;
                        task.ProductId = taskVisionCheckDto.ProductId;
                        task.EquipmentId = taskVisionCheckDto.EquipmentId;
                        task.WorkProcessId = _appsetting.Value.VisionWPID;
                        task.Quantity = taskVisionCheckDto.Quantity;
                        task.UserDefine1 = taskVisionCheckDto.BadQuantity;
                        task.UserDefine2 = taskVisionCheckDto.DefectItemQuantity==null?"":taskVisionCheckDto.DefectItemQuantity;
                        task.UserDefine3 = "";
                        task.UserDefine4 = "";
                        task.UserDefine5 = "";
                        task.Description = "";
                        _context.Task.Add(task);
                        _context.SaveChanges();
                        taskid = task.TaskId;
                    }
                    List<VinspectionOrder> InspectionOrders = new List<VinspectionOrder>();
                    
                    foreach (TaskDtos.ProductCheck productCheck in taskVisionCheckDto.productChecks)
                    {

                        VinspectionOrder inspectionOrder = new VinspectionOrder();
                        inspectionOrder.TaskId = taskid;
                        inspectionOrder.ProductSn = productCheck.ProductSN;
                        inspectionOrder.OrderDateTime = productCheck.OrderDateTime==null?DateTime.Now : productCheck.OrderDateTime.Value;
                        List<VinspectionOrderDetail> inspectionOrderDetails = new List<VinspectionOrderDetail>();
                        foreach (TaskDtos.DefectDetail defectDetail in productCheck.defectDetails)
                        {
                            VinspectionOrderDetail inspectionOrderDetail = new VinspectionOrderDetail();
                            inspectionOrderDetail.VinspectionOrderId = inspectionOrder.VinspectionOrderId;
                            inspectionOrderDetail.Width = defectDetail.Width;
                            inspectionOrderDetail.Height = defectDetail.Height;
                            inspectionOrderDetail.PointX = defectDetail.PointX;
                            inspectionOrderDetail.PointY = defectDetail.PointY;
                            inspectionOrderDetail.DefectItemId = defectDetail.DefectItemID;
                            inspectionOrderDetail.EuclidDistance = defectDetail.EuclidDistance;
                            inspectionOrderDetails.Add(inspectionOrderDetail);
                        }
                        inspectionOrder.VinspectionOrderDetail = inspectionOrderDetails;
                        InspectionOrders.Add(inspectionOrder);
                    }
                    _context.VinspectionOrder.AddRange(InspectionOrders);
                    _context.SaveChanges();
                   
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                return taskid;
            }

        }
        public void ImportDimensionData(TaskDtos.TaskDimensionDto model) {
            string path = model.filePath;// "F:\\workspace\\project\\SPC\\SPC2019\\SPC.Api\\bin\\Debug\\netcoreapp2.2\\datas\\尺寸机数据.xlsx";
            DataTable dt=  NPOIHelper.GetDataTable(path, 0);
           var t= _context.Task.Where(c => c.BatchNo == model.BatchNo && c.WorkProcessId==_appsetting.Value.SizeWPID).FirstOrDefault();
            if (t != null)
            {
                throw new Exception("该批次已经导入过信息");
            }
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Task task = new Task();
                    task.BatchNo = model.BatchNo;
                    task.ProductId = model.ProductID;
                    task.EquipmentId = model.EquipmentId;
                    task.BeginDateTime = DateTime.Now;
                    task.EndDateTime = DateTime.Now;
                    task.WorkProcessId = _appsetting.Value.SizeWPID;
                    task.Quantity = 0;
                    task.UserDefine1 = "";
                    task.UserDefine2 = "";
                    task.UserDefine3 = "";
                    task.UserDefine4 = "";
                    task.UserDefine5 = "";
                    task.Description = "";

                    List<Parameter> parameters = _context.Parameter.AsNoTracking().ToList();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        task.Quantity = dt.Rows.Count - 4;
                        if (dt.Rows.Count > 5)
                        {
                            task.BeginDateTime = dt.Rows[4][0].ConvertToNullableDateTime().Value;
                        }
                        task.EndDateTime = dt.Rows[dt.Rows.Count - 5][0].ConvertToNullableDateTime().Value;

                        _context.Task.Add(task);

                        List<InspectionOrder> InspectionOrders = new List<InspectionOrder>();
                        //如果是确定是参数列开始读数据
                        for (int n = 4; n < dt.Rows.Count; n++)
                        {

                            InspectionOrder inspectionOrder = new InspectionOrder();
                            inspectionOrder.TaskId = task.TaskId;
                            inspectionOrder.ProductSn = "";
                            inspectionOrder.OrderDateTime = dt.Rows[n][0].ConvertToNullableDateTime().Value;

                            List<InspectionOrderDetail> inspectionOrderDetails = new List<InspectionOrderDetail>();
                            for (int i = 1; i < dt.Columns.Count; i++)
                            {
                                Parameter parameter = parameters.Where(c => c.ParameterName == dt.Columns[i].ConvertToString()).FirstOrDefault();
                                if (parameter != null)
                                {
                                    InspectionOrderDetail inspectionOrderDetail = new InspectionOrderDetail();
                                    inspectionOrderDetail.InspectionOrderId = inspectionOrder.InspectionOrderId;
                                    inspectionOrderDetail.ParameterId = parameter.ParameterId;
                                    inspectionOrderDetail.ParameterValue = dt.Rows[n][i].ConvertToString();
                                    inspectionOrderDetails.Add(inspectionOrderDetail);
                                }
                            }

                            inspectionOrder.InspectionOrderDetail = inspectionOrderDetails;
                            InspectionOrders.Add(inspectionOrder);

                        }
                        _context.InspectionOrder.AddRange(InspectionOrders);
                        _context.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            
        }
        /// <summary>
        /// 获取尺寸详情数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
       public  Tuple<TaskDtos.TaskDimensionDetailDto, int> GetDimensionDetailList(FiterConditionBase<TaskDtos.TaskDimensionDetailFilterDto> fiterCondition)
        {
            //1.头部行转列
            var parameters = _context.Parameter.ToList();
            DataTable dt = ToDataTable(parameters);

            Dictionary<string, string> DataColums = new Dictionary<string, string>();
            DataColums.Add("USL", "MaxValue");
            DataColums.Add("Norminal", "StandardValue");
            DataColums.Add("LSL", "MinValue");
            string groupingColumn = "ParameterName";
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("Dim", typeof(string));
            List<string> cols = new List<string>();
            cols.Add("Dim");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtNew.Columns.Add(dt.Rows[i]["ParameterName"].ToString(), typeof(string));
                cols.Add(dt.Rows[i]["ParameterName"].ToString());
            }
            foreach (var dic in DataColums)
            {
                DataRow drNew = dtNew.NewRow();
                drNew[0] = dic.Key;
                for (int n = 1; n < dtNew.Columns.Count; n++)
                {
                    DataRow[] dnewRow = dt.Select(groupingColumn + " ='" + dtNew.Columns[n].ColumnName + "'");
                    if (dnewRow.Length != 0)
                    {
                        drNew[n] = dnewRow[0][dic.Value].ConvertToString();
                    }
                }
                dtNew.Rows.Add(drNew);
            }

            //2.获取前分页条数据
            string BatchNo = fiterCondition.Filter.BatchNo;

            var query = (from t in _context.Task
                         join o in _context.InspectionOrder on t.TaskId equals o.TaskId
                         where t.BatchNo == BatchNo
                         orderby o.OrderDateTime
                         select new TaskDtos.TaskDimensionOrderDto { InspectionOrderID= o.InspectionOrderId, OrderDateTime=o.OrderDateTime });

            List< TaskDtos.TaskDimensionOrderDto >  taskDimensionOrderDtos = query.Skip((fiterCondition.SkipCount - 1) * fiterCondition.MaxResultCount).Take(fiterCondition.MaxResultCount).ToList();
            List<long> orderids = taskDimensionOrderDtos.Select(c => c.InspectionOrderID).ToList();

            var detaillist = _context.InspectionOrderDetail.Include(c=>c.Parameter).Join(taskDimensionOrderDtos, s => s.InspectionOrderId, c => c.InspectionOrderID, (s, c) => new {
                ParameterValue= s.ParameterValue,
                ParameterName= s.Parameter.ParameterName,
                InspectionOrderId=s.InspectionOrderId
            }).ToList();

            //3.数据进行行转列
            foreach (TaskDtos.TaskDimensionOrderDto taskDimensionOrderDto in taskDimensionOrderDtos) {

                var details = detaillist.Where(c => c.InspectionOrderId == taskDimensionOrderDto.InspectionOrderID);
                DataTable dtcontent = ToDataTable(details);
                DataRow drNew = dtNew.NewRow();
                drNew[0] = taskDimensionOrderDto.OrderDateTime;
                for (int n = 1; n < dtNew.Columns.Count; n++)
                {
                    DataRow[] dnewRow = dtcontent.Select(groupingColumn + " ='" + dtNew.Columns[n].ColumnName + "'");
                    if (dnewRow.Length != 0)
                    {
                        drNew[n] = dnewRow[0]["ParameterValue"].ConvertToString();
                    }
                }
                dtNew.Rows.Add(drNew);
            }
            object obj = JsonConvert.DeserializeObject(dtNew.ToJsonString());
            TaskDtos.TaskDimensionDetailDto taskDimensionDetailDto = new TaskDtos.TaskDimensionDetailDto();
            taskDimensionDetailDto.obj = obj;
            taskDimensionDetailDto.cols = cols;
            return new Tuple<TaskDtos.TaskDimensionDetailDto, int>(taskDimensionDetailDto, query.Count());
        }
        public  DataTable ToDataTable<T>( IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    List<object> tempList = new List<object>();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }
        /// <summary>
        /// 同步数据
        /// </summary>
        public void SyncTaskDefectReportData() {

            List<Task> tasks= _context.Task.Where(c=>c.WorkProcessId==_appsetting.Value.VisionWPID).OrderByDescending(c => c.TaskId).ToList();
           
            foreach (Task task in tasks) {
               var vtask= _context.VtaskDefectReport.Where(c => c.TaskId == task.TaskId).FirstOrDefault();
                if (vtask != null)
                    break;
                var query=  _context.VinspectionOrderDetail.Include(c => c.VinspectionOrder).Where(c => c.VinspectionOrder.TaskId == task.TaskId);
                List<VtaskDefectReport> vTaskDefectReports= query.GroupBy(c => new { c.DefectItemId }).Select(c => new VtaskDefectReport { TaskId=task.TaskId, DefectItemId=c.Key.DefectItemId, DefectItemNum = c.Count() }).ToList();
                _context.VtaskDefectReport.AddRange(vTaskDefectReports);
                _context.SaveChanges();
            }
        }
    }
}
