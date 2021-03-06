SET SERVEROUTPUT ON;

DECLARE
    STOCK INT;
    PRODUCTID VARCHAR(25);
    CURSOR A IS
        SELECT PRODUCTID, STOCKLEVEL
        FROM PRODUCT
        WHERE PRODUCTID = 'X503';
    
BEGIN

OPEN A;
FETCH A INTO PRODUCTID, STOCK;

LOOP

IF STOCK < 10 THEN
    DBMS_OUTPUT.PUT_LINE (PRODUCTID || ' stock levels are not stable. Stock levels need to be increased.');
END IF;

FETCH A INTO PRODUCTID, STOCK;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;