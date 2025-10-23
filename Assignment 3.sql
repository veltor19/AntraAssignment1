USE Northwind
GO

--1 List all cities that have both Employees and Customers.
SELECT DISTINCT e.City
FROM Employees e JOIN Customers c ON e.city = c.city
-- 2 List all cities that have Customers but no Employee.

--a.      Use sub-query

--b.      Do not use sub-query

SELECT DISTINCT City
FROM Customers
WHERE City NOT IN (
	SELECT DISTINCT City
	FROM Employees
	)

SELECT DISTINCT c.City
FROM Customers c LEFT JOIN Employees e ON c.city = e.city
WHERE e.EmployeeID IS NULL

--3  List all products and their total order quantities throughout all orders.
SELECT p.ProductID, ProductName, SUM(od.Quantity) as totalQuantitity
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID
GROUP BY p.ProductID, ProductName

--4. List all Customer Cities and total products ordered by that city.
SELECT c.City, sum(od.Quantity) TotalProducts
FROM dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City

-- 5. List all Customer Cities that have at least two customers.
SELECT City
FROM dbo.Customers
GROUP BY City
HAVING COUNT(City) >= 2

-- 6 List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City, COUNT(DISTINCT od.productID) as NumOfDifferentProducts
FROM dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.productID) >= 2

--7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities
SELECT Distinct c.CustomerID, c.ContactName
FROM dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
WHERE c.City != o.ShipCity

--8 List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
SELECT TOP 5
    p.ProductID,
    p.ProductName,
    AVG(od.UnitPrice) as AvgPrice,
    SUM(od.Quantity) as TotalQuantity,
    (
        SELECT TOP 1 o.ShipCity
        FROM Orders o
        JOIN [Order Details] od2 ON o.OrderID = od2.OrderID
        WHERE od2.ProductID = p.ProductID
        GROUP BY o.ShipCity
        ORDER BY SUM(od2.Quantity) DESC
    ) as TopCustomerCity
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY SUM(od.Quantity) DESC;

--9 List all cities that have never ordered something but we have employees there.

--a.      Use sub-query

--b.      Do not use sub-query

SELECT DISTINCT e.City
FROM Employees e
WHERE e.City NOT IN (
    SELECT DISTINCT o.ShipCity
    FROM Orders o
    WHERE o.ShipCity IS NOT NULL
)

SELECT DISTINCT e.City
FROM Employees e 
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.OrderID IS NULL

--10 List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, 
--and also the city of most total quantity of products ordered from. (tip: join  sub-query)

SELECT TOP 1 EmployeeCities.City
FROM (
    -- Subquery 1: Find the city of the employee who sold the most orders
    SELECT TOP 1 e.City
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.EmployeeID, e.City
    ORDER BY COUNT(o.OrderID) DESC
) AS EmployeeCities
JOIN (
    -- Subquery 2: Find the city that ordered the most total quantity
    SELECT TOP 1 o.ShipCity AS City
    FROM Orders o
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY o.ShipCity
    ORDER BY SUM(od.Quantity) DESC
) AS CustomerCities ON EmployeeCities.City = CustomerCities.City

--11 we could do a self join

