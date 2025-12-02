USE [master]
GO
/****** Object:  Database [info360 Unimatch]    Script Date: 27/11/2025 15:44:25 ******/
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
ALTER DATABASE [info360 Unimatch] SET QUERY_STORE = OFF
GO
USE [info360 Unimatch]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 12/1/2025 10:43:25 PM ******/
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
/****** Object:  Table [dbo].[Chat]    Script Date: 12/1/2025 10:43:25 PM ******/
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
/****** Object:  Table [dbo].[Facultad]    Script Date: 12/1/2025 10:43:25 PM ******/
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
/****** Object:  Table [dbo].[Resenia]    Script Date: 12/1/2025 10:43:25 PM ******/
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
/****** Object:  Table [dbo].[ReseniaCarrera]    Script Date: 12/1/2025 10:43:25 PM ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/1/2025 10:43:25 PM ******/
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

INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (1, 1, 45, 5, N'Ingeniería Aeronáutica', N'Formación en diseño, mantenimiento y gestión de aeronaves y estructuras de vuelo.', N'/img/Aeroespacial.jpg')
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (2, 2, 42, 6, N'Odontología', N'Carrera centrada en la salud bucal, prevención y tratamiento odontológico.', N'/img/Odontologia.jpg')
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (3, 3, 40, 5, N'Lic. en Ciencias Biológicas', N'Estudio científico de los seres vivos, su evolución y relación con el entorno.', N'/img/CienciasBiologicas.jpg')
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (4, 4, 38, 4, N'Cine', N'Formación teórica y práctica en dirección, guion y producción audiovisual.', N'/img/Cine.jpg')
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (5, 5, 50, 5, N'Terapia Ocupacional', N'Promoción de la salud y bienestar mediante la ocupación significativa.', N'/terapia ocupacional.jpg')
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (6, 6, 45, 5, N'Agronomía', N'Formación en manejo sustentable de recursos naturales y sistemas productivos.', N'/img/Agronomia.avif')
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (7, 7, 45, 5, N'Ingeniería Aeronáutica', N'Aplicación de la ingeniería a la aeronavegación y diseño estructural.', NULL)
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (8, 8, 40, 6, N'Odontología', N'Diagnóstico, prevención y tratamiento de enfermedades bucodentales.', N'/img/Odontologia.jpg')
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (9, 1, 50, 5, N'Lic. en Ciencias Biológicas', N'Investigación y docencia sobre organismos vivos.', N'/img/CienciasBiologicas.jpg')
INSERT [dbo].[Carrera] ([idCarrera], [idFacultad], [cantMaterias], [duracion], [nombre], [descripcion], [fotoCarrera]) VALUES (10, 2, 35, 4, N'Cine', N'Desarrollo de competencias artísticas y técnicas en el cine contemporáneo.', N'/img/Cine.jpg')
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

INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (1, N'UADE', N'Lima 775, Ciudad Autónoma de Buenos Aires', N'contacto@uade.edu.ar', 250000, N'/img/uade2.png', 1, 6)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (2, N'Universidad Torcuato Di Tella', N'Av. Figueroa Alcorta 7350, CABA', N'admision@utdt.edu', 280000, N'/img/ditella.png', 1, 5)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (3, N'UTN', N'Medrano 951, CABA', N'contacto@utn.edu.ar', 120000, N'/img/utn.png', 0, 8)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (4, N'ITBA', N'Av. Eduardo Madero 399, CABA', N'info@itba.edu.ar', 300000, N'/img/itba.png', 1, 5)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (5, N'Universidad de Palermo', N'Mario Bravo 1050, CABA', N'info@palermo.edu', 220000, N'/img/up.png', 1, 6)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (6, N'UFLO', N'Pedernera 288, CABA', N'info@uflo.edu.ar', 180000, N'/img/uflo.jpg', 1, 5)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (7, N'Universidad de Belgrano', N'Villanueva 1324, CABA', N'contacto@ub.edu.ar', 210000, N'/img/ub.jpg', 1, 7)
INSERT [dbo].[Facultad] ([idFacultad], [nombre], [direccion], [contacto], [precio], [fotoFacultad], [tipoGestion], [cantCarreras]) VALUES (8, N'Universidad Leonardo Da Vinci', N'Av. Cabildo 2040, CABA', N'info@davinci.edu.ar', 190000, N'/img/davinci.jpeg', 1, 4)
SET IDENTITY_INSERT [dbo].[Facultad] OFF
GO
SET IDENTITY_INSERT [dbo].[Resenia] ON 

INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (1, N'La facultad ofrece un ambiente muy sólido y organizado; siento que los contenidos están bien distribuidos y se nota el esfuerzo por mantener un buen nivel académico.', 1, 1)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (2, N'Me gustó mucho la exigencia y la forma en que se plantean las prácticas; la facultad mantiene un enfoque profesional que suma muchísimo a la formación.', 2, 2)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (3, N'La facultad tiene docentes muy claros y recursos modernos; creo que la carga teórica es intensa, pero al final se nota que vale la pena.', 3, 3)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (4, N'El ambiente de la facultad es muy creativo y colaborativo; se fomenta mucho el trabajo en equipo y eso hace que la experiencia sea súper enriquecedora.', 4, 4)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (5, N'La facultad brinda un trato muy humano y cercano; las materias están bien integradas y sentís que realmente se preocupan por tu avance.', 5, 5)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (6, N'La facultad tiene un enfoque práctico muy marcado que ayuda a aplicar rápido lo aprendido; quizás podría mejorar la comunicación, pero la experiencia es muy positiva.', 6, 6)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (7, N'Me encantó la organización y el nivel de acompañamiento de los docentes; la facultad está muy bien estructurada y se nota un compromiso real con los estudiantes.', 7, 7)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (8, N'La facultad cuenta con muy buenos laboratorios y actividades complementarias; se siente un ambiente serio donde te preparan para lo que viene.', 8, 8)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (9, N'La facultad es muy completa y mantiene un nivel académico constante; siempre encontré apoyo cuando lo necesité y eso suma muchísimo.', 1, 9)
INSERT [dbo].[Resenia] ([idResenia], [mensaje], [idFacultad], [idUsuario]) VALUES (10, N'La experiencia en esta facultad fue muy buena; se trabaja con proyectos reales y eso ayuda a crecer tanto en lo técnico como en lo personal.', 2, 10)
SET IDENTITY_INSERT [dbo].[Resenia] OFF
GO
SET IDENTITY_INSERT [dbo].[ReseniaCarrera] ON 

INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (1, N'Estudiar Ingeniería Aeronáutica es una experiencia intensa pero muy gratificante. Es una carrera pensada para gente curiosa, meticulosa y que disfruta entender cómo funcionan las cosas a nivel profundo. Desde el primer año ya te das cuenta de que no es una ingeniería cualquiera: todo lo que aprendés tiene una aplicación directa en el mundo real, desde el diseño de alas y turbinas hasta la aerodinámica que usan los aviones modernos.

Lo mejor de la carrera es que combina física, matemática y mucha ingeniería aplicada. Si te gustan los desafíos técnicos, la sensación de descubrir por qué vuela algo y cómo hacerlo más eficiente, te va a encantar. Además, los laboratorios y las materias de dinámica de fluidos son increíbles; cuando entendés por fin un modelo o un simulador de vuelo, sentís que realmente estás aprendiendo algo grande.

Ahora, lo malo: la carga académica es pesada. De verdad. Hay materias que te pueden consumir semanas enteras, y muchas veces los trabajos prácticos son largos y exigentes. También es una carrera que pide mucha constancia; si te colgás, después cuesta recuperar el ritmo. Y, dependiendo de la universidad, la salida laboral puede estar muy concentrada en ciertos sectores (aviación, aeroespacial, mantenimiento, investigación), así que hay que saber bien hacia dónde apuntar.

En general, Ingeniería Aeronáutica es una carrera para personas apasionadas por el mundo del vuelo, con ganas de meterse a fondo en temas técnicos complejos y con paciencia para enfrentar una curva de aprendizaje empinada. Si eso te motiva, es una carrera espectacular.', 1, 1)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (2, N'Odontología es una carrera que sorprende más de lo que uno espera. Mucha gente piensa que se trata solo de “arreglar dientes”, pero cuando empezás a cursarla descubrís que es muchísimo más compleja y profunda. Hay anatomía, biología, microbiología, materiales, cirugía, estética, prótesis… literalmente un mundo entero dentro de la boca que antes ni registrabas.

Lo mejor de la carrera es la mezcla entre ciencia y trabajo manual. Si sos detallista, paciente y te gusta trabajar con precisión milimétrica, vas a disfrutar cada práctica. La sensación de ver que algo que hiciste con tus manos mejora la vida de otra persona es realmente única. Además, la salida laboral es muy amplia: podés trabajar por tu cuenta, en clínicas, especializarte en ortodoncia, cirugía, endodoncia… hay camino para todos los perfiles.

Pero no todo es perfecto. La carrera es larga, exigente y muchas veces cara: los materiales, los instrumentos y las prácticas clínicas suelen ser un gasto constante. También requiere una gran responsabilidad emocional; tratás con personas que tienen dolor, miedo o ansiedad, y eso te obliga a desarrollar empatía y mucha paciencia. Y a nivel académico, también es un desafío: anatomía y las materias básicas suelen ser un filtro bastante duro.

Aun así, para quienes disfrutan el contacto con pacientes, tienen buena motricidad fina y no les asusta estudiar en serio, Odontología termina siendo una carrera muy gratificante. Te forma no solo como profesional, sino también como alguien que puede ayudar de forma directa, visible y concreta a mejorar la salud de los demás.', 2, 4)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (3, N'La Licenciatura en Ciencias Biológicas es una carrera para quienes realmente sienten curiosidad por entender cómo funciona la vida en todas sus formas. Desde el primer año te encontrás con un abanico enorme de temas: genética, ecología, fisiología, zoología, microbiología, botánica… es como abrir una puerta a un universo que siempre estuvo ahí, pero del que recién ahora empezás a ver los detalles.

Lo mejor de la carrera es ese sentido constante de descubrimiento. Cada materia te muestra procesos que antes dabas por obvios: cómo respiran las plantas, por qué muta un virus, cómo se organiza una comunidad ecológica, o cómo se comunican las células entre sí. Si te gusta la ciencia de verdad —esa mezcla de curiosidad, paciencia y método—, te vas a sentir en tu elemento. Además, la posibilidad de hacer investigación desde temprano es un plus enorme.

Sin embargo, no todo es color de rosas. Es una carrera exigente, con mucha carga de lectura, laboratorio y estadísticas (sí, más de lo que pensás). A veces puede volverse frustrante porque los resultados experimentales no siempre salen como uno quiere, y la salida laboral es un poco más acotada si no estás dispuesto a seguir estudiando, especializarte o meterte en investigación o docencia. No es una carrera que suele ofrecer un camino laboral inmediato y amplio.

Aun así, para quienes sienten pasión por los organismos, los ecosistemas, la biología molecular o cualquier pregunta relacionada con la vida, la carrera es increíble. Te forma con una mirada científica muy sólida, te da herramientas para investigar y te permite contribuir a campos que van desde la conservación hasta la biotecnología. Es una carrera para mentes curiosas, pacientes y comprometidas con la ciencia.', 3, 5)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (4, N'Estudiar Cine es meterse en un mundo creativo que combina arte, técnica y un montón de trabajo en equipo. Desde el primer día te das cuenta de que no es solo “ver películas”: es aprender a pensar en imágenes, en ritmos, en emociones, en cómo contar historias de una manera que realmente llegue a la gente. Es una carrera ideal si te apasiona la narrativa y te gusta expresarte a través de lo visual.

Lo más lindo de la carrera es que cada proyecto se siente como un desafío nuevo. Un corto puede llevarte semanas de planificación, rodaje y edición, pero cuando lo ves terminado sentís una mezcla de orgullo y alivio que pocas cosas te dan. Aprendés a manejar cámaras, luces, sonido, montaje, dirección y guion. Y si te gusta crear, vas a sentir que estás exactamente donde tenés que estar.

Ahora, lo que no siempre se dice: es una carrera con mucha exigencia práctica. Vas a tener que quedarte hasta tarde editando, coordinar equipos que a veces no funcionan como quisieras y lidiar con frustraciones cuando una escena no sale o el clima arruina todo un rodaje. Además, la salida laboral es real pero no automática: requiere contactos, constancia y ganas de moverte. Es un ambiente competitivo y muchas veces inestable.

A pesar de eso, estudiar Cine te abre la cabeza. Te enseña a mirar el mundo de otro modo, con más sensibilidad y más atención. Si tenés vocación por contar historias, si disfrutás del proceso creativo y si no te asusta trabajar bajo presión, es una carrera que vale muchísimo la pena. Te da herramientas que no solo sirven para filmar, sino también para comunicar, liderar equipos y producir ideas que pueden llegar muy lejos.', 4, 3)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (5, N'Terapia Ocupacional es una carrera que sorprende por la profundidad humana que tiene. Mucha gente la conoce solo de nombre, pero cuando empezás a estudiarla te das cuenta de que es una profesión súper completa: trabaja con personas de todas las edades para ayudarlas a desarrollar autonomía, recuperar habilidades o mejorar su calidad de vida a través de actividades concretas y significativas.

Lo más valioso de la carrera es el impacto directo que tenés en la vida de los demás. Aprendés a trabajar con personas con discapacidades físicas, neurológicas, sensoriales o sociales, y entendés que cada intervención se construye a partir del vínculo, la escucha y la creatividad. No es una profesión rígida: al contrario, te exige pensar soluciones originales y adaptadas a cada persona. Ver a un paciente progresar, aunque sea un poco, es una satisfacción enorme.

En lo académico, la carrera mezcla ciencias de la salud, rehabilitación, psicología y pedagogía. Es variada y dinámica, pero también exigente. Las prácticas son intensas emocionalmente, porque muchas veces acompañás situaciones complejas. Tenés que aprender a manejar frustraciones, límites y tiempos que no dependen de vos. También requiere mucha empatía y energía para trabajar con personas en momentos vulnerables.

La salida laboral es buena y diversa: hospitales, centros de rehabilitación, geriátricos, escuelas, instituciones de salud mental, acompañamiento domiciliario, equipos interdisciplinarios… incluso podés trabajar en áreas más innovadoras como accesibilidad, inclusión laboral o diseño de dispositivos adaptados.

En síntesis, Terapia Ocupacional es una carrera para personas sensibles, pacientes y creativas, que quieran marcar una diferencia real en la vida de otras personas. No es fácil, pero es profundamente gratificante.', 5, 2)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (6, N'Agronomía es una carrera que conecta ciencia, producción y naturaleza de una forma que pocas profesiones logran. Desde el primer año entendés que no se trata solo de “campo”, sino de sistemas complejos: suelos, cultivos, clima, economía, ecología y tecnología. Es una carrera ideal para quienes disfrutan el aire libre, la biología aplicada y la resolución de problemas reales.

Lo mejor de Agronomía es su variedad. Un día estás estudiando fisiología vegetal, al otro aprendés sobre maquinaria, al otro analizás datos de rendimiento o impacto ambiental. La carrera te da una mirada muy amplia, desde la genética hasta la gestión de empresas agropecuarias. Y si te gusta la ciencia aplicada, es fascinante ver cómo pequeñas decisiones (una dosis de fertilizante, un riego, una rotación de cultivos) pueden modificar completamente un sistema productivo.

Sin embargo, no es una carrera liviana. Tiene mucha carga de campo, de laboratorio y de números. La química y la estadística aparecen más de lo que muchos esperan, y la responsabilidad es grande: trabajás con recursos naturales, ambientes frágiles y decisiones que afectan a comunidades enteras. Además, es un área donde la realidad económica y política del país impacta fuerte, para bien o para mal.

La salida laboral es muy buena: asesoramiento técnico, investigación, producción, industria agroalimentaria, manejo ambiental, empresas agropecuarias, organismos públicos, docencia y más. Pero también es un rubro competitivo, donde la experiencia práctica y los contactos valen muchísimo.

En resumen, Agronomía es una carrera para personas curiosas, prácticas y con ganas de trabajar en contacto con sistemas vivos y cambiantes. Si te interesa el campo desde una mirada científica y moderna, es una carrera muy completa y con futuro.', 6, 6)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (7, N'La Ingeniería Aeronáutica es una carrera que te cambia la cabeza. Entrás pensando que vas a aprender “cómo vuelan los aviones” y terminás descubriendo un universo muchísimo más amplio, lleno de detalles que jamás imaginaste. No es solo física o matemática: es una forma distinta de mirar el mundo, donde cada fuerza, cada material y cada diseño tiene una razón de ser.

Lo que más me gustó de la carrera es que nunca te deja en piloto automático (ironías de la vida). Siempre te está exigiendo un poco más: cuando creés que entendiste aerodinámica, aparece estabilidad de vuelo; cuando te sentís cómodo con estructuras, llega un trabajo práctico que te hace replantear todo. Esa exigencia constante, aunque agotadora, también es lo que la hace tan emocionante. Sentís que estás estudiando algo grande, algo que mueve al mundo.

Eso sí, no voy a mentir: a veces puede ser frustrante. Hay materias que se sienten como muros de concreto y profesores que ya asumieron que sos un mini-NASA y no un estudiante común. Y si no te gusta estudiar de verdad —horas y horas—, esta carrera te pasa por encima. La presión existe, y es parte del camino.

Pero cuando te das cuenta de que podés leer un manual técnico real, o analizar por qué un avión se comporta como se comporta, o resolver un problema que hace unos meses parecía imposible, ahí entendés por qué te metiste. Te da una mezcla de orgullo y fascinación que pocas carreras logran.

Ingeniería Aeronáutica no es para todos, pero para quienes encuentran pasión en el cielo, la mecánica y los desafíos, es una carrera que vale cada esfuerzo.', 1, 7)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (8, N'Estudiar Odontología es meterse en una carrera donde el detalle lo es todo. Desde afuera parece algo simple, pero cuando empezás te das cuenta de que estás entrando a un mundo extremadamente técnico, donde cada milímetro importa y cada procedimiento requiere pulso firme y cabeza fría. No es solo teoría: es entrenar tus manos, tu paciencia y tu capacidad de concentrarte por largos períodos.

La parte más linda de la carrera es que ves resultados concretos. No es algo abstracto: ayudás a alguien a sonreír mejor, a sacarse un dolor que lo venía matando o a recuperar algo que creía perdido. Eso genera una satisfacción personal enorme. Además, a diferencia de otras carreras, la autonomía profesional es real: si querés, podés tener tu propio espacio, armar tu consultorio y trabajar a tu ritmo.

Pero también tiene su lado pesado. La inversión económica es continua: insumos, materiales, instrumental… y eso puede ser un dolor de cabeza. Las prácticas también pueden ser desgastantes, porque no todos los pacientes son iguales: algunos tienen miedo, otros no colaboran, otros vienen en situaciones complejas. Y a nivel académico, las materias de base —anatomía, biofísica, histología— te obligan a estudiar muchísimo y no dejar nada al azar.

A pesar de eso, quien realmente disfruta la mezcla entre ciencia y trabajo manual encuentra en Odontología una carrera muy apasionante. Te exige, pero también te da herramientas para impactar de forma directa en la calidad de vida de las personas. Si te gustan los desafíos que se resuelven con precisión y humanidad, es una carrera que vale la pena.', 2, 8)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (9, N'Cursar Ciencias Biológicas es una experiencia que te cambia la manera de mirar el mundo. Al principio entrás pensando que vas a estudiar “animales, plantas y células”, pero a medida que avanzás te das cuenta de que la carrera es muchísimo más profunda. Te enseña a cuestionar todo: cómo funciona un organismo, cómo se relacionan las especies, por qué ocurre una enfermedad o cómo se equilibra un ecosistema. De repente, la vida cotidiana empieza a tener explicaciones que antes ni imaginabas.

Lo que más disfruto de esta carrera es la sensación constante de descubrimiento. Hay materias que te vuelan la cabeza —genética, microbiología, biología molecular— porque te muestran procesos invisibles que sin embargo sostienen la vida entera. Y los trabajos de campo son un capítulo aparte: salir a muestrear, tomar datos, observar comportamientos… te hace sentir que realmente sos parte del proceso científico, no solo un estudiante.

Pero no voy a mentir: también tiene momentos duros. Hay mucho contenido, mucha lectura técnica y estadísticas por todos lados. Los resultados de laboratorio pueden tardar semanas y aun así salir mal. Además, si no te interesa la investigación o la docencia, la salida laboral puede sentirse algo limitada en comparación con otras carreras más “directas”.

Aun así, Ciencias Biológicas es una carrera que recompensa a quienes tienen curiosidad genuina y paciencia. Te forma una mentalidad científica sólida, te enseña a pensar en sistemas complejos y te da la posibilidad de trabajar en temas realmente importantes: salud, ambiente, conservación, biotecnología. Es una carrera para quienes sienten fascinación por la vida en todas sus escalas.', 3, 9)
INSERT [dbo].[ReseniaCarrera] ([idReseniaCarrera], [mensaje], [idCarrera], [idUsuario]) VALUES (10, N'La carrera de Cine es un viaje creativo que mezcla emoción, frustración, descubrimiento y mucho, pero mucho trabajo. Entrás porque te gusta contar historias, pero terminás entendiendo que el cine es también matemática, organización, sensibilidad, improvisación y un nivel de detalle que nunca habías imaginado. Cada plano, cada corte y cada silencio tienen un sentido, y aprender eso te cambia la manera de ver películas para siempre.

Lo que más me marcó de la carrera es la sensación de comunidad. Los rodajes crean vínculos raros: tenés momentos caóticos, discusiones, risas a las 3 de la mañana mientras filmás una escena que salió mal diez veces seguidas… y aun así, cuando ves el resultado, todo ese desgaste tiene un sentido. Es una carrera donde aprendés a trabajar con otros, a confiar, a delegar y a resolver problemas rápido.

Pero no es un camino fácil. La exigencia práctica es alta y el ritmo puede ser agotador. Hay semanas donde vivís editando, o donde una materia te pide un corto entero en poco tiempo. Y sí, la salida laboral depende mucho de hacer contactos, moverte, mostrar tu trabajo y aceptar que al principio los proyectos quizás no sean tan glamorosos como imaginabas. También necesitas mucha tolerancia a la frustración: en cine las cosas rara vez salen bien a la primera.

Aun así, si te mueve la creación artística, si disfrutás pensar en emociones, encuadres, atmósferas y si sos de los que sienten algo especial cuando una escena está “justa”, esta carrera te puede fascinar. El cine te obliga a crecer, a mirar distinto y a convertir ideas en algo real. Y cuando lográs eso, aunque sea en un proyecto pequeño, sentís que valió completamente la pena.', 4, 10)
SET IDENTITY_INSERT [dbo].[ReseniaCarrera] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (1, N'Juan', N'Pérez', N'titulo_juan.jpg', N'Ingeniería Aeronáutica', N'juanperez@gmail.com', N'12345', N'juanp', 1, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (2, N'María', N'López', N'titulo_maria.jpg', N'Odontología', N'marialopez@gmail.com', N'abcd1234', N'marial', 2, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (3, N'Lucas', N'Gómez', N'titulo_lucas.jpg', N'Lic. en Ciencias Biológicas', N'lucasgomez@gmail.com', N'pass123', N'lucasg', 3, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (4, N'Camila', N'Rodríguez', N'titulo_camila.jpg', N'Cine', N'camilarodriguez@gmail.com', N'cine2024', N'camiro', 4, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (5, N'Sofía', N'Martínez', N'titulo_sofia.jpg', N'Terapia Ocupacional', N'sofia.martinez@gmail.com', N'sofi2025', N'sofiam', 5, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (6, N'Agustín', N'Fernández', N'titulo_agustin.jpg', N'Agronomía', N'agustin.fernandez@gmail.com', N'agro321', N'agustinf', 6, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (7, N'Valentina', N'Torres', N'titulo_valen.jpg', N'Ingeniería Aeronáutica', N'valentina.torres@gmail.com', N'aero2025', N'valentor', 7, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (8, N'Nicolás', N'Sosa', N'titulo_nico.jpg', N'Odontología', N'nico.sosa@gmail.com', N'odonto', N'nicos', 8, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (9, N'Lucía', N'Vega', N'titulo_lucia.jpg', N'Lic. en Ciencias Biológicas', N'lucia.vega@gmail.com', N'bio123', N'luciav', 1, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (10, N'Martín', N'Díaz', N'titulo_martin.jpg', N'Cine', N'martin.diaz@gmail.com', N'cinepass', N'martind', 2, 1, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (12, N'Juan', N'López', NULL, NULL, N'juanT@gmail.com', N'juancho', N'juaneto01', NULL, 0, N'/icon-7797704_640.png')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [apellido], [fotoTituloUni], [carrera], [gmail], [contrasenia], [username], [idFacultad], [rol], [fotoPerfil]) VALUES (13, N'facundo', N'peri', N'.jpg', N'Cine', N'facuperi@gmail.com', N'facu123', N'facuchi', 1, 1, N'/icon-7797704_640.png')
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
