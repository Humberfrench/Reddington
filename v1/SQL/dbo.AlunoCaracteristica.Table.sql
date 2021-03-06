USE [dbT]
GO
/****** Object:  Table [dbo].[AlunoCaracteristica]    Script Date: 06/10/2016 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlunoCaracteristica](
	[Aluno] [int] NOT NULL,
	[Caracteristica] [int] NOT NULL,
 CONSTRAINT [PK_AlunoCaracteristica] PRIMARY KEY CLUSTERED 
(
	[Aluno] ASC,
	[Caracteristica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AlunoCaracteristica]  WITH CHECK ADD  CONSTRAINT [FK_AlunoCaracteristica_Aluno] FOREIGN KEY([Aluno])
REFERENCES [dbo].[Aluno] ([Codigo])
GO
ALTER TABLE [dbo].[AlunoCaracteristica] CHECK CONSTRAINT [FK_AlunoCaracteristica_Aluno]
GO
ALTER TABLE [dbo].[AlunoCaracteristica]  WITH CHECK ADD  CONSTRAINT [FK_AlunoCaracteristica_Caracteristica] FOREIGN KEY([Caracteristica])
REFERENCES [dbo].[Caracteristica] ([Codigo])
GO
ALTER TABLE [dbo].[AlunoCaracteristica] CHECK CONSTRAINT [FK_AlunoCaracteristica_Caracteristica]
GO
