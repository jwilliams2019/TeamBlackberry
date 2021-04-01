-- up script

USE [BerylDB];

CREATE TABLE [Event] (
    [ID]            INT PRIMARY KEY IDENTITY(1,1),
    [TypeID]        INT NOT NULL,
    [AccountID]     INT NOT NULL,
    [Title]         NVARCHAR(63),
    [StartDateTime] DATETIME NOT NULL,
    [EndDateTime]   DATETIME NOT NULL,
    [Location]      NVARCHAR(127)
);

CREATE TABLE [Account] (
    [ID]        INT PRIMARY KEY IDENTITY(1,1),
    [Username]  NVARCHAR(31)
);

CREATE TABLE [Type] (
    [ID]        INT PRIMARY KEY IDENTITY(1,1),
    [Name]      NVARCHAR(15)
);

ALTER TABLE [Event] ADD CONSTRAINT [Event_FK_Type] FOREIGN KEY ([TypeID]) REFERENCES [Type] ([ID]);

ALTER TABLE [Event] ADD CONSTRAINT [Event_FK_Account] FOREIGN KEY ([AccountID]) REFERENCES [Account] ([ID]);