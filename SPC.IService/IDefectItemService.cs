/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-18 09:03:34                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： IDefectItemService                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface IDefectItemService
    {
        /// <summary>
        /// 创建DefectItem
        /// </summary>
        /// <param name="model"></param>
        void CreateDefectItem(DefectItemDtos.DefectItemDto model);
        /// <summary>
        /// 修改DefectItem
        /// </summary>
        /// <param name="model"></param>
        void UpdateDefectItem(DefectItemDtos.DefectItemDto model);
        /// <summary>
        /// 删除DefectItem根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteDefectItem(int id);
        /// <summary>
        /// 通过编号获取DefectItem信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DefectItemDtos.DefectItemDto GetDefectItemByID(int id);
        /// <summary>
        /// 获取所有DefectItem 列表信息
        /// </summary>
        /// <returns></returns>
        List<DefectItemDtos.DefectItemDto> GetDefectItemList();
        /// <summary>
        /// 通过过滤条件获取DefectItem分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<DefectItemDtos.DefectItemDto>, int> GetDefectItemListForPagination(FiterConditionBase<DefectItemDtos.DefectItemFilterDto> fiterCondition);

    }
}

