﻿namespace HotelReserve
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
            dateTimePicker1 = new DateTimePicker();
            txtkisi = new TextBox();
            txttel = new TextBox();
            txtmail = new TextBox();
            txtadres = new TextBox();
            txtsoyad = new TextBox();
            txtad = new TextBox();
            button2 = new Button();
            label1 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cmbotel = new ComboBox();
            cmboda = new ComboBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            cmbpaymentmethod = new ComboBox();
            datecikis = new DateTimePicker();
            dtpgiris = new DateTimePicker();
            button1 = new Button();
            label10 = new Label();
            dtpcikis = new Label();
            label11 = new Label();
            label9 = new Label();
            label12 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.MistyRose;
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(txtkisi);
            groupBox1.Controls.Add(txttel);
            groupBox1.Controls.Add(txtmail);
            groupBox1.Controls.Add(txtadres);
            groupBox1.Controls.Add(txtsoyad);
            groupBox1.Controls.Add(txtad);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label1);
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
            groupBox1.Size = new Size(623, 569);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rezervasyon Formu";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(271, 384);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(293, 34);
            dateTimePicker1.TabIndex = 11;
            // 
            // txtkisi
            // 
            txtkisi.Location = new Point(271, 330);
            txtkisi.Name = "txtkisi";
            txtkisi.Size = new Size(293, 34);
            txtkisi.TabIndex = 10;
            // 
            // txttel
            // 
            txttel.Location = new Point(271, 287);
            txttel.Name = "txttel";
            txttel.Size = new Size(293, 34);
            txttel.TabIndex = 9;
            // 
            // txtmail
            // 
            txtmail.Location = new Point(271, 245);
            txtmail.Name = "txtmail";
            txtmail.Size = new Size(293, 34);
            txtmail.TabIndex = 8;
            // 
            // txtadres
            // 
            txtadres.Location = new Point(271, 194);
            txtadres.Name = "txtadres";
            txtadres.Size = new Size(293, 34);
            txtadres.TabIndex = 7;
            // 
            // txtsoyad
            // 
            txtsoyad.Location = new Point(271, 145);
            txtsoyad.Name = "txtsoyad";
            txtsoyad.Size = new Size(293, 34);
            txtsoyad.TabIndex = 6;
            // 
            // txtad
            // 
            txtad.Location = new Point(271, 97);
            txtad.Name = "txtad";
            txtad.Size = new Size(293, 34);
            txtad.TabIndex = 5;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.Location = new Point(271, 458);
            button2.Name = "button2";
            button2.Size = new Size(293, 56);
            button2.TabIndex = 4;
            button2.Text = "Misafir Bilgilerini Kaydet";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(6, 390);
            label1.Name = "label1";
            label1.Size = new Size(140, 28);
            label1.TabIndex = 2;
            label1.Text = "Doğum Tarihi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(6, 345);
            label7.Name = "label7";
            label7.Size = new Size(106, 28);
            label7.TabIndex = 2;
            label7.Text = "Kişi Sayısı";
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
            // cmbotel
            // 
            cmbotel.FormattingEnabled = true;
            cmbotel.Location = new Point(6, 33);
            cmbotel.Name = "cmbotel";
            cmbotel.Size = new Size(558, 36);
            cmbotel.TabIndex = 1;
            cmbotel.SelectedIndexChanged += cmbotel_SelectedIndexChanged;
            // 
            // cmboda
            // 
            cmboda.FormattingEnabled = true;
            cmboda.Location = new Point(170, 40);
            cmboda.Name = "cmboda";
            cmboda.Size = new Size(217, 28);
            cmboda.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.Location = new Point(0, 41);
            label8.Name = "label8";
            label8.Size = new Size(92, 28);
            label8.TabIndex = 2;
            label8.Text = "Oda Tipi";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.MistyRose;
            groupBox2.Controls.Add(cmbpaymentmethod);
            groupBox2.Controls.Add(datecikis);
            groupBox2.Controls.Add(dtpgiris);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(cmboda);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(dtpcikis);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(652, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(446, 569);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // cmbpaymentmethod
            // 
            cmbpaymentmethod.FormattingEnabled = true;
            cmbpaymentmethod.Location = new Point(248, 294);
            cmbpaymentmethod.Name = "cmbpaymentmethod";
            cmbpaymentmethod.Size = new Size(151, 28);
            cmbpaymentmethod.TabIndex = 17;
            // 
            // datecikis
            // 
            datecikis.Location = new Point(170, 154);
            datecikis.Name = "datecikis";
            datecikis.Size = new Size(217, 27);
            datecikis.TabIndex = 15;
            // 
            // dtpgiris
            // 
            dtpgiris.Location = new Point(170, 106);
            dtpgiris.Name = "dtpgiris";
            dtpgiris.Size = new Size(217, 27);
            dtpgiris.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new Point(170, 220);
            button1.Name = "button1";
            button1.Size = new Size(217, 29);
            button1.TabIndex = 13;
            button1.Text = "Rezervasyon Oluştur";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label10.Location = new Point(6, 390);
            label10.Name = "label10";
            label10.Size = new Size(156, 28);
            label10.TabIndex = 2;
            label10.Text = "Toplam Miktar:";
            // 
            // dtpcikis
            // 
            dtpcikis.AutoSize = true;
            dtpcikis.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dtpcikis.Location = new Point(6, 290);
            dtpcikis.Name = "dtpcikis";
            dtpcikis.Size = new Size(121, 28);
            dtpcikis.TabIndex = 2;
            dtpcikis.Text = "Ödeme Tipi";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label11.Location = new Point(0, 103);
            label11.Name = "label11";
            label11.Size = new Size(114, 28);
            label11.TabIndex = 2;
            label11.Text = "Giriş Tarihi";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label9.Location = new Point(0, 88);
            label9.Name = "label9";
            label9.Size = new Size(0, 28);
            label9.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label12.Location = new Point(6, 153);
            label12.Name = "label12";
            label12.Size = new Size(115, 28);
            label12.TabIndex = 2;
            label12.Text = "Çıkış Tarihi";
            label12.Click += label12_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 735);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private GroupBox groupBox2;
        private Button button1;
        private Label label10;
        private Label label9;
        private DateTimePicker datecikis;
        private DateTimePicker dtpgiris;
        private Label dtpcikis;
        private Label label11;
        private CheckBox checkBox1;
        private ComboBox cmbpaymentmethod;
        private Label label12;
    }
}
