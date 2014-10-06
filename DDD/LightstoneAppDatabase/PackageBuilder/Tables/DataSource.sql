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
	Version nvarchar(20),
	CONSTRAINT DataSource_PK PRIMARY KEY(DataSourceId)
)
GO
ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK1 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (PackageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK2 FOREIGN KEY (DataSourceOwner) REFERENCES PackageBuilder.Owner ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE PackageBuilder.DataSource ADD CONSTRAINT DataSource_FK3 FOREIGN KEY (DataSourceState) REFERENCES PackageBuilder.State ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION