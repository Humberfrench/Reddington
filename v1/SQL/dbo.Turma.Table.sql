USE [dbT]
GO
/****** Object:  Table [dbo].[Turma]    Script Date: 06/10/2016 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turma](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[NomeSala] [varchar](50) NOT NULL,
	[Evangelizador] [int] NOT NULL,
	[Ano] [int] NOT NULL,
 CONSTRAINT [PK_Turma] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Turma]  WITH CHECK ADD  CONSTRAINT [FK_Turma_Evangelizador] FOREIGN KEY([Evangelizador])
REFERENCES [dbo].[Evangelizador] ([Codigo])
GO
ALTER TABLE [dbo].[Turma] CHECK CONSTRAINT [FK_Turma_Evangelizador]
GO
