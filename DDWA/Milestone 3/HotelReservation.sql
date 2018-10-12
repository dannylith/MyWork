SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='HotelReservation')
		drop database HotelReservation
go

CREATE DATABASE HotelReservation
GO

USE HotelReservation
GO


CREATE TABLE RoomTypeRate(
	RoomTypeRateID INT IDENTITY(1,1) PRIMARY KEY,
	Price DECIMAL(6,2),
	StartDate datetime2,
	EndDate datetime2
)

CREATE TABLE RoomType(
	RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
	RoomName varchar(30),
	RoomTypeRateID INT
)


CREATE TABLE Room(
	RoomID INT IDENTITY(1,1) PRIMARY KEY,
	FloorNumber INT,
	OccupancyLimit INT,
	RoomTypeID INT
)

CREATE TABLE RoomAmenity(
	RoomID INT NOT NULL,
	AmenityID INT NOT NULL
)

CREATE TABLE Amenity(
	AmenityID INT IDENTITY(1,1) PRIMARY KEY,
	AmenityName varchar(30) NOT NULL
)

CREATE TABLE RoomReservation(
	ReservationID INT NOT NULL,
	RoomID INT NOT NULL,
	StartDate DATETIME2,
	EndDate DATETIME2
)

CREATE TABLE Reservation(
	ReservationID INT IDENTITY(1,1) PRIMARY KEY,
	PromotionID INT,
	CustomerID INT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	GuestID INT,
	BillID INT
)


CREATE TABLE Bill(
	BillID INT IDENTITY(1,1) PRIMARY KEY,
	TotalPrice DECIMAL(6,2),
	Tax DECIMAL(6,2),
	BillDetailsID INT
)

CREATE TABLE BillDetails(
	BillDetailsID INT IDENTITY(1,1) PRIMARY KEY,
	RoomTypeID INT,
	AddOnPrice DECIMAL(6,2),
	RoomPrice DECIMAL(6,2)
	
)

CREATE TABLE BillDetailsAddOn(
	BillDetailsID INT NOT NULL,
	AddOnID INT NOT NULL
)

CREATE TABLE ReservationAddOn(
	ReservationID INT NOT NULL,
	AddOnID INT	NOT NULL
)

CREATE TABLE ReservationCustomer(
	ReservationID INT NOT NULL,
	CustomerID INT NOT NULL
)


CREATE TABLE ReservationGuest(
	ReservationID INT NOT NULL,
	GuestID INT NOT NULL
)

CREATE TABLE AddOn(
	AddOnID INT IDENTITY(1,1) PRIMARY KEY,
	AddOnName varchar(30),
	AddOnRateID INT
)

CREATE TABLE AddOnRate(
	AddOnRateID INT IDENTITY(1,1) PRIMARY KEY,
	StartDate DATETIME2,
	EndDate DATETIME2,
	Price DECIMAL(6,2)
)

CREATE TABLE Customer(
	CustomerID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	Phone varchar(30),
	GuestID INT
)

CREATE TABLE Promotion(
	PromotionID INT IDENTITY(1,1) PRIMARY KEY,
	StartDate DATETIME2,
	EndDate DATETIME2,
	Discount DECIMAL(6,2)
)

CREATE TABLE Guest(
	GuestID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(30) NOT NULL,
	Lastname nvarchar(30) NOT NULL
)



ALTER TABLE RoomType 
ADD FOREIGN KEY (RoomTypeRateID) REFERENCES RoomTypeRate(RoomTypeRateID)

ALTER TABLE Room
ADD FOREIGN KEY (RoomTypeID) REFERENCES RoomType(RoomTypeID)

ALTER TABLE RoomAmenity
ADD PRIMARY KEY(RoomID, AmenityID),
	FOREIGN KEY (RoomID) REFERENCES Room(RoomID),
	FOREIGN KEY (AmenityID) REFERENCES Amenity(AmenityID)


ALTER TABLE RoomReservation
ADD PRIMARY KEY(ReservationID, RoomID),
	FOREIGN KEY(ReservationID) REFERENCES Reservation(ReservationID),
	FOREIGN KEY(RoomID) REFERENCES Room(RoomID)

ALTER TABLE Reservation
ADD FOREIGN KEY (PromotionID) REFERENCES Promotion(PromotionID),
	FOREIGN KEY (BillID) REFERENCES Bill(BillID)

