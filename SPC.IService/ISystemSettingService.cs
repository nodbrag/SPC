using System.Collections.Generic;
using SPC.Core.Models;
using SPC.Models.DtoModel;

namespace SPC.IService
{
    public interface ISystemSettingService
   {
       /// <summary>
       /// 创建
       /// </summary>
       /// <param name="model"></param>
       void Create(SystemSettingDtos.SystemSettingDto model);
       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="model"></param>
       void Update(SystemSettingDtos.SystemSettingDto model);
       /// <summary>
       /// 删除，根据ID
       /// </summary>
       /// <param name="id"></param>
       void Delete(int id);
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        SystemSettingDtos.SystemSettingDto GetById(int id);
        /// <summary>
        /// 获取列--分页
        /// </summary>
        /// <param name="paginationFilter"></param>
        /// <returns></returns>
        Pagination GetListForPagination(PaginationFilter paginationFilter);

        /// <summary>
        /// 获取列表，不分页
        /// </summary>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        IList<SystemSettingDtos.SystemSettingDto> GetList(SortFilter sortFilter);

       
   }
}
