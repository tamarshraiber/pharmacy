using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.DTOs
{
    public class PharmacistDto
    {
        public long id { get; set; }
        public string name { get; set; } 

        public Pharmacy pharmacy { get; set; }
    }
}
