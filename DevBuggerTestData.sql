insert into AccountLevel values ('test')
declare @id int
select @id = a.IDAccountLevel from AccountLevel as a where a.Name like 'test' 

exec createAccount 2,'deleteted-account@mail.com','Deleted','go342mjkojsdpkijgmkiWEENMGKwnghare','Deleted','Account'

exec createAccount 2,'test1@mail.com','test','pass','te','st'

exec createAccount 2,'test2@mail.com','test2','pass','te','st'

select * from Account

delete  from Account where Account.IdAccount > 0