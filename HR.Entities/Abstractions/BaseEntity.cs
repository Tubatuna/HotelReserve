using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Abstractions
{
    public interface BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }  
    }
}
