create database CarRentSystem

create table Colors
(
Id int identity(1,1) not null,
Name nvarchar(255) not null,
primary key(Id),

)

create table Brands
(
Id int identity(1,1) not null,
Name nvarchar(255) not null,
primary key(Id),

)

create table Models
(
Id int identity(1,1) not null,
BrandId int not null,
Name nvarchar(255) not null,
primary key(Id),
foreign key(BrandId) references Brands(Id)
)

create table Cars
(
Id int identity(1,1) not null,
BrandId int not null,
ColorId int not null,
ModelId int not null,
ModelYear int not null,
DailyPrice decimal not null,
Description nvarchar(255) not null,
primary key(Id),
foreign key(BrandId) references Brands(Id),
foreign key(ColorId) references Colors(Id),
foreign key(ModelId) references Models(Id)
)

create table Users
(
Id int identity(1,1) not null,
FirstName nvarchar(255) not null,
LastName nvarchar(255) not null,
Email nvarchar(255) not null,
Password nvarchar(255) not null,
primary key(Id)
)

create table Customers
(
Id int identity(1,1) not null,
UserId int not null,
CompanyName nvarchar(255) not null,
primary key(Id),
foreign key(UserId) references Users(Id)
)

create table Rentals
(
Id int identity(1,1) not null,
CarId int not null,
CustomerId int not null,
RentDate datetime not null,
ReturnDate datetime,
primary key(Id),
foreign key(CarId) references Cars(Id),
foreign key(CustomerId) references Customers(Id)
)