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
	pant_Url				NVARCHAR(300) NOT NULL,
	pant_Menu				NVARCHAR(300) NOT NULL,
	pant_HtmlId				NVARCHAR(80) NOT NULL,
	pant_UsuCreacion		INT NOT NULL,
	pant_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pant_FechaCreacion DEFAULT(GETDATE()),
	pant_UsuModificacion	INT,
	pant_FechaModificacion	DATETIME,
	pant_Estado				BIT NOT NULL CONSTRAINT DF_pant_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbPantallas_pant_Id PRIMARY KEY(pant_Id)
);
GO

INSERT INTO acce.tbPantallas(pant_Nombre, pant_Url, pant_Menu, pant_HtmlId, pant_UsuCreacion)
VALUES ('Consultas', 'Consulta/Index', 'Consultorio', 'consultasItem', 1),
       ('Facturas', 'Factura/Index', 'Consultorio', 'facturasItem', 1),
	   ('Cargos', 'Cargo/Index', 'Consultorio', 'cargosItem',1),
	   ('Empleados', 'Empleado/Index', 'Consultorio', 'empleadosItem', 1),
	   ('Usuarios', 'Usuario/Index', 'Seguridad', 'usuariosItem', 1),
	   ('Roles', 'Rol/Index', 'Seguridad', 'rolesItem', 1)

GO
--***********CREACION TABLA ROLES/PANTALLA*****************---
CREATE TABLE acce.tbPantallasPorRoles(
	pantrole_Id					INT IDENTITY,
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
	@user_NombreUsuario		NVARCHAR(100),	
	@user_Contrasena		NVARCHAR(200),
	@user_EsAdmin			BIT,					
	@role_Id				INT, 
	@empe_Id				INT									
AS
BEGIN
	DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));
	INSERT acce.tbUsuarios(user_NombreUsuario, user_Contrasena, user_EsAdmin, role_Id, empe_Id, user_UsuCreacion)
	VALUES(@user_NombreUsuario, @password, @user_EsAdmin, @role_Id, @empe_Id, 1);
END;
GO
EXEC acce.UDP_InsertUsuario 'admin', '123', 1, 1, 1;

GO
CREATE OR ALTER PROCEDURE acce.UDP_InsertUsuarios
	@user_NombreUsuario		NVARCHAR(100),	
	@user_Contrasena		NVARCHAR(200),
	@user_EsAdmin			BIT,					
	@role_Id				INT, 
	@empe_Id				INT,
	@user_UsuCreacion		INT			
AS
BEGIN
	DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));

	BEGIN TRY
		IF NOT EXISTS (SELECT user_NombreUsuario 
					   FROM acce.tbUsuarios 
					   WHERE user_NombreUsuario = @user_NombreUsuario)
			BEGIN			
				INSERT INTO acce.tbUsuarios(user_NombreUsuario, user_Contrasena, user_EsAdmin, role_Id, empe_Id, user_UsuCreacion)
				VALUES(@user_NombreUsuario, @password, @user_EsAdmin, @role_Id, @empe_Id, @user_UsuCreacion);

				SELECT 'El registro se ha insertado con �xito'
			END
		ELSE IF EXISTS (SELECT user_NombreUsuario 
					    FROM acce.tbUsuarios  
					    WHERE user_NombreUsuario = @user_NombreUsuario
						AND user_Estado = 1)
			BEGIN
				UPDATE acce.tbUsuarios
				SET user_Estado = 1,
					user_Contrasena = @password,
					user_EsAdmin = @user_EsAdmin,
					role_Id = @role_Id,
					empe_Id = @empe_Id
				WHERE user_NombreUsuario = @user_NombreUsuario

				SELECT 'El registro se ha insertado con �xito'
			END
		ELSE
			SELECT 'Ya existe un cargo con este nombre'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END;
GO
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
   
   CONSTRAINT PK_gral_tbEstadosCiviles_estacivi_Id 										PRIMARY KEY(estacivi_Id),
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

	CONSTRAINT PK_tbCargos_carg_Id									PRIMARY KEY(carg_Id),
	CONSTRAINT FK_tbCargos_tbUsuarios_carg_UsuCreacion_user_Id		FOREIGN KEY(carg_UsuCreacion)	  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbCargos_tbUsuarios_carg_UsuModificacion_user_Id	FOREIGN KEY(carg_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id)
);

--********TABLA �REAS****************---
CREATE TABLE cons.tbAreas(
	area_Id					INT IDENTITY,
	area_Nombre				NVARCHAR(150) NOT NULL,
	area_UsuCreacion		INT NOT NULL,
	area_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_area_FechaCreacion DEFAULT(GETDATE()),
	area_UsuModificacion	INT,
	area_FechaModificacion	DATETIME,
	area_Estado				BIT NOT NULL CONSTRAINT DF_area_Estado DEFAULT(1)

	CONSTRAINT PK_tbAreas_area_Id									PRIMARY KEY(area_Id),
	CONSTRAINT FK_tbAreas_tbUsuarios_area_UsuCreacion_user_Id		FOREIGN KEY(area_UsuCreacion)	  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbAreas_tbUsuarios_area_UsuModificacion_user_Id	FOREIGN KEY(area_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id)
);

--********TABLA PROVEEDORES****************---
CREATE TABLE cons.tbProveedores(
	prov_Id					INT IDENTITY,
	prov_Nombre				NVARCHAR(300) NOT NULL,
	prov_Correo				NVARCHAR(300) NOT NULL,
	prov_Telefono			NVARCHAR(20) NOT NULL,
	prov_UsuCreacion		INT NOT NULL,
	prov_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_prov_FechaCreacion DEFAULT(GETDATE()),
	prov_UsuModificacion	INT,
	prov_FechaModificacion	DATETIME,
	prov_Estado				BIT NOT NULL CONSTRAINT DF_prov_Estado DEFAULT(1)

	CONSTRAINT PK_tbProveedores_prov_Id									PRIMARY KEY(prov_Id),
	CONSTRAINT FK_tbProveedores_tbUsuarios_prov_UsuCreacion_user_Id		FOREIGN KEY(prov_UsuCreacion)	  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbProveedores_tbUsuarios_prov_UsuModificacion_user_Id FOREIGN KEY(prov_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id)
);

