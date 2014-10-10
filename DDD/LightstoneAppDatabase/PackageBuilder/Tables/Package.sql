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
	Version VARCHAR(16),
	CONSTRAINT Package_PK PRIMARY KEY(PackageId)
)
GO
ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK1 FOREIGN KEY (PackageOwner) REFERENCES PackageBuilder.Owner ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK2 FOREIGN KEY (PackageState) REFERENCES PackageBuilder.State ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE PackageBuilder.Package ADD CONSTRAINT Package_FK3 FOREIGN KEY (PackageIndustry) REFERENCES PackageBuilder.Industry ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION