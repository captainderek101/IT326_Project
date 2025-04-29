USE [master]
GO

/****** Object:  Table [dbo].[UserPostRatings]    Script Date: 4/29/2025 1:26:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS UserPostRatings;

CREATE TABLE [dbo].[UserPostRatings](
	[userID] [int] NOT NULL,
	[postID] [int] NOT NULL,
	[ratingID] [int] IDENTITY(1,1) NOT NULL,
	[upvote] [bit] NOT NULL,
	[downvote] [bit] NOT NULL,
	PRIMARY KEY (ratingID),
	FOREIGN KEY (userID) REFERENCES Users(userID),
	FOREIGN KEY (postID) REFERENCES Posts(postID)
) ON [PRIMARY]
GO


