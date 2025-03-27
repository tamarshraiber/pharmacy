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
    public class PatientsQueueRepository : IPatientsQueueRepository
    {
        private readonly DataContext _context;

        public PatientsQueueRepository(DataContext context)
        {
            _context = context;
        }

        public List<PatientsQueue> GetList()
        {
            return _context.patientsQueues.ToList();
        }

        public PatientsQueue GetById(long id)
        {
            return _context.patientsQueues.FirstOrDefault(b => b.id == id);
        }

        public async Task<PatientsQueue> AddPatientsQueue(PatientsQueue patientsQueue)
        {
            _context.patientsQueues.Add(patientsQueue);
            _context.SaveChanges();
            return patientsQueue;
        }

        public PatientsQueue UpdatePatientsQueue(long id, PatientsQueue patientsQueue)
        {
            PatientsQueue p = GetById(id);
            p.id = id;
            p.pharmacy = patientsQueue.pharmacy;
            p.number = patientsQueue.number;

            _context.patientsQueues.Update(p);
            _context.SaveChanges();
            return p;

        }
        public PatientsQueue Delete(long id)
        {
            var p = GetById(id);
            if (p == null)
            {
                return p;
            }
            _context.patientsQueues.Remove(p);
            _context.SaveChanges();
            return p;
        }

        public async Task<PatientsQueue> DeleteNumberPatientQueue(long pharmacyId)
        {
            PatientsQueue smallestQueueItem = await _context.patientsQueues
                .Where(q => q.pharmacyId == pharmacyId)
                .OrderBy(q => q.number)
                .FirstOrDefaultAsync();

            if (smallestQueueItem == null)
            {
                return smallestQueueItem;
            }

            _context.patientsQueues.Remove(smallestQueueItem);
            await _context.SaveChangesAsync();
            return smallestQueueItem;
        }

        public List<PatientsQueue> GetByPharmacy(long pharmacyId)
        {
            var l = _context.patientsQueues.Where(b => b.pharmacyId == pharmacyId).ToList();
            return l;
        }

        public void DeleteAll(int id)
        {
            _context.patientsQueues.RemoveRange(GetByPharmacy(id));
            _context.SaveChanges();
        }

    }
}
