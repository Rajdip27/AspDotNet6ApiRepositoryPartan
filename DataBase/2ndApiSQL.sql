USE [2ndApiDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13-Dec-22 12:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posts]    Script Date: 13-Dec-22 12:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Decripation] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221212063456_addpost', N'7.0.0')
GO
SET IDENTITY_INSERT [dbo].[posts] ON 

INSERT [dbo].[posts] ([Id], [Title], [Decripation], [CreatedDate]) VALUES (1, N'string', N'string', CAST(N'2022-12-12T06:53:14.5070000' AS DateTime2))
INSERT [dbo].[posts] ([Id], [Title], [Decripation], [CreatedDate]) VALUES (2, N'stringhdjkghjkdhfjhdfkahjkdfhkdfghjkdfahjkfgjkhfdjhgfd', N'stringdfghdgahkdffdkjhffghfhfjghfdgfhdjfd', CAST(N'2022-12-12T13:01:48.7410000' AS DateTime2))
INSERT [dbo].[posts] ([Id], [Title], [Decripation], [CreatedDate]) VALUES (4, N'jhjkhgfh', N'thrhjrehjhrerheht', CAST(N'2022-12-12T14:09:15.4612040' AS DateTime2))
INSERT [dbo].[posts] ([Id], [Title], [Decripation], [CreatedDate]) VALUES (5, N'Raj Raj', N'fdskjfhkhdfhfdhhfd', CAST(N'2022-12-12T19:47:01.5840406' AS DateTime2))
INSERT [dbo].[posts] ([Id], [Title], [Decripation], [CreatedDate]) VALUES (6, N'string', N'string', CAST(N'2022-12-12T21:28:07.5884648' AS DateTime2))
SET IDENTITY_INSERT [dbo].[posts] OFF
GO
