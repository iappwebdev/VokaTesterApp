UPDATE v
SET v.[CaseSensitive] = wv.CaseSensitive,
    v.[Frz] = wv.Frz,
    v.[FrzSan] = wv.Frz_San,
    v.[Phonetik] = wv.Phonetik,
    v.[Deu] = wv.Deu,
    v.[DeuSan] = wv.Deu_San
FROM [dbo].[Vokabel] v
JOIN [dbo].[Wortdaten_Vokabeln] wv
ON wv.[SeedId] = v.Id