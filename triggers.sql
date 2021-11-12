create database et_26
use et_26

create table Persona(nombre varchar(50),apellido varchar(50),telefono varchar(10))

--se activa al insertar una persona en la tabla e imprime el msj--

create trigger tr_persona_insert
on Persona for insert
as
	print 'hubo un cambio en la tabla'
go
insert into Persona values('robert','house','1103041475')

create table Producto(
id_cod int,
cod_prod varchar(4),
nombre varchar(50),
stock int,
constraint PK_Producto PRIMARY KEY (id_cod))
create table Ventas (cod_prod varchar(4),precio money,cantidad int)
create table Historial1(fecha date,descripcion varchar(50)) 

--este trigger obtiene la fecha y hora y lo almacena dentro de la tabla historial1 junto con un msj--
--Se activa cuando se inserta algo en la tabla productos--

create trigger tr_producto_insertado
on Producto for insert
as
	insert into Historial1 values (GETDATE(),'se inserto')
go
insert into Producto values(0002,'4123','Auris de Virgo Momo',34)
select* from Historial1

--Primero agregamos 2 columnas a la tabla historial11--
--Este trigger inserta el nombre del producto insertado

alter table Historial1 add producto varchar (50) 

alter trigger tr_producto_insertado2
on Producto for insert
as
	insert into Historial1 (fecha,descripcion,producto)
	select GETDATE(),'se inserto',nombre from inserted
go
select* from Historial1

alter table Historial1 ADD cod_prod varchar(4) --añado columna cod_prod
alter table Historial1 drop column producto --borro columna producto

alter trigger tr_producto_insertado3
on Producto for insert
as
	declare @cod_prod varchar (4) --Declaro para poder usarla más adelante
	select @cod_prod = cod_prod from inserted
	insert into Historial1 values (GETDATE(),'Registro insertado',@cod_prod)
go