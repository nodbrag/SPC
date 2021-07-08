/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-18 09:03:34                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： IProductService                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface IProductService
    {
        /// <summary>
        /// 创建Product
        /// </summary>
        /// <param name="model"></param>
        void CreateProduct(ProductDtos.ProductDto model);
        /// <summary>
        /// 修改Product
        /// </summary>
        /// <param name="model"></param>
        void UpdateProduct(ProductDtos.ProductDto model);
        /// <summary>
        /// 删除Product根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteProduct(int id);
        /// <summary>
        /// 通过编号获取Product信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDtos.ProductDto GetProductByID(int id);
        /// <summary>
        /// 获取所有Product 列表信息
        /// </summary>
        /// <returns></returns>
        List<ProductDtos.ProductDto> GetProductList();
        /// <summary>
        /// 通过过滤条件获取Product分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<ProductDtos.ProductDto>, int> GetProductListForPagination(FiterConditionBase<ProductDtos.ProductFilterDto> fiterCondition);

    }
}

