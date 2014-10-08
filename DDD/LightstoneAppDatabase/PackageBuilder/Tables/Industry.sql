CREATE TABLE PackageBuilder.Industry
(
	"Value" nvarchar(32) CHECK ("Value" IN (N'Banking', N'Consumer', N'Dealer', N'Government', N'Insurance', N'Other')) NOT NULL,
	CONSTRAINT Industry_PK PRIMARY KEY("Value")
)