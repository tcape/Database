
---- SLIDE 5
--SELECT FirstName, LastName, Salary
--FROM Employees
--WHERE Salary = 
--  (SELECT MAX(Salary) FROM Employees)


--SELECT FirstName, LastName, DepartmentID, Salary
--FROM Employees
--WHERE DepartmentID IN 
--  (SELECT DepartmentID FROM Departments
--   WHERE Name='Sales')


---- SLIDE 6

--SELECT FirstName, LastName, DepartmentID, Salary
--FROM Employees e
--WHERE Salary = 
--  (SELECT MAX(Salary) FROM Employees 
--   WHERE DepartmentID = e.DepartmentID)
--ORDER BY DepartmentID

---- SLIDE 7

--SELECT FirstName, LastName, EmployeeID, ManagerID
--FROM Employees e
--WHERE EXISTS
--  (SELECT EmployeeID
--   FROM Employees m
--   WHERE m.EmployeeID = e.ManagerID
--     AND m.DepartmentID = 1)


---- SLIDE 11
--SELECT
--  AVG(Salary) [Average Salary],
--  MAX(Salary) [Max Salary],
--  MIN(Salary) [Min Salary],
--  SUM(Salary) [Salary Sum]
--FROM Employees
--WHERE JobTitle = 'Design Engineer'

---- SLIDE 12
--SELECT MIN(HireDate) MinHD, MAX(HireDate) MaxHD
--FROM Employees

--SELECT MIN(LastName), MAX(LastName)
--FROM Employees

---- SLIDE 13
--SELECT COUNT(*) Cnt FROM Employees
--WHERE DepartmentID = 3

--SELECT COUNT(ManagerID) MgrCount,
--  COUNT(*) AllCount
--FROM Employees
--WHERE DepartmentID = 16


---- SLIDE 14
--SELECT AVG(ManagerID) Avg,
--  SUM(ManagerID) / COUNT(*) AvgAll
--FROM Employees

---- SLIDE 15
--SELECT e.FirstName, e.LastName, e.HireDate, d.Name
--FROM Employees e 
--  JOIN Departments d
--    ON e.DepartmentID = d.DepartmentID
--WHERE e.HireDate = 
--  (SELECT MIN(HireDate) FROM Employees 
--   WHERE DepartmentID = d.DepartmentID)

---- SLIDE 19 
--SELECT DepartmentID, SUM(Salary) as SalariesCost
--FROM Employees
--GROUP BY DepartmentID


---- SLIDE 21
--SELECT DepartmentID, JobTitle, 
--  SUM(Salary) as Salaries, COUNT(*) as Count
--FROM Employees
--GROUP BY DepartmentID, JobTitle

---- SLIDE 23
--SELECT DepartmentID, JobTitle, 
--  SUM(Salary) AS Cost, MIN(HireDate) as StartDate
--FROM Employees
--GROUP BY DepartmentID, JobTitle


---- SLIDE 24
--SELECT DepartmentID, COUNT(EmployeeID) as
--  Count, AVG(Salary) AverageSalary
--FROM Employees
--GROUP BY DepartmentID
--HAVING COUNT(EmployeeID) BETWEEN 3 AND 5


---- SLIDE 25
--SELECT COUNT(*) AS EmpCount, d.Name AS DeptName
--FROM Employees e JOIN Departments d
--    ON e.DepartmentID = d.DepartmentID
--WHERE e.HireDate BETWEEN '1999-2-1' AND '2002-12-31'
--GROUP BY d.Name
--HAVING COUNT(*) > 5
--ORDER BY EmpCount DESC


---- SLIDE 28
--SELECT Name AS [Projects Name], 
--  ISNULL(EndDate, GETDATE()) AS [End Date]
--FROM Projects


---- SLIDE 29
--SELECT LastName, LEN(LastName) AS LastNameLen,
--  UPPER(LastName) AS UpperLastName
--FROM Employees
--WHERE RIGHT(LastName, 3) = 'son'


---- SLIDE 31
--SELECT Name AS [Projects Name], 
--  COALESCE(CONVERT(nvarchar(50), EndDate), 
--  'Not Finished') AS [Date Finished]
--FROM Projects


---- SLIDE 34
--CREATE TABLE Persons (
--  PersonID int IDENTITY,
--  Name nvarchar(100) NOT NULL,
--  CONSTRAINT PK_Persons PRIMARY KEY(PersonID)
--)
--GO
--CREATE VIEW [First 10 Persons] AS
--SELECT TOP 10 Name FROM Persons

---- SLIDE 35
--CREATE TABLE Countries (
--  CountryID int IDENTITY,
--  Name nvarchar(100) NOT NULL,
--  CONSTRAINT PK_Countries PRIMARY KEY(CountryID)
--)
--GO
--CREATE TABLE Cities (
--  CityID int IDENTITY,
--  Name nvarchar(100) NOT NULL,
--  CountryID int NOT NULL,
--  CONSTRAINT PK_Cities PRIMARY KEY(CityID)
--)


---- SLIDE 36
---- Add a foreign key constraint Cities --> Country
--ALTER TABLE Cities
--ADD CONSTRAINT FK_Cities_Countries
--  FOREIGN KEY (CountryID)
--  REFERENCES Countries(CountryID)
---- Add column Population to the table Country
--ALTER TABLE Countries ADD Population int
---- Remove column Population from the table Country
--ALTER TABLE Countries DROP COLUMN Population


---- SLIDE 37
--DROP TABLE Persons
--ALTER TABLE Cities
--DROP CONSTRAINT FK_Cities_Countries


---- SLIDE 41
--CREATE TABLE Groups (
--  GroupID int IDENTITY,
--  Name nvarchar(100) NOT NULL,
--  CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
--)

--CREATE TABLE Users (
--  UserID int IDENTITY,
--  UserName nvarchar(100) NOT NULL,
--  GroupID int NOT NULL,
--  CONSTRAINT PK_Users PRIMARY KEY(UserID),
--  CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupID)
--    REFERENCES Groups(GroupID)
--)


---- SLIDE 44
--BEGIN TRAN
--DELETE FROM EmployeesProjects;
--DELETE FROM Projects;
--ROLLBACK TRAN


---- SLIDE 45
--SET IMPLICIT_TRANSACTIONS ON

--exec sp_columns Employees;

--SELECT CONCAT(e.FirstName, ' ',e.LastName) AS [Full Name]
--	, e.Salary
--	, d.Name
--FROM Employees e
--	JOIN Departments d
--		ON e.DepartmentID = d.DepartmentID
--WHERE e.Salary = 
--		(SELECT MIN(Salary) FROM Employees emp
--		WHERE e.DepartmentID = emp.DepartmentID)

SELECT *
FROM employees

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
	, ISNULL(m.FirstName + ' ' + m.LastName, 'No Manager') AS [Mgr Name]
FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID

	
				

