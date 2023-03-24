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

--********TABLA ÁREAS****************---
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
	   ('Unión Libre', 1)

GO
INSERT INTO cons.tbCargos(carg_Nombre, carg_UsuCreacion)
VALUES ('Médico general', 1),
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
VALUES ('Anestesiología', 1, GETDATE(), NULL, NULL, 1),
       ('Cardiología', 1, GETDATE(), NULL, NULL, 1),
       ('Cuidados Intensivos', 1, GETDATE(), NULL, NULL, 1),
       ('Ginecología', 1, GETDATE(), NULL, NULL, 1),
       ('Dermatología', 1, GETDATE(), NULL, NULL, 1),
       ('Traumatología', 1, GETDATE(), NULL, NULL, 1),
       ('Farmacia', 1, GETDATE(), NULL, NULL, 1),
       ('Medicina Preventiva', 1, GETDATE(), NULL, NULL, 1),
       ('Radiodiagnóstico', 1, GETDATE(), NULL, NULL, 1),
       ('Laboratorio Clínico', 1, GETDATE(), NULL, NULL, 1);

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
			('Tanque de Oxígeno', 3, 1500.00, 2120.50, 150, 1, GETDATE(), NULL, NULL, 1)

--********TABLA CLÍNICAS****************---
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
VALUES ('Los Andes', '0501', 'Residencial Los Andes, calle no sé avenida peor', 1, 1),
		('Los Castaños', '0501', 'Barrio Los Cedros, 2da avenida, 3ra calle', 1, 1),
		('Centro Cáceres', '0703', 'Los Castaños, 8va avenida, 6ta calle', 1, 1),
		('Centro Enmanuel', '0401', 'Barrio Los Cedros, 2da avenida, 3ra calle', 1, 1),
		('Climedenti', '0903', 'Plaza Alicía, 4ta avenida, 5ta calle', 1, 1),
		('Clínica Médica San Isidro', '0903', 'Residencial Salamanca, 4ta avenida, 31 calle', 1, 1),
		('Honduras Medical Center', '1205', 'Mall Las Cascadas, 4ta avenida, 12va calle', 1, 1),
		('Torre Médica Zafiro', '1205', 'Avenida los Proceres, 20va avenida, 1era calle', 1, 1)

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
		('Fernando','Castañeda','0902250500728','M',1,'2001-02-04','0902','Calle las Brisas','87756952','fernandocastañeda1@gmail.com','2023-07-02',NULL,1,1,1),
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
VALUES ('Tarjeta de crédito', 1, GETDATE(), NULL, NULL, 1)

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

CREATE TABLE cons.tbFacturasDetalles(
	factdeta_Id					INT IDENTITY,
	fact_Id						INT NOT NULL,
	cons_Id						INT NOT NULL,
	medi_Id						INT NOT NULL,
	factdeta_Precio				DECIMAL(18,2),
	factdeta_Cantidad			INT NOT NULL,
	factdeta_UsuCreacion		INT NOT NULL,
	factdeta_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_factdeta_FechaCreacion DEFAULT(GETDATE()),
	factdeta_UsuModificacion	INT,
	factdeta_FechaModificacion	DATETIME,
	factdeta_Estado				BIT NOT NULL CONSTRAINT DF_factdeta_Estado DEFAULT(1)

	CONSTRAINT PK_tbFacturasDetalles_factdeta_Id									PRIMARY KEY(factdeta_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbUsuarios_factdeta_UsuCreacion_user_Id		FOREIGN KEY(factdeta_UsuCreacion)	   REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbUsuarios_factdeta_UsuModificacion_user_Id	FOREIGN KEY(factdeta_UsuModificacion)  REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbFacturas_fact_Id								FOREIGN KEY(fact_Id)				   REFERENCES cons.tbFacturas(fact_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbConsultas_cons_Id							FOREIGN KEY(cons_Id)				   REFERENCES cons.tbConsultas(cons_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbMedicamentos_medi_Id							FOREIGN KEY(medi_Id)			       REFERENCES cons.tbMedicamentos(medi_Id)
);

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

			SELECT 'El registro ha sido eliminado con éxito'
	END TRY
	BEGIN CATCH
		SELECT 'Ha ocurrido un error'
	END CATCH
END

/*Procedimientos de consultas*/

--Vista consultas
GO
CREATE OR ALTER VIEW cons.VW_tbConsultas
AS
	SELECT [cons_Id], 
		   [cons_Inicio], 
		   [cons_Final], 
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