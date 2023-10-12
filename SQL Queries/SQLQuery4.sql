SELECT TOP (1000) [OrderID]
      ,[OrderDate]
      ,[CustomerID]
      ,[OrderTotal]
  FROM [KCC].[dbo].[Orders]
  --WHERE OrderTotal > 1000
  --WHERE OrderTotal BETWEEN 1000 AND 2000