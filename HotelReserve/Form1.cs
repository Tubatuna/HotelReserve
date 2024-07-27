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
            LoadCustomers();


        }
        private readonly HotelService hService;
        private readonly RoomTypeService roomTypeService;
        private readonly BookingService _bService;
        private readonly GuestService guestService;
        private readonly PaymentService paymentService;
        private readonly Guests_BookingService guests_BookingService;
        private readonly RoomService rService;

        private DateTime checkoutDate;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form a��l�nca y�klenecek veriler methodlar ile �a��r�ld�.
            GetAllHotel();
            GetAllRoomType();
            GetAllPaymentMethods();

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
        private void ClearForm()
        {
            foreach (var item in grpRezervasyon.Controls)
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
                }
            }
            //cmboda.SelectedIndex = -1;
            //cmbotel.SelectedIndex = -1;
            //cmbpaymentmethod.SelectedIndex = -1;

        }
        Booking b;

        //Chechout s�resi ge�ince IsEmptynin true olmas� i�in metod denendi.
        private void ScheduleRoomAvailabilityUpdate(Room selectedRoom, DateTime chechOutDate)
        {
            selectedRoom.IsEmpty = false;
            TimeSpan delay = checkoutDate - DateTime.Now;
            Task.Delay(delay).ContinueWith(_ =>
            {
                selectedRoom.IsEmpty = true;
                rService.Update(selectedRoom);
                MessageBox.Show($"{selectedRoom.RoomNumber} numaral� oda bo�ald�.");
            });
        }

        // paymentmetod se�imi
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

        //Rezerve edilecek oda se�imi
        Room selectedRoom;

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRoom = (Room)lstoda.SelectedItem;
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

        private readonly List<Guest> guestList = new();
        private void btnguests_Click(object sender, EventArgs e)
        {
            try
            {

                Guest g = new Guest()
                {
                    FirstName = txtad.Text,
                    LastName = txtsoyad.Text,
                    Address = txtadres.Text,
                    Email = txtmail.Text,
                    Phone = txttel.Text,
                    DateOfBirth = dtpdogumtarihi.Value
                };

                var existingGuest = guestService.GetAll().FirstOrDefault(x => x.FirstName == txtad.Text &&
                x.LastName == txtsoyad.Text);

                if (existingGuest != null)
                {
                    // E�er ayn� isim ve soyisimde misafir varsa, bir uyar� mesaj� f�rlat�yoruz
                    throw new Exception("Bu isim ve soyisimde zaten bir misafir var.");
                }
                MessageBox.Show(guestList.Count.ToString(), selectedRoomType.Capacity.ToString());
                if (guestList.Count >= selectedRoomType.Capacity)
                {
                    throw new Exception("Oda kapasitesinden fazla misafir eklenemez.");
                }
                guestList.Add(g);
                guestService.Add(g);
                MessageBox.Show("Misafir bilgisi kaydedildi.");
                foreach (var item in guestList)
                {
                    Guests_Booking gb = new Guests_Booking()
                    {
                        Booking = b,
                        BookingID = b.Id,
                        Guest = item,
                        GuestID = item.Id
                    };
                    guests_BookingService.Add(gb);
                }

                guestList.Clear();
                ClearForm();
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
                b = new Booking()
                {
                    CheckInDate = dtpgiris.Value,
                    ChechOutDate = dateTimePickerCheckout.Value,
                    CreatedDate = DateTime.Now,
                    TotalPrice = selectedRoomType.Capacity * selectedRoomType.PricePerNight,
                    Room = selectedRoom,
                    RoomID = selectedRoom.Id,


                };
                _bService.Add(b);
                //selectedRoom.IsEmpty = false;
                MessageBox.Show("Rezervasyon olu�turuldu.");
                txttotalfiyat.Text = b.TotalPrice.ToString();
                Payment p = new Payment()
                {
                    Booking = b,
                    BookingID = b.Id,
                    Amount = b.TotalPrice,
                    PaymentMethod = selectedPaymentMethod,
                    PaymentDate = DateTime.Now,

                };
                paymentService.Add(p);


                //ScheduleRoomAvailabilityUpdate(selectedRoom, b.ChechOutDate);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void LoadCustomers()
        {
            listboxM��teri.Items.Clear();
            var customers = guestService.GetAll();
            foreach (var customer in customers)
            {
                listboxM��teri.Items.Add(customer);
            }
        }
        private void listboxM��teri_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCustomer = (Guest)listboxM��teri.SelectedItem;
            if (selectedCustomer != null)
            {

                txtad.Text = selectedCustomer.FirstName;
                txtmail.Text = selectedCustomer.Email;


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selectedCustomer = (Guest)listboxM��teri.SelectedItem;
            if (selectedCustomer != null)
            {
                selectedCustomer.FirstName = txtad.Text;
                selectedCustomer.Email = txtmail.Text;
                guestService.Update(selectedCustomer);
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("L�tfen g�ncellemek i�in bir m��teri se�in.");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedCustomer = (Guest)listboxM��teri.SelectedItem;
            if (selectedCustomer != null && selectedCustomer.GuestID ! = 0 )
            {
                guestService.Delete(selectedCustomer.GuestID);
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("L�tfen silmek i�in bir m��teri se�in.");
            }
        }


        ///De�i�iklik yap�ld�.
    }
}
