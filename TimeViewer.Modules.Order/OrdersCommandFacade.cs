using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Windows.Forms;

using TimeViewer.Core;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Orders
{
    public static class OrdersCommandFacade
    {
        public static IModuleHandler ModuleHandler { get; set; }

        public static void MenuNovo(object sender, EventArgs e)
        {
            NewOrder();
        }

        public static bool NewOrder()
        {
            frmOrder f = new frmOrder();
            f.MdiParent = (Form)ModuleHandler.Host;
            f.Show();
            return true;
        }

        public static DataSet SelectOrders()
        {
            //frmOrders f = new frmOrders();
            //f.ShowDialog();
            //DataSet l = f.SelectedOrders;
            return null;// l;
        }
    }
}
