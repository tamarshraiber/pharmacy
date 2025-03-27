using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Project.Core.Model
{
    public class Pharmacy
    {
        [Key]
        public long id { get; set; }
        public string manager { get; set; } 
        public string password { get; set; } 
        public int stationCount { get; set; } 
        public string pharmacyPassword { get; set; } 
        public List<Pharmacist> pharmacists { get; set; } 
        public List<Station> stations { get; set; } 
        public int addCounter { get; set; } 
        public int removeCounter { get; set; } 
        public List<PatientsQueue> patientsQueue { get; set; } 
        public int specialsAddCounter { get; set; } 
        public int specialsRemoveCounter { get; set; } 
        public List<SpecialsQueue> specialsQueue { get; set; } 
    }
}
