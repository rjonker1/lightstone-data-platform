SELECT
	car.Car_ID as 'CarID',
	make.MakeName as 'Make',
	car.CarModel as 'Model',
	car.CarFullName as 'Car Full Name',
	s.Year_ID as 'Year',
	MAX(CASE s.Metric_ID WHEN (8) THEN cast(s.MoneyValue AS decimal(18,2)) WHEN isnull(s.Metric_ID, 0) then 0 END) as SalePriceNew,
	MAX(CASE s.Metric_ID WHEN (11) THEN cast(s.MoneyValue AS decimal(18,2)) WHEN isnull(s.Metric_ID, 0) then 0 END) as RetailValue,
	MAX(CASE s.Metric_ID WHEN (37) THEN cast(s.MoneyValue AS decimal(18,2)) ELSE 0 END) as TradeValue,
	MAX(CASE s.Metric_ID WHEN (41) THEN cast(s.MoneyValue AS decimal(18,2)) ELSE 0 END) as CostValue,
	MAX(CASE s.Metric_ID WHEN (45) THEN cast(s.MoneyValue AS decimal(18,2)) ELSE 0 END) as AuctionValue

FROM [Auto_Carstats].[dbo].[Car] as car
 INNER JOIN [Auto_Carstats].[dbo].[CarType] as carType on car.CarType_ID = carType.CarType_ID
 INNER JOIN [Auto_Carstats].[dbo].[Make] as make on carType.Make_ID = make.Make_ID
 INNER JOIN [Auto_Carstats].[dbo].[Statistics] as s on car.Car_ID = s.Car_ID

WHERE s.Year_ID IS NOT NULL AND
s.Year_ID > 100 AND
s.MoneyValue IS NOT NULL

GROUP BY car.Car_ID, s.Year_ID, make.MakeName, car.CarModel, car.CarFullName

ORDER BY Make, Model, Year