SELECT C.COMPANYNAME, P.PRODUCT, S.QUANTITY
FROM CUSTOMER C
INNER JOIN SALES S ON C.CUSTOMERID = S.CUSTOMERID
INNER JOIN PRODUCT P ON S.PRODUCTID = P.PRODUCTID;