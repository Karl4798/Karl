SET SERVEROUTPUT ON;

DECLARE
    NAME VARCHAR(50);
    REVENUE INT;
    CURSOR A IS
        SELECT P.PRODUCT, SUM((P.PRICE * S.QUANTITY))
        FROM PRODUCT P
        INNER JOIN SALES S ON p.productid = s.productid
        WHERE P.PRODUCTID = 'X500'
        GROUP BY p.product;
    
BEGIN

OPEN A;

FETCH A INTO NAME, REVENUE;

LOOP

DBMS_OUTPUT.put_line('The total sales amount for product ' || NAME || ' is: R' || REVENUE);
FETCH A INTO NAME, REVENUE;
EXIT WHEN A%NOTFOUND;

END LOOP;

CLOSE A;

END;


