using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

// MEF References
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.ComponentModel.Composition.AttributedModel;
//Core Reference
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Core
{
    [Export(typeof(IModuleHandler))]
    public class ModuleHandler : IDisposable, IModuleHandler
    {
        private static IDataModule _dataModule;

        // The importMany attribute allow us to import the classes that implement the same interface
        [ImportMany(typeof(IModule), AllowRecomposition = true)]
        // The ModuleList will be filled with the imported modules
        public List<Lazy<IModule, IModuleAttribute>> ModuleList
        { get; set; }

        [ImportMany(typeof(IMenu), AllowRecomposition = true)]
        // The MenuList will be filled with the imported Menus
        public List<Lazy<IMenu, IModuleAttribute>> MenuList
        { get; set; }

        [Import(typeof(IHost))]
        // The imported host form
        public IHost Host
        { get; set; }

        //The DataModule exposes the database module.
        public IDataModule DataModule
        { 
            get 
            {
                if (_dataModule == null)
                    _dataModule = new SqlDataModule();
                return _dataModule; 
            } 
        }

        // AggregateCatalog stores the MEF Catalogs
        AggregateCatalog catalog = new AggregateCatalog();

        public void InitializeModules()
        {
            // Create a new instance of ModuleList
            ModuleList = new List<Lazy<IModule, IModuleAttribute>>();
            // Create a new instance of MenuList
            MenuList = new List<Lazy<IMenu, IModuleAttribute>>();

            // Foreach path in the main app App.Config
            foreach (var s in ConfigurationManager.AppSettings.AllKeys)
            {
                if (s.StartsWith("Path"))
                {
                    // Create a new DirectoryCatalog with the path loaded from the App.Config
                    catalog.Catalogs.Add(new DirectoryCatalog(ConfigurationManager.AppSettings[s], "*.dll"));
                }
            }
            // Create a new catalog from the main app, to get the Host
            catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetCallingAssembly()));
            // Create a new catalog from the TimeViewer.Core
            catalog.Catalogs.Add(new DirectoryCatalog(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "*.dll"));

            // Create the CompositionContainer
            CompositionContainer cc = new CompositionContainer(catalog);
            // Do the MEF Magic
            cc.ComposeParts(this);
        }

        //Verify if some module is imported
        public bool ContainsModule(string moduleName_)
        {
            bool ret = false;
            foreach (var l in ModuleList)
            {
                if (l.Metadata.ModuleName == moduleName_)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        //return a module instance based on it's name
        public IModule GetModuleInstance(string moduleName_)
        {
            IModule instance = null;
            foreach (var l in ModuleList)
            {
                if (l.Metadata.ModuleName == moduleName_)
                {
                    instance = l.Value;
                    break;
                }
            }
            return instance;
        }

        public void Dispose()
        {
            _dataModule = null;
            catalog.Dispose();
            catalog = null;
            ModuleList.Clear();
            ModuleList = null;
        }
    }
}
