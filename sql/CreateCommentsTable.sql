USE [master]
GO

/****** Object:  Table [dbo].[Comments]    Script Date: 4/29/2025 1:24:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS Comments;

CREATE TABLE [dbo].[Comments](
	[userID] [int] NOT NULL,
	[postID] [int] NOT NULL,
	[lastUpdated] [datetime] NULL,
	[message] [nvarchar](max) NULL,
	[commentID] [int] IDENTITY(1,1) NOT NULL,
	PRIMARY KEY (commentID),
	FOREIGN KEY (userID) REFERENCES Users(userID),
	FOREIGN KEY (postID) REFERENCES Posts(postID)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


