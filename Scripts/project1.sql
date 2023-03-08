Create Database Specialticket;
USE Specialticket;
drop DATABASE  Specialticket;
IF OBJECT_ID('tipo_evento', 'U') IS NOT NULL  
   DROP TABLE tipo_evento;  
go
CREATE TABLE tipo_evento
(
	idTipo tinyint  NOT NULL primary key,
	descripcion varchar(100) NOT NULL,
	Created_At datetime NOT NULL,
	Created_by tinyint NOT NULL,
	Update_At datetime NOT NULL,
	Update_By tinyint NOT NULL,
	Active tinyint NOT NULL
);
IF OBJECT_ID('escenario', 'U') IS NOT NULL  
   DROP TABLE escenario;  
go
CREATE TABLE escenario 
(
	idEscenario int  NOT NULL primary key,
	nombre varchar(100) NOT NULL,
	localizacion varchar(100) NOT NULL,
	Created_At datetime NOT NULL,
	Created_by tinyint NOT NULL,
	Update_At datetime NOT NULL,
	Update_By tinyint NOT NULL,
	Active tinyint NOT NULL,
	idTipoEscenario tinyint NOT NULL
);
IF OBJECT_ID('tipo_escenario', 'U') IS NOT NULL  
   DROP TABLE tipo_escenario;  
go
CREATE TABLE tipo_escenario
(
	idTipoEscenario tinyint NOT NULL primary key,
	descripcion varchar(100) NOT NULL,
	Created_At datetime NOT NULL,
	Created_by tinyint NOT NULL,
	Update_At datetime NOT NULL,
	Update_By tinyint NOT NULL,
	Active tinyint NOT NULL,
);

IF OBJECT_ID('asiento', 'U') IS NOT NULL  
   DROP TABLE asiento;  
go
CREATE TABLE asiento
(
	idAsiento int NOT NULL primary key,
	descripcion varchar(100) NOT NULL,
	cantidad int NOT NULL,
	Created_At datetime NOT NULL,
	Created_by tinyint NOT NULL,
	Update_At datetime NOT NULL,
	Update_By tinyint NOT NULL,
	Active tinyint NOT NULL,
	id_escenario int NOT NULL
);
IF OBJECT_ID('evento', 'U') IS NOT NULL  
   DROP TABLE evento;  
go
 CREATE TABLE evento
 (
	idEvento int NOT NULL Primary Key,
 	descripcion varchar(100) NOT NULL,
	fecha datetime NOT NULL,
	Created_At datetime NOT NULL,
	Created_by tinyint NOT NULL,
	Update_At datetime NOT NULL,
	Update_By tinyint NOT NULL,
	Active tinyint NOT NULL,
	idTipoEvento tinyint NOT NULL,
	id_escenario int NOT NULL
 );
IF OBJECT_ID('usuarios', 'U') IS NOT NULL  
   DROP TABLE usuarios;  
go
 CREATE TABLE usuarios(
	 idUsuario int NOT NULL primary key,
	 nombre varchar(100) NOT NULL,
	 correo varchar(100) NOT NULL,
	 telefono int NOT NULL,
	 rol int NOT NULL,
 	Created_At datetime NOT NULL,
	Created_by tinyint NOT NULL,
	Update_At datetime NOT NULL,
	Update_By tinyint NOT NULL,
	Active tinyint NOT NULL
 );
IF OBJECT_ID('entradas', 'U') IS NOT NULL  
   DROP TABLE entradas;  
go
 CREATE TABLE entradas
 (	
	 idEntrada int NOT NULL primary key,
	 tipo_asiento varchar(100) NOT NULL,
	 precio decimal(10,0) NOT NULL,
	 Created_At datetime NOT NULL,
	Created_by tinyint NOT NULL,
	Update_At datetime NOT NULL,
	Update_By tinyint NOT NULL,
	Active tinyint NOT NULL,
	id_evento int NOT NULL,
	id_compra int NOT NULL default 0
 );

IF OBJECT_ID('compra', 'U') IS NOT NULL  
   DROP TABLE compra;  
go
CREATE TABLE compra 
(	
	idCompra int NOT NULL primary key CHECK(idCompra <> 0),
	cantidad int NOT NULL,
	fecha_reserva datetime NOT NULL,
	fecha_pago datetime NOT NULL,
	Created_At datetime NOT NULL,
	Created_by tinyint NOT NULL,
	Update_At datetime NOT NULL,
	Update_By tinyint NOT NULL,
	Active tinyint NOT NULL,
	id_cliente int NOT NULL
);
ALTER TABLE escenario ADD FOREIGN KEY(idTipoEscenario) REFERENCES tipo_escenario(idTipoEscenario) ON DELETE CASCADE; --relación entre tipo_escenario y escenario
ALTER TABLE asiento ADD FOREIGN KEY(id_escenario) REFERENCES escenario(idEscenario) ON DELETE CASCADE;--llave foranea entre asiento y escenario
ALTER TABLE evento ADD FOREIGN KEY(idTipoEvento) REFERENCES tipo_evento(idTipo) ON DELETE CASCADE;--llave foranea entre evento y tipo de evento 
ALTER TABLE evento ADD FOREIGN KEY(id_escenario) REFERENCES escenario(idEscenario) ON DELETE CASCADE;--llave foranea entre evento y escenario 
ALTER TABLE entradas ADD FOREIGN KEY(id_evento) REFERENCES evento(idEvento) ON DELETE CASCADE;--llave foranea entre entradas y evento 
ALTER TABLE entradas ADD FOREIGN KEY(id_compra) REFERENCES compra(idCompra) ON DELETE CASCADE;--llave foranea entre entradas y compra
ALTER TABLE compra ADD FOREIGN KEY(id_cliente) REFERENCES usuarios(idUsuario) ON DELETE CASCADE;---llave foranea entre compra y usuario(cliente)