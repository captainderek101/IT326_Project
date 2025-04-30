USE [master]
GO

/****** Object:  Table [dbo].[Subscriptions]    Script Date: 4/29/2025 1:29:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS Subscriptions;

CREATE TABLE [dbo].[Subscriptions](
	[userID] [int] NOT NULL,
	[postID] [int] NOT NULL,
	[emailAddress] [nvarchar](max) NOT NULL,
	[subscriptionID] [int] IDENTITY(1,1) NOT NULL,
	[active] [bit] NOT NULL,
	PRIMARY KEY (subscriptionID),
	FOREIGN KEY (userID) REFERENCES Users(userID),
	FOREIGN KEY (postID) REFERENCES Posts(postID)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Subscriptions] ADD  CONSTRAINT [DF_Subscriptions_active]  DEFAULT ((1)) FOR [active]
GO


