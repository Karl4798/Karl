SELECT (S.FIRSTNAME || ', ' || S.SURNAME) AS "NAMES", C.COURSENAME AS "COURSE", (R.RESULTS || '%') AS "RESULTS"
FROM STUDENT S
INNER JOIN RESULTS R ON S.STUDID = R.STUDID
INNER JOIN COURSE C ON R.COURSEID = C.COURSEID;