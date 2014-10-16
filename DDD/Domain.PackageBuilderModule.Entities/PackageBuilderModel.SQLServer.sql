CREATE SCHEMA PackageBuilder
GO

GO


CREATE TABLE PackageBuilder.Package
(
	PackageId int IDENTITY (1, 1) NOT NULL,
	Description nvarchar(512) NOT NULL,
	Name nvarchar(256) NOT NULL,
	StateId int NOT NULL,
	Version nvarchar(16) NOT NULL,
	CostOfSale decimal(19,4),
	Created datetime,
	Edited datetime,
	IndustryId int,
	Owner nvarchar(512),
	Published bit,
	RecomendedRetailPrice decimal(19,4),
	RevisionDate datetime,
	CONSTRAINT Package_UC UNIQUE(Name, Version),
	CONSTRAINT Package_PK PRIMARY KEY(PackageId)
)
GO


CREATE TABLE PackageBuilder.State
(
	StateId int IDENTITY (1, 1) NOT NULL,
	"Value" nvarchar(16) NOT NULL,
	CONSTRAINT State_PK PRIMARY KEY(StateId),
	CONSTRAINT State_Value_RoleValueConstraint1 CHECK ("Value" IN (N'Under construction', N'Published', N'Expired'))
)
GO


CREATE TABLE PackageBuilder.DataProvider
(
	DataProviderId int IDENTITY (1, 1) NOT NULL,
	Name nvarchar(256) NOT NULL,
	SourceURL nvarchar(512) NOT NULL,
	StateId int NOT NULL,
	Version nvarchar(16) NOT NULL,
	CostOfSale decimal(19,4),
	Created datetime,
	Description nvarchar(512),
	Edited datetime,
	Owner nvarchar(512),
	RevisionDate datetime,
	CONSTRAINT DataProvider_UC UNIQUE(Name, Version),
	CONSTRAINT DataProvider_PK PRIMARY KEY(DataProviderId)
)
GO


CREATE TABLE PackageBuilder.DataField
(
	DataFieldId int IDENTITY (1, 1) NOT NULL,
	DataProviderId int NOT NULL,
	IndustryId int NOT NULL,
	Definition nvarchar(255),
	Label nvarchar(32),
	CONSTRAINT DataField_PK PRIMARY KEY(DataFieldId)
)
GO


CREATE TABLE PackageBuilder.PackageHasDataProviderWithDataField
(
	"_Id" int IDENTITY (1, 1) NOT NULL,
	DataFieldId int NOT NULL,
	DataProviderId int NOT NULL,
	PackageId int NOT NULL,
	Selected bit NOT NULL,
	UnifiedName nvarchar(128) NOT NULL,
	Priority smallint CHECK (Priority >= 0),
	CONSTRAINT PackageHasDataProviderWithDataField_UC UNIQUE(PackageId, DataProviderId, DataFieldId),
	CONSTRAINT PackageHasDataProviderWithDataField_PK PRIMARY KEY("_Id")
)
GO


CREATE TABLE PackageBuilder.Industry
(
	IndustryId int IDENTITY (1, 1) NOT NULL,
	"Value" nvarchar(16) NOT NULL,
	CONSTRAINT Industry_PK PRIMARY KEY(IndustryId),
	CONSTRAINT Industry_Value_RoleValueConstraint2 CHECK ("Value" IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other'))
)
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK1 FOREIGN KEY (StateId) REFERENCES PackageBuilder.State (StateId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK2 FOREIGN KEY (IndustryId) REFERENCES PackageBuilder.Industry (IndustryId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataProvider ADD CONSTRAINT DataProvider_FK FOREIGN KEY (StateId) REFERENCES PackageBuilder.State (StateId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataField ADD CONSTRAINT DataField_FK1 FOREIGN KEY (DataProviderId) REFERENCES PackageBuilder.DataProvider (DataProviderId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataField ADD CONSTRAINT DataField_FK2 FOREIGN KEY (IndustryId) REFERENCES PackageBuilder.Industry (IndustryId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageHasDataProviderWithDataField ADD CONSTRAINT PackageHasDataProviderWithDataField_FK1 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (PackageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageHasDataProviderWithDataField ADD CONSTRAINT PackageHasDataProviderWithDataField_FK2 FOREIGN KEY (DataProviderId) REFERENCES PackageBuilder.DataProvider (DataProviderId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageHasDataProviderWithDataField ADD CONSTRAINT PackageHasDataProviderWithDataField_FK3 FOREIGN KEY (DataFieldId) REFERENCES PackageBuilder.DataField (DataFieldId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


GO