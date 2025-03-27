using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Service
{
    public interface IPharmacistService
    {

        List<Pharmacist> GetAll();

        List<Pharmacist> GetByPharmacyId(long pharmacistId);
        Pharmacist GetById(long id);
        Pharmacist AddPharmacist(Pharmacist pharmacist);
        Pharmacist UpdatePharmacist(long id, Pharmacist pharmacist);
        Pharmacist Delete(long id);
        Pharmacist GetByName(string name);


    }
}
