using HR.DataAccess.ApplicationDbContext;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Repostories
{
    public class Guests_BookingRepostory : GenericRepostory<Guests_Booking>
    {
        public Guests_BookingRepostory(Context context) : base(context)
        {
        }
    }
}
