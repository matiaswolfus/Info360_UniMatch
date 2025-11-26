USE [info360 Unimatch]
GO

-- Actualizar la foto de la Universidad Leonardo Da Vinci
UPDATE [dbo].[Facultad] 
SET fotoFacultad = '~/davinci.jpeg' 
WHERE idFacultad = 8
GO


