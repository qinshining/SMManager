using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Models;

namespace SMManager
{
    public partial class FrmProductStorage : Form
    {
        private ProductManager objProductManager = new ProductManager();
        public FrmProductStorage()
        {
            InitializeComponent();
        }
        //查询商品信息
        private Product GetProduct()
        {
            try
            {
                Product objProduct = objProductManager.GetProductById(this.txtProductId.Text.Trim());
                if (objProduct != null)
                {
                    this.txtProductName.Text = objProduct.ProductName;
                    this.txtQuantity.Focus();
                }
                else
                {
                    MessageBox.Show("没有此商品编号，请检查是否录入正确或未添加商品信息", "提示信息");
                    this.txtProductName.Clear();
                    this.txtProductId.SelectAll();
                    this.txtProductId.Focus();
                }
                return objProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现异常：" + ex.Message, "提示信息");
                return null;
            }
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && this.txtProductId.Text.Trim().Length != 0)
            {
                GetProduct();
            }
        }
        private void txtProductId_Leave(object sender, EventArgs e)
        {
            GetProduct();
        }
        //执行商品入库（点击“入库确认”按钮）
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtProductId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入商品编号", "提示信息");
                this.txtProductId.Focus();
                return;
            }
            if (!DataValidate.IsInteger(this.txtQuantity.Text.Trim()))
            {
                MessageBox.Show("请输入正确的入库数量", "提示信息");
                this.txtQuantity.SelectAll();
                this.txtQuantity.Focus();
                return;
            }
            Product objProduct = GetProduct();
            if (objProduct != null)
            {
                try
                {
                    string addedResult = objProductManager.AddProductCount(objProduct.ProductId, Convert.ToInt32(this.txtQuantity.Text.Trim()), objProduct.TotalCount);
                    if (addedResult == "success")
                    {
                        MessageBox.Show("入库成功！");
                        this.txtProductId.Clear();
                        this.txtProductName.Clear();
                        this.txtQuantity.Clear();
                        this.txtProductId.Focus();
                    }
                    else
                    {
                        MessageBox.Show(addedResult, "提示信息");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("系统出现异常：" + ex.Message, "提示信息");
                }
            }
        }
        //执行商品入库（在“入库数量”文本框中点击回车键）
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnConfirm_Click(null, null);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmProductStorage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
