USE master;
GO

IF DB_ID('MyWebDB') IS NOT NULL
DROP DATABASE MyWebDB;
GO

CREATE DATABASE MyWebDB;
GO

USE MyWebDB;

	 --Create tables --

CREATE TABLE Users(
	UserID			int				PRIMARY KEY		IDENTITY,
	EmailAddress	nvarchar(255)	NOT NULL		UNIQUE,
	FirstName		nvarchar(60)	NOT NULL,
	LastName		nvarchar(60)	NOT NULL
);

CREATE TABLE Products(
	ProductID		int				PRIMARY KEY		IDENTITY,
	ProductName		nvarchar(255)	NOT NULL
);
	
CREATE TABLE Downloads(
	DownloadID		int				PRIMARY KEY		IDENTITY,
	UserID			int				FOREIGN KEY		REFERENCES Users(UserID),
	ProductID		int				FOREIGN KEY		REFERENCES Products(ProductID),
	DownloadDate	datetime		DEFAULT NULL,
	FileName		nvarchar(255)	NOT NULL
);

INSERT INTO Users VALUES
('joeshmoe@gmail.com', 'Joe', 'Shmoe'),
('bobsmith@gmail.com', 'Bob', 'Smith');

INSERT INTO Products VALUES
('Unity'),
('Unreal 4');

INSERT INTO Downloads (UserID, ProductID, DownloadDate, FileName) VALUES
(1, 2, GETDATE(), 'Unreal4.zip'), 
(2, 1, GETDATE(), 'Unity.zip'),
(2, 2, GETDATE(), 'Unreal4.zip');

SELECT u.EmailAddress, u.FirstName, u.LastName, d.DownloadDate, d.FileName, p.ProductName
FROM Users u JOIN Downloads d
	ON u.UserID = d.UserID
	JOIN Products p
	ON p.productID = d.productID
ORDER BY u.EmailAddress DESC, p.ProductName

ALTER TABLE Products
ADD Price		decimal(3, 2)	NOT NULL	DEFAULT 9.99;

ALTER TABLE Products
ADD DateAdded	datetime		DEFAULT GETDATE();

ALTER TABLE Users
ALTER COLUMN FirstName	nvarchar(20)	NOT NULL;

UPDATE Users
SET FirstName = NULL
WHERE UserID = 1;

UPDATE Users
SET FirstName = 'Supercalifragilisticexpialidocious'
WHERE UserID = 1;





