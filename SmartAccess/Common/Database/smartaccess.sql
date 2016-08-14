USE [master]
GO 
IF EXISTS(SELECT 1 FROM sysdatabases WHERE NAME=N'SmartAccess') 
BEGIN 
DROP DATABASE SmartAccess --如果数据库存在先删掉数据库 
END
GO
/****** Object:  Database [SmartAccess]    Script Date: 08/09/2016 18:32:25 ******/
CREATE DATABASE [SmartAccess] ON  PRIMARY 
( NAME = N'SmartAccess', FILENAME = N'${DBPATH}\SmartAccess.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SmartAccess_log', FILENAME = N'${DBPATH}\SmartAccess_log.ldf' , SIZE = 1792KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SmartAccess] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SmartAccess].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SmartAccess] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SmartAccess] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SmartAccess] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SmartAccess] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SmartAccess] SET ARITHABORT OFF
GO
ALTER DATABASE [SmartAccess] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SmartAccess] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SmartAccess] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SmartAccess] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SmartAccess] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SmartAccess] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SmartAccess] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SmartAccess] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SmartAccess] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SmartAccess] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SmartAccess] SET  DISABLE_BROKER
GO
ALTER DATABASE [SmartAccess] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SmartAccess] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SmartAccess] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SmartAccess] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SmartAccess] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SmartAccess] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SmartAccess] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SmartAccess] SET  READ_WRITE
GO
ALTER DATABASE [SmartAccess] SET RECOVERY FULL
GO
ALTER DATABASE [SmartAccess] SET  MULTI_USER
GO
ALTER DATABASE [SmartAccess] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SmartAccess] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'SmartAccess', N'ON'
GO
USE [SmartAccess]
GO
/****** Object:  Table [dbo].[SMT_USER_INFO]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_USER_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[USER_NAME] [nvarchar](50) NOT NULL,
	[PASS_WORD] [nvarchar](100) NULL,
	[IS_ENABLE] [bit] NOT NULL,
	[IS_DELETE] [bit] NOT NULL,
	[ORDER_VALUE] [int] NULL,
	[REAL_NAME] [nvarchar](50) NULL,
	[ORG_ID] [decimal](18, 0) NULL,
	[TELEPHONE] [nvarchar](50) NULL,
	[ADDRESS] [nvarchar](100) NULL,
	[EMAIL] [nvarchar](100) NULL,
	[QQ] [nvarchar](50) NULL,
 CONSTRAINT [PK_SMT_USER_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNI_SMTUI_USER_NAME] UNIQUE NONCLUSTERED 
(
	[USER_NAME] ASC,
	[IS_DELETE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'USER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码，重置密码为：123456' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'PASS_WORD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用，0 禁用 1启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'IS_ENABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除，0 未删除 1 删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'IS_DELETE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'ORDER_VALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'REAL_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门/组织ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'ORG_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'TELEPHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'EMAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'QQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统用户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO'
GO
/****** Object:  Table [dbo].[SMT_STAFF_INFO]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_STAFF_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[ORG_ID] [decimal](18, 0) NULL,
	[STAFF_NO_TEMPLET] [decimal](18, 0) NULL,
	[STAFF_NO] [nvarchar](400) NULL,
	[REAL_NAME] [nvarchar](100) NOT NULL,
	[SEX] [tinyint] NULL,
	[JOB] [nvarchar](200) NULL,
	[BIRTHDAY] [date] NULL,
	[POLITICS] [nvarchar](100) NULL,
	[MARRIED] [tinyint] NULL,
	[SKIIL_LEVEL] [nvarchar](100) NULL,
	[CER_NAME] [nvarchar](100) NULL,
	[CER_NO] [nvarchar](400) NULL,
	[TELE_PHONE] [nvarchar](100) NULL,
	[CELL_PHONE] [nvarchar](100) NULL,
	[NATIVE] [nvarchar](400) NULL,
	[NATION] [nvarchar](100) NULL,
	[RELIGION] [nvarchar](100) NULL,
	[EDUCATIONAL] [nvarchar](100) NULL,
	[EMAIL] [nvarchar](100) NULL,
	[VALID_STARTTIME] [datetime] NOT NULL,
	[VALID_ENDTIME] [datetime] NOT NULL,
	[ENTRY_TIME] [date] NULL,
	[ABORT_TIME] [date] NULL,
	[ADDRESS] [nvarchar](400) NULL,
	[PHOTO] [image] NULL,
	[CER_PHOTO_FRONT] [image] NULL,
	[CER_PHOTO_BACK] [image] NULL,
	[PRINT_TEMPLET_ID] [decimal](18, 0) NULL,
	[IS_FORBIDDEN] [bit] NOT NULL,
	[IS_DELETE] [bit] NOT NULL,
	[REG_TIME] [datetime] NOT NULL,
	[DEL_TIME] [datetime] NULL,
	[FORBIDDEN_TIME] [datetime] NULL,
	[ENABLE_TIME] [datetime] NULL,
	[MODIFY_TIME] [datetime] NULL,
 CONSTRAINT [PK_SMT_STAFF_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门组织ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'ORG_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职员证件编号模板ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'STAFF_NO_TEMPLET'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职员/证件编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'STAFF_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职员姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'REAL_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别，0 未知 1 男 2 女' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'SEX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'JOB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出身年月日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'BIRTHDAY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'政治面貌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'POLITICS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MARRIED' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'MARRIED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'技术等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'SKIIL_LEVEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效证件名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'CER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效证件号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'CER_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'办公电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'TELE_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'CELL_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'籍贯' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'NATIVE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'NATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宗教' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'RELIGION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'EDUCATIONAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'EMAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'VALID_STARTTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'VALID_ENDTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入职时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'ENTRY_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'离职时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'ABORT_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通信地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'PHOTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效证件正面照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'CER_PHOTO_FRONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效证件背面照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'CER_PHOTO_BACK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用的打印证件模板ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'PRINT_TEMPLET_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否被禁用/挂失' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'IS_FORBIDDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否被删除/注销' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'IS_DELETE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'REG_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO', @level2type=N'COLUMN',@level2name=N'MODIFY_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工职员表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_INFO'
GO
/****** Object:  Table [dbo].[SMT_STAFF_DOOR]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_STAFF_DOOR](
	[STAFF_ID] [decimal](18, 0) NOT NULL,
	[DOOR_ID] [decimal](18, 0) NOT NULL,
	[IS_UPLOAD] [bit] NOT NULL,
	[UPLOAD_TIME] [datetime] NOT NULL,
	[ADD_TIME] [datetime] NOT NULL,
 CONSTRAINT [PK_SMT_STAFF_DOOR] PRIMARY KEY CLUSTERED 
(
	[STAFF_ID] ASC,
	[DOOR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_DOOR', @level2type=N'COLUMN',@level2name=N'STAFF_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_DOOR', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已上传' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_DOOR', @level2type=N'COLUMN',@level2name=N'IS_UPLOAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上传时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_DOOR', @level2type=N'COLUMN',@level2name=N'UPLOAD_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_DOOR', @level2type=N'COLUMN',@level2name=N'ADD_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工门权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_DOOR'
GO
/****** Object:  Table [dbo].[SMT_STAFF_CARD]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_STAFF_CARD](
	[STAFF_ID] [decimal](18, 0) NOT NULL,
	[CARD_ID] [decimal](18, 0) NOT NULL,
	[ACCESS_STARTTIME] [datetime] NOT NULL,
	[ACCESS_ENDTIME] [datetime] NOT NULL,
 CONSTRAINT [PK_SMT_STAFF_CARD] PRIMARY KEY CLUSTERED 
(
	[STAFF_ID] ASC,
	[CARD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门禁有效开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_CARD', @level2type=N'COLUMN',@level2name=N'ACCESS_STARTTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门禁有效结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_CARD', @level2type=N'COLUMN',@level2name=N'ACCESS_ENDTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工卡关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_CARD'
GO
/****** Object:  Table [dbo].[SMT_ORG_INFO]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_ORG_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[PAR_ID] [decimal](18, 0) NOT NULL,
	[ORG_CODE] [varchar](100) NOT NULL,
	[ORG_NAME] [nvarchar](100) NULL,
	[ORDER_VALUE] [int] NULL,
 CONSTRAINT [PK_SMT_ORG_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织机构ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ORG_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级组织机构ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ORG_INFO', @level2type=N'COLUMN',@level2name=N'PAR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ORG_INFO', @level2type=N'COLUMN',@level2name=N'ORG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织机构名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ORG_INFO', @level2type=N'COLUMN',@level2name=N'ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ORG_INFO', @level2type=N'COLUMN',@level2name=N'ORDER_VALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织机构部门表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ORG_INFO'
GO
/****** Object:  Table [dbo].[SMT_FUN_MENUPOINT]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_FUN_MENUPOINT](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[PAR_ID] [decimal](18, 0) NOT NULL,
	[FUN_CODE] [varchar](100) NOT NULL,
	[FUN_NAME] [nvarchar](200) NOT NULL,
	[IS_MENU] [bit] NULL,
 CONSTRAINT [PK_SMT_FUN_MENUPOINT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上一级功能ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'PAR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'FUN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'FUN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'IS_MENU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能菜单/功能点表[SMT_FUN_MENUPOINT]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT'
GO
/****** Object:  Table [dbo].[SMT_DOOR_INFO]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_DOOR_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[DOOR_NAME] [nvarchar](200) NOT NULL,
	[CTRL_ID] [decimal](18, 0) NULL,
	[CTRL_DOOR_INDEX] [tinyint] NULL,
	[DOOR_DESC] [nvarchar](400) NULL,
	[CTRL_STYLE] [tinyint] NOT NULL,
	[CTRL_DELAY_TIME] [tinyint] NOT NULL,
	[IS_ENABLE] [bit] NOT NULL,
	[IS_ENTER1] [bit] NOT NULL,
	[IS_ENTER2] [bit] NOT NULL,
	[IS_ATTENDANCE1] [bit] NOT NULL,
	[IS_ATTENDANCE2] [bit] NOT NULL,
 CONSTRAINT [PK_SMT_DOOR_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'DOOR_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联控制器ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'CTRL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联控制器门号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'CTRL_DOOR_INDEX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'DOOR_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制方式,0 在线，1 常开，2 常闭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'CTRL_STYLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开门延时(秒)，不低于1s 默认3s' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'CTRL_DELAY_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'IS_ENABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否进门1，双向1，单向1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'IS_ENTER1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否进门2，双向2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'IS_ENTER2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否考勤1，双向1，单向1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'IS_ATTENDANCE1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否考勤2，双向2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'IS_ATTENDANCE2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO'
GO
/****** Object:  Table [dbo].[SMT_CONTROLLER_ZONE]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_CONTROLLER_ZONE](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[PAR_ID] [decimal](18, 0) NULL,
	[ZONE_NAME] [nvarchar](100) NOT NULL,
	[ZONE_DESC] [nvarchar](200) NULL,
	[ORDER_VALUE] [int] NULL,
 CONSTRAINT [PK_SMT_CONTROLLER_ZONE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_ZONE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级区域ID  0 为跟级区域' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_ZONE', @level2type=N'COLUMN',@level2name=N'PAR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_ZONE', @level2type=N'COLUMN',@level2name=N'ZONE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_ZONE', @level2type=N'COLUMN',@level2name=N'ZONE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_ZONE', @level2type=N'COLUMN',@level2name=N'ORDER_VALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器区域表[SMT_CONTROLLER_ZONE]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_ZONE'
GO
/****** Object:  Table [dbo].[SMT_CONTROLLER_INFO]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_CONTROLLER_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[SN_NO] [varchar](100) NOT NULL,
	[NAME] [nvarchar](200) NULL,
	[IP] [varchar](40) NULL,
	[PORT] [int] NULL,
	[MASK] [varchar](40) NULL,
	[GATEWAY] [varchar](40) NULL,
	[MAC] [varchar](40) NULL,
	[CTRLR_TYPE] [tinyint] NULL,
	[DRIVER_VERSION] [varchar](20) NULL,
	[DRIVER_DATE] [date] NULL,
	[CTRLR_DESC] [nvarchar](400) NULL,
	[AREA_ID] [decimal](18, 0) NULL,
	[ORDER_VALUE] [int] NULL,
	[ORG_ID] [decimal](18, 0) NULL,
	[CTRLR_MODEL] [varchar](20) NULL,
	[IS_ENABLE] [bit] NULL,
 CONSTRAINT [PK_SMT_CONTROLLER_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [SMT_CONTROLLER_SN_INDEX] ON [dbo].[SMT_CONTROLLER_INFO] 
(
	[SN_NO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'SN_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'PORT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子网掩码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'MASK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'GATEWAY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MAC地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'MAC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器类型:OneDoorTwoDirections=0,//单门双向  ;  TwoDoorsTwoDirections=1,//双门双向
   ; FourDoorsOneDirection=2,//四门单向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'CTRLR_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'驱动版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'DRIVER_VERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'驱动发行日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'DRIVER_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'CTRLR_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属区域ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'AREA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'ORDER_VALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'ORG_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器型号类型："WGACCESS"  WG门禁控制器；' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'CTRLR_MODEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO'
GO
/****** Object:  Table [dbo].[SMT_CARD_RECORDS]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_CARD_RECORDS](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CTRLR_SN] [varchar](100) NULL,
	[RECORD_INDEX] [decimal](18, 0) NULL,
	[RECORD_TYPE] [varchar](15) NULL,
	[RECORD_REASON] [varchar](30) NULL,
	[RECORD_DESC] [nvarchar](400) NULL,
	[RECORD_DATE] [date] NULL,
	[CARD_NO] [varchar](100) NULL,
	[IS_ENTER] [bit] NULL,
	[IS_ALLOW] [bit] NULL,
	[CTRLR_DOOR_INDEX] [tinyint] NULL,
	[CTRLR_ID] [decimal](18, 0) NULL,
	[DOOR_ID] [decimal](18, 0) NULL,
	[STAFF_ID] [decimal](18, 0) NULL,
 CONSTRAINT [PK_SMT_CARD_RECORDS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录的编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'CTRLR_SN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录的索引号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'RECORD_INDEX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'RECORD_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'详细记录原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'RECORD_REASON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'RECORD_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录的卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'CARD_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是进门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'IS_ENTER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否通过' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'IS_ALLOW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'于控制器的上门序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'CTRLR_DOOR_INDEX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的控制器ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'CTRLR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的职员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS', @level2type=N'COLUMN',@level2name=N'STAFF_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'刷卡记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_RECORDS'
GO
/****** Object:  Table [dbo].[SMT_CARD_INFO]    Script Date: 08/09/2016 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_CARD_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CARD_NO] [varchar](100) NULL,
	[CARD_DESC] [nvarchar](400) NULL,
	[CARD_TYPE] [tinyint] NULL,
	[CARD_WG_NO] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SMT_CARD_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_INFO', @level2type=N'COLUMN',@level2name=N'CARD_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_INFO', @level2type=N'COLUMN',@level2name=N'CARD_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡类型,根据不同类型待定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_INFO', @level2type=N'COLUMN',@level2name=N'CARD_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CARD_INFO'
GO
/****** Object:  Default [DF_SMT_USER_INFO_IS_ENABLE]    Script Date: 08/09/2016 18:32:26 ******/
ALTER TABLE [dbo].[SMT_USER_INFO] ADD  CONSTRAINT [DF_SMT_USER_INFO_IS_ENABLE]  DEFAULT ((1)) FOR [IS_ENABLE]
GO
/****** Object:  Default [DF_SMT_USER_INFO_IS_DELETE]    Script Date: 08/09/2016 18:32:26 ******/
ALTER TABLE [dbo].[SMT_USER_INFO] ADD  CONSTRAINT [DF_SMT_USER_INFO_IS_DELETE]  DEFAULT ((0)) FOR [IS_DELETE]
GO
/****** Object:  Default [DF_SMT_ORG_INFO_PAR_ID]    Script Date: 08/09/2016 18:32:26 ******/
ALTER TABLE [dbo].[SMT_ORG_INFO] ADD  CONSTRAINT [DF_SMT_ORG_INFO_PAR_ID]  DEFAULT ((1)) FOR [PAR_ID]
GO
/****** Object:  Default [DF_SMT_CONTROLLER_ZONE_PAR_ID]    Script Date: 08/09/2016 18:32:26 ******/
ALTER TABLE [dbo].[SMT_CONTROLLER_ZONE] ADD  CONSTRAINT [DF_SMT_CONTROLLER_ZONE_PAR_ID]  DEFAULT ((0)) FOR [PAR_ID]
GO
INSERT INTO [dbo].[SMT_USER_INFO] (USER_NAME,PASS_WORD,REAL_NAME,IS_ENABLE,IS_DELETE,ORDER_VALUE) values('admin',substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','admin')),3,32),'admin',1,0,100)
GO