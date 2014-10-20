CREATE TABLE PackageBuilder.Industry
(
	IndustryId uniqueidentifier NOT NULL,
	"Value" nvarchar(16) NOT NULL,
	CONSTRAINT Industry_PK PRIMARY KEY(IndustryId),
	CONSTRAINT Industry_Value_RoleValueConstraint2 CHECK ("Value" IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other'))
)