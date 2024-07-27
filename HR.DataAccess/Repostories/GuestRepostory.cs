using HR.DataAccess.ApplicationDbContext;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Repostories
{
    public class GuestRepostory : GenericRepostory<Guest>
    {
        private readonly Context _context;
        public GuestRepostory(Context context) : base(context)
        {
        }
        //public void Update (Guest guest) 
        //{
        //    var existingGuest = _context.Guests.Find(guest.Id);
        //    if (existingGuest != null)
        //    {
        //        {
        //            existingGuest.FirstName = guest.FirstName;
        //            existingGuest.LastName = guest.LastName;
        //            existingGuest.Email = guest.Email;
        //            _context.SaveChanges();
        //        }
        //    }
        //}

        //public void Delete(int guestId)
        //{
        //    var guest = _context.Guests.Find(guestId);
        //    if (guest != null)
        //    {
        //        _context.Guests.Remove(guest);
        //        _context.SaveChanges();
        //    }
        //}

        //public List<Guest> GetAll()
        //{
        //    return _context.Guests.ToList();
        //}
    }
}
