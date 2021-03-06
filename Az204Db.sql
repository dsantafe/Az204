USE [master]
GO
/****** Object:  Database [Az204]    Script Date: 16/07/2022 11:24:27 ******/
CREATE DATABASE [Az204]
GO
USE [Az204]
GO
/****** Object:  User [UserAz204]    Script Date: 16/07/2022 11:24:27 ******/
CREATE USER [UserAz204] FOR LOGIN [UserAz204] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [UserAz204]
GO
/****** Object:  Table [dbo].[Applicative]    Script Date: 16/07/2022 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applicative](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Applicative] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 16/07/2022 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Area_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 16/07/2022 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstMidName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevelopmentEngineer]    Script Date: 16/07/2022 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevelopmentEngineer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](50) NULL,
	[FirstMidName] [varchar](50) NULL,
 CONSTRAINT [PK_DevelopmentEngineer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 16/07/2022 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 16/07/2022 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Price] [float] NULL,
	[Hours] [float] NULL,
	[ProjectStateId] [int] NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectState]    Script Date: 16/07/2022 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_ProjectState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requirement]    Script Date: 16/07/2022 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requirement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AreaID] [int] NULL,
	[ApplicativeID] [int] NULL,
	[ScopeRequirement] [varchar](1000) NULL,
	[ApplicationDate] [datetime] NULL,
	[PriorityID] [int] NULL,
	[DevelopmentEngineerID] [int] NULL,
	[DevelopmentDays] [int] NULL,
	[DevelopmentDate] [datetime] NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Customer]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectState] FOREIGN KEY([ProjectStateId])
REFERENCES [dbo].[ProjectState] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectState]
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Area_Applicative] FOREIGN KEY([ApplicativeID])
REFERENCES [dbo].[Applicative] ([ID])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Area_Applicative]
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Area_DevelopmentEngineer] FOREIGN KEY([DevelopmentEngineerID])
REFERENCES [dbo].[DevelopmentEngineer] ([ID])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Area_DevelopmentEngineer]
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Area_Priority] FOREIGN KEY([PriorityID])
REFERENCES [dbo].[Priority] ([ID])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Area_Priority]
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Requirement_Area] FOREIGN KEY([AreaID])
REFERENCES [dbo].[Area] ([ID])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Requirement_Area]
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Requirement_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Requirement_Project]
GO
USE [master]
GO
ALTER DATABASE [Az204] SET  READ_WRITE 
GO
