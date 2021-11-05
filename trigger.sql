use et_26

create table persona (nombre varchar(50), apellido varchar(50), telefono varchar(10))

insert into persona values('Javier','Milei','111-000')
insert into persona values('Alberto', 'Fernandez', '123-456')
insert into persona values('Charly', 'Garcia', '987-123')
insert into persona values('Sebastian', 'Lucas Moscardi Galli', '1099832')

create trigger tr_persona_insert
on persona for insert
as
print 'hubo un cambio en la tabla'
go

create table historial (nombre varchar(50), fecha date, descripcion varchar(50))

insert into persona values('pepe', 'alvarez', '7890')


create trigger tr_persona_insertar
on persona for insert
as
	begin
		set nocount on
		insert into historial (nombre, fecha, descripcion)
		select nombre, getdate(), 'se inserto correctamente' from inserted
	end
go

create trigger tr_persona_eliminar
on persona for delete
as
	begin
	set nocount on
		insert into historial (nombre, fecha, descripcion)
		select nombre, getdate(), 'se inserto correctamente' from deleted
	end
go
delete from persona where nombre='Alberto'

create table productos (id_cod int primary key, cod_prod varchar(4), nombre varchar(50), stock int)
create table ventas (cod_prod varchar(4), precio money, cantidad int)
create table historial_1 (fecha date, descripcion varchar(50))

create trigger tr_producto_insertedo
on productos for insert
as
	insert into historial_1 values (getdate(), 'se inserta')
go
insert into productos values (1, '2339', 'bautista', 45)

create trigger tr_producto_insertado2
on productos for insert
as
	declare @cod_prod varchar(4)
	select @cod_prod = cod_prod from inserted
	insert into historial_1
	values (getdate(), @cod_prod, 'registro insertado')
go

create trigger tr_producto_eliminado
on producto for delete
as
	