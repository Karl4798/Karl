SET SERVEROUTPUT ON;

DECLARE
    EVENT VARCHAR(50);
    PRICE DECIMAL(6, 2);
    CURSOR A IS
        SELECT EVENT_NAME, EVENT_RATE
        FROM EVENT;
    
BEGIN

OPEN A;
FETCH A INTO EVENT, PRICE;

LOOP

IF PRICE >= 250 THEN
    PRICE := PRICE * 0.9;
END IF;

DBMS_OUTPUT.PUT_LINE (EVENT || ': R ' || PRICE);

FETCH A INTO EVENT, PRICE;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;