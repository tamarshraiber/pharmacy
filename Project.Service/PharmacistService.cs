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
    public class PharmacistService : IPharmacistService
    {
        private readonly IPharmacistRepository _pharmacistRepository;

        public PharmacistService(IPharmacistRepository pharmacistRepository)
        {
            _pharmacistRepository = pharmacistRepository;
        }
        public List<Pharmacist> GetAll()
        {
            return _pharmacistRepository.GetList();
        }

        public List<Pharmacist> GetByPharmacyId(long id)
        {
            return _pharmacistRepository.GetByPharmacyIdList(id);
        }
        public Pharmacist GetById(long id)
        {
            return _pharmacistRepository.GetById(id);
        }
        public Pharmacist AddPharmacist(Pharmacist pharmacist)
        {
            return _pharmacistRepository.AddPharmacist(pharmacist);
        }
        public Pharmacist UpdatePharmacist(long id, Pharmacist pharmacist)
        {
            return _pharmacistRepository.UpdatePharmacist(id, pharmacist);
        }

        public Pharmacist Delete(long id)
        {
            return _pharmacistRepository.Delete(id);
        }

        public Pharmacist GetByName(string name)
        {
            return _pharmacistRepository.GetByName(name);
        }

    }
}
