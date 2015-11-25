﻿using System;
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
        private BindingList<EmployersDetailsDto> list = new BindingList<EmployersDetailsDto>();
        private BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
        }

        // DataBase Binding
        private async void button1_Click(object sender, EventArgs e)
        {
            EmployeeRepository eps = new EmployeeRepository();
            list = await eps.GetEmployers();
            bs.DataSource = list;
            dataGridView1.DataSource = list;
        }

        //  WorkNotes Binding
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
                if(rowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    List<WorkNote> temp = new List<WorkNote>();
                    var result = list.Where<WorkNote>(item => item.EmployeeId == ((int)row.Cells[0].Value));
                    foreach (WorkNote w in result)
                    {
                        temp.Add(w);
                    }

                    dataGridView2.DataSource = temp;
                }
            }
        }

        //Delete Row
        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("This row is going to be deleted, are you sure?", "WARNING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    EmployeeRepository eps = new EmployeeRepository();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];
                    await eps.DeleteEmployee((int)row.Cells[0].Value);
                    bs.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }

        //Create new Employee
        private void button2_Click(object sender, EventArgs e)
        {
            AddDIalog add = new AddDIalog();
            add.Show();
        }
    }
}