--********TABLA MEDICAMENTOS****************---
CREATE TABLE cons.tbMedicamentos(
	medi_Id					INT IDENTITY,
	medi_Nombre				NVARCHAR(200) NOT NULL,
	prov_Id					INT NOT NULL,
	medi_PrecioCompra		DECIMAL(18,2) NOT NULL,
	medi_PrecioVenta		DECIMAL(18,2) NOT NULL,
	medi_Stock				INT NOT NULL,
	medi_UsuCreacion		INT NOT NULL,
	medi_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_medi_FechaCreacion DEFAULT(GETDATE()),
	medi_UsuModificacion	INT,
	medi_FechaModificacion	DATETIME,
	medi_Estado				BIT NOT NULL CONSTRAINT DF_medi_Estado DEFAULT(1)

	CONSTRAINT PK_tbMedicamentos_medi_Id								 PRIMARY KEY(medi_Id),
	CONSTRAINT FK_tbMedicamentos_tbUsuarios_medi_UsuCreacion_user_Id     FOREIGN KEY(medi_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbMedicamentos_tbUsuarios_medi_UsuModificacion_user_Id FOREIGN KEY(medi_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbMedicamentos_tbProveedores_prov_Id					 FOREIGN KEY(prov_Id)			   REFERENCES cons.tbProveedores(prov_Id)
);

/*
INSERTS DE LA BASE DE DATOS
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
GO
INSERT INTO gral.tbEstadosCiviles(estacivi_Nombre, estacivi_UsuCreacion)
VALUES ('Soltero(a)', 1),
	   ('Casado(a)', 1),
	   ('Divorciado(a)', 1),
	   ('Viudo(a)', 1),
	   ('Uni�n Libre', 1)

GO
INSERT INTO cons.tbCargos(carg_Nombre, carg_UsuCreacion)
VALUES ('M�dico general', 1),
		('Secretaria de  Gerencia', 1),
		('Encargada de Carnets Sanitarios y Pre-Nupciales', 1),
		('Administrador', 1),
		('Operario de Limpieza', 1),
		('Auditor Medico', 1),
		('Jefe de Enfermeria', 1),
		('Director Medico', 1),
		('Gerente', 1)
GO
INSERT INTO cons.tbAreas(area_Nombre,area_UsuCreacion,area_FechaCreacion,area_UsuModificacion,area_FechaModificacion,area_Estado)
VALUES ('Anestesiolog�a', 1, GETDATE(), NULL, NULL, 1),
       ('Cardiolog�a', 1, GETDATE(), NULL, NULL, 1),
       ('Cuidados Intensivos', 1, GETDATE(), NULL, NULL, 1),
       ('Ginecolog�a', 1, GETDATE(), NULL, NULL, 1),
       ('Dermatolog�a', 1, GETDATE(), NULL, NULL, 1),
       ('Traumatolog�a', 1, GETDATE(), NULL, NULL, 1),
       ('Farmacia', 1, GETDATE(), NULL, NULL, 1),
       ('Medicina Preventiva', 1, GETDATE(), NULL, NULL, 1),
       ('Radiodiagn�stico', 1, GETDATE(), NULL, NULL, 1),
       ('Laboratorio Cl�nico', 1, GETDATE(), NULL, NULL, 1);

GO
INSERT INTO cons.tbProveedores (prov_Nombre, prov_Correo, prov_Telefono, prov_UsuCreacion, prov_FechaCreacion, prov_UsuModificacion, prov_FechaModificacion, prov_Estado)
VALUES ('Konica HealthCare, INC', 'Konica@gmail.com', '9155-1234', 1, GETDATE(),NULL ,NULL, 1),
		('Vinno Technology CO.,LTD', 'Vinno@gmail.com', '9555-5678', 1, GETDATE(),NULL ,NULL, 1),
		('Neusoft Medical', 'neusoftmedical@gmail.com', '8555-9012', 1, GETDATE(),NULL ,NULL, 1),
		('VioPlast S.A.', 'vioplast@gmail.com', '8975-3456', 1, GETDATE(),NULL ,NULL, 1),
		('Grupo Vital S.A.S', 'grupovital@hotmail.com', '9901-7890', 1, GETDATE(),NULL ,NULL, 1),
		('iCRco, Inc', 'icrco@hotmail.com', '9761-2345', 1, GETDATE(),NULL ,NULL, 1),
		('Ingenieria Tecnologica', 'ingenieriatecnologica@gmail.com', '8771-6789', 1, GETDATE(),NULL ,NULL, 1),
		('EKF Diagnostics', 'ekfdiagnostics@gmail.com', '9551-0123', 1, GETDATE(),NULL ,NULL, 1),
		('GlobalDentt.CO', 'globaldentt@gmail.com', '3362-4567', 1,GETDATE(),NULL ,NULL,  1),
		('IndustriasMedicol', 'industriasmedicol@gmail.com', '8791-8901', 1, GETDATE(),NULL ,NULL, 1)

GO
INSERT INTO cons.tbMedicamentos (medi_Nombre, prov_Id, medi_PrecioCompra, medi_PrecioVenta, medi_Stock, medi_UsuCreacion, medi_FechaCreacion, medi_UsuModificacion, medi_FechaModificacion, medi_Estado) 
VALUES		('Halothano', 1, 10.50, 15.00, 100, 1, GETDATE(), NULL, NULL, 1),
			('Ketamina', 2, 8.75, 12.00, 200, 1, GETDATE(), NULL, NULL, 1),
			('Epinefrina', 1, 5.00, 8.50, 50, 1, GETDATE(), NULL, NULL, 1),
			('Diazepam', 3, 12.25, 18.00, 75, 1, GETDATE(), NULL, NULL, 1),
			('Morfina', 2, 9.99, 14.00, 150, 1, GETDATE(), NULL, NULL, 1),
			('Hidroxocobalamina', 1, 7.50, 11.00, 100, 1, GETDATE(), NULL, NULL, 1),
			('Clorfenamina', 3, 15.00, 22.50, 55, 1, GETDATE(), NULL, NULL, 1),
			('Paracetamol', 3, 25.00, 32.50, 21, 1, GETDATE(), NULL, NULL, 1),
			('Ibuprofeno', 3, 40.00, 60.00 , 30, 1, GETDATE(), NULL, NULL, 1),
			('Tanque de Ox�geno', 3, 1500.00, 2120.50, 150, 1, GETDATE(), NULL, NULL, 1)

--********TABLA CL�NICAS****************---
CREATE TABLE cons.tbClinicas(
	clin_Id					INT IDENTITY,
	clin_Nombre				NVARCHAR(200) NOT NULL,
	muni_Id					CHAR(4) NOT NULL,
	clin_Direccion			NVARCHAR(500) NOT NULL,
	empe_Id					INT NOT NULL,
	clin_UsuCreacion		INT NOT NULL,
	clin_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_clin_FechaCreacion DEFAULT(GETDATE()),
	clin_UsuModificacion	INT,
	clin_FechaModificacion	DATETIME,
	clin_Estado				BIT NOT NULL CONSTRAINT DF_clin_Estado DEFAULT(1)

	CONSTRAINT PK_tbClinicas_clin_Id								 PRIMARY KEY(clin_Id),
	CONSTRAINT FK_tbClinicas_tbUsuarios_clin_UsuCreacion_user_Id     FOREIGN KEY(clin_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbClinicas_tbUsuarios_clin_UsuModificacion_user_Id FOREIGN KEY(clin_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbClinicas_tbClinicas_muni_Id						 FOREIGN KEY(muni_Id)			   REFERENCES gral.tbMunicipios(muni_Id)
);

INSERT INTO cons.tbClinicas(clin_Nombre, 
							muni_Id, 
							clin_Direccion, 
							empe_Id, 
							clin_UsuCreacion)
VALUES ('Los Andes', '0501', 'Residencial Los Andes, calle no s� avenida peor', 1, 1),
		('Los Casta�os', '0501', 'Barrio Los Cedros, 2da avenida, 3ra calle', 1, 1),
		('Centro C�ceres', '0703', 'Los Casta�os, 8va avenida, 6ta calle', 1, 1),
		('Centro Enmanuel', '0401', 'Barrio Los Cedros, 2da avenida, 3ra calle', 1, 1),
		('Climedenti', '0903', 'Plaza Alic�a, 4ta avenida, 5ta calle', 1, 1),
		('Cl�nica M�dica San Isidro', '0903', 'Residencial Salamanca, 4ta avenida, 31 calle', 1, 1),
		('Honduras Medical Center', '1205', 'Mall Las Cascadas, 4ta avenida, 12va calle', 1, 1),
		('Torre M�dica Zafiro', '1205', 'Avenida los Proceres, 20va avenida, 1era calle', 1, 1)

GO
--********TABLA EMPLEADOS****************---
CREATE TABLE cons.tbEmpleados(
	empe_Id					INT IDENTITY,
	empe_Nombres			NVARCHAR(200) NOT NULL,
	empe_Apellido			NVARCHAR(200) NOT NULL,
	empe_Identidad			VARCHAR(13) NOT NULL,
	empe_Sexo				CHAR NOT NULL,
	estacivi_Id				INT NOT NULL,
	empe_FechaNacimiento	DATETIME NOT NULL,
	muni_Id					CHAR(4) NOT NULL,
	empe_Direccion			NVARCHAR(500) NOT NULL,
	empe_Telefono			NVARCHAR(20) NOT NULL,
	empe_Correo				NVARCHAR(120) NOT NULL,
	empe_FechaInicio		DATE NOT NULL,
	empe_FechaFinal			DATE,
	carg_Id					INT NOT NULL,
	clin_Id					INT NOT NULL,
	empe_UsuCreacion		INT NOT NULL,
	empe_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_empe_FechaCreacion DEFAULT(GETDATE()),
	empe_UsuModificacion	INT,
	empe_FechaModificacion	DATETIME,
	empe_Estado				BIT NOT NULL CONSTRAINT DF_empe_Estado DEFAULT(1)

	CONSTRAINT PK_tbEmpleados_empe_Id									PRIMARY KEY(empe_Id),
	CONSTRAINT FK_tbEmpleados_tbUsuarios_empe_UsuCreacion_user_Id		FOREIGN KEY(empe_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbEmpleados_tbUsuarios_empe_UsuModificacion_user_Id	FOREIGN KEY(empe_UsuModificacion)  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbEmpleados_tbEstadosCiviles_estacivi_Id				FOREIGN KEY(estacivi_Id)		   REFERENCES gral.tbEstadosCiviles(estacivi_Id),
	CONSTRAINT FK_tbEmpleados_tbMunicipios_muni_Id						FOREIGN KEY(muni_Id)			   REFERENCES gral.tbMunicipios(muni_Id),
	CONSTRAINT CK_tbEmpleados_empe_Sexo									CHECK(empe_Sexo IN ('F', 'M')),
	CONSTRAINT FK_tbEmpleados_tbClinicas_clin_Id						FOREIGN KEY(clin_Id)			   REFERENCES cons.tbClinicas(clin_Id),
	CONSTRAINT FK_tbEmpleados_tbCargos_carg_Id							FOREIGN KEY(carg_Id)			   REFERENCES cons.tbCargos(carg_Id)
);

INSERT INTO cons.tbEmpleados(empe_Nombres, empe_Apellido, 
							 empe_Identidad, empe_Sexo, 
							 estacivi_Id, empe_FechaNacimiento, 
							 muni_Id, empe_Direccion,
							 empe_Telefono, empe_Correo,
							 empe_FechaInicio, empe_FechaFinal,
							 carg_Id, clin_Id,
							 empe_UsuCreacion)
VALUES('Juan','Molina','0501200506728','M',1,'2005-05-06','0501','Valle de Sula','98789658','juanmolina@gmail.com','2023-03-01',NULL,1,1,1),
		('Fernando','Casta�eda','0902250500728','M',1,'2001-02-04','0902','Calle las Brisas','87756952','fernandocasta�eda1@gmail.com','2023-07-02',NULL,1,1,1),
		('Selvin','Medina','1201200501228','M',1,'2002-01-09','1201','La Rivera','98789658','selvinmedi@gmail.com','2023-01-03',NULL,1,1,1),
		('Axel','Gomez','0501200506728','M',1,'2000-01-10','0501','Bosques de Jucutuma','99220345','gomez03@gmail.com','2023-06-02',NULL,1,1,1),
		('Andrea','Montenegro','0311200506728','M',1,'1999-02-11','0301','Col. Felipe','88541230','andreamontenegro@gmail.com','2023-03-01',NULL,1,1,1),
		('Daniel','Espinoza','1101200836721','M',1,'2001-10-10','1101','Col. Satelite','89031285','danielespi@outlook.com','2023-01-12',NULL,1,1,1),
		('Francisco','Antunez','0401200506123','M',1,'2000-09-09','0501','Barrio las Acacias','97350100','fransiscojoelr@gmail.com','2023-03-01',NULL,1,1,1),
		('Felicia','Ramirez','0401200506125','M',1,'1994-02-09','0401','Colonia Smith','98789658','juanmolina@gmail.com','2023-03-01',NULL,1,1,1),
		('Soledad','Perez','0501200506877','M',1,'1998-01-10','0501','Salida a la Lima','98789658','juanmolina@gmail.com','2023-03-01',NULL,1,1,1),
		('Wilfredo','Lopez','0501200526739','M',1,'2001-09-11','0501','Colonia Ideal','98789658','juanmolina@gmail.com','2023-03-01',NULL,1,1,1)


ALTER TABLE cons.tbClinicas
ADD CONSTRAINT FK_tbClientes_tbEmpleados_empe_Id FOREIGN KEY(empe_Id) REFERENCES cons.tbEmpleados(empe_Id)

GO
ALTER TABLE acce.tbUsuarios
ADD CONSTRAINT FK_tbUsuarios_tbEmpleados_empe_Id FOREIGN KEY(empe_Id) REFERENCES cons.tbEmpleados(empe_Id)

GO
CREATE TABLE cons.tbPacientes(
	paci_Id					INT IDENTITY,
	paci_Nombres			NVARCHAR(200) NOT NULL,
	paci_Apellidos			NVARCHAR(200) NOT NULL,
	paci_Identidad			VARCHAR(13) NOT NULL,
	paci_TipoSangre			CHAR(4),
	paci_FechaNacimiento	DATE NOT NULL,
	estacivi_Id				INT NOT NULL,
	paci_Telefono			NVARCHAR(20) NOT NULL,
	paci_UsuCreacion		INT NOT NULL,
	paci_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_paci_FechaCreacion DEFAULT(GETDATE()),
	paci_UsuModificacion	INT,
	paci_FechaModificacion	DATETIME,
	paci_Estado				BIT NOT NULL CONSTRAINT DF_paci_Estado DEFAULT(1)
	
	CONSTRAINT PK_tbPacientes_paci_Id									PRIMARY KEY(paci_Id),
	CONSTRAINT FK_tbPacientes_tbUsuarios_paci_UsuCreacion_user_Id		FOREIGN KEY(paci_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbPacientes_tbUsuarios_paci_UsuModificacion_user_Id	FOREIGN KEY(paci_UsuModificacion)  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbPacientes_tbEstadosCiviles_estacivi_Id				FOREIGN KEY(estacivi_Id)		   REFERENCES gral.tbEstadosCiviles(estacivi_Id),
);
GO
INSERT INTO cons.tbPacientes (paci_Nombres, paci_Apellidos, paci_Identidad, paci_TipoSangre, paci_FechaNacimiento, estacivi_Id, paci_Telefono, paci_UsuCreacion, paci_Estado)
VALUES
('Juan', 'P�rez', '1234567891011', 'O+', '1990-01-01', 1, '2009-09-09', 1, 1),
('Mar�a', 'Gonz�lez', '234567890234', 'B-', '1985-03-15', 2, '2018-08-08', 1, 1),
('Luis', 'Mart�nez', '3456789019823', 'AB+', '1995-05-20', 2, '2017-07-07', 1, 1),
('Ana', 'Fern�ndez', '4567890124671', 'A+', '1998-07-12', 1, '2016-06-06', 1, 1),
('Pedro', 'S�nchez', '5678901230923', 'O-', '1980-09-30', 2, '2015-05-05', 1, 1),
('Sof�a', 'L�pez', '6789012344610', 'B+', '1982-11-25', 3, '2014-04-04', 1, 1),
('Ricardo', 'Garc�a', '7890123451725', 'AB-', '1992-02-14', 1, '2013-03-03', 1, 1),
('Laura', 'Hern�ndez', '8901234562763', 'A-', '1996-04-18', 2, '2012-02-02', 1, 1),
('Fernando', 'D�az', '9012345672763', 'O+', '1988-06-07', 4, '2021-11-11', 1, 1),
('Carla', 'Ram�rez', '0123456780090', 'B-', '1984-08-23', 1, '2023-10-14', 1, 1);

GO

CREATE TABLE cons.tbConsultorios(
	consltro_Id					INT IDENTITY,
	consltro_Nombre				NVARCHAR(20) NOT NULL,
	area_Id						INT NOT NULL,
	empe_Id						INT NOT NULL,
	consltro_UsuCreacion		INT NOT NULL,
	consltro_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_consltro_FechaCreacion DEFAULT(GETDATE()),
	consltro_UsuModificacion	INT,
	consltro_FechaModificacion	DATETIME,
	consltro_Estado				BIT NOT NULL CONSTRAINT DF_consltro_Estado DEFAULT(1)

	CONSTRAINT PK_tbConsultorios_consltro_Id									PRIMARY KEY(consltro_Id),
	CONSTRAINT FK_tbConsultorios_tbUsuarios_consltro_UsuCreacion_user_Id		FOREIGN KEY(consltro_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbConsultorios_tbUsuarios_consltro_UsuModificacion_user_Id	FOREIGN KEY(consltro_UsuModificacion)  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbConsultorios_tbAreas_area_Id								FOREIGN KEY(area_Id)				   REFERENCES cons.tbAreas(area_Id),
	CONSTRAINT FK_tbConsultorios_tbEmpleados_empe_Id FOREIGN KEY(empe_Id) REFERENCES cons.tbEmpleados(empe_Id)
);
GO
INSERT INTO cons.tbConsultorios(consltro_Nombre, area_Id, empe_Id, consltro_UsuCreacion, consltro_Estado)
VALUES ('Vida', 1, 1, 1, 1),
		('Vitals', 2, 2, 1, 1),
		('C.E.R', 1, 3, 1, 1),
		('M�dico Chinchilla', 3, 4, 1, 1),
		('Valladares', 2, 5, 1, 1),
		('Buena Fe', 3, 6, 1, 1),
		('Brisas', 1, 7, 1, 1),
		('MEDIAFAM', 2, 8, 1, 1),
		('Guerrero', 3, 9, 1, 1),
		('San Jos�', 1, 10, 1, 1)
GO

CREATE TABLE cons.tbConsultas(
	cons_Id					INT IDENTITY,
	cons_Inicio				DATETIME NOT NULL,
	cons_Final				DATETIME NOT NULL,
	paci_Id					INT NOT NULL,
	consltro_Id				INT NOT NULL,
	cons_Costo				DECIMAL(18,2),
	cons_UsuCreacion		INT NOT NULL,
	cons_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_cons_FechaCreacion DEFAULT(GETDATE()),
	cons_UsuModificacion	INT,
	cons_FechaModificacion	DATETIME,
	cons_Estado				BIT NOT NULL CONSTRAINT DF_cons_Estado DEFAULT(1)

	CONSTRAINT PK_tbConsultas_cons_Id									PRIMARY KEY(cons_Id),
	CONSTRAINT FK_tbConsultas_tbUsuarios_cons_UsuCreacion_user_Id		FOREIGN KEY(cons_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbConsultas_tbUsuarios_cons_UsuModificacion_user_Id	FOREIGN KEY(cons_UsuModificacion)  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbConsultas_tbPacientes_paci_Id						FOREIGN KEY(paci_Id)			   REFERENCES cons.tbPacientes(paci_Id),
	CONSTRAINT FK_tbConsultas_tbConsultorios_consltro_Id				FOREIGN KEY(consltro_Id)		   REFERENCES cons.tbConsultorios(consltro_Id)
);
INSERT INTO cons.tbConsultas(cons_Inicio, cons_Final, paci_Id, consltro_Id, cons_Costo, cons_UsuCreacion, cons_Estado)
VALUES	('2023-03-27', '2023-03-27', 1, 1, 800, 1, 1),
		('2023-03-28', '2023-03-28', 1, 2, 300, 1, 1),
		('2023-03-22', '2023-03-22', 1, 1, 900, 1, 1),
		('2023-03-02', '2023-03-02', 1, 4, 1000, 1, 1)

CREATE TABLE cons.tbMetodosPago(
	meto_Id					INT IDENTITY,
	meto_Nombre				NVARCHAR(60) NOT NULL,
	meto_UsuCreacion		INT NOT NULL,
	meto_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_meto_FechaCreacion DEFAULT(GETDATE()),
	meto_UsuModificacion	INT,
	meto_FechaModificacion	DATETIME,
	meto_Estado				BIT NOT NULL CONSTRAINT DF_meto_Estado DEFAULT(1)
	
	CONSTRAINT PK_tbMetodosPago_meto_Id									PRIMARY KEY(meto_Id),
	CONSTRAINT FK_tbMetodosPago_tbUsuarios_meto_UsuCreacion_user_Id		FOREIGN KEY(meto_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbMetodosPago_tbUsuarios_meto_UsuModificacion_user_Id	FOREIGN KEY(meto_UsuModificacion)  REFERENCES acce.tbUsuarios(user_Id)
);
INSERT INTO cons.tbMetodosPago (meto_Nombre, meto_UsuCreacion, meto_FechaCreacion, meto_UsuModificacion, meto_FechaModificacion, meto_Estado)
VALUES	('Efectivo', 1, GETDATE(), NULL, NULL, 1),
		('Tarjeta de cr�dito', 1, GETDATE(), NULL, NULL, 1),
		('Cheque', 1, GETDATE(), NULL, NULL, 1),
		('Transferencia Bancaria', 1, GETDATE(), NULL, NULL, 1),
		('Paypal', 1, GETDATE(), NULL, NULL, 1)

CREATE TABLE cons.tbFacturas(
	fact_Id					INT IDENTITY,
	fact_Fecha				DATETIME NOT NULL,
	paci_Id					INT NOT NULL,
	empe_Id					INT NOT NULL,
	meto_Id					INT NOT NULL,
	fact_UsuCreacion		INT NOT NULL,
	fact_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_fact_FechaCreacion DEFAULT(GETDATE()),
	fact_UsuModificacion	INT,
	fact_FechaModificacion	DATETIME,
	fact_Estado				BIT NOT NULL CONSTRAINT DF_fact_Estado DEFAULT(1)

	CONSTRAINT PK_tbFacturas_fact_Id									PRIMARY KEY(fact_Id),
	CONSTRAINT FK_tbFacturas_tbUsuarios_fact_UsuCreacion_user_Id		FOREIGN KEY(fact_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbFacturas_tbUsuarios_fact_UsuModificacion_user_Id	FOREIGN KEY(fact_UsuModificacion)  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbFacturas_tbPacientes_paci_Id						FOREIGN KEY(paci_Id)			   REFERENCES cons.tbPacientes(paci_Id),
	CONSTRAINT FK_tbFacturas_tbPacientes_empe_Id						FOREIGN KEY(empe_Id)			   REFERENCES cons.tbEmpleados(empe_Id),
	CONSTRAINT FK_tbFacturas_tbMetodosPago_empe_Id						FOREIGN KEY(meto_Id)			   REFERENCES cons.tbMetodosPago(meto_Id)
);
GO
INSERT INTO cons.tbFacturas(fact_Fecha, paci_Id, empe_Id, meto_Id, fact_UsuCreacion, fact_Estado)
VALUES ('2022-01-01', 1, 1, 1, 1, 1),
		('2022-01-02', 2, 1, 2, 1, 1),
		('2022-01-03', 3, 2, 1, 1, 1),
		('2022-01-04', 4, 2, 4, 1, 1),
		('2022-01-05', 5, 3, 1, 1, 1),
		('2022-01-06', 6, 3, 2, 1, 1),
		('2022-01-07', 7, 4, 1, 1, 1),
		('2022-01-08', 8, 4, 2, 1, 1),
		('2022-01-09', 9, 5, 3, 1, 1),
		('2022-01-10', 10, 5, 2, 1, 1)
GO

CREATE TABLE cons.tbFacturasDetalles(
	factdeta_Id					INT IDENTITY,
	fact_Id						INT NOT NULL,
	cons_Id						INT,
	factdeta_UsuCreacion		INT NOT NULL,
	factdeta_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_factdeta_FechaCreacion DEFAULT(GETDATE()),
	factdeta_UsuModificacion	INT,
	factdeta_FechaModificacion	DATETIME,
	factdeta_Estado				BIT NOT NULL CONSTRAINT DF_factdeta_Estado DEFAULT(1)

	CONSTRAINT PK_tbFacturasDetalles_factdeta_Id									PRIMARY KEY(factdeta_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbUsuarios_factdeta_UsuCreacion_user_Id		FOREIGN KEY(factdeta_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbUsuarios_factdeta_UsuModificacion_user_Id	FOREIGN KEY(factdeta_UsuModificacion)  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbFacturas_fact_Id								FOREIGN KEY(fact_Id)				   REFERENCES cons.tbFacturas(fact_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbConsultas_cons_Id							FOREIGN KEY(cons_Id)				   REFERENCES cons.tbConsultas(cons_Id)
);

/*Procedimientos de login y restablecimiento de contrase�a*/
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

--Procedimiento municipios por departamento
GO 
CREATE OR ALTER PROCEDURE gral.UDP_tbMunicipios_ListadoDepa
	@depa_Id	CHAR(2)
AS
BEGIN
	SELECT [muni_id], [muni_Nombre]
	FROM [gral].[tbMunicipios]
	WHERE [depa_Id] = @depa_Id
	AND [muni_Estado] = 1
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
		   carg_FechaModificacion,
		   carg_Estado
	FROM cons.tbCargos T1 INNER JOIN [acce].[tbUsuarios] T2 
	ON T1.carg_UsuCreacion = T2.user_Id LEFT JOIN [acce].[tbUsuarios] T3
	ON T1.carg_UsuModificacion = T3.user_Id

--Procedimiento listar cargos
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbCargos_List
AS
BEGIN
	SELECT * FROM cons.VW_tbCargos
	WHERE carg_Estado = 1
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

				SELECT 'El registro se ha insertado con �xito'
			END
		ELSE IF EXISTS (SELECT carg_Nombre 
					    FROM cons.tbCargos 
					    WHERE carg_Nombre = @carg_Nombre
						AND carg_Estado = 0)
			BEGIN
				UPDATE cons.tbCargos
				SET carg_Estado = 1
				WHERE carg_Nombre = @carg_Nombre

				SELECT 'El registro se ha insertado con �xito'
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

						SELECT 'El registro ha sido editado con �xito'
					END
				ELSE IF EXISTS (SELECT carg_Nombre 
								FROM cons.tbCargos
								WHERE carg_Estado = 0
								AND carg_Nombre = @carg_Nombre)
					BEGIN
						UPDATE cons.tbCargos
						SET carg_Estado = 1
						WHERE carg_Nombre = @carg_Nombre

						SELECT 'El registro ha sido editado con �xito'
					END
				ELSE
					SELECT 'Ya existe un cargo con este nombre'
			END
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Procedimiento eliminar cargos
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbCargos_Delete
	@carg_Id	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT carg_Id FROM cons.tbCargos WHERE carg_Id = @carg_Id)
			BEGIN
				SELECT 'El registro que intenta eliminar no existe'
			END
		ELSE
			UPDATE cons.tbCargos
			SET carg_Estado = 0
			WHERE carg_Id = @carg_Id

			SELECT 'El registro ha sido eliminado con �xito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Procedimiento encontrar cargos
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbCargos_Find 
	@carg_Id		INT
AS
BEGIN
	SELECT * FROM cons.VW_tbCargos WHERE [carg_Id] = @carg_Id
END

/*Procedimientos de consultas*/

--Vista consultas
GO
CREATE OR ALTER VIEW cons.VW_tbConsultas
AS
	SELECT [cons_Id], 
		   [cons_Inicio], 
		   [cons_Final],
		   (CONVERT(varchar(19), cons_Final, 120) + ' ' + T2.consltro_Nombre) AS cons_DropDown,
		   T1.[consltro_Id], 
		   T2.consltro_Nombre,
		   T1.paci_Id,
		   (T3.paci_Nombres + ' ' + T3.paci_Apellidos) AS cons_Paciente,
		   cons_Costo,
		   T1.cons_UsuCreacion,
		   T4.user_NombreUsuario AS cons_UsuarioCreacionNombre,
		   t1.cons_UsuModificacion,
		   T5.user_NombreUsuario AS cons_UsuarioModificacionNombre
	FROM cons.tbConsultas T1 INNER JOIN cons.tbConsultorios T2
	ON T1.consltro_Id = T2.consltro_Id INNER JOIN cons.tbPacientes T3
	ON T1.paci_Id = T3.paci_Id INNER JOIN acce.tbUsuarios T4
	ON T1.cons_UsuCreacion = T4.user_Id LEFT JOIN acce.tbUsuarios T5
	ON t1.cons_UsuModificacion = T5.user_Id

--Procedimiento listar consultas
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbConsultas_List
AS
BEGIN
	SELECT * FROM cons.VW_tbConsultas
END

--Procedimiento insertar consultas
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbConsultas_Insert
	@cons_Inicio		DATETIME,
	@cons_Final			DATETIME,
	@paci_Id			INT,
	@consltro_Id		INT,
	@cons_Costo			DECIMAL(18,2),
	@cons_UsuCreacion	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT cons_Id FROM cons.tbConsultas 
						WHERE cons_Inicio = @cons_Inicio 
						AND cons_Final = @cons_Final 
						AND consltro_Id = @consltro_Id
						AND paci_Id = @paci_Id) 
			BEGIN
				INSERT INTO cons.tbConsultas(cons_Inicio, 
											 cons_Final, 
											 paci_Id, 
											 consltro_Id, 
											 cons_Costo, 
											 cons_UsuCreacion)
				VALUES(@cons_Inicio, @cons_Final, @paci_Id, @consltro_Id, @cons_Costo, @cons_UsuCreacion)

				SELECT 'El registro ha sido ingresado con �xito'
			END
		ELSE IF EXISTS (SELECT * FROM cons.tbConsultas
						   WHERE cons_Inicio = @cons_Inicio 
						   AND cons_Final = @cons_Final 
						   AND consltro_Id = @consltro_Id
						   AND paci_Id = @paci_Id
						   AND cons_Estado = 0)
			BEGIN
				UPDATE cons.tbConsultas
				SET cons_Estado = 1
				WHERE cons_Inicio = @cons_Inicio 
				      AND cons_Final = @cons_Final 
				      AND consltro_Id = @consltro_Id
				      AND paci_Id = @paci_Id

				SELECT 'El registro ha sido ingresado con �xito'
			END 
		ELSE
			SELECT 'Esta consulta ya existe'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Procedimiento editar consultas
