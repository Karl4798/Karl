SELECT C.COMPANYNAME, P.PRODUCT, ('R ' || (P.PRICE * s.quantity)) AS "TOTAL",
('R ' || ((P.PRICE * s.quantity) * 0.1)) AS "DISCOUNT",
('R ' || ((P.PRICE * s.quantity) * 0.9)) AS "DISCOUNTED_TOTAL"
FROM CUSTOMER C
INNER JOIN SALES S ON c.customerid = s.customerid
INNER JOIN PRODUCT P ON s.productid = p.productid;