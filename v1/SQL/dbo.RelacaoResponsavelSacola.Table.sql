USE [dbT]
GO
/****** Object:  Table [dbo].[RelacaoResponsavelSacola]    Script Date: 06/10/2016 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelacaoResponsavelSacola](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Responsavel] [int] NOT NULL,
	[Familia] [int] NOT NULL,
 CONSTRAINT [PK_RelacaoResponsavelSacola] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
