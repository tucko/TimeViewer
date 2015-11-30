using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using TimeViewer.Core;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Administration
{
    public class AdministrationService
    {
        IDataModule _dataModule;

        public AdministrationService()
        {
            _dataModule = AdministrationCommandFacade.ModuleHandler.DataModule;
        }

    }
}
