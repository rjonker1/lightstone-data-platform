-- ================================================

-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lightstone Auto
-- Create date: 2015/12/07
-- Description:	Billing Statement Details
-- =============================================
CREATE PROCEDURE BillingStatementDetails 
	@CustomerClientId uniqueidentifier,
	@StartDate DateTime,
	@EndDate DateTime
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		'9999/99/99 - 9999/99/99' AS 'StatementPeriod',
		bt.CustomerName AS 'CustomerClientName',
		acc.AccountOwner AS 'ConsultantName',
		acc.BillingAccountContactName AS 'AccountContact',
		acc.AccountNumber AS 'AccountNumber'
	FROM [Billing].[dbo].[BillingTransaction] bt
	INNER JOIN [Billing].[dbo].[AccountMeta] acc on bt.AccountNumber = acc.AccountNumber
	WHERE bt.Type = 'FinalBilling' AND 
	(bt.CustomerId = @CustomerClientId OR bt.ClientId = @CustomerClientId)

GROUP BY bt.CustomerId, bt.CustomerName, acc.AccountNumber, acc.AccountOwner, acc.BillingAccountContactName
END
GO
