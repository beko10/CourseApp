namespace CourseApp.DesktopUI.Forms
{
    partial class RegistrationForm
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
            lstListe = new ListBox();
            txtFiyat = new TextBox();
            cmbOgrenci = new ComboBox();
            cmbKurs = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstListe);
            groupBox2.Controls.Add(txtFiyat);
            groupBox2.Controls.Add(cmbOgrenci);
            groupBox2.Controls.Add(cmbKurs);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 130);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(713, 335);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "ÖĞRENCİ KAYIT İŞLEMLERİ";
            // 
            // lstListe
            // 
            lstListe.FormattingEnabled = true;
            lstListe.ItemHeight = 27;
            lstListe.Location = new Point(18, 173);
            lstListe.Name = "lstListe";
            lstListe.Size = new Size(674, 139);
            lstListe.TabIndex = 12;
            // 
            // txtFiyat
            // 
            txtFiyat.Location = new Point(228, 132);
            txtFiyat.Name = "txtFiyat";
            txtFiyat.Size = new Size(464, 35);
            txtFiyat.TabIndex = 10;
            // 
            // cmbOgrenci
            // 
            cmbOgrenci.FormattingEnabled = true;
            cmbOgrenci.Location = new Point(228, 91);
            cmbOgrenci.Name = "cmbOgrenci";
            cmbOgrenci.Size = new Size(464, 35);
            cmbOgrenci.TabIndex = 8;
            // 
            // cmbKurs
            // 
            cmbKurs.FormattingEnabled = true;
            cmbKurs.Location = new Point(228, 50);
            cmbKurs.Name = "cmbKurs";
            cmbKurs.Size = new Size(464, 35);
            cmbKurs.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 140);
            label3.Name = "label3";
            label3.Size = new Size(127, 27);
            label3.TabIndex = 5;
            label3.Text = "Kurs Fiyatı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 94);
            label2.Name = "label2";
            label2.Size = new Size(181, 27);
            label2.TabIndex = 6;
            label2.Text = "Öğrenci Seçiniz";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 53);
            label1.Name = "label1";
            label1.Size = new Size(146, 27);
            label1.TabIndex = 7;
            label1.Text = "Kurs Seçiniz";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 491);
            Controls.Add(groupBox2);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            Load += RegistrationForm_Load;
            Controls.SetChildIndex(groupBox2, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private ListBox lstListe;
        private TextBox txtFiyat;
        private ComboBox cmbOgrenci;
        private ComboBox cmbKurs;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}