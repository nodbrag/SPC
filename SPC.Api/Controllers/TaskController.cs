/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： TaskController                                    
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using SPC.Core.Extensions;
using SPC.IService;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;
using Microsoft.Extensions.Logging;
using SPC.Core.Filter;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SPC.Api.Controllers
{
    /// <summary>
    /// 任务管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "DataClass")]
    public class TaskController : ControllerBase
    {
        private readonly  ITaskService _TaskService;
        private readonly ILogger _logger;
        public TaskController(ITaskService TaskService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _TaskService = TaskService;
        }
        /// <summary>
        ///     创建单任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateTask([FromBody]TaskDtos.TaskDto model)
        {
            try
            {
                _TaskService.CreateTask(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     创建多任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateTasks([FromBody]List<TaskDtos.TaskDto> models)
        {
            try
            {
                _TaskService.CreateTasks(models);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 上传excel文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult uploadExcel(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var fileDir = AppDomain.CurrentDomain.BaseDirectory + "\\datas";
                    if (!Directory.Exists(fileDir))
                    {
                        Directory.CreateDirectory(fileDir);
                    }
                    //文件名称
                    string projectFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + file.FileName;

                    //上传的文件的路径
                    string filePath = fileDir + $@"\{projectFileName}";
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                    var ok = new { path = filePath };
                    return new OkOpResult(ok);
                }
                else
                {
                    return new BadOpResult("没有上传");
                }
            }
            catch (Exception ex)
            {

                return new BadOpResult(ex.GetInnerException());
            }
           
        }
        /// <summary>
        /// 导入离散数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult ImportDimensionData([FromBody]TaskDtos.TaskDimensionDto model)
        {
            try
            {
                _TaskService.ImportDimensionData(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }

        }
        /// <summary>
        /// 导入视觉检测数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult ImportVisionCheckData([FromBody] string JsonData)
        {
            try
            {
               //string j= JsonData.ToJsonString();
                TaskDtos.TaskVisionCheckDto task = JsonConvert.DeserializeObject<TaskDtos.TaskVisionCheckDto>(JsonData);
                int taskid=_TaskService.ImportVisionCheckData(task);
                return new OkOpResult(new { TaskId=taskid });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }

        }
        /// <summary>
        /// 导入视觉检测数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult ImportVisionCheckData2([FromBody] TaskDtos.TaskVisionCheckDto task)
        {
            try
            {
                //string j= JsonData.ToJsonString();
                //TaskDtos.TaskVisionCheckDto task = JsonConvert.DeserializeObject<TaskDtos.TaskVisionCheckDto>(JsonData);
                int taskid = _TaskService.ImportVisionCheckData(task);
                return new OkOpResult(new { TaskId = taskid });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }

        }
        /// <summary>
        ///     修改任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateTask([FromBody]TaskDtos.TaskDto model)
        {
            try
            {
                _TaskService.UpdateTask(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 根据批次号获取离散数据
        /// </summary>
        /// <param name="batchNo"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult getTaskByBatch(string batchNo)
        {
            try
            {
                return new OkOpResult(_TaskService.getTaskByBatch(batchNo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 根据批次删除离散数据
        /// </summary>
        /// <param name="batchNo"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult deleteTaskByBatch(string batchNo)
        {
            try
            {
                //return new OkOpResult(_TaskService.deleteTaskByBatch(batchNo));
                _TaskService.deleteTaskByBatch(batchNo);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteTask(int id)
        {
            try
            {
                _TaskService.DeleteTask(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取任务信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<TaskDtos.TaskDto> GetTaskByID(int id)
        {
            try
            {
                TaskDtos.TaskDto TaskDto= _TaskService.GetTaskByID(id);
                return new OkOpResult<TaskDtos.TaskDto>(TaskDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<TaskDtos.TaskDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取尺寸详情数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetDimensionDetailList([FromBody]FiterConditionBase<TaskDtos.TaskDimensionDetailFilterDto> fiterCondition)
        {
            try
            {
                Tuple<TaskDtos.TaskDimensionDetailDto, int> list =  _TaskService.GetDimensionDetailList(fiterCondition);
                var obj = new { success= true,message= "操作成功!",status= 1,result=new{ cols=list.Item1.cols, items= list.Item1.obj, totalCount= list.Item2 } };
                return new OkObjectResult(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadRequestResult();
            }
        }
        /// <summary>
        /// 获取离散数据接口
        /// </summary>
        /// <param name="fiterCondition">过滤条件</param>
        /// <returns></returns>
        [HttpPost]
         public IExecPageResult<TaskDtos.TaskDiscreteDto> GetDiscreteList([FromBody]FiterConditionBase<TaskDtos.TaskDiscreteFilterDto> fiterCondition) {

            try
            {
                Tuple<List<TaskDtos.TaskDiscreteDto>, int> list = _TaskService.GetDiscreteList(fiterCondition);
                return new OkOpPageResult<TaskDtos.TaskDiscreteDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<TaskDtos.TaskDiscreteDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有任务列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<TaskDtos.TaskDto> GetTaskList()
        {
            try
            {
                List<TaskDtos.TaskDto> TaskDtos = _TaskService.GetTaskList();
                return new OkOpPageResult<TaskDtos.TaskDto>(TaskDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<TaskDtos.TaskDto>(ex.GetInnerException());
            }
        }
        
        /// <summary>
        /// 通过过滤条件获取任务分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<TaskDtos.TaskDto> GetTaskListForPagination([FromBody]FiterConditionBase<TaskDtos.TaskFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetTaskList();
                Tuple<List<TaskDtos.TaskDto>, int> list = _TaskService.GetTaskListForPagination(fiterCondition);
                return new OkOpPageResult<TaskDtos.TaskDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<TaskDtos.TaskDto>(ex.GetInnerException());
            }
           
        }
        
        [HttpGet]
        public IExecResult SyncTaskDefectReportData()
        {
            try
            {
                _TaskService.SyncTaskDefectReportData();
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }

    }
}
