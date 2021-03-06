USE [GestionParqueadero]
GO
/****** Object:  Table [dbo].[CAJA]    Script Date: 23/6/2022 17:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAJA](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_registro] [numeric](18, 0) NOT NULL,
	[fecha] [smalldatetime] NULL,
	[id_cliente] [nvarchar](20) NOT NULL,
	[valor] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_CAJA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 23/6/2022 17:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[id] [nvarchar](20) NOT NULL,
	[nombres] [nvarchar](50) NOT NULL,
	[apellidos] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](250) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[email] [nchar](50) NULL,
 CONSTRAINT [PK_CLIENTE_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[REGISTRO]    Script Date: 23/6/2022 17:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REGISTRO](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[fecha_entrada] [smalldatetime] NOT NULL,
	[fecha_salida] [smalldatetime] NOT NULL,
	[placa] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_REGISTRO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 23/6/2022 17:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](30) NOT NULL,
	[clave] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VEHICULO]    Script Date: 23/6/2022 17:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VEHICULO](
	[placa] [nvarchar](15) NOT NULL,
	[marca] [nvarchar](50) NULL,
	[modelo] [nvarchar](50) NULL,
	[color] [nvarchar](50) NULL,
	[tipo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CAJA] ADD  CONSTRAINT [DF_CAJA_fecha]  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[CAJA]  WITH CHECK ADD  CONSTRAINT [FK_CAJA_CLIENTE] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[CLIENTE] ([id])
GO
ALTER TABLE [dbo].[CAJA] CHECK CONSTRAINT [FK_CAJA_CLIENTE]
GO
ALTER TABLE [dbo].[CAJA]  WITH CHECK ADD  CONSTRAINT [FK_CAJA_REGISTRO] FOREIGN KEY([id_registro])
REFERENCES [dbo].[REGISTRO] ([id])
GO
ALTER TABLE [dbo].[CAJA] CHECK CONSTRAINT [FK_CAJA_REGISTRO]
GO
ALTER TABLE [dbo].[REGISTRO]  WITH CHECK ADD  CONSTRAINT [FK_REGISTRO_VEHICULO1] FOREIGN KEY([placa])
REFERENCES [dbo].[VEHICULO] ([placa])
GO
ALTER TABLE [dbo].[REGISTRO] CHECK CONSTRAINT [FK_REGISTRO_VEHICULO1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'clave primaria de la tabla, representa el numero de la placa del vehiculo sin espacios ni caracteres especiales: Eemplo: PCD5986' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VEHICULO', @level2type=N'COLUMN',@level2name=N'placa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca del Vehiculo ejemplo Hyundai' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VEHICULO', @level2type=N'COLUMN',@level2name=N'marca'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Representa el modelo del vehiculo . Ejemplo: Accent' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VEHICULO', @level2type=N'COLUMN',@level2name=N'modelo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Color del vehiculo. Ejemplo: Rojo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VEHICULO', @level2type=N'COLUMN',@level2name=N'color'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica el tipo de vehiculo, ejemplo: automovil, camion, jeep, etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VEHICULO', @level2type=N'COLUMN',@level2name=N'tipo'
GO
