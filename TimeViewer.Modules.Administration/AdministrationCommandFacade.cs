using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Windows.Forms;

using TimeViewer.Core;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Administration
{
    public static class AdministrationCommandFacade
    {
        public static IModuleHandler ModuleHandler { get; set; }

    
        public static void PersonList(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            ViewPersons();
        }

        public static void AddPerson(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            AddPersonForm();
        }

        private static void AddPersonForm()
        {
            frmEmployeesAdd f = new frmEmployeesAdd();
            f.ShowDialog();
        }

        public static bool ViewPersons()
        {
            frmEmployees f = new frmEmployees();
            f.MdiParent = (Form)ModuleHandler.Host;
            f.Show();
            return true;
        }

    }
}
