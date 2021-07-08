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
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using SPC.Core.Models;
using Microsoft.EntityFrameworkCore;
using SPC.Core.Attribute;
using SPC.Core.Utility;

namespace SPC.Service
{
    public class UserService : IUserService
    {
        private readonly SPCContext _context;
        private readonly IOptions<AppSettings> _appsetting;
        public UserService(SPCContext context, IOptions<AppSettings> settings)
        {
            _context = context;
            _appsetting = settings;
        }
        public void CreateUser(UserDtos.UserDto model)
        {
            User newUser = model.MapTo<User>();
            newUser.Password = _appsetting.Value.DefaultPassword.ToMd5();
            List<UserRole> userRoles = new List<UserRole>();
            foreach (int id in model.RoleID)
            {
                UserRole userRole = new UserRole();
                userRole.RoleId = id;
                userRole.UserId = newUser.UserId;
                userRoles.Add(userRole);
            }
            newUser.UserRole = userRoles;
            _context.Add(newUser);
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            User user = _context.User.Find(id);
            if (user == null)
                throw new Exception("编号为" + id + "的用户不存在!");
            _context.Remove(user);

            List<UserRole> userRoles = _context.UserRole.Where(c => c.UserId == id).ToList();
             if(userRoles.Count>0)
            _context.RemoveRange(userRoles);

            _context.SaveChanges();
        }
        public UserDtos.UserDto GetUserByID(int id)
        {
            User user = _context.User.Find(id);
            if (user == null)
                throw new Exception("编号为" + id + "的用户不存在!");
            return user.MapTo<UserDtos.UserDto>();
        }

        public List<UserDtos.UserDto> GetUserList()
        {
            return  _context.User.Include(c => c.UserRole).Select(c => new UserDtos.UserDto
            {
                EMail = c.Email,
                MobilePhone = c.MobilePhone,
                Description = c.Description,
                IsUsed = c.IsUsed,
                RoleID = c.UserRole.Select(s => s.RoleId).ToList(),
                Telephone = c.Telephone,
                UserID = c.UserId,
                UserCode = c.UserCode,
                UserName = c.UserName
            }).ToList();
        }

        public Tuple<List<UserDtos.UserDto>, int> GetUserListForPagination(FiterConditionBase<UserDtos.UserFilterDto> fiterCondition)
        {
            var query = _context.User.Include(c => c.UserRole).AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition); 
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<User>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<User> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }
            return query.Select(c => new UserDtos.UserDto
            {
                EMail = c.Email,
                MobilePhone = c.MobilePhone,
                Description = c.Description,
                IsUsed = c.IsUsed,
                RoleID = c.UserRole.Select(s => s.RoleId).ToList(),
                Telephone = c.Telephone,
                UserID = c.UserId,
                UserCode = c.UserCode,
                UserName = c.UserName
            }).GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateUser(UserDtos.UserDto model)
        {
            User user = _context.User.Where(c=>c.UserId==model.UserID).AsNoTracking().FirstOrDefault();
            if(user==null)
                throw new Exception("编号为" + model.UserID + "的用户不存在!");
            User newUser = model.MapTo<User>();
            newUser.Password = user.Password;

            List<UserRole> userRoles = new List<UserRole>();
            foreach (int id in model.RoleID)
            {
                UserRole userRole = new UserRole();
                userRole.RoleId = id;
                userRole.UserId = newUser.UserId;
                userRoles.Add(userRole);
            }
            newUser.UserRole = userRoles;

            _context.User.Update(newUser);
            //删除角色
             userRoles= _context.UserRole.Where(c => c.UserId == model.UserID).ToList();
            _context.UserRole.RemoveRange(userRoles);

            _context.SaveChanges();
        }
        
        public IExecResult UserToken(UserDtos.UserTokenRequest userTokenRequest)
        {
            if (userTokenRequest.UserCode.IsNullOrEmpty() || userTokenRequest.Password.IsNullOrEmpty())
                return new BadOpResult("用户名或密码不能为空，登录失败!");
            User user =_context.User.Include(c=> c.UserRole).FirstOrDefault(c => c.IsUsed && c.Password == userTokenRequest.Password.ToMd5()&& c.UserCode == userTokenRequest.UserCode);
            if (user != null)
            {
                int roleid = 0;
                if (user.UserRole.Count() > 0) {
                   UserRole userRole=   user.UserRole.FirstOrDefault();
                    roleid = userRole != null ? userRole.RoleId : 0;
                }
                var tokenstr = Core.Auth.JWToken.getToken(_appsetting, user.UserCode, user.UserId.ToString(), roleid);

                return new OkOpResult(new
                {
                    User = new { UserCode = user.UserCode,RoleId=roleid, UserId = user.UserId, UserName = user.UserName },
                    Token = tokenstr
                });
            }
            return new BadOpResult("用户名或密码错误，登录失败!");
        }
    }
}
