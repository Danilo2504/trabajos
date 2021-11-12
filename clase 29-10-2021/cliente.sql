create database et_26
use et_26

create table alumno(
matricula int,
dni varchar(50),
nombre varchar(50),
apellido varchar(50),
edad int,
sexo char,
domicilio varchar(50),
constraint pk_alumno primary key (matricula)
)

INSERT INTO alumno VALUES(0001,'12345','Juan','Perez',18,'M','Av. Jujuy 200'),
(0002,'67890','Ana','Lopez',18,'F','San Pedrito 500'),
(0003,'98765','Pedro','Perez',15,'M','Independencia 700'),
(0004,'54321','Vero','Martinez',19,'F','Rivadavia 1000')

/*
(0003,'98765','Gordo','Freeman',15,'M','No se'),
(0004,'54321','Roberto','House',19,'M','Lucky 38')

drop table alumno
*/
drop view v_alumno
create view v_alumno
as
select * from alumno
go
alter view v_alumno
as
select matricula,nombre,apellido,edad,sexo from alumno
go
update V_alumno
set nombre = 'Pepe' where nombre = 'Pedro'



delete  from alumno
drop table alumno



