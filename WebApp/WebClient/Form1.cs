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
            this.MaximumSize = this.MinimumSize = this.Size;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            EmployeeRepository eps = new EmployeeRepository();
            List<EmployersDetailsDto> list = new List<EmployersDetailsDto>();
            list = await eps.GetEmployers();
            dataGridView1.DataSource = list;
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                WorkNoteRepository wps = new WorkNoteRepository();
                List<WorkNote> list = new List<WorkNote>();
                list = await wps.GetWorkNotes();

                int rowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                List<WorkNote> temp = new List<WorkNote>();
                var result = list.Where<WorkNote>(item => item.EmployeeId == ((int)row.Cells[0].Value));
                foreach(WorkNote w in result)
                {
                    temp.Add(w);
                }

                dataGridView2.DataSource = temp;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            EmployeeRepository eps = new EmployeeRepository();
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            await eps.DeleteEmployee((int)row.Cells[0].Value);
        }
    }
}
