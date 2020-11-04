CREATE OR REPLACE VIEW Address_View AS

SELECT O.OFFICER_ID, C.CITIZEN_ID, C.CITIZEN_ADDRESS,
CR.CRIMINAL_ID, OE.OFFENCE_NAME, CA.CASE_DATE
FROM OFFICER O
INNER JOIN CASES CA ON O.OFFICER_ID = CA.OFFICER_ID
INNER JOIN CRIMINAL CR ON CA.CRIMINAL_ID = CR.CRIMINAL_ID
INNER JOIN OFFENCE OE ON CA.OFFENCE_ID = OE.OFFENCE_ID
INNER JOIN CITIZEN C ON C.CITIZEN_ID = CA.CITIZEN_ID
WHERE C.CITIZEN_ADDRESS LIKE '%Main rd%';

/

SELECT *
FROM Address_View;