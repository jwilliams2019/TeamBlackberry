-- down script

USE [BerylDB];

ALTER TABLE [Event] DROP CONSTRAINT [Event_FK_Type];
ALTER TABLE [Event] DROP CONSTRAINT [Event_FK_Account];

DROP TABLE [Type];
DROP TABLE [Account];
DROP TABLE [Event];