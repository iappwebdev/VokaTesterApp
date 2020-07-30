DELETE FROM [dbo].[Lektion]
DBCC CHECKIDENT ('[Lektion]', RESEED, 0);
GO

INSERT INTO [dbo].[Lektion]
SELECT LektionNr, LektionName, Titel, SubTitel, Inhalt
FROM [dbo].[Wortdaten_Lektionen]