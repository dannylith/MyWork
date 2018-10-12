IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StatesSelectAll')
      DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateId, StateName
	FROM States
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BathroomTypesSelectAll')
      DROP PROCEDURE BathroomTypesSelectAll
GO

CREATE PROCEDURE BathroomTypesSelectAll AS
BEGIN
	SELECT BathroomTypeId, BathroomTypeName
	FROM BathroomTypes
	ORDER BY BathroomTypeName
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsInsert')
      DROP PROCEDURE ListingsInsert
GO

CREATE PROCEDURE ListingsInsert (
	@ListingId int output,
	@UserId nvarchar(128),
	@StateId char(2),
	@BathroomTypeId int,
	@NIckname nvarchar(50),
	@City nvarchar(50),
	@Rate decimal(7,2),
	@SquareFootage decimal(7,2),
	@HasElectric bit,
	@HasHeat bit,
	@ImageFileName varchar(50)
)
AS
BEGIN
	INSERT INTO Listings(UserId, StateId, BathroomTypeId, Nickname, City, Rate, SquareFootage, HasElectric, HasHeat, ImageFileName)
	VALUES(@UserId, @StateId, @BathroomTypeId, @Nickname, @City, @Rate, @SquareFootage, @HasElectric, @HasHeat, @ImageFileName)

	SET @ListingId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsUpdate')
      DROP PROCEDURE ListingsUpdate
GO

CREATE PROCEDURE ListingsUpdate (
	@ListingId int,
	@UserId nvarchar(128),
	@StateId char(2),
	@BathroomTypeId int,
	@NIckname nvarchar(50),
	@City nvarchar(50),
	@Rate decimal(7,2),
	@SquareFootage decimal(7,2),
	@HasElectric bit,
	@HasHeat bit,
	@ImageFileName varchar(50)
)
AS
BEGIN
	UPDATE Listings SET UserId = @UserID, 
					StateId = @StateId, 
					BathroomTypeId = @BathroomTypeId, 
					Nickname = @Nickname, 
					City = @City, 
					Rate = @Rate, 
					SquareFootage = @SquareFootage, 
					HasElectric = @HasElectric, 
					HasHeat = @HasHeat, 
					ImageFileName = @ImageFileName
	WHERE ListingId = @ListingId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsDelete')
      DROP PROCEDURE ListingsDelete
GO

CREATE PROCEDURE ListingsDelete (
	@ListingId int)
AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Contacts WHERE ListingId = @ListingId;
	DELETE FROM Favorites WHERE ListingId = @ListingId;
	DELETE FROM Listings WHERE ListingId = @ListingId;
	
	COMMIT TRANSACTION
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelect')
      DROP PROCEDURE ListingsSelect
GO

CREATE PROCEDURE ListingsSelect (
	@ListingId int)
AS
BEGIN
	SELECT ListingId, UserId, StateId, BathroomTypeId, Nickname, City, Rate, SquareFootage, HasElectric, HasHeat, ImageFileName
	FROM Listings
	WHERE ListingId = @ListingId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectRecent')
      DROP PROCEDURE ListingsSelectRecent
GO

CREATE PROCEDURE ListingsSelectRecent AS
BEGIN
	SELECT TOP 5 ListingId, UserId, Rate, City, StateId, ImageFileName
	FROM Listings
	ORDER BY CreatedDate DESC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectDetails')
      DROP PROCEDURE ListingsSelectDetails
GO

CREATE PROCEDURE ListingsSelectDetails
(
	@ListingId int
)
 AS
BEGIN
	SELECT ListingId, UserId, Nickname, City, StateId, Rate, SquareFootage, HasElectric, HasHeat, l.BathroomTypeId, BathroomTypeName, ImageFileName
	FROM Listings l
		INNER JOIN BathroomTypes b ON l.BathroomTypeId = b.BathroomTypeId
	WHERE ListingId = @ListingId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectFavorites')
      DROP PROCEDURE ListingsSelectFavorites
GO

CREATE PROCEDURE ListingsSelectFavorites
(
	@UserId nvarchar(128)
)
 AS
BEGIN
SELECT l.ListingId, l.City, l.StateId, l.Rate, l.SquareFootage, l.HasElectric, l.HasHeat, b.BathroomTypeName
FROM Favorites f
	INNER JOIN Listings l ON f.ListingId = l.ListingId
	INNER JOIN BathroomTypes b ON l.BathroomTypeId = b.BathroomTypeId
WHERE f.UserId = @UserId;

END
GO
