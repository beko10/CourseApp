namespace CourseApp.DesktopUI.Forms
{
    partial class LessonForm
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
            lstLessonList = new ListBox();
            groupBox2 = new GroupBox();
            txtLessonTime = new MaskedTextBox();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label9 = new Label();
            label5 = new Label();
            txtLessonContent = new TextBox();
            txtLessonDuration = new TextBox();
            txtLessonName = new TextBox();
            dtLessonDate = new DateTimePicker();
            comboBox1 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lstLessonList
            // 
            lstLessonList.FormattingEnabled = true;
            lstLessonList.ItemHeight = 27;
            lstLessonList.Location = new Point(570, 133);
            lstLessonList.Name = "lstLessonList";
            lstLessonList.Size = new Size(313, 355);
            lstLessonList.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(txtLessonTime);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtLessonContent);
            groupBox2.Controls.Add(txtLessonDuration);
            groupBox2.Controls.Add(txtLessonName);
            groupBox2.Controls.Add(dtLessonDate);
            groupBox2.Location = new Point(18, 121);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(546, 394);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "DERS KAYIT FORMU";
            // 
            // txtLessonTime
            // 
            txtLessonTime.Location = new Point(170, 161);
            txtLessonTime.Name = "txtLessonTime";
            txtLessonTime.Size = new Size(361, 35);
            txtLessonTime.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 243);
            label7.Name = "label7";
            label7.Size = new Size(132, 27);
            label7.TabIndex = 3;
            label7.Text = "Ders İçeriği";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 201);
            label6.Name = "label6";
            label6.Size = new Size(137, 27);
            label6.TabIndex = 3;
            label6.Text = "Ders Süresi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 87);
            label4.Name = "label4";
            label4.Size = new Size(103, 27);
            label4.TabIndex = 3;
            label4.Text = "Ders Adı";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 165);
            label9.Name = "label9";
            label9.Size = new Size(61, 27);
            label9.TabIndex = 3;
            label9.Text = "Saat";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 126);
            label5.Name = "label5";
            label5.Size = new Size(63, 27);
            label5.TabIndex = 3;
            label5.Text = "Tarih";
            // 
            // txtLessonContent
            // 
            txtLessonContent.Location = new Point(170, 243);
            txtLessonContent.Multiline = true;
            txtLessonContent.Name = "txtLessonContent";
            txtLessonContent.Size = new Size(361, 137);
            txtLessonContent.TabIndex = 1;
            // 
            // txtLessonDuration
            // 
            txtLessonDuration.Location = new Point(170, 202);
            txtLessonDuration.Name = "txtLessonDuration";
            txtLessonDuration.Size = new Size(361, 35);
            txtLessonDuration.TabIndex = 1;
            // 
            // txtLessonName
            // 
            txtLessonName.Location = new Point(170, 79);
            txtLessonName.Name = "txtLessonName";
            txtLessonName.Size = new Size(361, 35);
            txtLessonName.TabIndex = 1;
            // 
            // dtLessonDate
            // 
            dtLessonDate.Location = new Point(170, 120);
            dtLessonDate.Name = "dtLessonDate";
            dtLessonDate.Size = new Size(361, 35);
            dtLessonDate.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(170, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(361, 35);
            comboBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 46);
            label1.Name = "label1";
            label1.Size = new Size(153, 27);
            label1.TabIndex = 3;
            label1.Text = "Kurs Seçiniz:";
            // 
            // button1
            // 
            button1.Location = new Point(188, 521);
            button1.Name = "button1";
            button1.Size = new Size(376, 58);
            button1.TabIndex = 4;
            button1.Text = "Bu Dersi Kursa Ata >>";
            button1.UseVisualStyleBackColor = true;
            // 
            // LessonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 612);
            Controls.Add(button1);
            Controls.Add(lstLessonList);
            Controls.Add(groupBox2);
            Name = "LessonForm";
            Text = "LessonForm";
            Load += LessonForm_Load;
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(lstLessonList, 0);
            Controls.SetChildIndex(button1, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstLessonList;
        private GroupBox groupBox2;
        private MaskedTextBox txtLessonTime;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label9;
        private Label label5;
        private TextBox txtLessonContent;
        private TextBox txtLessonDuration;
        private TextBox txtLessonName;
        private DateTimePicker dtLessonDate;
        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
    }
}