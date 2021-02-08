create table Cars
(
Id int not null,
BrandId int not null,
ColorId int not null,
DailyPrice decimal not null,
ModelYear int not null,
Description varchar(255) not null,
primary key(Id)
)