using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using TimeViewer.Core.Interfaces;
using TimeViewer.Core;
using System.ComponentModel.Composition;
using Janus.Windows.Ribbon;

namespace TimeViewer.Modules.Administration
{
    [MenuAttibute("Administration")]
    public class AdministrationMenu : IMenu
    {
        private ButtonCommand PersonMainMenu;
        private ButtonCommand AddPersonMenu;
        private RibbonTab PersonMainTab;
        private RibbonGroup PersonMainGroup;
         
        private RibbonTab CreateMenu()
        {
            this.PersonMainMenu = new ButtonCommand();
            this.PersonMainGroup = new RibbonGroup();
            this.PersonMainTab = new RibbonTab();
            this.AddPersonMenu = new ButtonCommand();

            PersonMainTab.Text = "Администрација";
            PersonMainTab.Name = "rtabAdministration";
            PersonMainTab.Key = "rtabAdministration";

            PersonMainGroup.Text = "Вработени";
            PersonMainGroup.Name = "rgEmployee";
            PersonMainGroup.Key = "rgEmployee";

            PersonMainMenu.Text = "Вработени";
            PersonMainMenu.Name = "pcbPersonMainMenu";
            PersonMainMenu.Click += AdministrationCommandFacade.PersonList;
            PersonMainMenu.SizeStyle = CommandSizeStyle.Large;

            AddPersonMenu.Text = "Додади Вработен";
            AddPersonMenu.Name = "pcbAddPersonMenu";
            AddPersonMenu.Click += AdministrationCommandFacade.AddPerson;
            AddPersonMenu.SizeStyle = CommandSizeStyle.Small;

            PersonMainGroup.Commands.Add(PersonMainMenu);
            PersonMainGroup.Commands.Add(AddPersonMenu);
            PersonMainTab.Groups.Add(PersonMainGroup);

            
            return PersonMainTab;
        }


        [ImportingConstructor()]
        public AdministrationMenu([Import(typeof(IModuleHandler))] IModuleHandler moduleHandler_)
        {
            CreateMenu();
            AdministrationCommandFacade.ModuleHandler = moduleHandler_;
        }

        public RibbonTab WinFormsMenu
        {
            get { return PersonMainTab; }
        }
    }
}
