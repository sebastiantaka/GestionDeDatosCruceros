USE [GD1C2019]
CREATE TABLE [LOS_QUERY].[Cabina](
	ID int IDENTITY(1, 1) PRIMARY KEY not null,
	NRO int,
	PISO int,
	TIPO int references LOS_QUERY.TipoCabina(ID),
	CRUCERO int references LOS_QUERY.Crucero(ID)
) 
GO
