using HR.Bussiness.Services;
using HR.DataAccess.ApplicationDbContext;
using HR.DataAccess.Repostories;
using HR.Entities.Models;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelReserve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var _context = new Context();
            var hRepostory = new HotelRepostory(_context);
            var rTypeRepostory = new RoomTypeRepostory(_context);
            var bRepostory = new BookingRepostory(_context);
            var guestRepo = new GuestRepostory(_context);
            var paymentRepo = new PaymentRepostory(_context);
            var guests_bookingRepo = new Guests_BookingRepostory(_context);
            var roomRepo = new RoomRepostory(_context);
            rService = new RoomService(roomRepo);
            guests_BookingService = new Guests_BookingService(guests_bookingRepo);
            paymentService = new PaymentService(paymentRepo);
            guestService = new GuestService(guestRepo);
            _bService = new BookingService(bRepostory);
            hService = new HotelService(hRepostory);
            roomTypeService = new RoomTypeService(rTypeRepostory);
            
        }
        private readonly HotelService hService;
        private readonly RoomTypeService roomTypeService;
        private readonly BookingService _bService;
        private readonly GuestService guestService;
        private readonly PaymentService paymentService;
        private readonly Guests_BookingService guests_BookingService;
        private readonly RoomService rService;



        private void Form1_Load(object sender, EventArgs e)
        {
            //Form a��l�nca y�klenecek veriler methodlar ile �a��r�ld�.
          
            GetAllHotel();
            GetAllRoomType();
            GetAllPaymentMethods();

            //Dgw otomatik se�ti�i i�in y�klendi�inde g�z�kmemesi daha temiz oluyor.
           GetAllBookings();

        }

        //Se�ilen otelde oda olmamas� halinde oda t�retmek i�in method olu�turuldu.
        private void AddRoom()
        {
            MessageBox.Show("Add room �al��t�");

            foreach (var roomType in roomTypeService.GetAll())
            {
                if (roomType.Rooms == null || !roomType.Rooms.Any(r => r.HotelID == selectedHotel.Id))
                {


                    for (int i = 1; i <= 4; i++)
                    {
                        Room newRoom = new Room
                        {
                            RoomTypeID = roomType.Id,
                            RoomType = roomType,
                            HotelID = selectedHotel.Id,
                            Hotel = selectedHotel,
                            IsEmpty = true,
                            CreatedDate = DateTime.Now,
                            RoomNumber = i
                        };


                        rService.Add(newRoom);
                        roomType.Rooms.Add(newRoom);

                    }
                }
            }
        }
        //T�m oda tiplerini getiren metod
        private void GetAllRoomType()
        {
            foreach (var item in roomTypeService.GetAll())
            {
                cmboda.Items.Add(item);
            }
        }
        //T�m otelleri getiren metod
        private void GetAllHotel()
        {
            foreach (var item in hService.GetAll())
            {
                cmbotel.Items.Add(item);
            }
        }
        //Paymentmethodlar� getiren metod
        private void GetAllPaymentMethods()
        {
            //payment metodlar enum kullan�larak olu�turuldu.
            var methods = Enum.GetValues(typeof(PaymentMethods));
            foreach (var item in methods)
            {
                cmbpaymentmethod.Items.Add(item);
            }
        }


        Hotel selectedHotel;
        private void cmbotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedHotel = (Hotel)cmbotel.SelectedItem;
            //Otel se�ildi�inde se�ilen odaya ait oda bilgisi olup olmad��� kontrol edildi olmamas� halinde yeni odalar �retildi.
            var existingRooms = rService.GetAll().Where(r => r.HotelID == selectedHotel.Id);
            if (!existingRooms.Any())
            {
                AddRoom();
            }


        }


        //Form temizleme metodu eklendi. REzervasyon olu�turunca formu temizle dedi�imde combobox se�imlerinde sorun oluyor. Ayr�ca datagridview bookingi otomatik se�ti�i i�in de form temiz kalmayabiliyor.
        private void ClearForm(GroupBox grp)
        {
            foreach (var item in grp.Controls)
            {
                switch (item)
                {
                    case TextBox t:
                        t.Text = string.Empty;
                        break;
                    case DateTimePicker dtp:
                        dtp.Value = DateTime.Now;
                        break;
                    //case ComboBox combobox:
                    //    combobox.SelectedIndex = -1;
                    //    break;
                    case NumericUpDown numericUpDown:
                        numericUpDown.Value = 0;
                        break;
                    case ListBox lst:
                        lst.SelectedIndex = -1;
                        break;
                }
            }
            if (grp == grpRezervasyon)
            {
                cmboda.SelectedIndex = 0;
                cmbpaymentmethod.SelectedIndex = 0;
                cmbotel.SelectedIndex =0;
            }
        }
       

        // paymentmetod se�imi
        PaymentMethods selectedPaymentMethod;
        private void cmbpaymentmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPaymentMethod = (PaymentMethods)cmbpaymentmethod.SelectedItem;
        }

        //Rezerve edilecek oda se�imi
        Room selectedRoom;
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRoom = (Room)lstoda.SelectedItem;
            txttotalfiyat.Text = (selectedRoomType.PricePerNight * ((dateTimePickerCheckout.Value - dtpgiris.Value).Days)).ToString();
        }

        //Oda tipi se�imi
        RoomType selectedRoomType;
        private void cmboda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedRoomType = (RoomType)cmboda.SelectedItem;

                GetAllRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Se�ilen otel ve oda tipinde bos olan odalar� listeleme
        private void GetAllRooms()
        {
            lstoda.Items.Clear();
           foreach (var item in rService.GetAll()
                .Where(r => r.RoomTypeID == selectedRoomType.Id)
                .Where(r => r.HotelID == selectedHotel.Id))
            {
                if (item.IsEmpty == true)
                {
                    lstoda.Items.Add(item);
                }

            }
        }

        //Rezervayon olu�turmak i�in tan�mlamalar yap�ld�.
        Booking b;
        decimal guestNumr;
        //tan�mlanan bookinge guests_booking tablosu ba�lanaca�� i�in buraya al�nd�.
        private void btnbooking_Click(object sender, EventArgs e)
        {
            try
            {
                //oda tipi kapasitesi kadar misafir say�s� belirlendi.
                if (nmrguestsCount.Value > selectedRoomType.Capacity)
                {
                    throw new Exception("L�tfen oda kapasitesi kadar misafir ekleyiniz");
                  
                  }
                guestNumr = nmrguestsCount.Value;

                b = new Booking()
                {
                    CheckInDate = dtpgiris.Value,
                    ChechOutDate = dateTimePickerCheckout.Value,
                    CreatedDate = DateTime.Now,
                    TotalPrice = selectedRoomType.PricePerNight * ((((dateTimePickerCheckout.Value).Day+1) - dtpgiris.Value.Day)),
                    Room = selectedRoom,
                    RoomID = selectedRoom.Id,
                };
                // bir bookinge birden fazla misafir eklenebilece�i gibi bir misafirin birden fazla bookingi olabilir. O y�zden bir bookingte misafir say�s� kadar ara tablo olu�turulmas� gerekmektedir. Olu�turulacak ara tablo say�s�n� tutmak i�in guestNumr tan�mland�.
                
                //Se�ilen oda se�ilen tarihlerde m�sait mi de�il mi kontrol etmek i�in metod tan�mland�.
                ControlsAvailableRoom(b.RoomID, b.ChechOutDate, b.CheckInDate);
                _bService.Add(b);
                guestCount = 0;
                MessageBox.Show("Rezervasyon olu�turuldu.");
                //olu�turulan bookinge paymenti olu�turuldu.
                Payment p = new Payment()
                {
                    Booking = b,
                    BookingID = b.Id,
                    Amount = b.TotalPrice,
                    PaymentMethod = selectedPaymentMethod,
                    PaymentDate = DateTime.Now,

                };
                paymentService.Add(p);
                //t�m bilgiler kaydedilince rezervasyonlar listelendi.
                GetAllBookings();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        //se�ilen odan�n m�saitli�i ile ilgili kod
        private void ControlsAvailableRoom(Guid roomID, DateTime chechOutDate, DateTime checkInDate)
        {
            //se�ilen odan�n idsindeki t�m rbookingler listeleniyor.
            var getAllbookingsRoom = from b in _bService.GetAll()
                                     where b.RoomID == roomID
                                     select b;
            //yukar�daki liste ile girilen tarihler aras�nda �ak��an bookingler varsa listeleniyor.
            var overlappingBookings = getAllbookingsRoom.Where(b =>
                                  (checkInDate < b.ChechOutDate && chechOutDate > b.CheckInDate)).ToList();

            //�ak��an booking varsa hata veriliyor yoksa ve tablo temizleniyor.
            if (overlappingBookings.Any())
            {
                throw new Exception("Bu tarihler aras�nda m�sait oda bulunmamaktad�r.");
            }
            if (overlappingBookings.Any())
            {
                ClearForm(grpRezervasyon);
            }


        }
        //yukar�da tan�mlanan ve formda belirlenen misafir say�s�na (guestNmr) ula�mak i�in ve ula��ld���nda art�k yeni misafir kaydedilmemesi i�in count tan�mland�.
        int guestCount = 0;
        private void btnguests_Click(object sender, EventArgs e)
        {
            try
            {
                if (guestCount == guestNumr) {
                    ClearForm(grpRezervasyon);
                    ClearForm(grpguestsFormu);
                }
                //Rezervasyon formunda belirlenen misafir say�s�ndan fazla misafir eklenmesi �nlendi.
                if (guestCount == guestNumr)
                {
                    throw new Exception("Rezerve say�s�ndan fazla misafir eklenemez.");
                    
                }
               

                Guest g = new Guest()
                {
                    IdentityNumber = txttc.Text,
                    FirstName = txtad.Text,
                    LastName = txtsoyad.Text,
                    Address = txtadres.Text,
                    Email = txtmail.Text,
                    Phone = txttel.Text,
                    DateOfBirth = dtpdogumtarihi.Value
                };
                //olu�turulan guest veritaban�nda varsa yenisi olu�turulmas�n ama ara tablo olu�turulsun istedi�imiz i�in �nce eklenen guest veritaban�nda var m� yok mu sorguland�.

                var existingGuest = guestService.GetAll().FirstOrDefault(x => x.IdentityNumber == txttc.Text);

                if (existingGuest != null)
                {
                    // E�er ayn� isim ve soyisimde misafir varsa, ara tablo olu�turuyoruz ve guestCount� art�r�yoruz.
                    Guests_Booking gb = new Guests_Booking()
                    {
                        Booking = b,
                        BookingID = b.Id,
                        Guest = existingGuest,
                        GuestID = existingGuest.Id
                    };
                    guests_BookingService.Add(gb);
                    guestCount++;

                }
                else
                {
                    //olu�turulan misafir dbde yoksa hem yeni guest olu�turuyoruz hem de ara tablo olu�tuuryoruz.
                    guestService.Add(g);
                    MessageBox.Show("Misafir bilgisi kaydedildi.");
                    Guests_Booking gb = new Guests_Booking()
                    {
                        Booking = b,
                        BookingID = b.Id,
                        Guest = g,
                        GuestID = g.Id
                    };
                    guests_BookingService.Add(gb);
                    guestCount++;
                }
               
                //Misafir tablosunu temizliyoruz.
                ClearForm(grpguestsFormu);
                if (guestCount == guestNumr)
                {
                    ClearForm(grpRezervasyon);
                    ClearForm(grpguestsFormu);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void GetAllBookings()
        {
            dgvbookings.DataSource = null;
            var filteredbooking = from b in _bService.GetAll()
                                  join r in rService.GetAll() on b.RoomID equals r.Id
                                  select new { b.Id, b.TotalPrice, b.CheckInDate, b.ChechOutDate, b.CreatedDate,r.RoomNumber,b.RoomID};
            dgvbookings.DataSource = filteredbooking.ToList(); 
            //se�ili �zelli�i katamaya �al��t�m olmad�
            dgvbookings.ClearSelection();

        }
        // dgvdeki booking se�ildi�inde bilgileri forma geri yazd�r�l�yor g�ncelleme i�in.
        private void dgvbookings_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = ((DataGridView)sender).Rows[e.RowIndex];
                secilenID = (Guid)selectedRow.Cells["Id"].Value;
                selectedBooking = _bService.GetByID(secilenID);
               // Bu bookinge kay�tl� misafirler de guest listesine yazd�r�l�yor.
                GetAllBookingGuests(selectedBooking, secilenID);

                dateTimePickerCheckout.Value = selectedBooking.ChechOutDate;
                dtpgiris.Value = selectedBooking.CheckInDate;
                lstoda.SelectedItem = selectedBooking.Room;
                nmrguestsCount.Value = guests_BookingService.GetAll().Where(gb => gb.BookingID == secilenID).Count();
                cmbpaymentmethod.SelectedItem = paymentService.GetAll().Where(p => p.BookingID == secilenID);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //se�ilen bookingde kay�tl� misafirleri misafir listesine getiren metod
        private void GetAllBookingGuests(Booking selectedBooking, Guid secilenID)
        {
            if (selectedBooking != null)
            {
                var selectedGuests_Booking = from gb in guests_BookingService.GetAll()
                                             where gb.BookingID == secilenID
                                             join g in guestService.GetAll() on gb.GuestID equals g.Id
                                             select g;
                listboxM��teri.Items.Clear();
                foreach (var item in selectedGuests_Booking)
                {
                    listboxM��teri.Items.Add(item);
                }
            }
        }
        //se�ilen bookingte g�ncelleme
        private void btn_booking_update_Click(object sender, EventArgs e)
        {
            try
            {
                selectedBooking.CheckInDate = dtpgiris.Value;
                selectedBooking.ChechOutDate = dateTimePickerCheckout.Value;
               //  selectedBooking.Room.RoomType = selectedRoomType;
                _bService.Update(selectedBooking);
                MessageBox.Show("G�ncelleme i�lem ger�ekle�ti");
                GetAllBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Booking selectedBooking;
        Guid secilenID;

        //se�ilen booking silme metodu
        private void btn_booking_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBooking != null)
                {
                    _bService.Delete(selectedBooking);
                    MessageBox.Show("Silme i�lemi ger�ekle�ti.");
                    GetAllBookings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //listelenen bookinglerde tarih aral���na g�re arama yapmaktadir.
        private void btnarama_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime searchedInTime = dtpsearchgiris.Value;
                DateTime searchedOutTime = dtpsearchcikis.Value.AddDays(1);
                var filteredList = from b in _bService.GetAll()
                                   where b.CheckInDate >= searchedInTime.Date && b.ChechOutDate <= searchedOutTime.Date
                                   select b;
                //var data = from b in _bService.GetAll()
                //           select b;
               
                if (filteredList.Any())
                {
                    MessageBox.Show("buraday�z if");

                    dgvbookings.DataSource = null;
                    dgvbookings.DataSource = filteredList.ToList();
                }
                else
                {
                    MessageBox.Show("buraday�z else");
                    GetAllBookings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Guest listesinden misafir se�ilince bilgiler forma dolduruluyor.
        private void listboxM��teri_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCustomer = (Guest)listboxM��teri.SelectedItem;
            if (selectedCustomer != null)
            {
                txttc.Text = selectedCustomer.IdentityNumber;
                txtad.Text = selectedCustomer.FirstName;
                txtsoyad.Text = selectedCustomer.LastName;
                txtmail.Text = selectedCustomer.Email;
                txtadres.Text = selectedCustomer.Address;
                txttel.Text = selectedCustomer.Phone;
                dtpdogumtarihi.Value = selectedCustomer.DateOfBirth;
            }
        }
        //se�ilen misafir g�ncelleme metodu
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCustomer = (Guest)listboxM��teri.SelectedItem;
                if (selectedCustomer != null)
                {
                    selectedCustomer.IdentityNumber = txttc.Text;
                    selectedCustomer.FirstName = txtad.Text;
                    selectedCustomer.LastName = txtsoyad.Text;
                    selectedCustomer.Address = txtadres.Text;
                    selectedCustomer.DateOfBirth = dtpdogumtarihi.Value;
                    selectedCustomer.Email = txtmail.Text;
                    guestService.Update(selectedCustomer);
                    MessageBox.Show("Se�ilen Misafir bilgileri g�ncellendi.");
                    ClearForm(grpguestsFormu);

                   GetAllBookingGuests(selectedBooking,secilenID);
                }
                else
                {
                    MessageBox.Show("L�tfen g�ncellemek i�in bir m��teri se�in.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

        }
        //se�ilen misafir silme metodu
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCustomer = (Guest)listboxM��teri.SelectedItem;
                if (selectedCustomer != null)
                {
                    guestService.Delete(selectedCustomer);
                    MessageBox.Show("Silme i�lemi ger�ekle�tirildi.");
                    GetAllBookingGuests(selectedBooking, secilenID);
                    ClearForm(grpguestsFormu);
                   
                }
                else
                {
                    MessageBox.Show("L�tfen silmek i�in bir m��teri se�in.");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
       
        ///De�i�iklik yap�ld�.
    }
}
