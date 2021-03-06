﻿using System;
using System.ComponentModel;
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
            if((NameBox.Text.Length > 0) && (LNameBox.Text.Length > 0))
            {
                name = NameBox.Text;
                lastName = LNameBox.Text;
                await eRep.add(name, lastName);

                F.dgv.DataSource = null;
                list = await eRep.get();
                F.bs.DataSource = list;
                F.dgv.DataSource = list;

                MessageBox.Show("New Employee successfully added to DataBase.");
                this.Close();
            } else
            {
                DialogResult dialogResult = MessageBox.Show("Fill empty textBox", "WARNING", MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    AddDIalog add = this;
                    this.Show();
                }
            }
        }
    }
}