GO 
CREATE OR ALTER PROCEDURE cons.UDP_tbConsultas_Update
	@cons_Id				INT,
	@cons_Inicio			DATETIME,
	@cons_Final				DATETIME,
	@paci_Id				INT,
	@consltro_Id			INT,
	@cons_Costo				DECIMAL(18,2),
	@cons_UsuModificacion	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM cons.tbConsultas WHERE cons_Id = @cons_Id)
			BEGIN 
				SELECT 'El registro que intenta editar no existe'
			END
		ELSE
			BEGIN
				IF NOT EXISTS (SELECT * 
								FROM cons.tbConsultas 
								WHERE cons_Inicio = @cons_Inicio 
									AND cons_Final = @cons_Final 
									AND consltro_Id = @consltro_Id
									AND paci_Id = @paci_Id
									AND cons_Id != cons_Id) 

					BEGIN
						UPDATE cons.tbConsultas 
						SET   cons_Inicio = @cons_Inicio,
							  cons_Final = @cons_Final,
							  consltro_Id = @consltro_Id,
							  paci_Id = @paci_Id,
							  cons_FechaModificacion = GETDATE(),
							  cons_UsuModificacion = @cons_UsuModificacion
						WHERE cons_Id = @cons_Id

						SELECT 'El registro ha sido editado con �xito'
					END
				ELSE IF EXISTS (SELECT* 
								FROM cons.tbConsultas
								WHERE cons_Estado = 0
								AND cons_Inicio = @cons_Inicio 
								AND cons_Final = @cons_Final 
								AND consltro_Id = @consltro_Id
								AND paci_Id = @paci_Id
								AND cons_Id != @cons_Id)
					BEGIN
						UPDATE cons.tbConsultas
						SET cons_Estado = 1
						WHERE cons_Inicio = @cons_Inicio 
						AND cons_Final = @cons_Final 
						AND consltro_Id = @consltro_Id
						AND paci_Id = @paci_Id
						AND cons_Id != cons_Id

						SELECT 'El registro ha sido editado con �xito'
					END
				ELSE
					SELECT 'Esta consulta ya existe'
			END
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Procedimiento eliminar consultas
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbConsultas_Delete
	@cons_Id				INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM cons.tbConsultas WHERE cons_Id = @cons_Id)
			BEGIN
				SELECT 'El registro que intenta eliminar no existe'
			END
		ELSE
			UPDATE cons.tbConsultas
			SET cons_Estado = 0
			WHERE cons_Id = @cons_Id

			SELECT 'El registro ha sido eliminado con �xito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

