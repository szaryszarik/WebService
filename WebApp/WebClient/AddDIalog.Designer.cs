namespace WebClient
{
    partial class AddDIalog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLbl = new System.Windows.Forms.Label();
            this.LNameLbl = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.LNameBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLbl.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NameLbl.Location = new System.Drawing.Point(57, 9);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(79, 25);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Name:";
            // 
            // LNameLbl
            // 
            this.LNameLbl.AutoSize = true;
            this.LNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LNameLbl.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LNameLbl.Location = new System.Drawing.Point(5, 46);
            this.LNameLbl.Name = "LNameLbl";
            this.LNameLbl.Size = new System.Drawing.Size(131, 25);
            this.LNameLbl.TabIndex = 1;
            this.LNameLbl.Text = "Last Name:";
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameBox.Location = new System.Drawing.Point(142, 6);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(217, 31);
            this.NameBox.TabIndex = 2;
            // 
            // LNameBox
            // 
            this.LNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LNameBox.Location = new System.Drawing.Point(142, 43);
            this.LNameBox.Name = "LNameBox";
            this.LNameBox.Size = new System.Drawing.Size(217, 31);
            this.LNameBox.TabIndex = 3;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddButton.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.AddButton.Location = new System.Drawing.Point(142, 80);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(105, 52);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitButton.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ExitButton.Location = new System.Drawing.Point(254, 80);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(105, 52);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Cancel";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // AddDIalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(371, 138);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.LNameBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.LNameLbl);
            this.Controls.Add(this.NameLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "AddDIalog";
            this.Text = "New Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label LNameLbl;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox LNameBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ExitButton;
    }
}