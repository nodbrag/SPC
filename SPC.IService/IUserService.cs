using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace SPC.IService
{
    public interface IUserService
    {
        /// <summary>
        /// 创建User
        /// </summary>
        /// <param name="model"></param>
        void CreateUser(UserDtos.UserDto model);
        /// <summary>
        /// 修改User
        /// </summary>
        /// <param name="model"></param>
        void UpdateUser(UserDtos.UserDto model);
        /// <summary>
        /// 删除User根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(int id);
        /// <summary>
        /// 通过编号获取User信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDtos.UserDto GetUserByID(int id);
        /// <summary>
        /// 获取所有User 列表信息
        /// </summary>
        /// <returns></returns>
        List<UserDtos.UserDto> GetUserList();
        /// <summary>
        /// 通过过滤条件获取User分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<UserDtos.UserDto>, int> GetUserListForPagination(FiterConditionBase<UserDtos.UserFilterDto> fiterCondition);

        /// <summary>
        /// 用户授权
        /// </summary>
        /// <param name="userTokenRequest"></param>
        /// <returns></returns>
        IExecResult UserToken(UserDtos.UserTokenRequest userTokenRequest);

    }
}
