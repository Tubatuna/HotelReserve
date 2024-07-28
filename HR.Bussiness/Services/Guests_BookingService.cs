using HR.Bussiness.Abstract;
using HR.DataAccess.Repostories;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Services
{
    public class Guests_BookingService : IManager<Guests_Booking>
    {
        private readonly Guests_BookingRepostory guests_BookingRepostory;
        public Guests_BookingService(Guests_BookingRepostory guests_Booking)
        {
            guests_BookingRepostory = guests_Booking;  
        }
        public void Add(Guests_Booking entity)
        {
           guests_BookingRepostory.Add(entity);
        }

        public void Delete(Guests_Booking entity)
        {
            guests_BookingRepostory.Delete(entity.GuestID);
        }

        public List<Guests_Booking> GetAll()
        {
           return guests_BookingRepostory.GetAll();
        }

        public Guests_Booking GetByID(Guid id)
        {
            return guests_BookingRepostory.GetByID(g => g.GuestID == id);

        }

        public void Update(Guests_Booking entity)
        {
            guests_BookingRepostory.Update(entity);
        }
    }
}
