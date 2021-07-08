/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： ProductController                                    
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

namespace SPC.Api.Controllers
{
    /// <summary>
    /// 产品管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "BasicInformation")]
    public class ProductController : ControllerBase
    {
        private readonly  IProductService _ProductService;
        private readonly ILogger _logger;
        public ProductController(IProductService ProductService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _ProductService = ProductService;
        }
        /// <summary>
        ///     创建产品
        /// </summary>
        /// <param name="model">产品信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateProduct([FromBody]ProductDtos.ProductDto model)
        {
            try
            {
                _ProductService.CreateProduct(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     修改产品
        /// </summary>
        /// <param name="model">产品信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateProduct([FromBody]ProductDtos.ProductDto model)
        {
            try
            {
                _ProductService.UpdateProduct(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteProduct(int id)
        {
            try
            {
                _ProductService.DeleteProduct(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取产品信息
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<ProductDtos.ProductDto> GetProductByID(int id)
        {
            try
            {
                ProductDtos.ProductDto ProductDto= _ProductService.GetProductByID(id);
                return new OkOpResult<ProductDtos.ProductDto>(ProductDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<ProductDtos.ProductDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有产品列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<ProductDtos.ProductDto> GetProductList()
        {
            try
            {
                List<ProductDtos.ProductDto> ProductDtos = _ProductService.GetProductList();
                return new OkOpPageResult<ProductDtos.ProductDto>(ProductDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<ProductDtos.ProductDto>(ex.GetInnerException());
            }
        }
        
        /// <summary>
        /// 通过过滤条件获取产品分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<ProductDtos.ProductDto> GetProductListForPagination([FromBody]FiterConditionBase<ProductDtos.ProductFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetProductList();
                Tuple<List<ProductDtos.ProductDto>, int> list = _ProductService.GetProductListForPagination(fiterCondition);
                return new OkOpPageResult<ProductDtos.ProductDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<ProductDtos.ProductDto>(ex.GetInnerException());
            }
           
        }

    }
}
