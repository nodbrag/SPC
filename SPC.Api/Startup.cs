using System;
using System.Text;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Extensions.Logging;
using NLog.Targets;
using NLog.Web;
using SPC.Api.CoreBuilder;
using SPC.Core.Middlewares;
using SPC.Core.Models;
using SPC.Models.DataModel;

namespace SPC.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ICoreServiceBuilder coreServiceBuilder = new CoreServiceBuilder(services, _configuration);
            coreServiceBuilder.AddDbcontext();
            coreServiceBuilder.AddAppService();
            coreServiceBuilder.AddFluentValidationService();
            coreServiceBuilder.AddMvcExtensions();
            coreServiceBuilder.AddSwaggerGenerator();
            coreServiceBuilder.AddAutoMapper();
            coreServiceBuilder.AddMiniProfiler();
            coreServiceBuilder.AddJwtAuth();
            coreServiceBuilder.AddCors();
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            //注入AppSettings配置
            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp,
            ILoggerFactory loggerFactory)
        {
            ICoreConfigurationBuilder coreConfigurationBuilder =
                new CoreConfigureBuilder(app, env, svp, _configuration);

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
               app.UseHsts();

            #region Nlog记日志

            loggerFactory.AddNLog();
            //将日志记录到数据库
            env.ConfigureNLog("NLog.config");
            //LogManager.Configuration.FindTargetByName<DatabaseTarget>("database").ConnectionString =
            //    _configuration.GetValue<string>("AppSettings" + ":SQLServerConnectionString");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); //避免日志中的中文输出乱码
           // app.UseLog();

            #endregion

            
            coreConfigurationBuilder.UseSwagger();
            coreConfigurationBuilder.UseAuth();
            coreConfigurationBuilder.UseMiniProfiler();
            coreConfigurationBuilder.UseOther();
            coreConfigurationBuilder.UseCors(CorsPolicyType.AllRequests);
            // coreConfigurationBuilder.UseOPCManager();
            //app.UseHttpsRedirection();
            //app.UseCors("AllRequests");

            app.UseMvc();
           
        }
    }
}