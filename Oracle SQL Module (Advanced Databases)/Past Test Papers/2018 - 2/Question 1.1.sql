CREATE TABLE VEHICLE (
VIN CHAR(6) PRIMARY KEY NOT NULL,
MANUFACTURER VARCHAR(25) NOT NULL,
VEHICLE_MODEL VARCHAR(25) NOT NULL,
PRICE DECIMAL(9, 2) NOT NULL
);

/

CREATE TABLE CUSTOMER (
CUSTOMER_ID CHAR(8) PRIMARY KEY NOT  NULL,
CUSTOMER_NAME VARCHAR(50) NOT NULL,
CUSTOMER_EMAIL VARCHAR(25) NOT NULL
);

/

CREATE TABLE VEHICLE_SALES (
SALES_ID INT PRIMARY KEY NOT NULL,
SALES_DATE DATE NOT NULL,
VIN CHAR(6),
CUSTOMER_ID CHAR(8),
CONSTRAINT FK_VIN FOREIGN KEY (VIN) REFERENCES VEHICLE(VIN),
CONSTRAINT FK_CUSTOMER_ID FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMER(CUSTOMER_ID)
);

/