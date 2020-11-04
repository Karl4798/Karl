SET SERVEROUTPUT ON;

DECLARE
    NAME VARCHAR(25);
    VIN VARCHAR(25);
    PRICE DECIMAL(25, 2);
    CURSOR C
        IS SELECT C.CUSTOMER_NAME, VS.VIN, V.PRICE
        FROM CUSTOMER C
        INNER JOIN VEHICLE_SALES VS ON C.CUSTOMER_ID = VS.CUSTOMER_ID
        INNER JOIN VEHICLE V ON VS.VIN = V.VIN
        WHERE V.PRICE >= 300000;
        
BEGIN

OPEN C;
FETCH C INTO NAME, VIN, PRICE;
LOOP

DBMS_OUTPUT.PUT_LINE('CUSTOMER NAME: ' || NAME);
DBMS_OUTPUT.PUT_LINE('VIN: ' || VIN);
DBMS_OUTPUT.PUT_LINE('PRICE: ' || PRICE);
DBMS_OUTPUT.PUT_LINE(null);

FETCH C INTO NAME, VIN, PRICE;
EXIT WHEN C%NOTFOUND;

END LOOP;
CLOSE C;
END;
