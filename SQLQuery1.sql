create database DB_Creditos_
use DB_Creditos_

CREATE TABLe Carrera(
Id_Carrera int identity primary key not null,
Nombre nvarchar(50) not null
)

create table Año_Academico(
Id_Año int identity primary key not null,
Año int unique not null
)

create table Periodo(
Id_Periodo int identity primary key not null,
Peirodo nvarchar(50) not null,
)

Create table Campus(
Id_Campus int identity primary key not null,
Campus nvarchar(20) unique not null
)

create table Alumno(
Id_Alumno int identity primary key not null,
Carnet nvarchar(20) unique not null,
Nombre nvarchar(250) unique not null,
Id_Carrera int not null,
foreign key (Id_Carrera) references Carrera(Id_Carrera)
)

create table Actividad(
Id_Actividad int identity primary key not null,
Fecha_Inscripcion date not null,
Fecha_Finalizacion date not null,
Lugar nvarchar(250) not null,
Nombre_Actividad nvarchar(250) not null,
Tipo nvarchar(300) not null,
)

create table Detalle_Actividad(
Id_DetalleA int identity primary key not null,
Id_Actividad int not null,
Id_Alumno int not null,
Carnet numeric not null,
Nombre nvarchar(250),
Horas int not null,
Id_Campus int not null,
Id_Periodo int not null,
Id_Año int not null,
foreign key (Id_Actividad) references Actividad(Id_Actividad),
foreign key (Id_Alumno) references Alumno(Id_Alumno),
foreign key (Id_Campus) references Campus(Id_Campus),
foreign key (Id_Periodo) references Periodo(Id_Periodo),
foreign key (Id_Año) references Año_Academico(Id_Año)
)