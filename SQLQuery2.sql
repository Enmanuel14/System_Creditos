create proc mostrar_alumno
as
SELECT        dbo.Alumno.Id_Alumno, dbo.Alumno.Carnet, dbo.Alumno.Nombre, dbo.Alumno.Id_Carrera, dbo.Carrera.Nombre AS Carrera
FROM            dbo.Alumno INNER JOIN
                         dbo.Carrera ON dbo.Alumno.Id_Carrera = dbo.Carrera.Id_Carrera

exec mostrar_alumno

create proc mostrar_carrera
as
select *from Carrera order by Id_Carrera

exec mostrar_carrera

create proc insertar_alumno
@id int output,
@carnet decimal,
@nombre nvarchar(250),
@carrera int
as
insert into Alumno(Carnet, Nombre, Id_Carrera)
values (@carnet, @nombre, @carrera)

create proc editar_alumno
@id int,
@carnet decimal,
@nombre nvarchar(250),
@carrera int
as
update Alumno set Carnet = @carnet, Nombre = @nombre, Id_Carrera = @carrera
where Id_Alumno = @id

create proc buscar_alumno
@nombre nvarchar(250)
as
select *from Alumno
where Nombre like @nombre + '%'

create proc mostrar_actividad
as
select *from Actividad

create proc insertar_actividad
@id int output,
@fechai date,
@fechaf date,
@lugar nvarchar(250),
@nombre nvarchar(250),
@tipo int
as
insert into Actividad(Fecha_Inscripcion, Fecha_Finalizacion, Lugar, Nombre_Actividad, Tipo)
values (@fechai, @fechaf, @lugar, @nombre,@tipo)


create proc mostrar_actividad
as
SELECT        Id_Actividad, Fecha_Inscripcion, Fecha_Finalizacion, Lugar, Nombre_Actividad, Tipo
FROM            dbo.Actividad


create proc editar_actividad
@id int,
@fechai date,
@fechaf date,
@lugar nvarchar(250),
@nombre nvarchar(250),
@tipo nvarchar(300)
as
update Actividad set Fecha_Inscripcion = @fechai, Fecha_Finalizacion = @fechaf, Lugar = @lugar, Nombre_Actividad = @nombre, Tipo = @tipo
where Id_Actividad = @id


create proc buscar_actividad
@nombre nvarchar(250)
as
select *from Actividad
where Nombre_Actividad like @nombre + '%'

create proc mostrar_año
as
select *from Año_Academico order by Id_Año desc

exec mostrar_año

create proc mostrar_periodo
as
select *from Periodo order by Id_Periodo


create proc mostrar_campus
as
select *from Campus order by Id_Campus

create proc MOSTRAR_DETALLE
AS

SELECT        dbo.Detalle_Actividad.Id_DetalleA, dbo.Detalle_Actividad.Id_Actividad, dbo.Actividad.Fecha_Inscripcion, dbo.Actividad.Fecha_Finalizacion, dbo.Actividad.Lugar, dbo.Actividad.Nombre_Actividad, dbo.Actividad.Tipo, dbo.Detalle_Actividad.Id_Alumno,
                          dbo.Detalle_Actividad.Carnet, dbo.Detalle_Actividad.Nombre, dbo.Alumno.Id_Carrera, dbo.Carrera.Nombre AS Carrera, dbo.Detalle_Actividad.Horas, dbo.Detalle_Actividad.Id_Campus, dbo.Campus.Campus, 
                         dbo.Detalle_Actividad.Id_Periodo, dbo.Periodo.Peirodo, dbo.Detalle_Actividad.Id_Año, dbo.Año_Academico.Año
FROM            dbo.Detalle_Actividad INNER JOIN
                         dbo.Actividad ON dbo.Detalle_Actividad.Id_Actividad = dbo.Actividad.Id_Actividad INNER JOIN
                         dbo.Alumno ON dbo.Detalle_Actividad.Id_Alumno = dbo.Alumno.Id_Alumno INNER JOIN
                         dbo.Año_Academico ON dbo.Detalle_Actividad.Id_Año = dbo.Año_Academico.Id_Año INNER JOIN
                         dbo.Campus ON dbo.Detalle_Actividad.Id_Campus = dbo.Campus.Id_Campus INNER JOIN
                         dbo.Carrera ON dbo.Alumno.Id_Carrera = dbo.Carrera.Id_Carrera INNER JOIN
                         dbo.Periodo ON dbo.Detalle_Actividad.Id_Periodo = dbo.Periodo.Id_Periodo


create proc insertar_detalle
@id_detalle int output,
@id_actividad int,
@id_alumno int, 
@carnet decimal,
@nombre nvarchar(250),
@horas int,
@id_campus int,
@id_periodo int,
@id_año int
as
insert into Detalle_Actividad(Id_Actividad, Id_Alumno, Carnet, Nombre, Horas, Id_Campus, Id_Periodo, Id_Año)
values(@id_actividad, @id_alumno, @carnet, @nombre, @horas, @id_campus, @id_periodo, @id_año)

create proc editar_detalle
@id_detalle int,
@id_actividad int,
@id_alumno int, 
@carnet decimal,
@nombre nvarchar(250),
@horas int,
@id_campus int,
@id_periodo int,
@id_año int
as
update Detalle_Actividad set Id_Actividad = @id_actividad, Id_Alumno = @id_alumno, Carnet = @carnet, Nombre = @nombre , Horas = @horas, Id_Campus = @id_campus, Id_Periodo = @id_periodo, Id_Año = @id_año
where Id_DetalleA = @id_detalle

create proc eliminar_detalle
@id_detalle int
as
delete Detalle_Actividad
where Id_DetalleA = @id_detalle

create proc buscar_detalle
@nombre nvarchar(250)
as
select Detalle_Actividad.Carnet, Detalle_Actividad.Nombre, Detalle_Actividad.Id_Campus, Campus.Campus, sum(Detalle_Actividad.Horas) Horas, sum(Horas)/48 as Total_Creditos
From Detalle_Actividad inner join Campus on Detalle_Actividad.Id_Campus = Campus.Id_Campus 
where Nombre = @nombre group by Detalle_Actividad.Carnet, Detalle_Actividad.Nombre, Detalle_Actividad.Id_Campus, Campus.Campus

create proc buscar_detalle_
@carnet decimal
as
select Detalle_Actividad.Carnet, Detalle_Actividad.Nombre, Detalle_Actividad.Id_Campus, Campus.Campus, sum(Detalle_Actividad.Horas) Horas, sum(Horas)/48 as Total_Creditos
From Detalle_Actividad inner join Campus on Detalle_Actividad.Id_Campus = Campus.Id_Campus 
where Carnet = @carnet group by Detalle_Actividad.Carnet, Detalle_Actividad.Nombre, Detalle_Actividad.Id_Campus, Campus.Campus


CREATE TABLE Usuario(
	Id_Usuario int IDENTITY(1,1) NOT NULL,
	nombre varchar(20) NOT NULL,
	apellidos varchar(40) NOT NULL,
	direccion varchar(100) NULL,
	telefono [varchar](10) NULL,
	email varchar(50) NULL,
	acceso varchar(20) NOT NULL,
	usuario varchar(20) NOT NULL,
	password varchar(20) NOT NULL
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED)


create proc splogin
@usuario varchar(20),
@password varchar(20)
as
select Id_Usuario,apellidos,nombre,acceso
from Usuario
where usuario=@usuario and password=@password