ALTER TABLE Bill
ADD FOREIGN KEY(BillDetailsID) REFERENCES BillDetails(BillDetailsID)

ALTER TABLE BillDetails
ADD FOREIGN KEY(RoomTypeID) REFERENCES RoomType(RoomTypeID)

ALTER TABLE BillDetailsAddOn
ADD PRIMARY KEY(BillDetailsID, AddOnID),
	FOREIGN KEY(BillDetailsID) REFERENCES BillDetails(BillDetailsID),
	FOREIGN KEY(AddOnID) REFERENCES AddOn(AddOnID)

ALTER TABLE AddOn
ADD FOREIGN KEY(AddOnRateID) REFERENCES AddOnRate(AddOnRateID)

ALTER TABLE ReservationAddOn
ADD PRIMARY KEY(ReservationID, AddOnID),
	FOREIGN KEY(ReservationID) REFERENCES Reservation(ReservationID),
	FOREIGN KEY(AddOnID) REFERENCES AddOn(AddOnID)

ALTER TABLE ReservationCustomer
ADD PRIMARY KEY(ReservationID, CustomerID),
	FOREIGN KEY(ReservationID) REFERENCES Reservation(ReservationID),
	FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID)


ALTER TABLE ReservationGuest
ADD PRIMARY KEY(ReservationID, GuestID),
	FOREIGN KEY(ReservationID) REFERENCES Reservation(ReservationID),
	FOREIGN KEY(GuestID) REFERENCES Guest(GuestID)

ALTER TABLE Customer
ADD FOREIGN KEY(GuestID) REFERENCES Guest(GuestID)

SET IDENTITY_INSERT RoomTypeRate ON
INSERT INTO RoomTypeRate(RoomTypeRateID, Price, StartDate, EndDate)
VALUES ('1','100', NULL, NULL),
	   ('2','200', '6/1/2016', '12/15/2016'),
	   ('3', '50', '1/1/2016', '2/1/2016')
SET IDENTITY_INSERT RoomTypeRate OFF

INSERT INTO RoomType(RoomName, RoomTypeRateID)
VALUES ('double', '1'),
       ('queen', '2'),
	   ('single', '3')


INSERT INTO Room(FloorNumber, OccupancyLimit, RoomTypeID)
VALUES ('1', '4', '1'),
	   ('1', '4', '2'),
	   ('1', '4', '3'),
	   ('1', '4', '3'),
	   ('1', '6', '2'),
	   ('1', '6','1'),
	   ('1', '6', '2'),
	   ('1', '2', '2'),
	   ('1', '2','3'),
	   ('2', '2','3'),
	   ('2', '2','2'),
	   ('2', '3','3'),
	   ('2', '3','2'),
	   ('2', '3','3'),
	   ('2', '5','1'),
	   ('2', '5','1')

INSERT INTO Amenity(AmenityName)
VALUES('Refrigerator'),
	  ('TV'),
	  ('Microwave'),
	  ('Safe'),
	  ('Computer')

INSERT INTO RoomAmenity(RoomID, AmenityID)
VALUES('1', '1'),
	  ('1', '2'),
	  ('1', '3'),
	  ('1', '4'),
	  ('1', '5'),
	  ('2', '1'),
	  ('2', '5'),
	  ('6', '5'),
	  ('10', '2'),
	  ('10', '4'),
	  ('4', '3')

INSERT INTO Guest(FirstName, Lastname)
VALUES('John', 'Doe'),
	  ('Jane', 'Doe'),
	  ('Bob', 'Mill'),
	  ('Sam', 'Smith')

INSERT INTO Customer(FirstName, LastName, Phone)
VALUES ('Montell', 'Mackie', '123-456-7890'),
	   ('Lyra', 'Becker', '789-456-4568'),
	   ('Loki', 'Mills', null),
	   ('Ilyas', 'Morton', '456-456-8516'),
	   ('Tamanna', 'Matthews', '951-456-7542'),
	   ('Winner', 'Neale', null),
	   ('Carlie', 'Britton', '321-258-0015'),
	   ('Todd', 'Weeks', '202-555-0180'),
	   ('Harry', 'King', '202-555-0198'),
	   ('Gwen', 'Rojas', '651-555-0101'),
	   ('Cecilia', 'Adkins', '651-555-0168')


