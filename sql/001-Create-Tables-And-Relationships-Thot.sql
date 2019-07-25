IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Person] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    [Username] varchar(50) NULL,
    [Password] varchar(50) NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [ImageUrl] varchar(500) NULL,
    [Name] varchar(100) NULL,
    [Resume] varchar(1000) NULL,
    [Job] varchar(50) NULL,
    [Phone] varchar(11) NULL,
    [UrlGithub] varchar(500) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Skill] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    CONSTRAINT [PK_Skill] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Lead] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    [Title] varchar(60) NOT NULL,
    [CreatedById] int NOT NULL,
    [Status] varchar(15) NOT NULL,
    CONSTRAINT [PK_Lead] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Lead_Person_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Project] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    [LogoUrl] varchar(500) NULL,
    [Name] varchar(100) NOT NULL,
    [Company] varchar(100) NOT NULL,
    [Description] varchar(1000) NULL,
    [BeginDate] datetime NOT NULL,
    [EndDate] datetime NOT NULL,
    [ResponsibleId] int NOT NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Project_Person_ResponsibleId] FOREIGN KEY ([ResponsibleId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PersonSkill] (
    [PersonId] int NOT NULL,
    [SkillId] int NOT NULL,
    [Id] int NOT NULL,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    CONSTRAINT [PK_PersonSkill] PRIMARY KEY ([PersonId], [SkillId]),
    CONSTRAINT [FK_PersonSkill_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonSkill_Skill_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skill] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Coment] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    [Description] varchar(500) NULL,
    [LeadId] int NOT NULL,
    [FatherComentId] int NULL,
    [CreatedById] int NOT NULL,
    CONSTRAINT [PK_Coment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Coment_Person_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Person] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Coment_Coment_FatherComentId] FOREIGN KEY ([FatherComentId]) REFERENCES [Coment] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Coment_Lead_LeadId] FOREIGN KEY ([LeadId]) REFERENCES [Lead] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [PersonLead] (
    [PersonId] int NOT NULL,
    [LeadId] int NOT NULL,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    CONSTRAINT [PK_PersonLead] PRIMARY KEY ([LeadId], [PersonId]),
    CONSTRAINT [FK_PersonLead_Lead_LeadId] FOREIGN KEY ([LeadId]) REFERENCES [Lead] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonLead_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProjectPerson] (
    [ProjectId] int NOT NULL,
    [PersonId] int NOT NULL,
    [Id] int NOT NULL,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    CONSTRAINT [PK_ProjectPerson] PRIMARY KEY ([ProjectId], [PersonId]),
    CONSTRAINT [FK_ProjectPerson_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProjectPerson_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Project] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProjectSkill] (
    [ProjectId] int NOT NULL,
    [SkillId] int NOT NULL,
    [Id] int NOT NULL,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    CONSTRAINT [PK_ProjectSkill] PRIMARY KEY ([ProjectId], [SkillId]),
    CONSTRAINT [FK_ProjectSkill_Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Project] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProjectSkill_Skill_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skill] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Coment_CreatedById] ON [Coment] ([CreatedById]);

GO

CREATE INDEX [IX_Coment_FatherComentId] ON [Coment] ([FatherComentId]);

GO

CREATE INDEX [IX_Coment_LeadId] ON [Coment] ([LeadId]);

GO

CREATE INDEX [IX_Lead_CreatedById] ON [Lead] ([CreatedById]);

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
VALUES (N'20190725001616_Create-Tables-And-Relationships-Thot', N'2.2.6-servicing-10079');

GO

