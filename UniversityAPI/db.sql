USE [master]
GO
/****** Object:  Database [studentDB]    Script Date: 4/23/2023 10:15:36 PM ******/
CREATE DATABASE [studentDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'studentDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\studentDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'studentDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\studentDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [studentDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [studentDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [studentDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [studentDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [studentDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [studentDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [studentDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [studentDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [studentDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [studentDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [studentDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [studentDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [studentDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [studentDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [studentDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [studentDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [studentDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [studentDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [studentDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [studentDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [studentDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [studentDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [studentDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [studentDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [studentDB] SET RECOVERY FULL 
GO
ALTER DATABASE [studentDB] SET  MULTI_USER 
GO
ALTER DATABASE [studentDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [studentDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [studentDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [studentDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [studentDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [studentDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'studentDB', N'ON'
GO
ALTER DATABASE [studentDB] SET QUERY_STORE = OFF
GO
USE [studentDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AllocateClassTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateClassTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromTime] [datetime2](7) NOT NULL,
	[ToTime] [datetime2](7) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
 CONSTRAINT [PK_AllocateClassTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Fullname] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseAssignTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Action] [bit] NOT NULL,
 CONSTRAINT [PK_CourseAssignTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [nvarchar](20) NOT NULL,
	[CourseName] [nvarchar](max) NOT NULL,
	[Credit] [real] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Action] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_CourseTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DayTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DayTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DayTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [nvarchar](max) NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DepartmentTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DesignationTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesignationTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DesignationTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnrollCourseTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollCourseTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_EnrollCourseTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeLetterTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeLetterTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradeLetterMarkes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_GradeLetterTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RoomTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SemesterTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SemesterTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SemesterTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentResultTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResultTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[GradeLetterId] [int] NOT NULL,
 CONSTRAINT [PK_StudentResultTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTb]    Script Date: 4/23/2023 10:15:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[RegisterDate] [datetime2](7) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[RegistrationNo] [nvarchar](max) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_StudentTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherTb]    Script Date: 4/23/2023 10:15:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[ContactNo] [nvarchar](14) NOT NULL,
	[CreditToBeTaken] [float] NOT NULL,
	[RemainingCredit] [float] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[DesignationId] [int] NOT NULL,
 CONSTRAINT [PK_TeacherTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230414231822_Init DB', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230415073144_Add Database model and relation', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230415180924_date update', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230423064459_update courseAssignmodel', N'6.0.13')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0f01bad0-3c7d-4261-93be-94b36a17ea7e', N'admin', N'ADMIN', N'32a5c836-d48c-411f-bb96-667f4279c066')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fa1ce4a6-2d5d-499b-8b47-9c9ad85b150b', N'user', N'USER', N'09fb7e34-b3fb-4614-baa4-be6bf35d503e')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'232c0434-a3e7-427f-bbf5-72e687e8450f', N'0f01bad0-3c7d-4261-93be-94b36a17ea7e')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Fullname], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'232c0434-a3e7-427f-bbf5-72e687e8450f', N'string', N'towhid', N'TOWHID', N'string', N'STRING', 0, N'AQAAAAEAACcQAAAAEO/O7bb2455qbJGAogpQEeX1GNuBiSPa0ryWho5qRalm7RKMXkFbegkDDXP85ILHtA==', N'FFC4ATGT7P3WQXW3FPNQZRUZVELGE4YI', N'eb7e2def-38a2-4d88-8f81-3f2c4e3d0ccc', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[CourseAssignTb] ON 

INSERT [dbo].[CourseAssignTb] ([Id], [DepartmentId], [TeacherId], [CourseId], [Action]) VALUES (1, 1, 1, 4, 0)
SET IDENTITY_INSERT [dbo].[CourseAssignTb] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseTb] ON 

INSERT [dbo].[CourseTb] ([Id], [CourseCode], [CourseName], [Credit], [Description], [Action], [DepartmentId], [SemesterId]) VALUES (4, N'CSE-1101', N'Programming With C', 3, N'Cfe', 1, 1, 1)
INSERT [dbo].[CourseTb] ([Id], [CourseCode], [CourseName], [Credit], [Description], [Action], [DepartmentId], [SemesterId]) VALUES (18, N'CSE-1102', N'CSE-1101', 3, N'', 1, 1, 8)
SET IDENTITY_INSERT [dbo].[CourseTb] OFF
GO
SET IDENTITY_INSERT [dbo].[DepartmentTb] ON 

INSERT [dbo].[DepartmentTb] ([Id], [DepartmentCode], [DepartmentName]) VALUES (1, N'CSE', N'CSE')
INSERT [dbo].[DepartmentTb] ([Id], [DepartmentCode], [DepartmentName]) VALUES (2, N'EEE', N'EEE')
INSERT [dbo].[DepartmentTb] ([Id], [DepartmentCode], [DepartmentName]) VALUES (3, N'BBA', N'BBA')
SET IDENTITY_INSERT [dbo].[DepartmentTb] OFF
GO
SET IDENTITY_INSERT [dbo].[DesignationTb] ON 

INSERT [dbo].[DesignationTb] ([Id], [DesignationName]) VALUES (1, N'Professor')
INSERT [dbo].[DesignationTb] ([Id], [DesignationName]) VALUES (2, N'Inestractor')
SET IDENTITY_INSERT [dbo].[DesignationTb] OFF
GO
SET IDENTITY_INSERT [dbo].[SemesterTb] ON 

INSERT [dbo].[SemesterTb] ([Id], [SemesterName]) VALUES (1, N'1st')
INSERT [dbo].[SemesterTb] ([Id], [SemesterName]) VALUES (2, N'2nd')
INSERT [dbo].[SemesterTb] ([Id], [SemesterName]) VALUES (3, N'3rd')
INSERT [dbo].[SemesterTb] ([Id], [SemesterName]) VALUES (4, N'4th')
INSERT [dbo].[SemesterTb] ([Id], [SemesterName]) VALUES (5, N'5th')
INSERT [dbo].[SemesterTb] ([Id], [SemesterName]) VALUES (6, N'6th')
INSERT [dbo].[SemesterTb] ([Id], [SemesterName]) VALUES (7, N'7th')
INSERT [dbo].[SemesterTb] ([Id], [SemesterName]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[SemesterTb] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentTb] ON 

INSERT [dbo].[StudentTb] ([Id], [StudentName], [Email], [ContactNo], [RegisterDate], [Address], [RegistrationNo], [DepartmentId]) VALUES (9, N'Towhidul islam', N'towhid6785@aibl.com', N'01864746', CAST(N'2023-04-12T00:00:00.0000000' AS DateTime2), N'ctg', N'CSE-2023-007', 1)
INSERT [dbo].[StudentTb] ([Id], [StudentName], [Email], [ContactNo], [RegisterDate], [Address], [RegistrationNo], [DepartmentId]) VALUES (10, N'Abul', N'abul@email.com', N'01864746474', CAST(N'2023-04-07T00:00:00.0000000' AS DateTime2), N'ctg', N'EEE-2023-002', 2)
INSERT [dbo].[StudentTb] ([Id], [StudentName], [Email], [ContactNo], [RegisterDate], [Address], [RegistrationNo], [DepartmentId]) VALUES (12, N'FAhad', N'123@ff.co', N'015214018', CAST(N'2023-04-20T00:00:00.0000000' AS DateTime2), N'Patiya kotiya', N'CSE-2023-009', 1)
INSERT [dbo].[StudentTb] ([Id], [StudentName], [Email], [ContactNo], [RegisterDate], [Address], [RegistrationNo], [DepartmentId]) VALUES (13, N'towhid6785@aibl.com', N'12@12.vom', N'01521401823', CAST(N'2023-04-28T00:00:00.0000000' AS DateTime2), N'qw', N'CSE-2023-003', 1)
INSERT [dbo].[StudentTb] ([Id], [StudentName], [Email], [ContactNo], [RegisterDate], [Address], [RegistrationNo], [DepartmentId]) VALUES (14, N'towhid6785@aibl.com', N'12@12.vo0', N'0152140182', CAST(N'2023-04-28T00:00:00.0000000' AS DateTime2), N'qw', N'CSE-2023-004', 1)
INSERT [dbo].[StudentTb] ([Id], [StudentName], [Email], [ContactNo], [RegisterDate], [Address], [RegistrationNo], [DepartmentId]) VALUES (15, N'5', N'5', N'5', CAST(N'2023-04-20T00:00:00.0000000' AS DateTime2), N'555', N'EEE-2023-002', 2)
INSERT [dbo].[StudentTb] ([Id], [StudentName], [Email], [ContactNo], [RegisterDate], [Address], [RegistrationNo], [DepartmentId]) VALUES (16, N'Arfa', N'arfa@gmail.com', N'01834', CAST(N'2023-04-19T00:00:00.0000000' AS DateTime2), N'Patiya', N'CSE-2023-005', 1)
INSERT [dbo].[StudentTb] ([Id], [StudentName], [Email], [ContactNo], [RegisterDate], [Address], [RegistrationNo], [DepartmentId]) VALUES (17, N'Arfa', N'arfa@gmail.com.bd', N'018344', CAST(N'2023-04-19T00:00:00.0000000' AS DateTime2), N'Patiya', N'CSE-2023-006', 1)
SET IDENTITY_INSERT [dbo].[StudentTb] OFF
GO
SET IDENTITY_INSERT [dbo].[TeacherTb] ON 

INSERT [dbo].[TeacherTb] ([Id], [TeacherName], [Address], [Email], [ContactNo], [CreditToBeTaken], [RemainingCredit], [DepartmentId], [DesignationId]) VALUES (1, N'string', N'string', N'user@example.com', N'string', 10, 10, 1, 1)
SET IDENTITY_INSERT [dbo].[TeacherTb] OFF
GO
/****** Object:  Index [IX_AllocateClassTb_CourseId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_AllocateClassTb_CourseId] ON [dbo].[AllocateClassTb]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AllocateClassTb_DayId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_AllocateClassTb_DayId] ON [dbo].[AllocateClassTb]
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AllocateClassTb_DepartmentId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_AllocateClassTb_DepartmentId] ON [dbo].[AllocateClassTb]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AllocateClassTb_RoomId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_AllocateClassTb_RoomId] ON [dbo].[AllocateClassTb]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseAssignTb_CourseId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseAssignTb_CourseId] ON [dbo].[CourseAssignTb]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseAssignTb_DepartmentId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseAssignTb_DepartmentId] ON [dbo].[CourseAssignTb]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseAssignTb_TeacherId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseAssignTb_TeacherId] ON [dbo].[CourseAssignTb]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseTb_DepartmentId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseTb_DepartmentId] ON [dbo].[CourseTb]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseTb_SemesterId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseTb_SemesterId] ON [dbo].[CourseTb]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EnrollCourseTb_CourseId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_EnrollCourseTb_CourseId] ON [dbo].[EnrollCourseTb]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EnrollCourseTb_StudentId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_EnrollCourseTb_StudentId] ON [dbo].[EnrollCourseTb]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentResultTb_CourseId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentResultTb_CourseId] ON [dbo].[StudentResultTb]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentResultTb_GradeLetterId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentResultTb_GradeLetterId] ON [dbo].[StudentResultTb]
(
	[GradeLetterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentResultTb_StudentId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentResultTb_StudentId] ON [dbo].[StudentResultTb]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentTb_DepartmentId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentTb_DepartmentId] ON [dbo].[StudentTb]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherTb_DepartmentId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherTb_DepartmentId] ON [dbo].[TeacherTb]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherTb_DesignationId]    Script Date: 4/23/2023 10:15:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherTb_DesignationId] ON [dbo].[TeacherTb]
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CourseAssignTb] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Action]
GO
ALTER TABLE [dbo].[AllocateClassTb]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassTb_CourseTb_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[CourseTb] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassTb] CHECK CONSTRAINT [FK_AllocateClassTb_CourseTb_CourseId]
GO
ALTER TABLE [dbo].[AllocateClassTb]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassTb_DayTb_DayId] FOREIGN KEY([DayId])
REFERENCES [dbo].[DayTb] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassTb] CHECK CONSTRAINT [FK_AllocateClassTb_DayTb_DayId]
GO
ALTER TABLE [dbo].[AllocateClassTb]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassTb_DepartmentTb_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[DepartmentTb] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassTb] CHECK CONSTRAINT [FK_AllocateClassTb_DepartmentTb_DepartmentId]
GO
ALTER TABLE [dbo].[AllocateClassTb]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassTb_RoomTb_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[RoomTb] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassTb] CHECK CONSTRAINT [FK_AllocateClassTb_RoomTb_RoomId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CourseAssignTb]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTb_CourseTb_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[CourseTb] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignTb] CHECK CONSTRAINT [FK_CourseAssignTb_CourseTb_CourseId]
GO
ALTER TABLE [dbo].[CourseAssignTb]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTb_DepartmentTb_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[DepartmentTb] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignTb] CHECK CONSTRAINT [FK_CourseAssignTb_DepartmentTb_DepartmentId]
GO
ALTER TABLE [dbo].[CourseAssignTb]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTb_TeacherTb_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[TeacherTb] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignTb] CHECK CONSTRAINT [FK_CourseAssignTb_TeacherTb_TeacherId]
GO
ALTER TABLE [dbo].[CourseTb]  WITH CHECK ADD  CONSTRAINT [FK_CourseTb_DepartmentTb_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[DepartmentTb] ([Id])
GO
ALTER TABLE [dbo].[CourseTb] CHECK CONSTRAINT [FK_CourseTb_DepartmentTb_DepartmentId]
GO
ALTER TABLE [dbo].[CourseTb]  WITH CHECK ADD  CONSTRAINT [FK_CourseTb_SemesterTb_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[SemesterTb] ([Id])
GO
ALTER TABLE [dbo].[CourseTb] CHECK CONSTRAINT [FK_CourseTb_SemesterTb_SemesterId]
GO
ALTER TABLE [dbo].[EnrollCourseTb]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourseTb_CourseTb_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[CourseTb] ([Id])
GO
ALTER TABLE [dbo].[EnrollCourseTb] CHECK CONSTRAINT [FK_EnrollCourseTb_CourseTb_CourseId]
GO
ALTER TABLE [dbo].[EnrollCourseTb]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourseTb_StudentTb_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[StudentTb] ([Id])
GO
ALTER TABLE [dbo].[EnrollCourseTb] CHECK CONSTRAINT [FK_EnrollCourseTb_StudentTb_StudentId]
GO
ALTER TABLE [dbo].[StudentResultTb]  WITH CHECK ADD  CONSTRAINT [FK_StudentResultTb_CourseTb_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[CourseTb] ([Id])
GO
ALTER TABLE [dbo].[StudentResultTb] CHECK CONSTRAINT [FK_StudentResultTb_CourseTb_CourseId]
GO
ALTER TABLE [dbo].[StudentResultTb]  WITH CHECK ADD  CONSTRAINT [FK_StudentResultTb_GradeLetterTb_GradeLetterId] FOREIGN KEY([GradeLetterId])
REFERENCES [dbo].[GradeLetterTb] ([Id])
GO
ALTER TABLE [dbo].[StudentResultTb] CHECK CONSTRAINT [FK_StudentResultTb_GradeLetterTb_GradeLetterId]
GO
ALTER TABLE [dbo].[StudentResultTb]  WITH CHECK ADD  CONSTRAINT [FK_StudentResultTb_StudentTb_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[StudentTb] ([Id])
GO
ALTER TABLE [dbo].[StudentResultTb] CHECK CONSTRAINT [FK_StudentResultTb_StudentTb_StudentId]
GO
ALTER TABLE [dbo].[StudentTb]  WITH CHECK ADD  CONSTRAINT [FK_StudentTb_DepartmentTb_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[DepartmentTb] ([Id])
GO
ALTER TABLE [dbo].[StudentTb] CHECK CONSTRAINT [FK_StudentTb_DepartmentTb_DepartmentId]
GO
ALTER TABLE [dbo].[TeacherTb]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTb_DepartmentTb_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[DepartmentTb] ([Id])
GO
ALTER TABLE [dbo].[TeacherTb] CHECK CONSTRAINT [FK_TeacherTb_DepartmentTb_DepartmentId]
GO
ALTER TABLE [dbo].[TeacherTb]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTb_DesignationTb_DesignationId] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[DesignationTb] ([Id])
GO
ALTER TABLE [dbo].[TeacherTb] CHECK CONSTRAINT [FK_TeacherTb_DesignationTb_DesignationId]
GO
USE [master]
GO
ALTER DATABASE [studentDB] SET  READ_WRITE 
GO
