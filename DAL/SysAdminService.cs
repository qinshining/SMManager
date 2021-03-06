using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SysAdminService
    {
        /// <summary>
        /// 用户登录，返回登录实体
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public SysAdmin AdminLogin(SysAdmin objAdmin)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LoginId", objAdmin.LoginId),
                new SqlParameter("@LoginPwd", objAdmin.LoginPwd)
            };
            SqlDataReader reader = SqlHelper.GetReaderByProc("usp_SysAdminLogin", param);
            if (reader.Read())
            {
                objAdmin.AdminName = reader["AdminName"].ToString();
                objAdmin.AdminStatus = Convert.ToInt32(reader["AdminStatus"]);
                objAdmin.RoleId = Convert.ToInt32(reader["RoleId"]);
            }
            else
            {
                objAdmin = null;
            }
            reader.Close();
            return objAdmin;
        }
        /// <summary>
        /// 写入登录日志，返回日志ID
        /// </summary>
        /// <param name="loginLog"></param>
        /// <returns></returns>
        public int WriteLoginLog(LoginLogs loginLog)
        {
            string sql = "INSERT INTO LoginLogs (LoginId,SPName,ServerName) VALUES (@LoginId,@SPName,@ServerName);SELECT @@IDENTITY";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LoginId", loginLog.LoginId),
                new SqlParameter("@SPName", loginLog.SPName),
                new SqlParameter("@ServerName", loginLog.ServerName)
            };
            return Convert.ToInt32(SqlHelper.GetSingleResult(sql, param));
        }
        /// <summary>
        /// 更新日志退出时间
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        public int WriteExitTime(int logId)
        {
            string sql = "UPDATE LoginLogs SET ExitTime = GETDATE() WHERE LogId = " + logId;
            return SqlHelper.Update(sql);
        }
    }
}
