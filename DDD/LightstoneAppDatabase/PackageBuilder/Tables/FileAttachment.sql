CREATE TABLE PackageBuilder.FileAttachment
(
	FileAttachmentId int IDENTITY (1, 1) NOT NULL,
	DataSourceId int,
	FileName nvarchar(256),
	CONSTRAINT FileAttachment_PK PRIMARY KEY(FileAttachmentId)
)
GO
ALTER TABLE PackageBuilder.FileAttachment ADD CONSTRAINT FileAttachment_FK FOREIGN KEY (DataSourceId) REFERENCES PackageBuilder.DataSource (DataSourceId) ON DELETE NO ACTION ON UPDATE NO ACTION