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
        private Random random = new Random();
        private HashSet<int> previousNumbers = new HashSet<int>();



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
            //LoadCustomers();


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

        private void GetAllRoomType()
        {
            foreach (var item in roomTypeService.GetAll())
            {
                cmboda.Items.Add(item);
            }
        }

        private void GetAllHotel()
        {
            foreach (var item in hService.GetAll())
            {
                cmbotel.Items.Add(item);
            }
        }

        private void GetAllPaymentMethods()
        {
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


        //Form temizleme metodu eklendi.
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
                    case ComboBox combobox:
                        combobox.SelectedIndex = -1;
                        break;
                    case NumericUpDown numericUpDown:
                        numericUpDown.Value = 0;
                        break;
                }
            }
            //cmboda.SelectedIndex = -1;
            //cmbotel.SelectedIndex = -1;
            //cmbpaymentmethod.SelectedIndex = -1;

        }
        Booking b;




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

            foreach (var item in rService.GetAll().Where(r => r.RoomTypeID == selectedRoomType.Id).Where(r => r.HotelID == selectedHotel.Id))
            {
                if (item.IsEmpty == true)
                {
                    lstoda.Items.Add(item);
                }

            }
        }

        //misafir ve rezervasyon aras�nda ara tablo olu�turmak i�in ve eklenecek misafir say�s�n� tutmak i�in liste olu�turuldu.

        int guestCount = 0;
        private void btnguests_Click(object sender, EventArgs e)
        {
            try
            {
                if (guestCount == nmrguestsCount.Value)
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

                var existingGuest = guestService.GetAll().FirstOrDefault(x => x.IdentityNumber == txttc.Text);

                if (existingGuest != null)
                {
                    // E�er ayn� isim ve soyisimde misafir varsa, bir uyar� mesaj� f�rlat�yoruz
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
                //Girilen misafir say�s� kadar misafir eklemek gerekmektedir.


                ClearForm(grpguestsFormu);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnbooking_Click(object sender, EventArgs e)
        {
            try
            {

                //    int days = (dateTimePickerCheckout.Value - dtpgiris.Value).Days;
                //    decimal totalPrice = selectedRoomType.PricePerNight * days;

                //    MessageBox.Show($"G�n Say�s�: {days}, Toplam Fiyat: {totalPrice}");
                b = new Booking()
                {
                    CheckInDate = dtpgiris.Value,
                    ChechOutDate = dateTimePickerCheckout.Value,
                    CreatedDate = DateTime.Now,
                    TotalPrice = selectedRoomType.PricePerNight * ((dateTimePickerCheckout.Value - dtpgiris.Value).Days),
                    Room = selectedRoom,
                    RoomID = selectedRoom.Id,
                };

                _bService.Add(b);
                guestCount = 0;
                MessageBox.Show("Rezervasyon olu�turuldu.");

                Payment p = new Payment()
                {
                    Booking = b,
                    BookingID = b.Id,
                    Amount = b.TotalPrice,
                    PaymentMethod = selectedPaymentMethod,
                    PaymentDate = DateTime.Now,

                };
                paymentService.Add(p);

                GetAllBookings();
                //   ClearForm(grpRezervasyonFormu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }
        private void GetAllBookings()
        {
            dgvbookings.DataSource = null;
            dgvbookings.DataSource = _bService.GetAll();

        }

        //private void LoadCustomers()
        //{
        //    listboxM��teri.Items.Clear();
        //    var customers = guestService.GetAll();
        //    foreach (var customer in customers)
        //    {
        //        listboxM��teri.Items.Add(customer);
        //    }
        //}
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

        private void btnUpdate_Click(object sender, EventArgs e)
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

                //LoadCustomers();
            }
            else
            {
                MessageBox.Show("L�tfen g�ncellemek i�in bir m��teri se�in.");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedCustomer = (Guest)listboxM��teri.SelectedItem;
            if (selectedCustomer != null)
            {
                guestService.Delete(selectedCustomer);
                MessageBox.Show("Silme i�lemi ger�ekle�tirildi.");
                //LoadCustomers();
            }
            else
            {
                MessageBox.Show("L�tfen silmek i�in bir m��teri se�in.");
            }
        }

        private void btn_booking_update_Click(object sender, EventArgs e)
        {
            selectedBooking.CheckInDate = dtpgiris.Value;
            selectedBooking.ChechOutDate = dateTimePickerCheckout.Value;
            //selectedBooking.Room.RoomType=cmboda.SelectedItem,
            _bService.Update(selectedBooking);
        }
        Booking selectedBooking;

        private void dgvbookings_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = ((DataGridView)sender).Rows[e.RowIndex];
            var secilenID = (Guid)selectedRow.Cells["Id"].Value;
            selectedBooking = _bService.GetByID(secilenID);
            if (selectedBooking != null)
            {
                var selectedGuests_Booking = from gb in guests_BookingService.GetAll()
                                             where gb.BookingID == secilenID
                                             join g in guestService.GetAll() on gb.GuestID equals g.Id
                                             select g;
                foreach (var item in selectedGuests_Booking)
                {
                    listboxM��teri.Items.Add(item);
                }
            }

            //cmboda.SelectedItem = selectedBooking.Room.RoomType.Name;
            GetAllRoomType();

            dateTimePickerCheckout.Value = selectedBooking.ChechOutDate;
            dtpgiris.Value = selectedBooking.CheckInDate;
            lstoda.SelectedItem = selectedBooking.Room;
            nmrguestsCount.Value = guests_BookingService.GetAll().Where(gb => gb.BookingID == secilenID).Count();
            cmbpaymentmethod.SelectedItem = paymentService.GetAll().Where(p => p.BookingID == secilenID);


        }

        private void btn_booking_delete_Click(object sender, EventArgs e)
        {
            if (selectedBooking != null)
            {
                _bService.Delete(selectedBooking);
            }
        }

        private void txtsearchbooking_TextChanged(object sender, EventArgs e)
        {
            
        }

        ///De�i�iklik yap�ld�.
    }
}
