CREATE OR REPLACE PROCEDURE BUS_LOCATION_COUNT
(VIN_NO IN VARCHAR) AS

BUS_COUNT INT;
OUTPUT VARCHAR(50);
no_vin EXCEPTION;

BEGIN

SELECT COUNT (*) INTO BUS_COUNT
FROM BOOKING, BUS
WHERE BOOKING.VIN = BUS.VIN
AND BUS.VIN = VIN_NO;

IF BUS_COUNT = 0 THEN
    RAISE no_vin;
ELSIF BUS_COUNT = 1 THEN
    OUTPUT := 'one';
ELSIF BUS_COUNT = 2 THEN
    OUTPUT := 'two';
ELSIF BUS_COUNT = 3 THEN
    OUTPUT := 'three';
END IF;

DBMS_OUTPUT.put_line('VIN: ' || VIN_NO || ' has travelled to ' || OUTPUT|| ' locations.');

EXCEPTION
    WHEN no_vin THEN
    DBMS_OUTPUT.PUT_LINE('No Bus Exists With The Provided VIN Number!');

END;

/

SET SERVEROUTPUT ON;
EXECUTE BUS_LOCATION_COUNT(8235251524);