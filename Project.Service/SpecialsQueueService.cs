using Project.Core.Model;
using Project.Core.Repositories;
using Project.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class SpecialsQueueService : ISpecialsQueueService
    {
        private readonly ISpecialsQueueRepository _specialsQueueRepository;

        public SpecialsQueueService(ISpecialsQueueRepository specialsQueueRepository)
        {
            _specialsQueueRepository = specialsQueueRepository;
        }
        public List<SpecialsQueue> GetAll()
        {
            return _specialsQueueRepository.GetList();
        }
        public SpecialsQueue GetById(long id)
        {
            return _specialsQueueRepository.GetById(id);
        }
        public async Task<SpecialsQueue> AddSpecialsQueue(long id, int n)
        {
            SpecialsQueue specialsQueue = new SpecialsQueue() { number = n, pharmacyId = id };
            return await _specialsQueueRepository.AddSpecialsQueue(specialsQueue);
        }

        public SpecialsQueue UpdateSpecialsQueue(long id, SpecialsQueue specialsQueue)
        {
            return _specialsQueueRepository.UpdateSpecialsQueue(id, specialsQueue);
        }

        public void Delete(long id)
        {
            _specialsQueueRepository.Delete(id);
        }

        public async Task<SpecialsQueue> DeleteNumberSpecialQueue(long id)
        {
            return await _specialsQueueRepository.DeleteNumberSpecialQueue(id);
        }

        public List<SpecialsQueue> GetByPharmacy(long pharmacyId)
        {
            return _specialsQueueRepository.GetByPharmacy(pharmacyId);

        }
        public void DeleteAll(int id)
        {
            _specialsQueueRepository.DeleteAll(id);
        }


    }
}
