USE [HBApostas]
GO

/****** Object:  Table [dbo].[HistoryLotoFacil]    Script Date: 9/18/2019 8:58:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HistoryLotoFacil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Concourse] [varchar](50) NOT NULL,
	[DateAward] [datetime] NULL,
	[ValueAward] [numeric](18, 0) NULL,
	[WinnersQuantity] [int] NULL,
	[Dozen1] [int] NOT NULL,
	[Dozen2] [int] NOT NULL,
	[Dozen3] [int] NOT NULL,
	[Dozen4] [int] NOT NULL,
	[Dozen5] [int] NOT NULL,
	[Dozen6] [int] NOT NULL,
	[Dozen7] [int] NOT NULL,
	[Dozen8] [int] NOT NULL,
	[Dozen9] [int] NOT NULL,
	[Dozen10] [int] NOT NULL,
	[Dozen11] [int] NOT NULL,
	[Dozen12] [int] NOT NULL,
	[Dozen13] [int] NOT NULL,
	[Dozen14] [int] NOT NULL,
	[Dozen15] [int] NOT NULL,
 CONSTRAINT [PK_HistoryLotoFacil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


