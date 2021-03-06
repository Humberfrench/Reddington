USE [dbT]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 06/10/2016 11:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aluno](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Responsavel] [int] NULL,
	[DataNascimento] [date] NOT NULL,
	[Sexo] [varchar](1) NOT NULL,
	[GrupoDeJovens] [bit] NOT NULL,
	[Matriculado] [bit] NOT NULL,
	[Status] [int] NOT NULL,
	[Observacao] [varchar](100) NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Aluno]  WITH CHECK ADD  CONSTRAINT [FK_Aluno_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Codigo])
GO
ALTER TABLE [dbo].[Aluno] CHECK CONSTRAINT [FK_Aluno_Status]
GO
