CREATE TABLE CUSTOMER (
CUSTOMER_ID INT PRIMARY KEY NOT NULL,
FIRST_NAME VARCHAR(25) NOT NULL,
SURNAME VARCHAR(25) NOT NULL,
ADDRESS VARCHAR(50) NOT NULL,
CONTACT_NUMBER VARCHAR(25) NOT NULL,
EMAIL VARCHAR(25) NOT NULL
);

/

CREATE TABLE EMPLOYEE (
EMPLOYEE_ID CHAR(6) PRIMARY KEY NOT NULL,
FIRST_NAME VARCHAR(25) NOT NULL,
SURNAME VARCHAR(25) NOT NULL,
CONTACT_NUMBER VARCHAR(25) NOT NULL,
POSITION VARCHAR(25),
ADDRESS VARCHAR(50) NOT NULL,
EMAIL VARCHAR(25) NOT NULL
);

/

CREATE TABLE DELIVERY (
DELIVERY_ID INT PRIMARY KEY NOT NULL,
DESCRIPTION VARCHAR(250) NOT NULL,
DISPATCH_DATE DATE,
DELIVERY_DATE DATE
);

/

CREATE TABLE RETURNS (
RETURN_ID CHAR(6) PRIMARY KEY NOT NULL,
RETURN_DATE DATE NOT NULL,
REASON VARCHAR(250)
);

/

CREATE TABLE PRODUCT (
PRODUCT_ID INT PRIMARY KEY NOT NULL,
PRODUCT VARCHAR(100) NOT NULL,
PRICE DECIMAL(9, 2) NOT NULL,
QTY INT NOT NULL
);

CREATE TABLE BILLING (
BILL_ID INT PRIMARY KEY NOT NULL,
CUSTOMER_ID INT,
BILL_DATE DATE NOT NULL,
EMPLOYEE_ID CHAR(6),
CONSTRAINT FK_CUSTOMER_ID FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMER(CUSTOMER_ID),
CONSTRAINT FK_EMPLOYEE_ID FOREIGN KEY (EMPLOYEE_ID) REFERENCES EMPLOYEE(EMPLOYEE_ID)
);

/

CREATE TABLE PRODUCT_BILLING (
DELIVERY_ID INT,
RETURN_ID CHAR(6),
PRODUCT_ID INT,
BILL_ID INT,
CONSTRAINT FK_DELIVERY_ID FOREIGN KEY (DELIVERY_ID) REFERENCES DELIVERY(DELIVERY_ID),
CONSTRAINT FK_RETURN_ID FOREIGN KEY (RETURN_ID) REFERENCES RETURNS(RETURN_ID),
CONSTRAINT FK_PRODUCT_ID FOREIGN KEY (PRODUCT_ID) REFERENCES PRODUCT(PRODUCT_ID),
CONSTRAINT FK_BILL_ID FOREIGN KEY (BILL_ID) REFERENCES BILLING(BILL_ID)
);

/

INSERT ALL
    INTO CUSTOMER VALUES (11011, 'Jeffery', 'Smith', '18 Water rd', '0877277521', 'jef@isat.com')
    INTO CUSTOMER VALUES (11012, 'Alex', 'Hendricks', '22 Water rd', '0863257857', 'ah@mcom.co.za')
    INTO CUSTOMER VALUES (11013, 'Johnson', 'Clark', '101 Summer lane', '0834567891', 'jclark@mcom.co.za')
    INTO CUSTOMER VALUES (11014, 'Henry', 'Jones', '55 Mountain way', '0612547895', 'hj@isat.co.za')
    INTO CUSTOMER VALUES (11015, 'Andre', 'Williams', '5 Main rd', '0827238521', 'aw@mcal.co.za')
SELECT * FROM dual;

/

