using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeViewer.Core.Interfaces
{
    public interface IModule
    {
        string Name { get; }

        ICommandDispatcher Commands { get; }

        IModuleHandler ModuleHandler { get; }
    }
}
