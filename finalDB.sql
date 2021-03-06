
/****** Object:  Table [dbo].[Category]    Script Date: 12/17/2017 14:07:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[SeqNo] [tinyint] NOT NULL,
	[ParentCategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/17/2017 14:07:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[ProductDescription] [varchar](max) NOT NULL,
	[ProductPrice] [nchar](10) NOT NULL,
	[Active] [bit] NOT NULL,
	[otherAttributes] [xml] NULL,
	[PrimaryCategoryId] [int] NOT NULL,
 CONSTRAINT [PK__Product__B40CC6CD0425A276] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SecondaryCategory]    Script Date: 12/17/2017 14:07:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecondaryCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_SecondaryCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__Category__Parent__014935CB]    Script Date: 12/17/2017 14:07:11 ******/
ALTER TABLE [dbo].[Category]  WITH CHECK ADD FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
/****** Object:  ForeignKey [FK__Product__Primary__060DEAE8]    Script Date: 12/17/2017 14:07:11 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Primary__060DEAE8] FOREIGN KEY([PrimaryCategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Primary__060DEAE8]
GO
/****** Object:  ForeignKey [FK_SecondaryCategory_Category]    Script Date: 12/17/2017 14:07:11 ******/
ALTER TABLE [dbo].[SecondaryCategory]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[SecondaryCategory] CHECK CONSTRAINT [FK_SecondaryCategory_Category]
GO
/****** Object:  ForeignKey [FK_SecondaryCategory_Product]    Script Date: 12/17/2017 14:07:11 ******/
ALTER TABLE [dbo].[SecondaryCategory]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[SecondaryCategory] CHECK CONSTRAINT [FK_SecondaryCategory_Product]
GO
