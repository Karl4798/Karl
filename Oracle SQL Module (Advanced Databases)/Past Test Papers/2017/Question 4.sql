DECLARE ARTIST VARCHAR(50);
        BOOK_DATE VARCHAR(50);

BEGIN

SELECT A.ARTIST_NAME INTO ARTIST
FROM ARTIST A
INNER JOIN BOOKINGS B ON a.artist_id = b.artist_id
WHERE b.event_id = '1001';

SELECT BOOKING_DATE INTO BOOK_DATE
FROM BOOKINGS B
INNER JOIN EVENT E ON b.event_id = e.event_id
WHERE e.event_id = '1001';

dbms_output.put_line(CONCAT('ARTIST NAME: ', ARTIST));
dbms_output.put_line(CONCAT('BOOKING DATE: ', BOOK_DATE));

END;