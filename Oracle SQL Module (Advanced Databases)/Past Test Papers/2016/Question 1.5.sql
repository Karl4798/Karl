SET SERVEROUTPUT ON;

DECLARE
    NAME VARCHAR(50);
    PURCHASES INT;
    CURSOR A IS
        SELECT C.COMPANYNAME, COUNT(S.SALEID)
        FROM CUSTOMER C
        INNER JOIN SALES S ON C.CUSTOMERID = S.CUSTOMERID
        GROUP BY C.COMPANYNAME;

BEGIN

OPEN A;
FETCH A INTO NAME, PURCHASES;

LOOP

DBMS_OUTPUT.PUT_LINE('Purchases made by ' || NAME || ': ' || PURCHASES);
FETCH A INTO NAME, PURCHASES;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;