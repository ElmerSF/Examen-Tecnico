USE [MaestroDetalle]
GO
/****** Object:  User [ElmerUNED]    Script Date: 8/9/2021 1:05:36:p. m. ******/
CREATE USER [ElmerUNED] FOR LOGIN [ElmerUNED] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[detallado]    Script Date: 8/9/2021 1:05:36:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detallado](
	[id_detalle] [int] IDENTITY(1,1) NOT NULL,
	[factura] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [int] NULL,
	[cantidad] [int] NULL,
	[subtotal] [int] NULL,
 CONSTRAINT [PK_detallado] PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 8/9/2021 1:05:36:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[fecha] [date] NULL,
	[total] [int] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[detallado] ON 

INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (2, 3, N'azucar', 3000, 1, 3000)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (11, 6, N'zapatso', 362, 20, 7240)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (12, 6, N'mortadela', 750, 15, 11250)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (14, 7, N'panes', 100, 1, 100)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (15, 8, N'caramelo', 30, 40, 1200)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (16, 9, N'mandarinas', 30, 80, 2400)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (17, 9, N'Peras', 3, 1000, 3000)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (18, 10, N'Macarrones', 1250, 1, 1250)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (19, 10, N'Salsa', 650, 2, 1300)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (20, 10, N'Jugos', 2500, 2, 5000)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (21, 11, N'pera', 50, 3, 150)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (22, 12, N'mani', 500, 3, 1500)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (23, 12, N'almendras', 1250, 1, 1250)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (24, 12, N'cocoa', 750, 3, 2250)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (25, 13, N'madera', 4500, 1, 4500)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (27, 14, N'CAFE', 2350, 1, 2350)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (29, 15, N'camisa', 10500, 1, 10500)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (31, 16, N'Camisa', 1000, 3, 3000)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (32, 16, N'tenis', 80000, 1, 80000)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (33, 17, N'arroz', 1250, 3, 3750)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (34, 17, N'Sal', 800, 2, 1600)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (35, 17, N'Macarrones', 1250, 1, 1250)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (37, 19, N'Libro', 6810, 1, 6810)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (38, 18, N'Cereal', 2000, 2, 4000)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (39, 18, N'papitas', 100, 5, 500)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (40, 24, N'papitas', 100, 5, 500)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (41, 25, N'papitas', 100, 5, 500)
INSERT [dbo].[detallado] ([id_detalle], [factura], [descripcion], [precio], [cantidad], [subtotal]) VALUES (42, 32, N'Galletas Soda', 1500, 3, 4500)
SET IDENTITY_INSERT [dbo].[detallado] OFF
GO
SET IDENTITY_INSERT [dbo].[Factura] ON 

INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (3, N'Heisel', CAST(N'2021-09-02' AS Date), 3000)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (4, N'Mary', CAST(N'2021-09-03' AS Date), 0)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (5, N'Manolo', CAST(N'2021-09-03' AS Date), 0)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (6, N'paco', CAST(N'2021-09-03' AS Date), 7240)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (7, N'Maria', CAST(N'2021-09-03' AS Date), 100)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (8, N'Juana', CAST(N'2021-09-03' AS Date), 1200)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (9, N'Marcos', CAST(N'2021-09-03' AS Date), 2400)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (10, N'Marco', CAST(N'2021-09-03' AS Date), 1250)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (11, N'ricarso', CAST(N'2021-09-03' AS Date), 150)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (12, N'pepe', CAST(N'2021-09-03' AS Date), 1500)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (13, N'katia', CAST(N'2021-09-03' AS Date), 4500)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (14, N'marco vinicio', CAST(N'2021-09-03' AS Date), 2350)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (15, N'Camila', CAST(N'2021-09-03' AS Date), 10500)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (16, N'Juana', CAST(N'2021-09-04' AS Date), 83000)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (17, N'Pedro', CAST(N'2021-09-04' AS Date), 6600)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (18, N'Juana la cubana', CAST(N'2021-09-04' AS Date), 4500)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (19, N'Veronica', CAST(N'2021-09-04' AS Date), 6810)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (20, N'Maria', CAST(N'2021-09-05' AS Date), 5000)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (21, N'Marcos', CAST(N'2021-09-05' AS Date), 830)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (22, N'Maria', CAST(N'2021-09-05' AS Date), 5410)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (23, N'Carlos', CAST(N'2021-09-05' AS Date), 280)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (24, N'minor', CAST(N'2021-09-05' AS Date), 4500)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (25, N'uno', CAST(N'2021-09-05' AS Date), 50)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (26, N'carlos', CAST(N'2021-09-05' AS Date), 34400)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (27, N'mario', CAST(N'2021-09-05' AS Date), 510)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (28, N'pepe', CAST(N'2021-09-05' AS Date), 6)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (29, N'Marcos Alicea', CAST(N'2021-09-05' AS Date), 6)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (30, N'Damarys', CAST(N'2021-09-05' AS Date), 1420)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (31, N'Carmen Garcia', CAST(N'2021-09-05' AS Date), 3)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (32, N'Manuel Maria', CAST(N'2021-09-06' AS Date), 7500)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (33, N'Carlos', CAST(N'2021-09-07' AS Date), 5200)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (34, N'Alejandro', CAST(N'2021-09-07' AS Date), 13400)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (35, N'Maria Fernanda', CAST(N'2021-09-07' AS Date), 2320)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (36, N'Damarys', CAST(N'2021-09-07' AS Date), 18320)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (37, N'Pedro', CAST(N'2021-09-07' AS Date), 13200)
INSERT [dbo].[Factura] ([id_factura], [nombre], [fecha], [total]) VALUES (38, N'Ricardo', CAST(N'2021-09-07' AS Date), 30000)
SET IDENTITY_INSERT [dbo].[Factura] OFF
GO
ALTER TABLE [dbo].[detallado]  WITH CHECK ADD  CONSTRAINT [FK_detallado_Factura] FOREIGN KEY([factura])
REFERENCES [dbo].[Factura] ([id_factura])
GO
ALTER TABLE [dbo].[detallado] CHECK CONSTRAINT [FK_detallado_Factura]
GO
/****** Object:  StoredProcedure [dbo].[ActualizaTotal]    Script Date: 8/9/2021 1:05:37:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizaTotal] 
	 @fact int
AS

BEGIN


update Factura set total =(select sum(detallado.subtotal) 
	as 'suma' from detallado where factura =@fact) where id_factura =@fact;
END
GO
/****** Object:  StoredProcedure [dbo].[Borra_Detalle]    Script Date: 8/9/2021 1:05:37:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Elmer Salazar>
-- Create date: <Septiembre de 2021>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Borra_Detalle] 
	-- parametros
	@factura int,
	@descripcion varchar(50),
	@precio int,
	@cantidad int

AS

BEGIN
	-- Los query a realizar
	declare @resultado int; --declaramos una variable donde almacenamos el resultado del query
	
	--obtenemos el id de line del detalle
	set @resultado = (select id_detalle from detallado 
	where (factura=@factura and descripcion=@descripcion and precio=@precio and cantidad=@cantidad));

	--borramos utilizando el id de la linea
	delete from detallado where id_detalle = @resultado;

	--actualizamos el encabezado de la factura con el nuevo valor total

	update Factura set total =(select sum(detallado.subtotal) 
	as 'suma' from detallado where factura =@factura) where id_factura =@factura;

END
GO
/****** Object:  StoredProcedure [dbo].[Cambio_nombre_cliente]    Script Date: 8/9/2021 1:05:37:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Elmer Salazar>
-- Create date: <Septiembre 2021>
-- Description:	<Actualiza el nombre de una factura en particular>
-- =============================================
CREATE PROCEDURE [dbo].[Cambio_nombre_cliente] 
	@nombre varchar (50),
	@factura int
AS
BEGIN
--se realiza la actualización de la tabla con el valor indicado en el registro señalado
	update Factura set nombre=@nombre where id_factura =@factura;
END
GO
