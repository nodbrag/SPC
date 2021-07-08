/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-18 09:03:34                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： ITaskRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface ITaskService
    {
        /// <summary>
        /// 创建Task
        /// </summary>
        /// <param name="model"></param>
        void CreateTask(TaskDtos.TaskDto model);
        /// <summary>
        /// 创建多任务
        /// </summary>
        /// <param name="models"></param>
        void CreateTasks(List<TaskDtos.TaskDto> models);
        /// <summary>
        /// 修改Task
        /// </summary>
        /// <param name="model"></param>
        void UpdateTask(TaskDtos.TaskDto model);
        /// <summary>
        /// 删除Task根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteTask(int id);
        /// <summary>
        /// 通过编号获取Task信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TaskDtos.TaskDto GetTaskByID(int id);
        /// <summary>
        /// 获取所有Task 列表信息
        /// </summary>
        /// <returns></returns>
        List<TaskDtos.TaskDto> GetTaskList();
        /// <summary>
        /// 根据批次获取离散数据
        /// </summary>
        /// <param name="batchNo"></param>
        /// <returns></returns>
        List<TaskDtos.TaskDto> getTaskByBatch(string batchNo);
        /// <summary>
        /// 根据批次删除离散数据
        /// </summary>
        /// <param name="batchNo"></param>
        /// <returns></returns>
        void deleteTaskByBatch(string batchNo);
        /// <summary>
        /// 通过过滤条件获取Task分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<TaskDtos.TaskDto>, int> GetTaskListForPagination(FiterConditionBase<TaskDtos.TaskFilterDto> fiterCondition);
        /// <summary>
        /// 获取离散数据列表
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<TaskDtos.TaskDiscreteDto>, int> GetDiscreteList(FiterConditionBase<TaskDtos.TaskDiscreteFilterDto> fiterCondition);
        /// <summary>
        /// 根据批次获取详情
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple< TaskDtos.TaskDimensionDetailDto, int> GetDimensionDetailList(FiterConditionBase<TaskDtos.TaskDimensionDetailFilterDto> fiterCondition);
        /// <summary>
        /// 导入尺寸数据
        /// </summary>
        /// <param name="model"></param>
        void ImportDimensionData(TaskDtos.TaskDimensionDto model);
        /// <summary>
        ///  导入视觉数据
        /// </summary>
        /// <param name="taskVisionCheckDto"></param>
        int ImportVisionCheckData(TaskDtos.TaskVisionCheckDto taskVisionCheckDto);
        /// <summary>
        /// 同步任务缺陷数据
        /// </summary>
        void SyncTaskDefectReportData();

    }
}

