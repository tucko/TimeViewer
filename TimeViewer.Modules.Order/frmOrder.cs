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
    public partial class frmOrder : Form
    {
        IModule _clientsModule = null;

        public frmOrder()
        {
            InitializeComponent();
            _clientsModule = OrdersCommandFacade.ModuleHandler.GetModuleInstance("Clients");
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            if (_clientsModule != null)
            {
                if (_clientsModule.Commands.CanExecute("Clients.GetClientList"))
                {
                    DataTable _result = _clientsModule.Commands.Execute<DataTable>("Clients.GetClientList");
                    if (_result == null)
                        MessageBox.Show("Command executed with error!");
                    else
                    {
                        this.cboClient.DataSource = _result;
                        this.cboClient.ValueMember = "ID";
                        this.cboClient.DisplayMember = "Name";
                    }
                }
            }
            else
            {
                MessageBox.Show("Clients Module not loaded!");
            }

            this.dtpOrderDate.Value = DateTime.Now;
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            OrdersService _cs = new OrdersService();
            if (this.txtID.Text == "")
            {
                int newID = _cs.InsertOrder(this.dtpOrderDate.Value, int.Parse(this.cboClient.SelectedValue.ToString()));
                this.txtID.Text = newID.ToString();
                btnAddItem.Enabled = true;
            }

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmAddOrderDetail f = new frmAddOrderDetail(int.Parse(txtID.Text));
            f.ShowDialog();

            OrdersService _cs = new OrdersService();
            this.dataGridView1.DataSource = _cs.GetOrderDetails(int.Parse(txtID.Text));
        }
    }
}
