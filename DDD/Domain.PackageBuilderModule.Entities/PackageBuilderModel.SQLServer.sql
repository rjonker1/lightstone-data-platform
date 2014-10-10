CREATE SCHEMA PackageBuilder
GO

GO


CREATE TABLE PackageBuilder.Package
(
	PackageId int IDENTITY (1, 1) NOT NULL,
	CostOfSale decimal(19,4),
	Created datetime,
	Description nvarchar(512),
	Edited datetime,
	Name nvarchar(256),
	PackageIndustry nvarchar(32) CHECK (PackageIndustry IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')),
	PackageOwner nvarchar(512),
	PackageState nvarchar(32) CHECK (PackageState IN (N'Under construction', N'Published', N'Expired')),
	Published bit,
	RevisionDate datetime,
	Version nvarchar(16),
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
	CostOfSale decimal(19,4),
	Created datetime,
	DataSourceOwner nvarchar(512),
	DataSourceState nvarchar(32) CHECK (DataSourceState IN (N'Under construction', N'Published', N'Expired')),
	Description nvarchar(512),
	Edited datetime,
	Name nvarchar(256),
	PackageId int,
	RevisionDate datetime,
	SourceURL nvarchar(512),
	Version nvarchar(16),
	CONSTRAINT DataSource_PK PRIMARY KEY(DataSourceId)
)
GO


CREATE TABLE PackageBuilder.DateField
(
	DateFieldId int IDENTITY (1, 1) NOT NULL,
	DataSourceId int,
	Definition nvarchar(255),
	Industry nvarchar(32) CHECK (Industry IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')),
	Label nvarchar(32),
	Selected bit,
	CONSTRAINT DateField_PK PRIMARY KEY(DateFieldId)
)
GO


CREATE TABLE PackageBuilder.FileAttachment
(
	FileAttachmentId int IDENTITY (1, 1) NOT NULL,
	"Blob" varbinary(max),
	DataSourceId int,
	FileName nvarchar(256),
	CONSTRAINT FileAttachment_PK PRIMARY KEY(FileAttachmentId)
)
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK1 FOREIGN KEY (PackageOwner) REFERENCES PackageBuilder.Owner ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK2 FOREIGN KEY (PackageState) REFERENCES PackageBuilder.State ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK3 FOREIGN KEY (PackageIndustry) REFERENCES PackageBuilder.Industry ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK1 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (PackageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK2 FOREIGN KEY (DataSourceOwner) REFERENCES PackageBuilder.Owner ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK3 FOREIGN KEY (DataSourceState) REFERENCES PackageBuilder.State ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DateField ADD CONSTRAINT DateField_FK1 FOREIGN KEY (DataSourceId) REFERENCES PackageBuilder.DataSource (DataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.DateField ADD CONSTRAINT DateField_FK2 FOREIGN KEY (Industry) REFERENCES PackageBuilder.Industry ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE PackageBuilder.FileAttachment ADD CONSTRAINT FileAttachment_FK FOREIGN KEY (DataSourceId) REFERENCES PackageBuilder.DataSource (DataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


GO