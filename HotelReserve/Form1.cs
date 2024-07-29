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
            //Form açýlýnca yüklenecek veriler methodlar ile çaðýrýldý.
          
            GetAllHotel();
            GetAllRoomType();
            GetAllPaymentMethods();

            //Dgw otomatik seçtiði için yüklendiðinde gözükmemesi daha temiz oluyor.
           GetAllBookings();

        }

        //Seçilen otelde oda olmamasý halinde oda türetmek için method oluþturuldu.
        private void AddRoom()
        {
            MessageBox.Show("Add room çalýþtý");

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
        //Tüm oda tiplerini getiren metod
        private void GetAllRoomType()
        {
            foreach (var item in roomTypeService.GetAll())
            {
                cmboda.Items.Add(item);
            }
        }
        //Tüm otelleri getiren metod
        private void GetAllHotel()
        {
            foreach (var item in hService.GetAll())
            {
                cmbotel.Items.Add(item);
            }
        }
        //Paymentmethodlarý getiren metod
        private void GetAllPaymentMethods()
        {
            //payment metodlar enum kullanýlarak oluþturuldu.
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
            //Otel seçildiðinde seçilen odaya ait oda bilgisi olup olmadýðý kontrol edildi olmamasý halinde yeni odalar üretildi.
            var existingRooms = rService.GetAll().Where(r => r.HotelID == selectedHotel.Id);
            if (!existingRooms.Any())
            {
                AddRoom();
            }


        }


        //Form temizleme metodu eklendi. REzervasyon oluþturunca formu temizle dediðimde combobox seçimlerinde sorun oluyor. Ayrýca datagridview bookingi otomatik seçtiði için de form temiz kalmayabiliyor.
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
       

        // paymentmetod seçimi
        PaymentMethods selectedPaymentMethod;
        private void cmbpaymentmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPaymentMethod = (PaymentMethods)cmbpaymentmethod.SelectedItem;
        }

        //Rezerve edilecek oda seçimi
        Room selectedRoom;
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRoom = (Room)lstoda.SelectedItem;
            txttotalfiyat.Text = (selectedRoomType.PricePerNight * ((dateTimePickerCheckout.Value - dtpgiris.Value).Days)).ToString();
        }

        //Oda tipi seçimi
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
        //Seçilen otel ve oda tipinde bos olan odalarý listeleme
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

        //Rezervayon oluþturmak için tanýmlamalar yapýldý.
        Booking b;
        decimal guestNumr;
        //tanýmlanan bookinge guests_booking tablosu baðlanacaðý için buraya alýndý.
        private void btnbooking_Click(object sender, EventArgs e)
        {
            try
            {
                //oda tipi kapasitesi kadar misafir sayýsý belirlendi.
                if (nmrguestsCount.Value > selectedRoomType.Capacity)
                {
                    throw new Exception("Lütfen oda kapasitesi kadar misafir ekleyiniz");
                  
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
                // bir bookinge birden fazla misafir eklenebileceði gibi bir misafirin birden fazla bookingi olabilir. O yüzden bir bookingte misafir sayýsý kadar ara tablo oluþturulmasý gerekmektedir. Oluþturulacak ara tablo sayýsýný tutmak için guestNumr tanýmlandý.
                
                //Seçilen oda seçilen tarihlerde müsait mi deðil mi kontrol etmek için metod tanýmlandý.
                ControlsAvailableRoom(b.RoomID, b.ChechOutDate, b.CheckInDate);
                _bService.Add(b);
                guestCount = 0;
                MessageBox.Show("Rezervasyon oluþturuldu.");
                //oluþturulan bookinge paymenti oluþturuldu.
                Payment p = new Payment()
                {
                    Booking = b,
                    BookingID = b.Id,
                    Amount = b.TotalPrice,
                    PaymentMethod = selectedPaymentMethod,
                    PaymentDate = DateTime.Now,

                };
                paymentService.Add(p);
                //tüm bilgiler kaydedilince rezervasyonlar listelendi.
                GetAllBookings();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        //seçilen odanýn müsaitliði ile ilgili kod
        private void ControlsAvailableRoom(Guid roomID, DateTime chechOutDate, DateTime checkInDate)
        {
            //seçilen odanýn idsindeki tüm rbookingler listeleniyor.
            var getAllbookingsRoom = from b in _bService.GetAll()
                                     where b.RoomID == roomID
                                     select b;
            //yukarýdaki liste ile girilen tarihler arasýnda çakýþan bookingler varsa listeleniyor.
            var overlappingBookings = getAllbookingsRoom.Where(b =>
                                  (checkInDate < b.ChechOutDate && chechOutDate > b.CheckInDate)).ToList();

            //çakýþan booking varsa hata veriliyor yoksa ve tablo temizleniyor.
            if (overlappingBookings.Any())
            {
                throw new Exception("Bu tarihler arasýnda müsait oda bulunmamaktadýr.");
            }
            if (overlappingBookings.Any())
            {
                ClearForm(grpRezervasyon);
            }


        }
        //yukarýda tanýmlanan ve formda belirlenen misafir sayýsýna (guestNmr) ulaþmak için ve ulaþýldýðýnda artýk yeni misafir kaydedilmemesi için count tanýmlandý.
        int guestCount = 0;
        private void btnguests_Click(object sender, EventArgs e)
        {
            try
            {
                if (guestCount == guestNumr) {
                    ClearForm(grpRezervasyon);
                    ClearForm(grpguestsFormu);
                }
                //Rezervasyon formunda belirlenen misafir sayýsýndan fazla misafir eklenmesi önlendi.
                if (guestCount == guestNumr)
                {
                    throw new Exception("Rezerve sayýsýndan fazla misafir eklenemez.");
                    
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
                //oluþturulan guest veritabanýnda varsa yenisi oluþturulmasýn ama ara tablo oluþturulsun istediðimiz için önce eklenen guest veritabanýnda var mý yok mu sorgulandý.

                var existingGuest = guestService.GetAll().FirstOrDefault(x => x.IdentityNumber == txttc.Text);

                if (existingGuest != null)
                {
                    // Eðer ayný isim ve soyisimde misafir varsa, ara tablo oluþturuyoruz ve guestCountý artýrýyoruz.
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
                    //oluþturulan misafir dbde yoksa hem yeni guest oluþturuyoruz hem de ara tablo oluþtuuryoruz.
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
            //seçili özelliði katamaya çalýþtým olmadý
            dgvbookings.ClearSelection();

        }
        // dgvdeki booking seçildiðinde bilgileri forma geri yazdýrýlýyor güncelleme için.
        private void dgvbookings_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = ((DataGridView)sender).Rows[e.RowIndex];
                secilenID = (Guid)selectedRow.Cells["Id"].Value;
                selectedBooking = _bService.GetByID(secilenID);
               // Bu bookinge kayýtlý misafirler de guest listesine yazdýrýlýyor.
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
        //seçilen bookingde kayýtlý misafirleri misafir listesine getiren metod
        private void GetAllBookingGuests(Booking selectedBooking, Guid secilenID)
        {
            if (selectedBooking != null)
            {
                var selectedGuests_Booking = from gb in guests_BookingService.GetAll()
                                             where gb.BookingID == secilenID
                                             join g in guestService.GetAll() on gb.GuestID equals g.Id
                                             select g;
                listboxMüþteri.Items.Clear();
                foreach (var item in selectedGuests_Booking)
                {
                    listboxMüþteri.Items.Add(item);
                }
            }
        }
        //seçilen bookingte güncelleme
        private void btn_booking_update_Click(object sender, EventArgs e)
        {
            try
            {
                selectedBooking.CheckInDate = dtpgiris.Value;
                selectedBooking.ChechOutDate = dateTimePickerCheckout.Value;
               //  selectedBooking.Room.RoomType = selectedRoomType;
                _bService.Update(selectedBooking);
                MessageBox.Show("Güncelleme iþlem gerçekleþti");
                GetAllBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Booking selectedBooking;
        Guid secilenID;

        //seçilen booking silme metodu
        private void btn_booking_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBooking != null)
                {
                    _bService.Delete(selectedBooking);
                    MessageBox.Show("Silme iþlemi gerçekleþti.");
                    GetAllBookings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //listelenen bookinglerde tarih aralýðýna göre arama yapmaktadir.
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
                    MessageBox.Show("buradayýz if");

                    dgvbookings.DataSource = null;
                    dgvbookings.DataSource = filteredList.ToList();
                }
                else
                {
                    MessageBox.Show("buradayýz else");
                    GetAllBookings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Guest listesinden misafir seçilince bilgiler forma dolduruluyor.
        private void listboxMüþteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCustomer = (Guest)listboxMüþteri.SelectedItem;
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
        //seçilen misafir güncelleme metodu
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCustomer = (Guest)listboxMüþteri.SelectedItem;
                if (selectedCustomer != null)
                {
                    selectedCustomer.IdentityNumber = txttc.Text;
                    selectedCustomer.FirstName = txtad.Text;
                    selectedCustomer.LastName = txtsoyad.Text;
                    selectedCustomer.Address = txtadres.Text;
                    selectedCustomer.DateOfBirth = dtpdogumtarihi.Value;
                    selectedCustomer.Email = txtmail.Text;
                    guestService.Update(selectedCustomer);
                    MessageBox.Show("Seçilen Misafir bilgileri güncellendi.");
                    ClearForm(grpguestsFormu);

                   GetAllBookingGuests(selectedBooking,secilenID);
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek için bir müþteri seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

        }
        //seçilen misafir silme metodu
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCustomer = (Guest)listboxMüþteri.SelectedItem;
                if (selectedCustomer != null)
                {
                    guestService.Delete(selectedCustomer);
                    MessageBox.Show("Silme iþlemi gerçekleþtirildi.");
                    GetAllBookingGuests(selectedBooking, secilenID);
                    ClearForm(grpguestsFormu);
                   
                }
                else
                {
                    MessageBox.Show("Lütfen silmek için bir müþteri seçin.");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
       
        ///Deðiþiklik yapýldý.
    }
}
