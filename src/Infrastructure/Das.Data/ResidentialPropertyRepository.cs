using Dapper;
using Dapper.Oracle;
using Das.Application.Interfaces;
using Das.Application.ResidentialProperties;
using Das.Data.Common;
using Das.Domain.ResidentialProperties;
using System.Data;

namespace Das.Data;

public class ResidentialPropertyRepository :
    GenericRepository<ResidentialProperty>, IResidentialPropertyRepository
{

    private readonly IUnitOfWork _unitOfWork;

    public ResidentialPropertyRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResidentialProperty> AddAsync(ResidentialProperty residentialProperty)
    {
        throw new NotImplementedException();
    }

    public Task<ResidentialProperty> UpdateAsync(ResidentialProperty entity)
    {
        throw new NotImplementedException();
    }


    public async Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }




    public async Task<ResidentialProperty?> FindByIdAsync(long id)
    {
        var storedProcedure = $"{DataConstant.ORACLE_SCHEMA}.\"residential_properties_find_by_id_prc\"";
        object? result = null;
        OracleDynamicParameters parameters = new OracleDynamicParameters();
        parameters.Add("i_id", value: id, OracleMappingType.Int32, ParameterDirection.Input);
        parameters.Add("o_result", result, OracleMappingType.RefCursor, ParameterDirection.Output);

        var queryResults = await _unitOfWork.DbConnection.QueryAsync(
            storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        //var results =
        //    await _unitOfWork.DbConnection.QueryAsync<ResidentialProperty>(
        //        @"select * from dashboard.""residential_properties""");

        return queryResults.Select(ResidentialPropertyMapping).FirstOrDefault();

    }


    private ResidentialProperty ResidentialPropertyMapping(dynamic item)
    {
        return new ResidentialProperty()
        {
            Id = (int)item.id,
            BuildingAmenity = (string?)item.building_amenity,
            BuildingBathroomTotal = (int?)item.building_bathroom_total,
            BuildingBedroom = (int?)item.building_bedroom,
            BuildingSizeInterior = (int?)item.building_size_interior,
            BuildingStoriesTotal = (int?)item.building_stories_total,
            BuildingType = (string?)item.building_type,
            Distance = (string?)item.distance,
            LandLandscapeFeature = (string?)item.land_landscape_feature,
            LandSizeTotal = (string?)item.land_size_total,
            ListingBoundary = (string?)item.listing_boundary,
            MlsNumber = (string?)item.mls_number,
            PostalCode = (string?)item.postal_code,
            PriceUnformattedValue = (decimal?)item.price_unformatted_value,
            PropertyAmenityNearBy = (string?)item.property_amenity_near_by,
            PropertyOwnershipType = (string?)item.property_ownership_type,
            PropertyParkingSpaceTotal = (int?)item.property_parking_space_total,
            PropertyParkingType = (string?)item.property_parking_type,
            PropertyType = (string?)item.property_type,
            ProvinceName = (string?)item.province_name,
            PublicRemark = (string?)item.public_remark,
            City = (string?)item.city,
            ListedTime = (DateTime?)item.listed_time,
            ModifiedTime = (DateTime)item.modified_time

        };
    }




    public async Task<IReadOnlyList<ResidentialProperty>> FindAsync(ResidentialPropertySearchCriteria searchCriteria)
    {
        var storedProcedure = $"{DataConstant.ORACLE_SCHEMA}.\"residential_properties_find_all_prc\"";
        object? result = null;
        OracleDynamicParameters parameters = new OracleDynamicParameters();
        parameters.Add("i_city", searchCriteria.City, OracleMappingType.Varchar2, ParameterDirection.Input);
        parameters.Add("i_building_type", searchCriteria.BuildingType, OracleMappingType.Varchar2, ParameterDirection.Input);
        parameters.Add("i_max_price", searchCriteria.MaxPrice, OracleMappingType.Decimal, ParameterDirection.Input);
        parameters.Add("i_min_price", searchCriteria.MinPrice, OracleMappingType.Decimal, ParameterDirection.Input);
        parameters.Add("o_result", result, OracleMappingType.RefCursor, ParameterDirection.Output);

        var queryResults = await _unitOfWork.DbConnection.QueryAsync(
            storedProcedure, parameters, commandType: CommandType.StoredProcedure);



        // AsList() is a custom Dapper extension method.
        // AsList() returns it back, just casts to List<T>. If it's not - it calls regular ToList.
        // AsList() avoid the creation of copy if the result is already a list.
        // C# build-in ToList() always creates a copy.
        // Without AsList(), the code runs the risk of remunerating through the result set multiple times,
        return queryResults.Select(ResidentialPropertyMapping).AsList();
    }


}