using AutoMapper;
using Das.Application.Interfaces;
using Das.Domain.Entities;
using Das.Domain.Enum;
using Das.Domain.ResidentialProperties;

namespace Das.Application.ResidentialProperties;

public class ResidentialPropertyService : IResidentialPropertyService
{
    private readonly IRepository<ResidentialProperty> _residentialPropertyRepository;
    private readonly IMapper _mapper;
    
    public ResidentialPropertyService(IRepository<ResidentialProperty> residentialPropertyRepository, IMapper _mapper)
    {
        this._residentialPropertyRepository = residentialPropertyRepository; 
        this._mapper = _mapper;
    }
    
    public async Task<ResidentialPropertyDto> GetByIdAsync(int id) {
        var residentialProperty = await _residentialPropertyRepository.FindByIdAsync(id, "uspResidentialPropertyGetById");

        return _mapper.Map<ResidentialPropertyDto>(residentialProperty) ;
    }



    public List<ResidentialSaleState> CalculateSaleState(List<ResidentialProperty> residentialProperties)
    {
        var groups = residentialProperties.GroupBy(x => x.BuildingType);
        var totalProperties = residentialProperties.Count();
        var saleState = new List<ResidentialSaleState>();

        foreach (var group in groups) {
            var salesCount = group.Count();
            var salesPercentage = salesCount / totalProperties;

            if (!Enum.TryParse<BuildingTypeEnum>(group.Key, out var buildType)) {
                buildType = BuildingTypeEnum.Unknown;
            }

            var saleStateItem = new ResidentialSaleState(buildType, salesCount, salesPercentage);
            saleState.Add(saleStateItem);
        }

        return saleState;
    }
}
