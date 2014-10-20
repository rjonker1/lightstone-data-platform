﻿CREATE TABLE PackageBuilder.PackageDataField
(
	PackageDataFieldId uniqueidentifier NOT NULL,
	DataFieldId uniqueidentifier NOT NULL,
	PackageId uniqueidentifier NOT NULL,
	Priority smallint CHECK (Priority >= 0) NOT NULL,
	Selected bit NOT NULL,
	UnifiedName nvarchar(128) NOT NULL,
	CONSTRAINT PackageDataField_PK PRIMARY KEY(PackageDataFieldId)
)
GO
ALTER TABLE PackageBuilder.PackageDataField ADD CONSTRAINT PackageDataField_FK1 FOREIGN KEY (PackageId) REFERENCES PackageBuilder.Package (PackageId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE PackageBuilder.PackageDataField ADD CONSTRAINT PackageDataField_FK2 FOREIGN KEY (DataFieldId) REFERENCES PackageBuilder.DataField (DataFieldId) ON DELETE NO ACTION ON UPDATE NO ACTION