create proc mostrar_alumno
as
SELECT        dbo.Alumno.Id_Alumno, dbo.Alumno.Carnet, dbo.Alumno.Nombre, dbo.Alumno.Id_Carrera, dbo.Carrera.Nombre AS Carrera
FROM            dbo.Alumno INNER JOIN
                         dbo.Carrera ON dbo.Alumno.Id_Carrera = dbo.Carrera.Id_Carrera

exec mostrar_alumno

create proc insertar_alumno
@id int output,
@carnet decimal,
@nombre nvarchar(250),
@carrera int
as
insert into Alumno(Carnet, Nombre, Id_Carrera)
values (@carnet, @nombre, @carrera)

create proc mostrar_carrera
as
select *from Carrera order by Id_Carrera

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
@nombre nvarchar(250)
as
insert into Actividad(Fecha_Inscripcion, Fecha_Finalizacion, Lugar, Nombre_Actividad)
values (@fechai, @fechaf, @lugar, @nombre)

create proc editar_actividad
@id int,
@fechai date,
@fechaf date,
@lugar nvarchar(250),
@nombre nvarchar(250)
as
update Actividad set Fecha_Inscripcion = @fechai, Fecha_Finalizacion = @fechaf, Lugar = @lugar, Nombre_Actividad = @nombre
where Id_Actividad = @id

create proc buscar_actividad
@nombre nvarchar(250)
as
select *from Actividad
where Nombre_Actividad like @nombre + '%'



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


create proc buscar_detalle
@nombre nvarchar(250)
as
select Detalle_Actividad.Id_Alumno, Detalle_Actividad.Carnet, Detalle_Actividad.Nombre, Detalle_Actividad.Id_Campus, Campus.Campus, sum(Detalle_Actividad.Horas) Horas, sum(Horas)/48 as Total_Creditos
From Detalle_Actividad inner join Campus on Detalle_Actividad.Id_Campus = Campus.Id_Campus 
where Nombre = @nombre group by Detalle_Actividad.Carnet, Detalle_Actividad.Nombre, Detalle_Actividad.Id_Campus, Campus.Campus