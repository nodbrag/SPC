﻿
using System.ComponentModel;

namespace SPC.Api.CoreBuilder
{
    public enum CorsPolicyType
    {
        /// <summary>
        /// 允许所有请求
        /// </summary>
        [Description("允许所有请求")]
        AllRequests = 0,

        /// <summary>
        /// 策略限制。
        /// </summary>
        [Description("域限制请求")]
        LimitRequests = 1,

    }
}
