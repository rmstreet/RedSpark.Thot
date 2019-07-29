IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Role] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(256) NULL,
    [NormalizedName] varchar(256) NULL,
    [ConcurrencyStamp] varchar(MAX) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Skill] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    [Name] varchar(50) NOT NULL,
    CONSTRAINT [PK_Skill] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [UserName] varchar(256) NULL,
    [NormalizedUserName] varchar(256) NULL,
    [Email] varchar(256) NULL,
    [NormalizedEmail] varchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] varchar(max) NULL,
    [SecurityStamp] varchar(max) NULL,
    [ConcurrencyStamp] varchar(max) NULL,
    [PhoneNumber] varchar(14) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [RoleClaim] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [ClaimType] varchar(max) NULL,
    [ClaimValue] varchar(max) NULL,
    CONSTRAINT [PK_RoleClaim] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RoleClaim_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Persons] (
    [Id] int NOT NULL IDENTITY,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    [ImageUrl] varchar(500) NULL,
    [Name] varchar(100) NOT NULL,
    [Resume] varchar(1000) NULL,
    [Job] varchar(50) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Phone] varchar(11) NULL,
    [UrlGithub] varchar(500) NULL,
    [Active] bit NOT NULL,
    [UserId] int NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Persons_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [UserClaim] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [ClaimType] varchar(max) NULL,
    [ClaimValue] varchar(max) NULL,
    CONSTRAINT [PK_UserClaim] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserClaim_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserLogin] (
    [LoginProvider] varchar(128) NOT NULL,
    [ProviderKey] varchar(128) NOT NULL,
    [ProviderDisplayName] varchar(max) NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserLogin] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_UserLogin_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserRole] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserToken] (
    [UserId] int NOT NULL,
    [LoginProvider] varchar(450) NOT NULL,
    [Name] varchar(450) NOT NULL,
    [Value] varchar(max) NULL,
    CONSTRAINT [PK_UserToken] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_UserToken_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
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
    CONSTRAINT [FK_Lead_Persons_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PersonSkill] (
    [PersonId] int NOT NULL,
    [SkillId] int NOT NULL,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    CONSTRAINT [PK_PersonSkill] PRIMARY KEY ([PersonId], [SkillId]),
    CONSTRAINT [FK_PersonSkill_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonSkill_Skill_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skill] ([Id]) ON DELETE CASCADE
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
    CONSTRAINT [FK_Project_Persons_ResponsibleId] FOREIGN KEY ([ResponsibleId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
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
    CONSTRAINT [FK_Coment_Persons_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Persons] ([Id]) ON DELETE CASCADE,
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
    CONSTRAINT [FK_PersonLead_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProjectPerson] (
    [ProjectId] int NOT NULL,
    [PersonId] int NOT NULL,
    [Id] int NOT NULL,
    [UpdateDate] datetime NULL,
    [CreateDate] datetime NOT NULL,
    CONSTRAINT [PK_ProjectPerson] PRIMARY KEY ([ProjectId], [PersonId]),
    CONSTRAINT [FK_ProjectPerson_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE CASCADE,
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

CREATE UNIQUE INDEX [IX_Persons_UserId] ON [Persons] ([UserId]) WHERE [UserId] IS NOT NULL;

GO

CREATE INDEX [IX_PersonSkill_SkillId] ON [PersonSkill] ([SkillId]);

GO

CREATE INDEX [IX_Project_ResponsibleId] ON [Project] ([ResponsibleId]);

GO

CREATE INDEX [IX_ProjectPerson_PersonId] ON [ProjectPerson] ([PersonId]);

GO

CREATE INDEX [IX_ProjectSkill_SkillId] ON [ProjectSkill] ([SkillId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [Role] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_RoleClaim_RoleId] ON [RoleClaim] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [User] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [User] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE INDEX [IX_UserClaim_UserId] ON [UserClaim] ([UserId]);

GO

CREATE INDEX [IX_UserLogin_UserId] ON [UserLogin] ([UserId]);

GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190729032044_Begin-ThotDb-With-Identity', N'2.2.6-servicing-10079');

GO

