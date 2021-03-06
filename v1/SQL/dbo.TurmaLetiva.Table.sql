USE [dbT]
GO
/****** Object:  Table [dbo].[TurmaLetiva]    Script Date: 06/10/2016 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurmaLetiva](
	[Turma] [int] NOT NULL,
	[Aluno] [int] NOT NULL,
 CONSTRAINT [PK_TurmaLetiva] PRIMARY KEY CLUSTERED 
(
	[Turma] ASC,
	[Aluno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TurmaLetiva]  WITH CHECK ADD  CONSTRAINT [FK_TurmaLetiva_Aluno] FOREIGN KEY([Aluno])
REFERENCES [dbo].[Aluno] ([Codigo])
GO
ALTER TABLE [dbo].[TurmaLetiva] CHECK CONSTRAINT [FK_TurmaLetiva_Aluno]
GO
ALTER TABLE [dbo].[TurmaLetiva]  WITH CHECK ADD  CONSTRAINT [FK_TurmaLetiva_Turma] FOREIGN KEY([Turma])
REFERENCES [dbo].[Turma] ([Codigo])
GO
ALTER TABLE [dbo].[TurmaLetiva] CHECK CONSTRAINT [FK_TurmaLetiva_Turma]
GO
