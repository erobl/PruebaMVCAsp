CREATE TABLE Cliente  (
	Cedula Varchar(15) PRIMARY KEY,
	Nombre Varchar(64),
	Apellido1 Varchar(64),
	Apellido2 Varchar(64),
	Correo Varchar(64),
	Direccion Varchar(256),
	Usuario nvarchar(128),
	FOREIGN KEY (Usuario) REFERENCES dbo.AspNetUsers(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)

CREATE TABLE Telefono (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Numero Varchar(20),
	Cedula Varchar(15)

	FOREIGN KEY (Cedula) REFERENCES Cliente(Cedula)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)

CREATE TABLE Cuenta (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Tipo Varchar(20),
	Numero Varchar(20),
	Cedula Varchar(15),
	FOREIGN KEY (Cedula) REFERENCES Cliente(Cedula)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)

CREATE TABLE Rol (
	Rol varchar(20) PRIMARY KEY
)

CREATE TABLE Rol_de_usuario (
	Id nvarchar(128),
	Rol varchar(20)

	FOREIGN KEY (Id) REFERENCES dbo.AspNetUsers(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE,

	FOREIGN KEY (Rol) REFERENCES Rol(Rol)
	ON UPDATE CASCADE
	ON DELETE CASCADE,

	PRIMARY KEY (Id, Rol)
)

Insert into dbo.AspNetRoles values(1, 'Administrador');
Insert into dbo.AspNetRoles values(2, 'Lider');
Insert into dbo.AspNetRoles values(3, 'Usuario');
