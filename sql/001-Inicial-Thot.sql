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

