CREATE TABLE [dbo].[DataProvider_Fields]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Price] DECIMAL(10, 2) NULL, 
    [Provider] NVARCHAR(50) NULL
)
