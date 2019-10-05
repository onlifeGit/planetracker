Use [DB_A2BB91_tempnameSoft1]

Exec sp_helpdb [DB_A2BB91_tempnameSoft1]

Create Table Users
(
	Id int Identity Not Null Primary Key,
	FName nvarchar(100) Not Null,
	LName nvarchar(100) Not Null,
	MName nvarchar(100) Null,
	BDay DateTime Null,
	Gender bit Null,
	Phone nvarchar(max) Not NUll,
	Email nvarchar(max) Not Null,
	[Password] nvarchar(max) Not Null,
	TwitterId int Null,
	Created DateTime Not Null
)

Drop Table SubscriptionCompanies
Drop Table SubscriptionFlights
Drop Table Logs

Drop Table Users


Create Table SubscriptionFlights
(
	Id int Identity Not Null Primary Key,
	FlightId int,
	UserId int Not Null Foreign Key References Users(Id),
	Created DateTime Not Null
)

Create Table SubscriptionCompanies
(
	Id int Identity Not Null Primary Key,
	CompanyId int Not Null,
	UserId int Not Null Foreign Key References Users(Id),
	Created DateTime Not Null
)

Create Table Logs
(
	Id int Identity Not Null Primary Key,
	Type int Not Null,
	Method nvarchar(max),
	[Message] nvarchar(max),
	Stack nvarchar(max),
	Created DateTime Not Null
)
