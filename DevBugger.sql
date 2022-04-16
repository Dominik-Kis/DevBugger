use master
GO
drop database DevBugger
GO
create database DevBugger
GO
use DevBugger
GO

--TABLES
create table AccountLevel(
IDAccountLevel int identity primary key,
Name nvarchar(20) not null,
)
GO

create table Account(
IDAccount int identity primary key,
AccountLevelID int foreign key references AccountLevel(IDAccountLevel) not null,
Email nvarchar(100) unique not null,
Username nvarchar(50) not null,
Password nvarchar(20) not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Created datetime DEFAULT getdate(),
)
GO

create table GamePage(
IDGamePage int identity primary key,
AccountID int foreign key references Account(IDAccount) not null,
Title nvarchar(100) not null,
Description nvarchar(2000) null,
Created datetime DEFAULT getdate(),
)
GO

create table BugCategory(
IDCategory int identity primary key,
Name nvarchar(100) not null,
Description nvarchar(500),
)
GO

create table BugReport(
IDBugReport int identity primary key,
BugCategoryID int foreign key references BugCategory(IDCategory) not null,
GamePageID int foreign key references GamePage(IDGamePage) not null,
AccountID int foreign key references Account(IDAccount) not null,
Titel nvarchar(100) not null,
Description nvarchar(2500) not null,
Created datetime DEFAULT getdate(),
)
GO

create table BugReportImage(
IDBugReportImage int identity primary key,
BugReportID int foreign key references BugReport(IDBugReport) not null,
Image varbinary(max) not null
)
GO

create table Comment(
IDComment int identity primary key,
BugReportID int foreign key references BugReport(IDBugReport) not null,
AccountID int foreign key references Account(IDAccount) not null,
Text nvarchar(2500) not null,
Created datetime DEFAULT getdate()
)
GO

--ACCOUNT PROCEDURES
CREATE proc createAccount
@AccountLevelID int,
@Email nvarchar(100),
@Username nvarchar(50),
@Password nvarchar(20),
@Firstname nvarchar(50),
@Lastname nvarchar(50),
@idAccount int output
as
INSERT into Account(AccountLevelID, Email, Username, Password, FirstName, LastName, Created)
values(@AccountLevelID, @Email, @Username, @Password, @FirstName, @LastName, getdate())
set @idAccount = SCOPE_IDENTITY()
GO

CREATE proc updateAccount
@IDAccount int,
@Username nvarchar(50),
@Password nvarchar(20),
@Firstname nvarchar(50),
@Lastname nvarchar(50)
as
UPDATE Account
set Username = @Username, Password = @Password, FirstName = @Firstname, LastName = @Lastname
where Account.IDAccount = @IDAccount
GO

CREATE proc selectAccount
@IDAccount int
as
SELECT * from Account
where Account.IDAccount = @IDAccount
GO

CREATE proc selectAccounts
as
SELECT * from Account
GO

CREATE proc loginAccount
@Email nvarchar(100),
@Password nvarchar(20)
as
SELECT * from Account
where Account.Email = @Email and Account.Password = @Password
GO