----- JOINS -------
/*
SELECT OrderId, 
OrderDate, 
OrderTotal,
CustomerName,
Phone
From dbo.Orders
Inner Join dbo.Customers on dbo.Orders.CustomerID = dbo.Customers.CustomerID 
*/


------ USING ALIAS -------
/* SELECT OrderId, 
OrderDate, 
OrderTotal,
CustomerName,
Phone
From dbo.Orders o
Inner Join dbo.Customers c on o.CustomerID = c.CustomerID --an inner join  gives us all the customers back who have an order,  
--and it also gives us back all orders that have a customer associated with it.
*/
