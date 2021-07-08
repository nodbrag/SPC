/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 17:38:10                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： IEquipmentService                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface IEquipmentService
    {
        /// <summary>
        /// 创建Equipment
        /// </summary>
        /// <param name="model"></param>
        void CreateEquipment(EquipmentDtos.EquipmentDto model);
        /// <summary>
        /// 修改Equipment
        /// </summary>
        /// <param name="model"></param>
        void UpdateEquipment(EquipmentDtos.EquipmentDto model);
        /// <summary>
        /// 删除Equipment根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteEquipment(int id);
        /// <summary>
        /// 通过编号获取Equipment信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EquipmentDtos.EquipmentDto GetEquipmentByID(int id);
        /// <summary>
        /// 获取所有Equipment 列表信息
        /// </summary>
        /// <returns></returns>
        List<EquipmentDtos.EquipmentDto> GetEquipmentList();
        /// <summary>
        /// 通过过滤条件获取Equipment分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<EquipmentDtos.EquipmentDto>, int> GetEquipmentListForPagination(FiterConditionBase<EquipmentDtos.EquipmentFilterDto> fiterCondition);

    }
}

