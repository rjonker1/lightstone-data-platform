CREATE SCHEMA PackageBuilder
GO

GO


CREATE TABLE PackageBuilder.Package
(
	PackageId int IDENTITY (1, 1) NOT NULL,
	Description nvarchar(512) NOT NULL,
	Name nvarchar(128) NOT NULL,
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
	Name nvarchar(128) NOT NULL,
	Owner nvarchar(512) NOT NULL,
	SourceURL nvarchar(512) NOT NULL,
	StateId int NOT NULL,
	Version nvarchar(16) NOT NULL,
	CostOfSale decimal(19,4),
	Created datetime,
	Description nvarchar(512),
	Edited datetime,
	RevisionDate datetime,
	CONSTRAINT DataProvider_UC UNIQUE(Name, Version),
	CONSTRAINT DataProvider_PK PRIMARY KEY(DataProviderId)
)
GO


CREATE TABLE PackageBuilder.DataField
(
	DataFieldId int IDENTITY (1, 1) NOT NULL,
	CostOfSale decimal(19,4) NOT NULL,
	DataProviderId int NOT NULL,
	IndustryId int NOT NULL,
	Name nvarchar(128) NOT NULL,
	Selected bit NOT NULL,
	Label nvarchar(32),
	TypeDefinition nvarchar(255),
	CONSTRAINT DataField_UC UNIQUE(Name),
	CONSTRAINT DataField_PK PRIMARY KEY(DataFieldId)
)
GO


CREATE TABLE PackageBuilder.PackageDataField
(
	PackageDataFieldId int IDENTITY (1, 1) NOT NULL,
	DataFieldId int NOT NULL,
	PackageId int NOT NULL,
	Priority smallint CHECK (Priority >= 0) NOT NULL,
	Selected bit NOT NULL,
	UnifiedName nvarchar(128) NOT NULL,
	CONSTRAINT PackageDataField_PK PRIMARY KEY(PackageDataFieldId)
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


ALTER TABLE PackageBuilder.PackageDataField ADD CONSTRAINT PackageDataField_FK1 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (PackageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageDataField ADD CONSTRAINT PackageDataField_FK2 FOREIGN KEY (DataFieldId) REFERENCES PackageBuilder.DataField (DataFieldId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


GO