USE [master]
GO
/****** Object:  Database [Confitec_Users]    Script Date: 9/17/2022 3:21:20 PM ******/
CREATE DATABASE [Confitec_Users]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Confitec_Users', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Confitec_Users.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Confitec_Users_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Confitec_Users_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Confitec_Users] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Confitec_Users].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Confitec_Users] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Confitec_Users] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Confitec_Users] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Confitec_Users] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Confitec_Users] SET ARITHABORT OFF 
GO
ALTER DATABASE [Confitec_Users] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Confitec_Users] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Confitec_Users] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Confitec_Users] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Confitec_Users] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Confitec_Users] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Confitec_Users] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Confitec_Users] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Confitec_Users] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Confitec_Users] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Confitec_Users] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Confitec_Users] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Confitec_Users] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Confitec_Users] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Confitec_Users] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Confitec_Users] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Confitec_Users] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Confitec_Users] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Confitec_Users] SET  MULTI_USER 
GO
ALTER DATABASE [Confitec_Users] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Confitec_Users] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Confitec_Users] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Confitec_Users] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Confitec_Users] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Confitec_Users]
GO
/****** Object:  Table [dbo].[tbSchooling]    Script Date: 9/17/2022 3:21:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbSchooling](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbSchooling] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbUsers]    Script Date: 9/17/2022 3:21:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[SchoolingId] [int] NOT NULL,
	[SchoolingHistoryId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_tbUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tbUsers]  WITH CHECK ADD  CONSTRAINT [FK_tbUsers_tbSchooling] FOREIGN KEY([SchoolingId])
REFERENCES [dbo].[tbSchooling] ([Id])
GO
ALTER TABLE [dbo].[tbUsers] CHECK CONSTRAINT [FK_tbUsers_tbSchooling]
GO
USE [master]
GO
ALTER DATABASE [Confitec_Users] SET  READ_WRITE 
GO
