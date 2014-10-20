CREATE TABLE PackageBuilder.Package
(
	PackageId uniqueidentifier NOT NULL,
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
	CONSTRAINT Package_PK PRIMARY KEY(PackageId)
)
GO
ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK1 FOREIGN KEY (StateId) REFERENCES PackageBuilder.State (StateId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK2 FOREIGN KEY (IndustryId) REFERENCES PackageBuilder.Industry (IndustryId) ON DELETE NO ACTION ON UPDATE NO ACTION