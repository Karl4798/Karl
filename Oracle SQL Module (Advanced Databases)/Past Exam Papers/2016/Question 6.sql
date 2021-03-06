CREATE OR REPLACE FUNCTION Lowest_Sales
(PROD_ID IN VARCHAR)
RETURN VARCHAR AS

PRODUCT VARCHAR(50);
MIN_PRICE DECIMAL(25, 2);

BEGIN

SELECT P.PRODUCTNAME, MIN(S.SALEQTY * P.PRICE)
    INTO PRODUCT, MIN_PRICE
FROM PRODUCT P
INNER JOIN PRODUCT_SALES PS ON P.PRODUCTID = PS.PRODUCTID
INNER JOIN SALES S ON PS.SALEID = S.SALEID
WHERE P.PRODUCTID = PROD_ID
GROUP BY P.PRODUCTNAME;

RETURN PRODUCT || ' - R ' || MIN_PRICE;

EXCEPTION
   WHEN NO_DATA_FOUND THEN
   DBMS_OUTPUT.PUT_LINE('NO PRODUCT FOUND WITH PROVIDED PRODUCT ID!');

END;

/

SET SERVEROUTPUT ON;

BEGIN

DBMS_OUTPUT.PUT_LINE(Lowest_Sales('Prod112'));

END;