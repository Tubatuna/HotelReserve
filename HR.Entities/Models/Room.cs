﻿using HR.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models
{
    public class Room :BaseEntity
    {
        public string Status { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public Guid RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }
        public Guid HotelID { get; set; }
        public Hotel Hotel  { get; set; }
    }
}