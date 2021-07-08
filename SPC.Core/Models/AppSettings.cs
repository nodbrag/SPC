namespace SPC.Core.Models
{
    public class AppSettings
    {
        /// <summary>
        /// 默认分页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 默认第几页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// sqlserver 链接字符串
        /// </summary>
        public string SQLServerConnectionString { get; set; }

        /// <summary>
        /// mysql 链接字符串 
        /// </summary>
        public string MySqlConnectionString { get; set; }

        /// <summary>
        /// 数据库类型设置  0-sqlserver,1-mysql 
        /// </summary>
        public int DataBaseType { get; set; }

        /// <summary>
        /// 默认排序
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 安全key
        /// </summary>
        public string SecurityKey { get; set; }

        /// <summary>
        /// 登录过期时间 分钟
        /// </summary>
        public int ExpiresTime { get; set; }

        /// <summary>
        /// token是谁颁发的
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// token可以给哪些客户端使用
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public string ServerUrl { get; set; }
        /// <summary>
        /// 是否测试模式
        /// </summary>
        public int IsTest { get; set; }

        /// <summary>
        /// 角色管理菜单ID 用来区分敏感授权
        /// </summary>
        public int RoleManagerMenuID { get; set; }

        public long MachineId { get; set; }

        public long DataCenterId { get; set; }
        /// <summary>
        /// 注册用户默认密码
        /// </summary>
        public string DefaultPassword { get; set; }
        /// <summary>
        /// 注塑工序id
        /// </summary>
        public int InjectionWPID { get; set; }
        /// <summary>
        /// 摆件工序id
        /// </summary>
        public int SwayWPID { get; set; }
        /// <summary>
        /// 烧结工序id
        /// </summary>
        public int FiringWPID { get; set; }
        /// <summary>
        /// 整形工序id
        /// </summary>
        public int PlasticWPID { get; set; }
        /// <summary>
        /// 尺寸工序id
        /// </summary>
        public int SizeWPID { get; set; }
        /// <summary>
        /// VisionWPID
        /// </summary>
        public int VisionWPID { get; set; }
        /// <summary>
        /// /*筛选良品率>0.5的任务数据*/
        /// </summary>
        public double VKRate { get; set; }
    }
}