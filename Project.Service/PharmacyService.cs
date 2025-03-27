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
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly IPatientsQueueService _patientsQueueService;
        private readonly ISpecialsQueueService _specialsQueueService;

        public PharmacyService(IPharmacyRepository pharmacyRepository,
            IPatientsQueueService patientsQueueService,
            ISpecialsQueueService specialsQueueService)
        {
            _pharmacyRepository = pharmacyRepository;
            _patientsQueueService = patientsQueueService;
            _specialsQueueService = specialsQueueService;

        }

        public Pharmacy GetById(long id)
        {
            return _pharmacyRepository.GetById(id);
        }

        public Pharmacy GetByName(string name)
        {
            return _pharmacyRepository.GetByName(name);
        }
        public Pharmacy AddPharmacy(Pharmacy pharmacy)
        {
            return _pharmacyRepository.AddPharmacy(pharmacy);
        }
        public Pharmacy UpdatePharmacy(long id, Pharmacy pharmacy)
        {
            return _pharmacyRepository.UpdatePharmacy(id, pharmacy);
        }

        public Pharmacy Delete(long id)
        {
            return _pharmacyRepository.Delete(id);
        }

        public List<Pharmacy> GetAll()
        {
            return _pharmacyRepository.GetList();
        }

        public async Task<Pharmacy> AddPatientToQ(long id)
        {
            var p = GetById(id);
            if (p == null)
            {
                return p;
            }

            int res = await _pharmacyRepository.AddPatientToQ(id);
            var pq = _patientsQueueService.AddPatientsQueue(id, res);
            if (pq == null)
            {
                p = null;
                return p;
            }
            return p;
        }

        public async Task<Pharmacy> AddSpecialToQ(long id)
        {
            var p = GetById(id);
            if (p == null)
            {
                return p;
            }

            int res = await _pharmacyRepository.AddSpecialToQ(id);
            var sq = await _specialsQueueService.AddSpecialsQueue(id, res);
            return p;

        }

        public async Task<int> RemovePatient(long id)
        {
            var s = await _specialsQueueService.DeleteNumberSpecialQueue(id);
            if (s != null)
            {
                _pharmacyRepository.RemoveSpecialToQ(id);
                return (s.number * 10) + 1;
            }

            var p = await _patientsQueueService.DeleteNumberPatientQueue(id);
            if (p != null)
            {
                _pharmacyRepository.RemovePatientToQ(id);
                return (p.number*10) + 2;
            }

            return -1;
        }

        public Pharmacy UpdateDatabase(Pharmacy p)
        {
            return _pharmacyRepository.UpdateDatabase(p);

        }
    }
}
