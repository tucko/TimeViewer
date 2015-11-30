using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.ComponentModel.Composition;

using TimeViewer.Core;
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Modules.Planning
{
    [ModuleAttibute("Planning")]
    public class PlanningModule : IModule
    {
        ICommandDispatcher _commands = new ModuleCommandDispatcher();

        public string Name
        {
            get { return "Planning"; }
        }

        public ICommandDispatcher Commands
        {
            get { return _commands; }
        }

        public IModuleHandler ModuleHandler
        {
            get { return PlanningCommandFacade.ModuleHandler; }
        }

        [ImportingConstructor()]
        public PlanningModule([Import(typeof(IModuleHandler))] IModuleHandler moduleHandler_)
        {
            PlanningCommandFacade.ModuleHandler = moduleHandler_;
            RegisterCommands();
        }

        public void RegisterCommands()
        {
        }

    }
}
