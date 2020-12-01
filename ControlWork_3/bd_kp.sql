--create database Test
--go
--use Test
--go

--create table TestTable
--(
--	id int primary key identity not null,
--	name nvarchar(100) not null,
--	number int not null
--);
--go

--create table Archive
--(
--	id int not null,
--	remove_date date not null
--);
--go

--insert into TestTable(name, number)
--values
--('Test1', 1),
--('Test2', 2),
--('Test3', 3),
--('Test4', 4),
--('Test5', 5),
--('Test6', 6),
--('Test7', 7),
--('Test8', 8),
--('Test9', 9),
--('Test10', 10),
--('Test11', 11),
--('Test12', 12),
--('Test13', 13),
--('Test14', 14),
--('Test15', 15),
--('Test16', 16),
--('Test17', 17),
--('Test18', 18),
--('Test19', 19),
--('Test20', 20),
--('Test21', 21),
--('Test22', 22),
--('Test23', 23),
--('Test24', 24),
--('Test25', 25),
--('Test26', 26),
--('Test27', 27),
--('Test28', 28),
--('Test29', 29),
--('Test30', 30),
--('Test31', 31),
--('Test32', 32),
--('Test33', 33),
--('Test34', 34),
--('Test35', 35),
--('Test36', 36),
--('Test37', 37),
--('Test38', 38),
--('Test39', 39),
--('Test40', 40),
--('Test41', 41),
--('Test42', 42),
--('Test43', 43),
--('Test44', 44),
--('Test45', 45),
--('Test46', 46),
--('Test47', 47),
--('Test48', 48),
--('Test49', 49),
--('Test50', 50),
--('Test51', 51),
--('Test52', 52),
--('Test53', 53),
--('Test54', 54),
--('Test55', 55);
--go

--create table Products
--(
--	id int primary key identity not null,
--	name nvarchar(100) not null,
--	amount int not null
--)
--go

--insert into Products(name, amount)
--values
--('Product1', 1),
--('Product2', 2),
--('Product3', 3),
--('Product4', 4),
--('Product5', 5),
--('Product6', 6),
--('Product7', 7),
--('Product8', 8),
--('Product9', 9);
--go

--create table BILL
--(
--	id int not null,
--	delete_date date not null
--);
--go

--create trigger ProductAfterDelete
--on Products
--after delete
--as
--insert into BILL
--select id, GETDATE() from deleted

--select * from Products
--select * from BILL

--delete from Products where id = 3

--select * from Products
--select * from BILL


create unique index BTree
on Products(amount)



select name from Products order by amount desc

select amount from Products order by amount

select * from Products
