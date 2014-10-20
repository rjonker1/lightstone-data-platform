CREATE TABLE PackageBuilder.DataProvider
(
	Id uniqueidentifier NOT NULL,
	Name nvarchar(128) NOT NULL,
	OverrideFieldLevelCostOfSale bit NOT NULL,
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
ALTER TABLE PackageBuilder.DataProvider ADD CONSTRAINT DataProvider_FK FOREIGN KEY (StateId) REFERENCES PackageBuilder.State (Id) ON DELETE NO ACTION ON UPDATE NO ACTION