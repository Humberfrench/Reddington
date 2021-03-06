USE [dbT]
GO
/****** Object:  Table [dbo].[AlunoProblemaSaude]    Script Date: 06/10/2016 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlunoProblemaSaude](
	[Aluno] [int] NOT NULL,
	[ProblemaSaude] [int] NOT NULL,
 CONSTRAINT [PK_AlunoProblemaSaude] PRIMARY KEY CLUSTERED 
(
	[Aluno] ASC,
	[ProblemaSaude] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AlunoProblemaSaude]  WITH CHECK ADD  CONSTRAINT [FK_AlunoProblemaSaude_Aluno] FOREIGN KEY([Aluno])
REFERENCES [dbo].[Aluno] ([Codigo])
GO
ALTER TABLE [dbo].[AlunoProblemaSaude] CHECK CONSTRAINT [FK_AlunoProblemaSaude_Aluno]
GO
ALTER TABLE [dbo].[AlunoProblemaSaude]  WITH CHECK ADD  CONSTRAINT [FK_AlunoProblemaSaude_ProblemasSaude] FOREIGN KEY([ProblemaSaude])
REFERENCES [dbo].[ProblemasSaude] ([Codigo])
GO
ALTER TABLE [dbo].[AlunoProblemaSaude] CHECK CONSTRAINT [FK_AlunoProblemaSaude_ProblemasSaude]
GO
