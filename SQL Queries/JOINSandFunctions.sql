-- ALTER THE TABLES TO ADD FOREIGN KEY CONSTRAINTS
ALTER TABLE Orders
ADD FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID);

ALTER TABLE Orders
ADD FOREIGN KEY (ShipperID) REFERENCES Shippers(ShipperID);

--INSERT, UPDATE and DELETE Examples

INSERT INTO Shippers(ShipperID, ShipperName, Phone)
VALUES ('120', 'Speedy', '0700 17 001')


UPDATE Customers
SET Address = 'New address here'
WHERE CustomerName='Lonesome Pine Restaurant'

DELETE FROM Orders
WHERE CustomerID = '81'

-- A JOIN clause is used to combine rows from two or more tables, based on a related column between them.
-- We know that Orders and Customers tables are related.
-- The relationship between the two tables is the "CustomerID" column.

-- Then, we can create the following SQL statement (that contains an INNER JOIN), 
-- that selects records that have matching values in both tables:

SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate, Customers.Country
FROM Orders
INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID;

-- DIFFERENT TYPES OF SQL JOINs 

-- (INNER) JOIN: Returns records that have matching values in both tables
-- LEFT (OUTER) JOIN: Returns all records from the left table, and the matched records from the right table
-- RIGHT (OUTER) JOIN: Returns all records from the right table, and the matched records from the left table
-- FULL (OUTER) JOIN: Returns all records when there is a match in either left or right table

-- INNER JOIN EXAMPLE with COUNT and GROUP BY
SELECT Customers.CustomerName, COUNT(Orders.OrderID) AS OrderCount
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerName

-- MULTIPLE TABLE JOINS
SELECT O.OrderID, C.CustomerName, S.ShipperName
FROM Orders O
INNER JOIN Shippers S ON S.ShipperID = O.ShipperID
INNER JOIN Customers C ON O.CustomerID = C.CustomerID
GROUP BY C.CustomerName, S.ShipperName, O.OrderID


-- CREATE TABLE WITH SELECT INTO Structure

SELECT 
Shippers.ShipperName,
Orders.OrderID
INTO DeliverySummary
FROM Shippers
INNER JOIN Orders ON Shippers.ShipperID = Orders.ShipperID