SELECT C.*
FROM CUSTOMER C
LEFT OUTER JOIN ORDERS O ON c.cus_id = o.cus_id
WHERE o.cus_id IS NULL;