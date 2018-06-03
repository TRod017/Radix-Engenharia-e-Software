USE [Pagamento]
GO

/****** Object:  Table [dbo].[Loja]    Script Date: 03/06/2018 19:46:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Loja](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CNPJ] [nvarchar](18) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Endereco] [nvarchar](50) NOT NULL,
	[IsAntiFraudeEnabled] [bit] NOT NULL,
	[Token] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Loja] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Token_lojaAdquirente] UNIQUE NONCLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

