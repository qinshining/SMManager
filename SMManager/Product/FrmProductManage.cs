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
    public partial class FrmProductManage : Form
    {
        private ProductManager objProductManager = new ProductManager();
        public FrmProductManage()
        {
            InitializeComponent();
            this.dgvProduct.AutoGenerateColumns = false;
            try
            {
                List<ProductCategory> list = objProductManager.GetAllCategory();
                list.Insert(0, new ProductCategory() { CategoryId = -1, CategoryName = "" });
                this.cboCategory.DataSource = list;
                this.cboCategory.DisplayMember = "CategoryName";
                this.cboCategory.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化出现异常：" + ex.Message, "异常提示");
            }
        }
        //提交查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvProduct.DataSource = null;
                this.dgvProduct.DataSource = objProductManager.QueryProducts(this.txtProductId.Text.Trim(), this.txtProductName.Text.Trim(), this.cboCategory.SelectedValue.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询出现异常：" + ex.Message, "异常提示");
            }
        }
        //显示行号
        private void dgvProduct_RowPostPaint(object sender,
            DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvProduct, e);
        }
        private void DgvProduct_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            // e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        //显示商品折扣
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //更新折扣
        private void btnUpdateDiscount_Click(object sender, EventArgs e)
        {

        }
        //显示修改窗体，并将当前的商品编号传递给修改窗体
        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        //删除商品
        private void btnDel_Click(object sender, EventArgs e)
        {

        }
        //显示添加商品窗口
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        //显示商品入库窗口
        private void btnStorage_Click(object sender, EventArgs e)
        {

        }
        //关闭窗体
        private void FrmProductManage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
