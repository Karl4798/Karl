DECLARE
    NAME VARCHAR(100);
    PRICE INT;
    AVERAGE DECIMAL(25, 2);
    CURSOR A IS
        SELECT EVENT_NAME, EVENT_RATE
        FROM EVENT;
        
BEGIN

SELECT ((SUM(EVENT_RATE) / COUNT(EVENT_ID)))
INTO AVERAGE
FROM EVENT;

OPEN A;

FETCH A INTO NAME, PRICE;

LOOP

IF PRICE > AVERAGE
THEN
    
    DBMS_OUTPUT.PUT_LINE(NAME);
    DBMS_OUTPUT.put_line('Price R ' || PRICE);
    DBMS_OUTPUT.PUT_LINE('---------------------------------');

END IF;

FETCH A INTO NAME, PRICE;

EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;