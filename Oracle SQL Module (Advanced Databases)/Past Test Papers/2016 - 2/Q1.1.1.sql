CREATE TABLE PRODUCT (
PRODUCTID CHAR(4) PRIMARY KEY NOT NULL,
PRODUCT VARCHAR(50) NOT NULL,
PRICE DECIMAL(7, 2) NOT NULL,
STOCKLEVEL INT NOT NULL
);

/

CREATE TABLE CUSTOMER (
CUSTOMERID CHAR(5) PRIMARY KEY NOT NULL,
COMPANYNAME VARCHAR(25) NOT NULL,
ADDRESS VARCHAR(25) NOT NULL,
EMAIL VARCHAR(50) NOT  NULL
);

/

CREATE TABLE SALES (
SALEID CHAR(3) PRIMARY KEY NOT NULL,
PRODUCTID CHAR(4),
CUSTOMERID CHAR(5),
SALEDATE DATE NOT NULL,
QUANTITY INT NOT NULL,
CONSTRAINT FK_PRODUCTID FOREIGN KEY (PRODUCTID) REFERENCES PRODUCT(PRODUCTID),
CONSTRAINT FK_CUSTOMERID FOREIGN KEY (CUSTOMERID) REFERENCES CUSTOMER(CUSTOMERID)
);

/