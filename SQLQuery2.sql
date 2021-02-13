create table Users
(
Id int identity(1,1) not null,
MailAdress nvarchar(255) unique not null,
Password nvarchar(255) not null,
Role nvarchar(255) not null,
)