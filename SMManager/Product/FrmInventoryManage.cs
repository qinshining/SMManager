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
    public partial class FrmInventoryManage : Form
    {
        public FrmInventoryManage()
        {
            InitializeComponent();
            this.dgvProduct.AutoGenerateColumns = false;

        }

        //显示行号
        private void dgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvProduct, e);
        }
        //刷新库存预警信息
        private void linklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        //查看超出商品库存上限的商品信息
        private void btnShowMax_Click(object sender, EventArgs e)
        {

        }
        //查看低于商品库存下限的商品信息
        private void btnShowMin_Click(object sender, EventArgs e)
        {

        }

        //提交查询
        private void btnQuery_Click(object sender, EventArgs e)
        {

        }
        //同步显示库存数据
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //调整库存预警设置
        private void btnUpdateSet_Click(object sender, EventArgs e)
        {

        }
        //更新当前库存数据
        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {

        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
