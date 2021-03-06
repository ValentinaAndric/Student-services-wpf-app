USE [master]
GO
/****** Object:  Database [Studentska sluzba]    Script Date: 30.11.2020. 16:24:22 ******/
CREATE DATABASE [Studentska sluzba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Studentska sluzba', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Studentska sluzba.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Studentska sluzba_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Studentska sluzba_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Studentska sluzba] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Studentska sluzba].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Studentska sluzba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Studentska sluzba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Studentska sluzba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Studentska sluzba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Studentska sluzba] SET ARITHABORT OFF 
GO
ALTER DATABASE [Studentska sluzba] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Studentska sluzba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Studentska sluzba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Studentska sluzba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Studentska sluzba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Studentska sluzba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Studentska sluzba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Studentska sluzba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Studentska sluzba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Studentska sluzba] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Studentska sluzba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Studentska sluzba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Studentska sluzba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Studentska sluzba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Studentska sluzba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Studentska sluzba] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Studentska sluzba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Studentska sluzba] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Studentska sluzba] SET  MULTI_USER 
GO
ALTER DATABASE [Studentska sluzba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Studentska sluzba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Studentska sluzba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Studentska sluzba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Studentska sluzba] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Studentska sluzba] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Studentska sluzba] SET QUERY_STORE = OFF
GO
USE [Studentska sluzba]
GO
/****** Object:  Table [dbo].[tblClassroom]    Script Date: 30.11.2020. 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClassroom](
	[ClassroomID] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfClassroom] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tblClassroom] PRIMARY KEY CLUSTERED 
(
	[ClassroomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 30.11.2020. 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](30) NOT NULL,
	[EmployeeSurname] [nvarchar](40) NOT NULL,
	[Counter] [int] NOT NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblExam]    Script Date: 30.11.2020. 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblExam](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](20) NOT NULL,
	[Time] [nvarchar](20) NOT NULL,
	[StudentID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[ClassroomID] [int] NULL,
 CONSTRAINT [PK_tblExam] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPaymentSlip]    Script Date: 30.11.2020. 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPaymentSlip](
	[PaymentSlipID] [int] IDENTITY(1,1) NOT NULL,
	[BankAccountNumber] [nvarchar](30) NOT NULL,
	[Sum] [nvarchar](20) NOT NULL,
	[StudentID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_tblPaymentSlip] PRIMARY KEY CLUSTERED 
(
	[PaymentSlipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudent]    Script Date: 30.11.2020. 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudent](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](40) NOT NULL,
	[NumberOfIndex] [nvarchar](13) NOT NULL,
	[Adress] [nvarchar](40) NULL,
	[City] [nvarchar](30) NULL,
	[Contact] [nvarchar](30) NOT NULL,
	[StudyProgramID] [int] NOT NULL,
 CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudyProgram]    Script Date: 30.11.2020. 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudyProgram](
	[StudyProgramID] [int] IDENTITY(1,1) NOT NULL,
	[NameOfStudyProgram] [nvarchar](60) NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_tblStudyProgram] PRIMARY KEY CLUSTERED 
(
	[StudyProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubject]    Script Date: 30.11.2020. 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[NameOfSubject] [nvarchar](60) NOT NULL,
	[Professor] [nvarchar](60) NOT NULL,
	[ESPB] [int] NULL,
 CONSTRAINT [PK_tblSubject] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblPaymentSlip]  WITH CHECK ADD  CONSTRAINT [FK_tblPaymentSlip_tblEmployee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[tblEmployee] ([EmployeeID])
GO
ALTER TABLE [dbo].[tblPaymentSlip] CHECK CONSTRAINT [FK_tblPaymentSlip_tblEmployee]
GO
ALTER TABLE [dbo].[tblPaymentSlip]  WITH CHECK ADD  CONSTRAINT [FK_tblPaymentSlip_tblStudent] FOREIGN KEY([StudentID])
REFERENCES [dbo].[tblStudent] ([StudentID])
GO
ALTER TABLE [dbo].[tblPaymentSlip] CHECK CONSTRAINT [FK_tblPaymentSlip_tblStudent]
GO
ALTER TABLE [dbo].[tblStudent]  WITH CHECK ADD  CONSTRAINT [FK_tblStudent_tblStudyProgram] FOREIGN KEY([StudyProgramID])
REFERENCES [dbo].[tblStudyProgram] ([StudyProgramID])
GO
ALTER TABLE [dbo].[tblStudent] CHECK CONSTRAINT [FK_tblStudent_tblStudyProgram]
GO
USE [master]
GO
ALTER DATABASE [Studentska sluzba] SET  READ_WRITE 
GO
