DELETE FROM [dbo].[FehlerArt]
DBCC CHECKIDENT ('[FehlerArt]', RESEED, 0);
GO

INSERT INTO [dbo].[FehlerArt]
SELECT Name, Truth, Answer
FROM [dbo].[Wortdaten_FehlerArten]
