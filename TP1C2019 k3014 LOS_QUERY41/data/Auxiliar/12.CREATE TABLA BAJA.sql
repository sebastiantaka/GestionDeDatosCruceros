USE [GD1C2019]
CREATE TABLE [LOS_QUERY].[Baja](
	ID int IDENTITY(1, 1) PRIMARY KEY not null,
	TIPO_BAJA int references LOS_QUERY.TipoBaja(ID),
	CRUCERO int references LOS_QUERY.Crucero(ID),
	FECHA_BAJA date,
	FECHA_REINICIO date
) 
GO
