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
    public partial class FrmEditProduct : Form
    {
        public FrmEditProduct(string productId)
        {
            InitializeComponent();

        }
        //提交修改
        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        //关闭窗口
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
