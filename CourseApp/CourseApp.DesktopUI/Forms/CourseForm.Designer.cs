namespace CourseApp.DesktopUI.Forms
{
    partial class CourseForm
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
            lstCourseList = new ListBox();
            groupBox2 = new GroupBox();
            cmbInstructor = new ComboBox();
            label8 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtEndDate = new DateTimePicker();
            dtStartDate = new DateTimePicker();
            txtCourseName = new TextBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lstCourseList
            // 
            lstCourseList.FormattingEnabled = true;
            lstCourseList.ItemHeight = 27;
            lstCourseList.Location = new Point(29, 231);
            lstCourseList.Name = "lstCourseList";
            lstCourseList.Size = new Size(520, 193);
            lstCourseList.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstCourseList);
            groupBox2.Controls.Add(cmbInstructor);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dtEndDate);
            groupBox2.Controls.Add(dtStartDate);
            groupBox2.Controls.Add(txtCourseName);
            groupBox2.Location = new Point(18, 121);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(565, 441);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "KURS KAYIT FORMU";
            // 
            // cmbInstructor
            // 
            cmbInstructor.FormattingEnabled = true;
            cmbInstructor.Location = new Point(230, 179);
            cmbInstructor.Name = "cmbInstructor";
            cmbInstructor.Size = new Size(319, 35);
            cmbInstructor.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 182);
            label8.Name = "label8";
            label8.Size = new Size(192, 27);
            label8.TabIndex = 3;
            label8.Text = "Eğitmen Seçiniz:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 140);
            label3.Name = "label3";
            label3.Size = new Size(120, 27);
            label3.TabIndex = 3;
            label3.Text = "Bitiş Tarihi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 99);
            label2.Name = "label2";
            label2.Size = new Size(181, 27);
            label2.TabIndex = 3;
            label2.Text = "Başlangıç Tarihi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 58);
            label1.Name = "label1";
            label1.Size = new Size(103, 27);
            label1.TabIndex = 3;
            label1.Text = "Kurs Adı";
            // 
            // dtEndDate
            // 
            dtEndDate.Location = new Point(230, 140);
            dtEndDate.Name = "dtEndDate";
            dtEndDate.Size = new Size(319, 35);
            dtEndDate.TabIndex = 2;
            // 
            // dtStartDate
            // 
            dtStartDate.Location = new Point(230, 99);
            dtStartDate.Name = "dtStartDate";
            dtStartDate.Size = new Size(319, 35);
            dtStartDate.TabIndex = 2;
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(230, 58);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(319, 35);
            txtCourseName.TabIndex = 1;
            txtCourseName.TextChanged += txtCourseName_TextChanged;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 568);
            Controls.Add(groupBox2);
            Name = "CourseForm";
            Text = "CourseForm";
            Load += CourseForm_Load;
            Controls.SetChildIndex(groupBox2, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstCourseList;
        private GroupBox groupBox2;
        private ComboBox cmbInstructor;
        private Label label8;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtEndDate;
        private DateTimePicker dtStartDate;
        private TextBox txtCourseName;
    }
}