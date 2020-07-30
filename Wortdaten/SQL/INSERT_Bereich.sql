DELETE FROM [dbo].[Bereich]
DBCC CHECKIDENT ('[Bereich]', RESEED, 0);
GO

INSERT INTO [dbo].[Bereich]
SELECT BereichNr, BereichName
FROM [dbo].[Wortdaten_Bereiche]
