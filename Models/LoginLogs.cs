﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 日志实体类
    /// </summary>
    [Serializable]
    public class LoginLogs
    {
        public int LoginId { get; set; }
        public string SPName { get; set; }
        public string ServerName { get; set; }
        public DateTime  LoginTime { get; set; }
        public DateTime  ExitTime { get; set; }
    }
}
