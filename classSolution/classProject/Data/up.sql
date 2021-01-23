-- UP script for SQL Server

CREATE TABLE [Peak] (
  [ID]              INT PRIMARY KEY IDENTITY(1, 1),
  [Name]            NVARCHAR(30) NOT NULL,
  [Height]          INT NOT NULL,
  [ClimbingStatus]  BIT NOT NULL,
  [FirstAscentYear] INT
)
GO

CREATE TABLE [Expedition] (
  [ID]                INT PRIMARY KEY IDENTITY(1, 1),
  [Season]            NVARCHAR(10),
  [Year]              INT,
  [StartDate]         DATE,
  [TerminationReason] NVARCHAR(80),
  [OxygenUsed]        BIT,
  [PeakID]            INT,
  [TrekkingAgencyID]  INT,
  [LoginID]           INT
)
GO

CREATE TABLE [TrekkingAgency] (
  [ID]    INT PRIMARY KEY IDENTITY(1, 1),
  [Name]  NVARCHAR(100)
)
GO

CREATE TABLE [Login] (
  [ID]          INT PRIMARY KEY IDENTITY(1, 1),
  [Username]    NVARCHAR(31),
  [Password]    NVARCHAR(31),
  [IsAdmin]     BIT
)
GO

ALTER TABLE [Expedition] ADD CONSTRAINT [Expedition_FK_Peak] FOREIGN KEY ([PeakID]) REFERENCES [Peak] ([ID])
ALTER TABLE [Expedition] ADD CONSTRAINT [Expedition_FK_TrekkingAgency] FOREIGN KEY ([TrekkingAgencyID]) REFERENCES [TrekkingAgency] ([ID])
ALTER TABLE [Expedition] ADD CONSTRAINT [Expedition_FK_Login] FOREIGN KEY ([LoginID]) REFERENCES [Login] ([ID])
GO
