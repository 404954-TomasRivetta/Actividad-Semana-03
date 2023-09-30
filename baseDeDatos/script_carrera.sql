--Creamos la base de datos
create database carrera_planes_de_estudio

--Definimos la BD a utilizar
use carrera_planes_de_estudio

--Creamos las tablas
create table Carrera(
	id_carrera int identity(1,1),
	nombre_carrera varchar(150),
	titulo varchar(100)
	constraint pk_id_carrera primary key (id_carrera)
)

create table Asignatura(
	id_asignatura int identity(1,1),
	nombre_asignatura varchar(150)
	constraint pk_id_asignatura primary key (id_asignatura)
)

create table DetalleCarrera(
	id_detalle int,
	id_carrera int,
	anioCursado int,
	cuatrimestre int,
	id_asignatura int
	constraint pk_id_detalle primary key (id_detalle),
	constraint fk_id_carrera foreign key (id_carrera)
		references Carrera(id_carrera),
	constraint fk_id_asignatura foreign key (id_asignatura)
		references Asignatura(id_asignatura)
)

--Realizamos algunos insert
INSERT INTO Asignatura VALUES('AED')
INSERT INTO Asignatura VALUES('MAD')
INSERT INTO Asignatura VALUES('AM1')
INSERT INTO Asignatura VALUES('AGA1')
INSERT INTO Asignatura VALUES('INGLES 1')

--Creamos Procedimientos Almacenados
create procedure sp_consultar_asignaturas
as
begin
	select * from Asignatura;
end

create procedure sp_proximo_id
@next int output
as
begin
	set @next = (SELECT MAX(id_carrera)+1  FROM Carrera);
end

create procedure sp_insertar_maestro
	@nombre_carrera varchar(150),
	@titulo varchar(100)
as
begin
	insert into Carrera(nombre_carrera,titulo)
	VALUES (@nombre_carrera,@titulo)
end	

create procedure sp_insertar_detalle
	@id_carrera int,
	@id_detalle int,
	@anioCursado int,
	@cuatrimestre int,
	@id_asignatura int
as
begin
	insert into DetalleCarrera(
	id_detalle,
	id_carrera,
	anioCursado,
	cuatrimestre,
	id_asignatura
	)
	values(	@id_detalle,
	@id_carrera,
	@anioCursado,
	@cuatrimestre,
	@id_asignatura)
end

create procedure sp_carrera_filtro
	@nombre_carrera varchar(150),
	@titulo varchar(100)
as
begin
	select * from
end	


/*------------------------------*/
use carrera_planes_de_estudio

select * from Carrera
select * from DetalleCarrera