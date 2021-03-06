SET SERVEROUTPUT ON;

DECLARE
    CUSTOMER VARCHAR2(50);
    LOCATION VARCHAR(50);
    PARTICIPANTS VARCHAR(50);
    CURSOR A IS
        SELECT (C.CUST_FNAME || ', ' || C.CUST_SNAME),
            L.LOCATION_NAME, B.BOOKING_DATE
            FROM CUSTOMER C
            INNER JOIN BOOKING B ON C.CUST_ID = B.CUST_ID
            INNER JOIN LOCATIONS L ON L.LOCATION_ID = B.LOCATION_ID
            WHERE B.BOOKING_DATE = '20 June 2017';
            
BEGIN

OPEN A;
FETCH A INTO CUSTOMER, LOCATION, PARTICIPANTS;

LOOP

DBMS_OUTPUT.PUT_LINE('CUSTOMER: ' || CUSTOMER);
DBMS_OUTPUT.PUT_LINE('LOCATION: ' || LOCATION);
DBMS_OUTPUT.PUT_LINE('PARTICIPANTS: ' || PARTICIPANTS);
DBMS_OUTPUT.PUT_LINE('-----------------------------------');

FETCH A INTO CUSTOMER, LOCATION, PARTICIPANTS;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;