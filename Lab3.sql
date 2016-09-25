CREATE TABLE Cliente  (
	Cedula Varchar(15) PRIMARY KEY,
	Nombre Varchar(64),
	Apellido1 Varchar(64),
	Apellido2 Varchar(64),
	Correo Varchar(64),
	Direccion Varchar(256),
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

CREATE TABLE Rol

DROP TABLE Cliente, Cuenta, Telefono