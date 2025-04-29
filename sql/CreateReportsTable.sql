USE [master]
GO

/****** Object:  Table [dbo].[Reports]    Script Date: 4/29/2025 1:21:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS Reports;

CREATE TABLE [dbo].[Reports](
	[userID] [int] NOT NULL,
	[postID] [int] NOT NULL,
	[reportID] [int] IDENTITY(1,1) NOT NULL,
	PRIMARY KEY (reportID),
	FOREIGN KEY (userID) REFERENCES Users(userID),
	FOREIGN KEY (postID) REFERENCES Posts(postID)
) ON [PRIMARY]
GO


