-- ================================================

-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lightstone Auto
-- Create date: 2015/12/07
-- Description:	Billing Statement UserTransactions
-- =============================================
CREATE PROCEDURE BillingStatementUserTransactions 
	@CustomerClientId uniqueidentifier,
	@StartDate DateTime,
	@EndDate DateTime
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	bt.Username, 
	bt.PackageName,
	'Transactions' = 
		(SELECT COUNT(DISTINCT RequestId) 
			FROM [Billing].[dbo].[BillingTransaction] 
			WHERE Type = 'FinalBilling' AND  
			PackageName = bt.PackageName AND
			PackageRecommendedPrice = bt.PackageRecommendedPrice AND
			Username = bt.Username AND
			(CustomerId = bt.CustomerId OR ClientId = bt.ClientId) AND
			  Created >= @StartDate AND
			  Created <= @EndDate),

	'BillableTransactions' = 
		(SELECT COUNT(DISTINCT RequestId) 
			FROM [Billing].[dbo].[BillingTransaction] 
			WHERE Type = 'FinalBilling' AND
			BillingType = 'BILLABLE' AND  
			PackageName = bt.PackageName AND
			PackageRecommendedPrice = bt.PackageRecommendedPrice AND
			Username = bt.Username AND
			(CustomerId = bt.CustomerId OR ClientId = bt.ClientId) AND
			  Created >= @StartDate AND
			  Created <= @EndDate)

	  FROM [Billing].[dbo].[BillingTransaction] bt
	  WHERE Type = 'FinalBilling' AND 
	  (bt.CustomerId = @CustomerClientId OR bt.ClientId = @CustomerClientId) AND
	  Created >= @StartDate AND
	  Created <= @EndDate

	GROUP BY bt.CustomerId, bt.ClientId, bt.PackageName, bt.PackageRecommendedPrice, bt.Username
END
GO
