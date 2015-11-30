using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using TimeViewer.Core.Interfaces;
using TimeViewer.Core;
using System.ComponentModel.Composition;

namespace TimeViewer.Modules.Orders
{
    [MenuAttibute("Orders")]
    public class OrdersMenu : IMenu
    {
        private ToolStripMenuItem OrdersMainMenu;
        private ToolStripMenuItem OrdersNovoMenu;

        private ToolStripMenuItem CreateMenu()
        {
            this.OrdersMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersNovoMenu = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // MenuOrdersMain
            // 
            this.OrdersMainMenu.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[] {
                    this.OrdersNovoMenu});
            this.OrdersMainMenu.Name = "MenuOrdersMain";
            this.OrdersMainMenu.Text = "Orders";
            // 
            // MenuOrdersNovo
            // 
            this.OrdersNovoMenu.Name = "MenuOrdersNovo";
            this.OrdersNovoMenu.Text = "Novo";
            this.OrdersNovoMenu.Click += new EventHandler(OrdersCommandFacade.MenuNovo);

            return OrdersMainMenu;
        }

        [ImportingConstructor()]
        public OrdersMenu([Import(typeof(IModuleHandler))] IModuleHandler moduleHandler_)
        {
            CreateMenu();
            OrdersCommandFacade.ModuleHandler = moduleHandler_;
        }

        public ToolStripMenuItem WinFormsMenu
        {
            get { return OrdersMainMenu; }
        }
    }
}
