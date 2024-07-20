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
        public GuestRepostory(Context context) : base(context)
        {
        }
    }
}
