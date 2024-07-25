using HR.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models
{
    public class RoomType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
