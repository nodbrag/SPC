using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SPC.Core.Log
{
    public abstract class BaseHandler<TLog>
    {
        #region 构造函数

     //   private readonly ILogService _iLogService;

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="loggerConfig"></param>
        protected BaseHandler(string loggerConfig)
        {
            LoggerConfig = loggerConfig;
            //_iLogService = iLogService;

        }

        #endregion

    #region 方法

    /// <summary>
    /// 写入日志,虚函数.可进行重写
    /// </summary>
    public virtual void WriteLog()
        {
            if (string.IsNullOrEmpty(LoggerConfig))
                return;

            Task.Factory.StartNew(() => InsertDb());
        }

        /// <summary>
        /// 插入数据库
        /// </summary>
        private void InsertDb()
        {
            //var client = new MongoClient(ConfigurationUtil.GetSection("MongoDb:ConnectionString"));
            //var dataBase = client.GetDatabase("TPX_Log");
            //var table = dataBase.GetCollection<TLog>(LoggerConfig);
            //table.InsertOneAsync(Log);
        }

        /// <summary>
        /// 获取请求数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected string RequestData(HttpRequest request)
        {
            if (request.ContentLength == 0) return string.Empty;
            if (request.Method == HttpMethods.Post && request.HasFormContentType)
                return JsonConvert.SerializeObject(request.Form);
            else
                return request.QueryString.Value;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 需要启动的日志模式名称
        /// </summary>
        private string LoggerConfig { get; set; }

        public TLog Log { get; set; }

        #endregion
    }
}