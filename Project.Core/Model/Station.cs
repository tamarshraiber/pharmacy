using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model
{
    public class Station
    {
        [Key]
        public long id { get; set; }

        public long pharmacyId;

        [ForeignKey("pharmacyId")]
        public Pharmacy pharmacy { get; set; } 
        public bool isActive { get; set; }
        public long? pharmacistId {  get; set; }

        public Station(long pharmacyId, long pharmacistId)
        {
            this.pharmacyId = pharmacyId;
            this.isActive = false;
            this.pharmacistId = pharmacistId;
        }
        public Station(long pharmacyId)
        {
            this.pharmacyId = pharmacyId;
            this.isActive = false;
        }

        public Station() { }
    }
}
