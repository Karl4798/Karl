SELECT a.*
FROM (SELECT a.artist_name, COUNT(b.event_id) AS "PERFORMANCE_COUNT"
      FROM artist A
      INNER JOIN bookings B ON a.artist_id = b.artist_id
      GROUP BY a.artist_name
      ORDER BY COUNT(b.event_id)) a
WHERE ROWNUM = 1;