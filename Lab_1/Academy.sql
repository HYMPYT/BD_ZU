CREATE DATABASE Academy
GO
USE Academy
Go

CREATE TABLE Faculties (
	Id int identity(1, 1) primary key NOT NULL,
	Name nvarchar(100) NOT NULL UNIQUE CHECK (Name <> N'')
)
GO

CREATE TABLE Departments (
	Id int identity(1, 1) primary key NOT NULL,
	Name nvarchar(100) UNIQUE NOT NULL CHECK (Name <> N''),
	Financing money NOT NULL CHECK (Financing >= 0.0) DEFAULT '0.0',
	FacultyId int NOT NULL FOREIGN KEY REFERENCES Faculties(Id) ON DELETE CASCADE
)
GO

CREATE TABLE Groups (
	Id int identity(1, 1) primary key NOT NULL,
	Name nvarchar(100) NOT NULL UNIQUE CHECK (Name <> N''),
	Year int NOT NULL CHECK (Year between 1 and 5),
	AmountOfStudents int NOT NULL CHECK(AmountOfStudents > -1),
	DepartmentId int NOT NULL FOREIGN KEY REFERENCES Departments(Id) ON DELETE CASCADE
)
GO

CREATE TABLE Subjects (
	Id int identity(1, 1) primary key NOT NULL,
	Name nvarchar(100) NOT NULL UNIQUE CHECK (Name <> N'')
)
GO

CREATE TABLE Teachers (
	Id int identity(1, 1) primary key NOT NULL,
	Name nvarchar(100) NOT NULL CHECK (Name <> N''),
	Surname nvarchar(100) NOT NULL CHECK (Surname <> N''),
	Salary money NOT NULL CHECK (Salary > 0.0)
)
GO

CREATE TABLE LecturesPlan (
	Id int identity(1, 1) primary key NOT NULL,
	DayOfWeek int NOT NULL CHECK (DayOfWeek between 1 and 6),
	GroupId int NOT NULL FOREIGN KEY REFERENCES Groups(Id),
	SubjectId int NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
	TeacherId int NOT NULL FOREIGN KEY REFERENCES Teachers(Id)
)
GO

CREATE TABLE StudentTickets(
	Id int identity(1, 1) primary key NOT NULL,
	Info nvarchar(max) NOT NULL CHECK (Info <> N'')
)
GO

CREATE TABLE Students (
	Id int identity(1, 1) primary key NOT NULL,
	Name nvarchar(100) NOT NULL CHECK (Name <> N''),
	Surname nvarchar(100) NOT NULL CHECK (Surname <> N''),
	Age int NOT NULL CHECK(Age > 0),
	GroupId int NOT NULL FOREIGN KEY REFERENCES Groups(Id) ON DELETE CASCADE,
	StudentTicketId int NOT NULL FOREIGN KEY REFERENCES StudentTickets(Id) ON DELETE CASCADE
)
GO

--ALTER TABLE Departments ADD FOREIGN KEY (FacultyId) REFERENCES Faculties(Id)
--ON DELETE CASCADE
--GO


--ALTER TABLE Groups ADD FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
--ON DELETE CASCADE
--GO


--ALTER TABLE LecturesPlan ADD FOREIGN KEY (GroupId) REFERENCES Groups(Id)
--ON UPDATE CASCADE
--GO
--ALTER TABLE LecturesPlan ADD FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
--ON UPDATE CASCADE
--GO
--ALTER TABLE LecturesPlan ADD FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
--ON UPDATE CASCADE
--GO


--ALTER TABLE Students ADD FOREIGN KEY (GroupId) REFERENCES Groups(Id)
--ON DELETE CASCADE
--GO
--ALTER TABLE Students ADD FOREIGN KEY (StudentTicketId) REFERENCES StudentTickets(Id)
--ON DELETE CASCADE
--GO


insert into Faculties(Name)
values
('FAM'),
('FICT'),
('FEL');
go

insert into Departments(Name, Financing, FacultyId)
values
('SPSCS', 25000, 1),
('PZCS', 30000, 1),
('ITT', 28000, 2),
('POLI', 26000, 2),
('ELA', 25500, 3),
('TEC', 19000, 3);
go

