DELETE FROM [dbo].[Vokabel]
DBCC CHECKIDENT ('[Vokabel]', RESEED, 0);
GO

SET IDENTITY_INSERT [dbo].[Vokabel] ON;
GO

INSERT INTO [dbo].[Vokabel]
	([Id]
	,[SheetNr]
    ,[LektionId]
    ,[BereichId]
    ,[CaseSensitive]
    ,[Frz]
    ,[FrzSan]
    ,[Phonetik]
    ,[Deu]
    ,[DeuSan]
    ,[Wortnetze])
SELECT
	SeedId,
	Sheet,
	(SELECT Id FROM [dbo].[Lektion] WHERE Nr = LektionNr),
	(SELECT Id FROM [dbo].[Bereich] WHERE Nr = BereichNr),
	CaseSensitive,
	Frz,
	Frz_San,
	Phonetik,
	Deu,
	Deu_San,
	''
FROM [dbo].[Wortdaten_Vokabeln]
GO

SET IDENTITY_INSERT [dbo].[Vokabel] OFF;