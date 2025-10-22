USE AdventureWorks2019
GO
-- 1.How many products can you find in the Production.Product table?
Select COUNT(*) AS numProducts
FROM Production.Product

--2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
--The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(ProductSubcategoryID) AS numProducts
FROM Production.Product

--3 How many Products reside in each SubCategory? Write a query to display the results with the following titles.
--ProductSubcategoryID CountedProducts
SELECT ProductSubcategoryID, COUNT(ProductSubcategoryID) as numProducts
FROM Production.Product
GROUP BY ProductSubcategoryID

--4 How many products that do not have a product subcategory.
SELECT COUNT(*) AS numProductsWithoutSubcategory
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;

--5 Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT ProductID, SUM(Quantity) as sum_of_products
FROM Production.ProductInventory
GROUP BY ProductID

--6 Write a query to list the sum of products in the Production.ProductInventory table and LocationID 
--set to 40 and limit the result to include just summarized quantities less than 100.
--              ProductID    TheSum

--              -----------        ----------
SELECT ProductID, SUM(Quantity) as TheSum
FROM Production.ProductInventory
WHERE LocationID = 40 
GROUP BY ProductID
HAVING SUM(Quantity) < 100

--7 Write a query to list the sum of products with the shelf information in the Production.ProductInventory 
--table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

--    Shelf      ProductID    TheSum

--    ----------   -----------        -----------
SELECT Shelf, ProductID, SUM(Quantity) as TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100

--8 Write the query to list the average quantity for products where column LocationID has the value of 10 from 
--the table Production.ProductInventory table.

SELECT ProductID, AVG(Quantity) as TheAvg
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID

--9 Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

--    ProductID   Shelf      TheAvg

--    ----------- ---------- -----------

SELECT ProductID, SHELF, AVG(Quantity) as TheAvg
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID, SHELF

--10 Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in 
--the column Shelf from the table Production.ProductInventory

--    ProductID   Shelf      TheAvg

 ---   ----------- ---------- -----------

SELECT ProductID, SHELF, AVG(Quantity) as TheAvg
FROM Production.ProductInventory
WHERE SHELF != 'N/A'
GROUP BY ProductID, SHELF
ORDER BY ProductID

--11 List the members (rows) and average list price in the Production.Product table. This should be grouped 
--independently over the Color and the Class column. Exclude the rows where Color or Class are null.

  --  Color                        Class              TheCount          AvgPrice

   -- -------------- - -----    -----------            ---------------------

SELECT Color, Class, Count(Color) TheCount, AVG(ListPrice) AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class

--12 Write a query that lists the country and province names from person. CountryRegion and person. 
--StateProvince tables. Join them and produce a result set similar to the following.

--    Country                        Province

--    ---------                          ----------------------

SELECT c.Name Country, s.Name Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode

--13   Write a query that lists the country and province names from person. CountryRegion and person. 
--StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce
--a result set similar to the following.

 --   Country                        Province

 --   ---------                          ----------------------

SELECT c.Name Country, s.Name Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.name in ('Germany','Canada')

USE Northwind
GO

--14 List all Products that has been sold at least once in last 27 years.
SELECT p.ProductID, p.ProductName, o.OrderDate
FROM dbo.Products p JOIN dbo.[Order Details] od ON p.ProductID = od.ProductID JOIN dbo.Orders o ON od.OrderID = o.orderID
WHERE o.OrderDate >= '1992-01-01'

--15 List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) total
FROM dbo.[Order Details] od JOIN dbo.Orders o ON od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY total DESC

--16 List top 5 locations (Zip Code) where the products sold most in last 27 years.
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) total
FROM dbo.[Order Details] od JOIN dbo.Orders o ON od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL AND o.OrderDate >= '1992-01-01' AND o.OrderDate <= '2019-12-31'
GROUP BY o.ShipPostalCode
ORDER BY total DESC

--17 List all city names and number of customers in that city. 
SELECT City, COUNT(CustomerID) as numCustomers
FROM dbo.Customers customers
GROUP BY CITY

--18 List city names which have more than 2 customers, and number of customers in that city
SELECT City, COUNT(CustomerID) as numCustomers
FROM dbo.Customers customers
GROUP BY CITY
HAVING COUNT(CustomerID) > 2

--19.  List the names of customers who placed orders after 1/1/98 with order date.
SELECT c.ContactName, o.OrderDate
FROM dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'

--20.  List the names of all customers with most recent order dates
SELECT c.ContactName, MAX(o.OrderDate) mostRecentOrder
FROM dbo.Customers c LEFT JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

--21 Display the names of all customers  along with the  count of products they bought
SELECT c.ContactName, SUM(od.Quantity) numProductsBought
FROM dbo.Customers c LEFT JOIN dbo.Orders o ON c.CustomerID = o.CustomerID JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName

--22 Display the customer ids who bought more than 100 Products with count of products.
SELECT c.CustomerID, SUM(od.Quantity) numProductsBought
FROM dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING SUM(od.Quantity) > 100

--23 List all of the possible ways that suppliers can ship their products. Display the results as below

--    Supplier Company Name                Shipping Company Name

--    ---------------------------------            ----------------------------------
SELECT DISTINCT sup.CompanyName, ship.CompanyName
FROM dbo.Shippers ship join dbo.Orders o ON ship.ShipperID = o.ShipVia join dbo.[Order Details] od ON od.OrderID = o.OrderID join dbo.Products p ON p.ProductID = od.ProductID join dbo.Suppliers sup ON sup.SupplierID = p.SupplierID

--24 Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM dbo.Products p join dbo.[Order Details] od ON p.ProductID = od.ProductID JOIN dbo.Orders o ON od.OrderID = o.OrderID

--25 Displays pairs of employees who have the same job title.

SELECT e1.FirstName + ' ' + e1.LastName as Employee1 , e2.FirstName + ' ' + e2.LastName as Employee2
FROM dbo.Employees e1 join dbo.Employees e2 on e1.Title = e2.Title
WHERE e1.EmployeeID < e2.EmployeeID

--26.  Display all the Managers who have more than 2 employees reporting to them.

SELECT e2.FirstName + ' ' + e2.LastName AS Manager, COUNT(e1.EmployeeID) AS NumTeamMembers
FROM dbo.Employees e1 JOIN dbo.Employees e2 ON e1.ReportsTo = e2.EmployeeID
GROUP BY e2.FirstName + ' ' + e2.LastName
HAVING COUNT(e1.EmployeeID) > 2

--27 Display the customers and suppliers by city. The results should have the following columns

--City

--Name

--Contact Name,

--Type (Customer or Supplier)

SELECT City, CompanyName, ContactName, 'Customer' AS Type
FROM dbo.Customers

UNION ALL

SELECT city, CompanyName, ContactName, 'Supplier' AS Type
FROM DBO.Suppliers
ORDER BY City, Type, CompanyName