insert into AccountLevel values ('test')
declare @id int
select @id = a.IDAccountLevel from AccountLevel as a where a.Name like 'test' 


exec createAccount @id,'test1@mail.com','test','pass','te','st'

exec createAccount @id,'test2@mail.com','test2','pass','te','st'

select * from Account