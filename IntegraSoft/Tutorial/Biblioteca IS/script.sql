USE [master]
GO
/****** Object:  Database [IS_Administrativo]    Script Date: 13/04/2020 16:02:19 ******/
CREATE DATABASE [IS_Administrativo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SB_Comercial', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SB\MSSQL\DATA\SB_Financeiro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SB_Comercial_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SB\MSSQL\DATA\SB_Financeiro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [IS_Administrativo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IS_Administrativo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IS_Administrativo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IS_Administrativo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IS_Administrativo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IS_Administrativo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IS_Administrativo] SET ARITHABORT OFF 
GO
ALTER DATABASE [IS_Administrativo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IS_Administrativo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IS_Administrativo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IS_Administrativo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IS_Administrativo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IS_Administrativo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IS_Administrativo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IS_Administrativo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IS_Administrativo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IS_Administrativo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IS_Administrativo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IS_Administrativo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IS_Administrativo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IS_Administrativo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IS_Administrativo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IS_Administrativo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IS_Administrativo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IS_Administrativo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IS_Administrativo] SET  MULTI_USER 
GO
ALTER DATABASE [IS_Administrativo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IS_Administrativo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IS_Administrativo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IS_Administrativo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IS_Administrativo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IS_Administrativo] SET QUERY_STORE = OFF
GO
USE [IS_Administrativo]
GO
/****** Object:  UserDefinedFunction [dbo].[usf_rm_accent_pt_latin1]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[usf_rm_accent_pt_latin1] (@txt varchar(max)) RETURNS varchar(max) 
-- Nome Artefato/Programa..: usf_rm_accent_pt_latin1.sql
-- Autor(es)...............: Emerson Hermann (emersonhermann [at] gmail.com) O Peregrino (http://www.emersonhermann.blogspot.com) 
-- Data Inicio ............: 26/11/2011
-- Data Atualizacao........: 08/10/2012
-- Versao..................: 0.03
-- Compilador/Interpretador: T-SQL (Transact SQL) 
-- Sistemas Operacionais...: Windows
-- SGBD....................: MS SQL Server 2005/2008/2012
-- Kernel..................: Nao informado!
-- Finalidade..............: store function para remover acentos maiúsculos e minúsculos em latin1 pt
-- OBS.....................: só funciona para banco configurado com o collate latin1, para saber qual o collate do seu banco execute essa query 
-- ........................: SELECT DatabasePropertyEx(db_name(),'Collation');
--
BEGIN
DECLARE @txt0 varchar(max) 
 --caixa baixa
    SET @txt0 = replace(@txt COLLATE Latin1_General_BIN, char(225),'a')  --SELECT 'á',ASCII('á'); --225
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(224),'a')  --SELECT 'à',ASCII('à'); --224   
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(227),'a')  --SELECT 'ã',ASCII('ã'); --227 
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(226),'a')  --SELECT 'â',ASCII('â'); --226
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(233),'e')  --SELECT 'é',ASCII('é'); --233 
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(232),'e')  --SELECT 'è',ASCII('è'); --232
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(234),'e')  --SELECT 'ê',ASCII('ê'); --234
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(237),'i')  --SELECT 'í',ASCII('í'); --237 
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(236),'i')  --SELECT 'ì',ASCII('ì'); --236
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(238),'i')  --SELECT 'î',ASCII('î'); --238 
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(243),'o')  --SELECT 'ó',ASCII('ó'); --243
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(242),'o')  --SELECT 'ò',ASCII('ò'); --242
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(244),'o')  --SELECT 'ô',ASCII('ô'); --244
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(245),'o')  --SELECT 'õ',ASCII('õ'); --245
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(250),'u')  --SELECT 'ú',ASCII('ú'); --250
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(249),'u')  --SELECT 'ù',ASCII('ù'); --249
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(251),'u')  --SELECT 'û',ASCII('û'); --251 
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(252),'u')  --SELECT 'ü',ASCII('ü'); --252 
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(231),'ç')  --SELECT 'ç',ASCII('ç'); --231
 -- caixa alta
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(193),'A')  --SELECT 'Á',ASCII('Á'); --193
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(192),'A')  --SELECT 'À',ASCII('À'); --192  
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(194),'A')  --SELECT 'Â',ASCII('Â'); --194
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(195),'A')  --SELECT 'Ã',ASCII('Ã'); --195
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(201),'E')  --SELECT 'É',ASCII('É'); --201
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(200),'E')  --SELECT 'È',ASCII('È'); --200
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(202),'E')  --SELECT 'Ê',ASCII('Ê'); --202
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(205),'I')  --SELECT 'Í',ASCII('Í'); --205
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(204),'I')  --SELECT 'Ì',ASCII('Ì'); --204
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(206),'I')  --SELECT 'Î',ASCII('Î'); --206
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(211),'O')  --SELECT 'Ó',ASCII('Ó'); --211
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(210),'O')  --SELECT 'Ò',ASCII('Ò'); --210
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(212),'O')  --SELECT 'Ô',ASCII('Ô'); --212
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(213),'O')  --SELECT 'Õ',ASCII('Õ'); --213
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(218),'U')  --SELECT 'Ú',ASCII('Ú'); --218
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(217),'U')  --SELECT 'Ù',ASCII('Ù'); --217
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(219),'U')  --SELECT 'Û',ASCII('Û'); --219 
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(220),'U')  --SELECT 'Ü',ASCII('Ü'); --220
    SET @txt0 = replace(@txt0 COLLATE Latin1_General_BIN,char(199),'C')  --SELECT 'Ç',ASCII('Ç'); --199
      
 RETURN (@txt0)
END
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[banID] [int] IDENTITY(1,1) NOT NULL,
	[banCompensacao] [varchar](5) NULL,
	[banNome] [varchar](60) NULL,
	[banSite] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[banID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogoComponente]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogoComponente](
	[cacoID] [int] IDENTITY(1,1) NOT NULL,
	[cacoIDForm] [int] NOT NULL,
	[cacoNomeComponente] [varchar](100) NULL,
	[cacoNomeAmigavel] [varchar](100) NULL,
	[cacoChecked] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[cacoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogoFormulario]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogoFormulario](
	[cafoID] [int] IDENTITY(1,1) NOT NULL,
	[cafoNomeFormulario] [varchar](70) NOT NULL,
	[cafoNomeAmigavel] [varchar](70) NOT NULL,
	[cafoNomeFullFormulario] [varchar](100) NOT NULL,
	[cafoChecked] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[cafoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogoPermissaoUsuario]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogoPermissaoUsuario](
	[capeusID] [int] IDENTITY(1,1) NOT NULL,
	[capeusIDComponente] [int] NOT NULL,
	[capeusIDPWUsuario] [int] NOT NULL,
	[capeusPermissao] [bit] NULL,
	[capeusChecked] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[capeusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cep]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cep](
	[cepID] [int] IDENTITY(1,1) NOT NULL,
	[cepCep] [varchar](8) NULL,
	[cepIDLogradouro] [int] NOT NULL,
	[cepEndereco] [varchar](50) NULL,
	[cepComplemento] [varchar](30) NULL,
	[cepBairro] [varchar](70) NULL,
	[cepIDCidade] [int] NOT NULL,
	[cepGia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[disID] [int] IDENTITY(1,1) NOT NULL,
	[disIDMunicipio] [int] NOT NULL,
	[disIBGEDistrito] [int] NOT NULL,
	[disNome] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[disID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoCivil]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCivil](
	[escID] [int] IDENTITY(1,1) NOT NULL,
	[escDescricao] [nchar](30) NOT NULL,
 CONSTRAINT [PK_EstadoCivil] PRIMARY KEY CLUSTERED 
(
	[escID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logradouro]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logradouro](
	[logID] [int] IDENTITY(1,1) NOT NULL,
	[logNome] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[logID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MassorRegiao_Geografica]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MassorRegiao_Geografica](
	[msrID] [int] IDENTITY(1,1) NOT NULL,
	[msrIDUF] [int] NOT NULL,
	[msrCodigo] [int] NOT NULL,
	[msrNome] [varchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[msrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MicrorRegiao_Geografica]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MicrorRegiao_Geografica](
	[mirID] [int] IDENTITY(1,1) NOT NULL,
	[mirIDMassorRegiao] [int] NOT NULL,
	[mirCodigo] [int] NOT NULL,
	[mirNome] [varchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[mirID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipio]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipio](
	[munID] [int] IDENTITY(1,1) NOT NULL,
	[munIDMicrorRegiao] [int] NOT NULL,
	[munIBGECidade] [int] NOT NULL,
	[munNome] [varchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[munID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[paisID] [int] IDENTITY(1,1) NOT NULL,
	[paisNome] [varchar](60) NULL,
	[paisSigla] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[paisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PW~Usuarios]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PW~Usuarios](
	[PW~ID] [int] IDENTITY(1,1) NOT NULL,
	[PW~Nome] [varchar](100) NOT NULL,
	[PW~Senha] [varchar](100) NOT NULL,
	[PW~Login] [varchar](100) NOT NULL,
	[PW~Email] [varchar](100) NOT NULL,
	[PW~DataCadastro] [datetime] NOT NULL,
	[PW~Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_PW~Usuarios] PRIMARY KEY CLUSTERED 
(
	[PW~ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RamoAtividade]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RamoAtividade](
	[ratID] [int] IDENTITY(1,1) NOT NULL,
	[ratDescricao] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regiao]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regiao](
	[regID] [int] IDENTITY(1,1) NOT NULL,
	[regNome] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[regID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SituacaoCadastralEmpresa]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SituacaoCadastralEmpresa](
	[sceID] [int] IDENTITY(1,1) NOT NULL,
	[sceDescricao] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UF]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UF](
	[ufID] [int] IDENTITY(1,1) NOT NULL,
	[ufEstado] [varchar](75) NULL,
	[ufAbreviado] [varchar](2) NULL,
	[ufIDRegiao] [int] NOT NULL,
	[ufCodIBGEEstado] [int] NOT NULL,
	[ufIDPais] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ufID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VIACEP]    Script Date: 13/04/2020 16:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VIACEP](
	[cep] [varchar](9) NULL,
	[logradouro] [varchar](25) NULL,
	[endereco] [varchar](100) NULL,
	[complemento] [varchar](100) NULL,
	[bairro] [varchar](100) NULL,
	[cidade] [varchar](100) NULL,
	[uf] [varchar](2) NULL,
	[unidade] [varchar](1) NULL,
	[ibge] [varchar](7) NULL,
	[gia] [varchar](4) NULL,
	[idLogradouro] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CatalogoComponente]  WITH CHECK ADD  CONSTRAINT [FK_CatalogoComponente] FOREIGN KEY([cacoIDForm])
REFERENCES [dbo].[CatalogoFormulario] ([cafoID])
GO
ALTER TABLE [dbo].[CatalogoComponente] CHECK CONSTRAINT [FK_CatalogoComponente]
GO
ALTER TABLE [dbo].[CatalogoPermissaoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_CatalogoPermissaoUsuario_Compo] FOREIGN KEY([capeusIDComponente])
REFERENCES [dbo].[CatalogoComponente] ([cacoID])
GO
ALTER TABLE [dbo].[CatalogoPermissaoUsuario] CHECK CONSTRAINT [FK_CatalogoPermissaoUsuario_Compo]
GO
ALTER TABLE [dbo].[CatalogoPermissaoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_CatalogoPermissaoUsuario_Usu] FOREIGN KEY([capeusIDPWUsuario])
REFERENCES [dbo].[PW~Usuarios] ([PW~ID])
GO
ALTER TABLE [dbo].[CatalogoPermissaoUsuario] CHECK CONSTRAINT [FK_CatalogoPermissaoUsuario_Usu]
GO
ALTER TABLE [dbo].[Cep]  WITH CHECK ADD  CONSTRAINT [FK_CEP_Logradouro] FOREIGN KEY([cepIDLogradouro])
REFERENCES [dbo].[Logradouro] ([logID])
GO
ALTER TABLE [dbo].[Cep] CHECK CONSTRAINT [FK_CEP_Logradouro]
GO
ALTER TABLE [dbo].[Cep]  WITH CHECK ADD  CONSTRAINT [FK_CEP_Municipio] FOREIGN KEY([cepIDCidade])
REFERENCES [dbo].[Municipio] ([munID])
GO
ALTER TABLE [dbo].[Cep] CHECK CONSTRAINT [FK_CEP_Municipio]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_DIS_MUN] FOREIGN KEY([disIDMunicipio])
REFERENCES [dbo].[Municipio] ([munID])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_DIS_MUN]
GO
ALTER TABLE [dbo].[MassorRegiao_Geografica]  WITH CHECK ADD  CONSTRAINT [FK_MSR_UF] FOREIGN KEY([msrIDUF])
REFERENCES [dbo].[UF] ([ufID])
GO
ALTER TABLE [dbo].[MassorRegiao_Geografica] CHECK CONSTRAINT [FK_MSR_UF]
GO
ALTER TABLE [dbo].[MicrorRegiao_Geografica]  WITH CHECK ADD  CONSTRAINT [FK_MIR_MSR] FOREIGN KEY([mirIDMassorRegiao])
REFERENCES [dbo].[MassorRegiao_Geografica] ([msrID])
GO
ALTER TABLE [dbo].[MicrorRegiao_Geografica] CHECK CONSTRAINT [FK_MIR_MSR]
GO
ALTER TABLE [dbo].[Municipio]  WITH CHECK ADD  CONSTRAINT [FK_MUN_MIR] FOREIGN KEY([munIDMicrorRegiao])
REFERENCES [dbo].[MicrorRegiao_Geografica] ([mirID])
GO
ALTER TABLE [dbo].[Municipio] CHECK CONSTRAINT [FK_MUN_MIR]
GO
ALTER TABLE [dbo].[UF]  WITH CHECK ADD  CONSTRAINT [FK_UF_Pais] FOREIGN KEY([ufIDPais])
REFERENCES [dbo].[Pais] ([paisID])
GO
ALTER TABLE [dbo].[UF] CHECK CONSTRAINT [FK_UF_Pais]
GO
ALTER TABLE [dbo].[UF]  WITH CHECK ADD  CONSTRAINT [FK_UF_Regiao] FOREIGN KEY([ufIDRegiao])
REFERENCES [dbo].[Regiao] ([regID])
GO
ALTER TABLE [dbo].[UF] CHECK CONSTRAINT [FK_UF_Regiao]
GO
USE [master]
GO
ALTER DATABASE [IS_Administrativo] SET  READ_WRITE 
GO
