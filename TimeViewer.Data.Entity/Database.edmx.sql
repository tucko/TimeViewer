
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2015 11:06:57
-- Generated from EDMX file: E:\Work\Timeviewer\TimeViever.Data\Database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TimeViewer];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CardPersonCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonCards] DROP CONSTRAINT [FK_CardPersonCard];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyDepartmentCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartmentCompanies] DROP CONSTRAINT [FK_CompanyDepartmentCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentDepartmentCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartmentCompanies] DROP CONSTRAINT [FK_DepartmentDepartmentCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentPersonDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonDepartments] DROP CONSTRAINT [FK_DepartmentPersonDepartment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cards];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[DepartmentCompanies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartmentCompanies];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[PersonCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonCards];
GO
IF OBJECT_ID(N'[dbo].[PersonDepartments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonDepartments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [EMB] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Cards'
CREATE TABLE [dbo].[Cards] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CardNumber] nvarchar(max)  NOT NULL,
    [Pin] int  NOT NULL
);
GO

-- Creating table 'PersonCards'
CREATE TABLE [dbo].[PersonCards] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DateRegistered] datetime  NOT NULL,
    [DateValid] datetime  NOT NULL,
    [CardID] int  NOT NULL,
    [Person_ID] int  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ParentDepartmentID] int  NOT NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DepartmentCompanies'
CREATE TABLE [dbo].[DepartmentCompanies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DepartmentID] int  NOT NULL,
    [CompanyID] int  NOT NULL
);
GO

-- Creating table 'PersonDepartments'
CREATE TABLE [dbo].[PersonDepartments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NOT NULL,
    [PersonID] int  NOT NULL,
    [DepartmentID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [PK_Cards]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PersonCards'
ALTER TABLE [dbo].[PersonCards]
ADD CONSTRAINT [PK_PersonCards]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'DepartmentCompanies'
ALTER TABLE [dbo].[DepartmentCompanies]
ADD CONSTRAINT [PK_DepartmentCompanies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'PersonDepartments'
ALTER TABLE [dbo].[PersonDepartments]
ADD CONSTRAINT [PK_PersonDepartments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Person_ID] in table 'PersonCards'
ALTER TABLE [dbo].[PersonCards]
ADD CONSTRAINT [FK_PersonPersonCard]
    FOREIGN KEY ([Person_ID])
    REFERENCES [dbo].[Person]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonCard'
CREATE INDEX [IX_FK_PersonPersonCard]
ON [dbo].[PersonCards]
    ([Person_ID]);
GO

-- Creating foreign key on [CardID] in table 'PersonCards'
ALTER TABLE [dbo].[PersonCards]
ADD CONSTRAINT [FK_CardPersonCard]
    FOREIGN KEY ([CardID])
    REFERENCES [dbo].[Cards]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CardPersonCard'
CREATE INDEX [IX_FK_CardPersonCard]
ON [dbo].[PersonCards]
    ([CardID]);
GO

-- Creating foreign key on [DepartmentID] in table 'DepartmentCompanies'
ALTER TABLE [dbo].[DepartmentCompanies]
ADD CONSTRAINT [FK_DepartmentDepartmentCompany]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentDepartmentCompany'
CREATE INDEX [IX_FK_DepartmentDepartmentCompany]
ON [dbo].[DepartmentCompanies]
    ([DepartmentID]);
GO

-- Creating foreign key on [CompanyID] in table 'DepartmentCompanies'
ALTER TABLE [dbo].[DepartmentCompanies]
ADD CONSTRAINT [FK_CompanyDepartmentCompany]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Companies]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyDepartmentCompany'
CREATE INDEX [IX_FK_CompanyDepartmentCompany]
ON [dbo].[DepartmentCompanies]
    ([CompanyID]);
GO

-- Creating foreign key on [PersonID] in table 'PersonDepartments'
ALTER TABLE [dbo].[PersonDepartments]
ADD CONSTRAINT [FK_PersonPersonDepartment]
    FOREIGN KEY ([PersonID])
    REFERENCES [dbo].[Person]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonDepartment'
CREATE INDEX [IX_FK_PersonPersonDepartment]
ON [dbo].[PersonDepartments]
    ([PersonID]);
GO

-- Creating foreign key on [DepartmentID] in table 'PersonDepartments'
ALTER TABLE [dbo].[PersonDepartments]
ADD CONSTRAINT [FK_DepartmentPersonDepartment]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentPersonDepartment'
CREATE INDEX [IX_FK_DepartmentPersonDepartment]
ON [dbo].[PersonDepartments]
    ([DepartmentID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------