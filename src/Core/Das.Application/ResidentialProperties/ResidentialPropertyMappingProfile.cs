using AutoMapper;
using Das.Domain.ResidentialProperties;

namespace Das.Application.ResidentialProperties; 



public class ResidentialPropertyMappingProfile : Profile {

    public ResidentialPropertyMappingProfile() {
        CreateMap<ResidentialProperty, ResidentialPropertyDto>();
        CreateMap<ResidentialPropertyDto, ResidentialProperty>();
    }

}