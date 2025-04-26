USE [master]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 4/22/2025 11:30:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS Users;

CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[passwordHash] [nvarchar](max) NOT NULL,
	[emailAddress] [nvarchar](max) NULL,
	PRIMARY KEY (userID)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

SET IDENTITY_INSERT Users ON

INSERT INTO Users(userID, username, passwordHash) VALUES (1, 'anonymous', 'test');

SET IDENTITY_INSERT Users OFF
GO

