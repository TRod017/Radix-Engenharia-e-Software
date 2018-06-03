USE [Pagamento]
GO

/****** Object:  Table [dbo].[Transacao]    Script Date: 03/06/2018 19:48:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [uniqueidentifier] NOT NULL,
	[Data] [datetime] NOT NULL,
	[LojaId] [int] NOT NULL,
	[AdquirenteId] [int] NOT NULL,
	[NumeroPedido] [int] NULL,
	[Valor] [money] NULL,
 CONSTRAINT [PK_Transacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_Adquirente] FOREIGN KEY([AdquirenteId])
REFERENCES [dbo].[Adquirente] ([Id])
GO

ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_Adquirente]
GO

ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_Loja] FOREIGN KEY([LojaId])
REFERENCES [dbo].[Loja] ([Id])
GO

ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_Loja]
GO

