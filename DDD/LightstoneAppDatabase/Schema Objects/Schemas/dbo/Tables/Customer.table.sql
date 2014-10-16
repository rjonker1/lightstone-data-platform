CREATE TABLE [dbo].[Customer] (
    [CustomerId]   INT           IDENTITY (1, 1) NOT NULL,
    [CustomerCode] NVARCHAR (5)  NOT NULL,
    [CompanyName]  NVARCHAR (50) NOT NULL,
    [ContactName]  NVARCHAR (50) NULL,
    [ContactTitle] NVARCHAR (50) NULL,
    [Address]      NVARCHAR (50) NULL,
    [City]         NVARCHAR (20) NULL,
    [PostalCode]   NVARCHAR (10) NULL,
    [Telephone]    NVARCHAR (50) NULL,
    [Fax]          NVARCHAR (50) NULL,
    [CountryId]    INT           NULL,
    [Photo]        IMAGE         NULL,
    [IsEnabled]    BIT           NOT NULL
);



