using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.DTOs
{
    public class PharmacyDto
    {
        public long id { get; set; }
        public string manager { get; set; } 
        public int stationCount { get; set; } 
        public string pharmacyPassword { get; set; } 
        public List<Pharmacist> pharmacists { get; set; } 
        public List<Station> stations { get; set; } 
        public int addCounter { get; set; } 
        public int removeCounter { get; set; } 
        public int specialsAddCounter { get; set; } 
        public int specialsRemoveCounter { get; set; }
    }
}
