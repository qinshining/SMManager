using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using BLL;


namespace SMManager
{
    public partial class FrmLogin : Form
    {
        private SysAdminManager objAdminManager = new SysAdminManager();
        public FrmLogin()
        {
            InitializeComponent();
        }

        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入账号", "登录提示");
                this.txtLoginId.Focus();
                return;
            }
            if (!DataValidate.IsPositiveInteger(this.txtLoginId.Text.Trim()))
            {
                MessageBox.Show("请输入正确的账号", "登录提示");
                this.txtLoginId.SelectAll();
                this.txtLoginId.Focus();
                return;
            }
            if (this.txtLoginPwd.Text.Length == 0)
            {
                MessageBox.Show("请输入密码", "登录提示");
                this.txtLoginPwd.Focus();
                return;
            }
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text
            };
            try
            {
                objAdmin = objAdminManager.AdminLogin(objAdmin);
                if (objAdmin != null)
                {
                    if (objAdmin.AdminStatus == 0)
                    {
                        MessageBox.Show("该账号已被禁用", "登录提示");
                    }
                    else
                    {
                        Program.currentAdmin = objAdmin;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("账号或密码错误", "登录提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现异常，具体信息：" + ex.Message);
            }
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
