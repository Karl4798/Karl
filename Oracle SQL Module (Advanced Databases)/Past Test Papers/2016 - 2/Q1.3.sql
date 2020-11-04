SELECT C.COMPANYNAME, P.PRODUCT, 'R' || (S.QUANTITY * P.PRICE) AS "TOTAL",
'R' || ((S.QUANTITY * P.PRICE) * 0.1) AS "DISCOUNT",
'R' || ((S.QUANTITY * P.PRICE) * 0.9) AS "DISCOUNTED_TOTAL"
FROM CUSTOMER C
INNER JOIN SALES S ON C.CUSTOMERID = S.CUSTOMERID
INNER JOIN PRODUCT P ON P.PRODUCTID = S.PRODUCTID;