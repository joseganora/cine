USE [master]
GO
/****** Object:  Database [CINE_TPI]    Script Date: 23/11/2017 2:58:26 ******/
CREATE DATABASE [CINE_TPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CINE_TPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CINE_TPI.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CINE_TPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CINE_TPI_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CINE_TPI] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CINE_TPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CINE_TPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CINE_TPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CINE_TPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CINE_TPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CINE_TPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [CINE_TPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CINE_TPI] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CINE_TPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CINE_TPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CINE_TPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CINE_TPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CINE_TPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CINE_TPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CINE_TPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CINE_TPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CINE_TPI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CINE_TPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CINE_TPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CINE_TPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CINE_TPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CINE_TPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CINE_TPI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CINE_TPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CINE_TPI] SET RECOVERY FULL 
GO
ALTER DATABASE [CINE_TPI] SET  MULTI_USER 
GO
ALTER DATABASE [CINE_TPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CINE_TPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CINE_TPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CINE_TPI] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CINE_TPI', N'ON'
GO
USE [CINE_TPI]
GO
/****** Object:  User [grupo]    Script Date: 23/11/2017 2:58:26 ******/
CREATE USER [grupo] FOR LOGIN [grupo] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Actores]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actores](
	[cod_actor] [int] NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[apellido] [varchar](45) NOT NULL,
 CONSTRAINT [Actores_pk] PRIMARY KEY CLUSTERED 
(
	[cod_actor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[actores_peliculas]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[actores_peliculas](
	[cod_pelicula] [int] NOT NULL,
	[cod_actor] [int] NOT NULL,
 CONSTRAINT [actores_peliculas_pk] PRIMARY KEY CLUSTERED 
(
	[cod_pelicula] ASC,
	[cod_actor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Audios]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Audios](
	[cod_audio] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [Audios_pk] PRIMARY KEY CLUSTERED 
(
	[cod_audio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Barrios]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Barrios](
	[cod_barrio] [int] NOT NULL,
	[barrio] [varchar](50) NOT NULL,
	[cod_ciudad] [int] NOT NULL,
 CONSTRAINT [Barrios_pk] PRIMARY KEY CLUSTERED 
(
	[cod_barrio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Butacas]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Butacas](
	[cod_butaca] [int] NOT NULL,
	[cod_sala] [int] NOT NULL,
 CONSTRAINT [Butacas_pk] PRIMARY KEY CLUSTERED 
(
	[cod_butaca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ciudades](
	[cod_ciudad] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[cod_provincia] [int] NOT NULL,
 CONSTRAINT [Ciudades_pk] PRIMARY KEY CLUSTERED 
(
	[cod_ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[cod_cliente] [int] NOT NULL,
	[nom_cliente] [varchar](100) NOT NULL,
	[ape_cliente] [varchar](50) NOT NULL,
	[fecha_nac] [datetime] NOT NULL,
	[sexo] [bit] NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[nro_tel] [bigint] NULL,
	[mail] [varchar](100) NOT NULL,
	[cod_barrio] [int] NOT NULL,
 CONSTRAINT [Clientes_pk] PRIMARY KEY CLUSTERED 
(
	[cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Detalle_tickets]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_tickets](
	[cod_detalle] [int] NOT NULL,
	[total] [decimal](10, 2) NOT NULL,
	[cod_promo] [int] NOT NULL,
	[cod_funcion] [int] NOT NULL,
	[cod_ticket] [int] NOT NULL,
	[cod_butaca] [int] NOT NULL,
 CONSTRAINT [Detalle_tickets_pk] PRIMARY KEY CLUSTERED 
(
	[cod_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Directores]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Directores](
	[cod_director] [int] NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[apellido] [varchar](45) NOT NULL,
 CONSTRAINT [Directores_pk] PRIMARY KEY CLUSTERED 
(
	[cod_director] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Formas_de_pagos]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Formas_de_pagos](
	[cod_forma_de_pago] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
 CONSTRAINT [Formas_de_pagos_pk] PRIMARY KEY CLUSTERED 
(
	[cod_forma_de_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Funciones]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funciones](
	[cod_funcion] [int] NOT NULL,
	[dia_horario] [datetime] NOT NULL,
	[precio] [decimal](10, 2) NOT NULL,
	[cod_audio] [int] NOT NULL,
	[cod_sala] [int] NOT NULL,
	[cod_peliciula] [int] NOT NULL,
 CONSTRAINT [Funciones_pk] PRIMARY KEY CLUSTERED 
(
	[cod_funcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Generos]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Generos](
	[cod_genero] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [Generos_pk] PRIMARY KEY CLUSTERED 
(
	[cod_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Peliculas](
	[cod_pelicula] [int] NOT NULL,
	[titulo] [varchar](100) NULL,
	[fecha_estreno] [date] NOT NULL,
	[idioma] [varchar](50) NOT NULL,
	[sinopsis] [varchar](500) NOT NULL,
	[cod_genero] [int] NOT NULL,
	[cod_director] [int] NOT NULL,
	[calificacion] [int] NOT NULL,
	[duracion] [int] NULL,
 CONSTRAINT [Peliculas_pk] PRIMARY KEY CLUSTERED 
(
	[cod_pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Promociones](
	[cod_promo] [int] NOT NULL,
	[nombre_promo] [varchar](100) NOT NULL,
 CONSTRAINT [Promociones_pk] PRIMARY KEY CLUSTERED 
(
	[cod_promo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincias](
	[cod_provincia] [int] NOT NULL,
	[provincia] [varchar](50) NOT NULL,
 CONSTRAINT [Provincias_pk] PRIMARY KEY CLUSTERED 
(
	[cod_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[cod_reserva] [int] NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[cod_cliente] [int] NOT NULL,
	[cod_funcion] [int] NOT NULL,
	[cod_butaca] [int] NOT NULL,
	[cod_sucursal] [int] NOT NULL,
 CONSTRAINT [Reserva_pk] PRIMARY KEY CLUSTERED 
(
	[cod_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salas]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salas](
	[cod_sala] [int] NOT NULL,
	[cod_tipo] [int] NOT NULL,
 CONSTRAINT [Salas_pk] PRIMARY KEY CLUSTERED 
(
	[cod_sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursales](
	[cod_sucursal] [int] NOT NULL,
	[nom_sucursal] [varchar](50) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[cod_barrio] [int] NOT NULL,
 CONSTRAINT [Sucursales_pk] PRIMARY KEY CLUSTERED 
(
	[cod_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[cod_ticket] [int] NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[cod_forma_de_pago] [int] NOT NULL,
	[cod_cliente] [int] NOT NULL,
	[cod_sucursal] [int] NOT NULL,
 CONSTRAINT [Tickets_pk] PRIMARY KEY CLUSTERED 
(
	[cod_ticket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tipos_de_salas]    Script Date: 23/11/2017 2:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos_de_salas](
	[cod_tipo] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [Tipos_de_salas_pk] PRIMARY KEY CLUSTERED 
(
	[cod_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (1, N'LEONARDO', N'DICAPRIO')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (2, N'JENIFFER', N'ANISTON')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (3, N'TOM', N'HANKS')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (4, N'RICHARD', N'GEERE')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (5, N'VIN', N'DIESEL')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (6, N'PAUL', N'WALKER')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (7, N'NATALIE', N'PORTMAN')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (8, N'SANDRA', N'BULLOCKS')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (9, N'SCARLET', N'JOHANSEN')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (10, N'KATE', N'WINSLET')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (11, N'ROBERT', N'PATTISON')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (12, N'KRISTEN', N'STEWART')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (13, N'JHONNY', N'DEEP')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (14, N'ORLANDO', N'BLOOM')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (15, N'BEN', N'AFFLECK')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (16, N'TOM', N'HOLLAND')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (17, N'EMMA', N'WATSON')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (18, N'HUGH', N'JACKMAN')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (19, N'PATRICK', N'STEWART')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (20, N'ZOE', N'SALDAÑA')
INSERT [dbo].[Actores] ([cod_actor], [nombre], [apellido]) VALUES (21, N'JOSE', N'GANORA')
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (1, 1)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (1, 10)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (2, 2)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (3, 13)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (3, 14)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (4, 4)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (4, 5)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (4, 6)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (5, 11)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (5, 12)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (6, 15)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (6, 16)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (7, 8)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (7, 10)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (8, 20)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (9, 18)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (10, 17)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (11, 9)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (12, 3)
INSERT [dbo].[actores_peliculas] ([cod_pelicula], [cod_actor]) VALUES (13, 7)
INSERT [dbo].[Audios] ([cod_audio], [nombre]) VALUES (1, N'INGKES')
INSERT [dbo].[Audios] ([cod_audio], [nombre]) VALUES (2, N'LATINO')
INSERT [dbo].[Audios] ([cod_audio], [nombre]) VALUES (3, N'FRANCES')
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (1, N'ALTO ALBERDI', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (2, N'ALBERDI', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (3, N'GRAL PAZ', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (4, N'CENTRO', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (5, N'NUEVA CORDOBA', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (6, N'AMEGHINO', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (7, N'COFICO', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (8, N'ALTA CBA', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (9, N'COLINAS DE VELEZ SARSFIELD', 1)
INSERT [dbo].[Barrios] ([cod_barrio], [barrio], [cod_ciudad]) VALUES (10, N'LAS FLORES', 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (10, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (11, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (12, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (13, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (14, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (15, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (16, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (17, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (18, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (19, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (20, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (21, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (22, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (23, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (24, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (25, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (26, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (27, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (28, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (29, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (30, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (31, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (32, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (33, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (34, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (35, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (36, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (37, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (38, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (39, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (40, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (41, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (42, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (43, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (44, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (45, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (46, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (47, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (48, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (49, 1)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (110, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (111, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (112, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (113, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (114, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (115, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (116, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (117, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (118, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (119, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (220, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (221, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (222, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (223, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (224, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (225, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (226, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (227, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (228, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (229, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (330, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (331, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (332, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (333, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (334, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (335, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (336, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (337, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (338, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (339, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (440, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (441, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (442, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (443, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (444, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (445, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (446, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (447, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (448, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (449, 2)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1010, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1011, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1012, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1013, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1014, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1015, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1016, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1017, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1018, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (1019, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2020, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2021, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2022, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2023, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2024, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2025, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2026, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2027, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2028, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (2029, 3)
GO
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3030, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3031, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3032, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3033, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3034, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3035, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3036, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3037, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3038, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (3039, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4040, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4041, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4042, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4043, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4044, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4045, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4046, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4047, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4048, 3)
INSERT [dbo].[Butacas] ([cod_butaca], [cod_sala]) VALUES (4049, 3)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (1, N'CORDOBA', 1)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (2, N'RIVADAVIA', 2)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (3, N'SAN SALVADOR DE JUJUY', 3)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (4, N'MAR DEL PLATA', 4)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (5, N'SAN LORENZO', 5)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (6, N'SAN MIGUEL DE TUCUMAN', 6)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (7, N'GUAYMALLEN', 7)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (8, N'RAWSON', 8)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (9, N'ANILLACO', 9)
INSERT [dbo].[Ciudades] ([cod_ciudad], [nombre], [cod_provincia]) VALUES (10, N'BARILOCHE', 10)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (1, N'JOSE', N'GANORA', CAST(0x0000734D00000000 AS DateTime), 1, N'CARCANO 54', 156123456, N'PEPE@GMAIL.COM', 2)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (2, N'MARTIN', N'GUTIERREZ', CAST(0x00007BA200000000 AS DateTime), 1, N'27 DE ABRIL 2986', 152109493, N'MARTIN@GMAIL.COM', 1)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (3, N'ALEJANDRO', N'ORELLANO', CAST(0x0000844400000000 AS DateTime), 1, N'LAVALLEJA 123', 154987456, N'ALEJANDRO@GMAIL.COM', 4)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (4, N'CELESTE', N'FERNANDEZ', CAST(0x000076AE00000000 AS DateTime), 0, N'ROMAGOSA 320', 152555763, N'CELESTE@GMAIL.COM', 3)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (5, N'PABLO', N'OCAÑO', CAST(0x00007A0800000000 AS DateTime), 1, N'GORRITI 741', 154789147, N'PABLO@GMAIL.COM', 9)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (6, N'DENIS', N'CABRERA', CAST(0x0000781200000000 AS DateTime), 1, N'LIBERTAD 456', 154963258, N'DENIS@GMAIL.COM', 8)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (7, N'BELEN', N'FRANCESE', CAST(0x0000768300000000 AS DateTime), 0, N'ESPOSOS CURIE 743', 154852154, N'BELEN@GMAIL.COM', 7)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (8, N'SOLEDAD', N'SILVEYRA', CAST(0x00007D7900000000 AS DateTime), 0, N'SAN MARTIN 147', 156789741, N'SOLEDAD@GMAIL.COM', 2)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (9, N'GERMAN', N'LUX', CAST(0x00007C2B00000000 AS DateTime), 1, N'JUJUY 456', 154123654, N'GERMAN@GMAIL.COM', 7)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (10, N'LUCAS', N'ALARIO', CAST(0xFFFFDC0700000000 AS DateTime), 1, N'RONDEAU 45', 15845698, N'LUCAS@GMAIL.COM', 6)
INSERT [dbo].[Clientes] ([cod_cliente], [nom_cliente], [ape_cliente], [fecha_nac], [sexo], [direccion], [nro_tel], [mail], [cod_barrio]) VALUES (11, N'LIONEL', N'MESSI', CAST(0x00007BF400000000 AS DateTime), 1, N'INDEPENDENCIA 789', 157321456, N'LIONEL@GMAIL.COM', 4)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (1, CAST(360.00 AS Decimal(10, 2)), 2, 1, 1, 10)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (2, CAST(60.00 AS Decimal(10, 2)), 3, 1, 2, 1012)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (3, CAST(120.00 AS Decimal(10, 2)), 2, 2, 3, 4044)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (4, CAST(180.00 AS Decimal(10, 2)), 1, 3, 4, 331)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (5, CAST(120.00 AS Decimal(10, 2)), 2, 2, 5, 225)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (6, CAST(60.00 AS Decimal(10, 2)), 1, 1, 6, 449)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (7, CAST(60.00 AS Decimal(10, 2)), 2, 4, 7, 24)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (8, CAST(120.00 AS Decimal(10, 2)), 4, 1, 8, 27)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (9, CAST(180.00 AS Decimal(10, 2)), 1, 2, 9, 2024)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (10, CAST(120.00 AS Decimal(10, 2)), 2, 3, 10, 3039)
INSERT [dbo].[Detalle_tickets] ([cod_detalle], [total], [cod_promo], [cod_funcion], [cod_ticket], [cod_butaca]) VALUES (11, CAST(60.00 AS Decimal(10, 2)), 4, 2, 11, 15)
INSERT [dbo].[Directores] ([cod_director], [nombre], [apellido]) VALUES (1, N'JAMES', N'CAMERON')
INSERT [dbo].[Directores] ([cod_director], [nombre], [apellido]) VALUES (2, N'CATHERINE', N'HARDWICKE')
INSERT [dbo].[Directores] ([cod_director], [nombre], [apellido]) VALUES (3, N'ZACK', N'SNYDER')
INSERT [dbo].[Directores] ([cod_director], [nombre], [apellido]) VALUES (4, N'JUSTIN', N'LI')
INSERT [dbo].[Directores] ([cod_director], [nombre], [apellido]) VALUES (5, N'ROB', N'MARSHALL')
INSERT [dbo].[Directores] ([cod_director], [nombre], [apellido]) VALUES (6, N'JAMES', N'GUNN')
INSERT [dbo].[Directores] ([cod_director], [nombre], [apellido]) VALUES (7, N'BILL', N'CONDON')
INSERT [dbo].[Directores] ([cod_director], [nombre], [apellido]) VALUES (8, N'MENNAN', N'YAPO')
INSERT [dbo].[Formas_de_pagos] ([cod_forma_de_pago], [tipo]) VALUES (1, N'EECTIVO')
INSERT [dbo].[Formas_de_pagos] ([cod_forma_de_pago], [tipo]) VALUES (2, N'TARJETA CREDITO')
INSERT [dbo].[Formas_de_pagos] ([cod_forma_de_pago], [tipo]) VALUES (3, N'TARJETA DEBITO')
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (1, CAST(0x0000A80D00000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 1, 3, 5)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (2, CAST(0x0000A7F400000000 AS DateTime), CAST(60.00 AS Decimal(10, 2)), 3, 1, 6)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (3, CAST(0x0000A66800000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 2, 2, 4)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (4, CAST(0x0000A68400000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 1, 1, 1)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (5, CAST(0x0000A77300000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 2, 3, 9)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (6, CAST(0x0000A7C300000000 AS DateTime), CAST(60.00 AS Decimal(10, 2)), 3, 3, 13)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (7, CAST(0x0000A65100000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 1, 2, 11)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (8, CAST(0x0000A7A800000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 2, 1, 8)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (9, CAST(0x0000A6EE00000000 AS DateTime), CAST(60.00 AS Decimal(10, 2)), 3, 3, 7)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (10, CAST(0x0000A78400000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 2, 1, 10)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (11, CAST(0x0000A68B00000000 AS DateTime), CAST(60.00 AS Decimal(10, 2)), 1, 3, 5)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (12, CAST(0x0000A7BB00000000 AS DateTime), CAST(60.00 AS Decimal(10, 2)), 1, 1, 13)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (13, CAST(0x0000A6DB00000000 AS DateTime), CAST(60.00 AS Decimal(10, 2)), 2, 2, 4)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (14, CAST(0x0000A78800000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 1, 3, 8)
INSERT [dbo].[Funciones] ([cod_funcion], [dia_horario], [precio], [cod_audio], [cod_sala], [cod_peliciula]) VALUES (15, CAST(0x0000A6B400000000 AS DateTime), CAST(120.00 AS Decimal(10, 2)), 2, 1, 9)
INSERT [dbo].[Generos] ([cod_genero], [nombre]) VALUES (1, N'DRAMA')
INSERT [dbo].[Generos] ([cod_genero], [nombre]) VALUES (2, N'AVENTURA')
INSERT [dbo].[Generos] ([cod_genero], [nombre]) VALUES (3, N'ACCION')
INSERT [dbo].[Generos] ([cod_genero], [nombre]) VALUES (4, N'COMIC')
INSERT [dbo].[Generos] ([cod_genero], [nombre]) VALUES (5, N'INFANTILES')
INSERT [dbo].[Generos] ([cod_genero], [nombre]) VALUES (6, N'SUSPENSO')
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (1, N'TITANIC', CAST(0x86230B00 AS Date), N'INGLES', N'BARCO QUE SE HUNDE', 1, 1, 5, 180)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (2, N'VIVIENDO CON MI EX', CAST(0xB90D0B00 AS Date), N'INGLES', N'PAREJA SE SEPARA PERO VIVEN JUNTOS', 1, 3, 3, 180)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (3, N'PIRATAS DEL CARIBE', CAST(0x563C0B00 AS Date), N'INGLES', N'PIRATAS', 2, 5, 4, 195)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (4, N'RAPIDO Y FURIOSO', CAST(0x9E3B0B00 AS Date), N'LATINO', N'PICADAS DE AUTOS', 3, 4, 5, 200)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (5, N'CREPUSCULO', CAST(0x5A3A0B00 AS Date), N'LATINO', N'VAMPIROS VS LOBOS', 1, 2, 5, 210)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (6, N'BATMAN VS SUPERMAN', CAST(0xB5380B00 AS Date), N'FRANCES', N'SUPERHEROES', 4, 3, 5, 175)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (7, N'PREMONICION', CAST(0x053C0B00 AS Date), N'INGLES', N'MUJER OLVIDA COSAS', 6, 8, 2, 197)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (8, N'GUARDIANES DE LA GALAXYA', CAST(0x213B0B00 AS Date), N'LATINO', N'PERSONAS DEL ESPACIO', 5, 6, 4, 188)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (9, N'WOLVERINE', CAST(0xA83C0B00 AS Date), N'LATINO', N'HISTORIA DE WOLVERINE', 4, 4, 5, 205)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (10, N'LA BELLA Y LA BESTIA', CAST(0x433B0B00 AS Date), N'INGLES', N'HISTORIA DE LA BELLA Y LA BESTIA', 5, 7, 3, 212)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (11, N'THE ADVENGERS', CAST(0x8E3B0B00 AS Date), N'INGLES', N'GUERRA', 4, 4, 5, 187)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (12, N'NAUFRAGO', CAST(0x0B3D0B00 AS Date), N'INGLES', N'PERDIDO EN LA ISLA', 2, 1, 5, 215)
INSERT [dbo].[Peliculas] ([cod_pelicula], [titulo], [fecha_estreno], [idioma], [sinopsis], [cod_genero], [cod_director], [calificacion], [duracion]) VALUES (13, N'EL CISNE NEGRO', CAST(0x373C0B00 AS Date), N'LATINO', N'BAILARINA', 1, 6, 5, 180)
INSERT [dbo].[Promociones] ([cod_promo], [nombre_promo]) VALUES (1, N'PROMO 2 X1')
INSERT [dbo].[Promociones] ([cod_promo], [nombre_promo]) VALUES (2, N'PROMO TARJETA CREDITO')
INSERT [dbo].[Promociones] ([cod_promo], [nombre_promo]) VALUES (3, N'PROMO ESTUDIANTE')
INSERT [dbo].[Promociones] ([cod_promo], [nombre_promo]) VALUES (4, N'PROMO JUBILADO')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (1, N'CORDOBA')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (2, N'SAN JUAN')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (3, N'JUJUY')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (4, N'BUENOS AIRES')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (5, N'SALTA')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (6, N'TUCUMAN')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (7, N'MENDOZA')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (8, N'CHUBUT')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (9, N'LA RIOJA')
INSERT [dbo].[Provincias] ([cod_provincia], [provincia]) VALUES (10, N'NEUQUEN')
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (1, CAST(0x0000A6FC00000000 AS DateTime), 3, 1, 10, 3)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (2, CAST(0x0000A80B00000000 AS DateTime), 11, 3, 1012, 1)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (3, CAST(0x0000A63900000000 AS DateTime), 9, 4, 4044, 4)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (4, CAST(0x0000A7B000000000 AS DateTime), 7, 4, 331, 2)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (5, CAST(0x0000A5EB00000000 AS DateTime), 2, 1, 225, 1)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (6, CAST(0x0000A6A000000000 AS DateTime), 8, 2, 449, 2)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (7, CAST(0x0000A63F00000000 AS DateTime), 6, 4, 24, 3)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (8, CAST(0x0000A72B00000000 AS DateTime), 10, 3, 27, 3)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (9, CAST(0x0000A79200000000 AS DateTime), 7, 4, 2024, 1)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (10, CAST(0x0000A75500000000 AS DateTime), 1, 3, 3039, 4)
INSERT [dbo].[Reserva] ([cod_reserva], [fecha_hora], [cod_cliente], [cod_funcion], [cod_butaca], [cod_sucursal]) VALUES (11, CAST(0x0000A7DA00000000 AS DateTime), 4, 3, 15, 2)
INSERT [dbo].[Salas] ([cod_sala], [cod_tipo]) VALUES (1, 1)
INSERT [dbo].[Salas] ([cod_sala], [cod_tipo]) VALUES (2, 2)
INSERT [dbo].[Salas] ([cod_sala], [cod_tipo]) VALUES (3, 3)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nom_sucursal], [direccion], [cod_barrio]) VALUES (1, N'PATIO OLMOS', N'BV SAN JUAN 200', 2)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nom_sucursal], [direccion], [cod_barrio]) VALUES (2, N'NUEVO CENTRO', N'DUARTE QUIROS', 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nom_sucursal], [direccion], [cod_barrio]) VALUES (3, N'GRAN REX', N'GRAL PAZ 12', 5)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nom_sucursal], [direccion], [cod_barrio]) VALUES (4, N'CINERAMA', N'COLON 789', 8)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (1, CAST(0x0000A80C00000000 AS DateTime), 1, 2, 4)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (2, CAST(0x0000A7F200000000 AS DateTime), 2, 5, 2)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (3, CAST(0x0000A7EA00000000 AS DateTime), 3, 10, 1)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (4, CAST(0x0000A7AA00000000 AS DateTime), 3, 3, 3)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (5, CAST(0x0000A78800000000 AS DateTime), 1, 11, 1)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (6, CAST(0x0000A66000000000 AS DateTime), 3, 7, 4)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (7, CAST(0x0000A64300000000 AS DateTime), 2, 3, 4)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (8, CAST(0x0000A76500000000 AS DateTime), 3, 9, 2)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (9, CAST(0x0000A5FD00000000 AS DateTime), 2, 8, 1)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (10, CAST(0x0000A6F300000000 AS DateTime), 3, 4, 2)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (11, CAST(0x0000A72900000000 AS DateTime), 2, 5, 3)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (12, CAST(0x0000A6DD00000000 AS DateTime), 3, 11, 4)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (13, CAST(0x0000A80A00000000 AS DateTime), 2, 4, 1)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (14, CAST(0x0000A78700000000 AS DateTime), 2, 1, 3)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (15, CAST(0x0000A7A600000000 AS DateTime), 3, 4, 4)
INSERT [dbo].[Tickets] ([cod_ticket], [fecha_hora], [cod_forma_de_pago], [cod_cliente], [cod_sucursal]) VALUES (16, CAST(0x00008E2700000000 AS DateTime), 2, 10, 3)
INSERT [dbo].[Tipos_de_salas] ([cod_tipo], [nombre]) VALUES (1, N'VIP')
INSERT [dbo].[Tipos_de_salas] ([cod_tipo], [nombre]) VALUES (2, N'INFANTILES')
INSERT [dbo].[Tipos_de_salas] ([cod_tipo], [nombre]) VALUES (3, N'AZUL')
ALTER TABLE [dbo].[actores_peliculas]  WITH CHECK ADD  CONSTRAINT [actores_peliculas_Actores] FOREIGN KEY([cod_actor])
REFERENCES [dbo].[Actores] ([cod_actor])
GO
ALTER TABLE [dbo].[actores_peliculas] CHECK CONSTRAINT [actores_peliculas_Actores]
GO
ALTER TABLE [dbo].[actores_peliculas]  WITH CHECK ADD  CONSTRAINT [actores_peliculas_Peliculas] FOREIGN KEY([cod_pelicula])
REFERENCES [dbo].[Peliculas] ([cod_pelicula])
GO
ALTER TABLE [dbo].[actores_peliculas] CHECK CONSTRAINT [actores_peliculas_Peliculas]
GO
ALTER TABLE [dbo].[Barrios]  WITH CHECK ADD  CONSTRAINT [Barrios_Ciudades] FOREIGN KEY([cod_ciudad])
REFERENCES [dbo].[Ciudades] ([cod_ciudad])
GO
ALTER TABLE [dbo].[Barrios] CHECK CONSTRAINT [Barrios_Ciudades]
GO
ALTER TABLE [dbo].[Butacas]  WITH CHECK ADD  CONSTRAINT [Butacas_Salas] FOREIGN KEY([cod_sala])
REFERENCES [dbo].[Salas] ([cod_sala])
GO
ALTER TABLE [dbo].[Butacas] CHECK CONSTRAINT [Butacas_Salas]
GO
ALTER TABLE [dbo].[Ciudades]  WITH CHECK ADD  CONSTRAINT [Ciudades_Provincias] FOREIGN KEY([cod_provincia])
REFERENCES [dbo].[Provincias] ([cod_provincia])
GO
ALTER TABLE [dbo].[Ciudades] CHECK CONSTRAINT [Ciudades_Provincias]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [Clientes_Barrios] FOREIGN KEY([cod_barrio])
REFERENCES [dbo].[Barrios] ([cod_barrio])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [Clientes_Barrios]
GO
ALTER TABLE [dbo].[Detalle_tickets]  WITH CHECK ADD  CONSTRAINT [Detalle_factura_Funciones] FOREIGN KEY([cod_funcion])
REFERENCES [dbo].[Funciones] ([cod_funcion])
GO
ALTER TABLE [dbo].[Detalle_tickets] CHECK CONSTRAINT [Detalle_factura_Funciones]
GO
ALTER TABLE [dbo].[Detalle_tickets]  WITH CHECK ADD  CONSTRAINT [Detalle_factura_Promociones] FOREIGN KEY([cod_promo])
REFERENCES [dbo].[Promociones] ([cod_promo])
GO
ALTER TABLE [dbo].[Detalle_tickets] CHECK CONSTRAINT [Detalle_factura_Promociones]
GO
ALTER TABLE [dbo].[Detalle_tickets]  WITH CHECK ADD  CONSTRAINT [Detalle_factura_Tickets] FOREIGN KEY([cod_ticket])
REFERENCES [dbo].[Tickets] ([cod_ticket])
GO
ALTER TABLE [dbo].[Detalle_tickets] CHECK CONSTRAINT [Detalle_factura_Tickets]
GO
ALTER TABLE [dbo].[Detalle_tickets]  WITH CHECK ADD  CONSTRAINT [Detalle_tickets_Butacas] FOREIGN KEY([cod_butaca])
REFERENCES [dbo].[Butacas] ([cod_butaca])
GO
ALTER TABLE [dbo].[Detalle_tickets] CHECK CONSTRAINT [Detalle_tickets_Butacas]
GO
ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [Funciones_Audios] FOREIGN KEY([cod_audio])
REFERENCES [dbo].[Audios] ([cod_audio])
GO
ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [Funciones_Audios]
GO
ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [Funciones_Peliculas] FOREIGN KEY([cod_peliciula])
REFERENCES [dbo].[Peliculas] ([cod_pelicula])
GO
ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [Funciones_Peliculas]
GO
ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [Funciones_Salas] FOREIGN KEY([cod_sala])
REFERENCES [dbo].[Salas] ([cod_sala])
GO
ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [Funciones_Salas]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [Peliculas_Directores] FOREIGN KEY([cod_director])
REFERENCES [dbo].[Directores] ([cod_director])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [Peliculas_Directores]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [Peliculas_Generos] FOREIGN KEY([cod_genero])
REFERENCES [dbo].[Generos] ([cod_genero])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [Peliculas_Generos]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [Reserva_Butacas] FOREIGN KEY([cod_butaca])
REFERENCES [dbo].[Butacas] ([cod_butaca])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [Reserva_Butacas]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [Reserva_Clientes] FOREIGN KEY([cod_cliente])
REFERENCES [dbo].[Clientes] ([cod_cliente])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [Reserva_Clientes]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [Reserva_Funciones] FOREIGN KEY([cod_funcion])
REFERENCES [dbo].[Funciones] ([cod_funcion])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [Reserva_Funciones]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [Reserva_Sucursales] FOREIGN KEY([cod_sucursal])
REFERENCES [dbo].[Sucursales] ([cod_sucursal])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [Reserva_Sucursales]
GO
ALTER TABLE [dbo].[Salas]  WITH CHECK ADD  CONSTRAINT [Salas_Tipos_de_salas] FOREIGN KEY([cod_tipo])
REFERENCES [dbo].[Tipos_de_salas] ([cod_tipo])
GO
ALTER TABLE [dbo].[Salas] CHECK CONSTRAINT [Salas_Tipos_de_salas]
GO
ALTER TABLE [dbo].[Sucursales]  WITH CHECK ADD  CONSTRAINT [Sucursales_Barrios] FOREIGN KEY([cod_barrio])
REFERENCES [dbo].[Barrios] ([cod_barrio])
GO
ALTER TABLE [dbo].[Sucursales] CHECK CONSTRAINT [Sucursales_Barrios]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [Tickets_Clientes] FOREIGN KEY([cod_cliente])
REFERENCES [dbo].[Clientes] ([cod_cliente])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [Tickets_Clientes]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [Tickets_Formas_de_pagos] FOREIGN KEY([cod_forma_de_pago])
REFERENCES [dbo].[Formas_de_pagos] ([cod_forma_de_pago])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [Tickets_Formas_de_pagos]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [Tickets_Sucursales] FOREIGN KEY([cod_sucursal])
REFERENCES [dbo].[Sucursales] ([cod_sucursal])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [Tickets_Sucursales]
GO
USE [master]
GO
ALTER DATABASE [CINE_TPI] SET  READ_WRITE 
GO
