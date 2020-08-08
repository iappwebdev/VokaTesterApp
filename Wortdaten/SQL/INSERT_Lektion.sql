DELETE FROM [dbo].[Lektion]
DBCC CHECKIDENT ('[Lektion]', RESEED, 0);
GO

SET IDENTITY_INSERT [dbo].[Lektion] ON;
GO

INSERT INTO [dbo].[Lektion]
           ([Id]
		   ,[Key]
           ,[Name]
           ,[Titel]
           ,[SubTitel]
           ,[Inhalt])
SELECT SeedId, LektionKey, LektionName, Titel, SubTitel, Inhalt
FROM [dbo].[Wortdaten_Lektionen]

SET IDENTITY_INSERT [dbo].[Lektion] OFF;