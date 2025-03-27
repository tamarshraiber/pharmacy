using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{

    public interface IPharmacistRepository
    {
        List<Pharmacist> GetList();

        List<Pharmacist> GetByPharmacyIdList(long id);
        Pharmacist GetById(long id);
        Pharmacist AddPharmacist(Pharmacist pharmacist);
        Pharmacist UpdatePharmacist(long id, Pharmacist pharmacist);
        Pharmacist Delete(long id);
        Pharmacist GetByName(string name);




    }
}
