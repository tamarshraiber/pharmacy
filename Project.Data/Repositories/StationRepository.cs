using Project.Core.Model;
using Project.Core.Repositories;
using Project.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly DataContext _context;

        public StationRepository(DataContext context)
        {
            _context = context;
        }

        public List<Station> GetList()
        {
            return _context.stations.ToList();
        }

        public Station GetById(long id)
        {
            return _context.stations.FirstOrDefault(b => b.id == id);
        }

        public Station AddStation(Station station)
        {
            station.isActive = false;
            station.pharmacistId = null;
            _context.stations.Add(station);
            _context.SaveChanges();
            return station;
        }

        public Station UpdateStation(long id, Station station)
        {
            Station s = GetById(id);
            if (s.isActive)
            {
                s.isActive = false;
                s.pharmacistId = null;
            }
            else
            {
               // var stationWithParmacy = _mapper.Map<Station>(station);
                var res = GetStationByPharmacy(station.pharmacyId);

                foreach (var item in res)
                {
                    if (item.pharmacistId == station.pharmacistId && item.id != station.id)
                    {
                        return null;
                    }
                }
                //s.pharmacistId = station.pharmacistId;
                s.isActive = true;
                s.pharmacistId = station.pharmacistId;
            }

            _context.stations.Update(s);
            _context.SaveChanges();
            return s;

        }
        public void Delete(long id)
        {
            Station s = GetById(id);
            _context.stations.Remove(s);
            _context.SaveChanges();
        }

        public List<Station> GetStationByPharmacy(long pharmacyId)
        {
            return _context.stations.Where(b => b.pharmacyId == pharmacyId).ToList();
        }


    }
}
