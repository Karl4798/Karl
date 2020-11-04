/*Preload for XTREME GEAR SA 
'Please run this query using SQL Developer or SQL*Plus'*/ 
Create table EMPLOYEE
(
  empID           number(5)      not null    primary key,
  first_name      varchar2(100)  not null,
  surname         varchar2(100)  not null,
  Contact_Num     varchar2(200)  not null,
  email           varchar2(50)   null,
  address         varchar2(200)  null
);
Create table CUSTOMER
(
  customerID       varchar2(5)    not null    primary key,
  first_name       varchar2(100)  not null,
  surname          varchar2(100)  not null,
  contact_num      varchar2(12)   not null,
  address          varchar2(200)  not null,
  bank             varchar2(20)   null
);
Create table SUPPLIER
(
  supplierID       number(5)      not null    primary key,
  supplierName     varchar2(100)  not null,
  contact_Num      varchar2(12)   null,
  rating           number(10)     null
);
Create table PRODUCT
(
  productID       varchar2(10)    not null    primary key,
  ProductName     varchar2(100)   not null,
  Price           float           not null,
  Warranty        varchar2(20)    not null,
  SupplierID      number(5)       not null constraint fk_supp_id
                  references Supplier(SupplierID)
);
Create table SALES
(
  saleID        varchar2(10)    not null    primary key,
  saleDate      date            not null,
  saleQty       number(10)      not null,
  empID         number(5)       not null constraint fk_or_supp_id
                references Employee(empID),
  customerID    varchar2(5)       not null constraint fk_or_cust_id
                references Customer(CustomerID)
);
Create table PRODUCT_SALES
(
  saleID      varchar2(5)   constraint fk_order_id
              references SALES(saleID),
  productID   varchar(10)     constraint fk_prod_id
              references PRODUCT(productID)
);

insert all
  into EMPLOYEE(empID, first_name, surname, contact_num, email, address)
    values(101, 'Cameron', 'Willis', '0843569851', 'cw@isat.co.za', '11 Main rd')
 into EMPLOYEE(empID, first_name, surname, contact_num, email, address)
   values(102, 'Jessie', 'Wait', '0763698521', 'jwait@imail.com', '27 Water way')
  into EMPLOYEE(empID, first_name, surname, contact_num, email, address)
    values(103, 'Andre', 'Gumede', '0786598521', 'agum@mcare.co.za', '15 Cape st')
  into EMPLOYEE(empID, first_name, surname, contact_num, email, address)
     values(104, 'Marie', 'Du Preez', '0796369857', 'mduppie@isat.co.za', '20 Long rd')
   into EMPLOYEE(empID, first_name, surname, contact_num, email, address)
   values(105, 'Eric', 'Jones', '0826598741', 'ejones@nrom.co.za', '3 Temperance st')
  Select * from dual;
  Commit;
  
  insert all
  into CUSTOMER(CustomerID, First_Name, Surname, contact_num, Address, Bank)
    values('A1001', 'Asavela', 'Bitterhout', '0769856895', '15 Table rd', 'Absa')
 into CUSTOMER(CustomerID, First_Name, Surname, contact_num, Address, Bank)
   values('A1002', 'Henry', 'James', '0742598657', '28 Sea Side rd', 'Nedbank')
 into CUSTOMER(CustomerID, First_Name, Surname, contact_num, Address, Bank)
    values('A1003', 'Joe', 'Bloggs', '0863256982', '19 Upper End', 'FNB')
 into CUSTOMER(CustomerID, First_Name, Surname, contact_num, Address, Bank)
     values('A1004', 'Clark', 'Smith', '0785659857', '27 South end', 'Absa')
 into CUSTOMER(CustomerID, First_Name, Surname, contact_num, Address, Bank)
   values('A1005', 'Jabu', 'Xolani', '0712369571', '12 Main rd', 'FNB')
  Select * from dual;
  Commit;
  
  insert all
  into SUPPLIER(SupplierID, SupplierName, Contact_Num, Rating)
    values(751, 'Adventure Gear', '0113256958', 7)
  into SUPPLIER(SupplierID, SupplierName, Contact_Num, Rating)
    values(752, 'Ultra Outdoor', '0212569857', 5)
  into SUPPLIER(SupplierID, SupplierName, Contact_Num, Rating)
     values(753, 'Xtreme Gear', '0310524589', 9)
  into SUPPLIER(SupplierID, SupplierName, Contact_Num, Rating)
      values(754, 'Sky and Surf Gear', '0412365987', 2)
  Select * from dual;
  
  insert all
  into PRODUCT(ProductID, ProductName, Price, Warranty, SupplierID)
    values('Prod111', 'X500 Kanoe', 7189.55, '2 year', 751)
    into PRODUCT(ProductID, ProductName, Price, Warranty, SupplierID)
    values('Prod112', 'Z200 Goggles', 1295.75, '1 year', 754)
   into PRODUCT(ProductID, ProductName, Price, Warranty, SupplierID)
     values('Prod113', 'K99 GPS Device', 2700.21, '2 years', 753)
    into PRODUCT(ProductID, ProductName, Price, Warranty, SupplierID)
      values('Prod114', 'L55 Moutain Harness', 800.25, '1 year', 752)
    into PRODUCT(ProductID, ProductName, Price, Warranty, SupplierID)
   values('Prod115', 'Aqua Extreme Watch', 3050.79, '2 years', 751)
  Select * from dual;
  Commit;
  

  
 insert all
  into SALES(saleID, saleDate, saleQty, empID, CustomerID)
    values(1010,	'15 October 2016',	10,	101,	'A1005')
  into SALES(saleID, saleDate, saleQty, empID, CustomerID)
    values(1011,	'18 October 2016',	3,	103,	'A1002')
  into SALES(saleID, saleDate, saleQty, empID, CustomerID)
     values(1012,	'20 October 2016',	15,	101,	'A1004')
  into SALES(saleID, saleDate, saleQty, empID, CustomerID)
      values(1013,	'22 October 2016',	21,	101,	'A1001')
  Select * from dual;
  Commit;
  
  
  insert all
  into PRODUCT_SALES(saleID, ProductID)
    values(1010,	'Prod111')
 into PRODUCT_SALES(saleID, ProductID)
    values(1011,	'Prod112')
  into PRODUCT_SALES(saleID, ProductID)
     values(1011,	'Prod111')
  into PRODUCT_SALES(saleID, ProductID)
      values(1012,	'Prod115')
  into PRODUCT_SALES(saleID, ProductID)
   values(1013,	'Prod112')
  Select * from dual;
Commit;