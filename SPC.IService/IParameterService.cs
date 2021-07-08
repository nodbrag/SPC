/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-18 09:03:34                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： IParameterRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface IParameterService
    {
        /// <summary>
        /// 创建Parameter
        /// </summary>
        /// <param name="model"></param>
        void CreateParameter(ParameterDtos.ParameterDto model);
        /// <summary>
        /// 修改Parameter
        /// </summary>
        /// <param name="model"></param>
        void UpdateParameter(ParameterDtos.ParameterDto model);
        /// <summary>
        /// 删除Parameter根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteParameter(int id);
        /// <summary>
        /// 通过编号获取Parameter信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ParameterDtos.ParameterDto GetParameterByID(int id);
        /// <summary>
        /// 获取所有Parameter 列表信息
        /// </summary>
        /// <returns></returns>
        List<ParameterDtos.ParameterDto> GetParameterList();
        /// <summary>
        /// 通过过滤条件获取Parameter分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<ParameterDtos.ParameterDto>, int> GetParameterListForPagination(FiterConditionBase<ParameterDtos.ParameterFilterDto> fiterCondition);

    }
}

