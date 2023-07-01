using Das.Application.Interfaces;
using Das.Domain.Entities;

namespace Das.Application.ResidentialProperties;

public interface IResidentialPropertyRepository : IRepository<ResidentialProperty>
{
    Task<IReadOnlyList<ResidentialProperty>> GetAllAsync();
   
}
