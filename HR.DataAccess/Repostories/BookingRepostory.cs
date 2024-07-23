using HR.DataAccess.ApplicationDbContext;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Repostories
{
    public class BookingRepostory : GenericRepostory<Booking>
    {
        private readonly Context _context;
        public BookingRepostory(Context context) : base(context)
        {
            _context = context;
        }
       //Booking GetQueryable(Expression<Func<Booking, bool>> filter = null)
       // {
       //     return null; 
       // } //Oda tipine göre sorgulamada müsait odaları getirmek için kullanacağım.
    }
}
