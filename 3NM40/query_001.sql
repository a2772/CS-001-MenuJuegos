/*If(db_id(N't0') IS NULL)
	CREATE DATABASE t0;*/
go
	use master;
go
	If(db_id(N'dbAlgoritmos') IS NOT NULL)
	DROP DATABASE dbAlgoritmos;
GO
	CREATE DATABASE dbAlgoritmos;
GO
	USE dbAlgoritmos;
GO
	--Catálogos
	create table catPerfiles(
		idTipoUser int identity primary key,
		tipoUser nvarchar(24) not null
	);
	create table catEntFed(
		idEntFed int identity primary key,
		entFed nvarchar(24) not null,
		cve nvarchar(2) unique
	);
	create table catMenu(
		idMenu int identity primary key,
		menu nvarchar(11) not null
	);
	create table catJuegos(
		idJuego int identity primary key,
		juego nvarchar(28) not null,--Breakout from the Atari 2600; Pacman;
		idMenu int foreign key references catMenu(idMenu)
	);
	create table catActividades(
		idActividad int identity primary key,
		actividad nvarchar(19) not null,
		idMenu int foreign key references catMenu(idMenu)
	);
	create table catSexos(
		idSexo int identity primary key,
		sexo nvarchar(6) not null
	);
GO
	--Tablas
	create table tbPasswords(--Tabla de passwords o de usuarios
		idPassword int identity primary key,
		usrName nvarchar(18) unique, --CURP
		passwd nvarchar(128) not null, --password mínimo de 4, máximo de 20. 128 de tamaño para que quepa la encripación
		fechaNac date not null,
		foto varbinary(max),
		idSexo int foreign key references catSexos(idSexo),
		idTipoUser int foreign key references catPerfiles(idTipoUser)
	);
	create table tbLadderboard(
		idPuntaje int identity primary key,
		puntaje int not null,
		alias nvarchar(50) not null,
		fecha smalldatetime not null, --Fecha en la que se registró la puntuación hasta segundos: https://www.sqlshack.com/es/funciones-y-formatos-de-sql-convert-date/
		idPassword int foreign key references tbPasswords(idPassword),
		idJuego int foreign key references catJuegos(idJuego)
	);
GO
	--insercciones catálogos
	insert into catSexos(sexo) values ('Hombre'),('Mujer'),('Otro');
	insert into catEntFed(entFed,cve) values ('AGUASCALIENTES','AS'),('BAJA CALIFORNIA','BC'),('BAJA CALIFORNIA SUR','BS'),('CAMPECHE','CC'),('COAHUILA','CL'),('COLIMA','CM'),('CHIAPAS','CS'),('CHIHUAHUA','CH'),('DISTRITO FEDERAL / CDMX','DF'),('DURANGO','DG'),('GUANAJUATO','GT'),('GUERRERO','GR'),('HIDALGO','HG'),('JALISCO','JC'),('ESTADO DE MEXICO','MC'),('MICHOACAN','MN'),('MORELOS','MS'),('NAYARIT','NT'),('NUEVO LEON','NL'),('OAXACA','OC'),('PUEBLA','PL'),('QUERETARO','QT'),('QUINTANA ROO','QR'),('SAN LUIS POTOSI','SP'),('SINALOA','SL'),('SONORA','SR'),('TABASCO','TC'),('TAMAULIPAS','TS'),('TLAXCALA','TL'),('VERACRUZ','VZ'),('YUCATAN','YN'),('ZACATECAS','ZS'),('NACIDO EN EL EXTRANJERO','NE');
	insert into catMenu(menu) values ('Juego'),('Actvidad');
	insert into catPerfiles(tipoUser) values ('Administrador'),('Administrador Secundario'),('Jugador');
	insert into catJuegos(juego,idMenu) values ('Pacman',1),('Submarino 3D',1);
	insert into catActividades(actividad,idMenu) values ('El Caballo Loko',2);
/**//**//**/
GO --LLenado ddls
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spFillEntFed') AND type in (N'P', N'PC'))Drop Procedure spFillEntFed
		Go 
			CREATE PROCEDURE spFillEntFed AS BEGIN SET NOCOUNT ON;
			begin select idEntFed,entFed from catEntFed order by idEntFed end END
GO
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spFillJuegos') AND type in (N'P', N'PC'))Drop Procedure spFillJuegos
		Go 
			CREATE PROCEDURE spFillJuegos AS BEGIN SET NOCOUNT ON;
			begin select idJuego,juego from catJuegos order by idJuego end END
