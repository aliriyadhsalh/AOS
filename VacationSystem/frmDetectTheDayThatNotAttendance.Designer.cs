namespace VacationSystem
{
    partial class frmDetectTheDayThatNotAttendance
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.rdbAttend = new System.Windows.Forms.RadioButton();
            this.rdbNotAttend = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtDateTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdbNotAttend);
            this.panel1.Controls.Add(this.rdbAttend);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.dtDateFrom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 414);
            this.panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::VacationSystem.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(4, 365);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 44);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "اضافة";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::VacationSystem.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(4, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 37);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.CalendarFont = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateFrom.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtDateFrom.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtDateFrom.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.dtDateFrom.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateFrom.Location = new System.Drawing.Point(74, 180);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtDateFrom.RightToLeftLayout = true;
            this.dtDateFrom.Size = new System.Drawing.Size(344, 45);
            this.dtDateFrom.TabIndex = 7;
            // 
            // rdbAttend
            // 
            this.rdbAttend.AutoSize = true;
            this.rdbAttend.BackColor = System.Drawing.SystemColors.Control;
            this.rdbAttend.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAttend.ForeColor = System.Drawing.Color.Black;
            this.rdbAttend.Location = new System.Drawing.Point(143, 52);
            this.rdbAttend.Name = "rdbAttend";
            this.rdbAttend.Size = new System.Drawing.Size(81, 41);
            this.rdbAttend.TabIndex = 10;
            this.rdbAttend.Text = "حاضر";
            this.rdbAttend.UseVisualStyleBackColor = false;
            // 
            // rdbNotAttend
            // 
            this.rdbNotAttend.AutoSize = true;
            this.rdbNotAttend.BackColor = System.Drawing.SystemColors.Control;
            this.rdbNotAttend.Checked = true;
            this.rdbNotAttend.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNotAttend.ForeColor = System.Drawing.Color.Black;
            this.rdbNotAttend.Location = new System.Drawing.Point(269, 52);
            this.rdbNotAttend.Name = "rdbNotAttend";
            this.rdbNotAttend.Size = new System.Drawing.Size(81, 41);
            this.rdbNotAttend.TabIndex = 11;
            this.rdbNotAttend.TabStop = true;
            this.rdbNotAttend.Text = "غائب";
            this.rdbNotAttend.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = "من : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(219, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 37);
            this.label2.TabIndex = 14;
            this.label2.Text = "الى :";
            // 
            // dtDateTo
            // 
            this.dtDateTo.CalendarFont = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateTo.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtDateTo.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtDateTo.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.dtDateTo.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateTo.Location = new System.Drawing.Point(74, 290);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtDateTo.RightToLeftLayout = true;
            this.dtDateTo.Size = new System.Drawing.Size(344, 45);
            this.dtDateTo.TabIndex = 13;
            // 
            // frmDetectTheDayThatNotAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(502, 424);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cairo", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDetectTheDayThatNotAttendance";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.RadioButton rdbNotAttend;
        private System.Windows.Forms.RadioButton rdbAttend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.Label label1;
    }
}