/*Procedimientos empleados*/
--Vista empleados
GO
CREATE OR ALTER VIEW cons.VW_tbEmpleados
AS
	SELECT T1.[empe_Id], 
		   [empe_Nombres],
		   [empe_Apellido],
		   ([empe_Nombres] + ' ' + [empe_Apellido]) AS empe_NombreCompleto,
		   [empe_Identidad],
		   [empe_Sexo],
		   T1.[estacivi_Id],
		   T2.estacivi_Nombre,
		   [empe_FechaNacimiento],
		   T1.[muni_Id],
		   T3.muni_Nombre,
		   T3.depa_Id,
		   [empe_Direccion],
		   [empe_Telefono],
		   [empe_Correo],
		   [empe_FechaInicio],
		   [empe_FechaFinal],
		   T1.[carg_Id],
		   T4.carg_Nombre,
		   t1.clin_Id,
		   T7.clin_Nombre,
		   T1.empe_UsuCreacion,
		   T5.user_NombreUsuario AS empe_UsuCreacionNombre,
		   T1.empe_UsuModificacion,
		   T6.user_NombreUsuario AS empe_usuModificacionNombre,
		   empe_Estado,
		   empe_FechaCreacion,
		   empe_FechaModificacion
FROM cons.tbEmpleados T1 INNER JOIN gral.tbEstadosCiviles T2
ON T1.estacivi_Id = T2.estacivi_Id INNER JOIN gral.tbMunicipios T3
ON T1.muni_Id = T3.muni_id INNER JOIN cons.tbCargos T4
ON T1.carg_Id = T4.carg_Id INNER JOIN acce.tbUsuarios T5
ON T1.empe_UsuCreacion = T5.user_Id LEFT JOIN acce.tbUsuarios T6
ON T1.empe_UsuModificacion = T6.user_Id INNER JOIN cons.tbClinicas T7
ON T1.clin_Id = T7.clin_Id

