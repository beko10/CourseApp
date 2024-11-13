namespace CourseApp.DesktopUI.Forms
{
    partial class InstructorForm
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
            label1 = new Label();
            groupBox2 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lstListe = new ListBox();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtEmail = new TextBox();
            txtUzmanlik = new TextBox();
            txtTelefon = new TextBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 78);
            label1.Name = "label1";
            label1.Size = new Size(41, 27);
            label1.TabIndex = 5;
            label1.Text = "Ad";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtTelefon);
            groupBox2.Controls.Add(txtUzmanlik);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(txtSoyad);
            groupBox2.Controls.Add(txtAd);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(18, 137);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(686, 296);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "EĞİTMEN KAYIT FORMU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 119);
            label2.Name = "label2";
            label2.Size = new Size(80, 27);
            label2.TabIndex = 5;
            label2.Text = "Soyad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 160);
            label3.Name = "label3";
            label3.Size = new Size(72, 27);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 201);
            label4.Name = "label4";
            label4.Size = new Size(172, 27);
            label4.TabIndex = 5;
            label4.Text = "Uzmanlık Alanı";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 242);
            label5.Name = "label5";
            label5.Size = new Size(89, 27);
            label5.TabIndex = 5;
            label5.Text = "Telefon";
            // 
            // lstListe
            // 
            lstListe.FormattingEnabled = true;
            lstListe.ItemHeight = 27;
            lstListe.Location = new Point(18, 439);
            lstListe.Name = "lstListe";
            lstListe.Size = new Size(686, 193);
            lstListe.TabIndex = 8;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(213, 75);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(455, 35);
            txtAd.TabIndex = 6;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(213, 116);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(455, 35);
            txtSoyad.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(213, 157);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(455, 35);
            txtEmail.TabIndex = 6;
            // 
            // txtUzmanlik
            // 
            txtUzmanlik.Location = new Point(213, 198);
            txtUzmanlik.Name = "txtUzmanlik";
            txtUzmanlik.Size = new Size(455, 35);
            txtUzmanlik.TabIndex = 6;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(213, 239);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(455, 35);
            txtTelefon.TabIndex = 6;
            // 
            // InstructorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 648);
            Controls.Add(lstListe);
            Controls.Add(groupBox2);
            Name = "InstructorForm";
            Text = "InstructorForm";
            Load += InstructorForm_Load;
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(lstListe, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ListBox lstListe;
        private TextBox txtTelefon;
        private TextBox txtUzmanlik;
        private TextBox txtEmail;
        private TextBox txtSoyad;
        private TextBox txtAd;
    }
}