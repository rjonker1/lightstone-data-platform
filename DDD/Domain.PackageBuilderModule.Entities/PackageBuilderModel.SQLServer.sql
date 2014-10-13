CREATE SCHEMA PackageBuilder
GO

GO


CREATE TABLE PackageBuilder.Package
(
	PackageId int IDENTITY (1, 1) NOT NULL,
	Description nvarchar(512) NOT NULL,
	Name nvarchar(256) NOT NULL,
	Version nvarchar(16) NOT NULL,
	CostOfSale decimal(19,4),
	Created datetime,
	Edited datetime,
	PackageOwner nvarchar(512),
	PackageState nvarchar(32) CHECK (PackageState IN (N'Under construction', N'Published', N'Expired')),
	Price decimal(19,4),
	Published bit,
	RevisionDate datetime,
	CONSTRAINT Package_UC UNIQUE(Name, Version),
	CONSTRAINT Package_PK PRIMARY KEY(PackageId)
)
GO


CREATE TABLE PackageBuilder.Owner
(
	"Value" nvarchar(512) NOT NULL,
	CONSTRAINT Owner_PK PRIMARY KEY("Value")
)
GO


CREATE TABLE PackageBuilder.State
(
	"Value" nvarchar(32) CHECK ("Value" IN (N'Under construction', N'Published', N'Expired')) NOT NULL,
	CONSTRAINT State_PK PRIMARY KEY("Value")
)
GO


CREATE TABLE PackageBuilder.Industry
(
	"Value" nvarchar(32) CHECK ("Value" IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')) NOT NULL,
	CONSTRAINT Industry_PK PRIMARY KEY("Value")
)
GO


CREATE TABLE PackageBuilder.DataSource
(
	DataSourceId int IDENTITY (1, 1) NOT NULL,
	DataSouceName nvarchar(256) NOT NULL,
	DataSouceVersion nvarchar(16) NOT NULL,
	DataSourceState nvarchar(32) CHECK (DataSourceState IN (N'Under construction', N'Published', N'Expired')) NOT NULL,
	SourceURL nvarchar(512) NOT NULL,
	CostOfSale decimal(19,4),
	Created datetime,
	DataSourceOwner nvarchar(512),
	Description nvarchar(512),
	Edited datetime,
	PackageHasDataSourcePriority smallint CHECK (PackageHasDataSourcePriority >= 0),
	PackageId int,
	RevisionDate datetime,
	CONSTRAINT DataSource_UC UNIQUE(DataSouceName, DataSouceVersion),
	CONSTRAINT DataSource_PK PRIMARY KEY(DataSourceId),
	CONSTRAINT DataSource_PackageHasDataSource_MandatoryGroup CHECK (PackageId IS NOT NULL OR PackageId IS NULL AND PackageHasDataSourcePriority IS NULL)
)
GO


CREATE TABLE PackageBuilder.DateField
(
	DateFieldId int IDENTITY (1, 1) NOT NULL,
	DataSourceId int NOT NULL,
	Selected bit NOT NULL,
	Definition nvarchar(255),
	Industry nvarchar(32) CHECK (Industry IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')),
	Label nvarchar(32),
	CONSTRAINT DateField_PK PRIMARY KEY(DateFieldId)
)
GO


CREATE TABLE PackageBuilder.FileAttachment
(
	FileAttachmentId int IDENTITY (1, 1) NOT NULL,
	"Blob" varbinary(max) NOT NULL,
	FileName nvarchar(256) NOT NULL,
	DataSourceId int,
	CONSTRAINT FileAttachment_PK PRIMARY KEY(FileAttachmentId)
)
GO


CREATE TABLE PackageBuilder.PackageHasIndustry
(
	PackageId int NOT NULL,
	PackageIndustry nvarchar(32) CHECK (PackageIndustry IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')) NOT NULL,
	CONSTRAINT PackageHasIndustry_PK PRIMARY KEY(PackageId, PackageIndustry)
)
GO


CREATE TABLE PackageBuilder.PackageDataSourceDateField
(
	DataSourceId int NOT NULL,
	PackageId int NOT NULL,
	DateFieldId int NOT NULL,
	Priority smallint CHECK (Priority >= 0),
	UnifiedName nvarchar(max),
	CONSTRAINT PackageDataSourceDateField_PK PRIMARY KEY(PackageId, DataSourceId)
)
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK1 FOREIGN KEY (PackageOwner) REFERENCES PackageBuilder.Owner ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK2 FOREIGN KEY (PackageState) REFERENCES PackageBuilder.State ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK1 FOREIGN KEY (DataSourceOwner) REFERENCES PackageBuilder.Owner ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK2 FOREIGN KEY (DataSourceState) REFERENCES PackageBuilder.State ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK3 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (PackageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DateField ADD CONSTRAINT DateField_FK1 FOREIGN KEY (DataSourceId) REFERENCES PackageBuilder.DataSource (DataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DateField ADD CONSTRAINT DateField_FK2 FOREIGN KEY (Industry) REFERENCES PackageBuilder.Industry ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.FileAttachment ADD CONSTRAINT FileAttachment_FK FOREIGN KEY (DataSourceId) REFERENCES PackageBuilder.DataSource (DataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageHasIndustry ADD CONSTRAINT PackageHasIndustry_FK1 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (PackageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageHasIndustry ADD CONSTRAINT PackageHasIndustry_FK2 FOREIGN KEY (PackageIndustry) REFERENCES PackageBuilder.Industry ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageDataSourceDateField ADD CONSTRAINT PackageDataSourceDateField_FK1 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (PackageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageDataSourceDateField ADD CONSTRAINT PackageDataSourceDateField_FK2 FOREIGN KEY (DataSourceId) REFERENCES PackageBuilder.DataSource (DataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.PackageDataSourceDateField ADD CONSTRAINT PackageDataSourceDateField_FK3 FOREIGN KEY (DateFieldId) REFERENCES PackageBuilder.DateField (DateFieldId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


GO