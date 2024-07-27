using HR.Bussiness.Services;
using HR.DataAccess.ApplicationDbContext;
using HR.DataAccess.Repostories;
using HR.Entities.Models;
using System.Windows.Forms;

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


        }
        private readonly HotelService hService;
        private readonly RoomTypeService roomTypeService;
        private readonly BookingService _bService;
        private readonly GuestService guestService;
        private readonly PaymentService paymentService;
        private readonly Guests_BookingService guests_BookingService;
        private readonly RoomService rService;

      //  private DateTime checkoutDate;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form açýlýnca yüklenecek veriler methodlar ile çaðýrýldý.
            GetAllHotel();
            GetAllRoomType();
            GetAllPaymentMethods();

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
            //Otel seçildiðinde seçilen odaya ait oda bilgisi olup olmadýðý kontrol edildi olmamasý halinde yeni odalar üretildi.
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

        //Chechout süresi geçince IsEmptynin true olmasý için metod denendi.
        //private void ScheduleRoomAvailabilityUpdate(Room selectedRoom, DateTime chechOutDate)
        //{
        //    selectedRoom.IsEmpty = false;
        //    TimeSpan delay = checkoutDate - DateTime.Now;
        //    Task.Delay(delay).ContinueWith(_ =>
        //    {
        //        selectedRoom.IsEmpty = true;
        //        rService.Update(selectedRoom);
        //        MessageBox.Show($"{selectedRoom.RoomNumber} numaralý oda boþaldý.");
        //    });
        //}

        // paymentmetod seçimi
        PaymentMethods selectedPaymentMethod;
        private void cmbpaymentmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPaymentMethod = (PaymentMethods)cmbpaymentmethod.SelectedItem;
        }



        //private int GenerateRandomRoomNumber()
        //{
        //    int roomNumber;
        //    do
        //    {
        //        roomNumber = random.Next(1, 101);

        //    } while (IsRoomNumberUnavailable(roomNumber));
        //    return roomNumber;
        //}
        //private bool IsRoomNumberUnavailable(int roomNumber)
        //{
        //    return false;
        //}

        //private void dateTimePickerCheckout_ValueChanged(object sender, EventArgs e)
        //{
        //    checkoutDate = dateTimePickerCheckout.Value;
        //    ListBox.Items.Clear();
        //    ListBox.Visible = true;
        //    HashSet<int> numbers = new HashSet<int>();

        //    while (numbers.Count <10 )
        //    {
        //        int newNumber = random.Next(1, 101);
        //        if (!previousNumbers.Contains(newNumber))
        //        {
        //            numbers.Add(newNumber);
        //        }
        //    }

        //    previousNumbers.UnionWith(numbers);

        //    foreach (var number in numbers)
        //    {
        //        ListBox.Items.Add(number);
        //    }
        //}

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

            foreach (var item in rService.GetAll().Where(r => r.RoomTypeID == selectedRoomType.Id).Where(r => r.HotelID == selectedHotel.Id))
            {
                if (item.IsEmpty == true)
                {
                    lstoda.Items.Add(item);
                }

            }
        }

        //misafir ve rezervasyon arasýnda ara tablo oluþturmak için ve eklenecek misafir sayýsýný tutmak için liste oluþturuldu.

       
        int guestCount = 0;
        private void btnguests_Click(object sender, EventArgs e)
        {
            try
            {
                if (guestCount == nmrguestsCount.Value)
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

                var existingGuest = guestService.GetAll().FirstOrDefault(x => x.IdentityNumber == txttc.Text);

                if (existingGuest != null)
                {
                    // Eðer ayný isim ve soyisimde misafir varsa, bir uyarý mesajý fýrlatýyoruz
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
                //Girilen misafir sayýsý kadar misafir eklemek gerekmektedir.
              

                
                
               
               
               

            
                ClearForm(grpguestsFormu);
                //cmbotel.SelectedIndex = -1;
                //cmboda.SelectedIndex = -1;
                //lstoda.SelectedIndex = -1;
                //if (guestCount == nmrguestsCount.Value)
                //{
                //    ClearForm(grpRezervasyonFormu);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnbooking_Click(object sender, EventArgs e)
        {
            try { 
            //{
            //    int days = (dateTimePickerCheckout.Value - dtpgiris.Value).Days;
            //    decimal totalPrice = selectedRoomType.PricePerNight * days;

            //    MessageBox.Show($"Gün Sayýsý: {days}, Toplam Fiyat: {totalPrice}");
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
                MessageBox.Show("Rezervasyon oluþturuldu.");

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
                //ScheduleRoomAvailabilityUpdate(selectedRoom, b.ChechOutDate);
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

        private void nmrguestsCount_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }

    ///Deðiþiklik yapýldý.
}
