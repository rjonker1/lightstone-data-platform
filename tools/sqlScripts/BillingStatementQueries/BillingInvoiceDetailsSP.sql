-- ================================================

-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lightstone Auto
-- Create date: 2015/12/07
-- Description:	Billing Invoice Details
-- =============================================
CREATE PROCEDURE BillingInvoiceDetails 
	@CustomerClientId uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		bt.CustomerName AS 'Name',
		acc.BillingVatNumber AS 'TaxRegistration'
	FROM [Billing].[dbo].[BillingTransaction] bt
	INNER JOIN [Billing].[dbo].[AccountMeta] acc on bt.AccountNumber = acc.AccountNumber
	WHERE bt.Type = 'FinalBilling' AND 
	(bt.CustomerId = @CustomerClientId OR bt.ClientId = @CustomerClientId)

	GROUP BY bt.CustomerId, bt.CustomerName, acc.BillingVatNumber
END
GO
