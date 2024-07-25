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
            grpRezervasyon = new GroupBox();
            lstoda = new ListBox();
            label7 = new Label();
            dateTimePickerCheckout = new DateTimePicker();
            btnbooking = new Button();
            cmbpaymentmethod = new ComboBox();
            label12 = new Label();
            dtpgiris = new DateTimePicker();
            label10 = new Label();
            label11 = new Label();
            cmboda = new ComboBox();
            cmbotel = new ComboBox();
            label8 = new Label();
            dtpcikis = new Label();
            dtpdogumtarihi = new DateTimePicker();
            txttel = new TextBox();
            txtmail = new TextBox();
            txtadres = new TextBox();
            txtsoyad = new TextBox();
            txtad = new TextBox();
            btnguests = new Button();
            label1 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            label9 = new Label();
            txttotalfiyat = new TextBox();
            grpRezervasyon.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpRezervasyon
            // 
            grpRezervasyon.BackColor = Color.MistyRose;
            grpRezervasyon.Controls.Add(txttotalfiyat);
            grpRezervasyon.Controls.Add(lstoda);
            grpRezervasyon.Controls.Add(label7);
            grpRezervasyon.Controls.Add(dateTimePickerCheckout);
            grpRezervasyon.Controls.Add(btnbooking);
            grpRezervasyon.Controls.Add(cmbpaymentmethod);
            grpRezervasyon.Controls.Add(label12);
            grpRezervasyon.Controls.Add(dtpgiris);
            grpRezervasyon.Controls.Add(label10);
            grpRezervasyon.Controls.Add(label11);
            grpRezervasyon.Controls.Add(cmboda);
            grpRezervasyon.Controls.Add(cmbotel);
            grpRezervasyon.Controls.Add(label8);
            grpRezervasyon.Controls.Add(dtpcikis);
            grpRezervasyon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            grpRezervasyon.Location = new Point(23, 23);
            grpRezervasyon.Name = "grpRezervasyon";
            grpRezervasyon.Size = new Size(623, 679);
            grpRezervasyon.TabIndex = 0;
            grpRezervasyon.TabStop = false;
            grpRezervasyon.Text = "Rezervasyon Formu";
            // 
            // lstoda
            // 
            lstoda.FormattingEnabled = true;
            lstoda.ItemHeight = 28;
            lstoda.Location = new Point(271, 324);
            lstoda.Margin = new Padding(3, 4, 3, 4);
            lstoda.Name = "lstoda";
            lstoda.Size = new Size(293, 116);
            lstoda.TabIndex = 21;
            lstoda.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(19, 324);
            label7.Name = "label7";
            label7.Size = new Size(138, 25);
            label7.TabIndex = 20;
            label7.Text = "Mevcut Odalar";
            // 
            // dateTimePickerCheckout
            // 
            dateTimePickerCheckout.Location = new Point(271, 252);
            dateTimePickerCheckout.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerCheckout.Name = "dateTimePickerCheckout";
            dateTimePickerCheckout.Size = new Size(293, 34);
            dateTimePickerCheckout.TabIndex = 18;
            // 
            // btnbooking
            // 
            btnbooking.Location = new Point(334, 594);
            btnbooking.Name = "btnbooking";
            btnbooking.Size = new Size(230, 64);
            btnbooking.TabIndex = 13;
            btnbooking.Text = "Rezervasyon Oluştur";
            btnbooking.UseVisualStyleBackColor = true;
            btnbooking.Click += btnbooking_Click;
            // 
            // cmbpaymentmethod
            // 
            cmbpaymentmethod.FormattingEnabled = true;
            cmbpaymentmethod.Location = new Point(271, 469);
            cmbpaymentmethod.Name = "cmbpaymentmethod";
            cmbpaymentmethod.Size = new Size(293, 36);
            cmbpaymentmethod.TabIndex = 17;
            cmbpaymentmethod.SelectedIndexChanged += cmbpaymentmethod_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label12.Location = new Point(19, 252);
            label12.Name = "label12";
            label12.Size = new Size(103, 25);
            label12.TabIndex = 16;
            label12.Text = "Çıkış Tarihi";
            // 
            // dtpgiris
            // 
            dtpgiris.Location = new Point(271, 172);
            dtpgiris.Name = "dtpgiris";
            dtpgiris.Size = new Size(293, 34);
            dtpgiris.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label10.Location = new Point(12, 540);
            label10.Name = "label10";
            label10.Size = new Size(156, 28);
            label10.TabIndex = 2;
            label10.Text = "Toplam Miktar:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label11.Location = new Point(19, 179);
            label11.Name = "label11";
            label11.Size = new Size(114, 28);
            label11.TabIndex = 2;
            label11.Text = "Giriş Tarihi";
            // 
            // cmboda
            // 
            cmboda.FormattingEnabled = true;
            cmboda.Location = new Point(271, 105);
            cmboda.Name = "cmboda";
            cmboda.Size = new Size(293, 36);
            cmboda.TabIndex = 11;
            cmboda.SelectedIndexChanged += cmboda_SelectedIndexChanged;
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
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.Location = new Point(19, 113);
            label8.Name = "label8";
            label8.Size = new Size(92, 28);
            label8.TabIndex = 2;
            label8.Text = "Oda Tipi";
            // 
            // dtpcikis
            // 
            dtpcikis.AutoSize = true;
            dtpcikis.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dtpcikis.Location = new Point(12, 472);
            dtpcikis.Name = "dtpcikis";
            dtpcikis.Size = new Size(121, 28);
            dtpcikis.TabIndex = 2;
            dtpcikis.Text = "Ödeme Tipi";
            // 
            // dtpdogumtarihi
            // 
            dtpdogumtarihi.Location = new Point(192, 382);
            dtpdogumtarihi.Name = "dtpdogumtarihi";
            dtpdogumtarihi.Size = new Size(293, 31);
            dtpdogumtarihi.TabIndex = 11;
            // 
            // txttel
            // 
            txttel.Location = new Point(192, 309);
            txttel.Name = "txttel";
            txttel.Size = new Size(293, 31);
            txttel.TabIndex = 9;
            // 
            // txtmail
            // 
            txtmail.Location = new Point(192, 249);
            txtmail.Name = "txtmail";
            txtmail.Size = new Size(293, 31);
            txtmail.TabIndex = 8;
            // 
            // txtadres
            // 
            txtadres.Location = new Point(192, 201);
            txtadres.Name = "txtadres";
            txtadres.Size = new Size(293, 31);
            txtadres.TabIndex = 7;
            // 
            // txtsoyad
            // 
            txtsoyad.Location = new Point(192, 148);
            txtsoyad.Name = "txtsoyad";
            txtsoyad.Size = new Size(293, 31);
            txtsoyad.TabIndex = 6;
            // 
            // txtad
            // 
            txtad.Location = new Point(192, 85);
            txtad.Name = "txtad";
            txtad.Size = new Size(293, 31);
            txtad.TabIndex = 5;
            // 
            // btnguests
            // 
            btnguests.BackColor = Color.Gainsboro;
            btnguests.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnguests.Location = new Point(192, 483);
            btnguests.Name = "btnguests";
            btnguests.Size = new Size(293, 56);
            btnguests.TabIndex = 4;
            btnguests.Text = "Misafir Bilgilerini Kaydet";
            btnguests.UseVisualStyleBackColor = false;
            btnguests.Click += btnguests_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(1, 385);
            label1.Name = "label1";
            label1.Size = new Size(140, 28);
            label1.TabIndex = 2;
            label1.Text = "Doğum Tarihi";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(9, 312);
            label6.Name = "label6";
            label6.Size = new Size(82, 28);
            label6.TabIndex = 2;
            label6.Text = "Telefon";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(6, 252);
            label5.Name = "label5";
            label5.Size = new Size(82, 28);
            label5.TabIndex = 2;
            label5.Text = "E-Posta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(9, 201);
            label4.Name = "label4";
            label4.Size = new Size(66, 28);
            label4.TabIndex = 2;
            label4.Text = "Adres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(6, 151);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 2;
            label3.Text = "Soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(16, 88);
            label2.Name = "label2";
            label2.Size = new Size(38, 28);
            label2.TabIndex = 2;
            label2.Text = "Ad";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.MistyRose;
            groupBox2.Controls.Add(dtpdogumtarihi);
            groupBox2.Controls.Add(txtad);
            groupBox2.Controls.Add(txtsoyad);
            groupBox2.Controls.Add(txttel);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtmail);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnguests);
            groupBox2.Controls.Add(txtadres);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox2.Location = new Point(651, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(505, 679);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Misafir Formu";
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
            // txttotalfiyat
            // 
            txttotalfiyat.Location = new Point(271, 534);
            txttotalfiyat.Name = "txttotalfiyat";
            txttotalfiyat.Size = new Size(293, 34);
            txttotalfiyat.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 735);
            Controls.Add(groupBox2);
            Controls.Add(grpRezervasyon);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpRezervasyon.ResumeLayout(false);
            grpRezervasyon.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpRezervasyon;
        private ComboBox cmbotel;
        private ComboBox cmboda;
        private TextBox txttel;
        private TextBox txtmail;
        private TextBox txtadres;
        private TextBox txtsoyad;
        private TextBox txtad;
        private Button btnguests;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpdogumtarihi;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnbooking;
        private Label label10;
        private Label label9;
        private DateTimePicker dtpgiris;
        private Label dtpcikis;
        private Label label11;
        private ComboBox cmbpaymentmethod;
        private Label label12;
        private DateTimePicker dateTimePickerCheckout;
        private Label label7;
        private ListBox lstoda;
        private TextBox txttotalfiyat;
    }
}
