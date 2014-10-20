CREATE TABLE PackageBuilder.DataProvider
(
	DataProviderId uniqueidentifier NOT NULL,
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
	CONSTRAINT DataProviderUniquenessConstraintOnNameAndVersion_UC UNIQUE(Name, Version),
	CONSTRAINT DataProvider_PK PRIMARY KEY(DataProviderId)
)
GO
ALTER TABLE PackageBuilder.DataProvider ADD CONSTRAINT DataProvider_FK FOREIGN KEY (StateId) REFERENCES PackageBuilder.State (StateId) ON DELETE NO ACTION ON UPDATE NO ACTION