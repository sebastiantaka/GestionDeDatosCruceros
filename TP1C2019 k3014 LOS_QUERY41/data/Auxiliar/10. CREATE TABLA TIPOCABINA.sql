USE [GD1C2019]
CREATE TABLE [LOS_QUERY].[TipoCabina](
	ID int IDENTITY(1, 1) PRIMARY KEY not null,
	NOMBRE varchar(255) not null unique,
	PORC_RECARGO numeric(10,2) not null
) 
GO

