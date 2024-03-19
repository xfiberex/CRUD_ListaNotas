/* Creación de BD para un sistema que guarda notas y las clasifica como Pendiente o Completada */

--create database DBTASKLIST
--go
--use DBTASKLIST

create table Tareas(
idTarea int primary key identity(1,1),
nombre varchar(50),
descripcion varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)

select * from Tareas

insert into Tareas (nombre, descripcion, esActivo) values ('Sistema de ventas', 'Utilizando ASP.NET Blazor con HTML, JS Y CSS', 1)