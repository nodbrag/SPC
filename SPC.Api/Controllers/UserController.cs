using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using SPC.Core.Extensions;
using SPC.IService;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using SPC.Core.Filter;
namespace SPC.Api.Controllers
{
    /// <summary>
    /// 用户管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "SystemSetting")]
    public class UserController : SpcControllerBase
    {
        private readonly  IUserService _userService;
        private readonly ILogger _logger;
        public UserController(IUserService userService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _userService = userService;
        }
        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <param name="authUser">用户授权信息</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IExecResult UserToken([FromBody] UserDtos.UserTokenRequest authUser)
        {
            try
            {
                return _userService.UserToken(authUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     创建用户
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateUser([FromBody]UserDtos.UserDto model)
        {
            try
            {
                _userService.CreateUser(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userDto">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateUser([FromBody]UserDtos.UserDto  userDto)
        {
            try
            {
                _userService.UpdateUser(userDto);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取用户信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<UserDtos.UserDto> GetUserByID(int id)
        {
            try
            {
                UserDtos.UserDto userDto= _userService.GetUserByID(id);
                return new OkOpResult<UserDtos.UserDto>(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<UserDtos.UserDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有用户列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<UserDtos.UserDto> GetUserList()
        {
            try
            {
                List<UserDtos.UserDto> userDtos = _userService.GetUserList();
                return new OkOpPageResult<UserDtos.UserDto>(userDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<UserDtos.UserDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过过滤条件获取用户分页数据
        /// </summary>
        /// <param name="fiterCondition">过滤条件</param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<UserDtos.UserDto> GetUserListForPagination([FromBody]FiterConditionBase<UserDtos.UserFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetUserList();
                Tuple<List<UserDtos.UserDto>, int> list = _userService.GetUserListForPagination(fiterCondition);
                return new OkOpPageResult<UserDtos.UserDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<UserDtos.UserDto>(ex.GetInnerException());
            }
           
        }

    }
}