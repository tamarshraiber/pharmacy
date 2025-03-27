using Microsoft.EntityFrameworkCore;
using Project.Core.Model;
using Project.Core.Repositories;
using Project.Core.Service;
using Project.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class PatientsQueueService : IPatientsQueueService
    {
        private readonly IPatientsQueueRepository _patientsQueueRepository;

        public PatientsQueueService(IPatientsQueueRepository patientsQueueRepository)
        {
            _patientsQueueRepository = patientsQueueRepository;
        }
        public List<PatientsQueue> GetAll()
        {
            return _patientsQueueRepository.GetList();
        }
        public PatientsQueue GetById(long id)
        {
            return _patientsQueueRepository.GetById(id);
        }
        public async Task<PatientsQueue> AddPatientsQueue(long id, int n)
        {
            PatientsQueue p = new PatientsQueue() { number = n, pharmacyId = id };
            return await _patientsQueueRepository.AddPatientsQueue(p);
        }

        public PatientsQueue UpdatePatientsQueue(long id, PatientsQueue patientsQueue)
        {
            return _patientsQueueRepository.UpdatePatientsQueue(id, patientsQueue);
        }

        public PatientsQueue Delete(long id)
        {
            return _patientsQueueRepository.Delete(id);
        }

        public async Task<PatientsQueue> DeleteNumberPatientQueue(long id)
        {
            return await _patientsQueueRepository.DeleteNumberPatientQueue(id);
        }

        public List<PatientsQueue> GetByPharmacy(long pharmacyId)
        {
            return _patientsQueueRepository.GetByPharmacy(pharmacyId);
        }
        public void DeleteAll(int id)
        {
            _patientsQueueRepository.DeleteAll(id);
        }


    }
}
