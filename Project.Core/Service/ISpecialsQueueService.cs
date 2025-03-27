using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Service
{
    public interface ISpecialsQueueService
    {
        List<SpecialsQueue> GetAll();
        SpecialsQueue GetById(long id);
        Task<SpecialsQueue> AddSpecialsQueue(long id, int n);
        SpecialsQueue UpdateSpecialsQueue(long id, SpecialsQueue specialsQueue);
        void Delete(long id);
        Task<SpecialsQueue> DeleteNumberSpecialQueue(long id);
        List<SpecialsQueue> GetByPharmacy(long pharmacyId);
        void DeleteAll(int id);


    }
}
