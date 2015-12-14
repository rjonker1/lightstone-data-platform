USE [Billing]
GO
/****** Object:  StoredProcedure [dbo].[BillingInvoiceUserTransactions]    Script Date: 2015/12/14 8:39:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lightstone Auto
-- Create date: 2015/12/07
-- Description:	Billing Invoice User Transactions Details
-- =============================================
CREATE PROCEDURE [dbo].[BillingInvoiceUserTransactions] 
	@CustomerClientId uniqueidentifier,
	@StartDate DateTime,
	@EndDate DateTime
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		bt.PackageName AS 'ItemCode', 
		CASE 
			WHEN bt.BillingType = 'BILLABLE' THEN bt.PackageName
			WHEN bt.BillingType != 'BILLABLE' THEN bt.PackageName + ' - Non-Billable'
		END AS 'ItemDescription',
		'QuantityUnit' = 
			(SELECT COUNT(DISTINCT RequestId) 
				FROM [Billing].[dbo].[BillingTransaction] 
				WHERE Type = 'FinalBilling' AND
				PackageName = bt.PackageName AND
				PackageRecommendedPrice = bt.PackageRecommendedPrice AND
				(CustomerId = bt.CustomerId OR ClientId = bt.ClientId) AND
				Created >= @startDate AND Created <= @endDate),
		CASE 
			WHEN bt.BillingType = 'BILLABLE' THEN bt.PackageRecommendedPrice
			WHEN bt.BillingType != 'BILLABLE' THEN 0
		END AS 'Price'

	FROM [Billing].[dbo].[BillingTransaction] bt
	INNER JOIN [Billing].[dbo].[ContractMeta] cm on bt.ContractId = cm.ContractId
	WHERE bt.Type = 'FinalBilling' AND 
	(bt.CustomerId = @customerClientId OR bt.ClientId = @customerClientId) AND
	bt.Created >= @startDate AND bt.Created <= @endDate

	GROUP BY bt.CustomerId, bt.ClientId, cm.ContractName, bt.PackageName, bt.PackageRecommendedPrice, bt.BillingType
END
