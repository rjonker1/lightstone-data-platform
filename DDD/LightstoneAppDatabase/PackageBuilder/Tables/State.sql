CREATE TABLE PackageBuilder.State
(
	Id uniqueidentifier NOT NULL,
	"Value" nvarchar(24) NOT NULL,
	CONSTRAINT State_PK PRIMARY KEY(Id),
	CONSTRAINT State_Value_RoleValueConstraint1 CHECK ("Value" IN (N'Under construction', N'Published', N'Expired'))
)