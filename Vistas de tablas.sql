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

select * from v_alumno