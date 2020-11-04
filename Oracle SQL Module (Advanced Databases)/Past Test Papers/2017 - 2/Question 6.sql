CREATE VIEW Event_Schedules AS

SELECT DISTINCT E.EVENT_NAME, ('R ' || E.EVENT_RATE) AS "EVENT RATE", B.BOOKING_DATE
FROM EVENT E
INNER JOIN BOOKINGS B ON E.EVENT_ID = B.EVENT_ID
WHERE B.BOOKING_DATE BETWEEN '1 July 2017' AND '28 August 2017';

/

SELECT *
FROM Event_Schedules;