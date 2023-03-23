CREATE DATABASE CONSULTORIOCLINICO
GO
USE CONSULTORIOCLINICO
GO

CREATE SCHEMA gral
GO
CREATE SCHEMA acce
GO
CREATE SCHEMA cons
GO

--************CREACION TABLA ROLES******************--
CREATE TABLE acce.tbRoles(
	role_Id					INT IDENTITY,
	role_Nombre				NVARCHAR(100) NOT NULL,
	role_UsuCreacion		INT NOT NULL,
	role_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_role_FechaCreacion DEFAULT(GETDATE()),
	role_UsuModificacion	INT,
	role_FechaModificacion	DATETIME,
	role_Estado				BIT NOT NULL CONSTRAINT DF_role_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbRoles_role_Id PRIMARY KEY(role_Id)
);
GO

--***********CREACION TABLA PANTALLAS*****************---
CREATE TABLE acce.tbPantallas(
	pant_Id					INT IDENTITY,
	pant_Nombre				NVARCHAR(100) NOT NULL,
	pant_UsuCreacion		INT NOT NULL,
	pant_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pant_FechaCreacion DEFAULT(GETDATE()),
	pant_UsuModificacion	INT,
	pant_FechaModificacion	DATETIME,
	pant_Estado				BIT NOT NULL CONSTRAINT DF_pant_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbPantallas_pant_Id PRIMARY KEY(pant_Id)
);
GO

INSERT INTO acce.tbPantallas(pant_Nombre, pant_UsuCreacion)
VALUES ('Usuarios', 1),
       ('Departamentos', 1),
	   ('Municipios', 1),
	   ('Categorías', 1),
	   ('Clientes', 1),
	   ('Empleados', 1),
	   ('Facturas', 1),
	   ('Facturas detalles', 1),
	   ('Métodos de pago', 1),
	   ('Productos', 1),
	   ('Proveedores', 1)


--***********CREACION TABLA ROLES/PANTALLA*****************---
CREATE TABLE acce.tbPantallasPorRoles(
	pantrole_Id					INT IDENTITY,
	pantrole_Identificador		NVARCHAR(100) NOT NULL,
	role_Id						INT NOT NULL,
	pant_Id						INT NOT NULL,
	pantrole_UsuCreacion		INT NOT NULL,
	pantrole_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pantrole_FechaCreacion DEFAULT(GETDATE()),
	pantrole_UsuModificacion	INT,
	pantrole_FechaModificacion	DATETIME,
	pantrole_Estado				BIT NOT NULL CONSTRAINT DF_pantrole_Estado DEFAULT(1)
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES acce.tbRoles(role_Id),
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbPantallas_pant_Id FOREIGN KEY(pant_Id) REFERENCES acce.tbPantallas(pant_Id),
	CONSTRAINT PK_acce_tbPantallasPorRoles_pantrole_Id PRIMARY KEY(pantrole_Id),
);
GO


--****************CREACION TABLA USUARIOS****************--
CREATE TABLE acce.tbUsuarios(
	user_Id 				INT IDENTITY(1,1),
	user_NombreUsuario		NVARCHAR(100) NOT NULL,
	user_Contrasena			NVARCHAR(MAX) NOT NULL,
	user_EsAdmin			BIT,
	role_Id					INT,
	empe_Id					INT,
	user_UsuCreacion		INT,
	user_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_user_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	user_FechaModificacion	DATETIME,
	user_Estado				BIT NOT NULL CONSTRAINT DF_user_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbUsuarios_user_Id  PRIMARY KEY(user_Id),
);

--********* PROCEDIMIENTO INSERTAR USUARIOS ADMIN**************--
GO
CREATE OR ALTER PROCEDURE acce.UDP_InsertUsuario
	@user_NombreUsuario NVARCHAR(100),	@user_Contrasena NVARCHAR(200),
	@user_EsAdmin BIT,					@role_Id INT, 
	@empe_Id INT										
AS
BEGIN
	DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));

	INSERT acce.tbUsuarios(user_NombreUsuario, user_Contrasena, user_EsAdmin, role_Id, empe_Id, user_UsuCreacion)
	VALUES(@user_NombreUsuario, @password, @user_EsAdmin, @role_Id, @empe_Id, 1);
END;


GO
EXEC acce.UDP_InsertUsuario 'admin', '123', 1, 1, 1;


