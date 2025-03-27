﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model
{
    public class PatientsQueue
    {
        [Key]
        public long id { get; set; }
        public int number { get; set; }
        public long pharmacyId {  get; set; }

        [ForeignKey("pharmacyId")]
        public Pharmacy pharmacy { get; set; }


    }
}
