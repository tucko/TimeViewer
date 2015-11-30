using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//MEF Reference
using System.ComponentModel.Composition;
//Core Reference
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Core
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MenuAttibute : ExportAttribute, IModuleAttribute
    {
        public MenuAttibute(string moduleName_)
            : base(typeof(IMenu))
        {
            ModuleName = moduleName_;
        }

        public string ModuleName { get; private set; }
    }
}
