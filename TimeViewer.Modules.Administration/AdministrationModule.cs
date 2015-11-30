using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.ComponentModel.Composition;

using TimeViewer.Core;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Administration
{
    [ModuleAttibute("Administration")]
    public class AdministrationModule : IModule
    {
        ICommandDispatcher _commands = new ModuleCommandDispatcher();

        public string Name
        {
            get { return "Administration"; }
        }

        public ICommandDispatcher Commands
        {
            get { return _commands; }
        }

        public IModuleHandler ModuleHandler
        {
            get { return AdministrationCommandFacade.ModuleHandler; }
        }

        [ImportingConstructor()]
        public AdministrationModule([Import(typeof(IModuleHandler))] IModuleHandler moduleHandler_)
        {
            AdministrationCommandFacade.ModuleHandler = moduleHandler_;
            RegisterCommands();
        }

        public void RegisterCommands()
        {
            //_commands.Register("Products.GetProductsPrice", new ModuleCommand<int, double>(ProductsCommandFacade.GetProductPrice));
            //_commands.Register("Products.FillProductsList", new ModuleCommand<DataTable>(ProductsCommandFacade.FillProductsList));
            //_commands.Register("Products.SelectProducts", new ModuleCommand<DataSet>(ProductsCommandFacade.SelectProducts));
            //_commands.Register("Pessoas.RecuperarPessoaNome", new ModuleCommand<string, string>(PessoasFacade.RecuperarPessoaNome));
        }

    }
}
