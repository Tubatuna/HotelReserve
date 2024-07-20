using HR.DataAccess.ApplicationDbContext;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Repostories
{
    public class HotelRepostory : GenericRepostory<Hotel>
    {
        public HotelRepostory(Context context) : base(context)
        {
        }
    }
}
