USE [GD1C2019]
CREATE TABLE [LOS_QUERY].[Marca](
	ID int IDENTITY(1, 1) PRIMARY KEY not null,
	NOMBRE varchar(255) not null unique,
) 
GO