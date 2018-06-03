USE [Pagamento]
GO

/****** Object:  Table [dbo].[LojaAdquirente]    Script Date: 03/06/2018 19:47:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LojaAdquirente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LojaId] [int] NOT NULL,
	[AdquirenteId] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
 CONSTRAINT [PK_LojaAdquirente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LojaAdquirente]  WITH CHECK ADD  CONSTRAINT [FK_LojaAdquirente_Adquirente] FOREIGN KEY([AdquirenteId])
REFERENCES [dbo].[Adquirente] ([Id])
GO

ALTER TABLE [dbo].[LojaAdquirente] CHECK CONSTRAINT [FK_LojaAdquirente_Adquirente]
GO

ALTER TABLE [dbo].[LojaAdquirente]  WITH CHECK ADD  CONSTRAINT [FK_LojaAdquirente_Loja] FOREIGN KEY([LojaId])
REFERENCES [dbo].[Loja] ([Id])
GO

ALTER TABLE [dbo].[LojaAdquirente] CHECK CONSTRAINT [FK_LojaAdquirente_Loja]
GO


