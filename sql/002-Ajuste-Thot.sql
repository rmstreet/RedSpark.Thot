IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Coment] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    [Description] nvarchar(500) NULL,
    CONSTRAINT [PK_Coment] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Skills] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    [Username] varchar NULL,
    [Password] varchar NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [ImageUrl] nvarchar(500) NULL,
    [Name] nvarchar(max) NULL,
    [Resume] nvarchar(1000) NULL,
    [Job] nvarchar(50) NULL,
    [Phone] nvarchar(max) NULL,
    [UrlGithub] nvarchar(500) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Lead] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    [Title] varchar NOT NULL,
    [CreatedById] int NOT NULL,
    [Status] varchar NOT NULL,
    CONSTRAINT [PK_Lead] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Lead_Users_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [PersonSkill] (
    [PersonId] int NOT NULL,
    [SkillId] int NOT NULL,
    [Id] int NOT NULL,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    CONSTRAINT [PK_PersonSkill] PRIMARY KEY ([PersonId], [SkillId]),
    CONSTRAINT [FK_PersonSkill_Users_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonSkill_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Project] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    [LogoUrl] nvarchar(500) NULL,
    [Name] nvarchar(max) NOT NULL,
    [Company] nvarchar(max) NOT NULL,
    [Description] nvarchar(1000) NULL,
    [BeginDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [ResponsibleId] int NOT NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Project_Users_ResponsibleId] FOREIGN KEY ([ResponsibleId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [LeadComent] (
    [LeadId] int NOT NULL,
    [ComentId] int NOT NULL,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [AnswerLeadId] int NULL,
    [AnswerComentId] int NULL,
    CONSTRAINT [PK_LeadComent] PRIMARY KEY ([LeadId], [ComentId]),
    CONSTRAINT [FK_LeadComent_Coment_ComentId] FOREIGN KEY ([ComentId]) REFERENCES [Coment] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_LeadComent_Users_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Users] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_LeadComent_Lead_LeadId] FOREIGN KEY ([LeadId]) REFERENCES [Lead] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_LeadComent_LeadComent_AnswerLeadId_AnswerComentId] FOREIGN KEY ([AnswerLeadId], [AnswerComentId]) REFERENCES [LeadComent] ([LeadId], [ComentId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PersonLead] (
    [PersonId] int NOT NULL,
    [LeadId] int NOT NULL,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    CONSTRAINT [PK_PersonLead] PRIMARY KEY ([LeadId], [PersonId]),
    CONSTRAINT [FK_PersonLead_Lead_LeadId] FOREIGN KEY ([LeadId]) REFERENCES [Lead] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonLead_Users_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProjectPerson] (
    [ProjectId] int NOT NULL,
    [PersonId] int NOT NULL,
    [Id] int NOT NULL,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    CONSTRAINT [PK_ProjectPerson] PRIMARY KEY ([ProjectId], [PersonId]),
    CONSTRAINT [FK_ProjectPerson_Users_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProjectPerson_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Project] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProjectSkill] (
    [ProjectId] int NOT NULL,
    [SkillId] int NOT NULL,
    [Id] int NOT NULL,
    [UpdateDate] datetime2 NULL,
    [CreateDate] datetime2 NOT NULL,
    CONSTRAINT [PK_ProjectSkill] PRIMARY KEY ([ProjectId], [SkillId]),
    CONSTRAINT [FK_ProjectSkill_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Project] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProjectSkill_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Lead_CreatedById] ON [Lead] ([CreatedById]);

GO

CREATE INDEX [IX_LeadComent_ComentId] ON [LeadComent] ([ComentId]);

GO

CREATE INDEX [IX_LeadComent_CreatedById] ON [LeadComent] ([CreatedById]);

GO

CREATE INDEX [IX_LeadComent_AnswerLeadId_AnswerComentId] ON [LeadComent] ([AnswerLeadId], [AnswerComentId]);

GO

CREATE INDEX [IX_PersonLead_PersonId] ON [PersonLead] ([PersonId]);

GO

CREATE INDEX [IX_PersonSkill_SkillId] ON [PersonSkill] ([SkillId]);

GO

CREATE INDEX [IX_Project_ResponsibleId] ON [Project] ([ResponsibleId]);

GO

CREATE INDEX [IX_ProjectPerson_PersonId] ON [ProjectPerson] ([PersonId]);

GO

CREATE INDEX [IX_ProjectSkill_SkillId] ON [ProjectSkill] ([SkillId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190723185602_InitialCreate-Thot', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Lead] DROP CONSTRAINT [FK_Lead_Users_CreatedById];

GO

ALTER TABLE [LeadComent] DROP CONSTRAINT [FK_LeadComent_Users_CreatedById];

GO

ALTER TABLE [PersonLead] DROP CONSTRAINT [FK_PersonLead_Users_PersonId];

GO

ALTER TABLE [PersonSkill] DROP CONSTRAINT [FK_PersonSkill_Users_PersonId];

GO

ALTER TABLE [Project] DROP CONSTRAINT [FK_Project_Users_ResponsibleId];

GO

ALTER TABLE [ProjectPerson] DROP CONSTRAINT [FK_ProjectPerson_Users_PersonId];

GO

ALTER TABLE [Users] DROP CONSTRAINT [PK_Users];

GO

EXEC sp_rename N'[Users]', N'Person';

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProjectSkill]') AND [c].[name] = N'UpdateDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ProjectSkill] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ProjectSkill] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProjectSkill]') AND [c].[name] = N'CreateDate');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProjectSkill] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [ProjectSkill] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProjectPerson]') AND [c].[name] = N'UpdateDate');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ProjectPerson] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [ProjectPerson] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProjectPerson]') AND [c].[name] = N'CreateDate');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ProjectPerson] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [ProjectPerson] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'UpdateDate');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Project] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'CreateDate');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Project] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonSkill]') AND [c].[name] = N'UpdateDate');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [PersonSkill] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [PersonSkill] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonSkill]') AND [c].[name] = N'CreateDate');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [PersonSkill] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [PersonSkill] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonLead]') AND [c].[name] = N'UpdateDate');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [PersonLead] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [PersonLead] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonLead]') AND [c].[name] = N'CreateDate');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [PersonLead] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [PersonLead] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LeadComent]') AND [c].[name] = N'UpdateDate');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [LeadComent] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [LeadComent] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LeadComent]') AND [c].[name] = N'CreateDate');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [LeadComent] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [LeadComent] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lead]') AND [c].[name] = N'UpdateDate');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Lead] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Lead] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lead]') AND [c].[name] = N'CreateDate');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Lead] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Lead] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Coment]') AND [c].[name] = N'UpdateDate');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Coment] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Coment] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Coment]') AND [c].[name] = N'CreateDate');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Coment] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [Coment] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'UpdateDate');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [Person] ALTER COLUMN [UpdateDate] datetime NULL;

GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'CreateDate');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [Person] ALTER COLUMN [CreateDate] datetime NOT NULL;

GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'Resume');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [Person] ALTER COLUMN [Resume] varchar NULL;

GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'Name');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [Person] ALTER COLUMN [Name] varchar NULL;

GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'Job');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [Person] ALTER COLUMN [Job] varchar NULL;

GO

ALTER TABLE [Person] ADD CONSTRAINT [PK_Person] PRIMARY KEY ([Id]);

GO

ALTER TABLE [Lead] ADD CONSTRAINT [FK_Lead_Person_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Person] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [LeadComent] ADD CONSTRAINT [FK_LeadComent_Person_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Person] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [PersonLead] ADD CONSTRAINT [FK_PersonLead_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [PersonSkill] ADD CONSTRAINT [FK_PersonSkill_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [Project] ADD CONSTRAINT [FK_Project_Person_ResponsibleId] FOREIGN KEY ([ResponsibleId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [ProjectPerson] ADD CONSTRAINT [FK_ProjectPerson_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190723194121_AddEAjuste-Thot', N'2.2.6-servicing-10079');

GO

