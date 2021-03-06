USE [dbT]
GO
/****** Object:  Table [dbo].[ResponsavelAluno]    Script Date: 25/07/2016 12:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResponsavelAluno](
	[Responsavel] [int] NOT NULL,
	[Aluno] [int] NOT NULL,
 CONSTRAINT [PK_ResponsavelAluno] PRIMARY KEY CLUSTERED 
(
	[Responsavel] ASC,
	[Aluno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ResponsavelAluno]  WITH CHECK ADD  CONSTRAINT [FK_ResponsavelAluno_Aluno] FOREIGN KEY([Aluno])
REFERENCES [dbo].[Aluno] ([Codigo])
GO
ALTER TABLE [dbo].[ResponsavelAluno] CHECK CONSTRAINT [FK_ResponsavelAluno_Aluno]
GO
ALTER TABLE [dbo].[ResponsavelAluno]  WITH CHECK ADD  CONSTRAINT [FK_ResponsavelAluno_Responsavel] FOREIGN KEY([Responsavel])
REFERENCES [dbo].[Responsavel] ([Codigo])
GO
ALTER TABLE [dbo].[ResponsavelAluno] CHECK CONSTRAINT [FK_ResponsavelAluno_Responsavel]
GO
