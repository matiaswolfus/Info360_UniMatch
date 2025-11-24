-- Script para actualizar las rutas de las fotos de las universidades
-- Ejecutar este script en SQL Server Management Studio

USE [info360 Unimatch]
GO

-- Actualizar las rutas de las fotos de facultades para que coincidan con los archivos en wwwroot/img
UPDATE [dbo].[Facultad] SET [fotoFacultad] = '/img/uade2.png' WHERE [idFacultad] = 1; -- UADE
UPDATE [dbo].[Facultad] SET [fotoFacultad] = '/img/ditella.png' WHERE [idFacultad] = 2; -- Universidad Torcuato Di Tella
UPDATE [dbo].[Facultad] SET [fotoFacultad] = '/img/utn.png' WHERE [idFacultad] = 3; -- UTN
UPDATE [dbo].[Facultad] SET [fotoFacultad] = '/img/itba.png' WHERE [idFacultad] = 4; -- ITBA
UPDATE [dbo].[Facultad] SET [fotoFacultad] = '/img/up.png' WHERE [idFacultad] = 5; -- Universidad de Palermo
UPDATE [dbo].[Facultad] SET [fotoFacultad] = '/img/uflo.jpg' WHERE [idFacultad] = 6; -- UFLO
UPDATE [dbo].[Facultad] SET [fotoFacultad] = '/img/ub.jpg' WHERE [idFacultad] = 7; -- Universidad de Belgrano
UPDATE [dbo].[Facultad] SET [fotoFacultad] = '/img/logo.png' WHERE [idFacultad] = 8; -- Universidad Leonardo Da Vinci (usando logo.png como placeholder)

GO

-- Verificar los cambios
SELECT [idFacultad], [nombre], [fotoFacultad] FROM [dbo].[Facultad]
GO