--Procedimiento listar empleados
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbEmpleados_List
AS
BEGIN
	SELECT * FROM cons.VW_tbEmpleados WHERE empe_Estado = 1
END

GO
CREATE OR ALTER PROCEDURE cons.UDP_tbEmpleados_Insert
	@empe_Nombres			NVARCHAR(200), 
	@empe_Apellido			NVARCHAR(200), 
	@empe_Identidad			VARCHAR(13),
	@empe_Sexo				CHAR, 
	@estacivi_Id			INT, 
	@empe_FechaNacimiento	DATE, 
	@muni_Id				CHAR(4), 
	@empe_Direccion			NVARCHAR(500), 
	@empe_Telefono			NVARCHAR(15), 
	@empe_Correo			NVARCHAR(120), 
	@empe_FechaInicio		DATE, 
	@empe_FechaFinal		DATE, 
	@carg_Id				INT, 
	@clin_Id				INT, 
	@empe_UsuCreacion		INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT empe_Identidad 
					   FROM cons.tbEmpleados 
					   WHERE empe_Identidad = @empe_Identidad)
			BEGIN			
				INSERT INTO cons.tbEmpleados(empe_Nombres, 
											 empe_Apellido, empe_Identidad, 
											 empe_Sexo, estacivi_Id, 
											 empe_FechaNacimiento, muni_Id, 
											 empe_Direccion, empe_Telefono, 
											 empe_Correo, empe_FechaInicio, 
											 empe_FechaFinal, carg_Id, 
											 clin_Id, empe_UsuCreacion)
				VALUES(@empe_Nombres, 
					   @empe_Apellido, @empe_Identidad, 
					   @empe_Sexo, @estacivi_Id, 
					   @empe_FechaNacimiento, @muni_Id, 
					   @empe_Direccion, @empe_Telefono, 
					   @empe_Correo, @empe_FechaInicio, 
					   @empe_FechaFinal, @carg_Id, 
					   @clin_Id, @empe_UsuCreacion)

				SELECT 'El registro se ha insertado con �xito'
			END
		ELSE IF EXISTS (SELECT empe_Identidad 
					   FROM cons.tbEmpleados 
					   WHERE empe_Identidad = @empe_Identidad
					   AND empe_Estado = 0)
			BEGIN
				UPDATE cons.tbEmpleados
				SET empe_Estado = 1,
					empe_Nombres = @empe_Nombres,			 
					empe_Apellido = @empe_Apellido,		
					empe_Sexo = @empe_Sexo,				
					estacivi_Id = @estacivi_Id,			
					empe_FechaNacimiento = @empe_FechaNacimiento,	
					muni_Id = @muni_Id,				
					empe_Direccion = @empe_Direccion,			 
					empe_Telefono = @empe_Telefono,			
					empe_Correo = @empe_Correo,			 
					empe_FechaInicio = @empe_FechaInicio,		
					empe_FechaFinal = @empe_FechaFinal,		
					carg_Id = @carg_Id,				
					clin_Id = @clin_Id		
				WHERE empe_Identidad = @empe_Identidad

				SELECT 'El registro se ha insertado con �xito'
			END
		ELSE
			SELECT 'Ya existe un empleado con este n�mero de identidad'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

