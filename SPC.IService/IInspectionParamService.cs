/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-18 09:03:34                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： IInspectionParamRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface IInspectionParamService
    {
        /// <summary>
        /// 创建InspectionParam
        /// </summary>
        /// <param name="model"></param>
        void CreateInspectionParam(InspectionParamDtos.InspectionParamDto model);
        /// <summary>
        /// 修改InspectionParam
        /// </summary>
        /// <param name="model"></param>
        void UpdateInspectionParam(InspectionParamDtos.InspectionParamDto model);
        /// <summary>
        /// 删除InspectionParam根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteInspectionParam(int id);
        /// <summary>
        /// 通过编号获取InspectionParam信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InspectionParamDtos.InspectionParamDto GetInspectionParamByID(int id);
        /// <summary>
        /// 获取所有InspectionParam 列表信息
        /// </summary>
        /// <returns></returns>
        List<InspectionParamDtos.InspectionParamDto> GetInspectionParamList();
        /// <summary>
        /// 通过过滤条件获取InspectionParam分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<InspectionParamDtos.InspectionParamDto>, int> GetInspectionParamListForPagination(FiterConditionBase<InspectionParamDtos.InspectionParamFilterDto> fiterCondition);

    }
}

