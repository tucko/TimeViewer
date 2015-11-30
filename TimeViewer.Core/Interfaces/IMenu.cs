using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeViewer.Core.Interfaces
{
    public interface IMenu
    {
        Janus.Windows.Ribbon.RibbonTab WinFormsMenu
        {
            get;
        }
    }
}