GO
CREATE OR ALTER PROCEDURE cons.UDP_tbEmpleados_Update
	@empe_Id				INT,
	@empe_Nombres			NVARCHAR(200), 
	@empe_Apellido			NVARCHAR(200), 
	@empe_Identidad			VARCHAR(13),
	@empe_Sexo				CHAR, 
	@estacivi_Id			INT, 
	@empe_FechaNacimiento	DATE, 
	@muni_Id				CHAR(4), 
	@empe_Direccion			NVARCHAR(500), 
	@empe_Telefono			NVARCHAR(15), 
	@empe_Correo			NVARCHAR(120), 
	@empe_FechaInicio		DATE, 
	@empe_FechaFinal		DATE, 
	@carg_Id				INT, 
	@clin_Id				INT, 
	@empe_UsuModificacion	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM cons.tbEmpleados WHERE empe_Id = @empe_Id)
			BEGIN 
				SELECT 'El registro que intenta editar no existe'
			END
		ELSE
			BEGIN
				IF NOT EXISTS (SELECT * 
								FROM cons.tbEmpleados 
								WHERE empe_Identidad = @empe_Identidad
									AND empe_Id != @empe_Id) 

					BEGIN
						UPDATE cons.tbEmpleados 
						SET   empe_Nombres = @empe_Nombres,			 
							  empe_Apellido = @empe_Apellido,	
							  empe_Identidad = @empe_Identidad,
							  empe_Sexo = @empe_Sexo,				
							  estacivi_Id = @estacivi_Id,			
							  empe_FechaNacimiento = @empe_FechaNacimiento,	
							  muni_Id = @muni_Id,				
							  empe_Direccion = @empe_Direccion,			 
							  empe_Telefono = @empe_Telefono,			
							  empe_Correo = @empe_Correo,			 
							  empe_FechaInicio = @empe_FechaInicio,		
							  empe_FechaFinal = @empe_FechaFinal,		
							  carg_Id = @carg_Id,				
							  clin_Id = @clin_Id,
							  empe_UsuModificacion = @empe_UsuModificacion,
							  empe_FechaModificacion = GETDATE()
						WHERE empe_Id = @empe_Id

						SELECT 'El registro ha sido editado con �xito'
					END
				ELSE IF EXISTS (SELECT * 
								FROM cons.tbEmpleados
								WHERE empe_Estado = 0
								AND empe_Identidad = @empe_Identidad
								AND empe_Id != @empe_Id)
					BEGIN
						UPDATE cons.tbEmpleados
						SET empe_Estado = 1,
							empe_Nombres = @empe_Nombres,			 
							empe_Apellido = @empe_Apellido,	
							empe_Sexo = @empe_Sexo,				
							estacivi_Id = @estacivi_Id,			
							empe_FechaNacimiento = @empe_FechaNacimiento,	
							muni_Id = @muni_Id,				
							empe_Direccion = @empe_Direccion,			 
							empe_Telefono = @empe_Telefono,			
							empe_Correo = @empe_Correo,			 
							empe_FechaInicio = @empe_FechaInicio,		
							empe_FechaFinal = @empe_FechaFinal,		
							carg_Id = @carg_Id,				
							clin_Id = @clin_Id,
							empe_UsuModificacion = @empe_UsuModificacion,
							empe_FechaModificacion = GETDATE()
						WHERE empe_Identidad = @empe_Identidad 

						SELECT 'El registro ha sido editado con �xito'
					END
				ELSE
					SELECT 'Un empleado con el mismo n�mero de identidad ya existe'
			END
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

GO
CREATE OR ALTER PROCEDURE cons.UDP_tbEmpleados_Delete
	@empe_Id				INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM cons.tbEmpleados WHERE empe_Id = @empe_Id)
			BEGIN
				SELECT 'El registro que intenta eliminar no existe'
			END
		ELSE
			UPDATE cons.tbEmpleados
			SET empe_Estado = 0
			WHERE empe_Id = @empe_Id

			SELECT 'El registro ha sido eliminado con �xito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

GO
CREATE OR ALTER PROCEDURE cons.UDP_tbEmpleados_Find
	@empe_Id				INT
AS
BEGIN
	SELECT * FROM cons.VW_tbEmpleados WHERE empe_Id = @empe_Id
END

/*Procedimientos facturas*/
GO
CREATE OR ALTER VIEW cons.VW_tbFacturas
AS
	SELECT fact_Id, 
	       fact_Fecha, 
		   T1.paci_Id, 
		   (T2.paci_Nombres + ' ' + T2.paci_Apellidos) AS paci_NombreCompleto,
		   T1.empe_Id, 
		   (T3.empe_Nombres + ' ' + T3.empe_Apellido) AS empe_NombreCompleto,
		   T1.meto_Id, 
		   T4.meto_Nombre,
		   fact_UsuCreacion,
		   T5.user_NombreUsuario AS fact_UsuCreacionNombre,
		   fact_FechaCreacion, 
		   T6.user_NombreUsuario AS fact_UsuModificacionNombre,
		   fact_UsuModificacion, 
		   fact_FechaModificacion, 
		   fact_Estado
FROM cons.tbFacturas T1 INNER JOIN cons.tbPacientes T2
ON T1.paci_Id = T2.paci_Id INNER JOIN cons.tbEmpleados T3
ON T1.empe_Id = T3.empe_Id INNER JOIN cons.tbMetodosPago T4
ON T1.meto_Id = T4.meto_Id INNER JOIN acce.tbUsuarios T5
ON T1.fact_UsuCreacion = T5.user_Id LEFT JOIN acce.tbUsuarios T6
ON T1.fact_UsuModificacion = T6.user_Id

GO
CREATE OR ALTER PROCEDURE cons.tbFacturas_List
AS
BEGIN
	SELECT * FROM cons.VW_tbFacturas WHERE fact_Estado = 1
END

GO
CREATE OR ALTER PROCEDURE cons.tbFacturas_Insert
	@paci_Id			INT, 
	@empe_Id			INT, 
	@meto_Id			INT, 
	@fact_UsuCreacion	INT
AS
BEGIN
	INSERT INTO [cons].[tbFacturas](fact_Fecha, paci_Id, 
									empe_Id, meto_Id, 
									fact_UsuCreacion)
	VALUES (GETDATE(), @paci_Id,
			@empe_Id, @meto_Id,
			@fact_UsuCreacion)

	SELECT SCOPE_IDENTITY()
END

--GO
--CREATE OR ALTER TRIGGER cons.trg_tbFacturasDetalles_ReducirStock
--ON cons.tbFacturasDetalles
--AFTER INSERT
--AS
--BEGIN
--	UPDATE cons.tbMedicamentos
--	SET [medi_Stock] = [medi_Stock] - (SELECT [factdeta_Cantidad] FROM inserted)
--	WHERE [medi_Id] = (SELECT [medi_Id] FROM inserted)
--END

