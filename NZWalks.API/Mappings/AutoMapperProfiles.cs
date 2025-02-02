using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            // <Source, Destination>
            CreateMap<Region, RegionDto>().ReverseMap();
            // <Source, Destination>
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            // <Source, Destination>
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();


            // CreateMap<UserDTO, UserDomain>();

            // Explicit mappings
            // CreateMap<UserDTO, UserDomain>().ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));

        }

        // Example 
        public class UserDTO
        {
            public string FullName { get; set; }
        }

        // Example
        public class UserDomain 
        {
            public string Name { get; set;  }
        }
    }
}
