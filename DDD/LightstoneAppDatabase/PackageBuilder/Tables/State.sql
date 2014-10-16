CREATE TABLE PackageBuilder.State
(
	"Value" nvarchar(32) CHECK ("Value" IN (N'Under construction', N'Published', N'Expired')) NOT NULL,
	CONSTRAINT State_PK PRIMARY KEY("Value")
)