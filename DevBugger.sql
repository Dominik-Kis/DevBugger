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
Password nvarchar(100) not null,
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
Title nvarchar(100) not null,
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
@Password nvarchar(100),
@Firstname nvarchar(50),
@Lastname nvarchar(50),
@IDAccount int output
as
INSERT into Account(AccountLevelID, Email, Username, Password, FirstName, LastName, Created)
values(@AccountLevelID, @Email, @Username, @Password, @FirstName, @LastName, getdate())
set @IDAccount = SCOPE_identity()
GO

CREATE proc updateAccount
@IDAccount int,
@Username nvarchar(50),
@Password nvarchar(100),
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
@Password nvarchar(100)
as
SELECT * from Account
where Account.Email = @Email and Account.Password = @Password
GO

--Dummy
CREATE proc updateToDummy
@IDAccount int
as
declare  @Username nvarchar(50) = '[Deleted_account]'
declare  @Password nvarchar(100) = 'go342mjkojsdpkijgmkiWEENMGKwnghare'
declare  @Firstname nvarchar(50) = 'Deleted'
declare  @Lastname nvarchar(50) = 'Account'
update Account
set Username = @Username, Password = @Password, FirstName = @Firstname, LastName = @Lastname
where Account.IDAccount = @IDAccount
GO




--GAME PAGE PROCEDURES
CREATE proc createGamePage
@AccountID int,
@Title nvarchar(100),
@Description nvarchar(2000),
@IDGamePage int output
as
INSERT into GamePage(AccountID, Title, Description, Created)
values(@AccountID, @Title, @Description, getdate())
set @IDGamePage = SCOPE_identity()
GO

CREATE proc updateGamePage
@AccountID int,
@Created datetime,
@Title nvarchar(100),
@Description nvarchar(2000),
@IDGamePage int
as
UPDATE GamePage
set AccountID = @AccountID, Title = @Title, Description = @Description, Created = @Created
where IDGamePage = @IDGamePage
GO

CREATE proc selectGamePage
@IDGamePage int
as
SELECT * from GamePage
where IDGamePage = @IDGamePage
GO

CREATE proc selectGamePages
as
SELECT * from GamePage
GO

CREATE proc deleteGamePage
@IDGamePage int
as
declare @id int
while exists (select 1 from BugReport where GamePageID = @IDGamePage)
begin
     select top 1 @id = IDBugReport from BugReport where GamePageID = @IDGamePage 

     exec deleteBugReport @id
end
DELETE FROM GamePage
Where IDGamePage = @IDGamePage

GO
CREATE proc selectGamePageByAccountID
@IDAccount int
as
SELECT * from GamePage as gp
where AccountID = @IDAccount
GO


--BUG CATEGORY
CREATE proc createBugCategory
@Name nvarchar(100),
@Description nvarchar(500),
@IDCategory int output
as
INSERT into BugCategory(Name, Description)
values(@Name, @Description)
set @IDCategory = SCOPE_identity()
GO

CREATE proc updateBugCategory
@Name nvarchar(100),
@Description nvarchar(500),
@IDCategory int
as
UPDATE BugCategory
set Name = @Name, Description = @Description
where IDCategory = @IDCategory
GO

CREATE proc selectBugCategory
@IDCategory int
as
SELECT * from BugCategory
where IDCategory = @IDCategory
GO

CREATE proc selectBugCategories
as
SELECT * from BugCategory
GO

CREATE proc deleteBugCategory
@IDCategory int
as

declare @ID int
select @ID = IDCategory FROM BugCategory
WHERE BugCategory.Name = '[Unspecified]'

UPDATE BugReport
SET BugCategoryID = @ID 
WHERE BugCategoryID = @IDCategory

DELETE FROM BugCategory
where IDCategory = @IDCategory
GO



--BUG REPORT
CREATE proc createBugReport
@BugCategoryID int,
@GamePageID int,
@AccountID int,
@Title nvarchar(100),
@Description nvarchar(2500),
@IDBugReport int output
as
INSERT into BugReport(BugCategoryID, GamePageID, AccountID, Title, Description, Created)
values(@BugCategoryID, @GamePageID, @AccountID, @Title, @Description, getdate())
set @IDBugReport = SCOPE_identity()
GO

