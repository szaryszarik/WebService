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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("CLICK");
            EmployeeRepository eps = new EmployeeRepository();
            List<EmployersDetailsDto> list = new List<EmployersDetailsDto>();
            list = await eps.GetEmployers();
            //foreach(EmployersDetailsDto y in list)
            //{
            //    Console.WriteLine("ID: {2}\tName: {0}\tLastName: {1}", y.Name, y.LastName, y.EmployersDetailsDtoId);
            //}
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                Console.WriteLine("SO, WAR!");
            }
        }
    }
}
