USE [HBApostas]
GO

/****** Object:  Table [dbo].[FixedTableNineDozens]    Script Date: 9/18/2019 8:58:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FixedTableNineDozens](
	[Id] [int] NOT NULL,
	[FixedNumbers] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FixedTableNineDozens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


