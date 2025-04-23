USE [master]
GO

/****** Object:  Table [dbo].[Posts]    Script Date: 4/22/2025 11:27:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Posts](
	[userID] [int] NOT NULL,
	[postID] [int] IDENTITY(1,1) NOT NULL,
	[lastUpdated] [datetime] NULL,
	[dayType] [nchar](10) NULL,
	[sentiment] [nchar](10) NULL,
	[message] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

