namespace CourseApp.DesktopUI.Forms
{
    partial class ExamResultForm
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
            txtNot = new TextBox();
            cmbOgrenci = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            cmbSinav = new ComboBox();
            label1 = new Label();
            lstListe = new ListBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNot);
            groupBox2.Controls.Add(cmbOgrenci);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(cmbSinav);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(18, 131);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(696, 188);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "SINAV SONUÇ GİRİŞ FORMU";
            // 
            // txtNot
            // 
            txtNot.Location = new Point(219, 130);
            txtNot.Name = "txtNot";
            txtNot.Size = new Size(467, 35);
            txtNot.TabIndex = 2;
            // 
            // cmbOgrenci
            // 
            cmbOgrenci.FormattingEnabled = true;
            cmbOgrenci.Location = new Point(219, 89);
            cmbOgrenci.Name = "cmbOgrenci";
            cmbOgrenci.Size = new Size(467, 35);
            cmbOgrenci.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 133);
            label3.Name = "label3";
            label3.Size = new Size(49, 27);
            label3.TabIndex = 0;
            label3.Text = "Not";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 92);
            label2.Name = "label2";
            label2.Size = new Size(181, 27);
            label2.TabIndex = 0;
            label2.Text = "Öğrenci Seçiniz";
            // 
            // cmbSinav
            // 
            cmbSinav.FormattingEnabled = true;
            cmbSinav.Location = new Point(219, 48);
            cmbSinav.Name = "cmbSinav";
            cmbSinav.Size = new Size(467, 35);
            cmbSinav.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 51);
            label1.Name = "label1";
            label1.Size = new Size(156, 27);
            label1.TabIndex = 0;
            label1.Text = "Sınav Seçiniz";
            // 
            // lstListe
            // 
            lstListe.FormattingEnabled = true;
            lstListe.ItemHeight = 27;
            lstListe.Location = new Point(18, 325);
            lstListe.Name = "lstListe";
            lstListe.Size = new Size(696, 139);
            lstListe.TabIndex = 2;
            // 
            // ExamResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 481);
            Controls.Add(lstListe);
            Controls.Add(groupBox2);
            Name = "ExamResultForm";
            Text = "ExamResultForm";
            Load += ExamResultForm_Load;
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(lstListe, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private TextBox txtNot;
        private ComboBox cmbOgrenci;
        private Label label3;
        private Label label2;
        private ComboBox cmbSinav;
        private Label label1;
        private ListBox lstListe;
    }
}