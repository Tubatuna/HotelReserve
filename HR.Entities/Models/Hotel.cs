using HR.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models
{
    public class Hotel :BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Stars { get; set; }
        //public DateTime ChechInTime { get; set; }
        //public DateTime ChechOutTime { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
