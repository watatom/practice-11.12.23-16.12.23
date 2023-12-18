USE [master]
GO
/****** Object:  Database [ЖК_311]    Script Date: 12.12.2023 11:58:50 ******/
CREATE DATABASE [ЖК_311]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ЖК_311', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ЖК_311.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ЖК_311_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ЖК_311_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ЖК_311] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ЖК_311].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ЖК_311] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ЖК_311] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ЖК_311] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ЖК_311] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ЖК_311] SET ARITHABORT OFF 
GO
ALTER DATABASE [ЖК_311] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ЖК_311] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ЖК_311] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ЖК_311] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ЖК_311] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ЖК_311] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ЖК_311] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ЖК_311] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ЖК_311] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ЖК_311] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ЖК_311] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ЖК_311] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ЖК_311] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ЖК_311] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ЖК_311] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ЖК_311] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ЖК_311] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ЖК_311] SET RECOVERY FULL 
GO
ALTER DATABASE [ЖК_311] SET  MULTI_USER 
GO
ALTER DATABASE [ЖК_311] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ЖК_311] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ЖК_311] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ЖК_311] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ЖК_311] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ЖК_311] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ЖК_311', N'ON'
GO
ALTER DATABASE [ЖК_311] SET QUERY_STORE = OFF
GO
USE [ЖК_311]
GO
/****** Object:  Table [dbo].[Apartaments]    Script Date: 12.12.2023 11:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartaments](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[HouseID] [tinyint] NOT NULL,
	[Number] [smallint] NOT NULL,
	[Area] [decimal](18, 10) NOT NULL,
	[CountOfRooms] [tinyint] NOT NULL,
	[Section] [tinyint] NOT NULL,
	[Floor] [tinyint] NOT NULL,
	[IsSold] [bit] NULL,
	[BuildingCost] [int] NULL,
	[ApartmentValueAdded] [int] NULL,
	[IsDeleted] [tinyint] NULL,
 CONSTRAINT [PK_Apartaments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[House]    Script Date: 12.12.2023 11:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[House](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[ResidentialComplexID] [tinyint] NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[BuildingCost] [int] NULL,
	[HouseValueAdded] [int] NULL,
	[IsDeleted] [tinyint] NULL,
 CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResidentialComplex]    Script Date: 12.12.2023 11:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResidentialComplex](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[BuildingCost] [int] NULL,
	[ComplexValueAdded] [int] NULL,
	[IsDeleted] [tinyint] NULL,
 CONSTRAINT [PK_ResidentialComplex] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (457, 1, 1, CAST(67.6000000000 AS Decimal(18, 10)), 2, 1, 1, 1, 11882000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (458, 1, 2, CAST(79.2000000000 AS Decimal(18, 10)), 3, 1, 1, 1, 13925000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (776, 1, 320, CAST(79.2000000000 AS Decimal(18, 10)), 3, 2, 15, 1, 13925000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (777, 1, 321, CAST(35.4000000000 AS Decimal(18, 10)), 1, 2, 15, 1, 7852000, 200000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (778, 1, 322, CAST(35.4000000000 AS Decimal(18, 10)), 1, 2, 15, 1, 7852000, 200000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (923, 1, 467, CAST(79.2000000000 AS Decimal(18, 10)), 3, 2, 39, 0, 13925000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (924, 1, 468, CAST(67.6000000000 AS Decimal(18, 10)), 2, 2, 39, 1, 11882000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (925, 3, 1, CAST(67.6000000000 AS Decimal(18, 10)), 2, 1, 1, 1, 10697000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (926, 3, 2, CAST(79.2000000000 AS Decimal(18, 10)), 3, 1, 1, 0, 12558000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1002, 3, 78, CAST(67.6000000000 AS Decimal(18, 10)), 2, 1, 13, 1, 10697000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1003, 3, 79, CAST(67.6000000000 AS Decimal(18, 10)), 2, 1, 14, 1, 10697000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1004, 3, 80, CAST(79.2000000000 AS Decimal(18, 10)), 3, 1, 14, 1, 12558000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1005, 3, 81, CAST(35.4000000000 AS Decimal(18, 10)), 1, 1, 14, 0, 6900000, 200000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1152, 3, 228, CAST(67.6000000000 AS Decimal(18, 10)), 2, 1, 38, 1, 10697000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1153, 3, 229, CAST(67.6000000000 AS Decimal(18, 10)), 2, 1, 39, 1, 10697000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1154, 3, 230, CAST(79.2000000000 AS Decimal(18, 10)), 3, 1, 39, 1, 12558000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1410, 3, 486, CAST(67.6000000000 AS Decimal(18, 10)), 2, 3, 3, 1, 10697000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1411, 3, 487, CAST(67.6000000000 AS Decimal(18, 10)), 2, 3, 4, 0, 10697000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1412, 3, 488, CAST(79.2000000000 AS Decimal(18, 10)), 3, 3, 4, 0, 12558000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1647, 6, 21, CAST(35.4000000000 AS Decimal(18, 10)), 1, 1, 4, 1, 7200000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1648, 6, 22, CAST(35.4000000000 AS Decimal(18, 10)), 1, 1, 4, 1, 7200000, 300000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1649, 6, 23, CAST(79.7000000000 AS Decimal(18, 10)), 3, 1, 4, 0, 12560000, 475000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1836, 6, 210, CAST(68.7000000000 AS Decimal(18, 10)), 2, 2, 8, 0, 10854000, 400000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1837, 6, 211, CAST(68.7000000000 AS Decimal(18, 10)), 2, 2, 9, 1, 10854000, 400000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1978, 5, 28, CAST(35.4000000000 AS Decimal(18, 10)), 1, 1, 5, 0, 8955000, 350000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1979, 5, 29, CAST(79.7000000000 AS Decimal(18, 10)), 3, 1, 5, 1, 14432000, 525000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1980, 5, 30, CAST(68.7000000000 AS Decimal(18, 10)), 2, 1, 5, 0, 16885000, 450000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (1981, 5, 31, CAST(68.7000000000 AS Decimal(18, 10)), 2, 1, 6, 0, 16885000, 450000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2274, 5, 324, CAST(68.7000000000 AS Decimal(18, 10)), 2, 2, 27, 0, 16885000, 450000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2275, 8, 1, CAST(68.9000000000 AS Decimal(18, 10)), 2, 1, 1, 1, 10975000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2276, 8, 2, CAST(79.2000000000 AS Decimal(18, 10)), 3, 1, 1, 1, 12787000, 420000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2597, 8, 323, CAST(79.2000000000 AS Decimal(18, 10)), 3, 2, 27, 1, 14432000, 420000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2598, 8, 324, CAST(68.9000000000 AS Decimal(18, 10)), 2, 2, 27, 0, 16885000, 375000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2599, 9, 1, CAST(68.9000000000 AS Decimal(18, 10)), 2, 1, 1, 0, 14552000, 420000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2600, 9, 2, CAST(59.1000000000 AS Decimal(18, 10)), 3, 1, 1, 0, 11198000, 440000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2787, 9, 189, CAST(39.5000000000 AS Decimal(18, 10)), 1, 2, 8, 1, 8196000, 305000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2788, 9, 190, CAST(39.5000000000 AS Decimal(18, 10)), 1, 2, 8, 1, 8196000, 305000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2923, 10, 37, CAST(65.5000000000 AS Decimal(18, 10)), 2, 2, 1, 0, 7731000, 650000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2924, 10, 38, CAST(40.6000000000 AS Decimal(18, 10)), 1, 2, 1, 0, 5850000, 390000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (2925, 10, 39, CAST(40.6000000000 AS Decimal(18, 10)), 1, 2, 1, 0, 5850000, 390000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (3405, 11, 91, CAST(40.9000000000 AS Decimal(18, 10)), 1, 3, 5, 0, 5955000, 350000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (3406, 11, 92, CAST(62.7000000000 AS Decimal(18, 10)), 2, 3, 5, 1, 7453000, 450000, 0)
INSERT [dbo].[Apartaments] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [BuildingCost], [ApartmentValueAdded], [IsDeleted]) VALUES (3407, 11, 93, CAST(63.3000000000 AS Decimal(18, 10)), 2, 3, 6, 0, 7453000, 450000, 0)
GO
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [Street], [Number], [BuildingCost], [HouseValueAdded], [IsDeleted]) VALUES (1, 1, N'Амурская', N'Г8', 400000, 500000, 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [Street], [Number], [BuildingCost], [HouseValueAdded], [IsDeleted]) VALUES (3, 1, N'Амурская', N'Г7', 500000, 550000, 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [Street], [Number], [BuildingCost], [HouseValueAdded], [IsDeleted]) VALUES (5, 1, N'Амурская', N'А2', 700000, 850000, 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [Street], [Number], [BuildingCost], [HouseValueAdded], [IsDeleted]) VALUES (6, 1, N'Амурская', N'А1', 700000, 850000, 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [Street], [Number], [BuildingCost], [HouseValueAdded], [IsDeleted]) VALUES (8, 1, N'Амурская', N'Б3', 450000, 550000, 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [Street], [Number], [BuildingCost], [HouseValueAdded], [IsDeleted]) VALUES (9, 1, N'Амурская', N'Б4', 450000, 550000, 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [Street], [Number], [BuildingCost], [HouseValueAdded], [IsDeleted]) VALUES (10, 2, N'Калужское шоссе', N'1.1', 650000, 700000, 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [Street], [Number], [BuildingCost], [HouseValueAdded], [IsDeleted]) VALUES (11, 2, N'Калужское шоссе', N'1.2', 450000, 500000, 0)
GO
INSERT [dbo].[ResidentialComplex] ([ID], [Name], [City], [Status], [BuildingCost], [ComplexValueAdded], [IsDeleted]) VALUES (1, N'Level Амурская', N'Москва', N'2:строительство', 500000, 60000, 0)
INSERT [dbo].[ResidentialComplex] ([ID], [Name], [City], [Status], [BuildingCost], [ComplexValueAdded], [IsDeleted]) VALUES (2, N'Испанские кварталы', N'Москва', N'1:план', 7000000, 950000, 0)
INSERT [dbo].[ResidentialComplex] ([ID], [Name], [City], [Status], [BuildingCost], [ComplexValueAdded], [IsDeleted]) VALUES (3, N'Китайские кварталы', N'Омск', N'3:реализация', 7000000, 950000, 0)
GO
ALTER TABLE [dbo].[Apartaments]  WITH CHECK ADD  CONSTRAINT [FK_Apartaments_House] FOREIGN KEY([HouseID])
REFERENCES [dbo].[House] ([ID])
GO
ALTER TABLE [dbo].[Apartaments] CHECK CONSTRAINT [FK_Apartaments_House]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_ResidentialComplex] FOREIGN KEY([ResidentialComplexID])
REFERENCES [dbo].[ResidentialComplex] ([ID])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_ResidentialComplex]
GO
USE [master]
GO
ALTER DATABASE [ЖК_311] SET  READ_WRITE 
GO
