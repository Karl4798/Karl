/*Preload for TRAVEL BY BUS
'Please run this query using SQL Developer or SQL*Plus'*/ 

Create table BUS
(
  VIN                number(13)       not null    primary key,
  bus_type           varchar2(100)    not null,
  num_of_passengers  number(3)    not null,
  bus_colour         varchar2(10)     not null,
  bus_odometer       number(8,2)      not null
);
Create table CUSTOMER
(
  cust_id            varchar2(5)    not null    primary key,
  cust_fname         varchar2(100)  not null,
  cust_sname         varchar2(100)  not null,
  cust_address       varchar2(200)   not null,
  cust_contact       varchar2(12)  not null
);
Create table LOCATIONS
(
  location_id        number(5)         not null    primary key,
  location_name      varchar2(100)     not null,
  location_province  varchar2(100)         not null,
  location_price     number(3)  not null
);
Create table BOOKING
(
  booking_id         number(5)       not null    primary key,
  booking_date       varchar2(100)    not null,
  VIN                number(13)       not null constraint fk_bus_id
                     references BUS(VIN),
  cust_id        varchar2(5)     not null constraint fk_cus_id
                     references CUSTOMER(cust_id),
  location_id        number(5)       not null constraint fk_loc_id
                     references LOCATIONS(location_id)
);
create table CANCELLATIONS
(
  cancel_id        number(3)       not null  primary key,
  cancel_reason    varchar2(100)   null,
  booking_id       number(13)       not null constraint fk_booking_id
                   references BOOKING(booking_id)
);
insert all
   into BUS(VIN, bus_type, num_of_passengers, bus_colour, bus_odometer)
    values('1235251524', 'Public Transport', 100,  'Red', '125835')
   into BUS(VIN, bus_type, num_of_passengers, bus_colour, bus_odometer)
    values('7235251524', 'Tourism', 150,  'White', '22521')
   into BUS(VIN, bus_type, num_of_passengers, bus_colour, bus_odometer)
    values('8235251524', 'Party Events',70,  'Yellow', '352254')
   into BUS(VIN, bus_type, num_of_passengers, bus_colour, bus_odometer)
    values('9235251524', 'Private Events',50,  'Silver', '10150')
    into BUS(VIN, bus_type, num_of_passengers, bus_colour, bus_odometer)
    values('2235251524', 'Public Transport',100,  'Silver', '11150')
Select * from dual;
Commit;

 insert all
   into CUSTOMER(cust_id, cust_fname, cust_sname, cust_address, cust_contact)
    values('C115', 'Heinrich', 'Willis',  '3 Main Road', '0821253659')
   into CUSTOMER(cust_id, cust_fname, cust_sname, cust_address, cust_contact)
    values('C116', 'David', 'Watson',  '13 Cape Road', '0769658547')
   into CUSTOMER(cust_id, cust_fname, cust_sname, cust_address, cust_contact)
    values('C117', 'Waldo', 'Smith',  '3 Mountain Road', '0863256574')
   into CUSTOMER(cust_id, cust_fname, cust_sname, cust_address, cust_contact)
     values('C118', 'Alex', 'Hanson',  '8 Circle Road', '0762356587')
   into CUSTOMER(cust_id, cust_fname, cust_sname, cust_address, cust_contact)
    values('C119', 'Kuhle', 'Bitterhout', '15 Main Road', '0821235258')
   into CUSTOMER(cust_id, cust_fname, cust_sname, cust_address, cust_contact)
    values('C120', 'Thando', 'Zolani', '88 Summer Road', '0847541254')
   into CUSTOMER(cust_id, cust_fname, cust_sname, cust_address, cust_contact)
    values('C121', 'Philip', 'Jackson',  '3 Long Road', '0745556658')
   into CUSTOMER(cust_id, cust_fname, cust_sname, cust_address, cust_contact)
    values('C122', 'Sarah', 'Jones',  '7 Sea Road', '0814745745')
  Select * from dual;
  Commit;
  
insert all
   into LOCATIONS(location_id, location_name, location_province, location_price)
    values(555, 'Cape Town', 'Western Cape',  895)
   into LOCATIONS(location_id, location_name, location_province, location_price)
    values(556, 'Durban', 'Kwazulu Natal',  325)
   into LOCATIONS(location_id, location_name, location_province, location_price)
    values(557, 'Port Elizabeth','Eastern Cape', 755)
   into LOCATIONS(location_id, location_name, location_province, location_price)
    values(558, 'Pretoria','Guateng',  235)
   into LOCATIONS(location_id, location_name, location_province, location_price)
    values(559, 'Johannesburg','Gauteng',   899)
Select * from dual;
Commit;

insert all
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11101,  '15 June 2017',  '1235251524','C115', 555)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11102, '15 June 2017',  '7235251524','C117', 556)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11103, '17 June 2017', '9235251524', 'C118', 557)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11104, '18 June 2017',   '2235251524', 'C115', 558)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11105, '19 June 2017',  '8235251524', 'C120',559)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11106, '20 June 2017',   '7235251524', 'C121', 556)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11107, '20 June 2017',   '1235251524','C122', 555)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11108, '21 June 2017',    '9235251524', 'C115', 557)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11109, '25 June 2017',    '8235251524', 'C118', 559)
   into BOOKING(booking_id, booking_date, VIN, cust_id, location_id)
    values(11111, '27 June 2017',   '8235251524', 'C119', 559)
Select * from dual;
Commit;

insert all
   into CANCELLATIONS(cancel_id, cancel_reason, booking_id)
    values(210, 'Customer ill', 11111)
   into CANCELLATIONS(cancel_id, cancel_reason, booking_id)
    values(211, 'Bad Weather', 11106)
   into CANCELLATIONS(cancel_id, cancel_reason, booking_id)
    values(212, 'To be rescheduled', 11104)
Select * from dual;
Commit;
