-- up script

USE [BerylDB];
GO

CREATE TABLE [Event] (
    [ID]        INT PRIMARY KEY IDENTITY(1,1),
    [TypeID]    INT NOT NULL,
    [AccountID] INT NOT NULL,
    [Title]     NVARCHAR(63),
    [StartTime] DATETIME NOT NULL,
    [EndTime]   DATETIME NOT NULL,
    [Location]  NVARCHAR(127)
);
GO

CREATE TABLE [Account] (
    [ID]        INT PRIMARY KEY IDENTITY(1,1),
    [Username]  NVARCHAR(31)
);
GO

CREATE TABLE [Type] (
    [ID]        INT PRIMARY KEY IDENTITY(1,1),
    [Name]      NVARCHAR(15)
);
GO

ALTER TABLE [Event] ADD CONSTRAINT [Event_FK_Type] FOREIGN KEY ([TypeID]) REFERENCES [Type] ([ID]);
GO

ALTER TABLE [Event] ADD CONSTRAINT [Event_FK_Account] FOREIGN KEY ([AccountID]) REFERENCES [Account] ([ID]);
GO