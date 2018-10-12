USE HotelReservation
GO

--Reservations that end tomorrow
SELECT * FROM Reservation
WHERE EndDate = '10-02-2018'

--All rooms reserved for a particular customer
SELECT r.CustomerID, rt.RoomName FROM Reservation r
	INNER JOIN RoomReservation rr ON rr.ReservationID = r.ReservationID
	INNER JOIN Room ON Room.RoomID = rr.RoomID
	INNER JOIN RoomType rt ON rt.RoomTypeID = Room.RoomTypeID
WHERE CustomerID = 2

--Promotion codes, and the number of times used.
SELECT PromotionID,  COUNT(PromotionID) 
FROM Reservation
GROUP BY PromotionID

--The 3 most expensive bills upcoming in the next month
SELECT TOP 3 * 
FROM Bill
ORDER BY TotalPrice DESC

--Rooms that do not contain a specific amenity
SELECT * FROM RoomAmenity


--All rooms available for a date range
SELECT count(*) - (SELECT count(*) 
					FROM RoomReservation 
					WHERE StartDate between '1/1/2016' and '1/31/2016') OpenRooms
FROM Room

--SELECT *
--FROM Room r
--	FULL JOIN RoomReservation rr ON r.RoomID = rr.ReservationID
--WHERE ((StartDate BETWEEN '1/1/2016' AND '1/31/2016') OR StartDate IS NULL)