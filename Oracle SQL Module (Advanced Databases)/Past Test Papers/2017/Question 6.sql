CREATE VIEW Event_Schedules AS
SELECT DISTINCT e.event_name, CONCAT('R ', CAST(e.event_rate AS VARCHAR(25))) AS "EVENT RATE", b.booking_date
FROM EVENT E
INNER JOIN BOOKINGS B ON e.event_id = b.event_id
WHERE b.booking_date BETWEEN '1/JUL/17' AND '28/AUG/17';

SELECT * FROM Event_Schedules;