using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models
{
    public class HotelResevationSystem
    {
        private static Random random = new Random();
        private List<Reservation> reservations = new List<Reservation>();

        public void MakeReservation(RoomType roomType)
        {
            int reservationNumber = GenerateReservationNumber();
            Reservation newReservation = new Reservation(roomType, reservationNumber);
            reservations.Add(newReservation);
            Console.WriteLine($"Reservation made: {newReservation}");

        }

        private int GenerateReservationNumber()
        {
            return random.Next(1. 350);

        }

        public void ShowAllReservations()
        {
            Console.WriteLine("All Reservations");
            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation);
            }

        }
    }
}

