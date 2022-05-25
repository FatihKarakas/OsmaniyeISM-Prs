-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/21/2022 14:14:42
-- Generated from EDMX file: C:\Users\fatih.karakas\source\repos\RFIdWebs\RFIdWebs\App_Code\Model.edmx
-- --------------------------------------------------
SET QUOTED_IDENTIFIER OFF;
GO
USE [Data2020];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO
-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------
-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
IF OBJECT_ID(N'[DataModelStoreContainer].[Personel]', 'U') IS NOT NULL
    DROP TABLE [DataModelStoreContainer].[Personel];
GO
IF OBJECT_ID(N'[DataModelStoreContainer].[Terminal]', 'U') IS NOT NULL
    DROP TABLE [DataModelStoreContainer].[Terminal];
GO
IF OBJECT_ID(N'[DataModelStoreContainer].[TestGirisCikis]', 'U') IS NOT NULL
    DROP TABLE [DataModelStoreContainer].[TestGirisCikis];
GO
-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------
-- Creating table 'Personel'
CREATE TABLE [dbo].[Personel] (
    [personel] int IDENTITY(1,1) NOT NULL,
    [Adi] nvarchar(150)  NOT NULL,
    [Soyadi] nvarchar(150)  NOT NULL,
    [SicilNo] nvarchar(50)  NULL,
    [TcKimlikNo] nvarchar(50)  NULL,
    [TerminalKod] nvarchar(50)  NOT NULL,
    [KurumId] int  NOT NULL,
    [BaskanlikId] int  NULL,
    [Aktifmi] tinyint  NOT NULL
);
GO
-- Creating table 'Terminal'
CREATE TABLE [dbo].[Terminal] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TerminalKod] nvarchar(50)  NULL,
    [IpAdres] nvarchar(50)  NOT NULL,
    [Port] int  NOT NULL,
    [Aktifmi] tinyint  NOT NULL,
    [TerminalNo] int  NULL,
    [Serial] nvarchar(50)  NULL,
    [Konumu] nvarchar(50)  NULL
);
GO
-- Creating table 'TestGirisCikis'
CREATE TABLE [dbo].[TestGirisCikis] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Kullanici] nvarchar(50)  NULL,
    [Type] int  NULL,
    [Tarih] datetime  NULL,
    [WorkCode] nvarchar(50)  NULL,
    [State] int  NULL
);
GO
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------
-- Creating primary key on [personel], [Adi], [Soyadi], [TerminalKod], [KurumId], [Aktifmi] in table 'Personel'
ALTER TABLE [dbo].[Personel]
ADD CONSTRAINT [PK_Personel]
    PRIMARY KEY CLUSTERED ([personel], [Adi], [Soyadi], [TerminalKod], [KurumId], [Aktifmi] ASC);
GO
-- Creating primary key on [ID], [IpAdres], [Port], [Aktifmi] in table 'Terminal'
ALTER TABLE [dbo].[Terminal]
ADD CONSTRAINT [PK_Terminal]
    PRIMARY KEY CLUSTERED ([ID], [IpAdres], [Port], [Aktifmi] ASC);
GO
-- Creating primary key on [UserId] in table 'TestGirisCikis'
ALTER TABLE [dbo].[TestGirisCikis]
ADD CONSTRAINT [PK_TestGirisCikis]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------