CREATE TABLE [dbo].[ResidentialProperty] (
  [Id] [int] IDENTITY,
  [BuildingAmenity] [varchar](100) NULL,
  [BuildingBathroomTotal] [int] NULL,
  [BuildingBedroom] [int] NULL,
  [BuildingSizeInterior] [int] NULL,
  [BuildingStoriesTotal] [float] NULL,
  [BuildingType] [varchar](50) NULL,
  [Distance] [varchar](255) NULL,
  [LandLandscapeFeature] [varchar](100) NULL,
  [LandSizeTotal] [varchar](100) NULL,
  [ListingBoundary] [varchar](50) NULL,
  [MlsNumber] [varchar](255) NULL,
  [PostalCode] [varchar](50) NULL,
  [PriceUnformattedValue] [int] NULL,
  [PropertyAmenityNearBy] [varchar](150) NULL,
  [PropertyOwnershipType] [varchar](50) NULL,
  [PropertyParkingSpaceTotal] [int] NULL,
  [PropertyParkingType] [varchar](100) NULL,
  [PropertyType] [varchar](50) NULL,
  [ProvinceName] [varchar](50) NULL,
  [PublicRemark] [varchar](255) NULL,
  [City] [varchar](50) NULL,
  [ListedTime] [datetime2] NULL,
  [ModifiedTime] [datetime2] NULL DEFAULT (getdate()),
  CONSTRAINT [PK_ResidentialProperty_Id] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE TRIGGER [dbo].[trigger_ModifiedTime]
ON [dbo].[ResidentialProperty]
AFTER UPDATE
AS
  UPDATE ResidentialProperty
  SET ModifiedTime = GETDATE()
  WHERE Id IN (SELECT DISTINCT Id FROM INSERTED)
GO