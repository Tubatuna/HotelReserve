namespace HotelReserve
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            cmbotel = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button2 = new Button();
            txtad = new TextBox();
            txtsoyad = new TextBox();
            txtadres = new TextBox();
            txtmail = new TextBox();
            txttel = new TextBox();
            txtkisi = new TextBox();
            cmboda = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.MistyRose;
            groupBox1.Controls.Add(cmboda);
            groupBox1.Controls.Add(txtkisi);
            groupBox1.Controls.Add(txttel);
            groupBox1.Controls.Add(txtmail);
            groupBox1.Controls.Add(txtadres);
            groupBox1.Controls.Add(txtsoyad);
            groupBox1.Controls.Add(txtad);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbotel);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.Location = new Point(23, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(661, 569);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rezervasyon Formu";
            // 
            // cmbotel
            // 
            cmbotel.FormattingEnabled = true;
            cmbotel.Location = new Point(6, 33);
            cmbotel.Name = "cmbotel";
            cmbotel.Size = new Size(558, 36);
            cmbotel.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(19, 104);
            label2.Name = "label2";
            label2.Size = new Size(38, 28);
            label2.TabIndex = 2;
            label2.Text = "Ad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(19, 152);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 2;
            label3.Text = "Soyad";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(19, 201);
            label4.Name = "label4";
            label4.Size = new Size(66, 28);
            label4.TabIndex = 2;
            label4.Text = "Adres";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(19, 252);
            label5.Name = "label5";
            label5.Size = new Size(82, 28);
            label5.TabIndex = 2;
            label5.Text = "E-Posta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(19, 294);
            label6.Name = "label6";
            label6.Size = new Size(82, 28);
            label6.TabIndex = 2;
            label6.Text = "Telefon";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(19, 330);
            label7.Name = "label7";
            label7.Size = new Size(106, 28);
            label7.TabIndex = 2;
            label7.Text = "Kişi Sayısı";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.Location = new Point(19, 378);
            label8.Name = "label8";
            label8.Size = new Size(92, 28);
            label8.TabIndex = 2;
            label8.Text = "Oda Tipi";
            // 
            // button2
            // 
            button2.BackColor = Color.LightGray;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.Location = new Point(271, 467);
            button2.Name = "button2";
            button2.Size = new Size(293, 56);
            button2.TabIndex = 4;
            button2.Text = "Rezervasyon Oluştur";
            button2.UseVisualStyleBackColor = false;
            // 
            // txtad
            // 
            txtad.Location = new Point(271, 97);
            txtad.Name = "txtad";
            txtad.Size = new Size(293, 34);
            txtad.TabIndex = 5;
            // 
            // txtsoyad
            // 
            txtsoyad.Location = new Point(271, 145);
            txtsoyad.Name = "txtsoyad";
            txtsoyad.Size = new Size(293, 34);
            txtsoyad.TabIndex = 6;
            // 
            // txtadres
            // 
            txtadres.Location = new Point(271, 194);
            txtadres.Name = "txtadres";
            txtadres.Size = new Size(293, 34);
            txtadres.TabIndex = 7;
            // 
            // txtmail
            // 
            txtmail.Location = new Point(271, 245);
            txtmail.Name = "txtmail";
            txtmail.Size = new Size(293, 34);
            txtmail.TabIndex = 8;
            // 
            // txttel
            // 
            txttel.Location = new Point(271, 287);
            txttel.Name = "txttel";
            txttel.Size = new Size(293, 34);
            txttel.TabIndex = 9;
            // 
            // txtkisi
            // 
            txtkisi.Location = new Point(271, 330);
            txtkisi.Name = "txtkisi";
            txtkisi.Size = new Size(293, 34);
            txtkisi.TabIndex = 10;
            // 
            // cmboda
            // 
            cmboda.FormattingEnabled = true;
            cmboda.Location = new Point(271, 370);
            cmboda.Name = "cmboda";
            cmboda.Size = new Size(293, 36);
            cmboda.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 632);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cmbotel;
        private ComboBox cmboda;
        private TextBox txtkisi;
        private TextBox txttel;
        private TextBox txtmail;
        private TextBox txtadres;
        private TextBox txtsoyad;
        private TextBox txtad;
        private Button button2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}
