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
            var paymentRepo= new PaymentRepostory(_context);
            var guests_bookingRepo= new Guests_BookingRepostory(_context);
            guests_BookingService = new Guests_BookingService(guests_bookingRepo);
            paymentService=new PaymentService(paymentRepo);
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


      private void label3_Click(object sender, EventArgs e)
        {

        }

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
                cmboda.Items.Add(item.Name);
            }
        }

        private void GetAllHotel()
        {
            foreach (var item in hService.GetAll())
            {
                cmbotel.Items.Add(item.Name);
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
        List<Guest> guestList;
        private void button2_Click(object sender, EventArgs e)
        {
            Guest g = new Guest()
            {
                FirstName = txtad.Text,
                LastName = txtsoyad.Text,
                Address = txtadres.Text,
                Email = txtmail.Text,
                Phone = txttel.Text,
                DateOfBirth = dateTimePicker1.Value
            };
            guestList.Add(g);
            if (guestService.GetByID(g.Id) == null)
            {
                guestService.Add(g);
            }
            ClearForm();

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
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking b = new Booking()
            {
                CheckInDate = dtpgiris.Value,
                ChechOutDate = datecikis.Value,
                CreatedDate = DateTime.Now,
                TotalPrice=selectedRoomType.Capacity*selectedRoomType.PricePerNight,

            };
            Payment p = new Payment()
            {
                Booking = b,
                BookingID = b.Id,
                Amount = b.TotalPrice,
                Method = (PaymentMethods)cmbpaymentmethod.SelectedItem,
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

        }
        RoomType selectedRoomType;
        private void cmbpaymentmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRoomType = (RoomType)cmbpaymentmethod.SelectedItem;
        }
    }

    ///Deðiþiklik yapýldý.
}
