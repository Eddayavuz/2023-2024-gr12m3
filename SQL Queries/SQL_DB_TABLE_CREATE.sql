-- AFTER CREATING THE DB (OnlineShopping) MANUALLY OB THE OBJECT EXPLORER RIGHT CLICK ON THE DB AND CLICK NEW QUERY --
-- THEN FIRST, EXECUTE THE COMMANDS FOR CREATING THE TABLES, AFTER EXECUTE THE COMMANDS FOR INSERTING RECORDS TO THE TABLES --
    
-- Create the Customer table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(255),
    Email VARCHAR(255)
);

-- Create the Product table
CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(255),
    ProductDescription TEXT,
    Price MONEY
);

-- Create the Order table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
);

-- Create the Order_Product table (junction table to represent the many-to-many relationship between Order and Product)
CREATE TABLE Order_Product (
    OrderID INT,
    ProductID INT
);

-- Create the Payment_Method table
CREATE TABLE Payment_Method (
    PaymentMethodID INT PRIMARY KEY,
    CustomerID INT
);

-- Insert values into the Customer table

INSERT INTO Customers (CustomerID, FirstName, Email)
VALUES
    (1, 'Eda Yavuz', 'e.yavuz@acsbg.org'),
    (2, 'Jane Smith', 'jane.smith@email.com'),
    (3, 'Bob Johnson', 'bob.johnson@email.com');

-- Insert values into the Product table
INSERT INTO Product (ProductID, ProductName, ProductDescription, Price)
VALUES
    (101, 'Water Bottle', 'Description for Product A', 39.99),
    (102, 'TV Remote', 'Description for Product B', 29.99),
    (103, 'Socks', 'Description for Product C', 9.99);

-- Insert values into the Order table
INSERT INTO Orders (OrderID, CustomerID)
VALUES
    (1001, 1),
    (1002, 2),
    (1003, 3);

-- Insert values into the Order_Product table
INSERT INTO Order_Product (OrderID, ProductID)
VALUES
    (1001, 101),
    (1001, 102),
    (1002, 102),
    (1003, 103);

-- Insert values into the Payment_Method table
INSERT INTO Payment_Method (PaymentMethodID, CustomerID)
VALUES
    (201, 1),
    (202, 2),
    (203, 3);
