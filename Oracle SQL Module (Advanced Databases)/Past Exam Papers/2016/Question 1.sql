SELECT C.CUSTOMERID, E.EMPID, P.PRODUCTID, S.SALEDATE
FROM CUSTOMER C
INNER JOIN SALES S ON C.CUSTOMERID = S.CUSTOMERID
INNER JOIN PRODUCT_SALES PS ON S.SALEID = PS.SALEID
INNER JOIN PRODUCT P ON P.PRODUCTID = PS.PRODUCTID
INNER JOIN EMPLOYEE E ON S.EMPID = E.EMPID
WHERE P.PRICE < 5000
ORDER BY C.CUSTOMERID ASC;