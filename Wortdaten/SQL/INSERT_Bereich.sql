DELETE FROM [dbo].[Bereich]
DBCC CHECKIDENT ('[Bereich]', RESEED, 0);
GO

SET IDENTITY_INSERT [dbo].[Bereich] ON;
GO

INSERT INTO [dbo].[Bereich]
           ([Id]
		   ,[Key]
		   ,[Abkuerzung]
           ,[Name])
SELECT SeedId, BereichKey, BereichAbkuerzung, BereichName
FROM [dbo].[Wortdaten_Bereiche]


SET IDENTITY_INSERT [dbo].[Bereich] OFF;