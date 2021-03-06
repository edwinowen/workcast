IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'workcast')
BEGIN
  CREATE DATABASE workcast;
END;
GO

USE [workcast]
GO

CREATE TABLE Command
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Code VARCHAR(5) NOT NULL,
	CommandString VARCHAR(MAX) NOT NULL,
	EnqueueTime DATETIME NOT NULL DEFAULT GETDATE(),
	DequeueTime DATETIME,
	Complete BIT NOT NULL DEFAULT 0
)
GO
