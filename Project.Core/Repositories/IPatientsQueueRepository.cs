using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{
    public interface IPatientsQueueRepository
    {
        List<PatientsQueue> GetList();
        PatientsQueue GetById(long id);
        Task<PatientsQueue> AddPatientsQueue(PatientsQueue patientsQueue);
        PatientsQueue UpdatePatientsQueue(long id, PatientsQueue patientsQueue);
        PatientsQueue Delete(long id);
        Task<PatientsQueue> DeleteNumberPatientQueue(long id);
        List<PatientsQueue> GetByPharmacy(long pharmacyId);
        void DeleteAll(int id);

    }
}
