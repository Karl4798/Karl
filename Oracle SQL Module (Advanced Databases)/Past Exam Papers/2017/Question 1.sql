SELECT (O.OFFICER_FNAME || ', ' || O.OFFICER_SNAME) AS "OFFICER",
    (C.CRIMINAL_FNAME || ', ' || C.CRIMINAL_SNAME) AS "CRIMINAL",
    OE.OFFENCE_NAME, CA.CASE_DATE
FROM OFFICER O
INNER JOIN CASES CA ON O.OFFICER_ID = CA.OFFICER_ID
INNER JOIN CRIMINAL C ON C.CRIMINAL_ID = CA.CRIMINAL_ID
INNER JOIN OFFENCE OE ON CA.OFFENCE_ID = OE.OFFENCE_ID
WHERE CA.CASE_DATE BETWEEN '20 October 2017' AND '30 October 2017'
ORDER BY CA.CASE_DATE ASC;