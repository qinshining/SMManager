using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SMManager
{
    public partial class FrmLogQuery : Form
    {
        public FrmLogQuery()
        {
            InitializeComponent();
        }
        //提交查询
        private void btnQuery_Click(object sender, EventArgs e)
        {

        }
        //显示行号
        private void dgvLogs_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 分页显示

        //跳转到
        private void btnGoTo_Click(object sender, EventArgs e)
        {

        }
        //第一页
        private void btnFirst_Click(object sender, EventArgs e)
        {

        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {

        }
        //上一页
        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }
        //最后页
        private void btnLast_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
