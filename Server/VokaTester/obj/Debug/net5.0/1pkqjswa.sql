CREATE TABLE [Lektion] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Lektion] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Fortschritt] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [LektionId] int NOT NULL,
    CONSTRAINT [PK_Fortschritt] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Fortschritt_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Fortschritt_Lektion_LektionId] FOREIGN KEY ([LektionId]) REFERENCES [Lektion] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Vokabel] (
    [Id] int NOT NULL IDENTITY,
    [LektionId] int NOT NULL,
    [Frz] nvarchar(max) NULL,
    [Deu] nvarchar(max) NULL,
    [Phonetik] nvarchar(max) NULL,
    [ImageUrl] nvarchar(max) NULL,
    CONSTRAINT [PK_Vokabel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vokabel_Lektion_LektionId] FOREIGN KEY ([LektionId]) REFERENCES [Lektion] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Fortschritt_LektionId] ON [Fortschritt] ([LektionId]);

GO

CREATE INDEX [IX_Fortschritt_UserId] ON [Fortschritt] ([UserId]);

GO

CREATE INDEX [IX_Vokabel_LektionId] ON [Vokabel] ([LektionId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200716113720_CreateTables_User_Fortschritt_Lektion_Vokabel', N'5.0.0-preview.6.20312.4');

GO

