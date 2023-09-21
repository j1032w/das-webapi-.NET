namespace Das.Application.ResidentialProperties;

/// <summary>
///     The search criteria for residential properties
/// </summary>
public class ResidentialPropertySearchCriteria
{
    /// <summary>
    ///     The city of address of the Residential Property
    /// </summary>
    /// <example>Calgary</example>
    public string? City { get; set; }

    /// <summary>
    ///     The building type of the Residential Property
    /// </summary>
    /// <example>House</example>
    public string? BuildingType { get; set; }

    /// <summary>
    ///     The minimum price of the Residential Property
    /// </summary>
    /// <example>100000</example>
    public decimal? MinPrice { get; set; }

    /// <summary>
    ///     The maximum price of the Residential Property
    /// </summary>
    /// <example>3000000</example>
    public decimal? MaxPrice { get; set; }
}