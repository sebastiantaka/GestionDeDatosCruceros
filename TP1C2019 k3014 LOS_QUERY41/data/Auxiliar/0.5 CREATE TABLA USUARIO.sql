USE [GD1C2019]
CREATE TABLE [LOS_QUERY].[Usuario](
	ID int IDENTITY(1, 1) PRIMARY KEY not null,
	USERNAME varchar(255) not null unique,
	PASS char(64),
	ROL_ID int REFERENCES LOS_QUERY.Rol not null,
	CANTIDAD_INTENTOS smallint default 0,
	ACTIVO bit default 1
) 
GO
