DECLARE AVG_PRICE INT;
        NO_HIGH_PRICE INT;
        EVENT VARCHAR(50);
        PRICE INT;

BEGIN

SELECT AVG(EVENT_RATE) INTO AVG_PRICE
FROM EVENT;
SELECT COUNT(EVENT_RATE) INTO NO_HIGH_PRICE
FROM EVENT
WHERE EVENT_RATE > AVG_PRICE;

WHILE NO_HIGH_PRICE >= 1
LOOP

SELECT EVENT_NAME INTO EVENT
FROM
    (
    SELECT EVENT_NAME, ROWNUM R
    FROM(
        SELECT EVENT_NAME
        FROM EVENT
        WHERE EVENT_RATE > AVG_PRICE
        ORDER BY EVENT_ID DESC
        )
    )
WHERE R = NO_HIGH_PRICE;

SELECT EVENT_RATE INTO PRICE
FROM
    (
    SELECT EVENT_RATE, ROWNUM R
    FROM(
        SELECT EVENT_RATE
        FROM EVENT
        WHERE EVENT_RATE > AVG_PRICE
        ORDER BY EVENT_ID DESC
        )
    )
WHERE R = NO_HIGH_PRICE;
    

DBMS_OUTPUT.PUT_LINE(EVENT);
DBMS_OUTPUT.PUT_LINE(CONCAT('Price: R', CAST(PRICE AS VARCHAR)));
DBMS_OUTPUT.PUT_LINE('----------------------------');

NO_HIGH_PRICE := NO_HIGH_PRICE - 1;

END LOOP;

END;