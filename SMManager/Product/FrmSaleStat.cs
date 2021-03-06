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
    public partial class FrmSaleStat : Form
    {
        public FrmSaleStat()
        {
            InitializeComponent();
        }
        //开始统计
        private void btnStat_Click(object sender, EventArgs e)
        {
        }
        //显示行号
        private void dgvProductStat_RowPostPaint(object sender,
            DataGridViewRowPostPaintEventArgs e)
        {

        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmSaleStat_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
