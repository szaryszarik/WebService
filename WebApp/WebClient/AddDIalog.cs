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
        static EmployeeRepository eRep = new EmployeeRepository();

        public AddDIalog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text;
            string lastName = LNameBox.Text;
            eRep.PostEmployee(name, lastName);
            MessageBox.Show("New Employee successfully added to DataBase.");
            this.Close();
        }
    }
}
