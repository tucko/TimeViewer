using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.ComponentModel.Composition;

using TimeViewer.Core;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Orders
{
    [ModuleAttibute("Orders")]
    public class OrdersModule : IModule
    {
        ICommandDispatcher _commands = new ModuleCommandDispatcher();

        public string Name
        {
            get { return "Orders"; }
        }

        public ICommandDispatcher Commands
        {
            get { return _commands; }
        }

        public IModuleHandler ModuleHandler
        {
            get { return OrdersCommandFacade.ModuleHandler; }
        }

        [ImportingConstructor()]
        public OrdersModule([Import(typeof(IModuleHandler))] IModuleHandler moduleHandler_)
        {
            OrdersCommandFacade.ModuleHandler = moduleHandler_;
            RegisterCommands();
        }

        public void RegisterCommands()
        {
            //_commands.Register("Pessoas.Novo", new ModuleCommand<bool>(PessoasFacade.Novo));
            //_commands.Register("Pessoas.Consultar", new ModuleCommand<bool>(PessoasFacade.Consultar));
            _commands.Register("Orders.SelectOrders", new ModuleCommand<DataSet>(OrdersCommandFacade.SelectOrders));
            //_commands.Register("Pessoas.RecuperarPessoaNome", new ModuleCommand<string, string>(PessoasFacade.RecuperarPessoaNome));
        }

    }
}
