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
            _bService = new BookingService(bRepostory);
            hService = new HotelService(hRepostory);
            roomTypeService = new RoomTypeService(rTypeRepostory);
        }
        HotelService hService;
        RoomTypeService roomTypeService;
        BookingService _bService;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in hService.GetAll())
            {
                cmbotel.Items.Add(item.Name);
            }
            foreach (var item in roomTypeService.GetAll())
            {
                cmboda.Items.Add(item.Name);
            }
            GetAllPaymentMethods();
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking b = new Booking()
            {
                CheckInDate = dtpgiris.Value,
                ChechOutDate = datecikis.Value,

            };

        }

        private void cmboda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
