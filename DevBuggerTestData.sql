insert into AccountLevel values ('test')
declare @id int
select @id = a.IDAccountLevel from AccountLevel as a where a.Name like 'test' 

declare @outID int

exec createAccount 2,'deleteted-account@mail.com','Deleted','go342mjkojsdpkijgmkiWEENMGKwnghare','Deleted','Account', @outID

exec createAccount 2,'test1@mail.com','test','pass','te','st', @outID output

exec createAccount 2,'test2@mail.com','test2','pass','te','st', @outID output

exec createAccount 2,'test3@mail.com','test3','pass','te','st', @outID output

select * from Account



declare @gamePageID int
exec createGamePage @outID, 'Skyrim', 'Elder Scrolls V', @gamePageID output
exec createGamePage @outID, 'Fortnite', 'no life kids', @gamePageID output
exec createGamePage @outID, 'Town of salem', 'Lie to everyone', @gamePageID output

select * from GamePage

delete  from Account where Account.IdAccount > 0