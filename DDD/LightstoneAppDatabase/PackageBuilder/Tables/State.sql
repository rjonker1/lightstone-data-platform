CREATE TABLE PackageBuilder.State
(
	StateId uniqueidentifier NOT NULL,
	"Value" nvarchar(16) NOT NULL,
	CONSTRAINT State_PK PRIMARY KEY(StateId),
	CONSTRAINT State_Value_RoleValueConstraint1 CHECK ("Value" IN (N'Under construction', N'Published', N'Expired'))
)