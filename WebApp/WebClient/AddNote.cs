using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WebClient.Models;

namespace WebClient
{
    public partial class AddNote : Form
    {
        private int employeeId;
        Form1 F;
        static WorkNoteRepository wRep = new WorkNoteRepository();
        private List<WorkNote> list = new List<WorkNote>();

        public AddNote(Form1 parent, int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            F = parent;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if((sTimeBox.Text.Length > 0) && (eTimeBox.Text.Length > 0) && (dateBox.Text.Length > 0))
            {
                int sTime = int.Parse(sTimeBox.Text);
                int eTime = int.Parse(eTimeBox.Text);
                string date = dateBox.Text;
                string note = noteRichBox.Text;

                WorkNote wNote = new WorkNote() { EmployeeId = employeeId, StartTime = sTime, EndTime = eTime, Date = date, Note = note };
                await wRep.add(wNote);

                F.dgv.DataSource = null;
                list = await wRep.get();

                List<WorkNote> temp = new List<WorkNote>();

                var result = list.Where<WorkNote>(item => item.EmployeeId == employeeId);
                foreach (WorkNote w in result)
                {
                    temp.Add(w);
                }
                F.dgv.DataSource = temp;
                F.dgv.Columns["Employee"].Visible = false;
                F.dgv.Columns["WorkNoteId"].Visible = false;
                F.dgv.Columns["EmployeeId"].Visible = false;
                this.Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Fill empty textBox", "WARNING", MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    AddNote add = this;
                    this.Show();
                }
            }
        }
    }
}
