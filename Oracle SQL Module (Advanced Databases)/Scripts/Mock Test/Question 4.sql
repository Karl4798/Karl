SET SERVEROUTPUT ON;

DECLARE
  ID VARCHAR(25);
  EMAIL VARCHAR(25);
  CURSOR A IS
    SELECT STUDENTID, EMAIL
    FROM STUDENT
    WHERE EMAIL LIKE '%yahoo%';
  
BEGIN

OPEN A;

FETCH A INTO ID, EMAIL;

LOOP

  dbms_output.put_line('STUDENT ID: ' || ID);
  dbms_output.put_line('EMAIL ADDRESS: ' || EMAIL);
  dbms_output.put_line(null);

FETCH A INTO ID, EMAIL;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;