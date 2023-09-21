using AutoMapper;
using Das.Application.Interfaces;
using Das.Domain.Entities;
using Das.Domain.Enum;

namespace Das.Application.ResidentialProperties;

public class ResidentialPropertyService : IResidentialPropertyService
{
    private readonly IResidentialPropertyRepository _residentialPropertyRepository;
    private readonly IMapper _mapper;

    public ResidentialPropertyService(
        IResidentialPropertyRepository residentialPropertyRepository,
        IMapper mapper)
    {

        _residentialPropertyRepository = residentialPropertyRepository;
        _mapper = mapper;
    }

    public async Task<ResidentialPropertyDto> FindByIdAsync(int id)
    {
        var residentialProperty = await _residentialPropertyRepository.FindByIdAsync(id);

        return _mapper.Map<ResidentialPropertyDto>(residentialProperty);
    }


    public Task<int> Insert(ResidentialPropertyDto residentialPropertyDto)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(ResidentialPropertyDto residentialPropertyDto)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(ResidentialPropertyDto residentialPropertyDto)
    {
        throw new NotImplementedException();
    }


    public async Task<IReadOnlyList<ResidentialPropertyDto>> FindAsync(ResidentialPropertySearchCriteria searchCriteria)
    {

        var residentialProperty = await _residentialPropertyRepository.FindAsync(searchCriteria);

        return _mapper.Map<IReadOnlyList<ResidentialPropertyDto>>(residentialProperty);
    }

    private string CreateSpParam(string? value, string field)
    {
        return String.IsNullOrEmpty(value) ? $"@{field}=null" : $"@{field}='{value}'";
    }


    public async Task<IReadOnlyList<ResidentialSaleState>> GetSaleStateAsync(ResidentialPropertySearchCriteria searchCriteria)
    {
        var residentialProperties = await FindAsync(searchCriteria);

        var groups = residentialProperties.GroupBy(x => x.BuildingType);
        var totalProperties = residentialProperties.Count();
        var saleState = new List<ResidentialSaleState>();

        foreach (var group in groups)
        {
            var salesCount = group.Count();
            var salesPercentage = salesCount / totalProperties;

            if (!Enum.TryParse<BuildingTypeEnum>(group.Key, out var buildType))
            {
                buildType = BuildingTypeEnum.Unknown;
            }

            var saleStateItem = new ResidentialSaleState(buildType, salesCount, salesPercentage);
            saleState.Add(saleStateItem);
        }

        return saleState;
    }
}
