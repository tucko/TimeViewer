using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Orders
{
    public partial class frmAddOrderDetail : Form
    {
        IModule _productsModule = null;

        public frmAddOrderDetail(int orderID_)
        {
            InitializeComponent();
            _productsModule = OrdersCommandFacade.ModuleHandler.GetModuleInstance("Products");
            this.txtID.Text = orderID_.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddOrderDetail_Load(object sender, EventArgs e)
        {
            if (_productsModule != null)
            {
                if (_productsModule.Commands.CanExecute("Products.FillProductsList"))
                {
                    DataTable _result = _productsModule.Commands.Execute<DataTable>("Products.FillProductsList");
                    if (_result == null)
                        MessageBox.Show("Command executed with error!");
                    else
                    {
                        this.cboProduct.DataSource = _result;
                        this.cboProduct.ValueMember = "ID";
                        this.cboProduct.DisplayMember = "Name";
                    }
                }
            }
            else
            {
                MessageBox.Show("Products Module not loaded!");
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OrdersService _cs = new OrdersService();
            if (this.txtID.Text != "")
            {
                int newID = _cs.InsertOrderDetail(int.Parse(this.txtID.Text), int.Parse(this.cboProduct.SelectedValue.ToString()), int.Parse(this.txtQuantity.Text));
                this.txtDetailID.Text = newID.ToString();
            }
        }

        private void cboProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboProduct.SelectedText == "")
            {
                return;
            }

            if (_productsModule != null)
            {
                if (_productsModule.Commands.CanExecute("Products.GetProductsPrice"))
                {
                    double _result = _productsModule.Commands.Execute<int, double>("Products.GetProductsPrice", int.Parse(cboProduct.SelectedValue.ToString()));
                    if (_result == -1)
                        MessageBox.Show("Command executed with error!");
                    else
                        txtPrice.Text = _result.ToString();
                }
            }
            else
            {
                MessageBox.Show("Products Module not loaded!");
            }
        }
    }
}
