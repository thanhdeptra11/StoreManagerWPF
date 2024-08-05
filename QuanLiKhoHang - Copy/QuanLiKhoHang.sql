Create database QuanLiKhoHang
go 
use QuanLiKhoHang
go
create table Unit(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(100)
)
go
create table Supplier(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(200),
	Address nvarchar(200),
	Phone nvarchar(50),
	Email nvarchar(200),
	MoreInfo nvarchar(2000),
	ContractDate DateTime
)
go
create table Customer(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(200),
	Address nvarchar(200),
	Phone nvarchar(50),
	Email nvarchar(200),
	MoreInfo nvarchar(2000),
	ContractDate DateTime
)
go
create table ObjectItem(
	Id nvarchar(128) primary key,
	DisplayName nvarchar(200),
	IdUnit int not null,
	IdSupplier int not null,
	foreign key(IdUnit) references Unit(Id),
	foreign key(IdSupplier) references Supplier(Id),


)
go
create table UserRole(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(200),
	
)
go
create table UserApp(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(200),
	UserName nvarchar(200),
	Password nvarchar(max),
	IdRole int not null,
	foreign key(IdRole) references UserRole(Id),

)
go
create table Input(
	Id nvarchar(128) primary key,
	DateInput Datetime
)
go 
create table InputInfo(
	Id nvarchar(128) primary key,
	IdObject nvarchar(128) not null,
	IdInput nvarchar(128) not null,
	Count int,
	InputPrice float default 0,
	OutputPrice float default 0, 
	Status nvarchar(50),
	foreign key(IdObject) references ObjectItem(Id),
	foreign key(IdInput) references Input(Id)

)
create table Output(
	Id nvarchar(128) primary key,
	DateOutput Datetime
)
go 
create table OutputInfo(
	Id nvarchar(128) primary key,
	IdObject nvarchar(128) not null,
	IdOutput nvarchar(128) not null,
	IdInputInfo nvarchar(128) not null,
	IdCustomer int not null,

	Count int,
	Status nvarchar(50),
	foreign key(IdObject) references ObjectItem(Id),
	foreign key(IdOutput) references Output(Id),
	foreign key(IdInputInfo) references InputInfo(Id),
	foreign key(IdCustomer) references Customer(Id),
)
insert into UserRole (DisplayName) values ('Admin');
insert into UserRole (DisplayName) values ('Staff');
insert into UserApp (DisplayName) values ('lhoundson2');
insert into UserApp (DisplayName) values ('ablucher3');
insert into UserApp (DisplayName) values ('rsympson4')

Delete from UserApp
insert into UserApp (DisplayName, UserName, Password, IdRole) values ('Eustace', 'ehendriks0', 'rE0(', 1);
insert into UserApp (DisplayName, UserName, Password, IdRole) values ('Carroll', 'cgard1', 'vL6}', 2);
insert into UserApp (DisplayName, UserName, Password, IdRole) values ('Tamas', 'tivashinnikov2', 'yX2_', 1);
insert into UserApp (DisplayName, UserName, Password, IdRole) values ('Hurlee', 'hmanston3', 'jL7/+U', 2);
insert into UserApp (DisplayName, UserName, Password, IdRole) values ('Test', 'Test', '1', 1);
insert into UserApp (DisplayName, UserName, Password, IdRole) values ('Test2', 'Test2', '1', 2);
insert into UserApp (DisplayName, UserName, Password, IdRole) values ('Test3', 'Test3', '1a816f206f0a363dc63e8f2cb14f649c', 2);
insert into UserApp (DisplayName, UserName, Password, IdRole) values ('Test4', 'Test4', '1a816f206f0a363dc63e8f2cb14f649c', 1);
Alter table UserApp
Add Request nvarchar(100);

Alter table InputInfo
Add UserId int null;

Alter table InputInfo
Add Constraint FK_InputInfo_UserApp
Foreign Key(UserId) references UserApp(Id)

Alter table OutputInfo
Add UserId int null;

Alter table OutputInfo
Add Constraint FK_OutputInfo_UserApp
Foreign Key(UserId) references UserApp(Id)
