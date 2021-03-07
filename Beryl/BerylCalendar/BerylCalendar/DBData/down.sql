-- down script

USE [BerylDB];
GO

ALTER TABLE [Event] DROP CONSTRAINT [Event_FK_Type];
ALTER TABLE [Event] DROP CONSTRAINT [Event_FK_Account];
GO

DROP TABLE [Type];
DROP TABLE [Account];
DROP TABLE [Event];
GO