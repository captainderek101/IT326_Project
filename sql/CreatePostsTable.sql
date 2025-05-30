USE [master]
GO

/****** Object:  Table [dbo].[Posts]    Script Date: 4/22/2025 11:27:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS Posts;
GO

CREATE TABLE [dbo].[Posts](
	[userID] [int] NOT NULL,
	[postID] [int] IDENTITY(1,1) NOT NULL,
	[lastUpdated] [datetime] NULL,
	[dayType] [nchar](10) NULL,
	[sentiment] [nchar](10) NULL,
	[message] [nvarchar](max) NULL,
	PRIMARY KEY (postID),
	FOREIGN KEY (userID) REFERENCES Users(userID)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF_Posts_lastUpdated]  DEFAULT (getdate()) FOR [lastUpdated]
GO

INSERT INTO Posts(userID, dayType, sentiment, message) VALUES
	(1, 'good', 'Happy', 'I had a pretty good day today!'),
	(2, 'good', 'Neutral', 'Does anyone else wonder why the sky is blue?'),
	(1, 'bad', 'Upset', 'my sister is so mean to me'),
	(3, 'good', 'Happy', 'Hey guys whats up'),
	(4, 'good', 'Neutral', 'yo mama!!!')
GO

