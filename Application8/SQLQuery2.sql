-- SaimaTaskDB Setup Script
-- Run this in SQL Server Management Studio or Azure Data Studio

CREATE DATABASE SaimaTaskDB;
GO

USE SaimaTaskDB;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TodoItems' AND xtype='U')
CREATE TABLE TodoItems (
    Id          INT           PRIMARY KEY IDENTITY(1,1),
    Task        NVARCHAR(500) NOT NULL,
    IsCompleted INT           NOT NULL DEFAULT 0,
    CreatedAt   NVARCHAR(100) NOT NULL
);
GO

SELECT * FROM TodoItems;
