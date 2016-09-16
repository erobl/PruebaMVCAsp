CREATE TABLE Cliente  (
	Cedula Varchar(15) PRIMARY KEY,
	Nombre Varchar(64),
	Apellido1 Varchar(64),
	Apellido2 Varchar(64),
	Correo Varchar(64),
	Direccion Varchar(256),
)

CREATE TABLE Telefono (
	Numero Varchar(20),
	Cedula Varchar(15)

	FOREIGN KEY (Cedula) REFERENCES Cliente(Cedula),
	PRIMARY KEY(Cedula, Numero),
)

CREATE TABLE Cuenta (
	Tipo Varchar(20),
	Numero Varchar(20),
	Cedula Varchar(15),
	FOREIGN KEY (Cedula) REFERENCES Cliente(Cedula),
	PRIMARY KEY(Cedula, Numero)
)

DROP TABLE Cliente, Cuenta, Telefono