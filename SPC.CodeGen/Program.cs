using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPC.CodeGen.Options;

namespace SPC.CodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("代码生成中....");
            var serviceProvider = BuildServiceForSqlServer();
            var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            codeGenerator.GenerateTemplateCodesFromDatabase(true);
            Console.WriteLine("代码生成成功。");
            Console.ReadKey();
        }

        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();
            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "Data Source=114.80.118.175,15433;Initial Catalog=SPC;Persist Security Info=True;User ID=sa;Password=Password01!;MultipleActiveResultSets=true";
                options.DbType = Core.DbHelper.DatabaseType.SqlServer.ToString();//数据库类型是SqlServer,其他数据类型参照枚举DatabaseType
                options.Author = "SPC";//作者名称
                options.OutputPath = "D:\\CodeGenerator";//模板代码生成的路径
                options.UseGenerateModels("SPC.Models.DataModel");//实体命名空间
                options.UseGenerateIRepository("SPC.IRepository", false);//仓储接口命名空间
                options.UseGenerateRepository("SPC.Repository", false);//仓储命名空间
                options.UseGenerateIServices("SPC.IService", false);//服务接口命名空间
                options.UseGenerateServices("SPC.Service", false);//服务命名空间
                options.UseGenerateController("SPC.Api.Controllers", false);
                options.UseGenerateDtos("SPC.Models.DtoModel");
            });
            services.Configure<DbOption>("db", GetConfiguration().GetSection("DbOpion"));
            services.AddScoped<CodeGenerator>();
            return services.BuildServiceProvider(); //构建服务提供程序
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}