GO
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spFillActividades') AND type in (N'P', N'PC'))Drop Procedure spFillActividades
		Go 
			CREATE PROCEDURE spFillActividades AS BEGIN SET NOCOUNT ON;
			begin select idActividad,actividad from catActividades order by idActividad end END
GO
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spFillMenu') AND type in (N'P', N'PC'))Drop Procedure spFillMenu
		Go 
			CREATE PROCEDURE spFillMenu AS BEGIN SET NOCOUNT ON;
			begin select idMenu,menu from catMenu order by idMenu end END
GO
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spFillSexos') AND type in (N'P', N'PC'))Drop Procedure spFillSexos
		Go 
			CREATE PROCEDURE spFillSexos AS BEGIN SET NOCOUNT ON;
			begin select idSexo,sexo from catSexos order by idSexo end END
--Consultas para llenado de tablas de los scores, consultas del admin, etc
GO--Opciones de administrador
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'sp_SignUp') AND type in (N'P', N'PC')) Drop Procedure sp_SignUp
		Go
			CREATE PROCEDURE sp_SignUp
			@Cuenta nvarchar (150),
			@Passwd nvarchar(20),
			@Nacimiento date,
			@Foto varbinary(max),
			@Sexo int,--Como se obtiene de una DDlist se obtiene la id
			@TipoUsr int
		AS
		BEGIN SET NOCOUNT ON;
			begin insert into tbPasswords(usrName,passwd,fechaNac,foto,idSexo,idTipoUser) values (@Cuenta,ENCRYPTBYPASSPHRASE('pass',@Passwd),@Nacimiento,@Foto,@Sexo,@TipoUsr); end
		END
GO--Realiza el login devolviendo el tipo de usuario como int
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'sp_Login') AND type in (N'P', N'PC')) Drop Procedure sp_Login
		Go
			create procedure sp_Login
			@Cuenta nvarchar(18),
			@Pass nvarchar(128),
			@Result int Output
		AS
		BEGIN SET NOCOUNT ON;
			Declare @PassEncode as nvarchar(128)
			Declare @PassDecode as nvarchar(128)
			Declare @Idperfil as int
			Declare @ID as int
			begin
				select @ID = idPassword from tbPasswords where usrName = @Cuenta;
			end
			begin 
				select @PassEncode = passwd from tbPasswords where idPassword=@ID
			end	
			begin
				Set @PassDecode = CAST(DECRYPTBYPASSPHRASE('pass',@PassEncode) AS nvarchar(MAX)) 
			end
			begin 
				if @PassDecode COLLATE Latin1_General_CS_AS = @Pass
					select @Idperfil = idTipoUser from tbPasswords where usrName = @Cuenta 
				else Set @Idperfil = 0
			end
			begin 
				set @Result=@Idperfil 
			end
		END
GO--Devuelve la clave de la entidad federativa dada su id
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spGetEntFedCve') AND type in (N'P', N'PC')) Drop Procedure spGetEntFedCve
		Go
			create procedure spGetEntFedCve
			@idEntidad int,
			@CveEntidad nvarchar(2) Output
		AS
		BEGIN SET NOCOUNT ON;
			Declare @entity as nvarchar(2)
			begin
				select @entity = cve from catEntFed where idEntFed = @idEntidad;
			end
			begin 
				set @CveEntidad=@entity 
			end
		END
GO--Devuelve todos los datos del usuario por su CURP (aunque no todos los mostremos)
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spGetUsr') AND type in (N'P', N'PC')) Drop Procedure spGetUsr
		Go
			create procedure spGetUsr
			@usrName nvarchar(18),
			@passwd nvarchar(20) Output,/*Enviamos desencriptado*/
			@fechaNac date Output,
			@idPasswd int Output,
			@idSexo int Output,
			@idTipoUser int Output
		AS
		BEGIN SET NOCOUNT ON;
			Declare @PassEncode as nvarchar(128)
			Declare @PassDecode as nvarchar(128)
			Declare @ID as int
			/*
			begin
				select @ID = idPassword from tbPasswords where usrName = @usrName;
			end
			*/
			begin select @ID = idPassword from tbPasswords where usrName = @usrName end
			begin select @PassEncode = passwd from tbPasswords where idPassword=@ID end	
			begin Set @PassDecode = CAST(DECRYPTBYPASSPHRASE('pass',@PassEncode) AS nvarchar(MAX)) COLLATE Latin1_General_CS_AS end
			begin Set @passwd = @PassDecode end
			begin select @fechaNac = fechaNac from tbPasswords where idPassword=@ID end
			begin select @idPasswd = @ID end
			begin select @idSexo = idSexo from tbPasswords where idPassword=@ID end
			begin select @idTipoUser = idTipoUser from tbPasswords where idPassword=@ID end
		END
