CREATE TABLE EMPLOYEE (
EMPID CHAR(3) PRIMARY KEY NOT NULL,
FIRST_NAME VARCHAR(25) NOT NULL,
SURNAME VARCHAR(25) NOT NULL,
CONTACT_NUM VARCHAR(25) NOT NULL,
EMAIL VARCHAR(50) NOT NULL,
ADDRESS VARCHAR(50)
);

/

CREATE TABLE CUSTOMER (
CUSTOMERID CHAR(3) PRIMARY KEY NOT NULL,
FIRST_NAME VARCHAR(25) NOT NULL,
SURNAME VARCHAR(25) NOT NULL,
CONTACT_NUM VARCHAR(25) NOT NULL,
ADDRESS VARCHAR(50) NOT NULL,
COMMENTS VARCHAR(50)
);

/

CREATE TABLE SUPPLIER (
SUPPLIERID CHAR(3) PRIMARY KEY NOT NULL,
SUPPLIERNAME VARCHAR(50) NOT NULL,
CONTACT_NUM VARCHAR(25) NOT NULL,
RATING INT NOT NULL
);

/

CREATE TABLE PRODUCT (
PRODUCTID CHAR(7) PRIMARY KEY NOT NULL,
PRODUCTNAME VARCHAR(50) NOT NULL,
PRICE DECIMAL(12, 2) NOT NULL,
WARRANTY VARCHAR(25) NOT NULL,
SUPPLIERID CHAR(3),
CONSTRAINT FK_SUPPLIERID FOREIGN KEY (SUPPLIERID) REFERENCES SUPPLIER(SUPPLIERID)
);

/

CREATE TABLE SALES (
SALEID CHAR(4) PRIMARY KEY NOT NULL,
SALEDATE DATE NOT NULL,
SALEQTY INT NOT NULL,
EMPID CHAR(3),
CUSTOMERID CHAR(3),
CONSTRAINT FK_EMPID FOREIGN KEY (EMPID) REFERENCES EMPLOYEE(EMPID),
CONSTRAINT FK_CUSTOMERID FOREIGN KEY (CUSTOMERID) REFERENCES CUSTOMER(CUSTOMERID)
);

/

CREATE TABLE PRODUCT_SALES (
SALEID CHAR(4),
PRODUCTID CHAR(7),
CONSTRAINT FK_SALEID FOREIGN KEY (SALEID) REFERENCES SALES(SALEID),
CONSTRAINT FK_PRODUCTID FOREIGN KEY (PRODUCTID) REFERENCES PRODUCT(PRODUCTID)
);

/

INSERT INTO EMPLOYEE VALUES ('101', 'Shane', 'Willis', '0843569851', 'pw@isat.co.za', '15 Main rd');
INSERT INTO EMPLOYEE VALUES ('102', 'Patrick', 'Morgan', '0763698521', 'smore@imail.com', '27 Water way');
INSERT INTO EMPLOYEE VALUES ('103', 'Andre', 'Gumede', '0786598521', 'gg@mcare.co.za', '19 Cape st');
INSERT INTO EMPLOYEE VALUES ('104', 'Sam', 'Du Preez', '0796369857', 'duppie@isat.co.za', '20 Long rd');
INSERT INTO EMPLOYEE VALUES ('105', 'Eric', 'Smith', '0826598741', 'bsmith@nrom.co.za', '5 Temperance st');

/

INSERT INTO CUSTOMER VALUES ('A91', 'Bob', 'Watson', '0769856895', '15 Table rd', 'Late payer');
INSERT INTO CUSTOMER VALUES ('A92', 'Henry', 'Botha', '0742598657', '28 Sea Side rd', 'Handed over');
INSERT INTO CUSTOMER VALUES ('A93', 'Joe', 'Daniels', '0863256982', '19 Upper End', 'Up to date');
INSERT INTO CUSTOMER VALUES ('A94', 'Clark', 'Smith', '0785659857', '27 South end', 'Late payer');
INSERT INTO CUSTOMER VALUES ('A95', 'Jabu', 'Jones', '0712369571', '12 Main rd', 'Later payer');

/

INSERT INTO SUPPLIER VALUES ('751', 'Xtreme Parts', '0113256958', 7);
INSERT INTO SUPPLIER VALUES ('752', 'Ultra share', '0212569857', 5);
INSERT INTO SUPPLIER VALUES ('753', 'Ultra ideas', '0310524589', 9);
INSERT INTO SUPPLIER VALUES ('754', 'Robo Gear', '0412365987', 2);
INSERT INTO SUPPLIER VALUES ('755', 'Modern concepts', '0512569855', 10);

/

INSERT INTO PRODUCT VALUES ('Prod111', 'GT958 Display Card', 2189.55, '1 year', '751');
INSERT INTO PRODUCT VALUES ('Prod112', 'X700 Display Card', 1295.75, '1 year', '755');
INSERT INTO PRODUCT VALUES ('Prod113', 'K99 Solid State Drive', 3700.21, '2 years', '753');
INSERT INTO PRODUCT VALUES ('Prod114', '42 Inch LED', 3100.25, '1 year', '752');
INSERT INTO PRODUCT VALUES ('Prod115', '60 Inch LCD', 8050.79, '2 years', '751');

/

INSERT INTO SALES VALUES ('1010', '15 October 2015', 3, '101', 'A95');
INSERT INTO SALES VALUES ('1011', '18 October 2015', 1, '103', 'A92');
INSERT INTO SALES VALUES ('1012', '20 October 2015', 5, '101', 'A94');
INSERT INTO SALES VALUES ('1013', '22 October 2015', 2, '101', 'A91');
INSERT INTO SALES VALUES ('1014', '23 October 2015', 7, '102', 'A95');

/

INSERT INTO PRODUCT_SALES VALUES ('1010', 'Prod111');
INSERT INTO PRODUCT_SALES VALUES ('1011', 'Prod112');
INSERT INTO PRODUCT_SALES VALUES ('1011', 'Prod111');
INSERT INTO PRODUCT_SALES VALUES ('1012', 'Prod115');
INSERT INTO PRODUCT_SALES VALUES ('1013', 'Prod112');