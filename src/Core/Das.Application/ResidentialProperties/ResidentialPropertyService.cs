using Das.Domain.Entities;
using Das.Domain.Enum;

namespace Das.Application.ResidentialProperties;

public class ResidentialPropertyService : IResidentialPropertyService
{
    private readonly IResidentialPropertyRepository _residentialPropertyRepository;
    
    public ResidentialPropertyService(IResidentialPropertyRepository  residentialPropertyRepository)
    {
        this._residentialPropertyRepository = residentialPropertyRepository; 
    }
    
    public async Task<IReadOnlyList<ResidentialProperty>> GetAllAsync()
    {
        return await _residentialPropertyRepository.GetAllAsync();
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
