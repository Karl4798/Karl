SELECT a.artist_name, CONCAT('R ', CAST(SUM(e.event_rate) AS VARCHAR(25))) AS "REVENUE"
FROM BOOKINGS B
INNER JOIN EVENT E ON b.event_id = e.event_id
INNER JOIN ARTIST A ON b.artist_id = a.artist_id
GROUP BY a.artist_name