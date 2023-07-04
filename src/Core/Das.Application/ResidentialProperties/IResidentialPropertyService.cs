using Das.Domain.Entities;

namespace Das.Application.ResidentialProperties;

public interface IResidentialPropertyService {
    Task<ResidentialPropertyDto> FindByIdAsync(int id);
    Task<IReadOnlyList<ResidentialPropertyDto>> FindAsync(ResidentialPropertySearchCriteria searchCriteria);

    Task<int> Insert(ResidentialPropertyDto residentialPropertyDto);
    Task<int> Delete(ResidentialPropertyDto residentialPropertyDto);
    Task<int> Update(ResidentialPropertyDto residentialPropertyDto);


    Task<IReadOnlyList<ResidentialSaleState>> GetSaleStateAsync(ResidentialPropertySearchCriteria searchCriteria);
}