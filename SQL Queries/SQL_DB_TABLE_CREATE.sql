-- Create the Customer table
CREATE TABLE Customer (
    Customer_ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Email_Address VARCHAR(255)
);

-- Create the Product table
CREATE TABLE Product (
    Product_ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Description TEXT,
    Price DECIMAL(10, 2)
);

-- Create the Order table
CREATE TABLE Order (
    Order_ID INT PRIMARY KEY,
    Customer_ID INT,
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID)
);

-- Create the Order_Product table (junction table to represent the many-to-many relationship between Order and Product)
CREATE TABLE Order_Product (
    Order_ID INT,
    Product_ID INT,
    FOREIGN KEY (Order_ID) REFERENCES Order(Order_ID),
    FOREIGN KEY (Product_ID) REFERENCES Product(Product_ID)
);

-- Create the Payment_Method table
CREATE TABLE Payment_Method (
    Payment_Method_ID INT PRIMARY KEY,
    Customer_ID INT,
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID)
);

-- Insert values into the Customer table

INSERT INTO Customer (Customer_ID, Name, Email_Address)
VALUES
    (1, 'Eda Yavuz', 'e.yavuz@acsbg.org'),
    (2, 'Jane Smith', 'jane.smith@email.com'),
    (3, 'Bob Johnson', 'bob.johnson@email.com');

-- Insert values into the Product table
INSERT INTO Product (Product_ID, Name, Description, Price)
VALUES
    (101, 'Water Bottle', 'Description for Product A', 39.99),
    (102, 'TV Remote', 'Description for Product B', 29.99),
    (103, 'Socks', 'Description for Product C', 9.99);

-- Insert values into the Order table
INSERT INTO Order (Order_ID, Customer_ID)
VALUES
    (1001, 1),
    (1002, 2),
    (1003, 3);

-- Insert values into the Order_Product table
INSERT INTO Order_Product (Order_ID, Product_ID)
VALUES
    (1001, 101),
    (1001, 102),
    (1002, 102),
    (1003, 103);

-- Insert values into the Payment_Method table
INSERT INTO Payment_Method (Payment_Method_ID, Customer_ID)
VALUES
    (201, 1),
    (202, 2),
    (203, 3);
