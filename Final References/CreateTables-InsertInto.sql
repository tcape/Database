USE master
GO

--Create Database--

CREATE DATABASE MovieDB
GO

USE MovieDB
GO

 --Create Tables--

CREATE TABLE Customers (
	CustID		int				PRIMARY KEY		IDENTITY	NOT NULL,
	LastName	nvarchar(50)	NOT NULL,
	FirstName	nvarchar(50)	NOT NULL 
);

CREATE TABLE Movies(
	MovieID		int				PRIMARY KEY		IDENTITY	NOT NULL,
	MovieName	nvarchar(100)	NOT NULL
);

CREATE TABLE Inventory(
	MediaID		int				PRIMARY KEY		IDENTITY	NOT NULL,
	MovieID		int				FOREIGN KEY		REFERENCES Movies (MovieID)
);

CREATE TABLE Suppliers(
	SupplierID		int				PRIMARY KEY		IDENTITY	NOT NULL,
	SupplierName	nvarchar(100)	NOT NULL
);	

CREATE TABLE MovieSupplier(
	SupplierID	int				FOREIGN KEY		REFERENCES Suppliers (SupplierID),
	MovieID		int				FOREIGN KEY		REFERENCES Movies (MovieID),
	Price		money			NOT NULL		DEFAULT 0.00
	CONSTRAINT	PK_SuppliersMovies	PRIMARY KEY	(SupplierID, MovieID)
);

CREATE TABLE Orders(
	OrderID		int				PRIMARY KEY		IDENTITY	NOT NULL,
	SupplierID	int				FOREIGN KEY		REFERENCES Suppliers (SupplierID),
	MovieID		int				FOREIGN KEY		REFERENCES Movies (MovieID),
	Copies		int				NOT NULL		DEFAULT 0
);

CREATE TABLE Rentals(
	CustomerID	int				FOREIGN KEY		REFERENCES Customers (CustID),
	MediaID		int				FOREIGN KEY		REFERENCES Inventory (MediaID),
	CkoutDate	datetime		DEFAULT NULL,
	Duration	int				NOT NULL		DEFAULT 0,
	CONSTRAINT PK_CustomersInventoryCkoutDate PRIMARY KEY (CustomerID, MediaID, CkoutDate)
);

 --Insert data into tables --

INSERT INTO	Customers VALUES
('Capehart', 'Tim'),
('Williams', 'Billy-Dee'),
('Jones', 'James-Earl'),
('Hamil', 'Mark'),
('Ford', 'Harrison');

INSERT INTO Movies VALUES
('The Phantom Menace'),
('The Clone Wars'),
('Revenge of the Sith'),
('A New Hope'),
('Empire Strikes Back'),
('Return of the Jedi'),
('The Force Awakens'),
('The Last Jedi');

INSERT INTO Inventory VALUES
(4),
(5),
(6),
(7),
(8);

INSERT INTO Suppliers VALUES
('Netflix'),
('Amazon'),
('20th Century Fox'),
('Blockbuster'),
('RedBox');

INSERT INTO MovieSupplier(SupplierID, MovieID, Price) VALUES
(1, 4, 9.99),
(2, 4, 8.99),
(4, 5, 3.99),
(5, 8, 10.99),
(3, 6, 12.00);

INSERT INTO Orders(SupplierID, MovieID, Copies) VALUES
(1, 4, 12),
(2, 4, 9),
(4, 5, 6),
(5, 8, 3),
(3, 6, 7);

INSERT INTO Rentals (CustomerID, MediaID, CkoutDate, Duration) VALUES
(1, 3, 20-10-2018, 3),
(2, 1, 18-10-2018, 4),
(3, 2, 22-10-2018, 2),
(4, 4, 17-10-2018, 5),
(5, 5, 09-10-2018, 6);
