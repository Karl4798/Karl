SELECT (C.FIRST_NAME || ', ' || C.SURNAME) AS "CUSTOMER", B.EMPLOYEE_ID, D.DESCRIPTION, P.PRODUCT, B.BILL_DATE
FROM CUSTOMER C, BILLING B, PRODUCT_BILLING PB, DELIVERY D, PRODUCT P
WHERE C.CUSTOMER_ID = B.CUSTOMER_ID
AND D.DELIVERY_ID = PB.DELIVERY_ID
AND B.BILL_ID = PB.BILL_ID
AND P.PRODUCT_ID = PB.PRODUCT_ID
AND B.BILL_DATE = '15 May 2017'
ORDER BY B.EMPLOYEE_ID DESC;

