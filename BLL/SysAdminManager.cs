using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using System.Net;

namespace BLL
{
    public class SysAdminManager
    {
        private SysAdminService objAdminService = new SysAdminService();
        /// <summary>
        /// 用户登录，返回登录实体
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public SysAdmin AdminLogin(SysAdmin objAdmin)
        {
            objAdmin = objAdminService.AdminLogin(objAdmin);
            if (objAdmin != null && objAdmin.AdminStatus == 1)
            {
                LoginLogs loginLog = new LoginLogs()
                {
                    LoginId = objAdmin.LoginId,
                    SPName = objAdmin.AdminName,
                    ServerName = Dns.GetHostName()
                };
                objAdmin.LoginLogId = objAdminService.WriteLoginLog(loginLog);
            }
            return objAdmin;
        }
        /// <summary>
        /// 退出时更新退出时间
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns>true为成功</returns>
        public bool AdminLogOff(SysAdmin objAdmin)
        {
            return objAdminService.WriteExitTime(objAdmin.LoginLogId) == 1;
        }
    }
}
