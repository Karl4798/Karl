SET SERVEROUTPUT ON;

DECLARE
    STUDID VARCHAR(25);
    NO_RESULTS INT;
    CURSOR A IS
        SELECT STUDID, COUNT(RESULTID)
        FROM RESULTS
        GROUP BY STUDID
        ORDER BY COUNT(RESULTID) DESC;

BEGIN

OPEN A;
FETCH A INTO STUDID, NO_RESULTS;

LOOP

DBMS_OUTPUT.PUT_LINE('The result count for ' || STUDID || ' is: ' || NO_RESULTS);

FETCH A INTO STUDID, NO_RESULTS;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;