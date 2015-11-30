using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Windows.Forms;

using TimeViewer.Core;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Planning
{
    public static class PlanningCommandFacade
    {
        public static IModuleHandler ModuleHandler { get; set; }

        public static void ViewPlanning(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            viewPlanning();
        }
        public static void viewPlanning()
        {
            frmPlanning f = new frmPlanning();
            f.MdiParent = (Form)ModuleHandler.Host;
            f.Show();
        }

    }
}
