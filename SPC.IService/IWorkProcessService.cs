/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-18 09:03:34                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： IWorkProcessService                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface IWorkProcessService
    {
        /// <summary>
        /// 创建WorkProcess
        /// </summary>
        /// <param name="model"></param>
        void CreateWorkProcess(WorkProcessDtos.WorkProcessDto model);
        /// <summary>
        /// 修改WorkProcess
        /// </summary>
        /// <param name="model"></param>
        void UpdateWorkProcess(WorkProcessDtos.WorkProcessDto model);
        /// <summary>
        /// 删除WorkProcess根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteWorkProcess(int id);
        /// <summary>
        /// 通过编号获取WorkProcess信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WorkProcessDtos.WorkProcessDto GetWorkProcessByID(int id);
        /// <summary>
        /// 获取所有WorkProcess 列表信息
        /// </summary>
        /// <returns></returns>
        List<WorkProcessDtos.WorkProcessDto> GetWorkProcessList();
        /// <summary>
        /// 通过过滤条件获取WorkProcess分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<WorkProcessDtos.WorkProcessDto>, int> GetWorkProcessListForPagination(FiterConditionBase<WorkProcessDtos.WorkProcessFilterDto> fiterCondition);

    }
}

