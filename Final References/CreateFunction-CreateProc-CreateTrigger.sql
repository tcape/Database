USE MyGuitarShop

GO
CREATE PROC dbo.sp_InsertCategory(@categoryName varchar(255))
AS
BEGIN
	INSERT Categories (CategoryName)
	VALUES (@categoryName)
END

GO

EXEC sp_InsertCategory 'Pro Audio'
EXEC sp_InsertCategory 'DJ'

SELECT * from Categories

GO
CREATE FUNCTION dbo.fn_DiscountPrice (@item_id int)
RETURNS money
AS
BEGIN
	RETURN
	(SELECT (ItemPrice - DiscountAmount) FROM OrderItems
	WHERE ItemID = @item_id)
END
GO
	
--SELECT dbo.fn_DiscountPrice (5)

SELECT * from OrderItems
	
GO

CREATE FUNCTION dbo.fn_ItemTotal (@item_id int)
RETURNS money
AS
BEGIN
	DECLARE @discountPrice money
	SET @discountPrice = dbo.fn_DiscountPrice(@item_id)
	RETURN @discountPrice * 
	(SELECT Quantity FROM OrderItems
	WHERE ItemID = @item_id)
END
GO

SELECT dbo.fn_ItemTotal(5)

--DROP PROC dbo.sp_InsertProduct
GO

CREATE PROC dbo.sp_InsertProduct(
	@category_id int,
	@product_code varchar(10), 
	@product_name varchar(255), 
	@list_price money, 
	@discount_percent money)
AS
BEGIN
	IF (@list_price < 0)
		BEGIN
			RAISERROR('List Price cannot be negative', 16, 1)
			RETURN
		END
	IF (@discount_percent < 0)
		BEGIN
			RAISERROR('Discount Percent cannot be negative', 16, 1)
			RETURN
		END
	INSERT Products (CategoryID, ProductCode, ProductName, Description, ListPrice, DiscountPercent, DateAdded)
	VALUES (@category_id, @product_code, @product_name, '', @list_price, @discount_percent, GETDATE())
END
GO

EXEC dbo.sp_InsertProduct 3, 'testCode1', 'testName1',  99.99, 20; -- good

EXEC dbo.sp_InsertProduct 2, 'testCode2', 'testName2', 299.99, -25; -- bad

EXEC dbo.sp_InsertProduct 1, 'testCode3', 'testName3', -299.99, 30; -- bad

--SELECT * FROM Products

GO

CREATE PROC dbo.sp_UpdateProductDiscount (@product_id int, @discount_percent money)
AS
BEGIN
	IF (@discount_percent < 0)
		BEGIN
			RAISERROR('Discount Percent cannot be negative', 16, 1)
			RETURN
		END
	UPDATE Products
	SET DiscountPercent = @discount_percent
	WHERE ProductID = @product_id
END
GO

EXEC dbo.sp_UpdateProductDiscount 1, 50; -- good

EXEC dbo.sp_UpdateProductDiscount 2, -25; -- bad

GO



CREATE TRIGGER dbo.tr_Products_UPDATE ON Products FOR UPDATE
AS
BEGIN
	IF(EXISTS(SELECT DiscountPercent FROM inserted WHERE DiscountPercent < 0) OR
		EXISTS(SELECT DiscountPercent FROM inserted WHERE DiscountPercent > 100))
		BEGIN
			RAISERROR('DiscountPercent must be between 0 and 100', 16, 1);
			ROLLBACK TRAN
			RETURN
		END
	IF(EXISTS(SELECT DiscountPercent FROM inserted WHERE DiscountPercent > 0) AND
		EXISTS(SELECT DiscountPercent FROM inserted WHERE DiscountPercent < 1))
		BEGIN
			UPDATE Products
			SET DiscountPercent = DiscountPercent * 100
			WHERE DiscountPercent < 1 AND DiscountPercent > 0
		END
END

GO	


EXEC dbo.sp_UpdateProductDiscount 1, .1 -- good

EXEC dbo.sp_UpdateProductDiscount 2, 300 -- bad

SELECT * FROM Products

--DROP TRIGGER dbo.tr_Products_INSERT

GO

CREATE TRIGGER dbo.tr_Products_INSERT ON Products FOR INSERT
AS
BEGIN
	IF(EXISTS(SELECT DateAdded FROM inserted WHERE DateAdded IS NULL))
	BEGIN
		
		UPDATE Products
		SET DateAdded = GETDATE()
		WHERE DateAdded IS NULL
	END
END

GO

INSERT INTO Products (CategoryID, ProductCode, ProductName, Description, ListPrice, DiscountPercent, DateAdded)
VALUES (1, 'explorer', 'Gibson Explorer', '', 999.99, 25, NULL)
SELECT * FROM Products


--DROP TABLE ProductsAudit

CREATE TABLE ProductsAudit(
	AuditID			int				IDENTITY,
	ProductID		int				NOT NULL,
	CategoryID		int				NOT NULL,
	ProductCode		varchar(10)		NOT NULL	UNIQUE,
	ProductName		varchar(255)	NOT NULL,
	ListPrice		money			NOT NULL,
	DiscountPercent	money			NOT NULL	DEFAULT 0.00,
	DateUpdated		datetime		NOT NULL,
	CONSTRAINT PK_ProductsAudit		PRIMARY KEY (AuditID)
);

GO

CREATE TRIGGER dbo.tr_Product_UPDATE ON Products AFTER UPDATE
AS
	BEGIN
		INSERT INTO ProductsAudit(ProductID, CategoryID, ProductCode, ProductName, ListPrice, DiscountPercent, DateUpdated)
		SELECT ProductID, CategoryID, ProductCode, ProductName, ListPrice, DiscountPercent, GETDATE() FROM deleted
	END

UPDATE Products
SET DiscountPercent = 30
WHERE ProductID = 1

SELECT * FROM ProductsAudit




