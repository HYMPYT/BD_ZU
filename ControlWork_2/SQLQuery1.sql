--create database TicketService
--go
--use TicketService
--go

--create table Films(
--	id int primary key identity(1, 1) not null,
--	film_name nvarchar(100) not null,
--	genre nvarchar(50) not null
--);
--go

--create table Shows(
--	id int primary key identity(1, 1) not null,
--	count_of_sell_tickets int not null,
--	count_of_sits int not null,
--	film_id int not null foreign key references Films(id)
--);
--go

--create table Rooms(
--	id int primary key identity(1, 1) not null,
--	number int not null,
--	show_id int not null foreign key references Shows(id)
--);


--insert into Films(film_name, genre)
--values
--('film1', 'detective'),
--('film2', 'fantasy'),
--('film3', 'drama');
--go

--insert into Shows(count_of_sell_tickets, count_of_sits, film_id)
--values
--(40, 50, 2),
--(60, 60, 1),
--(20, 50, 3),
--(40, 40, 2);
--go

--insert into Rooms(number, show_id)
--values
--(200, 1),
--(300, 2),
--(100, 3),
--(400, 4);
--go


select *
from Films

select *
from Shows

select *
from Rooms


--1
select Rooms.number
from Rooms join Shows on Rooms.show_id = Shows.id join Films on Shows.film_id = Films.id
where Films.genre like 'detective'

--3
select Films.film_name
from Shows join Films on Shows.film_id = Films.id
where Shows.count_of_sits = Shows.count_of_sell_tickets

--4
select count_of_sits, min(count_of_sits - count_of_sell_tickets) as FreeSits
from Shows 
group by count_of_sits
having min(count_of_sits - count_of_sell_tickets) > 0