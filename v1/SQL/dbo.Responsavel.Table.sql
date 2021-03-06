USE [dbT]
GO
/****** Object:  Table [dbo].[Responsavel]    Script Date: 06/10/2016 11:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Responsavel](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Responsavel1] [varchar](50) NULL,
	[Responsavel2] [varchar](50) NULL,
	[Documento] [varchar](50) NULL,
	[Endereco] [varchar](75) NULL,
	[Bairro] [varchar](30) NULL,
	[Cep] [varchar](9) NULL,
	[Cidade] [varchar](50) NULL,
	[Uf] [varchar](2) NULL,
	[Telefone] [varchar](15) NULL,
	[Celular1] [varchar](15) NULL,
	[Celular2] [varchar](15) NULL,
 CONSTRAINT [PK_Responsavel] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
