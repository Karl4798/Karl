SET SERVEROUTPUT ON;

DECLARE
    NAME VARCHAR(50);
    VIN VARCHAR(25);
    PRICE DECIMAL(9, 2);
    CURSOR A IS
        SELECT C.CUSTOMER_NAME, V.VIN, V.PRICE
        FROM CUSTOMER C
        INNER JOIN VEHICLE_SALES VS ON C.CUSTOMER_ID = VS.CUSTOMER_ID
        INNER JOIN VEHICLE V ON VS.VIN = V.VIN
        WHERE PRICE >= 300000;
        
BEGIN

OPEN A;
FETCH A INTO NAME, VIN, PRICE;

LOOP

dbms_output.put_line('CUSTOMER NAME: ' || NAME);
dbms_output.put_line('VIN: ' || VIN);
dbms_output.put_line('PRICE: ' || PRICE);
dbms_output.put_line('------------------------');

FETCH A INTO NAME, VIN, PRICE;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;