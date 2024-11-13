namespace CourseApp.DesktopUI.Forms
{
    partial class ExamForm
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
            groupBox2 = new GroupBox();
            label4 = new Label();
            txtLessonName = new TextBox();
            label5 = new Label();
            dtLessonDate = new DateTimePicker();
            lstListe = new ListBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dtLessonDate);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtLessonName);
            groupBox2.Location = new Point(18, 131);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(554, 140);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "SINAV KAYIT FORMU";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 52);
            label4.Name = "label4";
            label4.Size = new Size(113, 27);
            label4.TabIndex = 5;
            label4.Text = "Sınav Adı";
            // 
            // txtLessonName
            // 
            txtLessonName.Location = new Point(173, 44);
            txtLessonName.Name = "txtLessonName";
            txtLessonName.Size = new Size(361, 35);
            txtLessonName.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 91);
            label5.Name = "label5";
            label5.Size = new Size(135, 27);
            label5.TabIndex = 7;
            label5.Text = "Sınav Tarihi";
            // 
            // dtLessonDate
            // 
            dtLessonDate.Location = new Point(173, 85);
            dtLessonDate.Name = "dtLessonDate";
            dtLessonDate.Size = new Size(361, 35);
            dtLessonDate.TabIndex = 6;
            // 
            // lstListe
            // 
            lstListe.FormattingEnabled = true;
            lstListe.ItemHeight = 27;
            lstListe.Location = new Point(18, 277);
            lstListe.Name = "lstListe";
            lstListe.Size = new Size(554, 139);
            lstListe.TabIndex = 2;
            // 
            // ExamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 427);
            Controls.Add(lstListe);
            Controls.Add(groupBox2);
            Name = "ExamForm";
            Text = "ExamForm";
            Load += ExamForm_Load;
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(lstListe, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label label4;
        private TextBox txtLessonName;
        private Label label5;
        private DateTimePicker dtLessonDate;
        private ListBox lstListe;
    }
}