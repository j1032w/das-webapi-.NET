SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO

CREATE PROC [dbo].[uspResidentialPropertyFindAll] (
@City VARCHAR(50),
@BuildingType VARCHAR(50),
@MaxPrice DECIMAL,
@MinPrice DECIMAL)

AS
  SELECT
    Id
   ,BuildingAmenity
   ,BuildingBathroomTotal
   ,BuildingBedroom
   ,BuildingSizeInterior
   ,BuildingStoriesTotal
   ,BuildingType
   ,Distance
   ,LandLandscapeFeature
   ,LandSizeTotal
   ,ListingBoundary
   ,MlsNumber
   ,PostalCode
   ,PriceUnformattedValue
   ,PropertyAmenityNearBy
   ,PropertyOwnershipType
   ,PropertyParkingSpaceTotal
   ,PropertyParkingType
   ,PropertyType
   ,ProvinceName
   ,PublicRemark
   ,City
   ,ListedTime
   ,ModifiedTime
  FROM ResidentialProperty
  WHERE (City = @City OR @City IS NULL) AND 
        (BuildingType = @BuildingType OR @BuildingType IS NULL) AND 
        (PriceUnformattedValue >= @MinPrice OR @MaxPrice IS NULL) AND
        (PriceUnformattedValue <= @MaxPrice OR @MaxPrice IS NULL)




GO