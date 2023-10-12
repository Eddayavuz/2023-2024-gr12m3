-- SELECT CustomerName FROM  dbo.Customers
-- SELECT CustomerName, Notes FROM  dbo.Customers
-- SELECT CustomerName as [Customer Name], Notes FROM  dbo.Customers
-- SELECT * FROM  dbo.Customers
-- SELECT TOP(3) FROM  dbo.Customers


/* SELECT * FROM dbo.Customers
WHERE State = 'WA' */

/* SELECT * FROM dbo.Customers
WHERE State != 'WA' */

/* SELECT * FROM dbo.Customers
WHERE State = 'WA' OR State = 'NY' or State = 'UT' */

/*SELECT *
FROM dbo.Customers
WHERE STATE IN('WA', 'NY', 'UT') */

/* SELECT *
FROM dbo.Customers
WHERE STATE NOT IN('WA', 'NY', 'UT') */

/* SELECT *
FROM Dbo.Customers
WHERE CustomerName = 'Tres Delicious' AND Country = 'UNITED STATES' */

/* SELECT *
FROM Dbo.Customers
WHERE CustomerName = 'Tres Delicious' AND Country = 'UNITED STATES' 
OR Country = 'FRANCE' */

/* SELECT *
FROM Dbo.Customers
WHERE CustomerName LIKE 'A%' AND Country = 'UNITED STATES' 
OR Country = 'FRANCE' */

SELECT *
FROM Dbo.Customers
WHERE CustomerName NOT LIKE 'A%' AND Country = 'UNITED STATES' 
OR Country = 'FRANCE'