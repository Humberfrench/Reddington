USE [dbT]
GO
/****** Object:  Table [dbo].[AlunoAtividadePreferida]    Script Date: 06/10/2016 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlunoAtividadePreferida](
	[Aluno] [int] NOT NULL,
	[AtividadePreferida] [int] NOT NULL,
 CONSTRAINT [PK_AlunoAtividade] PRIMARY KEY CLUSTERED 
(
	[Aluno] ASC,
	[AtividadePreferida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AlunoAtividadePreferida]  WITH CHECK ADD  CONSTRAINT [FK_AlunoAtividadePreferida_Aluno] FOREIGN KEY([Aluno])
REFERENCES [dbo].[Aluno] ([Codigo])
GO
ALTER TABLE [dbo].[AlunoAtividadePreferida] CHECK CONSTRAINT [FK_AlunoAtividadePreferida_Aluno]
GO
ALTER TABLE [dbo].[AlunoAtividadePreferida]  WITH CHECK ADD  CONSTRAINT [FK_AlunoAtividadePreferida_AtividadesPreferida] FOREIGN KEY([AtividadePreferida])
REFERENCES [dbo].[AtividadesPreferida] ([Codigo])
GO
ALTER TABLE [dbo].[AlunoAtividadePreferida] CHECK CONSTRAINT [FK_AlunoAtividadePreferida_AtividadesPreferida]
GO
