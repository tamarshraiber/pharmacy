using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Pharmacist> pharmacists { get; set; }
        public DbSet<Pharmacy> pharmacies { get; set; }
        public DbSet<Station> stations { get; set; }
        public DbSet<PatientsQueue> patientsQueues { get; set; }
        public DbSet<SpecialsQueue> specialsQueues { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  
    }
}
