-- ================================================

-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lightstone Auto
-- Create date: 2015/12/07
-- Description:	StageBilling Repository
-- =============================================
CREATE PROCEDURE StageBillingRepository
	@StartDate DateTime,
	@EndDate DateTime
AS
BEGIN
	SET NOCOUNT ON;
	SELECT bt.[Id]
      ,bt.[CustomerId]
      ,bt.[ClientId]
      ,bt.[BillingType]
      ,bt.[CustomerName]
      ,bt.[ClientName]
      ,bt.[AccountNumber]
      ,bt.[ContractId]
      ,bt.[Modified]
      ,bt.[ModifiedBy]
      ,bt.[Created]
      ,bt.[CreatedBy]
      ,bt.[PackageId]
      ,bt.[PackageName]
      ,bt.[PackageCostPrice]
      ,bt.[PackageRecommendedPrice]
      ,bt.[DataProviderId]
      ,bt.[DataProviderName]
      ,bt.[CostPrice]
      ,bt.[RecommendedPrice]
      ,bt.[ResponseState]
      ,bt.[TransactionState]
      ,bt.[RequestId]
      ,bt.[TransactionId]
      ,bt.[IsBillable]
      ,bt.[UserId]
      ,bt.[Username]
      ,bt.[FirstName]
      ,bt.[LastName]
      ,bt.[HasTransactions]
      ,bt.[BillingId]
      ,bt.[StageBillingId]
      ,bt.[PreBillingId]

	FROM [Billing].[dbo].[BillingTransaction] bt
	INNER JOIN [Billing].[dbo].[AccountMeta] acc on bt.AccountNumber = acc.AccountNumber
	WHERE bt.Type = 'StageBilling' AND 
	bt.Created >= @StartDate AND bt.Created <= @EndDate

	ORDER BY bt.Created
END
GO
