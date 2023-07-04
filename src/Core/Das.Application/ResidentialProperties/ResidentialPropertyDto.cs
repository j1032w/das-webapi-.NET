namespace Das.Application.ResidentialProperties;

/// <summary>
///     An object that represents a Residential Property
/// </summary>
public class ResidentialPropertyDto {
    /// <summary>
    ///     The Id of the Residential Property
    /// </summary>
    /// <example>123</example>
    public required int Id { get; set; } = 0;

    /// <summary>
    ///     The Address of the Residential Property
    /// </summary>
    /// <example>Clubhouse, Recreation Centre, Whirlpool</example>
    public string? BuildingAmenity { get; set; }

    /// <summary>
    ///     The Bathroom Total of the Residential Property
    /// </summary>
    /// <example>4</example>
    public int? BuildingBathroomTotal { get; set; }

    /// <summary>
    ///     The Bedroom Total of the Residential Property
    /// </summary>
    /// <example>2</example>
    public int? BuildingBedroom { get; set; }

    /// <summary>
    ///     The Size Interior of the Residential Property
    /// </summary>
    /// <example>1798</example>
    public int? BuildingSizeInterior { get; set; }

    /// <summary>
    ///     The Stories Total of the Residential Property
    /// </summary>
    /// <example>2</example>
    public int? BuildingStoriesTotal { get; set; }

    /// <summary>
    ///     The Type of the Residential Property
    /// </summary>
    /// <example>House</example>
    public string? BuildingType { get; set; }

    /// <summary>
    ///     The distance of the residential property
    /// </summary>
    /// <example></example>
    public string? Distance { get; set; }

    /// <summary>
    ///     The landscape of the residential property
    /// </summary>
    /// <example>Fruit trees, Landscaped</example>
    public string? LandLandscapeFeature { get; set; }

    /// <summary>
    ///    The size of the residential property
    /// </summary>
    /// <example>471 m2|4,051 - 7,250 sqft</example>
    public string? LandSizeTotal { get; set; }

    /// <summary>
    ///    The boundary of the residential property
    /// </summary>
    /// <example>America/Edmonton</example>
    public string? ListingBoundary { get; set; }

    /// <summary>
    ///   The MSL number of the residential property
    /// </summary>
    /// <example>MLS123456</example>
    public string? MlsNumber { get; set; }

    /// <summary>
    ///  The postal code of the residential property
    /// </summary>
    /// <example>T2K1K1</example>
    public string? PostalCode { get; set; }

    /// <summary>
    /// The asking price of the residential property
    /// </summary>
    /// 724900
    public int? PriceUnformattedValue { get; set; }

    /// <summary>
    /// The amenity nearby of the residential property
    /// </summary>
    /// <example>Park, Playground</example>
    public string? PropertyAmenityNearBy { get; set; }

    /// <summary>
    /// The ownership of the residential property
    /// </summary>
    /// <example>Freehold</example>
    public string? PropertyOwnershipType { get; set; }

    /// <summary>
    ///     The total of parking space of the residential property
    /// </summary>
    /// <example>4</example>
    public string? PropertyParkingSpaceTotal { get; set; }

    /// <summary>
    ///    The parking type of the residential property
    /// </summary>
    /// <example>Garage, Heated Garage, Oversize, Detached Garage (3)</example>
    public string? PropertyParkingType { get; set; }

    /// <summary>
    ///   The Property Type of the residential property
    /// </summary>
    /// <example>Single Family</example>
    public string? PropertyType { get; set; }

    /// <summary>
    /// The Province of the residential property address
    /// </summary>
    /// <example>Alberta</example>
    public string? ProvinceName { get; set; }

    /// <summary>
    /// The Public Remark of the residential property
    /// </summary>
    /// <example>HUD</example>
    public string? PublicRemark { get; set; }

    /// <summary>
    /// The city of the residential property address
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// The listed time of the residential property
    /// </summary>
    public required DateTime ListedTime { get; set; } = DateTime.Now;
}