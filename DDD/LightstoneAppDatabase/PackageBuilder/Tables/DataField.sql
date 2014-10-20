CREATE TABLE PackageBuilder.DataField
(
	DataFieldId uniqueidentifier NOT NULL,
	CostOfSale decimal(19,4) NOT NULL,
	DataProviderId uniqueidentifier NOT NULL,
	IndustryId uniqueidentifier NOT NULL,
	Name nvarchar(128) NOT NULL,
	Selected bit NOT NULL,
	Label nvarchar(32),
	TypeDefinition nvarchar(255),
	CONSTRAINT DataField_UC UNIQUE(Name),
	CONSTRAINT DataField_PK PRIMARY KEY(DataFieldId)
)
GO
ALTER TABLE PackageBuilder.DataField ADD CONSTRAINT DataField_FK1 FOREIGN KEY (DataProviderId) REFERENCES PackageBuilder.DataProvider (DataProviderId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE PackageBuilder.DataField ADD CONSTRAINT DataField_FK2 FOREIGN KEY (IndustryId) REFERENCES PackageBuilder.Industry (IndustryId) ON DELETE NO ACTION ON UPDATE NO ACTION