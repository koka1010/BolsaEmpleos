CREATE DATABASE db_Bolsa_empleos;
go
USE db_Bolsa_empleos;
go
-- Tabla de Empresas
CREATE TABLE [Empresas] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Cod_Empresa] INT NOT NULL,
    [Nom_Empresa] VARCHAR(50) NOT NULL,
    [Direc_Empresa] VARCHAR(250)
);

CREATE TABLE [Vacantes] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Empresa] INT NOT NULL,
    [Nombre_vacante] VARCHAR(100) NOT NULL,
    FOREIGN KEY (Empresa) REFERENCES Empresas(id)
);



-- Tabla de Personas
CREATE TABLE [Personas] 
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Cedula] NVARCHAR(20) NOT NULL,
    [Nombre_persona] NVARCHAR(255) NOT NULL,
    [Direccion] NVARCHAR(255) NOT NULL,
    [Cargos] NVARCHAR(255) NOT NULL,
    [Estado] NVARCHAR(20) NOT NULL
);

-- Tabla de Estudios
CREATE TABLE [Estudios] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Cod_estudio] NVARCHAR(50) NOT NULL,
    [Persona] INT NOT NULL,
    [Nombre_estudio] NVARCHAR(255) NOT NULL,
    FOREIGN KEY (Persona) REFERENCES Personas(id)
);

-- Tabla de Postulaciones
CREATE TABLE [Postulaciones] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Vacante] INT NOT NULL,
    [Especificaciones] NVARCHAR(200) NOT NULL,
    [Salario] int,
    FOREIGN KEY (Vacante) REFERENCES Vacantes(id)
);


-- Tabla de Detalles
CREATE TABLE [Detalles] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Postulacion] INT NOT NULL,
    [Persona] INT NOT NULL,
    FOREIGN KEY (Postulacion) REFERENCES Postulaciones(id),
    FOREIGN KEY (Persona) REFERENCES Personas(id)
);
CREATE TABLE [Auditoria] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Tabla] NVARCHAR(50),
    [Referencia] INT,
    [Accion]  NVARCHAR(50),
);
CREATE TABLE [Login] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(50),
    [Contraseña]  NVARCHAR(50),
	[Rol] NVARCHAR(50)
);


--INSERT PARA HACER LAS PRUEBAS UNITARIAS
INSERT INTO [Empresas] ( cod_Empresa, nom_Empresa, direc_Empresa) VALUES
( 294, 'TecnolID', 'cll 24 #12');

INSERT INTO [Vacantes] ( empresa, Nombre_vacante) VALUES
( 1, 'Desarrollar backend');

INSERT INTO [Personas] ( cedula, nombre_persona, direccion, cargos, estado) VALUES
( '124151', 'Juan', 'cll 24 #21', 'Diseñador web', 'inactivo');

INSERT INTO [Postulaciones] ( vacante, Especificaciones, salario) VALUES
( 1, 'SQL', 1400);


select * from Empresas

select * from Vacantes

select * from Personas

select * from Estudios

select * from Detalles

select * from Postulaciones