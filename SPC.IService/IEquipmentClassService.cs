/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 17:38:10                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： IEquipmentClassRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface IEquipmentClassService
    {
        /// <summary>
        /// 创建EquipmentClass
        /// </summary>
        /// <param name="model"></param>
        void CreateEquipmentClass(EquipmentClassDtos.EquipmentClassDto model);
        /// <summary>
        /// 修改EquipmentClass
        /// </summary>
        /// <param name="model"></param>
        void UpdateEquipmentClass(EquipmentClassDtos.EquipmentClassDto model);
        /// <summary>
        /// 删除EquipmentClass根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteEquipmentClass(int id);
        /// <summary>
        /// 通过编号获取EquipmentClass信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EquipmentClassDtos.EquipmentClassDto GetEquipmentClassByID(int id);
        /// <summary>
        /// 获取所有EquipmentClass 列表信息
        /// </summary>
        /// <returns></returns>
        List<EquipmentClassDtos.EquipmentClassDto> GetEquipmentClassList();
        /// <summary>
        /// 通过过滤条件获取EquipmentClass分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<EquipmentClassDtos.EquipmentClassDto>, int> GetEquipmentClassListForPagination(FiterConditionBase<EquipmentClassDtos.EquipmentClassFilterDto> fiterCondition);

    }
}

