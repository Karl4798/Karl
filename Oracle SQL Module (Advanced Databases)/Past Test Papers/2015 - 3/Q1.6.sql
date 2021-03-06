SET SERVEROUTPUT ON;

DECLARE
    STUDID VARCHAR(25);
    RESULT DECIMAL(5, 2);
    CURSOR A IS
        SELECT R.STUDID, R.RESULTS
        FROM RESULTS R
        WHERE R.STUDID = '1011'
        AND R.RESULTID = '101';
    
BEGIN

OPEN A;
FETCH A INTO STUDID, RESULT;

LOOP

DBMS_OUTPUT.PUT_LINE('Student ID: ' || STUDID);
DBMS_OUTPUT.put_line('Result: ' || RESULT || '%');

IF RESULT >= 75 THEN
    DBMS_OUTPUT.put_line('Outcome: is a distinction');
ELSIF RESULT >= 50 AND RESULT < 75 THEN
    DBMS_OUTPUT.put_line('Outcome: is a pass');
ELSIF RESULT < 50 THEN
    DBMS_OUTPUT.put_line('Outcome: is a fail');
END IF;

FETCH A INTO STUDID, RESULT;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;