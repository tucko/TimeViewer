using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.ComponentModel.Composition;

using TimeViewer.Core.Interfaces;
using TimeViewer.Data;
using TimeViever.Data.Entity;
using TeamViewer.Win.Core;

namespace TimeViewer
{
    [Export(typeof(IHost))]
    public partial class frmMain : TeamViewerForm, IHost
    {
        public frmMain()
        {
            InitializeComponent();
            //Here, the exported menus will be attached to the main menu.
          
        }


        private void frmHost_Load(object sender, EventArgs e)
        {
            foreach (var menu in Program._modHandler.MenuList)
            {
                this.ribbon1.Tabs.Add(menu.Value.WinFormsMenu);
         
            }
        
            //this.ribbon1.Tabs.Add(new Janus.Windows.Ribbon.RibbonTab("test"));
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit();
        }

        private static void Exit()
        {
            if (Program._modHandler != null)
            {
                //call the ModuleHandler Dispose method
                Program._modHandler.Dispose();
                Program._modHandler = null;
            }
            Application.Exit();
        }

        private void buttonCommand1_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {

        }

    }
}
