CREATE TABLE [dbo].[Product] (
    [ProductId]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductDescription] NVARCHAR (100) NULL,
    [UnitPrice]          MONEY          NULL,
    [UnitAmount]         NVARCHAR (50)  NULL,
    [Publisher]          NVARCHAR (200) NULL,
    [AmountInStock]      SMALLINT       NULL
);

