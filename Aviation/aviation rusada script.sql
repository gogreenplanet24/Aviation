USE [master]
GO
/****** Object:  Database [Spotter]    Script Date: 12-07-2022 13:50:11 ******/
CREATE DATABASE [Spotter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Spotter', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Spotter.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Spotter_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Spotter_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Spotter] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Spotter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Spotter] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Spotter] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Spotter] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Spotter] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Spotter] SET ARITHABORT OFF 
GO
ALTER DATABASE [Spotter] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Spotter] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Spotter] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Spotter] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Spotter] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Spotter] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Spotter] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Spotter] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Spotter] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Spotter] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Spotter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Spotter] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Spotter] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Spotter] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Spotter] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Spotter] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Spotter] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Spotter] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Spotter] SET  MULTI_USER 
GO
ALTER DATABASE [Spotter] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Spotter] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Spotter] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Spotter] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Spotter] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Spotter] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Spotter] SET QUERY_STORE = OFF
GO
USE [Spotter]
GO
/****** Object:  Table [dbo].[tblAircraft]    Script Date: 12-07-2022 13:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAircraft](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Registration] [varchar](50) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_tblAircraft] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddNewAircraftDetails]    Script Date: 12-07-2022 13:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddNewAircraftDetails]  
(  
   @Make varchar (50),  
   @Model varchar (50),  
   @Registration varchar (50),
   @Location varchar(50)
)  
as  
begin  
   Insert into tblAircraft values(@Make,@Model,@Registration,@Location,GETDATE())  
End 
GO
/****** Object:  StoredProcedure [dbo].[DeleteAircraftById]    Script Date: 12-07-2022 13:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteAircraftById]  
(  
   @ID int  
)  
as   
begin  
   Delete from tblAircraft where ID=@ID  
End 
GO
/****** Object:  StoredProcedure [dbo].[GetAircrafts]    Script Date: 12-07-2022 13:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetAircrafts]  
as  
begin  
   select *from tblAircraft  
End 
GO
/****** Object:  StoredProcedure [dbo].[SearchAircrafts]    Script Date: 12-07-2022 13:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[SearchAircrafts]
(@option varchar (50),  
   @search varchar (50))
as
begin
DECLARE @sql nvarchar(max)  = 'SELECT * FROM tblAircraft where '+@option+' like '''+@search +'%'''
exec sp_executesql @sql
print @sql
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateAircraftDetails]    Script Date: 12-07-2022 13:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateAircraftDetails]  
(  
   @ID int,  
   @Make varchar (50),  
   @Model varchar (50),  
   @Registration varchar (50),
    @Location varchar (50)
)  
as  
begin  
   Update tblAircraft   
   set   
   Make=@Make,  
   Model=@Model,
   Registration=@Registration,
   Location=@Location,
   Timestamp=CURRENT_TIMESTAMP
   where ID=@ID  
End 
GO
USE [master]
GO
ALTER DATABASE [Spotter] SET  READ_WRITE 
GO
