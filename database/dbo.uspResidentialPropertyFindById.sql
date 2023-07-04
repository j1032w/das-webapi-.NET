SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO

CREATE PROC [dbo].[uspResidentialPropertyFindById] @Id INT
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
WHERE Id = @Id
GO