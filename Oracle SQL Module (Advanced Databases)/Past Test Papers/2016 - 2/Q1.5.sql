SET SERVEROUTPUT ON;

DECLARE
    COMPANYNAME VARCHAR(25);
    PURCHASES INT;
    CURSOR A IS
        SELECT C.COMPANYNAME, COUNT(S.SALEID)
        FROM CUSTOMER C
        INNER JOIN SALES S ON C.CUSTOMERID = S.CUSTOMERID
        GROUP BY C.COMPANYNAME;
        
BEGIN

OPEN A;
FETCH A INTO COMPANYNAME, PURCHASES;

LOOP

DBMS_OUTPUT.PUT_LINE('Purchases made by ' || COMPANYNAME || ': ' || PURCHASES);

FETCH A INTO COMPANYNAME, PURCHASES;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;