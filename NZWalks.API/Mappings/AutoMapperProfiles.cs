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
            CreateMap<Region, RegionDto>().ReverseMap(); // ReverseMap maps both ways
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();

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
