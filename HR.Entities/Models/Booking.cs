using HR.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models
{
    public class Booking : BaseEntity
    {
        public int RoomNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime ChechOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Guests_Booking> Guests_Booking { get; set; } 
        public Guid RoomID { get; set; }
        public Room Room { get; set; }  
    }
}
