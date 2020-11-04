CREATE VIEW No_Purchases AS

SELECT C.COMPANYNAME
FROM CUSTOMER C
WHERE C.CUSTOMERID NOT IN (SELECT CUSTOMERID FROM SALES);

/

SELECT *
FROM No_Purchases;