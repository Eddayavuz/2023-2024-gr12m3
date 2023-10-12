Select * from dbo.Orders
where OrderDate >= DATEADD(year, -2, getdate())

Select count(*) from dbo.Orders
where OrderDate >=  DATEADD(year, -2, getdate())

Select sum(OrderTotal) from dbo.Orders
where OrderDate >=  DATEADD(year, -2, getdate())
group by CustomerID