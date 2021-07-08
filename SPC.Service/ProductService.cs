/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： ProductService                                    
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.IService;
using SPC.Models.DtoModel;
using SPC.Models.DataModel;
using SPC.Core.Dtos;
using SPC.Core.Extensions;
using System.Reflection;
using System.Linq;
using SPC.Core.Attribute;
using SPC.Core.Utility;
using SPC.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SPC.Service
{
    public class ProductService : IProductService
    {
        private readonly SPCContext _context;

        public ProductService(SPCContext context)
        {
            this._context = context;
        }

        public void CreateProduct(ProductDtos.ProductDto model)
        {
            _context.Product.Add(model.MapTo<Product>());
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product entity= _context.Product.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的Product不存在!");
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public ProductDtos.ProductDto GetProductByID(int id)
        {
            Product entity = _context.Product.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的Product不存在!");
            return entity.MapTo<ProductDtos.ProductDto>();
        }

        public List<ProductDtos.ProductDto> GetProductList()
        {
            return _context.Product.Select<ProductDtos.ProductDto>().AsNoTracking().ToList();
        }

        public Tuple<List<ProductDtos.ProductDto>, int> GetProductListForPagination(FiterConditionBase<ProductDtos.ProductFilterDto> fiterCondition)
        {
            var query = _context.Product.AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<Product>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<Product> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }
            return query.Select<ProductDtos.ProductDto>().GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateProduct(ProductDtos.ProductDto model)
        {
             _context.Product.Update(model.MapTo<Product>());
            _context.SaveChanges();
        }
    }
}
