IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wortdaten_Lektionen]') AND type in (N'U'))
DROP TABLE [dbo].[Wortdaten_Lektionen]
GO