INSERT ALL
    INTO EMPLOYEE VALUES ('emp101', 'Roan', 'Davis', '0877277521', 'sales', '10 main Road', 'rd@isat.com')
    INTO EMPLOYEE VALUES ('emp102', 'Billy', 'Marks', '0837377522', 'marketing', '18 water road', 'bmark@isat.com')
    INTO EMPLOYEE VALUES ('emp103', 'Chadwin', 'Andrews', '0817117523', 'sales', '21 circle lane', 'ca@isat.com')
    INTO EMPLOYEE VALUES ('emp104', 'Wayne', 'Dryer', '0797215244', 'sales', '1 sea road', 'dryer@isat.com')
    INTO EMPLOYEE VALUES ('emp105', 'Jaci', 'Samson', '0827122255', 'manager', '12 main road', 'samjax@isat.com')
SELECT * FROM dual;

/

INSERT ALL
    INTO DELIVERY VALUES (511, 'Delivery contains glass items - fragile', '10 May 2017', '15 May 2017')
    INTO DELIVERY VALUES (512, 'Delivery of wooden items', '12 May 2017', '15 May 2017')
    INTO DELIVERY VALUES (513, 'No description available', '12 May 2017', '17 May 2017')
    INTO DELIVERY VALUES (514, 'Delivery contains glass items - fragile', '12 May 2017', '15 May 2017')
    INTO DELIVERY VALUES (515, 'Delivery contains glass items - fragile', '18 May 2017', '19 May 2017')
    INTO DELIVERY VALUES (516, 'No description available', '20 May 2017', '25 May 2017')
    INTO DELIVERY VALUES (517, 'Delivery of wooden items', '25 May 2017', '27 May 2017')
SELECT * FROM dual;

/

INSERT ALL
    INTO RETURNS VALUES ('ret001', '25 May 2017', 'Customer not satisfied with product')
    INTO RETURNS VALUES ('ret002', '25 May 2017', 'Product missing part')
SELECT * FROM dual;

/

INSERT ALL
    INTO PRODUCT VALUES (7111, 'Four Piece Wall Unit', 10999, 10)
    INTO PRODUCT VALUES (7112, 'Plasma Stand Unit', 7999, 8)
    INTO PRODUCT VALUES (7113, 'Leather Recliner', 5999, 8)
    INTO PRODUCT VALUES (7114, 'Leather Lazy Boy', 7999, 5)
    INTO PRODUCT VALUES (7115, '6 Piece Fabric Suite', 17999, 15)
    INTO PRODUCT VALUES (7116, '6 Piece Leather Suite', 27999, 12)
    INTO PRODUCT VALUES (7117, '6 Seater Oak Dining table', 11999, 3)
SELECT * FROM dual;

/

INSERT ALL
    INTO BILLING VALUES (8111, 11011, '15 May 2017', 'emp103')
    INTO BILLING VALUES (8112, 11013, '15 May 2017', 'emp101')
    INTO BILLING VALUES (8113, 11012, '17 May 2017', 'emp101')
    INTO BILLING VALUES (8114, 11015, '17 May 2017', 'emp102')
    INTO BILLING VALUES (8115, 11011, '17 May 2017', 'emp102')
    INTO BILLING VALUES (8116, 11015, '18 May 2017', 'emp103')
    INTO BILLING VALUES (8117, 11012, '19 May 2017', 'emp101')
    INTO BILLING VALUES (8118, 11013, '19 May 2017', 'emp105')
SELECT * FROM dual;

/

INSERT ALL
    INTO PRODUCT_BILLING VALUES (512, null, 7113, 8115)
    INTO PRODUCT_BILLING VALUES (511, null, 7111, 8111)
    INTO PRODUCT_BILLING VALUES (512, null, 7111, 8114)
    INTO PRODUCT_BILLING VALUES (514, 'ret001', 7113, 8113)
    INTO PRODUCT_BILLING VALUES (516, null, 7115, 8112)
    INTO PRODUCT_BILLING VALUES (515, 'ret002', 7114, 8113)
    INTO PRODUCT_BILLING VALUES (517, null, 7113, 8115)
    INTO PRODUCT_BILLING VALUES (511, null, 7112, 8118)
    INTO PRODUCT_BILLING VALUES (513, null, 7111, 8117)
    INTO PRODUCT_BILLING VALUES (512, null, 7115, 8116)
SELECT * FROM dual;

/
