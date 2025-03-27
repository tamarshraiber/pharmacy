using AutoMapper;
using Project.API.Models.Pharmacist;
using Project.API.Models.Pharmacy;
using Project.API.Models.Station;
using Project.Core.Model;

namespace Project.API.Mapping
{
    public class PostModelMappingProfile : Profile
    {
        public PostModelMappingProfile()
        {
            CreateMap<PharmacistPostModel, Pharmacist>();
            CreateMap<PharmacistPutModel, Pharmacist>();

            CreateMap<PharmacyPostModel, Pharmacy>();
            CreateMap<PharmacyPutModel, Pharmacy>();

            CreateMap<StationPostModel, Station>().ReverseMap();
            CreateMap<StationPutModel, Station>().ReverseMap();

        }
    }
}
