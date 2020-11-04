SET SERVEROUTPUT ON;

DECLARE
    STOCK INT;
    PROD VARCHAR(25);
    CURSOR A IS
        SELECT PRODUCTID, STOCKLEVEL
        FROM PRODUCT
        WHERE PRODUCTID = 'X503';
BEGIN

OPEN A;

FETCH A INTO PROD, STOCK;

LOOP

IF STOCK < 10 THEN
    DBMS_OUTPUT.PUT_LINE(PROD || ' stock levels are not stable. Stock levels need to be increased.');
END IF;

IF STOCK >= 10 THEN
    DBMS_OUTPUT.PUT_LINE(PROD || ' stock levels are stable.');
END IF;

FETCH A INTO PROD, STOCK;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;