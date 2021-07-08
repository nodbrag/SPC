using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPC.Core.Extensions;
using SPC.Models.DtoModel;
using SPC.Core.Models;
using SPC.IService;

namespace SPC.Api.Controllers
{
    /// <summary>
    ///     系统设置接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "SystemSetting")]
    public class SystemSettingController : ControllerBase
    {
        /// <summary>
        ///     创建系统设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ExecResult Create(SystemSettingDtos.SystemSettingDto model)
        {
            var result = new ExecResult();
            try
            {
                _iSystemSettingService.Create(model);
                result.Success = true;
                result.Status = ExecResultStatus.Success;
                result.Result = "";
                result.Message = "";
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ExecResultStatus.Error; 
                result.Result = "";
                result.Message = ex.GetInnerException();
                return result;
            }
        }

        /// <summary>
        ///     修改系统设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ExecResult Update(SystemSettingDtos.SystemSettingDto model)
        {
            var result = new ExecResult();
            try
            {
                _iSystemSettingService.Update(model);
                result.Success = true;
                result.Status = ExecResultStatus.Success;
                result.Result = "";
                result.Message = "";
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ExecResultStatus.Error;
                result.Result = "";
                result.Message = ex.GetInnerException();
                return result;
            }
        }

        /// <summary>
        ///     修改系统设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public ExecResult Delete(int id)
        {
            var result = new ExecResult();
            try
            {
                _iSystemSettingService.Delete(id);
                result.Success = true;
                result.Status = ExecResultStatus.Success;
                result.Result = "";
                result.Message = "";
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ExecResultStatus.Error;
                result.Result = "";
                result.Message = ex.GetInnerException();
                return result;
            }
        }

        /// <summary>
        ///     根据ID获取系统设置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ExecResult GetById(int key)
        {
            var result = new ExecResult();
            try
            {
                var setting = _iSystemSettingService.GetById(key);
                result.Success = true;
                result.Status = ExecResultStatus.Success;
                result.Result = JsonConvert.SerializeObject(setting, Formatting.Indented);
                result.Message = "";
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ExecResultStatus.Error;
                result.Result = "";
                result.Message = ex.GetInnerException();
                return result;
            }
        }

       

        /// <summary>
        ///     获取系统设置列表--分页
        /// </summary>
        /// <param name="paginationFilter"></param>
        /// <returns></returns>
        [HttpPost]
        public ExecResult GetListForPagination(PaginationFilter paginationFilter)
        {
            var result = new ExecResult();
            try
            {
                var setting = _iSystemSettingService.GetListForPagination(paginationFilter);
                result.Success = true;
                result.Status = ExecResultStatus.Success;
                result.Result = JsonConvert.SerializeObject(setting);
                result.Message = "";
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ExecResultStatus.Error;
                result.Result = "";
                result.Message = ex.GetInnerException();
                return result;
            }
        }

        /// <summary>
        ///     获取系统设置列表
        /// </summary>
        /// <param name="paginationFilter"></param>
        /// <returns></returns>
        [HttpPost]
        public ExecResult GetList(SortFilter sortFilter)
        {
            var result = new ExecResult();
            try
            {
                var setting = _iSystemSettingService.GetList(sortFilter);
                result.Success = true;
                result.Status = ExecResultStatus.Success;
                result.Result = JsonConvert.SerializeObject(setting);
                result.Message = "";
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ExecResultStatus.Error;
                result.Result = "";
                result.Message = ex.GetInnerException();
                return result;
            }
        }

        #region 构造函数

        private readonly ISystemSettingService _iSystemSettingService;

        public SystemSettingController(ISystemSettingService iSystemSettingService)
        {
            _iSystemSettingService = iSystemSettingService;
        }

        #endregion
    }
}