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
    public class SpecialsQueueRepository : ISpecialsQueueRepository
    {
        private readonly DataContext _context;

        public SpecialsQueueRepository(DataContext context)
        {
            _context = context;
        }
        public List<SpecialsQueue> GetList()
        {
            return _context.specialsQueues.ToList();
        }

        public SpecialsQueue GetById(long id)
        {
            return _context.specialsQueues.FirstOrDefault(b => b.id == id);
        }

        public async Task<SpecialsQueue> AddSpecialsQueue(SpecialsQueue specialsQueue)
        {
            _context.specialsQueues.Add(specialsQueue);
            _context.SaveChanges();
            return specialsQueue;
        }

        public SpecialsQueue UpdateSpecialsQueue(long id, SpecialsQueue specialsQueue)
        {
            SpecialsQueue p = GetById(id);
            p.id = id;
            p.pharmacy = specialsQueue.pharmacy;
            p.number = specialsQueue.number;
            _context.specialsQueues.Update(p);
            _context.SaveChanges();
            return p;

        }
        public void Delete(long id)
        {
            SpecialsQueue p = GetById(id);
            if (p == null)
            {
                throw new KeyNotFoundException($"SpecialsQueue with ID {id} not found.");
            }
            _context.specialsQueues.Remove(p);
            _context.SaveChanges();
        }

        public async Task<SpecialsQueue> DeleteNumberSpecialQueue(long pharmacyId)
        {
            SpecialsQueue smallestQueueItem = await _context.specialsQueues
                .Where(q => q.pharmacyId == pharmacyId)
                .OrderBy(q => q.number)
                .FirstOrDefaultAsync();

            if (smallestQueueItem == null)
            {
                return smallestQueueItem;
            }

            _context.specialsQueues.Remove(smallestQueueItem);
            await _context.SaveChangesAsync();
            return smallestQueueItem;
        }

        public List<SpecialsQueue> GetByPharmacy(long pharmacyId)
        {
            var l = _context.specialsQueues.Where(b => b.pharmacyId == pharmacyId).ToList();
            return l;
        }
        public void DeleteAll(int id)
        {
            _context.specialsQueues.RemoveRange(GetByPharmacy(id));
            _context.SaveChanges();
        }

    }
}
