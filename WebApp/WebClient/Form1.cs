using AutoMapper;
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
        private BindingList<EmployersDetailsDto> list = new BindingList<EmployersDetailsDto>();
        public BindingSource bs = new BindingSource();

        public DataGridView dgv = new DataGridView();

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
        }

        public Form1 getForm1()
        {
            return this;
        }

        // DataBase Binding
        public async void button1_Click(object sender, EventArgs e)
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
                if (rowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    List<WorkNote> temp = new List<WorkNote>();
                    var result = list.Where<WorkNote>(item => item.EmployeeId == ((int)row.Cells[0].Value));
                    foreach (WorkNote w in result)
                    {
                        temp.Add(w);
                    }
                    dataGridView2.DataSource = temp;
                    this.dataGridView2.Columns["Employee"].Visible = false;
                    this.dataGridView2.Columns["WorkNoteId"].Visible = false;
                    this.dataGridView2.Columns["EmployeeId"].Visible = false;
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
        private async void button2_Click(object sender, EventArgs e)
        {
            EmployeeRepository eps = new EmployeeRepository();
            dgv = dataGridView1;
            AddDIalog add = new AddDIalog(this);
            add.Show();
        }

        //New note
        private async void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                int empId = (int)row.Cells[0].Value;
                dgv = dataGridView2;
                AddNote add = new AddNote(this, empId);
                add.Show();
            }
            else
            {
                MessageBox.Show("None row selected.");
            }
        }

        //Edit Employee
        private async void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            int id = (int)row.Cells[0].Value;

            //Cheking if there are notes binded to this employee

            WorkNoteRepository wRep = new WorkNoteRepository();
            List<WorkNote> list = new List<WorkNote>();
            list = await wRep.GetWorkNotes();
            List<WorkNote> temp = new List<WorkNote>();
            var result = list.Where<WorkNote>(item => item.EmployeeId == id);
            foreach (WorkNote w in result)
            {
                temp.Add(w);
            }
            if (temp.Count<WorkNote>() == 0)
            {
                string name = (string)row.Cells[1].Value;
                string lastName = (string)row.Cells[2].Value;

                EmployeeRepository eRep = new EmployeeRepository();
                await eRep.PutEmployee(id, name, lastName);
            }
            else
            {
                foreach (WorkNote w in temp)
                {
                    await wRep.DeleteWorkNote(w.WorkNoteId);
                }
                string name = (string)row.Cells[1].Value;
                string lastName = (string)row.Cells[2].Value;

                EmployeeRepository eRep = new EmployeeRepository();
                await eRep.PutEmployee(id, name, lastName);
                foreach (WorkNote w in temp)
                {
                    await wRep.PostWorkNote(w);
                }
                result = list.Where<WorkNote>(item => item.EmployeeId == id);
                foreach (WorkNote w in result)
                {
                    temp.Add(w);
                }
                dgv.DataSource = temp;
            }
        }

        //Delete Note
        private async void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This Note is going to be deleted, are you sure?", "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow rowEmp = dataGridView1.Rows[rowIndex];
                int empID = (int)rowEmp.Cells[0].Value;

                if (dataGridView2.SelectedRows.Count > 0)
                {
                    WorkNoteRepository wRep = new WorkNoteRepository();
                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                    int id = (int)row.Cells[0].Value;
                    await wRep.DeleteWorkNote(id);
                    dgv = dataGridView2;
                    dgv.DataSource = null;
                    List<WorkNote> list = new List<WorkNote>();
                    list = await wRep.GetWorkNotes();
                    List<WorkNote> temp = new List<WorkNote>();
                    var result = list.Where<WorkNote>(item => item.EmployeeId == empID);
                    foreach (WorkNote w in result)
                    {
                        temp.Add(w);
                    }
                    dgv.DataSource = temp;
                    dgv.Columns["Employee"].Visible = false;
                    dgv.Columns["WorkNoteId"].Visible = false;
                    dgv.Columns["EmployeeId"].Visible = false;
                }
            }
        }

        //Edit Worknote
        private async void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            int id = (int)row.Cells[0].Value;

            WorkNote temp = new WorkNote();
            temp.StartTime = (int)row.Cells[2].Value;
            temp.EndTime = (int)row.Cells[3].Value;
            temp.Date = (string)row.Cells[4].Value;
            temp.Note = (string)row.Cells[5].Value;
            temp.EmployeeId = (int)row.Cells[1].Value;
            temp.WorkNoteId = id;
            //Mapper.CreateMap<DataGridView, WorkNote>();
            //WorkNote temp = Mapper.Map<WorkNote>(sender);
            WorkNoteRepository wRep = new WorkNoteRepository();
            await wRep.PutWorkNote(id, temp);
        }
    }
}
