using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Service
{
    public interface IPharmacyService
    {
        List<Pharmacy> GetAll();
        Pharmacy GetById(long id);
        Pharmacy AddPharmacy(Pharmacy pharmacy);
        Pharmacy UpdatePharmacy(long id, Pharmacy pharmacy);
        Pharmacy Delete(long id);
        Task<Pharmacy> AddPatientToQ(long id);
        Task<Pharmacy> AddSpecialToQ(long id);
        Task<int> RemovePatient(long id);
        Pharmacy GetByName(string name);
        Pharmacy UpdateDatabase(Pharmacy p);

    }
}
