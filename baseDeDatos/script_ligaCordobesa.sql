--Creamos la base de datos
create database ligaCordobesa

--Definimos la BD a utilizar
use ligaCordobesa

--Creamos las tablas
create table Equipo(
	id_equipo int identity(1,1),
	nombre_equipo varchar(150),
	director_tecnico varchar(100)
	constraint pk_id_equipo primary key (id_equipo)
)

create table Posicion(
	id_posicion int identity(1,1) not null,
	nom_posicion varchar(100) not null
	constraint pk_id_posicion primary key (id_posicion)
)

create table Persona(
	dni_persona int not null,
	nombre_completo varchar(150) not null,
	fecha_nacimiento datetime not null,
	constraint pk_dni_persona primary key (dni_persona)
)

create table Jugador(
	id_jugador int identity(1,1),
	dni_persona int not null,
	num_camiseta int not null,
	id_posicion int not null,
	id_equipo int not null
	constraint pk_id_jugador primary key (id_jugador),
	constraint fk_dni_persona foreign key (dni_persona)
		references Persona (dni_persona),
	constraint fk_id_posicion foreign key (id_posicion)
		references Posicion (id_posicion),
	constraint fk_id_equipo foreign key (id_equipo)
		references Equipo (id_equipo)
)

--Insertamos datos a la tabla Equipo
insert into Equipo(nombre_equipo,director_tecnico) VALUES ('Club Atletico Carlos Paz','Juan Perez')
insert into Equipo(nombre_equipo,director_tecnico) VALUES ('Club Atletico Talleres','Javier Gandolfi') 
insert into Equipo(nombre_equipo,director_tecnico) VALUES ('Club Atletico Belgrano','Guillermo Farré')
insert into Equipo(nombre_equipo,director_tecnico) VALUES ('Club Atletico Las Palmas','Juan Carlos Olave') 

--Insertamos datos a la tabla Posicion
insert into Posicion(nom_posicion) VALUES ('P')
insert into Posicion(nom_posicion) VALUES ('DF I')
insert into Posicion(nom_posicion) VALUES ('DF D')
insert into Posicion(nom_posicion) VALUES ('DF C')
insert into Posicion(nom_posicion) VALUES ('DM I')
insert into Posicion(nom_posicion) VALUES ('DM D')
insert into Posicion(nom_posicion) VALUES ('DM C')
insert into Posicion(nom_posicion) VALUES ('M I')
insert into Posicion(nom_posicion) VALUES ('M D')
insert into Posicion(nom_posicion) VALUES ('M C')
insert into Posicion(nom_posicion) VALUES ('MP I')
insert into Posicion(nom_posicion) VALUES ('MP D')
insert into Posicion(nom_posicion) VALUES ('MP C')
insert into Posicion(nom_posicion) VALUES ('D I')
insert into Posicion(nom_posicion) VALUES ('D D')
insert into Posicion(nom_posicion) VALUES ('D C')

--Insertamos datos a la tabla Persona
insert into Persona(dni_persona,nombre_completo,fecha_nacimiento) VALUES (40358741,'Guido Herrera','1992/02/29')
insert into Persona(dni_persona,nombre_completo,fecha_nacimiento) VALUES (35148832,'Nahuel Losada','1993/04/17')
insert into Persona(dni_persona,nombre_completo,fecha_nacimiento) VALUES (38187354,'Damián Emiliano Martínez','1992/09/02')
insert into Persona(dni_persona,nombre_completo,fecha_nacimiento) VALUES (32455987,'Augusto Batalla','1996/04/30')

--Insertamos datos a la tabla Jugador
insert into Jugador(dni_persona,num_camiseta,id_posicion,id_equipo) VALUES (40358741,22,1,2)
insert into Jugador(dni_persona,num_camiseta,id_posicion,id_equipo) VALUES (32455987,13,1,1)

--Creamos Procedimientos Almacenados
create procedure sp_consultar_jugador
as
begin
	select * from Jugador;
end

create procedure sp_consultar_equipo
as
begin
	select * from Equipo;
end

create procedure sp_consultar_persona
as
begin
	select * from Persona;
end

create procedure sp_consultar_posicion
as
begin
	select * from Posicion;
end

create procedure sp_proximo_id
@next int output
as
begin
	set @next = (SELECT MAX(id_equipo)+1  FROM Equipo);
end

create procedure sp_insertar_maestro
	@nombre_equipo varchar(150),
	@director_tecnico varchar(100)
as
begin
	insert into Equipo(nombre_equipo,director_tecnico)
	VALUES (@nombre_equipo,@director_tecnico)
end	

create procedure sp_insertar_detalle
	@dni_persona int,
	@num_camiseta int,
	@id_posicion int,
	@id_equipo int
as
begin
	insert into Jugador(
		dni_persona,
		num_camiseta,
		id_posicion,
		id_equipo
	)
	values(@dni_persona,@num_camiseta,@id_posicion,@id_equipo)
end

/*
Portero (P)
Defensor Izquierdo (DF I)
Defensor Derecho (DF D)
Defensa Central (DF C)
Mediocampista Defensivo Izquierdo (DM I)
Mediocampista Defensivo Diestro (DM D)
Mediocampista Defensivo Central (DM C)
Mediocampista Izquierdo (M I)
Mediocampista Derecho (M D)
Mediocampista Central (M C)
Mediocampista Ofensivo Izquierdo (MP I)
Mediocampista Ofensivo Derecho (MP D)
Mediocampista Ofensivo Central (MP C)
Delantero Izquierdo (D I)
Delantero Derecho (D D)
Delantero Centro (D C)
*/
