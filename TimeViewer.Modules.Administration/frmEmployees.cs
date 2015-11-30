using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamViewer.Win.Core;
using TimeViever.Data.Entity;
using TimeViewer.Data;

namespace TimeViewer.Modules.Administration
{
    public partial class frmEmployees : TeamViewerForm
    {
        public frmEmployees()
        {
            InitializeComponent();
            personRepository = unitOfWork.Repository<Person>();
        }

        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Person> personRepository;

        private void frmProducts_Load(object sender, EventArgs e)
        {
            IEnumerable<Person> persons = personRepository.Table.ToList();
            gridEX1.DataSource = persons;
            gridEX1.RetrieveStructure();
        }



        
    }
}
