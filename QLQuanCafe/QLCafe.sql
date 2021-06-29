abc

use QLQuanCafe
go
create table TableFood (
	TableId int identity primary key,
	Name nvarchar(100),
	tableStatus nvarchar(100) 
)
go
create table Account (
	AccountId int identity primary key,
	DisplayName nvarchar(100) not null,
	UserName nvarchar(100) not null,
	AccountPass nvarchar(100) not null,
	AccountType bit not null
)
go
create table FoodCategory (
	CatId int identity primary key,
	Name nvarchar(100)
)
go
create table Food (
	FoodId int identity primary key,
	Name nvarchar(100),
	CatId int foreign key references FoodCategory (CatId),
	Price float not null default 0
)
go
create table Bill (
	BillId int identity primary key,
	DateCheckIn Date default getdate() not null,
	DateCheckOut Date,
	TableId int foreign key references TableFood (TableId),
	BillStatus bit not null
)
go
create table BillInfo (
	BillInforId int identity primary key,
	BillId int foreign key references Bill (BillId),
	FoodId int foreign key references Food (FoodId),
	countFood int default 0,

)
go
select * from Account
create proc getAccountByUsername
@username nvarchar(100)
as
begin
	select * from Account a where a.UserName= @username;
end
go
exec getAccountByUsername @username= N'hoainam'