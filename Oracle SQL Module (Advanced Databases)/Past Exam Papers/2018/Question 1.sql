SELECT B.VIN, C.CUST_ID, L.LOCATION_NAME, B.BOOKING_DATE, CA.CANCEL_REASON
FROM BOOKING B
INNER JOIN LOCATIONS L ON b.location_id = l.location_id
INNER JOIN CANCELLATIONS CA ON ca.booking_id = b.booking_id
INNER JOIN CUSTOMER C ON c.cust_id = b.cust_id;