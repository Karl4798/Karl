CREATE OR REPLACE PROCEDURE Criminal_Details
(CR_ID IN VARCHAR) AS

CRIMINAL VARCHAR(50);
CRIME_DATE VARCHAR(50);
CRIME VARCHAR(50);

BEGIN

SELECT (C.CRIMINAL_FNAME || ' ' || C.CRIMINAL_SNAME),
    CA.CASE_DATE, O.OFFENCE_NAME INTO CRIMINAL, CRIME_DATE, CRIME
    FROM CRIMINAL C
    INNER JOIN CASES CA ON C.CRIMINAL_ID = CA.CRIMINAL_ID
    INNER JOIN OFFENCE O ON CA.OFFENCE_ID = O.OFFENCE_ID
    WHERE C.CRIMINAL_ID = CR_ID;

DBMS_OUTPUT.put_line('CRIMINAL DETAILS: ' || CRIMINAL || ' committed a ' || CRIME || ' on the ' || CRIME_DATE);

END;

/

SET SERVEROUTPUT ON;
EXECUTE Criminal_Details('crim101');