CREATE proc updateBugReport
@BugCategoryID int,
@GamePageID int,
@AccountID int,
@Title nvarchar(100),
@Description nvarchar(2500),
@IDBugReport int
as
UPDATE BugReport
set BugCategoryID = @BugCategoryID, GamePageID = @GamePageID, AccountID = @AccountID, Title = @Title, Description = @Description
where IDBugReport = @IDBugReport
GO

CREATE proc selectBugReport
@IDBugReport int
as
SELECT * from BugReport
where IDBugReport = @IDBugReport
GO

CREATE proc selectBugReports
as
SELECT * from BugReport
GO

CREATE proc deleteBugReport
@IDBugReport int
as

DELETE FROM BugReportImage
WHERE IDBugReportImage=ANY(
SELECT IDBugReportImage FROM BugReportImage
WHERE BugReportID=@IDBugReport);

DELETE FROM Comment
WHERE IDComment=ANY(
SELECT IDComment FROM Comment
WHERE BugReportID=@IDBugReport);

DELETE FROM BugReport
where IDBugReport = @IDBugReport
GO

CREATE proc selectBugReportsByAccountID
@AccountID int
as
SELECT * from BugReport as br
where br.AccountID = @AccountID
GO

CREATE proc selectBugReportsByGamePageID
@IDGamePage int
as
SELECT * from BugReport as br
where br.GamePageID = @IDGamePage
GO

CREATE proc selectBugReportsByBugCategoryID
@IDBugCategory int
as
SELECT * from BugReport as br
where br.BugCategoryID = @IDBugCategory
GO


--BUG REPORT IMAGE
CREATE proc createBugReportImage
@BugReportID int,
@Image varbinary(max),
@IDBugReportImage int output
as
INSERT into BugReportImage(BugReportID, Image)
values(@BugReportID, @Image)
set @IDBugReportImage = SCOPE_identity()
GO

CREATE proc updateBugReportImage
@BugReportID int,
@Image varbinary(max),
@IDBugReportImage int
as
UPDATE BugReportImage
set BugReportID = @BugReportID, Image = @Image
where IDBugReportImage = @IDBugReportImage
GO

CREATE proc selectBugReportImage
@IDBugReportImage int
as
SELECT * from BugReportImage
where IDBugReportImage = @IDBugReportImage
GO

CREATE proc selectBugReportImages
as
SELECT * from BugReportImage
GO

CREATE proc deleteBugReportImage
@IDBugReportImage int
as
DELETE FROM BugReportImage
where IDBugReportImage = @IDBugReportImage
GO

CREATE proc selectBugReportImagesByBugReportID
@IDBugReport int
as
SELECT * from BugReportImage as br
where br.BugReportID = @IDBugReport
GO



--COMMENT PROCEDURES
CREATE proc createComment
@BugReportID int,
@AccountID int,
@Text nvarchar(2500),
@IDComment int output
as
INSERT into Comment(BugReportID, AccountID, Text, Created)
values(@BugReportID, @AccountID, @Text, getdate())
set @IDComment = SCOPE_identity()
GO

CREATE proc updateComment
@BugReportID int,
@AccountID int,
@Text nvarchar(2500),
@IDComment int
as
UPDATE Comment
set BugReportID = @BugReportID, AccountID = @AccountID, Text = @Text 
where IDComment = @IDComment
GO

CREATE proc selectComment
@IDComment int
as
SELECT * from Comment
where IDComment = @IDComment
GO

CREATE proc selectComments
as
SELECT * from Comment
GO

CREATE proc deleteComment
@IDComment int
as
DELETE FROM Comment
where IDComment = @IDComment
GO

CREATE proc selectCommentsByAccountID
@AccountID int
as
SELECT * from Comment as c
where c.AccountID = @AccountID
GO

CREATE proc selectCommentsByBugReportID
@BugReportID int
as
SELECT * from Comment as c
where c.BugReportID = @BugReportID
GO
