IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wortdaten_Vokabeln]') AND type in (N'U'))
DROP TABLE [dbo].[Wortdaten_Vokabeln]
GO
