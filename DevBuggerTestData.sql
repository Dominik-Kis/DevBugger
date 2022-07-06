insert into AccountLevel values ('test')
declare @id int
select @id = a.IDAccountLevel from AccountLevel as a where a.Name like 'test' 

declare @outID1 int
declare @outID2 int
declare @outID3 int
declare @outID4 int
declare @outID5 int

exec createAccount @id,'deleteted-account@mail.com','[Deleted_account]','IKnM/SWmwl0kHiP36gZ/RQQ68OaYrY13YAys5YDRb34=','Deleted','Account', @outID1 output

exec createAccount @id,'test1@mail.com','test','2jonN7v33cMAvv/2Z6Uu0R+V95oP9S8k1wiQ1sdSPD0=','te','st', @outID2 output

exec createAccount @id,'test2@mail.com','test2','2jonN7v33cMAvv/2Z6Uu0R+V95oP9S8k1wiQ1sdSPD0=','te','st', @outID3 output

exec createAccount @id,'test3@mail.com','test3','2jonN7v33cMAvv/2Z6Uu0R+V95oP9S8k1wiQ1sdSPD0=','te','st', @outID4 output

exec createAccount @id,'ivana@mail.com','ivana','2jonN7v33cMAvv/2Z6Uu0R+V95oP9S8k1wiQ1sdSPD0=','ivana','dzapo', @outID5 output

--Ml6YBKF5pYsjltNcFC9oSNTrPdjPqrfHVu6TKu8rm+0=
--hashiran je 
--test


declare @gamePageID1 int
declare @gamePageID2 int
declare @gamePageID3 int
declare @gamePageID4 int
exec createGamePage @outID2, 'Skyrim', 'Elder Scrolls V', @gamePageID1 output
exec createGamePage @outID3, 'Fortnite', 'no life kids', @gamePageID2 output
exec createGamePage @outID4, 'Town of salem', 'Lie to everyone', @gamePageID3 output
exec createGamePage @outID5, 'Minecraft', 'block game', @gamePageID4 output

declare @bugCategoryID1 int
declare @bugCategoryID2 int
declare @bugCategoryID3 int
declare @bugCategoryID4 int
exec createBugCategory 'Collision', 'Objects coliding', @bugCategoryID1 output
exec createBugCategory 'Exploit', 'Game breaking bug', @bugCategoryID2 output
exec createBugCategory 'Crash', 'Game crash', @bugCategoryID3 output
exec createBugCategory 'Audio', 'Game crash', @bugCategoryID4 output


declare @idBugReport1 int 
declare @idBugReport2 int 
declare @idBugReport3 int 
declare @idBugReport4 int 
exec createBugReport @bugCategoryID1, @gamePageID1, @outID2, 'Skyrim stuck in wall', 'Use plate to enter walls', @idBugReport1 output
exec createBugReport @bugCategoryID2, @gamePageID2, @outID3, 'Fortnite V-bucks glitch', 'Close connection fast after purchase', @idBugReport2 output
exec createBugReport @bugCategoryID3, @gamePageID3, @outID4, 'Win a game as Survivor', 'In some cases the game cant belive you did it', @idBugReport3 output
exec createBugReport @bugCategoryID4, @gamePageID4, @outID5, 'Build a house', 'I love blocks <3', @idBugReport4 output




declare @image varbinary(max)
set @image = cast('iVBORw0KGgoAAAANSUhEUgAAABgAAAAVCAYAAABc6S4mAAAAAXNSR0IArs4c6QAAAARnQU1BAACx
jwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABKSURBVEhL7Y2pDQAgAMQYmGUYhoUQvIYNDnMC
wQ1Ack3qmjTU1nE75sJN3hmxxKdpJlYaD1hpPGCl8YCVxgNWGg9YaTxgpfl9ABy89/uSSBK23gAA
AABJRU5ErkJggg==' as varbinary)

declare @idBugReportImage1 int 
declare @idBugReportImage2 int 
declare @idBugReportImage3 int 
exec createBugReportImage @idBugReport1, @image, @idBugReportImage1 output
exec createBugReportImage @idBugReport2, @image, @idBugReportImage2 output
exec createBugReportImage @idBugReport3, @image, @idBugReportImage3 output



declare @comment1 int 
declare @comment2 int 
declare @comment3 int  
declare @comment4 int 
declare @comment5 int 
declare @comment6 int  
declare @comment7 int 
declare @comment8 int 
exec createComment @idBugReport1, @outID2, 'I used a chicken breast to get into a wall', @comment1 output
exec createComment @idBugReport2, @outID3, 'got a number one victory royale yeah fortnite we bout to get down (get down)
ten kills on the board right now just wiped out tomato town', @comment2 output
exec createComment @idBugReport3, @outID4, 'Tarnation', @comment3 output
exec createComment @idBugReport1, @outID4, 'Vote Giles Corey', @comment4 output
exec createComment @idBugReport2, @outID3, 'One more game', @comment5 output
exec createComment @idBugReport3, @outID2, 'I used to be an adventurer like you...then I took an arrow to the knee!', @comment6 output
exec createComment @idBugReport4, @outID5, 'Vote Giles Corey', @comment7 output
exec createComment @idBugReport4, @outID5, 'One more game', @comment8 output


--SELECT TO TEST INPUT
select * from AccountLevel, Account, GamePage, BugCategory, BugReport, BugReportImage, Comment


-- DELETE ALL DATA FROM DB
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' 
GO 
EXEC sp_MSForEachTable 'DELETE FROM ?' 
GO 
EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL' 
GO