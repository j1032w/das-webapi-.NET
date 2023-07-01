using Das.Domain.Entities;

namespace Das.Application.ResidentialProperties;

public interface IResidentialPropertyService
{
    Task<IReadOnlyList<ResidentialProperty>> GetAllAsync();
    List<ResidentialSaleState> CalculateSaleState(List<ResidentialProperty> residentialProperties);
}
