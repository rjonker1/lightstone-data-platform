DECLARE @customerClientId as uniqueidentifier, 
		@startDate as DateTime,
		@endDate as DateTime

--SET @customerClientId = '54BD98DD-5CF1-48C1-9365-469FBE2970C8'
SET @customerClientId = '355E6242-0668-41A5-BE72-EC5091E12B35'

SET @startDate = '2015/10/26'
SET @endDate = '2015/11/27'

-- Statement Details
SELECT 
		'9999/99/99 - 9999/99/99' AS 'StatementPeriod',
		bt.CustomerName AS 'CustomerClientName',
		acc.AccountOwner AS 'ConsultantName',
		acc.BillingAccountContactName AS 'AccountContact',
		acc.AccountNumber AS 'AccountNumber'
	FROM [Billing].[dbo].[BillingTransaction] bt
	INNER JOIN [Billing].[dbo].[AccountMeta] acc on bt.AccountNumber = acc.AccountNumber
	WHERE bt.Type = 'FinalBilling' AND 
	(bt.CustomerId = @customerClientId OR bt.ClientId = @customerClientId)

GROUP BY bt.CustomerId, bt.CustomerName, acc.AccountNumber, acc.AccountOwner, acc.BillingAccountContactName

-- UserTransactions
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
			  Created >= @startDate AND
			  Created <= @endDate),

	'BillableTransactions' = 
		(SELECT COUNT(DISTINCT RequestId) 
			FROM [Billing].[dbo].[BillingTransaction] 
			WHERE Type = 'FinalBilling' AND
			BillingType = 'BILLABLE' AND  
			PackageName = bt.PackageName AND
			PackageRecommendedPrice = bt.PackageRecommendedPrice AND
			Username = bt.Username AND
			(CustomerId = bt.CustomerId OR ClientId = bt.ClientId) AND
			  Created >= @startDate AND
			  Created <= @endDate)

  FROM [Billing].[dbo].[BillingTransaction] bt
  WHERE Type = 'FinalBilling' AND 
  (bt.CustomerId = @customerClientId OR bt.ClientId = @customerClientId) AND
  Created >= @startDate AND
  Created <= @endDate

GROUP BY bt.CustomerId, bt.ClientId, bt.PackageName, bt.PackageRecommendedPrice, bt.Username

-- Prcining Summary
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