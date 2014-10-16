CREATE TABLE [dbo].[Order] (
    [OrderId]         INT           IDENTITY (1, 1) NOT NULL,
    [CustomerId]      INT           NULL,
    [OrderDate]       DATETIME      NULL,
    [DeliveryDate]    DATETIME      NULL,
    [ShippingName]    NVARCHAR (50) NULL,
    [ShippingAddress] NVARCHAR (50) NULL,
    [ShippingCity]    NVARCHAR (50) NULL,
    [ShippingZip]     NVARCHAR (50) NULL
);

