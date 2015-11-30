using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using TimeViewer.Core.Interfaces;
using TimeViewer.Core;
using System.ComponentModel.Composition;
using Janus.Windows.Ribbon;

namespace TimeViewer.Modules.Planning
{
    [MenuAttibute("Planning")]
    public class PlanningMenu : IMenu
    {
        private ButtonCommand PlanningMainMenu;
        private RibbonTab PlanningMainTab;
        private RibbonGroup PlanningMainGroup;

        private RibbonTab CreateMenu()
        {
            this.PlanningMainMenu = new ButtonCommand();
            this.PlanningMainGroup = new RibbonGroup();
            this.PlanningMainTab = new RibbonTab();

            PlanningMainTab.Text = "Планирање";
            PlanningMainTab.Name = "rtabPlanning";
            PlanningMainTab.Key = "rtabPlanning";

            PlanningMainGroup.Text = "Планирање";
            PlanningMainGroup.Name = "rgPlanning";
            PlanningMainGroup.Key = "rgPlanning";

            PlanningMainMenu.Text = "Форма";
            PlanningMainMenu.Name = "pcbPlanning";
            PlanningMainMenu.Click += PlanningCommandFacade.ViewPlanning;
            PlanningMainMenu.SizeStyle = CommandSizeStyle.Large;

            PlanningMainGroup.Commands.Add(PlanningMainMenu);
            PlanningMainTab.Groups.Add(PlanningMainGroup);

            return PlanningMainTab;
        }

        [ImportingConstructor()]
        public PlanningMenu([Import(typeof(IModuleHandler))] IModuleHandler moduleHandler_)
        {
            CreateMenu();
            PlanningCommandFacade.ModuleHandler = moduleHandler_;
        }

        public RibbonTab WinFormsMenu
        {
            get { return PlanningMainTab; }
        }
    }
}
