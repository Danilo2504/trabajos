use et_26

create table alumno (
matricula int primary key,
dni varchar(10),
nombre varchar(25),
apellido varchar(50),
edad smallint,
sexo char,
domicilio varchar (25)
)
insert into alumno values(0001,40100000, 'Marselo', 'Nahuel Buergo Coria', 18, 'M', 'Pompeya')
insert into alumno values(0002,40110000, 'Zebastian', 'Gashi Lucas Moscardi', 10, 'M', 'Balvanera')
insert into alumno values(0003,40111100, 'Pancho', 'Facundo BermudaZ', 35, 'M', 'Quilmes')
insert into alumno values(0005,40111111, 'Libreto', 'Fernando', 18, 'M', 'Ezeiza')

go
create view v_alumno
as
select* from alumno
go

alter view v_alumno
as select matricula, nombre, apellido, edad, sexo from alumno
go

update v_alumno set nombre = 'El pepe' where edad < 19
update v_alumno set nombre = 'Potaxio' where edad > 19

select * from v_alumno

create table cliente (
matricula int primary key,
dni varchar(10),
nombre varchar(25),
apellido varchar(50),
edad smallint,
sexo char,
domicilio varchar (25),
usuario varchar(50),
contrasena varchar (25)
)

insert into cliente values(0001,40100000, 'Marselo', 'Nahuel Buergo Coria', 18, 'M', 'Pompeya', 'momazos_buergo', '123')
insert into cliente values(0002,40110000, 'Zebastian', 'Gashi Lucas Moscardi', 18, 'M', 'Balvanera', 'sugus_de_uva', '234')
insert into cliente values(0003,40111100, 'Pancho', 'Facundo BermudaZ', 35, 'M', 'Quilmes', 'panchitos', '345')
insert into cliente values(0005,40111111, 'Libreto', 'Fernando', 18, 'M', 'Ezeiza', 'Fin del juego Liberato Fernandez', '007')

go
create view v_cliente
with encryption
as
select* from cliente
go

alter view v_cliente
as select matricula, nombre, apellido, edad, sexo from cliente
go

alter view v_cliente
as select nombre, apellido from cliente
go

select * from v_cliente
