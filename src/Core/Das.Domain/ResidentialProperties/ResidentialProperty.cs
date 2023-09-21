namespace Das.Domain.ResidentialProperties;

public class ResidentialProperty
{
    public required int Id { get; set; } = 0;
    public string? BuildingAmenity { get; set; }
    public int? BuildingBathroomTotal { get; set; }
    public int? BuildingBedroom { get; set; }
    public int? BuildingSizeInterior { get; set; }
    public int? BuildingStoriesTotal { get; set; }
    public string? BuildingType { get; set; }
    public string? Distance { get; set; }
    public string? LandLandscapeFeature { get; set; }
    public string? LandSizeTotal { get; set; }
    public string? ListingBoundary { get; set; }
    public string? MlsNumber { get; set; }
    public string? PostalCode { get; set; }
    public decimal? PriceUnformattedValue { get; set; }
    public string? PropertyAmenityNearBy { get; set; }
    public string? PropertyOwnershipType { get; set; }
    public int? PropertyParkingSpaceTotal { get; set; }
    public string? PropertyParkingType { get; set; }
    public string? PropertyType { get; set; }
    public string? ProvinceName { get; set; }
    public string? PublicRemark { get; set; }
    public string? City { get; set; }
    public DateTime? ListedTime { get; set; }
    public DateTime ModifiedTime { get; set; }
}