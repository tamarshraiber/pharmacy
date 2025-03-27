using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.DTOs
{
    public class StationDto
    {
        public bool isActive { get; set; } 
        public long pharmacyId { get; set; }
        public long? pharmacistId { get; set; }
    }
}
