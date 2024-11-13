namespace CourseApp.DesktopUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            pROGRAMTANIMLARIToolStripMenuItem = new ToolStripMenuItem();
            öğrenciTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            kursTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            eğitmenTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            dersTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            sınavTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            sınavSonuçTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            iŞLEMLERToolStripMenuItem = new ToolStripMenuItem();
            öĞRENCİKAYITİŞLEMLERİToolStripMenuItem = new ToolStripMenuItem();
            lblInstructorCount = new Label();
            lblStudentCount = new Label();
            lblCourseCount = new Label();
            lblExamCount = new Label();
            lblExamResultCount = new Label();
            lblLessonCount = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 18F);
            menuStrip1.Items.AddRange(new ToolStripItem[] { pROGRAMTANIMLARIToolStripMenuItem, iŞLEMLERToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(939, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // pROGRAMTANIMLARIToolStripMenuItem
            // 
            pROGRAMTANIMLARIToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { öğrenciTanımlarıToolStripMenuItem, kursTanımlarıToolStripMenuItem, eğitmenTanımlarıToolStripMenuItem, dersTanımlarıToolStripMenuItem, sınavTanımlarıToolStripMenuItem, sınavSonuçTanımlarıToolStripMenuItem });
            pROGRAMTANIMLARIToolStripMenuItem.Name = "pROGRAMTANIMLARIToolStripMenuItem";
            pROGRAMTANIMLARIToolStripMenuItem.Size = new Size(264, 36);
            pROGRAMTANIMLARIToolStripMenuItem.Text = "PROGRAM TANIMLARI";
            // 
            // öğrenciTanımlarıToolStripMenuItem
            // 
            öğrenciTanımlarıToolStripMenuItem.Name = "öğrenciTanımlarıToolStripMenuItem";
            öğrenciTanımlarıToolStripMenuItem.Size = new Size(320, 36);
            öğrenciTanımlarıToolStripMenuItem.Text = "Öğrenci Tanımları";
            öğrenciTanımlarıToolStripMenuItem.Click += öğrenciTanımlarıToolStripMenuItem_Click;
            // 
            // kursTanımlarıToolStripMenuItem
            // 
            kursTanımlarıToolStripMenuItem.Name = "kursTanımlarıToolStripMenuItem";
            kursTanımlarıToolStripMenuItem.Size = new Size(320, 36);
            kursTanımlarıToolStripMenuItem.Text = "Kurs Tanımları";
            kursTanımlarıToolStripMenuItem.Click += kursTanımlarıToolStripMenuItem_Click;
            // 
            // eğitmenTanımlarıToolStripMenuItem
            // 
            eğitmenTanımlarıToolStripMenuItem.Name = "eğitmenTanımlarıToolStripMenuItem";
            eğitmenTanımlarıToolStripMenuItem.Size = new Size(320, 36);
            eğitmenTanımlarıToolStripMenuItem.Text = "Eğitmen Tanımları";
            eğitmenTanımlarıToolStripMenuItem.Click += eğitmenTanımlarıToolStripMenuItem_Click;
            // 
            // dersTanımlarıToolStripMenuItem
            // 
            dersTanımlarıToolStripMenuItem.Name = "dersTanımlarıToolStripMenuItem";
            dersTanımlarıToolStripMenuItem.Size = new Size(320, 36);
            dersTanımlarıToolStripMenuItem.Text = "Ders Tanımları";
            dersTanımlarıToolStripMenuItem.Click += dersTanımlarıToolStripMenuItem_Click;
            // 
            // sınavTanımlarıToolStripMenuItem
            // 
            sınavTanımlarıToolStripMenuItem.Name = "sınavTanımlarıToolStripMenuItem";
            sınavTanımlarıToolStripMenuItem.Size = new Size(320, 36);
            sınavTanımlarıToolStripMenuItem.Text = "Sınav Tanımları";
            sınavTanımlarıToolStripMenuItem.Click += sınavTanımlarıToolStripMenuItem_Click;
            // 
            // sınavSonuçTanımlarıToolStripMenuItem
            // 
            sınavSonuçTanımlarıToolStripMenuItem.Name = "sınavSonuçTanımlarıToolStripMenuItem";
            sınavSonuçTanımlarıToolStripMenuItem.Size = new Size(320, 36);
            sınavSonuçTanımlarıToolStripMenuItem.Text = "Sınav Sonuç Tanımları";
            sınavSonuçTanımlarıToolStripMenuItem.Click += sınavSonuçTanımlarıToolStripMenuItem_Click;
            // 
            // iŞLEMLERToolStripMenuItem
            // 
            iŞLEMLERToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { öĞRENCİKAYITİŞLEMLERİToolStripMenuItem });
            iŞLEMLERToolStripMenuItem.Name = "iŞLEMLERToolStripMenuItem";
            iŞLEMLERToolStripMenuItem.Size = new Size(127, 36);
            iŞLEMLERToolStripMenuItem.Text = "İŞLEMLER";
            // 
            // öĞRENCİKAYITİŞLEMLERİToolStripMenuItem
            // 
            öĞRENCİKAYITİŞLEMLERİToolStripMenuItem.Name = "öĞRENCİKAYITİŞLEMLERİToolStripMenuItem";
            öĞRENCİKAYITİŞLEMLERİToolStripMenuItem.Size = new Size(367, 36);
            öĞRENCİKAYITİŞLEMLERİToolStripMenuItem.Text = "ÖĞRENCİ KAYIT İŞLEMLERİ";
            öĞRENCİKAYITİŞLEMLERİToolStripMenuItem.Click += öĞRENCİKAYITİŞLEMLERİToolStripMenuItem_Click;
            // 
            // lblInstructorCount
            // 
            lblInstructorCount.BackColor = Color.FromArgb(192, 255, 255);
            lblInstructorCount.Font = new Font("Segoe UI", 22F);
            lblInstructorCount.Location = new Point(12, 128);
            lblInstructorCount.Name = "lblInstructorCount";
            lblInstructorCount.Size = new Size(225, 106);
            lblInstructorCount.TabIndex = 1;
            lblInstructorCount.Text = "Eğitmen Sayısı";
            lblInstructorCount.Click += label1_Click;
            // 
            // lblStudentCount
            // 
            lblStudentCount.BackColor = Color.FromArgb(192, 255, 192);
            lblStudentCount.Font = new Font("Segoe UI", 22F);
            lblStudentCount.Location = new Point(254, 128);
            lblStudentCount.Name = "lblStudentCount";
            lblStudentCount.Size = new Size(225, 106);
            lblStudentCount.TabIndex = 1;
            lblStudentCount.Text = "Öğrenci Sayısı";
            // 
            // lblCourseCount
            // 
            lblCourseCount.BackColor = Color.FromArgb(255, 192, 255);
            lblCourseCount.Font = new Font("Segoe UI", 22F);
            lblCourseCount.Location = new Point(494, 128);
            lblCourseCount.Name = "lblCourseCount";
            lblCourseCount.Size = new Size(225, 106);
            lblCourseCount.TabIndex = 1;
            lblCourseCount.Text = "Eğitim Sayısı";
            // 
            // lblExamCount
            // 
            lblExamCount.BackColor = Color.FromArgb(192, 255, 192);
            lblExamCount.Font = new Font("Segoe UI", 22F);
            lblExamCount.Location = new Point(12, 266);
            lblExamCount.Name = "lblExamCount";
            lblExamCount.Size = new Size(225, 106);
            lblExamCount.TabIndex = 1;
            lblExamCount.Text = "Sınav Sayısı";
            // 
            // lblExamResultCount
            // 
            lblExamResultCount.BackColor = Color.FromArgb(255, 192, 255);
            lblExamResultCount.Font = new Font("Segoe UI", 22F);
            lblExamResultCount.Location = new Point(254, 266);
            lblExamResultCount.Name = "lblExamResultCount";
            lblExamResultCount.Size = new Size(225, 106);
            lblExamResultCount.TabIndex = 1;
            lblExamResultCount.Text = "Sınav Sonucu Sayısı";
            // 
            // lblLessonCount
            // 
            lblLessonCount.BackColor = Color.FromArgb(192, 255, 255);
            lblLessonCount.Font = new Font("Segoe UI", 22F);
            lblLessonCount.Location = new Point(494, 266);
            lblLessonCount.Name = "lblLessonCount";
            lblLessonCount.Size = new Size(225, 106);
            lblLessonCount.TabIndex = 1;
            lblLessonCount.Text = "Ders Sayısı";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 435);
            Controls.Add(lblLessonCount);
            Controls.Add(lblCourseCount);
            Controls.Add(lblExamResultCount);
            Controls.Add(lblStudentCount);
            Controls.Add(lblExamCount);
            Controls.Add(lblInstructorCount);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem pROGRAMTANIMLARIToolStripMenuItem;
        private ToolStripMenuItem öğrenciTanımlarıToolStripMenuItem;
        private ToolStripMenuItem kursTanımlarıToolStripMenuItem;
        private ToolStripMenuItem eğitmenTanımlarıToolStripMenuItem;
        private ToolStripMenuItem dersTanımlarıToolStripMenuItem;
        private ToolStripMenuItem sınavTanımlarıToolStripMenuItem;
        private ToolStripMenuItem sınavSonuçTanımlarıToolStripMenuItem;
        private ToolStripMenuItem iŞLEMLERToolStripMenuItem;
        private ToolStripMenuItem öĞRENCİKAYITİŞLEMLERİToolStripMenuItem;
        private Label lblInstructorCount;
        private Label lblStudentCount;
        private Label lblCourseCount;
        private Label lblExamCount;
        private Label lblExamResultCount;
        private Label lblLessonCount;
    }
}
