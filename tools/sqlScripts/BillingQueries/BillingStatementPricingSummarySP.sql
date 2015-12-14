-- ================================================

-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lightstone Auto
-- Create date: 2015/12/07
-- Description:	Billing Statement Pricing Summary
-- =============================================
CREATE PROCEDURE BillingStatementPricingSummary 
	@CustomerClientId uniqueidentifier,
	@StartDate DateTime,
	@EndDate DateTime
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		cm.ContractName, 
		bt.PackageName, 
		CASE 
			WHEN cm.HasPackagePriceOverride = 1 THEN CONVERT(nvarchar, bt.PackageRecommendedPrice)
			WHEN cm.HasPackagePriceOverride = 0 THEN 'Per Request @ R ' + CONVERT(nvarchar, bt.PackageRecommendedPrice) + ' ( Tx: ' +
			CONVERT(nvarchar, (SELECT COUNT(DISTINCT RequestId) 
			FROM [Billing].[dbo].[BillingTransaction] 
			WHERE Type = 'FinalBilling' AND
			BillingType = 'BILLABLE' AND  
			PackageName = bt.PackageName AND
			PackageRecommendedPrice = bt.PackageRecommendedPrice AND
			(CustomerId = bt.CustomerId OR ClientId = bt.ClientId) AND
			  Created >= @startDate AND
			  Created <= @endDate)) + ' )'
		END AS 'Description'
	FROM [Billing].[dbo].[BillingTransaction] bt
	INNER JOIN [Billing].[dbo].[ContractMeta] cm on bt.ContractId = cm.ContractId
	WHERE bt.Type = 'FinalBilling' AND 
	(bt.CustomerId = @customerClientId OR bt.ClientId = @customerClientId) AND
	bt.Created >= @startDate AND
	bt.Created <= @endDate

GROUP BY bt.CustomerId, bt.ClientId, cm.ContractName, bt.PackageName, bt.PackageRecommendedPrice, cm.HasPackagePriceOverride
END
GO
