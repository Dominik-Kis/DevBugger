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

--Dummy
CREATE proc updateToDummy
@idAccount int
as
declare  @AccountLevelID int
declare  @Email nvarchar(100)
declare  @Username nvarchar(50)
declare  @Password nvarchar(20)
declare  @Firstname nvarchar(50)
declare  @Lastname nvarchar(50)
Select @AccountLevelID = a.AccountLevelID, @Email = a.Email, @Username = a.Username, 
@Password = a.Password, @Firstname = a.FirstName, @Lastname = a.LastName
from Account as a where a.Firstname like 'Dummy' and  a.Lastname like 'Account'
update Account
set Username = @Username, Password = @Password, FirstName = @Firstname, LastName = @Lastname, AccountLevelID = @AccountLevelID
where Account.IDAccount = @idAccount
GO




--GAME PAGE PROCEDURES
CREATE proc createGamePage
@AccountID int,
@Title nvarchar(100),
@Description nvarchar(2000),
@idGamePage int output
as
INSERT into GamePage(AccountID, Title, Description, Created)
values(@AccountID, @Title, @Description, getdate())
set @idGamePage = SCOPE_IDENTITY()
GO

CREATE proc updateGamePage
@AccountID int,
@Created datetime,
@Title nvarchar(100),
@Description nvarchar(2000),
@idGamePage int
as
UPDATE GamePage
set AccountID = @AccountID, Title = @Title, Description = @Description, Created = @Created
where IDGamePage = @idGamePage
GO

CREATE proc selectGamePage
@idGamePage int
as
SELECT * from GamePage
where IDGamePage = @idGamePage
GO

CREATE proc selectGamePages
as
SELECT * from GamePage
GO

CREATE proc deleteGamePage
@idGamePage int
as
DELETE FROM GamePage
where IDGamePage = @idGamePage
GO


--BUG CATEGORY
CREATE proc createBugCategory
@Name nvarchar(100),
@Description nvarchar(500),
@idCategory int output
as
INSERT into BugCategory(Name, Description)
values(@Name, @Description)
set @idCategory = SCOPE_IDENTITY()
GO

CREATE proc updateBugCategory
@Name nvarchar(100),
@Description nvarchar(500),
@idCategory int
as
UPDATE BugCategory
set Name = @Name, Description = @Description
where IDCategory = @idCategory
GO

CREATE proc selectBugCategory
@idCategory int
as
SELECT * from BugCategory
where IDCategory = @idCategory
GO

CREATE proc selectBugCategories
as
SELECT * from BugCategory
GO

CREATE proc deleteBugCategory
@idCategory int
as

declare @id int
select @id = IDCategory FROM BugCategory
WHERE BugCategory.Name = '[Unspecified]'

UPDATE BugReport
SET BugCategoryID = @id 
WHERE BugCategoryID = @idCategory

DELETE FROM BugCategory
where IDCategory = @idCategory
GO



--BUG REPORT
CREATE proc createBugReport
@BugCategoryID int,
@GamePageID int,
@AccountID int,
@Titel nvarchar(100),
@Description nvarchar(2500),
@idBugReport int output
as
INSERT into BugReport(BugCategoryID, GamePageID, AccountID, Titel, Description, Created)
values(@BugCategoryID, @GamePageID, @AccountID, @Titel, @Description, getdate())
set @idBugReport = SCOPE_IDENTITY()
GO

CREATE proc updateBugReport
@BugCategoryID int,
@GamePageID int,
@AccountID int,
@Titel nvarchar(100),
@Description nvarchar(2500),
@idBugReport int
as
UPDATE BugReport
set BugCategoryID = @BugCategoryID, GamePageID = @GamePageID, AccountID = @AccountID, Titel = @Titel, Description = @Description
where IDBugReport = @idBugReport
GO

CREATE proc selectBugReport
@idBugReport int
as
SELECT * from BugReport
where IDBugReport = @idBugReport
GO

CREATE proc selectBugReports
as
SELECT * from BugReport
GO

CREATE proc deleteBugReport
@idBugReport int
as

DELETE FROM BugReportImage
WHERE IDBugReportImage=ANY(
SELECT IDBugReportImage FROM BugReportImage
WHERE BugReportID=@idBugReport);

DELETE FROM Comment
WHERE IDComment=ANY(
SELECT IDComment FROM Comment
WHERE BugReportID=@idBugReport);

DELETE FROM BugReport
where IDBugReport = @idBugReport
GO




--BUG REPORT IMAGE
CREATE proc createBugReportImage
@BugReportID int,
@Image varbinary(max),
@idBugReportImage int output
as
INSERT into BugReportImage(BugReportID, Image)
values(@BugReportID, @Image)
set @idBugReportImage = SCOPE_IDENTITY()
GO

CREATE proc updateBugReportImage
@BugReportID int,
@Image varbinary(max),
@idBugReportImage int
as
UPDATE BugReportImage
set BugReportID = @BugReportID, Image = @Image
where IDBugReportImage = @idBugReportImage
GO

CREATE proc selectBugReportImage
@idBugReportImage int
as
SELECT * from BugReportImage
where IDBugReportImage = @idBugReportImage
GO

CREATE proc selectBugReportImages
as
SELECT * from BugReportImage
GO

CREATE proc deleteBugReportImage
@idBugReportImage int
as
DELETE FROM BugReportImage
where IDBugReportImage = @idBugReportImage
GO



--COMMENT PROCEDURES
CREATE proc createComment
@BugReportID int,
@AccountID int,
@Text nvarchar(2500),
@idComment int output
as
INSERT into Comment(BugReportID, AccountID, Text, Created)
values(@BugReportID, @AccountID, @Text, getdate())
set @idComment = SCOPE_IDENTITY()
GO

CREATE proc updateComment
@BugReportID int,
@AccountID int,
@Text nvarchar(2500),
@Created datetime,
@idComment int
as
UPDATE Comment
set BugReportID = @BugReportID, AccountID = @AccountID, Text = @Text 
where IDComment = @idComment
GO

CREATE proc selectComment
@idComment int
as
SELECT * from Comment
where IDComment = @idComment
GO

CREATE proc selectComments
as
SELECT * from Comment
GO

CREATE proc deleteComment
@idComment int
as
DELETE FROM Comment
where IDComment = @idComment
GO
