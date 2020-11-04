SET SERVEROUTPUT ON;

DECLARE
    NAME VARCHAR(50);
    COURSENAME VARCHAR(50);
    RESULT INT;
    CURSOR A IS
        SELECT (S.FIRSTNAME || ', ' || S.SURNAME), C.COURSENAME, R.RESULTS
        FROM STUDENT S
        INNER JOIN RESULTS R ON S.STUDID = R.STUDID
        INNER JOIN COURSE C ON R.COURSEID = C.COURSEID
        WHERE S.STUDID = '1033';
    
BEGIN

OPEN A;
FETCH A INTO NAME, COURSENAME, RESULT;

LOOP

DBMS_OUTPUT.PUT_LINE ('The student results is: ' || NAME || ', ' || COURSENAME || ', ' || RESULT || '%');

FETCH A INTO NAME, COURSENAME, RESULT;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;