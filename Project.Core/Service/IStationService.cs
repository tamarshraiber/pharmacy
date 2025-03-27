using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Service
{
    public interface IStationService
    {
        List<Station> GetAll();
        Station GetById(long id);
        Station AddStation(Station station);
        Station UpdateStation(long id, Station station);
        void Delete(long id);
        List<Station> GetStationByPharmacy(long pharmacyId);

    }
}
