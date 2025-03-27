using Project.Core.Model;
using Project.Core.Repositories;
using Project.Core.Service;
using Project.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Project.Service
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public List<Station> GetAll()
        {
            return _stationRepository.GetList();
        }

        public Station GetById(long id)
        {
            return _stationRepository.GetById(id);
        }
        public Station AddStation(Station station)
        {
            return _stationRepository.AddStation(station);
        }
        public Station UpdateStation(long id, Station station)
        {
            return _stationRepository.UpdateStation(id, station);
        }

        public void Delete(long id)
        {
            _stationRepository.Delete(id);
        }

        public List<Station> GetStationByPharmacy(long pharmacyId)
        {
            return _stationRepository.GetStationByPharmacy(pharmacyId);
        }

        

    }
}
