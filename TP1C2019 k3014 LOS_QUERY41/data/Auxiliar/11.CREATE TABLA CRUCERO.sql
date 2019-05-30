USE [GD1C2019]
CREATE TABLE [LOS_QUERY].[Crucero](
	ID int IDENTITY(1, 1) PRIMARY KEY not null,
	FECHA_ALTA date,
	MODELO int references LOS_QUERY.Modelo(ID),
	FABRICANTE int references LOS_QUERY.Fabricante(ID),
	TIPO_SERVICIO int references LOS_QUERY.TipoServicio(ID)
) 
GO