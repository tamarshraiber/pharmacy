using Project.Core.Model;
using Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public class PharmacistRepository : IPharmacistRepository
    {
        private readonly DataContext _context;

        public PharmacistRepository(DataContext context)
        {
            _context = context;
        }

        public List<Pharmacist> GetByPharmacyIdList(long pharmacyId)
        {
            return _context.pharmacists.Where(b => b.pharmacyId == pharmacyId).ToList();
        }
        public List<Pharmacist> GetList()
        {
            return _context.pharmacists.ToList();
        }

        public Pharmacist GetById(long id)
        {
            return _context.pharmacists.FirstOrDefault(b => b.id == id);
        }

        public Pharmacist GetByName(string name)
        {
            return _context.pharmacists.FirstOrDefault(b => b.name == name);
        }

        public Pharmacist AddPharmacist(Pharmacist pharmacist)
        {
            _context.pharmacists.Add(pharmacist);
            _context.SaveChanges();
            return pharmacist;
        }

        public Pharmacist UpdatePharmacist(long id, Pharmacist pharmacist)
        {
            Pharmacist p = GetById(id);
            p.password = pharmacist.password;

            _context.pharmacists.Update(p);
            _context.SaveChanges();
            return p;

        }
        public Pharmacist Delete(long id)
        {
            Pharmacist p = GetById(id);
            if (p == null)
            {
                return p;
            }
            _context.pharmacists.Remove(p);
            _context.SaveChanges();
            return p;
        }
    }
}
