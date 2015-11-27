using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebClient.Models;

namespace WebClient
{
    public partial class AddDIalog : Form
    {
        public string name;
        public string lastName;
        Form1 F;
        private BindingList<EmployersDetailsDto> list = new BindingList<EmployersDetailsDto>();
        static EmployeeRepository eRep = new EmployeeRepository();

        public AddDIalog(Form1 parent)
        {
            InitializeComponent();
            F = parent;
        }
        
        public async void AddButton_Click(object sender, EventArgs e)
        {
            name = NameBox.Text;
            lastName = LNameBox.Text;
            await eRep.PostEmployee(name, lastName);

            F.dgv.DataSource = null;
            list = await eRep.GetEmployers();
            F.bs.DataSource = list;
            F.dgv.DataSource = list;

            MessageBox.Show("New Employee successfully added to DataBase.");
            this.Close();
        }
    }
}
