using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{
    public interface IPharmacyRepository
    {
        List<Pharmacy> GetList();
        Pharmacy GetById(long id);
        Pharmacy AddPharmacy(Pharmacy pharmacy);
        Pharmacy UpdatePharmacy(long id, Pharmacy pharmacy);
        Pharmacy Delete(long id);
        Task<int> AddPatientToQ(long id);
        Task<int> AddSpecialToQ(long id);
        int RemoveSpecialToQ(long id);
        int RemovePatientToQ(long id);
        Pharmacy GetByName(string name);
        Pharmacy UpdateDatabase(Pharmacy p);


    }
}
