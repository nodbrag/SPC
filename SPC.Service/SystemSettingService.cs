using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using SPC.Core.Extensions;
using SPC.Core.Models;
using SPC.Core.Utility;
using SPC.Models.DataModel;
using SPC.Models.DtoModel;
using SPC.IService;

namespace SPC.Service
{
    public class SystemSettingService : ISystemSettingService
    {
        #region 构造函数

        private readonly IOptions<AppSettings> _appsetting;

        public SystemSettingService(IOptions<AppSettings> settings)
        {
            _appsetting = settings;
        }

        #endregion

        /// <summary>
        ///     新增系统设置
        /// </summary>
        /// <param name="model"></param>
        public void Create(SystemSettingDtos.SystemSettingDto model)
        {
            try
            {
                using (var db = new SPCContext())
                {
                    var entity = new Models.DataModel.SystemSetting
                    {
                        //KeyID = SequenceHelper.GetSequence(_appsetting.Value.MachineId, _appsetting.Value.DataCenterId),
                         SystemSettingId=model.SystemSettingID,
                         SystemSettingKey=model.SystemSettingKey,
                         SystemSettingValue=model.SystemSettingValue,
                         Description = model.Description ?? ""
                    };
                    db.SystemSetting.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     修改系统设置
        /// </summary>
        /// <param name="model"></param>
        public void Update(SystemSettingDtos.SystemSettingDto model)
        {
            try
            {
                using (var db = new SPCContext())
                {
                    var entity = db.SystemSetting.Find(model.SystemSettingKey);
                    //存在性检查
                    if (entity == null)
                        throw new Exception("SystemSetting_RecordNotExist");
                    entity.SystemSettingId = model.SystemSettingID;
                    entity.SystemSettingKey = model.SystemSettingKey;
                    entity.SystemSettingValue = model.SystemSettingValue;
                    entity.Description = model.Description ?? "";
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     删除系统设置
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                using (var db = new SPCContext())
                {
                    var entity = db.SystemSetting.Find(id);
                    //存在性检查
                    if (entity == null)
                        throw new Exception("SystemSetting_RecordNotExist");

                    db.SystemSetting.Remove(entity);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SystemSettingDtos.SystemSettingDto GetById(int id)
        {
            try
            {
                using (var db = new SPCContext())
                {
                    //Find Record By ID
                    var mEntity = db.SystemSetting.Find(id);
                    if (mEntity == null)
                        throw new Exception("SystemSetting_RecordNotExist");
                    var query = from p in db.SystemSetting
                        where p.SystemSettingId == mEntity.SystemSettingId
                                select new SystemSettingDtos.SystemSettingDto
                        {
                            Description = p.Description,
                            SystemSettingID = p.SystemSettingId,
                            SystemSettingKey = p.SystemSettingKey,
                            SystemSettingValue = p.SystemSettingValue
                           
                        };
                    return query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        /// <summary>
        ///     获取系统设置数据---分页
        /// </summary>
        /// <param name="paginationFilter"></param>
        /// <returns></returns>
        public Pagination GetListForPagination(PaginationFilter paginationFilter)
        {
            try
            {
                using (var db = new SPCContext())
                {
                    var query = from a in db.SystemSetting
                        select new SystemSettingDtos.SystemSettingDto
                        {
                            
                            Description = a.Description,
                            SystemSettingID = a.SystemSettingId,
                            SystemSettingKey = a.SystemSettingKey,
                            SystemSettingValue = a.SystemSettingValue
                        };
                    //过滤条件
                    if (paginationFilter.Filters != null && paginationFilter.Filters.Count > 0)
                        foreach (var item in paginationFilter.Filters)
                            query = query.Where(LambdaProvider.GetLambdaByFilter<SystemSettingDtos.SystemSettingDto>(item));

                    //排序条件
                    if (paginationFilter.Sortings != null && paginationFilter.Sortings.Count > 0)
                        query = query.SortBy(paginationFilter.Sortings);

                    var pageIndex =
                        paginationFilter.PageIndex == 0 ? _appsetting.Value.PageIndex : paginationFilter.PageIndex;
                    var pageSize =
                        paginationFilter.PageSize == 0 ? _appsetting.Value.PageSize : paginationFilter.PageSize;
                    return query.AsPagination(pageIndex, pageSize);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     获取系统设置数据---分页
        /// </summary>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        public IList<SystemSettingDtos.SystemSettingDto> GetList(SortFilter sortFilter)
        {
            try
            {
                using (var db = new SPCContext())
                {
                    var query = from a in db.SystemSetting
                                select new SystemSettingDtos.SystemSettingDto
                                {
                                    Description = a.Description,
                                    SystemSettingID = a.SystemSettingId,
                                    SystemSettingKey = a.SystemSettingKey,
                                     SystemSettingValue=a.SystemSettingValue
                        };
                    //过滤条件
                    if (sortFilter.Filters != null && sortFilter.Filters.Count > 0)
                        foreach (var item in sortFilter.Filters)
                            query = query.Where(LambdaProvider.GetLambdaByFilter<SystemSettingDtos.SystemSettingDto>(item));

                    //排序条件
                    if (sortFilter.Sortings != null && sortFilter.Sortings.Count > 0)
                        query = query.SortBy(sortFilter.Sortings);

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}