using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;
using System.Diagnostics;

namespace SMManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //禁止启动多个客户端
            Process[] processArray = Process.GetProcesses();
            int currentCount = 0;//已启动的数量
            foreach (Process item in processArray)
            {
                if (item.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    currentCount++;
                    if (currentCount > 1)
                    {
                        MessageBox.Show("客户端已在运行！", "启动提示");
                        Application.Exit();
                        return;
                    }
                }
            }
            //登录窗体
            FrmLogin frmLogin = new FrmLogin();
            DialogResult result = frmLogin.ShowDialog();
            if (result == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
            else
            {
                Application.Exit();
            }
        }
        public static SysAdmin currentAdmin = null;
    }
}
