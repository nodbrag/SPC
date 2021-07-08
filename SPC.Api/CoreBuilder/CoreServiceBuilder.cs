using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using SPC.Core.Extensions;
using SPC.Core.Filter;
using SPC.Core.IocHelper;
using SPC.Core.Provider;
using SPC.Core.Route;
using SPC.IService;
using SPC.Models.DataModel;
using SPC.Service;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Builder;


namespace SPC.Api.CoreBuilder
{
    public class CoreServiceBuilder : ICoreServiceBuilder
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _provider;

        public CoreServiceBuilder(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
            _provider = services.BuildServiceProvider();//get an instance of IServiceProvider
        }

        public void AddAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.IgnoreUnmapped();
            });
        }

        public void AddCache()
        {
            throw new NotImplementedException();
        }

        public void AddCors()
        {
            _services.AddCors(options =>
            {
                options.AddPolicy("AllRequests", policy =>
                {
                    policy
                        .AllowAnyOrigin()//允许任何源
                        .AllowAnyMethod()//允许任何方式
                        .AllowAnyHeader()//允许任何头
                        .AllowCredentials();//允许cookie
                });

                //一般采用这种方法
                options.AddPolicy("LimitRequests", policy =>
                {
                    policy
                        .WithOrigins(_configuration["AppSettings:Audience"])//支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                        .AllowAnyHeader()//Ensures that the policy allows any header.
                        .AllowAnyMethod();
                });

            });
        }

        public void AddDbcontext()
        {
            int DatabaseType = _configuration["AppSettings:DataBaseType"].ConvertToNullableInt().Value;

            if (DatabaseType == 1)
            {

                _services.AddDbContext<SPCContext>
                  (options => options.UseMySql(_configuration["AppSettings:MySqlConnectionString"]));
            }
            else
            {
                _services.AddDbContext<SPCContext>
                  (options => options.UseSqlServer(_configuration["AppSettings:SQLServerConnectionString"]));
            }
        }

        public void AddHttpContext()
        {
            throw new NotImplementedException();
        }

        public void AddJwtAuth()
        {
            _services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });
            //添加jwt验证：
           /* _services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience
                    ValidateLifetime = true,//是否验证失效时间
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    ValidAudience = _configuration["AppSettings:Audience"],//Audience
                    ValidIssuer = _configuration["AppSettings:Issuer"],//Issuer，这两项和前面签发jwt的设置一致
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["AppSettings:SecurityKey"]))//拿到SecurityKey
                };
            });*/
        }

        public void AddLog()
        {
            throw new NotImplementedException();
        }

        public void AddMvcExtensions()
        {
            _services.AddMvc(options =>
            {
                // options.UseCentralRoutePrefix(new RouteAttribute("api/v1/[controller]/[action]"));
                //异常过滤
                options.Filters.Add<ExceptionFilter>();
                //请求参数过滤
                options.Filters.Add<ModelValidaionFilter>();
                //授权过滤
                options.Filters.Add<RequestAuthorizeAttribute>();

            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddFluentValidation()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //options.SerializerSettings.ContractResolver =  new CamelCasePropertyNamesContractResolver(); //驼峰命名  new DefaultContractResolver(); //保持一致  
                options.SerializerSettings.DateFormatHandling =  Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//设置时间格式
            });
        }

        public void AddSwaggerGenerator()
        {
            _services.AddScoped<SwaggerGenerator>();
            _services.AddSwaggerGen(sg =>
            {
                #region 文档分类

                 sg.SwaggerDoc("SystemSetting", new Info
                 {
                     Title = "系统设置",
                     Version = "1.0",
                     Description = "系统设置相关接口"
                 });
                 sg.SwaggerDoc("BasicInformation", new Info
                 {
                     Title = "基础档案",
                     Version = "1.0",
                     Description = "基础档案相关接口"
                 });
                 sg.SwaggerDoc("DataClass", new Info
                 {
                     Title = "数据分类",
                     Version = "1.0",
                     Description = "数据分类相关接口"
                 });
                 sg.SwaggerDoc("SPCAnalysis", new Info
                 {
                     Title = "SPC分析",
                     Version = "1.0",
                     Description = "SPC分析相关接口"
                 });
                #endregion

                sg.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "请输入带有Bearer的Token",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                sg.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                    {
                        { "Bearer", Enumerable.Empty<string>() }
                    });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "SPC.Api.xml");
                var xmlPathByModel = Path.Combine(basePath, "SPC.Models.xml");
                var xmlPathByCoreModel = Path.Combine(basePath, "SPC.Core.xml");
                sg.IncludeXmlComments(xmlPathByCoreModel);
                sg.IncludeXmlComments(xmlPathByModel);
                sg.IncludeXmlComments(xmlPath, true);
                sg.OperationFilter<Core.Swagger.SwaggerOperationFilter>(); // 新增swagger过滤
                //sg.DescribeAllEnumsAsStrings();//显示枚举值名称
                //sg.DescribeStringEnumsInCamelCase();//驼峰命名法显示枚举值名称
            });
        }

        public void AddMiniProfiler()
        {
            //注入MiniProfiler性能监测
            _services.AddMiniProfiler(options =>
                options.RouteBasePath = "/profiler"
            ).AddEntityFramework();
        }

        public void AddAppService()
        {
            _services.RegisterAssembly("SPC.IService", "SPC.Service");
        }
        public void AddFluentValidationService()
        {
            //注册所有验证类 当个添加例如：services.AddSingleton<IValidator<EMSApi.Dots.UserDots.UserModification>, Validators.UserValidator>();
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.BaseType != null && p.BaseType.GetInterfaces().Any(x => x == typeof(IValidator)));
            foreach (var type in types)
            {
                var baseType = type.BaseType;
                if (baseType.GenericTypeArguments.Any())
                {
                    var genericType = typeof(IValidator<>).MakeGenericType(baseType.GenericTypeArguments[0]);
                    _services.AddScoped(genericType, type);
                }
            }
        }

        public void AddInvalidModelStateResponse()
        {
            _services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState
                        .Values
                        .SelectMany(x => x.Errors
                            .Select(p => p.ErrorMessage))
                        .ToList();

                    if (errors.Count > 0)
                    {
                        var result = new
                        {
                            
                            success = false,
                            message = string.Join(",", errors.ToArray()),
                            status = 2,
                            result = ""
                        };
                        return new  BadRequestObjectResult(result);
                    }
                    else
                    {
                        return new OkResult();
                    }
                };
            });
        }

    }
}