--GO
--CREATE OR ALTER TRIGGER cons.trg_tbFacturasDetalles_AumentarStock
--ON cons.tbFacturasDetalles
--AFTER DELETE
--AS
--BEGIN
--	UPDATE cons.tbMedicamentos
--	SET [medi_Stock] = [medi_Stock] + (SELECT [factdeta_Cantidad] FROM deleted)
--	WHERE [medi_Id] = (SELECT [medi_Id] FROM deleted)
--END

--Vista masiva para facturas y facturas detalles
GO
CREATE OR ALTER VIEW cons.VW_tbFacturas_tbFacturasDetalles
AS
SELECT T1.fact_Id, 
	   fact_Fecha, 
	   T1.paci_Id, 
	   T1.empe_Id, 
	   meto_Id, 
	   fact_UsuCreacion, 
	   fact_FechaCreacion, 
	   fact_UsuModificacion, 
	   fact_FechaModificacion, 
	   fact_Estado,
	   factdeta_Id, 
	   T2.cons_Id, 
	   T3.cons_Costo,
	   (CONVERT(varchar(19), cons_Final, 120) + ' ' + T4.consltro_Nombre) AS cons_Nombre,
	   factdeta_UsuCreacion, 
	   factdeta_FechaCreacion
FROM [cons].[tbFacturas] T1 LEFT JOIN [cons].[tbFacturasDetalles] T2
ON T1.[fact_Id] = T2.[fact_Id] INNER JOIN cons.tbConsultas T3
ON T2.cons_Id = T3.cons_Id INNER JOIN cons.tbConsultorios T4
ON T3.consltro_Id = T4.consltro_Id
--UNION ALL
--SELECT T1.fact_Id, 
--	   fact_Fecha, 
--	   T1.paci_Id, 
--	   T1.empe_Id, 
--	   meto_Id, 
--	   fact_UsuCreacion, 
--	   fact_FechaCreacion, 
--	   fact_UsuModificacion, 
--	   fact_FechaModificacion, 
--	   fact_Estado,
--	   NULL AS factdeta_Id, 
--	   NULL AS cons_Id, 
--	   NULL AS cons_Costo,
--	   NULL AS cons_Nombre,
--	   NULL AS factdeta_UsuCreacion, 
--	   NULL AS factdeta_FechaCreacion
--FROM [cons].[tbFacturas] T1 
--WHERE NOT EXISTS (
--   SELECT 1 
--   FROM [cons].[tbFacturasDetalles] T5 
--   WHERE T1.[fact_Id] = T5.[fact_Id]
--)

GO 
CREATE OR ALTER PROCEDURE cons.UDP_VW_tbFacturas_tbFacturasDetalles_List
	@fact_Id		INT
AS
BEGIN
	SELECT * FROM cons.VW_tbFacturas_tbFacturasDetalles WHERE fact_Id = @fact_Id
END

GO
CREATE OR ALTER PROCEDURE cons.tbFacturasDetalles_Insert
	@fact_Id				INT, 
	@cons_Id				INT,
	@factdeta_UsuCreacion	INT
AS
BEGIN

	INSERT INTO [cons].[tbFacturasDetalles](fact_Id, 
											cons_Id, 
											factdeta_UsuCreacion, 
											factdeta_FechaCreacion)
	VALUES (@fact_Id,
			@cons_Id,
			@factdeta_UsuCreacion,
			GETDATE())
END

GO
CREATE OR ALTER PROCEDURE cons.tbFacturasDetalles_Delete
	@factdeta_Id	INT
AS
BEGIN
	DELETE 
	FROM cons.tbFacturasDetalles
	WHERE factdeta_Id = @factdeta_Id
END

GO
CREATE OR ALTER PROCEDURE cons.tbFacturasDetalles_Find 
	@fact_Id	INT
AS
BEGIN
	SELECT * FROM cons.tbFacturas WHERE fact_Id = @fact_Id
END

/*Procedimientos pantalla*/
GO 
CREATE OR ALTER PROCEDURE acce.UDP_tbPantallas_List
AS
BEGIN
	SELECT * FROM acce.tbPantallas
END

GO
CREATE OR ALTER PROCEDURE acce.UDP_tbPantallasPorRoles_Find 
	@role_Id	INT
AS
BEGIN
  SELECT T1.pant_Id, 
	     pant_Nombre, 
		 pant_Url, 
		 pant_Menu, 
		 pant_HtmlId, 
		 pant_UsuCreacion, 
		 pant_FechaCreacion,
		 (SELECT pantrole_Estado FROM [acce].[tbPantallasPorRoles] T2 WHERE T2.pant_Id = T1.pant_Id AND T2.role_Id = @role_Id) AS Seleccionada
  FROM acce.tbPantallas T1
END


/*Procedimientos roles y roles por pantalla*/
GO
CREATE OR ALTER VIEW acce.VW_tbRoles
AS
	SELECT T1.role_Id, 
		   role_Nombre, 
		   role_UsuCreacion,
		   T2.user_NombreUsuario AS role_UsuCreacionNombre,
		   role_FechaCreacion, 
		   role_UsuModificacion, 
		   T3.user_NombreUsuario AS role_UsuModificacionNombre,
		   role_FechaModificacion
	FROM [acce].[tbRoles] T1 INNER JOIN [acce].[tbUsuarios] T2
	ON T1.role_UsuCreacion = T2.user_Id LEFT JOIN [acce].[tbUsuarios] T3
	ON T1.role_UsuModificacion = T3.user_Id
	WHERE role_Estado = 1

--Listar roles
GO
CREATE OR ALTER PROCEDURE gral.UDP_tbRoles_List
AS
BEGIN
	SELECT * FROM acce.VW_tbRoles
END

--Insertar roles
GO
CREATE OR ALTER PROCEDURE gral.UDP_tbRoles_Insert
	@role_Nombre			NVARCHAR(100),
	@role_UsuCreacion	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT role_Nombre 
					   FROM acce.tbRoles 
					   WHERE role_Nombre = @role_Nombre)
			BEGIN			
				INSERT INTO acce.tbRoles(role_Nombre, role_UsuCreacion)
				VALUES(@role_Nombre, @role_UsuCreacion)

				SELECT 'El registro se ha insertado con �xito'
			END
		ELSE IF EXISTS (SELECT role_Nombre 
					    FROM acce.tbRoles 
					    WHERE role_Nombre = @role_Nombre
						AND role_Estado = 0)
			BEGIN
				UPDATE acce.tbRoles 
				SET role_Estado = 1
				WHERE role_Nombre = @role_Nombre

				SELECT 'El registro se ha insertado con �xito'
			END
		ELSE
			SELECT 'Ya existe un rol con este nombre'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Update roles
GO
CREATE OR ALTER PROCEDURE gral.UDP_tbRoles_Update
	@role_Id				INT,
	@role_Nombre			NVARCHAR(100),
	@role_UsuModificacion	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT role_Id FROM acce.tbRoles WHERE role_Id = @role_Id)
			BEGIN 
				SELECT 'El registro que intenta editar no existe'
			END
		ELSE
			BEGIN
				IF NOT EXISTS (SELECT role_Nombre 
					   FROM acce.tbRoles 
					   WHERE role_Nombre = @role_Nombre
					   AND role_Id != @role_Id)
					BEGIN
						UPDATE acce.tbRoles 
						SET role_Nombre = @role_Nombre,
							role_UsuModificacion = @role_UsuModificacion,
							role_FechaModificacion = GETDATE()
						WHERE role_Id = @role_Id

						SELECT 'El registro ha sido editado con �xito'
					END
				ELSE IF EXISTS (SELECT role_Nombre 
								FROM acce.tbRoles 
								WHERE role_Estado = 0
								AND role_Nombre = @role_Nombre)
					BEGIN
						UPDATE acce.tbRoles 
						SET role_Estado = 1
						WHERE role_Nombre = @role_Nombre

						SELECT 'El registro ha sido editado con �xito'
					END
				ELSE
					SELECT 'Ya existe un rol con este nombre'
			END
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Eliminar roles
GO
CREATE OR ALTER PROCEDURE gral.UDP_tbRoles_Delete
	@role_Id				INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT role_Id FROM acce.tbRoles  WHERE role_Id = @role_Id)
			BEGIN
				SELECT 'El registro que intenta eliminar no existe'
			END
		ELSE
			UPDATE acce.tbRoles 
			SET role_Estado = 0
			WHERE role_Id = @role_Id

			SELECT 'El registro ha sido eliminado con �xito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Insertar roles por pantalla
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbPantallasPorRoles_Insert
	@role_Nombre			NVARCHAR(100),
	@pant_Id				INT,
	@pantrole_UsuCreacion	INT
