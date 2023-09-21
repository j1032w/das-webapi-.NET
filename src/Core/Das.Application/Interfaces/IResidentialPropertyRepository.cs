using Das.Application.ResidentialProperties;
using Das.Domain.ResidentialProperties;


namespace Das.Application.Interfaces;

public interface IResidentialPropertyRepository : IGenericRepository<ResidentialProperty>
{
    public Task<ResidentialProperty?> FindByIdAsync(long id);
    public Task<IReadOnlyList<ResidentialProperty>> FindAsync(ResidentialPropertySearchCriteria searchCriteria);

}

