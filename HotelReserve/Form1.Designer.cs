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
            numericUpDown1 = new NumericUpDown();
            label14 = new Label();
            txttotalfiyat = new TextBox();
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
            dgvbookings = new DataGridView();
            listboxMüşteri = new ListBox();
            txtsearchbooking = new TextBox();
            grpReserve = new GroupBox();
            btn_sil = new Button();
            btn_guncelle = new Button();
            label13 = new Label();
            grpguests = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            grpRezervasyon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvbookings).BeginInit();
            grpReserve.SuspendLayout();
            grpguests.SuspendLayout();
            SuspendLayout();
            // 
            // grpRezervasyon
            // 
            grpRezervasyon.BackColor = Color.MistyRose;
            grpRezervasyon.Controls.Add(numericUpDown1);
            grpRezervasyon.Controls.Add(label14);
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
            grpRezervasyon.Location = new Point(29, 4);
            grpRezervasyon.Margin = new Padding(4, 3, 4, 3);
            grpRezervasyon.Name = "grpRezervasyon";
            grpRezervasyon.Padding = new Padding(4, 3, 4, 3);
            grpRezervasyon.Size = new Size(601, 597);
            grpRezervasyon.TabIndex = 0;
            grpRezervasyon.TabStop = false;
            grpRezervasyon.Text = "Rezervasyon Formu";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(391, 369);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 29);
            numericUpDown1.TabIndex = 24;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(24, 371);
            label14.Name = "label14";
            label14.Size = new Size(111, 21);
            label14.TabIndex = 23;
            label14.Text = "Misafir Sayısı";
            // 
            // txttotalfiyat
            // 
            txttotalfiyat.Location = new Point(176, 472);
            txttotalfiyat.Margin = new Padding(4, 3, 4, 3);
            txttotalfiyat.Name = "txttotalfiyat";
            txttotalfiyat.Size = new Size(365, 29);
            txttotalfiyat.TabIndex = 22;
            // 
            // lstoda
            // 
            lstoda.FormattingEnabled = true;
            lstoda.ItemHeight = 21;
            lstoda.Location = new Point(176, 238);
            lstoda.Margin = new Padding(4, 5, 4, 5);
            lstoda.Name = "lstoda";
            lstoda.Size = new Size(365, 109);
            lstoda.TabIndex = 21;
            lstoda.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(24, 238);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(111, 20);
            label7.TabIndex = 20;
            label7.Text = "Mevcut Odalar";
            // 
            // dateTimePickerCheckout
            // 
            dateTimePickerCheckout.Location = new Point(176, 192);
            dateTimePickerCheckout.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerCheckout.Name = "dateTimePickerCheckout";
            dateTimePickerCheckout.Size = new Size(365, 29);
            dateTimePickerCheckout.TabIndex = 18;
            // 
            // btnbooking
            // 
            btnbooking.Location = new Point(176, 533);
            btnbooking.Margin = new Padding(4, 3, 4, 3);
            btnbooking.Name = "btnbooking";
            btnbooking.Size = new Size(366, 56);
            btnbooking.TabIndex = 13;
            btnbooking.Text = "Rezervasyon Oluştur";
            btnbooking.UseVisualStyleBackColor = true;
            btnbooking.Click += btnbooking_Click;
            // 
            // cmbpaymentmethod
            // 
            cmbpaymentmethod.FormattingEnabled = true;
            cmbpaymentmethod.Location = new Point(176, 430);
            cmbpaymentmethod.Margin = new Padding(4, 3, 4, 3);
            cmbpaymentmethod.Name = "cmbpaymentmethod";
            cmbpaymentmethod.Size = new Size(365, 29);
            cmbpaymentmethod.TabIndex = 17;
            cmbpaymentmethod.SelectedIndexChanged += cmbpaymentmethod_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label12.Location = new Point(24, 198);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(84, 20);
            label12.TabIndex = 16;
            label12.Text = "Çıkış Tarihi";
            // 
            // dtpgiris
            // 
            dtpgiris.Location = new Point(176, 141);
            dtpgiris.Margin = new Padding(4, 3, 4, 3);
            dtpgiris.Name = "dtpgiris";
            dtpgiris.Size = new Size(365, 29);
            dtpgiris.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label10.Location = new Point(24, 478);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(126, 21);
            label10.TabIndex = 2;
            label10.Text = "Toplam Miktar:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label11.Location = new Point(24, 147);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(91, 21);
            label11.TabIndex = 2;
            label11.Text = "Giriş Tarihi";
            // 
            // cmboda
            // 
            cmboda.FormattingEnabled = true;
            cmboda.Location = new Point(176, 95);
            cmboda.Margin = new Padding(4, 3, 4, 3);
            cmboda.Name = "cmboda";
            cmboda.Size = new Size(365, 29);
            cmboda.TabIndex = 11;
            cmboda.SelectedIndexChanged += cmboda_SelectedIndexChanged;
            // 
            // cmbotel
            // 
            cmbotel.FormattingEnabled = true;
            cmbotel.Location = new Point(8, 38);
            cmbotel.Margin = new Padding(4, 3, 4, 3);
            cmbotel.Name = "cmbotel";
            cmbotel.Size = new Size(533, 29);
            cmbotel.TabIndex = 1;
            cmbotel.SelectedIndexChanged += cmbotel_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.Location = new Point(24, 101);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(74, 21);
            label8.TabIndex = 2;
            label8.Text = "Oda Tipi";
            // 
            // dtpcikis
            // 
            dtpcikis.AutoSize = true;
            dtpcikis.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dtpcikis.Location = new Point(17, 441);
            dtpcikis.Margin = new Padding(4, 0, 4, 0);
            dtpcikis.Name = "dtpcikis";
            dtpcikis.Size = new Size(98, 21);
            dtpcikis.TabIndex = 2;
            dtpcikis.Text = "Ödeme Tipi";
            // 
            // dtpdogumtarihi
            // 
            dtpdogumtarihi.Location = new Point(240, 439);
            dtpdogumtarihi.Margin = new Padding(4, 3, 4, 3);
            dtpdogumtarihi.Name = "dtpdogumtarihi";
            dtpdogumtarihi.Size = new Size(365, 27);
            dtpdogumtarihi.TabIndex = 11;
            // 
            // txttel
            // 
            txttel.Location = new Point(240, 355);
            txttel.Margin = new Padding(4, 3, 4, 3);
            txttel.Name = "txttel";
            txttel.Size = new Size(365, 27);
            txttel.TabIndex = 9;
            // 
            // txtmail
            // 
            txtmail.Location = new Point(240, 286);
            txtmail.Margin = new Padding(4, 3, 4, 3);
            txtmail.Name = "txtmail";
            txtmail.Size = new Size(365, 27);
            txtmail.TabIndex = 8;
            // 
            // txtadres
            // 
            txtadres.Location = new Point(240, 231);
            txtadres.Margin = new Padding(4, 3, 4, 3);
            txtadres.Name = "txtadres";
            txtadres.Size = new Size(365, 27);
            txtadres.TabIndex = 7;
            // 
            // txtsoyad
            // 
            txtsoyad.Location = new Point(240, 170);
            txtsoyad.Margin = new Padding(4, 3, 4, 3);
            txtsoyad.Name = "txtsoyad";
            txtsoyad.Size = new Size(365, 27);
            txtsoyad.TabIndex = 6;
            // 
            // txtad
            // 
            txtad.Location = new Point(240, 98);
            txtad.Margin = new Padding(4, 3, 4, 3);
            txtad.Name = "txtad";
            txtad.Size = new Size(365, 27);
            txtad.TabIndex = 5;
            // btnguests
            // 
            btnguests.BackColor = Color.Gainsboro;
            btnguests.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnguests.Location = new Point(240, 519);
            btnguests.Margin = new Padding(4, 3, 4, 3);
            btnguests.Name = "btnguests";
            btnguests.Size = new Size(366, 56);
            btnguests.TabIndex = 4;
            btnguests.Text = "Misafir Bilgilerini Kaydet";
            btnguests.UseVisualStyleBackColor = false;
            btnguests.Click += btnguests_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(1, 443);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 2;
            label1.Text = "Doğum Tarihi";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(11, 359);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(67, 21);
            label6.TabIndex = 2;
            label6.Text = "Telefon";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(8, 290);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 21);
            label5.TabIndex = 2;
            label5.Text = "E-Posta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(11, 231);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 21);
            label4.TabIndex = 2;
            label4.Text = "Adres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(8, 174);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 21);
            label3.TabIndex = 2;
            label3.Text = "Soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(20, 101);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 21);
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
            groupBox2.Location = new Point(638, 4);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(631, 597);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Misafir Formu";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label9.Location = new Point(0, 101);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(0, 21);
            label9.TabIndex = 2;
            // 
            // dgvbookings
            // 
            dgvbookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvbookings.Location = new Point(8, 107);
            dgvbookings.Margin = new Padding(4, 3, 4, 3);
            dgvbookings.Name = "dgvbookings";
            dgvbookings.RowHeadersWidth = 51;
            dgvbookings.Size = new Size(1224, 178);
            dgvbookings.TabIndex = 2;
            // 
            // listboxMüşteri
            // 
            listboxMüşteri.FormattingEnabled = true;
            listboxMüşteri.ItemHeight = 19;
            listboxMüşteri.Location = new Point(13, 29);
            listboxMüşteri.Margin = new Padding(4, 3, 4, 3);
            listboxMüşteri.Name = "listboxMüşteri";
            listboxMüşteri.Size = new Size(335, 460);
            listboxMüşteri.TabIndex = 3;
            listboxMüşteri.SelectedIndexChanged += listboxMüşteri_SelectedIndexChanged;
            // 
            // txtsearchbooking
            // 
            txtsearchbooking.Location = new Point(24, 69);
            txtsearchbooking.Margin = new Padding(4, 3, 4, 3);
            txtsearchbooking.Name = "txtsearchbooking";
            txtsearchbooking.Size = new Size(680, 26);
            txtsearchbooking.TabIndex = 12;
            // 
            // grpReserve
            // 
            grpReserve.BackColor = Color.MistyRose;
            grpReserve.Controls.Add(btn_sil);
            grpReserve.Controls.Add(btn_guncelle);
            grpReserve.Controls.Add(label13);
            grpReserve.Controls.Add(dgvbookings);
            grpReserve.Controls.Add(txtsearchbooking);
            grpReserve.Location = new Point(29, 599);
            grpReserve.Margin = new Padding(4, 3, 4, 3);
            grpReserve.Name = "grpReserve";
            grpReserve.Padding = new Padding(4, 3, 4, 3);
            grpReserve.Size = new Size(1240, 318);
            grpReserve.TabIndex = 13;
            grpReserve.TabStop = false;
            grpReserve.Text = "Rezervasyon Bilgileri";
            // 
            // btn_sil
            // 
            btn_sil.Location = new Point(1055, 61);
            btn_sil.Name = "btn_sil";
            btn_sil.Size = new Size(159, 37);
            btn_sil.TabIndex = 15;
            btn_sil.Text = "Sil";
            btn_sil.UseVisualStyleBackColor = true;
            // 
            // btn_guncelle
            // 
            btn_guncelle.Location = new Point(874, 61);
            btn_guncelle.Name = "btn_guncelle";
            btn_guncelle.Size = new Size(175, 37);
            btn_guncelle.TabIndex = 14;
            btn_guncelle.Text = "Güncelle";
            btn_guncelle.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label13.Location = new Point(24, 26);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(339, 19);
            label13.TabIndex = 13;
            label13.Text = "Aramak İstediğiniz Rezervasyon Bilgilerini Giriniz";
            // 
            // grpguests
            // 
            grpguests.BackColor = Color.MistyRose;
            grpguests.Controls.Add(btnDelete);
            grpguests.Controls.Add(btnUpdate);
            grpguests.Controls.Add(listboxMüşteri);
            grpguests.Location = new Point(1269, 9);
            grpguests.Name = "grpguests";
            grpguests.Size = new Size(355, 908);
            grpguests.TabIndex = 14;
            grpguests.TabStop = false;
            grpguests.Text = "Misafir Listesi";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(181, 523);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(167, 61);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(13, 523);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(162, 61);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 920);
            Controls.Add(grpguests);
            Controls.Add(grpReserve);
            Controls.Add(groupBox2);
            Controls.Add(grpRezervasyon);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpRezervasyon.ResumeLayout(false);
            grpRezervasyon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvbookings).EndInit();
            grpReserve.ResumeLayout(false);
            grpReserve.PerformLayout();
            grpguests.ResumeLayout(false);
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
        private DataGridView dgvbookings;
        private ListBox listboxMüşteri;
        private TextBox txtsearchbooking;
        private GroupBox grpReserve;
        private Label label13;
        private NumericUpDown numericUpDown1;
        private Label label14;
        private Button btn_sil;
        private Button btn_guncelle;
        private GroupBox grpguests;
        private Button btnDelete;
        private Button btnUpdate;
    }
}
