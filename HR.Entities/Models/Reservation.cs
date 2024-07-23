using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models
{
    public class Reservation
    {
        public RoomType RoomType { get; set; }
        public int ReservationNumber { get; set; }

        public Reservation (RoomType roomType,int reservationNumber)
        {
            RoomType = roomType;
            ReservationNumber = reservationNumber;
        }

        public override string ToString()
        {
            return $"Room Type: {RoomType}, Reservation Number {ReservationNumber} ";

        }
    }
}
