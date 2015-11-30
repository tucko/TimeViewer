using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//MEF Reference
using System.ComponentModel.Composition;

using TimeViewer.Core.Interfaces;

namespace TimeViewer.Core
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleAttibute : ExportAttribute, IModuleAttribute
    {
        public ModuleAttibute(string moduleName_)
            : base(typeof(IModule))
        {
            ModuleName = moduleName_;
        }

        public string ModuleName { get; private set; }
    }

}
