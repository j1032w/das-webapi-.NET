using Das.Domain.Entities;
using Das.Domain.ResidentialProperties;

namespace Das.Application.ResidentialProperties;

public interface IResidentialPropertyService
{
    Task<ResidentialPropertyDto> GetByIdAsync(int id);
    List<ResidentialSaleState> CalculateSaleState(List<ResidentialProperty> residentialProperties);
}