insert into Groups(Name, Year, AmountOfStudents, DepartmentId)
values
('KV-83', 3, 3, 1),
('KV-74', 4, 3, 1),
('KP-91', 2, 3, 2),
('KP-72', 4, 3, 2),
('IO-92', 2, 3, 3),
('IO-93', 2, 3, 3),
('IF-72', 4, 3, 4),
('IF-82', 3, 3, 4),
('EA-91', 2, 3, 5),
('EA-93', 2, 3, 5),
('TC-82', 3, 3, 6);
go

insert into StudentTickets(Info)
values
('Some text 1'),
('Some text 2'),
('Some text 3'),
('Some text 4'),
('Some text 5'),
('Some text 6'),
('Some text 7'),
('Some text 8'),
('Some text 9'),
('Some text 10'),
('Some text 11'),
('Some text 12'),
('Some text 13'),
('Some text 14'),
('Some text 15'),
('Some text 16'),
('Some text 17'),
('Some text 18'),
('Some text 19'),
('Some text 20'),
('Some text 21'),
('Some text 22'),
('Some text 23'),
('Some text 24'),
('Some text 25'),
('Some text 26'),
('Some text 27'),
('Some text 28'),
('Some text 29'),
('Some text 30'),
('Some text 31'),
('Some text 32'),
('Some text 33');
go

insert into Students(Name, Surname, Age, GroupId, StudentTicketId)
values
('Yevhen', 'Levchuk', 19, 1, 1),
('Vlad', 'Hleb', 19, 1, 2),
('Vitaliy', 'Buslenko', 19, 1, 3),
('Oleksandr', 'Haustovuch', 20, 2, 4),
('Ivan', 'Kucher', 21, 2, 5),
('Nadia', 'Poluhovuch', 20, 2, 6),
('Max', 'Dembitsky', 18, 3, 7),
('Vasya', 'Pupkin', 17, 3, 8),
('Ivan', 'Groznuy', 18, 3, 9),
('Oleg', 'Lazutkin', 21, 4, 10),
('Oleg', 'Kubay', 20, 4, 11),
('Petya', 'Razenbaum', 20, 4, 12),
('Victor', 'Gnom', 18, 5, 13),
('Artem', 'Zasupko', 17, 5, 14),
('Dmitriy', 'Parfeniuk', 17, 5, 15),
('Victor', 'Blood', 18, 6, 16),
('Gogita', 'Tupuria', 19, 6, 17),
('Kiril', 'Saruchev', 18, 6, 18),
('Denis', 'Cuplinkov', 20, 7, 19),
('Michael', 'Kokliayev', 21, 7, 20),
('Oleg', 'Zhokh', 21, 7, 21),
('Dasha', 'Miagkova', 19, 8, 22),
('Dasha', 'Putishestvinica', 20, 8, 23),
('Rostislav', 'Kiselov', 18, 8, 24),
('Oleksandr', 'Pavluk', 19, 9, 25),
('Ivan', 'Duchka', 20, 9, 26),
('Vitaliy', 'Romankevich', 20, 9, 27),
('Karina', 'Lovinska', 17, 10, 28),
('Angelika', 'Tomashevska', 18, 10, 29),
('Max', 'Padun', 18, 10, 30),
('Alina', 'Zaharchuk', 19, 11, 31),
('Vitaliy', 'Trotskiy', 19, 11, 32),
('Victoria', 'Homenko', 18, 11, 33);
go

insert into Subjects(Name)
values
('Programming'),
('TEC'),
('Mathematical analysis'),
('Database management systems'),
('Physics');
go

insert into Teachers(Name, Surname, Salary)
values
('Dmitriy', 'Chumak', 30000),
('Vladimir', 'Popov', 27000),
('Olena', 'Homenko', 15000),
('Victor', 'Dovgal', 12000);
go

insert into LecturesPlan(DayOfWeek, GroupId, SubjectId, TeacherId)
values
( 3, 2, 1, 1),
( 2, 1, 3, 3),
( 1, 4, 4, 2),
( 4, 5, 5, 4),
( 5, 7, 2, 4);
go