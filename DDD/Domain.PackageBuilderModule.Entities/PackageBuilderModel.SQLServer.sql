CREATE SCHEMA PackageBuilderModel
GO

GO


CREATE TABLE PackageBuilderModel.Package
(
	packageId int IDENTITY (1, 1) NOT NULL,
	name nvarchar(128),
	version nvarchar(20),
	costOfSale decimal(19,4),
	created datetime,
	description nvarchar(512),
	edited datetime,
	industry nvarchar(32) CHECK (industry IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')),
	owner nvarchar(512),
	packageBuilderId int IDENTITY (1, 1),
	published bit,
	revisionDate datetime,
	state nvarchar(max) CHECK (state IN (N'Under construction', N'Published', N'Expired')),
	CONSTRAINT Package_PK PRIMARY KEY(packageId)
)
GO


CREATE VIEW PackageBuilderModel.Package_UC (name, version)
WITH SCHEMABINDING
AS
	SELECT name, version
	FROM 
		PackageBuilderModel.Package
	WHERE name IS NOT NULL AND version IS NOT NULL
GO


CREATE UNIQUE CLUSTERED INDEX Package_UCIndex ON PackageBuilderModel.Package_UC(name, version)
GO


CREATE TABLE PackageBuilderModel.Owner
(
	"value" nvarchar(512) NOT NULL,
	CONSTRAINT Owner_PK PRIMARY KEY("value")
)
GO


CREATE TABLE PackageBuilderModel.Industry
(
	"value" nvarchar(32) CHECK ("value" IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')) NOT NULL,
	CONSTRAINT Industry_PK PRIMARY KEY("value")
)
GO


CREATE TABLE PackageBuilderModel.DataSource
(
	dataSourceId int IDENTITY (1, 1) NOT NULL,
	name nvarchar(128),
	version nvarchar(20),
	costOfSale decimal(19,4),
	created datetime,
	description nvarchar(512),
	edited datetime,
	owner nvarchar(512),
	packageId int,
	revisionDate datetime,
	sourceURL nvarchar(512),
	state nvarchar(max) CHECK (state IN (N'Under construction', N'Published', N'Expired')),
	CONSTRAINT DataSource_PK PRIMARY KEY(dataSourceId)
)
GO


CREATE VIEW PackageBuilderModel.DataSource_UC (name, version)
WITH SCHEMABINDING
AS
	SELECT name, version
	FROM 
		PackageBuilderModel.DataSource
	WHERE name IS NOT NULL AND version IS NOT NULL
GO


CREATE UNIQUE CLUSTERED INDEX DataSource_UCIndex ON PackageBuilderModel.DataSource_UC(name, version)
GO


CREATE TABLE PackageBuilderModel.DateField
(
	dateFieldId int IDENTITY (1, 1) NOT NULL,
	dataSourceId int,
	definition nvarchar(255),
	industry nvarchar(32) CHECK (industry IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')),
	label nvarchar(32),
	selected bit,
	CONSTRAINT DateField_PK PRIMARY KEY(dateFieldId)
)
GO


CREATE TABLE PackageBuilderModel.FileAttachment
(
	fileAttachmentId int IDENTITY (1, 1) NOT NULL,
	dataSourceId int,
	fileName nvarchar(128),
	CONSTRAINT FileAttachment_PK PRIMARY KEY(fileAttachmentId)
)
GO


ALTER TABLE PackageBuilderModel.Package ADD CONSTRAINT Package_FK1 FOREIGN KEY (owner) REFERENCES PackageBuilderModel.Owner ("value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilderModel.Package ADD CONSTRAINT Package_FK2 FOREIGN KEY (industry) REFERENCES PackageBuilderModel.Industry ("value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilderModel.DataSource ADD CONSTRAINT DataSource_FK1 FOREIGN KEY (packageId) REFERENCES PackageBuilderModel.Package (packageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilderModel.DataSource ADD CONSTRAINT DataSource_FK2 FOREIGN KEY (owner) REFERENCES PackageBuilderModel.Owner ("value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilderModel.DateField ADD CONSTRAINT DateField_FK1 FOREIGN KEY (dataSourceId) REFERENCES PackageBuilderModel.DataSource (dataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilderModel.DateField ADD CONSTRAINT DateField_FK2 FOREIGN KEY (industry) REFERENCES PackageBuilderModel.Industry ("value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilderModel.FileAttachment ADD CONSTRAINT FileAttachment_FK FOREIGN KEY (dataSourceId) REFERENCES PackageBuilderModel.DataSource (dataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


GO