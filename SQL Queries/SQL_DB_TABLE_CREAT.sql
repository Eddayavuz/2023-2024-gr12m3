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
