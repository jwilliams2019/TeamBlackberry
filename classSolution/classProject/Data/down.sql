-- DOWN script for SQL Server

ALTER TABLE [Expedition] DROP CONSTRAINT [Expedition_FK_Peak];
ALTER TABLE [Expedition] DROP CONSTRAINT [Expedition_FK_TrekkingAgency];
ALTER TABLE [Expedition] DROP CONSTRAINT [Expedition_FK_Login];

DROP TABLE [Expedition];
DROP TABLE [Peak];
DROP TABLE [TrekkingAgency];
DROP TABLE [Login];