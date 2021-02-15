CREATE DATABASE OOP11_2
go
USE OOP11_2
go
CREATE TABLE Scet
(
    Nomer int primary key,
	Tip_vklada nvarchar(50) ,
	Balans int, 
	Data_otryt date
)

CREATE TABLE InfoUser
(
    Nomer int foreign key references Scet(Nomer),
	Family_name nvarchar(50),
	Name_name nvarchar(50),
	Pasport_no nvarchar(50),
	Mesto_rojdeniya nvarchar(50),
	Data_rojd date,
	Picture varbinary(MAX)
)

DROP Table Scet
DROP Table InfoUser