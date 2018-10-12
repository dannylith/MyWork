IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Favorites;
	DELETE FROM Listings
	DELETE FROM States;
	DELETE FROM BathroomTypes;
	DELETE FROM AspNetUsers WHERE id IN ('00000000-0000-0000-0000-000000000000', '11111111-1111-1111-1111-111111111111')

	DBCC CHECKIDENT ('listings', RESEED, 1)

	INSERT INTO States (StateId, StateName)
	VALUES ('OH', 'Ohio'),
	('KY', 'Kentucky'),
	('MN', 'Minnesota')

	SET IDENTITY_INSERT BathroomTypes ON;

	INSERT INTO BathroomTypes (BathroomTypeId, BathroomTypeName)
	VALUES (1, 'Indoor'),
	(2, 'Outdoor'),
	(3, 'None')

	SET IDENTITY_INSERT BathroomTypes OFF;

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, StateId, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES ('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 'OH', 0,0,0,'test')

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, StateId, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES ('11111111-1111-1111-1111-111111111111', 0, 0, 'test2@test.com', 'OH', 0,0,0,'test2')

	SET IDENTITY_INSERT Listings ON;
	INSERT INTO Listings(ListingId, UserId, StateId, BathroomTypeId, Nickname, City, Rate, SquareFootage, HasElectric, HasHeat, ImageFileName)
	VALUES (1, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 1', 'Cleveland', 100, 400, 0, 1, 'placeholder.png'),
	 (2, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 2', 'Cleveland', 110, 410, 0, 1, 'placeholder.png'),
	 (3, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 3', 'Cleveland', 120, 420, 0, 1, 'placeholder.png'),
	 (4, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 4', 'Cleveland', 130, 430, 0, 1, 'placeholder.png'),
	 (5, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 5', 'Cleveland', 140, 440, 0, 1, 'placeholder.png'),
	 (6, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test shack 6', 'Cleveland', 150, 450, 0, 1, 'placeholder.png')
	SET IDENTITY_INSERT Listings OFF;

	INSERT INTO Favorites(ListingId, UserId)
	VALUES(1,'11111111-1111-1111-1111-111111111111'),
	(2, '11111111-1111-1111-1111-111111111111')
END
