using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface ICommonDictionryService
    {
        /// <summary>
        /// 获取公共初始化字典信息
        /// </summary>
        /// <returns></returns>
         IExecResult GetCommonDictionry();
    }
}
