USE [master]
GO
/****** Object:  Database [info360 Unimatch]    Script Date: 13/11/2025 15:10:56 ******/
CREATE DATABASE [info360 Unimatch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'info360 Unimatch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\info360 Unimatch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'info360 Unimatch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\info360 Unimatch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [info360 Unimatch] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [info360 Unimatch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [info360 Unimatch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [info360 Unimatch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [info360 Unimatch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [info360 Unimatch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [info360 Unimatch] SET ARITHABORT OFF 
GO
ALTER DATABASE [info360 Unimatch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [info360 Unimatch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [info360 Unimatch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [info360 Unimatch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [info360 Unimatch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [info360 Unimatch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [info360 Unimatch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [info360 Unimatch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [info360 Unimatch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [info360 Unimatch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [info360 Unimatch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [info360 Unimatch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [info360 Unimatch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [info360 Unimatch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [info360 Unimatch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [info360 Unimatch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [info360 Unimatch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [info360 Unimatch] SET RECOVERY FULL 
GO
ALTER DATABASE [info360 Unimatch] SET  MULTI_USER 
GO
ALTER DATABASE [info360 Unimatch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [info360 Unimatch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [info360 Unimatch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [info360 Unimatch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [info360 Unimatch] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'info360 Unimatch', N'ON'
GO
ALTER DATABASE [info360 Unimatch] SET QUERY_STORE = OFF
GO
USE [info360 Unimatch]
GO
/****** Object:  User [alumno]    Script Date: 13/11/2025 15:10:56 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 13/11/2025 15:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[idCarrera] [int] IDENTITY(1,1) NOT NULL,
	[idFacultad] [int] NOT NULL,
	[cantMaterias] [int] NOT NULL,
	[duracion] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](max) NOT NULL,
	[fotoCarrera] [varchar](50) NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[idCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chat]    Script Date: 13/11/2025 15:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[idChat] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[mensaje] [varchar](max) NOT NULL,
	[fechaHoraMensaje] [datetime] NOT NULL,
 CONSTRAINT [PK_Chat] PRIMARY KEY CLUSTERED 
(
	[idChat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facultad]    Script Date: 13/11/2025 15:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facultad](
	[idFacultad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[contacto] [varchar](50) NOT NULL,
	[precio] [int] NOT NULL,
	[fotoFacultad] [varchar](50) NULL,
	[tipoGestion] [bit] NOT NULL,
	[cantCarreras] [int] NOT NULL,
 CONSTRAINT [PK_Facultad] PRIMARY KEY CLUSTERED 
(
	[idFacultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resenia]    Script Date: 13/11/2025 15:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resenia](
	[idResenia] [int] IDENTITY(1,1) NOT NULL,
	[mensaje] [varchar](1000) NOT NULL,

	[idFacultad] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Resenia] PRIMARY KEY CLUSTERED 
(
	[idResenia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReseniaCarrera]    Script Date: 13/11/2025 15:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReseniaCarrera](
	[idReseniaCarrera] [int] IDENTITY(1,1) NOT NULL,
	[mensaje] [varchar](max) NOT NULL,

	[idCarrera] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_ReseniaCarrera] PRIMARY KEY CLUSTERED 
(
	[idReseniaCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 13/11/2025 15:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fotoTituloUni] [varchar](100) NULL,
	[carrera] [varchar](100) NULL,
	[gmail] [varchar](50) NOT NULL,
	[contrasenia] [varchar](80) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[idFacultad] [int] NULL,
	[rol] [bit] NOT NULL,
	[fotoPerfil] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Carrera] ON 

INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (1, 1, 45, 5, N'Ingeniería Aeronáutica', N'Formación en diseño, mantenimiento y gestión de aeronaves y estructuras de vuelo.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (2, 2, 42, 6, N'Odontología', N'Carrera centrada en la salud bucal, prevención y tratamiento odontológico.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (3, 3, 40, 5, N'Lic. en Ciencias Biológicas', N'Estudio científico de los seres vivos, su evolución y relación con el entorno.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (4, 4, 38, 4, N'Cine', N'Formación teórica y práctica en dirección, guion y producción audiovisual.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (5, 5, 50, 5, N'Terapia Ocupacional', N'Promoción de la salud y bienestar mediante la ocupación significativa.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (6, 6, 45, 5, N'Agronomía', N'Formación en manejo sustentable de recursos naturales y sistemas productivos.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (7, 7, 45, 5, N'Ingeniería Aeronáutica', N'Aplicación de la ingeniería a la aeronavegación y diseño estructural.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (8, 8, 40, 6, N'Odontología', N'Diagnóstico, prevención y tratamiento de enfermedades bucodentales.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (9, 1, 50, 5, N'Lic. en Ciencias Biológicas', N'Investigación y docencia sobre organismos vivos.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (10, 2, 35, 4, N'Cine', N'Desarrollo de competencias artísticas y técnicas en el cine contemporáneo.', NULL)
SET IDENTITY_INSERT [dbo].[Carrera] OFF
GO
SET IDENTITY_INSERT [dbo].[Chat] ON 

INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (1, 1, N'Hola, ¿cómo hago para inscribirme a Ingeniería Aeronáutica?', CAST(N'2025-03-10T09:20:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (2, 2, N'Buenas tardes, ¿cuándo empiezan las clases de Odontología?', CAST(N'2025-03-11T14:35:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (3, 3, N'¿La carrera de Biología tiene modalidad virtual?', CAST(N'2025-03-12T10:15:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (4, 4, N'Estoy editando mi primer cortometraje en ITBA, ¡qué emoción!', CAST(N'2025-03-13T18:50:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (5, 5, N'La carrera de Terapia Ocupacional tiene materias muy humanas, me encanta.', CAST(N'2025-03-14T20:10:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (6, 6, N'En Agronomía aprendemos mucho sobre sostenibilidad.', CAST(N'2025-03-15T11:40:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (7, 7, N'Los simuladores de vuelo en UADE son excelentes.', CAST(N'2025-03-16T17:30:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (8, 8, N'En Da Vinci los laboratorios de odontología están muy bien equipados.', CAST(N'2025-03-17T19:00:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (9, 9, N'La bioquímica de segundo año es difícil, pero muy interesante.', CAST(N'2025-03-18T16:25:00.000' AS DateTime))
INSERT [dbo].[Chat] ([idChat], [idUsuario], [mensaje], [fechaHoraMensaje]) VALUES (10, 10, N'Estoy preparando mi primer corto para el festival interno de Di Tella.', CAST(N'2025-03-19T21:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Chat] OFF
GO
SET IDENTITY_INSERT [dbo].[Facultad] ON 

INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (1, N'UADE', N'Lima 775, Ciudad Autónoma de Buenos Aires', N'contacto@uade.edu.ar', 250000, N'uade.jpg', 1, 6)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (2, N'Universidad Torcuato Di Tella', N'Av. Figueroa Alcorta 7350, CABA', N'admision@utdt.edu', 280000, N'ditella.jpg', 1, 5)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (3, N'UTN', N'Medrano 951, CABA', N'contacto@utn.edu.ar', 120000, N'utn.jpg', 0, 8)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (4, N'ITBA', N'Av. Eduardo Madero 399, CABA', N'info@itba.edu.ar', 300000, N'itba.jpg', 1, 5)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (5, N'Universidad de Palermo', N'Mario Bravo 1050, CABA', N'info@palermo.edu', 220000, N'up.jpg', 1, 6)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (6, N'UFLO', N'Pedernera 288, CABA', N'info@uflo.edu.ar', 180000, N'uflo.jpg', 1, 5)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (7, N'Universidad de Belgrano', N'Villanueva 1324, CABA', N'contacto@ub.edu.ar', 210000, N'ub.jpg', 1, 7)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (8, N'Universidad Leonardo Da Vinci', N'Av. Cabildo 2040, CABA', N'info@davinci.edu.ar', 190000, N'davinci.jpg', 1, 4)
SET IDENTITY_INSERT [dbo].[Facultad] OFF
GO
SET IDENTITY_INSERT [dbo].[Resenia] ON 

INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (1, N'Excelente universidad, la infraestructura es moderna y los profesores son atentos.',  1, 1)
INSERT [dbo].[Resenia] ([idResenia], [mensaje],  [idFacultad], [idUsuario]) VALUES (2, N'La Di Tella tiene una gran propuesta académica y cultural.', 2, 2)
INSERT [dbo].[Resenia] ([idResenia], [mensaje],  [idFacultad], [idUsuario]) VALUES (3, N'UTN ofrece una educación pública de calidad y práctica.',  3, 3)
INSERT [dbo].[Resenia] ([idResenia], [mensaje],  [idFacultad], [idUsuario]) VALUES (4, N'El ITBA tiene un nivel muy alto, aunque la exigencia es fuerte.', 4, 4, 4)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (5, N'La UP me brindó herramientas muy útiles para mi carrera profesional.', 5, 5)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (6, N'En UFLO encontré un ambiente muy humano y contenedor.',  6, 6)
INSERT [dbo].[Resenia] ([idResenia], [mensaje],[idFacultad], [idUsuario]) VALUES (7, N'La UB tiene profesores excelentes y buena red de contactos.',  7, 7)
INSERT [dbo].[Resenia] ([idResenia], [mensaje],[idFacultad], [idUsuario]) VALUES (8, N'Da Vinci es ideal para carreras con orientación tecnológica.',  8, 8)
INSERT [dbo].[Resenia] ([idResenia], [mensaje],  [idFacultad], [idUsuario]) VALUES (9, N'UADE combina lo teórico con lo práctico de forma excelente.',  1, 9)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (10, N'La Di Tella impulsa mucho la investigación y la creatividad.', 2, 10)
SET IDENTITY_INSERT [dbo].[Resenia] OFF
GO
SET IDENTITY_INSERT [dbo].[ReseniaCarrera] ON 

INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje],  [idCarrera], [idUsuario]) VALUES (1, N'Ingeniería en Informática tiene una gran base técnica, aunque las materias iniciales son exigentes.', 1, 1)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje],  [idCarrera], [idUsuario]) VALUES (2, N'Psicología es muy interesante, pero requiere mucha lectura y análisis constante.',  2, 4)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (3, N'Medicina tiene una excelente formación práctica, aunque el ritmo de cursada es intenso.',  3, 5)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (4, N'Diseño Gráfico es muy creativo, pero debería incluir más herramientas digitales.',  4, 3)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje],[idCarrera], [idUsuario]) VALUES (5, N'Arquitectura combina técnica y arte, aunque la carga horaria es bastante alta.',  5, 2)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje],  [idCarrera], [idUsuario]) VALUES (6, N'Economía brinda una visión profunda del sistema financiero, ideal para quienes disfrutan el análisis.',  6, 6)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje],  [idCarrera], [idUsuario]) VALUES (7, N'Informática en la UBA tiene docentes excelentes y materias muy actualizadas.', 1, 7)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (8, N'Psicología me encantó, especialmente las materias clínicas. Muy recomendable.',  2, 8)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje],  [idCarrera], [idUsuario]) VALUES (9, N'Medicina es una carrera muy demandante, pero gratificante al final del camino.',  3, 9)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (10, N'Diseño Gráfico tiene un enfoque muy práctico y moderno, perfecto para mentes creativas.', 4, 10)
SET IDENTITY_INSERT [dbo].[ReseniaCarrera] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (1, N'Juan', N'Pérez', N'titulo_juan.jpg', N'Ingeniería Aeronáutica', N'juanperez@gmail.com', N'12345', N'juanp', 1, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (2, N'María', N'López', N'titulo_maria.jpg', N'Odontología', N'marialopez@gmail.com', N'abcd1234', N'marial', 2, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (3, N'Lucas', N'Gómez', N'titulo_lucas.jpg', N'Lic. en Ciencias Biológicas', N'lucasgomez@gmail.com', N'pass123', N'lucasg', 3, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (4, N'Camila', N'Rodríguez', N'titulo_camila.jpg', N'Cine', N'camilarodriguez@gmail.com', N'cine2024', N'camiro', 4, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (5, N'Sofía', N'Martínez', N'titulo_sofia.jpg', N'Terapia Ocupacional', N'sofia.martinez@gmail.com', N'sofi2025', N'sofiam', 5, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (6, N'Agustín', N'Fernández', N'titulo_agustin.jpg', N'Agronomía', N'agustin.fernandez@gmail.com', N'agro321', N'agustinf', 6, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (7, N'Valentina', N'Torres', N'titulo_valen.jpg', N'Ingeniería Aeronáutica', N'valentina.torres@gmail.com', N'aero2025', N'valentor', 7, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (8, N'Nicolás', N'Sosa', N'titulo_nico.jpg', N'Odontología', N'nico.sosa@gmail.com', N'odonto', N'nicos', 8, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (9, N'Lucía', N'Vega', N'titulo_lucia.jpg', N'Lic. en Ciencias Biológicas', N'lucia.vega@gmail.com', N'bio123', N'luciav', 1, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (10, N'Martín', N'Díaz', N'titulo_martin.jpg', N'Cine', N'martin.diaz@gmail.com', N'cinepass', N'martind', 2, 1, NULL)
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (12, N'Juan', N'López', N'.png', N'Cine', N'juanT@gmail.com', N'juancho', N'juaneto01', 2, 0, NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Carrera]  WITH CHECK ADD  CONSTRAINT [FK_Carrera_Facultad] FOREIGN KEY([idFacultad])
REFERENCES [dbo].[Facultad] ([idFacultad])
GO
ALTER TABLE [dbo].[Carrera] CHECK CONSTRAINT [FK_Carrera_Facultad]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK_Chat_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK_Chat_Usuario]
GO
ALTER TABLE [dbo].[Resenia]  WITH CHECK ADD  CONSTRAINT [FK_Resenia_Facultad] FOREIGN KEY([idFacultad])
REFERENCES [dbo].[Facultad] ([idFacultad])
GO
ALTER TABLE [dbo].[Resenia] CHECK CONSTRAINT [FK_Resenia_Facultad]
GO
ALTER TABLE [dbo].[Resenia]  WITH CHECK ADD  CONSTRAINT [FK_Resenia_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Resenia] CHECK CONSTRAINT [FK_Resenia_Usuario]
GO
ALTER TABLE [dbo].[ReseniaCarrera]  WITH CHECK ADD  CONSTRAINT [FK_ReseniaCarrera_Carrera] FOREIGN KEY([idCarrera])
REFERENCES [dbo].[Carrera] ([idCarrera])
GO
ALTER TABLE [dbo].[ReseniaCarrera] CHECK CONSTRAINT [FK_ReseniaCarrera_Carrera]
GO
ALTER TABLE [dbo].[ReseniaCarrera]  WITH CHECK ADD  CONSTRAINT [FK_ReseniaCarrera_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ReseniaCarrera] CHECK CONSTRAINT [FK_ReseniaCarrera_Usuario]
GO
USE [master]
GO
ALTER DATABASE [info360 Unimatch] SET  READ_WRITE 
GO
