using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{
    public interface ISpecialsQueueRepository
    {
        List<SpecialsQueue> GetList();
        SpecialsQueue GetById(long id);
        Task<SpecialsQueue> AddSpecialsQueue(SpecialsQueue specialsQueue);
        SpecialsQueue UpdateSpecialsQueue(long id, SpecialsQueue specialsQueue);
        void Delete(long id);
        Task<SpecialsQueue> DeleteNumberSpecialQueue(long pharmacyId);
        List<SpecialsQueue> GetByPharmacy(long pharmacyId);

        void DeleteAll(int id);


    }
}
