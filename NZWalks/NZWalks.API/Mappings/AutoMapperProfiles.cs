using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    // This class defines mapping profiles for AutoMapper.
    // AutoMapper uses this to know how to convert between domain models and DTOs (and vice versa).
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Maps between Region (domain model) and RegionDto (Data Transfer Object)
            // ReverseMap() allows mapping in both directions
            CreateMap<Region, RegionDto>().ReverseMap();

            // Maps between AddRegionRequestDto and Region
            // Used when creating a new region
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();

            // Maps between UpdateRegionRequestDto and Region
            // Used when updating an existing region
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
        }
    }
}
