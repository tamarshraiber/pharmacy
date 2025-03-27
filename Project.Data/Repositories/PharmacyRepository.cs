using Microsoft.EntityFrameworkCore;
using Project.Core.Model;
using Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly DataContext _context;

        public PharmacyRepository(DataContext context)
        {
            _context = context;
        }

        public List<Pharmacy> GetList()
        {
            return _context.pharmacies.Include(b => b.pharmacists).Include(b => b.stations).ToList();
        }

        public Pharmacy GetById(long id)
        {
            return _context.pharmacies.FirstOrDefault(b => b.id == id);
        }

        public Pharmacy GetByName(string name)
        {
            return _context.pharmacies.FirstOrDefault(b => b.manager == name);
        }

        public Pharmacy AddPharmacy(Pharmacy pharmacy)
        {
            _context.pharmacies.Add(pharmacy);
            _context.SaveChanges();
            return pharmacy;
        }

        public Pharmacy UpdatePharmacy(long id, Pharmacy pharmacy)
        {
            Pharmacy p = GetById(id);

            p.password = pharmacy.password;
            p.manager = p.manager;
            p.stationCount = pharmacy.stationCount;
            p.pharmacyPassword = pharmacy.pharmacyPassword;
            _context.pharmacies.Update(p);
            _context.SaveChanges();
            return p;

        }
        public Pharmacy Delete(long id)
        {
            var p = GetById(id);
            if (p == null)
            {
                return p;
            }
            _context.pharmacies.Remove(p);
            _context.SaveChanges();
            return p;
        }

        public async Task<int> AddPatientToQ(long id)
        {
            Pharmacy p = GetById(id);
            p.addCounter = p.addCounter + 1;
            UpdatePharmacy(id, p);
            _context.SaveChanges();
            return (int)p.addCounter;
        }

        public async Task<int> AddSpecialToQ(long id)
        {
            Pharmacy p = GetById(id);
            p.specialsAddCounter = p.specialsAddCounter + 1;
            UpdatePharmacy(id, p);
            _context.SaveChanges();
            return (int)p.specialsAddCounter;
        }
        public int RemovePatientToQ(long id)
        {
            Pharmacy p = GetById(id);
            p.removeCounter = p.removeCounter + 1;
            return (int)p.removeCounter;
        }

        public int RemoveSpecialToQ(long id)
        {
            Pharmacy p = GetById(id);
            p.specialsRemoveCounter = p.specialsRemoveCounter + 1;
            return (int)p.specialsRemoveCounter;
        }

        public Pharmacy UpdateDatabase(Pharmacy p)
        {
            p.addCounter = 100;
            p.removeCounter = 100;
            p.specialsAddCounter = 100;
            p.specialsRemoveCounter = 100;

            _context.Update(p);
            _context.SaveChanges();
            return p;
        }
    }
}
