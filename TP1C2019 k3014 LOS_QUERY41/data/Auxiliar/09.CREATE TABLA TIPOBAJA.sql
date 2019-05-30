USE [GD1C2019]
CREATE TABLE [LOS_QUERY].[TipoBaja](
	ID int IDENTITY(1, 1) PRIMARY KEY not null,
	DESCRIPCION varchar(255) not null unique,
) 
GO