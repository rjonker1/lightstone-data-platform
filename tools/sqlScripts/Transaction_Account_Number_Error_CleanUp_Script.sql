
SELECT *
  FROM [Billing].[dbo].[Transaction]
  WHERE AccountNumber like '{"error%'
  ORDER BY Date DESC

  --CustomApp Error Requests--
  UPDATE
  [Billing].[dbo].[Transaction]
  SET AccountNumber = 'Cus00006'
  WHERE ContractId like '89EE%'AND
  AccountNumber like '{"error%'

  --LightstoneAuto Error Requests--
  UPDATE
  [Billing].[dbo].[Transaction]
  SET AccountNumber = 'Lig00001'
  WHERE ContractId like 'F2C93%' AND
  AccountNumber like '{"error%'

  --AllMyStuff Error Requests--
  UPDATE
  [Billing].[dbo].[Transaction]
  SET AccountNumber = 'All00007'
  WHERE ContractId like 'B370EA%' AND
  AccountNumber like '{"error%'

  --Digicall Error Requests--
  UPDATE
  [Billing].[dbo].[Transaction]
  SET AccountNumber = 'Dig00004'
  WHERE ContractId like '43EE80%' AND
  AccountNumber like '{"error%'

   --ONEFinancial Error Requests--
  UPDATE
  [Billing].[dbo].[Transaction]
  SET AccountNumber = 'ONE00003'
  WHERE ContractId like '64D3FE%' AND
  AccountNumber like '{"error%'