AS
BEGIN
	BEGIN TRY
		DECLARE @role_Id INT = (SELECT role_Id FROM acce.tbRoles WHERE role_Nombre = @role_Nombre)

		INSERT INTO [acce].[tbPantallasPorRoles]([role_Id], [pant_Id], [pantrole_UsuCreacion])
		VALUES (@role_Id, @pant_Id, @pantrole_UsuCreacion)

		SELECT 'Operaci�n realizada con �xito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

GO
CREATE OR ALTER PROCEDURE acce.UDP_tbPantallasPorRoles_InsertEdit
	@role_Id				INT,
	@pant_Id				INT,
	@pantrole_UsuCreacion	INT
AS
BEGIN
	BEGIN TRY

		INSERT INTO [acce].[tbPantallasPorRoles]([role_Id], [pant_Id], [pantrole_UsuCreacion])
		VALUES (@role_Id, @pant_Id, @pantrole_UsuCreacion)

		SELECT 'Operaci�n realizada con �xito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Insertar roles por pantalla edit
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbPantallasPorRoles_DeleteEdit
	@role_Id				INT,
	@pant_Id				INT
AS
BEGIN
	BEGIN TRY

		DELETE 
		FROM acce.tbPantallasPorRoles
		WHERE role_Id = @role_Id
		AND pant_Id = @pant_Id

		SELECT 'Operaci�n realizada con �xito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

--Eliminar roles por pantalla
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbPantallasPorRoles_Delete
	@role_Nombre			NVARCHAR(100),
	@pant_Id				INT
AS
BEGIN
	BEGIN TRY
		DECLARE @role_Id INT = (SELECT role_Id FROM acce.tbRoles WHERE role_Nombre = @role_Nombre)

		DELETE 
		FROM acce.tbPantallasPorRoles
		WHERE role_Id = @role_Id
		AND pant_Id = @pant_Id

		SELECT 'Operaci�n realizada con �xito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

/*DROPDOWNLISTS*/
--Estados civiles
GO
CREATE OR ALTER PROCEDURE gral.UDP_tbEstadosCiviles_List
AS
BEGIN
	SELECT [estacivi_Id], 
		   [estacivi_Nombre]
	FROM [gral].[tbEstadosCiviles]
	WHERE [estacivi_Estado] = 1
END

--Clinicas
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbClinicas_List
AS
BEGIN
	SELECT [clin_Id],
		   [clin_Nombre]
	FROM [cons].[tbClinicas]
	WHERE [clin_Estado] = 1
END

--Pacientes
GO
CREATE OR ALTER VIEW cons.VW_tbPacientes
AS
	SELECT ([paci_Nombres] + ' ' + [paci_Apellidos]) AS paci_NombreCompleto,
			paci_Id
	FROM [cons].[tbPacientes]
	WHERE [paci_Estado] = 1

GO
CREATE OR ALTER PROCEDURE cons.UDP_tbPacientes_DDL
AS
BEGIN 
	SELECT * FROM cons.VW_tbPacientes
END

--M�todos de pago
GO
CREATE OR ALTER VIEW cons.VW_tbMetodosPago
AS
	SELECT meto_Id,
		   meto_Nombre
	FROM [cons].tbMetodosPago
	WHERE meto_Estado = 1

GO
CREATE OR ALTER PROCEDURE cons.UDP_tbMetodosPago_DDL
AS
BEGIN 
	SELECT * FROM cons.VW_tbMetodosPago
END

--Medicamentos 
GO
CREATE OR ALTER VIEW cons.VW_tbMedicamentos
AS
	SELECT [medi_Id], [medi_Nombre], [medi_PrecioVenta]
	FROM [cons].[tbMedicamentos]
	WHERE [medi_Estado] = 1

GO
CREATE OR ALTER PROCEDURE cons.UDP_tbMedicamentos_DDL
AS
BEGIN
	SELECT * FROM cons.VW_tbMedicamentos
END

--Consultas
GO
CREATE OR ALTER PROCEDURE cons.UDP_tbConsultas_DDL 
AS
BEGIN
	SELECT * FROM cons.VW_tbConsultas
	WHERE cons_Id NOT IN (SELECT cons_Id FROM cons.tbFacturasDetalles)
END

GO
CREATE OR ALTER PROCEDURE cons.UDP_tbConsultas_Costo
	@cons_Id	INT
AS
BEGIN
	SELECT cons_Costo FROM cons.tbConsultas WHERE cons_Id = @cons_Id
END
GO







--**************Listar Usuarios**************--
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbUsuarios_List
AS
BEGIN
SELECT * FROM acce.VW_tbUsuarios_View
WHERE user_Estado = 1
END

--**************Editar usuarios**************--
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbUsuarios_UPDATE
	@user_Id					INT,
	@user_EsAdmin				BIT,
	@role_Id					INT,
	@empe_Id					INT,
	@user_UsuModificacion		INT
AS
BEGIN
	UPDATE acce.tbUsuarios
	SET user_EsAdmin = @user_EsAdmin,
		role_Id = @role_Id,
		empe_Id = @empe_Id,
		user_UsuModificacion = @user_UsuModificacion,
		user_FechaModificacion = GETDATE()
	WHERE user_Id = @user_Id
END

--**************Eliminar usuarios**************--
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbUsuarios_DELETE
	@user_Id	INT
AS
BEGIN
	UPDATE acce.tbUsuarios
	SET user_Estado = 0
	WHERE user_Id = @user_Id
END

GO
--**************UDP para vista de usuarios**************--
GO
CREATE OR ALTER PROCEDURE acce.UDP_tbUsuarios_Find
@user_Id INT
AS
BEGIN
SELECT * FROM acce.VW_tbUsuarios_View WHERE user_Id = @user_Id
END

--**************Vista usuarios**************--
GO
CREATE OR ALTER VIEW acce.VW_tbUsuarios_View
AS
SELECT t1.user_Id, t1.user_NombreUsuario, 
t1.user_Contrasena, t1.user_EsAdmin, 
t1.role_Id,t2.role_Nombre, t1.empe_Id,(SELECT t3.empe_Nombres + ' '+ empe_Apellido) AS empe_NombreCompleto, 
t1.user_UsuCreacion, t4.user_NombreUsuario AS user_UsuCreacion_Nombre,t1.user_FechaCreacion, 
t1.user_UsuModificacion,t5.user_NombreUsuario AS user_UsuModificacion_Nombre, t1.user_FechaModificacion, 
t1.user_Estado FROM acce.tbUsuarios t1 INNER JOIN acce.tbRoles t2
ON t1.role_Id = t2.role_Id
INNER JOIN cons.tbEmpleados t3
ON t3.empe_Id = t1.empe_Id 
INNER JOIN acce.tbUsuarios t4
ON t1.user_UsuCreacion = T4.user_Id
LEFT JOIN acce.tbUsuarios t5
ON t1.user_UsuModificacion = t5.user_Id

--************INICIAR SESI�N******************--
--************Cambiar Contrasena*******************--
GO
CREATE OR ALTER PROCEDURE UDP_RecuperarContrasena
	@user_NombreUsuario	NVARCHAR(100),
	@user_Contrasena	NVARCHAR(100)
AS
BEGIN
	DECLARE @user_ContrasenaEncript NVARCHAR(MAX) = HASHBYTES('SHA2_512', @user_Contrasena)
	IF EXISTS (SELECT user_NombreUsuario FROM acce.tbUsuarios WHERE user_NombreUsuario = @user_NombreUsuario)
	BEGIN
	UPDATE acce.tbUsuarios 
	SET user_Contrasena = @user_ContrasenaEncript
	WHERE user_NombreUsuario = @user_NombreUsuario
	SELECT 1
	END
	ELSE
	BEGIN
	SELECT 0
	END
END

--**************Login**************--
GO
CREATE OR ALTER PROCEDURE UDP_Login
	@user_NombreUsuario	NVARCHAR(100),
	@user_Contrasena	NVARCHAR(100)
AS
BEGIN
	DECLARE @user_ContrasenaEncript NVARCHAR(MAX) = HASHBYTES('SHA2_512', @user_Contrasena)

	SELECT user_NombreUsuario,[empe_Nombres], [empe_Apellido], [role_Id], [user_id],user_EsAdmin,t1.empe_Id
	FROM [acce].[tbUsuarios] T1 INNER JOIN [cons].[tbEmpleados] T2
	ON T1.empe_Id = T2.empe_Id
	WHERE [user_NombreUsuario] = @user_NombreUsuario
	AND [user_Contrasena] = @user_ContrasenaEncript
END
