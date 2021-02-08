create table Brands
(
Id int identity(1,1) not null,
Name text unique not null,
primary key(Id)
)

create table Colors
(
Id int identity(1,1) not null,
Name text unique not null,
primary key(Id)
)

create table Cars
(
Id int identity(1,1) not null,
BrandId int not null,
ColorId int not null,
ModelYear int not null,
DailyPrice decimal not null,
Description text not null,
primary key(Id),
foreign key(BrandId) references Brands(Id),
foreign key(ColorId) references Colors(Id)
)


drop table Cars
drop table Colors
drop table Brands

create database CarRentSystem