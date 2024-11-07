-- A JOIN clause is used to combine rows from two or more tables, based on a related column between them.
-- We know that Orders and Customers tables are related.
-- The relationship between the two tables is the "CustomerID" column.

-- Then, we can create the following SQL statement (that contains an INNER JOIN), 
-- that selects records that have matching values in both tables:

SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate, Customers.Country
FROM Orders INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID;

-- DIFFERENT TYPES OF SQL JOINs 

-- (INNER) JOIN: Returns records that have matching values in both tables
-- LEFT (OUTER) JOIN: Returns all records from the left table, and the matched records from the right table
-- RIGHT (OUTER) JOIN: Returns all records from the right table, and the matched records from the left table
-- FULL (OUTER) JOIN: Returns all records when there is a match in either left or right table

-- INNER JOIN: 
-- Retrieve the names of customers with the count of orders they have placed (only for the matching value)
SELECT Customers.CustomerName, COUNT(Orders.OrderID) AS OrderCount
FROM Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerName

-- LEFT JOIN: 
-- Retrieve the names of all the customers from Customers(left table) 
-- and the order count from the Orders (right table). Display 0 or null when the customer is without any orders.
SELECT Customers.CustomerName, COUNT(Orders.OrderID) AS OrderCount
FROM Orders RIGHT JOIN Customers ON  Customers.CustomerID = Orders.CustomerID 
GROUP BY Customers.CustomerName

-- RIGHT JOIN:
-- Get a report of all orders with their Shipper information. 
-- Include ShipperName, Phone, OrderID and OrderDate
-- If there is a shipper that is not assigned to an order, still show the shipper details.

SELECT Shippers.ShipperName, Shippers.Phone, Orders.OrderID, Orders.OrderDate
From Orders RIGHT JOIN Shippers ON Orders.ShipperID = Shippers.ShipperID

-- CREATE A NEW TABLE USING TWO DIFFERENT TABLES

SELECT 
Shippers.ShipperName, Orders.OrderID
INTO DeliverySummary
FROM Shippers
INNER JOIN Orders ON Shippers.ShipperID = Orders.ShipperID
