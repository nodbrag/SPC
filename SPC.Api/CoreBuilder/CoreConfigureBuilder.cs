using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPC.IService;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Reflection;

namespace SPC.Api.CoreBuilder
{
    public class CoreConfigureBuilder : ICoreConfigurationBuilder
    {
        private readonly IApplicationBuilder _app;
        private readonly IHostingEnvironment _env;
        private readonly IServiceProvider _svp;
        private readonly IConfiguration _configuration;

        public CoreConfigureBuilder(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp, IConfiguration configuration)
        {
            _app = app;
            _env = env;
            _svp = svp;
            _configuration = configuration;
        }

        public void UseAuth()
        {
            _app.UseAuthentication();//启用验证
        }

        public void UseCors(CorsPolicyType corsPolicyType)
        {
            if (corsPolicyType == CorsPolicyType.AllRequests)
            {
                _app.UseCors("AllRequests");
            }
            else
            {
                _app.UseCors("LimitRequests");
            }
        }

        public void UseErrorHanle()
        {
            throw new NotImplementedException();
        }

        public void UseOther()
        {
            //获取客户端ip地址
            _app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });
        }

        public void UseRazorEngine()
        {
            throw new NotImplementedException();
        }
      

        public void UseSwagger()
        {
            //启用中间件服务生成Swagger作为JSON终结点
            _app.UseSwagger();

            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            _app.UseSwaggerUI(c =>
            {
                #region
                c.SwaggerEndpoint("/swagger/SystemSetting/swagger.json", "系统设置");
                c.SwaggerEndpoint("/swagger/BasicInformation/swagger.json", "基础档案");
                c.SwaggerEndpoint("/swagger/DataClass/swagger.json", "数据分类");
                c.SwaggerEndpoint("/swagger/SPCAnalysis/swagger.json", "SPC分析");

                #endregion
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("SPC.Api.index.html");
                c.DefaultModelExpandDepth(2);//接口列表折叠配置
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);//不显示model
               // c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
                //c.EnableDeepLinking();
                //c.EnableFilter();
                c.ShowExtensions();
            });
        }

        public void UseMiniProfiler()
        {
            // 启用MiniProfiler 性能监测
            _app.UseMiniProfiler();
        }

        public void UseOPCManager()
        {

        }
    }
}