GO--Obtenemos la foto con la ID
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'getFotoById') AND type in (N'P', N'PC')) Drop Procedure getFotoById
		Go
			create procedure getFotoById
			@idPasswd int,
			@foto varbinary(max) Output
		AS
		BEGIN SET NOCOUNT ON;
			begin
				select @foto = foto from tbPasswords where idPassword = @idPasswd;
			end
		END
GO--Obtenemos cada puntuación de un usuario en la ladderboard
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'getPunctTotal') AND type in (N'P', N'PC')) Drop Procedure getPunctTotal
		Go
			create procedure getPunctTotal
			@idPasswd int,
			@puntos int Output
		AS
		BEGIN SET NOCOUNT ON;
			begin
				select @puntos = sum(puntaje) from tbLadderboard where idPassword = @idPasswd;
			end
		END
GO--Obtenemos cada puntuación de un usuario en la ladderboard
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'updtFoto') AND type in (N'P', N'PC')) Drop Procedure updtFoto
		Go
			create procedure updtFoto
			@idPasswd int,
			@foto varbinary(max)
		AS
		BEGIN SET NOCOUNT ON;
			begin
				update tbPasswords set foto = @foto where idPassword = @idPasswd;
			end
		END
GO--Consulta para scores
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spSelScore') AND type in (N'P', N'PC')) Drop Procedure spSelScore
		Go
			CREATE PROCEDURE spSelScore
		AS
		BEGIN SET NOCOUNT ON;
			begin
				select tLdb.puntaje 'Puntuación', tLdb.fecha 'Fecha', tPsw.usrName 'Clave del Jugador', tLdb.alias 'Nickname' from tbPasswords tPsw, tbLadderboard tLdb where tPsw.idPassword = tLdb.idPassword;
			end
		END
GO--Verifica si hay puntuacion almacenada
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spIsAPunct') AND type in (N'P', N'PC')) Drop Procedure spIsAPunct
		Go
			CREATE PROCEDURE spIsAPunct
			@idJuego int,
			@usrName nvarchar(150),
			@exist int output
		AS
		BEGIN SET NOCOUNT ON;
			Declare @idPasswd as int
			Declare @ex as int
			begin set @ex=0 end
			begin select @idPasswd = idPassword from tbPasswords where usrName = @usrName end
			begin select @ex = idPuntaje from tbLadderboard where @idJuego=idJuego and idPassword=@idPasswd end
			begin set @exist=@ex end
		END
GO--Inserta puntuación
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spSetScore') AND type in (N'P', N'PC')) Drop Procedure spSetScore
		Go
			CREATE PROCEDURE spSetScore
			@idJuego int,
			@fecha date,
			@usrName nvarchar(150),
			@puntaje int
		AS
		BEGIN SET NOCOUNT ON;
			Declare @idPasswd as int
			begin select @idPasswd = idPassword from tbPasswords where usrName = @usrName end
			begin
				begin insert into tbLadderboard(puntaje,alias,fecha,idPassword,idJuego) values (@puntaje, @usrName,@fecha,@idPasswd, @idJuego); end
			end
		END
GO--Actualiza puntuación
	if Exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'spUpdScore') AND type in (N'P', N'PC')) Drop Procedure spUpdScore
		Go
			CREATE PROCEDURE spUpdScore
			@idJuego int,
			@fecha date,
			@usrName nvarchar(150),
			@puntaje int
		AS
		BEGIN SET NOCOUNT ON;
			Declare @idPasswd as int
			Declare @puntajeActual as int
			begin select @idPasswd = idPassword from tbPasswords where usrName = @usrName end
			begin select @puntajeActual = puntaje from tbLadderboard where idPassword=@idPasswd and idJuego=@idJuego end
			if @puntaje >= @puntajeActual begin
				begin
					begin update tbLadderboard set puntaje=@puntaje,fecha=@fecha where idPassword=@idPasswd and idJuego=@idJuego; end
				end
			end
		END
GO
	--insercciones tablas
	exec sp_SignUp 'ADMIN','admin','2000-01-01',null,1,1;
GO
	select * from catPerfiles;
	select * from catEntFed;
	select * from catMenu;
	select * from catJuegos;
	select * from catActividades;
	select * from catSexos;
	select * from tbPasswords;
	select * from tbLadderboard;