CREATE SCHEMA PackageBuilder
GO

GO


CREATE TABLE PackageBuilder.Package
(
	Id uniqueidentifier NOT NULL,
	Description nvarchar(512) NOT NULL,
	Name nvarchar(128) NOT NULL,
	StateId uniqueidentifier NOT NULL,
	Version nvarchar(16) NOT NULL,
	CostOfSale decimal(19,4),
	Created datetime,
	Edited datetime,
	IndustryId uniqueidentifier,
	Owner nvarchar(512),
	Published bit,
	RecomendedRetailPrice decimal(19,4),
	RevisionDate datetime,
	CONSTRAINT PackageNameAndVersionExternalUniquenessConstraint_UC UNIQUE(Name, Version),
	CONSTRAINT Package_PK PRIMARY KEY(Id)
)
GO


CREATE TABLE PackageBuilder.State
(
	Id uniqueidentifier NOT NULL,
	"Value" nvarchar(16) NOT NULL,
	CONSTRAINT State_PK PRIMARY KEY(Id),
	CONSTRAINT State_Value_RoleValueConstraint1 CHECK ("Value" IN (N'Under construction', N'Published', N'Expired'))
)
GO


CREATE TABLE PackageBuilder.DataProvider
(
	Id uniqueidentifier NOT NULL,
	Name nvarchar(128) NOT NULL,
	Owner nvarchar(512) NOT NULL,
	SourceURL nvarchar(512) NOT NULL,
	StateId uniqueidentifier NOT NULL,
	Version nvarchar(16) NOT NULL,
	CostOfSale decimal(19,4),
	Created datetime,
	Description nvarchar(512),
	Edited datetime,
	RevisionDate datetime,
	CONSTRAINT DataProviderNameAndVersionUniquenessConstraint_UC UNIQUE(Name, Version),
	CONSTRAINT DataProvider_PK PRIMARY KEY(Id)
)
GO


CREATE TABLE PackageBuilder.DataField
(
	Id uniqueidentifier NOT NULL,
	CostOfSale decimal(19,4) NOT NULL,
	DataProviderId uniqueidentifier NOT NULL,
	IndustryId uniqueidentifier NOT NULL,
	Name nvarchar(128) NOT NULL,
	Selected bit NOT NULL,
	Label nvarchar(32),
	TypeDefinition nvarchar(255),
	CONSTRAINT DataField_UC UNIQUE(Name),
	CONSTRAINT DataField_PK PRIMARY KEY(Id)
)
GO


CREATE TABLE PackageBuilder.PackageDataField
(
	Id uniqueidentifier NOT NULL,
	DataFieldId uniqueidentifier NOT NULL,
	PackageId uniqueidentifier NOT NULL,
	Priority smallint CHECK (Priority >= 0) NOT NULL,
	Selected bit NOT NULL,
	UnifiedName nvarchar(128) NOT NULL,
	CONSTRAINT PackageDataField_PK PRIMARY KEY(Id)
)
GO


CREATE TABLE PackageBuilder.Industry
(
	Id uniqueidentifier NOT NULL,
	"Value" nvarchar(16) NOT NULL,
	CONSTRAINT Industry_PK PRIMARY KEY(Id),
	CONSTRAINT Industry_Value_RoleValueConstraint2 CHECK ("Value" IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other'))
)
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK1 FOREIGN KEY (StateId) REFERENCES PackageBuilder.State (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK2 FOREIGN KEY (IndustryId) REFERENCES PackageBuilder.Industry (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataProvider ADD CONSTRAINT DataProvider_FK FOREIGN KEY (StateId) REFERENCES PackageBuilder.State (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataField ADD CONSTRAINT DataField_FK1 FOREIGN KEY (DataProviderId) REFERENCES PackageBuilder.DataProvider (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataField ADD CONSTRAINT DataField_FK2 FOREIGN KEY (IndustryId) REFERENCES PackageBuilder.Industry (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageDataField ADD CONSTRAINT PackageDataField_FK1 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageDataField ADD CONSTRAINT PackageDataField_FK2 FOREIGN KEY (DataFieldId) REFERENCES PackageBuilder.DataField (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


GO