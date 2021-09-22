-- User Table 
drop table Users;
create table Users(
	id int primary key identity(1,1) not null,
	Name varchar(80) not null,
	Gender char not null,
	email varchar(50) not null unique,
	Zipcode int 
);
--insert into Users values();
insert into Users(Name,Gender,email,Zipcode) values ('Ramya','F','ramya145@gmail.com',12345)
insert into Users(Name,Gender,email,Zipcode) values ('Ajay','M','ajaytiwari@gmail.com',64535)
insert into Users(Name,Gender,email,Zipcode) values ('Sushma','F','sushpa12@gmail.com',45673)
insert into Users(Name,Gender,email,Zipcode) values ('Ron','M','ron78@gmail.com',33478)
insert into Users(Name,Gender,email,Zipcode) values ('Mitali','F','mitalij24@gmail.com',44407)
insert into Users(Name,Gender,email,Zipcode) values ('Aman','M','aman2000@gmail.com',98700)

select * from Users;

--Login Table
drop table Login;
create table Login(
	id int primary key identity(1,1) not null,
	user_id int references Users(id) not null,
	Password varchar(80) not null,
);
insert into Login values (1,'ramya123')
insert into Login values (2,'ajay367')
insert into Login values (3,'sushma98')
insert into Login values (4,'ron165')
insert into Login values (5,'mitali24')
insert into Login values (6,'amans45')

select * from Login;

-- Sizes Table
drop table Sizes;
create table Sizes(
 id int primary key identity(1,1),
 name varchar(15) not null,
 price int not null
);

insert into Sizes values('Small',50)
insert into Sizes values('Medium',80)
insert into Sizes values('Large',120)

select * from Sizes;

-- Toppings Table
create table Toppings(
 id int primary key identity(1,1),
 name varchar(15) not null,
 price int not null
);

insert into Toppings values('Pepproni',30)
insert into Toppings values('Capsicum',45)
insert into Toppings values('Mushroom',60)
insert into Toppings values('Sausage',40)

select * from Toppings;

-- Pizzas Table
create table Pizzas(
	id int primary key identity(1,1),
	name varchar(50) not null,
    price int not null
);

insert into Pizzas values('CHINESE PIZZA',40);
insert into Pizzas values('THIN CRUST',20);
insert into Pizzas values('VEGGIE PARADISE',50);
insert into Pizzas values('MEXICAN GREEWAVE',60);
insert into Pizzas values('CHICKEN DOMINATOR PIZZA',90);
insert into Pizzas values('CHICKEN SAUSAGE PIZZA',110);
insert into Pizzas values('CHICKEN GOLDEN',170);

select * from Pizzas;

--Order Table 
drop table Orders;
create table Orders(
	id int primary key identity(1,1) not null,
	DateTime DateTime not null default sysdatetime(),
	status varchar(20) not null,
	price int not null,
	user_id int foreign key references Users(id) not null 
);
insert into Orders values('2021-08-25','Completed',240,2);
insert into Orders values('2021-08-24','Completed',340,1);
insert into Orders values('2021-08-25','Completed',580,1);

select * from Orders;

-- TakingPizzaOrders Table
drop table TakingPizzaOrders;
create table TakingPizzaOrders(
	id int primary key identity(1,1) not null,
	PizzasId  int foreign key references Pizzas(id) not null,
	SizeId  int foreign key references Sizes(id) not null,
	ToppID  int foreign key references Toppings(id) not null,
	user_id int foreign key references Users(id) not null
);

select * from TakingPizzaOrders;

--Payment Table
drop table Payment;
create table Payment(
	id int primary key identity(1,1) not null,
	status  varchar(30) not null,
	method varchar(30) not null,
	OrderID int foreign key references Orders(id) not null
);
insert into Payment values('Successful','Online',1);
insert into Payment values('Successful','Cash On Delievery',2);

select * from Payment;

--OrderHistory Table
drop table OrderHistory;
create table OrderHistory(
	id int primary key identity(1,1) not null,
	OrderID int foreign key references Orders(id) not null
);

insert into OrderHistory values(1);
insert into OrderHistory values(2);
insert into OrderHistory values(3);
select * from OrderHistory;

-- Inventory Table
drop table Inventory;
create table Inventory(
	id int primary key identity(1,1) not null,
	name varchar(50) not null,
	quantity int not null
);
insert into Inventory values('CHINESE PIZZA',50);
insert into Inventory values('THIN CRUST',42);
insert into Inventory values('VEGGIE PARADISE',65);
insert into Inventory values('MEXICAN GREEWAVE',56);
insert into Inventory values('CHICKEN DOMINATOR PIZZA',26);
insert into Inventory values('CHICKEN SAUSAGE PIZZA',32);
insert into Inventory values('CHICKEN GOLDEN',54);

select * from Inventory;

--All Tables Data
select * from Users;
select * from Login;
select * from Pizzas;
select * from Sizes;
select * from Toppings;
select * from Orders;
select * from TakingPizzaOrders;
select * from OrderHistory;
select * from Inventory;
select * from Payment;