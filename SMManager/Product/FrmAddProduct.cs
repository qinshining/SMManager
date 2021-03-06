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
    public partial class FrmAddProduct : Form
    {
        private ProductManager objProductManager = new ProductManager();
        public FrmAddProduct()
        {
            InitializeComponent();
            try
            {
                //初始化下拉框
                this.cboCategory.DataSource = objProductManager.GetAllCategory();
                this.cboCategory.DisplayMember = "CategoryName";
                this.cboCategory.ValueMember = "CategoryId";
                this.cboCategory.SelectedIndex = -1;
                this.cboUnit.Items.AddRange(objProductManager.GetAllUnit());
                this.cboUnit.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化出现异常，请重试" + ex.Message, "提示信息");
            }
        }
        //添加锁定分类按钮，避免输入同类商品时频繁选择问题
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (this.btnLock.Text == "锁定")
            {
                this.cboCategory.Enabled = false;
                this.cboUnit.Enabled = false;
                this.btnLock.Text = "解锁";
            }
            else
            {
                this.cboCategory.Enabled = true;
                this.cboUnit.Enabled = true;
                this.btnLock.Text = "锁定";
            }
        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmEditProduct_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        //添加商品
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 数据验证

            if (this.cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("请选择商品分类", "提示信息");
                return;
            }
            if (this.cboUnit.SelectedIndex == -1)
            {
                MessageBox.Show("请选择商品单位", "提示信息");
                return;
            }
            if (this.txtProductId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请录入商品编号", "提示信息");
                this.txtProductId.Focus();
                return;
            }
            if (this.txtProductName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请录入商品名称", "提示信息");
                this.txtProductName.Focus();
                return;
            }
            if (this.txtUnitPrice.Text.Trim().Length == 0 || !DataValidate.IsPositiveDecimal(this.txtUnitPrice.Text.Trim()))
            {
                MessageBox.Show("请录入正确的单价", "提示信息");
                this.txtUnitPrice.SelectAll();
                this.txtUnitPrice.Focus();
                return;
            }
            if (!DataValidate.IsPositiveInteger(this.txtMaxCount.Text.Trim()))
            {
                MessageBox.Show("请录入正确的最大库存", "提示信息");
                this.txtMaxCount.SelectAll();
                this.txtMaxCount.Focus();
                return;
            }
            if (!DataValidate.IsPositiveInteger(this.txtMinCount.Text.Trim()))
            {
                MessageBox.Show("请录入正确的最小库存", "提示信息");
                this.txtMinCount.SelectAll();
                this.txtMinCount.Focus();
                return;
            }
            if (Convert.ToInt32(this.txtMaxCount.Text.Trim()) < Convert.ToInt32(this.txtMinCount.Text.Trim()))
            {
                MessageBox.Show("最大库存不能比最小库存小，请修改", "提示信息");
                this.txtMaxCount.SelectAll();
                this.txtMaxCount.Focus();
                return;
            }

            #endregion

            #region 封装数据

            Product objProduct = new Product()
            {
                ProductId = this.txtProductId.Text.Trim(),
                ProductName = this.txtProductName.Text.Trim(),
                UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text.Trim()),
                Unit = this.cboUnit.Text,
                CategoryId = Convert.ToInt32(this.cboCategory.SelectedValue),
                MinCount = Convert.ToInt32(this.txtMinCount.Text.Trim()),
                MaxCount = Convert.ToInt32(this.txtMaxCount.Text.Trim())
            };

            #endregion

            #region 调用后台数据执行添加

            try
            {
                objProductManager.AddProduct(objProduct);
                DialogResult result = MessageBox.Show("保存成功，是否继续添加？", "询问信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.txtMaxCount.Text = "";
                    this.txtMinCount.Clear();
                    foreach (Control item in this.gbInfo.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = "";
                        }
                        else if (item is ComboBox)
                        {
                            if (this.btnLock.Text == "锁定")
                            {
                                ((ComboBox)item).SelectedIndex = -1;
                            }
                        }
                    }
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存出现异常，具体信息：" + ex.Message);
            }

            #endregion
        }
    }
}