--********* ALTERAR TABLA ROLES **************--
--********* AGREGAR CAMPOS AUDITORIA**************--
GO
ALTER TABLE acce.tbRoles
ADD CONSTRAINT FK_acce_tbRoles_acce_tbUsuarios_role_UsuCreacion_user_Id 		FOREIGN KEY(role_UsuCreacion) REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_acce_tbRoles_acce_tbUsuarios_role_UsuModificacion_user_Id 	FOREIGN KEY(role_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id);




GO
INSERT INTO acce.tbRoles(role_Nombre, role_UsuCreacion)
VALUES ('Admin', 1),
	   ('Recepcionista', 1)


--********* ALTERAR TABLA USUARIOS **************--
--********* AGREGAR CAMPO ROL, AUDITORIA**************--
GO
ALTER TABLE [acce].[tbUsuarios]
ADD CONSTRAINT FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuCreacion_user_Id  FOREIGN KEY(user_UsuCreacion) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuModificacion_user_Id  FOREIGN KEY(user_UsuModificacion) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbUsuarios_acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES acce.tbRoles(role_Id)

GO 
ALTER TABLE [acce].[tbPantallasPorRoles]
ADD CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuCreacion_user_Id FOREIGN KEY([pantrole_UsuCreacion]) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuModificacion_user_Id FOREIGN KEY([pantrole_UsuModificacion]) REFERENCES acce.tbUsuarios([user_Id])