INSERT INTO AddOnRate(Price)
VALUES('5'),
	  ('10'),
	  ('15'),
	  ('20')

INSERT INTO AddOn(AddOnName, AddOnRateID)
VALUES ('Room Service', '4'),
	   ('Movies', '3'),
	   ('Internet Device', '1'),
	   ('Music', '2')

INSERT INTO BillDetails(AddOnPrice, RoomTypeID, RoomPrice)
VALUES ('35', '1', '100'),
	   ('20', '2', '100'),
	   ('5', '3', '50'),
	   ('15', '3', '50'),
	   ('10', '2', '200'),
	   ('5', '1', '100'),
	   (null, '1', '100'),
	   (null, '3', '50')


INSERT INTO Bill(BillDetailsID, TotalPrice, Tax)
VALUES ('1', '145', '10'),
	   ('2', '140', '20'),
	   ('3', '60', '5'),
	   ('4', '80', '5'),
	   ('5', '230', '20'),
	   ('6', '115', '10'),
	   ('7', '110', '10'),
	   ('8', '55', '5')


INSERT INTO Promotion(Discount)
VALUES ('.10'),
	   ('.15'),
	   ('.30'),
	   ('.50')

INSERT INTO Reservation(PromotionID, CustomerID, GuestID, BillID, StartDate, EndDate)
VALUES ('1', '1', null, '1', '10/1/2016', '10/2/2016'),
	   ('1', '2', null, '2', '1/1/2016', '1/3/2016'),
	   (null, '3', '1', '3', '5/2/2016', '5/8/2016'),
	   ('2', '4', null, '4', '1/1/2016', '1/2/2016'),
	   (null, '5', '2', '5', '2/1/2016', '2/10/2016'),
	   (null, '6', null, '6', '3/1/2016', '3/3/2016'),
	   ('3', '7', null, '7', '4/1/2016', '4/5/2016'),
	   (null, '8', null, '8', '5/1/2016', '5/15/2016'),
	   ('4', '9', null, null, '6/1/2016', '6/6/2016'),
	   (null, '10', null, null, '1/1/2016', '1/2/2016'),
	   ('2', '11', null, null, '1/1/2016', '1/8/2016'),
	   ('2', null, '3', null, '1/1/2016', '1/2/2017')

INSERT INTO RoomReservation(ReservationID, RoomID, StartDate, EndDate)
VALUES('1', '1', '10/1/2016', '10/2/2016'),
	  ('1', '2', '10/1/2016', '10/2/2016'),
	  ('1', '3', '10/1/2016', '10/2/2016'),
	  ('2', '1', '1/4/2016', '1/5/2016'),
	  ('2', '2', '1/10/2016', '1/15/2016'),
	  ('2', '3', '1/1/2016', '1/4/2016'),
	  ('3', '3', '5/2/2016', '5/8/2016'),
	  ('4', '3', '1/1/2016', '1/2/2016'),
	  ('5', '2', '2/1/2016', '2/10/2016'),
	  ('6', '1', '3/1/2016', '3/3/2016'),
	  ('7', '1', '4/1/2016', '4/5/2016'),
	  ('8', '3', '5/1/2016', '5/15/2016'),
	  ('9', '2', '6/1/2016', '6/6/2016'),
	  ('10', '1', '1/1/2016', '1/2/2016'),
	  ('11', '2', '1/1/2016', '1/8/2016'),
	  ('12', '2', '1/1/2016', '1/2/2016')

INSERT INTO ReservationGuest(ReservationID, GuestID)
VALUES ('12', '3')

INSERT INTO ReservationCustomer(ReservationID, CustomerID)
VALUES ('1', '1'),
	   ('2', '2'),
	   ('3', '3'),
	   ('4', '4'),
	   ('5', '5'),
	   ('6', '6'),
	   ('7', '7'),
	   ('8', '8'),
	   ('9', '9'),
	   ('10', '10'),
	   ('11', '11')

INSERT INTO ReservationAddOn(ReservationID, AddOnID)
VALUES ('1', '1'),
	   ('1', '2'),
	   ('2', '1'),
	   ('3', '3'),
	   ('4', '2'),
	   ('5', '4'),
	   ('6', '3')



