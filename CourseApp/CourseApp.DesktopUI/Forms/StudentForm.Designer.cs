namespace CourseApp.DesktopUI.Forms
{
    partial class StudentForm
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
            txtSoyad = new MaskedTextBox();
            txtAd = new MaskedTextBox();
            txtDTarihi = new MaskedTextBox();
            txtTC = new MaskedTextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lstListe = new ListBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSoyad);
            groupBox2.Controls.Add(txtAd);
            groupBox2.Controls.Add(txtDTarihi);
            groupBox2.Controls.Add(txtTC);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 121);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(839, 277);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "ÖĞRENCİ KAYIT FORMU";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(218, 169);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(602, 35);
            txtSoyad.TabIndex = 4;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(218, 116);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(602, 35);
            txtAd.TabIndex = 4;
            // 
            // txtDTarihi
            // 
            txtDTarihi.Location = new Point(218, 222);
            txtDTarihi.Mask = "00/00/0000";
            txtDTarihi.Name = "txtDTarihi";
            txtDTarihi.Size = new Size(602, 35);
            txtDTarihi.TabIndex = 4;
            txtDTarihi.ValidatingType = typeof(DateTime);
            // 
            // txtTC
            // 
            txtTC.Location = new Point(218, 63);
            txtTC.Name = "txtTC";
            txtTC.Size = new Size(602, 35);
            txtTC.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 222);
            label4.Name = "label4";
            label4.Size = new Size(153, 27);
            label4.TabIndex = 0;
            label4.Text = "Doğum Tarihi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 169);
            label3.Name = "label3";
            label3.Size = new Size(80, 27);
            label3.TabIndex = 0;
            label3.Text = "Soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 116);
            label2.Name = "label2";
            label2.Size = new Size(41, 27);
            label2.TabIndex = 0;
            label2.Text = "Ad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 63);
            label1.Name = "label1";
            label1.Size = new Size(114, 27);
            label1.TabIndex = 0;
            label1.Text = "TC Kimlik";
            // 
            // lstListe
            // 
            lstListe.FormattingEnabled = true;
            lstListe.ItemHeight = 27;
            lstListe.Location = new Point(12, 404);
            lstListe.Name = "lstListe";
            lstListe.Size = new Size(839, 193);
            lstListe.TabIndex = 6;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 607);
            Controls.Add(groupBox2);
            Controls.Add(lstListe);
            Name = "StudentForm";
            Text = "StudentForm";
            Load += StudentForm_Load;
            Controls.SetChildIndex(lstListe, 0);
            Controls.SetChildIndex(groupBox2, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private MaskedTextBox txtSoyad;
        private MaskedTextBox txtAd;
        private MaskedTextBox txtDTarihi;
        private MaskedTextBox txtTC;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ListBox lstListe;
    }
}