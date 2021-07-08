using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPC.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using SPC.IService;
using Microsoft.Extensions.Logging;
using SPC.Core.Filter;
using SPC.Core.Extensions;

namespace SPC.Api.Controllers
{
    /// <summary>
    /// 公共字典接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "SystemSetting")]
    public class CommonDictionryController : SpcControllerBase
    {
        private readonly ICommonDictionryService _commonDictionryService;
        private readonly ILogger _logger;
        public CommonDictionryController(ICommonDictionryService commonDictionryService, ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
            _commonDictionryService = commonDictionryService;
        }

        /// <summary>
        /// 获取公共字典数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IExecResult GetCommonDictionryList()
        {
            try
            {
                return _commonDictionryService.GetCommonDictionry();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());

                return new BadOpResult(OpResultStatus.Error);
            }
        }
    }
}
