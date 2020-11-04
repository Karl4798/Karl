CREATE OR REPLACE VIEW Booking_View AS

SELECT BU.NUM_OF_PASSENGERS, C.CUST_ID, C.CUST_ADDRESS, L.LOCATION_PROVINCE, B.BOOKING_DATE
FROM BOOKING B
INNER JOIN CUSTOMER C ON B.CUST_ID = C.CUST_ID
INNER JOIN BUS BU ON B.VIN = BU.VIN
INNER JOIN LOCATIONS L ON B.LOCATION_ID = L.LOCATION_ID
WHERE B.BOOKING_DATE BETWEEN '20 June 2017' AND '25 June 2017'
ORDER BY C.CUST_ID DESC;

GO

SELECT *
FROM Booking_View;