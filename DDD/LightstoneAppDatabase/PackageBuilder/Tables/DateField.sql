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
ALTER TABLE PackageBuilder.DateField ADD CONSTRAINT DateField_FK1 FOREIGN KEY (DataSourceId) REFERENCES PackageBuilder.DataSource (DataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE PackageBuilder.DateField ADD CONSTRAINT DateField_FK2 FOREIGN KEY (Industry) REFERENCES PackageBuilder.Industry ("Value") ON DELETE NO ACTION ON UPDATE NO ACTION