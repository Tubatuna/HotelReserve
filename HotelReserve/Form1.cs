using HR.Bussiness.Services;
using HR.DataAccess.ApplicationDbContext;
using HR.DataAccess.Repostories;
using HR.Entities.Models;

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

        private Random random = new Random();
        private DateTime checkoutDate;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllHotel();
            GetAllRoomType();
            GetAllPaymentMethods();
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
        }
        List<Guest> guestList = new();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (guestList.Count >= selectedRoomType.Capacity)
                {
                    throw new Exception($"{selectedRoomType.Capacity}'den fazla misafir eklenemez.");
                }
                Guest g = new Guest()
                {
                    FirstName = txtad.Text,
                    LastName = txtsoyad.Text,
                    Address = txtadres.Text,
                    Email = txtmail.Text,
                    Phone = txttel.Text,
                    DateOfBirth = dtpdogumtarihi.Value
                };
                guestList.Add(g);
                if (guestService.GetByID(g.Id) == null)
                {
                    guestService.Add(g);
                }
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ClearForm()
        {
            foreach (var item in groupBox1.Controls)
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
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Booking b = new Booking()
                {
                    CheckInDate = dtpgiris.Value,
                    ChechOutDate = dateTimePickerCheckout.Value,
                    CreatedDate = DateTime.Now,
                    TotalPrice = selectedRoomType.Capacity * selectedRoomType.PricePerNight,

                };
                Payment p = new Payment()
                {
                    Booking = b,
                    BookingID = b.Id,
                    Amount = b.TotalPrice,
                    PaymentMethod = selectedPaymentMethod,
                    PaymentDate = DateTime.Now,
                };
                paymentService.Add(p);

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
                _bService.Add(b);
                guestList.Clear();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            
            
            }

        }
        PaymentMethods selectedPaymentMethod;
        private void cmbpaymentmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPaymentMethod=(PaymentMethods)cmbpaymentmethod.SelectedItem;
        }



        private int GenerateRandomRoomNumber()
        {
            int roomNumber;
            do
            {
                roomNumber = random.Next(1, 101);

            } while (IsRoomNumberUnavailable(roomNumber));
            return roomNumber;
        }
        private bool IsRoomNumberUnavailable(int roomNumber)
        {
            return false;
        }

        private void dateTimePickerCheckout_ValueChanged(object sender, EventArgs e)
        {
            checkoutDate = dateTimePickerCheckout.Value;
        }

        private void cmbmevcutoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            int randomRoomNumber = GenerateRandomRoomNumber();
            MessageBox.Show("Oda Numarasý: " + randomRoomNumber);
        }
        RoomType selectedRoomType;
        private void cmboda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedRoomType = (RoomType)cmboda.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

    ///Deðiþiklik yapýldý.
}
