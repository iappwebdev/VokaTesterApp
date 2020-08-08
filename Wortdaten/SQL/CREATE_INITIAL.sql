IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200723160201_CreateMigrationHistoryAndIdentitySchema', N'5.0.0-preview.7.20365.15');

GO

CREATE TABLE [Bereich] (
    [Id] int NOT NULL IDENTITY,
    [Key] nvarchar(100) NOT NULL,
    [Abkuerzung] nvarchar(100) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Bereich] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Lektion] (
    [Id] int NOT NULL IDENTITY,
    [Key] nvarchar(100) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Titel] nvarchar(100) NULL,
    [SubTitel] nvarchar(100) NULL,
    [Inhalt] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Lektion] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Vokabel] (
    [Id] int NOT NULL IDENTITY,
    [SheetNr] int NOT NULL,
    [LektionId] int NOT NULL,
    [BereichId] int NOT NULL,
    [PositionLektion] int NOT NULL,
    [PositionBereich] int NOT NULL,
    [CaseSensitive] bit NOT NULL,
    [Frz] nvarchar(500) NOT NULL,
    [FrzSan] nvarchar(500) NOT NULL,
    [Phonetik] nvarchar(100) NOT NULL,
    [Deu] nvarchar(500) NOT NULL,
    [DeuSan] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_Vokabel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vokabel_Bereich_BereichId] FOREIGN KEY ([BereichId]) REFERENCES [Bereich] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Vokabel_Lektion_LektionId] FOREIGN KEY ([LektionId]) REFERENCES [Lektion] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Fortschritt] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [UserName] nvarchar(max) NOT NULL,
    [LektionId] int NOT NULL,
    [BereichId] int NULL,
    [Durchlauf] int NOT NULL,
    [LetzteVokabelCorrectId] int NULL,
    [LetzteVokabelWrongId] int NULL,
    [DateTestedLast] datetime2 NOT NULL,
    CONSTRAINT [PK_Fortschritt] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Fortschritt_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Fortschritt_Bereich_BereichId] FOREIGN KEY ([BereichId]) REFERENCES [Bereich] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Fortschritt_Lektion_LektionId] FOREIGN KEY ([LektionId]) REFERENCES [Lektion] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Fortschritt_Vokabel_LetzteVokabelCorrectId] FOREIGN KEY ([LetzteVokabelCorrectId]) REFERENCES [Vokabel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Fortschritt_Vokabel_LetzteVokabelWrongId] FOREIGN KEY ([LetzteVokabelWrongId]) REFERENCES [Vokabel] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [TestResult] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [UserName] nvarchar(max) NOT NULL,
    [VokabelId] int NOT NULL,
    [Truth] nvarchar(max) NOT NULL,
    [Answer] nvarchar(max) NULL,
    [IsCorrect] bit NOT NULL,
    [IsSimilar] bit NOT NULL,
    [IsArtikelFehler] bit NOT NULL,
    [IsSimilarAndArtikelFehler] bit NOT NULL,
    [IsWrong] bit NOT NULL,
    [DateTested] datetime2 NOT NULL,
    CONSTRAINT [PK_TestResult] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TestResult_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TestResult_Vokabel_VokabelId] FOREIGN KEY ([VokabelId]) REFERENCES [Vokabel] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Fortschritt_BereichId] ON [Fortschritt] ([BereichId]);

GO

CREATE INDEX [IX_Fortschritt_LektionId] ON [Fortschritt] ([LektionId]);

GO

CREATE INDEX [IX_Fortschritt_LetzteVokabelCorrectId] ON [Fortschritt] ([LetzteVokabelCorrectId]);

GO

CREATE INDEX [IX_Fortschritt_LetzteVokabelWrongId] ON [Fortschritt] ([LetzteVokabelWrongId]);

GO

CREATE INDEX [IX_Fortschritt_UserId] ON [Fortschritt] ([UserId]);

GO

CREATE INDEX [IX_TestResult_UserId] ON [TestResult] ([UserId]);

GO

CREATE INDEX [IX_TestResult_VokabelId] ON [TestResult] ([VokabelId]);

GO

CREATE INDEX [IX_Vokabel_BereichId] ON [Vokabel] ([BereichId]);

GO

CREATE INDEX [IX_Vokabel_LektionId] ON [Vokabel] ([LektionId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200808123432_CreateVokaTesterSchema', N'5.0.0-preview.7.20365.15');

GO

