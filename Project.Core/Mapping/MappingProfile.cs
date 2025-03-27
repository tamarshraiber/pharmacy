using AutoMapper;
using Project.Core.DTOs;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Pharmacist, PharmacistDto>().ReverseMap();   
            CreateMap<Pharmacy, PharmacyDto>().ReverseMap();
            CreateMap<Station, StationDto>().ReverseMap();
            CreateMap<PatientsQueue, PatientQueueDto>().ReverseMap();
            CreateMap<SpecialsQueue, SpecialQueueDto>().ReverseMap();
        }
        
    }

   
}
