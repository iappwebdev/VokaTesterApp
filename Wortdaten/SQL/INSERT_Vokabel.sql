--DELETE FROM [dbo].[Fortschritt]
--DELETE FROM [dbo].[TestResult]
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
	,[PositionLektion]
	,[PositionBereich]
    ,[CaseSensitive]
    ,[Frz]
    ,[FrzSan]
    ,[Phonetik]
    ,[Deu]
    ,[DeuSan])
SELECT
	SeedId,
	Sheet,
	(SELECT Id FROM [dbo].[Lektion] WHERE Id = LektionNr),
	(SELECT Id FROM [dbo].[Bereich] WHERE Abkuerzung = BereichNr),
	PosLektion,
	PosBereich,
	CaseSensitive,
	Frz,
	Frz_San,
	Phonetik,
	Deu,
	Deu_San
FROM [dbo].[Wortdaten_Vokabeln]
GO

SET IDENTITY_INSERT [dbo].[Vokabel] OFF;