USE [GD1C2019]
CREATE TABLE [LOS_QUERY].[Modelo](
	ID int IDENTITY(1, 1) PRIMARY KEY not null,
	MARCA int references LOS_QUERY.Marca(ID),
	NOMBRE varchar(255) not null unique,
) 
GO