--*******************************************--
--********TABLA DEPARTAMENTO****************---
GO
CREATE TABLE [gral].[tbDepartamentos](
	depa_Id  					CHAR(2) NOT NULL,
	depa_Nombre 				NVARCHAR(100) NOT NULL,
	depa_UsuCreacion			INT NOT NULL,
	depa_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_depa_FechaCreacion DEFAULT(GETDATE()),
	depa_UsuModificacion		INT,
	depa_FechaModificacion		DATETIME,
	depa_Estado					BIT NOT NULL CONSTRAINT DF_depa_Estado DEFAULT(1)
	CONSTRAINT PK_gral_tbDepartamentos_depa_Id 											PRIMARY KEY(depa_Id),
	CONSTRAINT FK_gral_tbDepartamentos_acce_tbUsuarios_depa_UsuCreacion_user_Id  		FOREIGN KEY(depa_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_gral_tbDepartamentos_acce_tbUsuarios_depa_UsuModificacion_user_Id  	FOREIGN KEY(depa_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);


--********TABLA MUNICIPIO****************---
GO
CREATE TABLE gral.tbMunicipios(
	muni_id					CHAR(4)	NOT NULL,
	muni_Nombre				NVARCHAR(80) NOT NULL,
	depa_Id					CHAR(2)	NOT NULL,
	muni_UsuCreacion		INT	NOT NULL,
	muni_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_muni_FechaCreacion DEFAULT(GETDATE()),
	muni_UsuModificacion	INT,
	muni_FechaModificacion	DATETIME,
	muni_Estado				BIT	NOT NULL CONSTRAINT DF_muni_Estado DEFAULT(1)
	CONSTRAINT PK_gral_tbMunicipios_muni_Id 										PRIMARY KEY(muni_Id),
	CONSTRAINT FK_gral_tbMunicipios_gral_tbDepartamentos_depa_Id 					FOREIGN KEY (depa_Id) 						REFERENCES gral.tbDepartamentos(depa_Id),
	CONSTRAINT FK_gral_tbMunicipios_acce_tbUsuarios_muni_UsuCreacion_user_Id  		FOREIGN KEY(muni_UsuCreacion) 				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_gral_tbMunicipios_acce_tbUsuarios_muni_UsuModificacion_user_Id  	FOREIGN KEY(muni_UsuModificacion) 			REFERENCES acce.tbUsuarios(user_Id)
);
 
 CREATE TABLE gral.tbEstadosCiviles
(
	estacivi_Id					INT IDENTITY,
	estacivi_Nombre				NVARCHAR(50),
	estacivi_UsuCreacion		INT NOT NULL,
	estacivi_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_estacivi_FechaCreacion DEFAULT(GETDATE()),
	estacivi_UsuModificacion	INT,
	estacivi_FechaModificacion	DATETIME,
	estacivi_Estado				BIT NOT NULL CONSTRAINT DF_estacivi_Estado DEFAULT(1)
   
   CONSTRAINT PK_gral_tbEstadosCiviles 												PRIMARY KEY(estacivi_Id),
   CONSTRAINT FK_gral_tbEstadosCiviles_acce_tbUsuarios_estacivi_UsuCreacion_user_Id  	FOREIGN KEY(estacivi_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
   CONSTRAINT FK_gral_tbEstadosCiviles_acce_tbUsuarios_estacivi_UsuModificacion_user_Id  FOREIGN KEY(estacivi_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);

--********TABLA CARGOS****************---
CREATE TABLE cons.tbCargos(
	carg_Id					INT IDENTITY,
	carg_Nombre				NVARCHAR(150) NOT NULL,
	carg_UsuCreacion		INT NOT NULL,
	carg_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_carg_FechaCreacion DEFAULT(GETDATE()),
	carg_UsuModificacion	INT,
	carg_FechaModificacion	DATETIME,
	carg_Estado				BIT NOT NULL CONSTRAINT DF_carg_Estado DEFAULT(1)

	CONSTRAINT PK_tbCargos											PRIMARY KEY(carg_Id),
	CONSTRAINT FK_tbCargos_tbUsuarios_carg_UsuCreacion_user_Id		FOREIGN KEY(carg_UsuCreacion)	  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbCargos_tbUsuarios_carg_UsuModificacion_user_Id	FOREIGN KEY(carg_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id)
);


/*
INSERT DE LA BASE DE DATOS
*/

GO
INSERT gral.tbDepartamentos(depa_Id, depa_Nombre, depa_UsuCreacion)
VALUES('01','Atlantida', 1),
      ('02','Colon', 1),
	  ('03','Comayagua', 1),
	  ('04','Copan', 1),
	  ('05','Cortes', 1),
	  ('06','Choluteca', 1),
	  ('07','El Paraiso', 1),
	  ('08','Francisco Morazan', 1),
	  ('09','Gracias a Dios', 1),
	  ('10','Intibuca', 1),
	  ('11','Islas de La Bahia', 1),
	  ('12','La Paz', 1),
	  ('13','Lempira', 1),
	  ('14','Ocotepeque', 1),
	  ('15','Olancho', 1),
	  ('16','Santa Barbara', 1),
	  ('17','Valle', 1),
	  ('18','Yoro', 1);

GO
INSERT gral.tbMunicipios(muni_id, muni_Nombre, depa_Id, muni_UsuCreacion)
VALUES('0101','La Ceiba ','01', 1),
      ('0102','El Porvenir','01', 1), 
	  ('0103','Jutiapa','01', 1),
	  ('0104','Jutiapa','01', 1),
	  ('0105','La Masica','01', 1),
	  ('0201','Trujillo','02', 1),
	  ('0202','Balfate','02', 1),
	  ('0203','Iriona','02', 1),
	  ('0204','Limon','02', 1),
	  ('0205','Saba','02', 1),
	  ('0301','Comayagua','03', 1),
	  ('0302','Ajuterique','03', 1),
      ('0303','El Rosario','03', 1),
	  ('0304','Esquias','03', 1),
      ('0305','Humuya','03', 1),
	  ('0401','Santa Rosa de Copan','04', 1),
	  ('0402','Cabanas','04', 1),
      ('0403','Concepcion','04', 1),
	  ('0404','Copan Ruinas','04', 1),
      ('0405','Corquin','04', 1),
	  ('0501','San Pedro Sula ','05', 1),
      ('0502','Choloma ','05', 1),
      ('0503','Omoa','05', 1),
      ('0504','Pimienta','05', 1),
	  ('0505','Potrerillos','05', 1),
	  ('0506','Puerto Cortes','05', 1),
	  ('0601','Choluteca','06', 1),
      ('0602','Apacilagua','06', 1),
      ('0603','Concepcion de Maria','06', 1),
      ('0604','Duyure','06', 1),
	  ('0605','El Corpus','07', 1),
	  ('0701','Yuscaran','07', 1),
      ('0702','Alauca','07', 1),
      ('0703','Danli','07', 1),
	  ('0704','El Paraiso','07', 1),
      ('0705','Ghinope','07', 1),
	  ('0801','Distrito Central (Comayaguela y Tegucigalpa)','08', 1),
      ('0802','Alubaran','08', 1),
      ('0803','Cedros','08', 1),
      ('0804','Curaron','08', 1),
	  ('0805','El Porvenir','08', 1),
	  ('0901','Puerto Lempira','09', 1),
      ('0902','Brus Laguna','09', 1),
      ('0903','Ahuas','09', 1),
	  ('0904','Juan Francisco Bulnes','09', 1),
      ('0905','Villeda Morales','09', 1),
	  ('1001','La Esperanza','10', 1),
      ('1002','Camasca','10', 1),
      ('1003','Colomoncagua','10', 1),
	  ('1004','Concepcion','10', 1),
      ('1005','Dolores','10', 1),
	  ('1101','Roatan','11', 1),
      ('1102','Guanaja','11', 1),
      ('1103','Jose Santos Guardiola','11', 1),
	  ('1104','Utila','11', 1),
	  ('1201','La Paz','12', 1),
      ('1202','Aguanqueterique','12', 1),
      ('1203','Cabanas','12', 1),
	  ('1204','Cane','12', 1),
      ('1205','Chinacla','12', 1),
	  ('1301','Gracias','13', 1),
      ('1302','Belen','13', 1),
      ('1303','Candelaria','13', 1),
	  ('1304','Cololaca','13', 1),
      ('1305','Erandique','13', 1),
	  ('1401','Ocotepeque','14', 1),
      ('1402','Belen Gualcho','14', 1),
      ('1403','Concepcion','14', 1),
	  ('1404','Dolores Merendon','14', 1),
      ('1405','Fraternidad','14', 1),
	  ('1501','Juticalpa','15', 1),
      ('1502','Campamento','15', 1),
      ('1503','Catacamas','15', 1),
	  ('1504','Concordia','15', 1),
      ('1505','Dulce Nombre de Culmo','15', 1),
	  ('1601','Santa Barbara','16', 1),
      ('1602','Arada','16', 1),
      ('1603','Atima','16', 1),
	  ('1604','Azacualpa','16', 1),
      ('1605','Ceguaca','16', 1),
	  ('1701','Nacaome','17', 1),
      ('1702','Alianza','17', 1),
      ('1703','Amapala','17', 1),
	  ('1704','Aramecina','17', 1),
      ('1705','Caridad','17', 1),
	  ('1801','Yoro','18', 1),
      ('1802','Arenal','18', 1),
      ('1803','El Negrito','18', 1),
	  ('1804','El Progreso','18', 1),
      ('1805','Jocon','18', 1)

/*Procedimientos de login y restablecimiento de contraseña*/
GO
CREATE OR ALTER PROCEDURE acce.UDP_Login
	@user_NombreUsuario		NVARCHAR(100),
	@user_Contrasena		NVARCHAR(100)
AS
BEGIN
	DECLARE @contraEncriptada NVARCHAR(MAX) = HASHBYTES('SHA2_512', @user_Contrasena)

	SELECT [user_Id],
		   [user_NombreUsuario],
		   [user_EsAdmin],
		   [role_Id]
	FROM [acce].[tbUsuarios]
	WHERE [user_NombreUsuario] = @user_NombreUsuario
	AND [user_Contrasena] = @contraEncriptada
END

GO 
CREATE OR ALTER PROCEDURE acce.UDP_RecuperarContra
	@user_NombreUsuario NVARCHAR(100),
	@user_Contrasena	NVARCHAR(100)
AS
BEGIN
	DECLARE @user_ContrasenaNueva NVARCHAR(MAX) = HASHBYTES('SHA2_512', @user_Contrasena)

	UPDATE [acce].[tbUsuarios]
	SET [user_Contrasena] = @user_ContrasenaNueva
	WHERE [user_NombreUsuario] = @user_NombreUsuario
END


/*Procedimientos de departamentos*/
--Departamentos (vista)
GO
CREATE OR ALTER VIEW gral.VW_tbDepartamentos
AS
	SELECT depa_Id, 
		   depa_Nombre, 
		   depa_UsuCreacion, 
		   T2.user_NombreUsuario AS depa_UsuCreacionNombre,
		   depa_FechaCreacion, 
		   depa_UsuModificacion, 
		   T3.user_NombreUsuario AS depa_UsuModificacionNombre,
		   depa_FechaModificacion
	FROM [gral].[tbDepartamentos] T1 INNER JOIN [acce].[tbUsuarios] T2
	ON T1.depa_UsuCreacion = T2.user_Id LEFT JOIN [acce].[tbUsuarios] T3
	ON T1.depa_UsuModificacion = T3.user_Id
	WHERE [depa_Estado] = 1


--Procedimiento listar departamentos
GO
CREATE OR ALTER PROCEDURE gral.UDP_tbDepartamentos_Listado
AS
BEGIN
	SELECT * FROM gral.VW_tbDepartamentos
END

/*Procedimientos de cargos*/
--Cargos vista
GO
CREATE OR ALTER VIEW cons.VW_tbCargos
AS
	SELECT carg_Id,
		   carg_Nombre,
		   carg_UsuCreacion,
		   T2.user_NombreUsuario AS carg_UsuCreacionNombre,
		   carg_FechaCreacion,
		   carg_UsuModificacion,
		   T3.user_NombreUsuario AS carg_UsuModificacionNombre,
		   carg_FechaModificacion
	FROM cons.tbCargos T1 INNER JOIN [acce].[tbUsuarios] T2 
	ON T1.carg_UsuCreacion = T2.user_Id LEFT JOIN [acce].[tbUsuarios] T3
	ON T1.carg_UsuModificacion = T3.user_Id

--Procedimiento listar cargos
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbCargos_List
AS
BEGIN
	SELECT * FROM cons.VW_tbCargos
END

--Procedimiento insertar cargos
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbCargos_Insert
	@carg_Nombre		NVARCHAR(150),
	@carg_UsuCreacion	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT carg_Nombre 
					   FROM cons.tbCargos 
					   WHERE carg_Nombre = @carg_Nombre)
			BEGIN			
				INSERT INTO cons.tbCargos(carg_Nombre, carg_UsuCreacion)
				VALUES(@carg_Nombre, @carg_UsuCreacion)

				SELECT 'El registro se ha insertado con éxito'
			END
		ELSE IF EXISTS (SELECT carg_Nombre 
					    FROM cons.tbCargos 
					    WHERE carg_Nombre = @carg_Nombre
						AND carg_Estado = 0)
			BEGIN
				UPDATE cons.tbCargos
				SET carg_Estado = 1
				WHERE carg_Nombre = @carg_Nombre

				SELECT 'El registro se ha insertado con éxito'
			END
		ELSE
			SELECT 'Ya existe un cargo con este nombre'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Procedimiento editar cargos
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbCargos_Update 
	@carg_Id				INT,
	@carg_Nombre			NVARCHAR(150),
	@carg_UsuModificacion	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT carg_Id FROM cons.tbCargos WHERE carg_Id = @carg_Id)
			BEGIN 
				SELECT 'El registro que intenta editar no existe'
			END
		ELSE
			BEGIN
				IF NOT EXISTS (SELECT carg_Nombre 
					   FROM cons.tbCargos 
					   WHERE carg_Nombre = @carg_Nombre
					   AND carg_Id != @carg_Id)
					BEGIN
						UPDATE cons.tbCargos 
						SET carg_Nombre = @carg_Nombre,
							carg_UsuModificacion = @carg_UsuModificacion,
							carg_FechaModificacion = GETDATE()
						WHERE carg_Id = @carg_Id

						SELECT 'El registro ha sido editado con éxito'
					END
				ELSE IF EXISTS (SELECT carg_Nombre 
								FROM cons.tbCargos
								WHERE carg_Estado = 0
								AND carg_Nombre = @carg_Nombre)
					BEGIN
						UPDATE cons.tbCargos
						SET carg_Estado = 1
						WHERE carg_Nombre = @carg_Nombre

						SELECT 'El registro ha sido editado con éxito'
					END
				ELSE
					SELECT 'Ya existe un cargo con este nombre'
			END
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

----Procedimiento insertar departamentos
--GO
--CREATE OR ALTER PROCEDURE gral.UDP_tbDepartamentos_Insert
--	@depa_Id			CHAR(4),
--	@depa_Nombre		NVARCHAR(150),
--	@depa_UsuCreacion	INT
--AS
--BEGIN
--	BEGIN TRY
--		INSERT INTO gral.tbDepartamentos(depa_Id, depa_Nombre, depa_UsuCreacion)
--	END TRY
--	BEGIN CATCH

--	END CATCH
--END
