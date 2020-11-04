CREATE OR REPLACE PROCEDURE Sale_Value
(Prod_ID IN VARCHAR) AS

TOTAL_SALE DECIMAL(12, 2);

BEGIN

SELECT (S.SALEQTY * P.PRICE) INTO TOTAL_SALE
FROM SALES S
INNER JOIN PRODUCT_SALES PS ON S.SALEID = PS.SALEID
INNER JOIN PRODUCT P ON P.PRODUCTID = PS.PRODUCTID
WHERE P.PRODUCTID = Prod_ID;

DBMS_OUTPUT.put_line('Total Sale: R ' || TOTAL_SALE);

END;

/

SET SERVEROUTPUT ON;
EXECUTE Sale_Value('Prod115');