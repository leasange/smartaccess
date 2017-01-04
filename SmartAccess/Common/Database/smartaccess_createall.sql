USE [master]
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
/****** Object:  Table [dbo].[SMT_WEEKEX_INFO]    Script Date: 01/04/2017 22:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_WEEKEX_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[WEEKEX_DESC] [nvarchar](200) NULL,
	[WEEKEX_ON_DUTY] [bit] NOT NULL,
	[WEEKEX_START_DATE] [datetime] NOT NULL,
	[WEEKEX_END_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_SMT_WEEKEX_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_WEEKEX_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_WEEKEX_INFO', @level2type=N'COLUMN',@level2name=N'WEEKEX_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否上班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_WEEKEX_INFO', @level2type=N'COLUMN',@level2name=N'WEEKEX_ON_DUTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_WEEKEX_INFO', @level2type=N'COLUMN',@level2name=N'WEEKEX_START_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_WEEKEX_INFO', @level2type=N'COLUMN',@level2name=N'WEEKEX_END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'假期约束' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_WEEKEX_INFO'
GO
/****** Object:  Table [dbo].[SMT_VERMODEL_INFO]    Script Date: 01/04/2017 22:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_VERMODEL_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[VERM_NAME] [nvarchar](100) NOT NULL,
	[VERM_CONTENT] [varbinary](max) NULL,
	[VERM_ADDTIME] [datetime] NOT NULL,
	[VERM_MODIFYTIME] [datetime] NOT NULL,
	[VERM_ADDUSERID] [decimal](18, 0) NULL,
 CONSTRAINT [PK_SMT_VERMODEL_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [AK_KEY_2_SMT_VERM] UNIQUE NONCLUSTERED 
(
	[VERM_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VERMODEL_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模板名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VERMODEL_INFO', @level2type=N'COLUMN',@level2name=N'VERM_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模板类容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VERMODEL_INFO', @level2type=N'COLUMN',@level2name=N'VERM_CONTENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VERMODEL_INFO', @level2type=N'COLUMN',@level2name=N'VERM_ADDTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VERMODEL_INFO', @level2type=N'COLUMN',@level2name=N'VERM_MODIFYTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VERMODEL_INFO', @level2type=N'COLUMN',@level2name=N'VERM_ADDUSERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'证件模板信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VERMODEL_INFO'
GO
/****** Object:  Table [dbo].[SMT_VER_FORMAT]    Script Date: 01/04/2017 22:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_VER_FORMAT](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[VER_TYPE] [smallint] NOT NULL,
	[VER_NAME] [nvarchar](40) NOT NULL,
	[VER_FORMAT] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_SMT_VER_FORMAT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VER_FORMAT', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：工作证 1：身份证 2：驾驶证 3：其他' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VER_FORMAT', @level2type=N'COLUMN',@level2name=N'VER_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'证件名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VER_FORMAT', @level2type=N'COLUMN',@level2name=N'VER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码格式：[0] 代表数字，[A]代表大写字母，[a]代表小写字母，[N]代表任意数字或大写字母，[n]代表任意数字或小写字母，其他表示实际字符' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VER_FORMAT', @level2type=N'COLUMN',@level2name=N'VER_FORMAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'证件编码格式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_VER_FORMAT'
GO
/****** Object:  Table [dbo].[SMT_USER_INFO]    Script Date: 01/04/2017 22:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
	[ROLE_ID] [decimal](18, 0) NULL,
	[KEY_VAL] [varchar](200) NULL,
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
SET ANSI_PADDING OFF
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'key值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO', @level2type=N'COLUMN',@level2name=N'KEY_VAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统用户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_USER_INFO'
GO
/****** Object:  Table [dbo].[SMT_TIMESCALE_INFO]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_TIMESCALE_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[TIME_NO] [int] NOT NULL,
	[TIME_NAME] [nvarchar](100) NOT NULL,
	[TIME_WEEK_DAY1] [bit] NOT NULL,
	[TIME_WEEK_DAY2] [bit] NOT NULL,
	[TIME_WEEK_DAY3] [bit] NOT NULL,
	[TIME_WEEK_DAY4] [bit] NOT NULL,
	[TIME_WEEK_DAY5] [bit] NOT NULL,
	[TIME_WEEK_DAY6] [bit] NOT NULL,
	[TIME_WEEK_DAY7] [bit] NOT NULL,
	[TIME_DATE_START] [date] NOT NULL,
	[TIME_DATE_END] [date] NOT NULL,
	[TIME_RANGE_START1] [time](7) NOT NULL,
	[TIME_RANGE_END1] [time](7) NOT NULL,
	[TIME_RANGE_START2] [time](7) NOT NULL,
	[TIME_RANGE_END2] [time](7) NOT NULL,
	[TIME_RANGE_START3] [time](7) NOT NULL,
	[TIME_RANGE_END3] [time](7) NOT NULL,
	[TIME_NEXT_NO] [int] NOT NULL,
 CONSTRAINT [PK_SMT_TIMESCALE_INFO] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [AK_KEY_2_SMT_TIME] UNIQUE NONCLUSTERED 
(
	[TIME_NO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时段号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时段名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_WEEK_DAY1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期二' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_WEEK_DAY2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期四' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_WEEK_DAY4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期五' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_WEEK_DAY5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期六' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_WEEK_DAY6'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_WEEK_DAY7'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_DATE_START'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_DATE_END'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时区开始1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_RANGE_START1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时区结束1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_RANGE_END1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时区开始2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_RANGE_START2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时区结束2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_RANGE_END2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时区开始3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_RANGE_START3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时区结束3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_RANGE_END3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下一时段号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO', @level2type=N'COLUMN',@level2name=N'TIME_NEXT_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时段信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_TIMESCALE_INFO'
GO
/****** Object:  Table [dbo].[SMT_SUPER_PWD]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_SUPER_PWD](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[SUPER_PWD] [nvarchar](10) NOT NULL,
	[DOOR_ID] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_SUPER_PWD', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超级密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_SUPER_PWD', @level2type=N'COLUMN',@level2name=N'SUPER_PWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门禁ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_SUPER_PWD', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超级通信密码表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_SUPER_PWD'
GO
/****** Object:  Table [dbo].[SMT_STAFF_INFO]    Script Date: 01/04/2017 22:32:54 ******/
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
/****** Object:  Table [dbo].[SMT_STAFF_DOOR]    Script Date: 01/04/2017 22:32:54 ******/
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
	[TIME_NUM] [int] NOT NULL,
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
/****** Object:  Table [dbo].[SMT_STAFF_CARD]    Script Date: 01/04/2017 22:32:54 ******/
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
/****** Object:  Table [dbo].[SMT_ROLE_INFO]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_ROLE_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[ROLE_NAME] [nvarchar](50) NOT NULL,
	[ROLE_DESC] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_SMT_ROLE_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ROLE_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ROLE_INFO', @level2type=N'COLUMN',@level2name=N'ROLE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ROLE_INFO', @level2type=N'COLUMN',@level2name=N'ROLE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ROLE_INFO'
GO
/****** Object:  Table [dbo].[SMT_ROLE_FUN]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_ROLE_FUN](
	[ROLE_ID] [decimal](18, 0) NOT NULL,
	[FUN_ID] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_SMT_ROLE_FUN] PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC,
	[FUN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ROLE_FUN', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ROLE_FUN', @level2type=N'COLUMN',@level2name=N'FUN_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ROLE_FUN'
GO
/****** Object:  Table [dbo].[SMT_ORG_INFO]    Script Date: 01/04/2017 22:32:54 ******/
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
/****** Object:  Table [dbo].[SMT_MAP_INFO]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_MAP_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[MAP_NAME] [nvarchar](100) NOT NULL,
	[MAP_IMAGE] [image] NOT NULL,
	[CREATE_TIME] [datetime] NOT NULL,
	[GROUP_ID] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_SMT_MAP_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地图名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_INFO', @level2type=N'COLUMN',@level2name=N'MAP_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地图底图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_INFO', @level2type=N'COLUMN',@level2name=N'MAP_IMAGE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_INFO', @level2type=N'COLUMN',@level2name=N'CREATE_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属分组ID[待定]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_INFO', @level2type=N'COLUMN',@level2name=N'GROUP_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子地图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_INFO'
GO
/****** Object:  Table [dbo].[SMT_MAP_DOOR]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_MAP_DOOR](
	[MAP_ID] [decimal](18, 0) NOT NULL,
	[DOOR_ID] [decimal](18, 0) NOT NULL,
	[LOCATION_X] [real] NOT NULL,
	[LOCATION_Y] [real] NOT NULL,
	[WIDTH] [real] NOT NULL,
	[HEIGHT] [real] NOT NULL,
 CONSTRAINT [PK_SMT_MAP_DOOR] PRIMARY KEY CLUSTERED 
(
	[MAP_ID] ASC,
	[DOOR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地图ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_DOOR', @level2type=N'COLUMN',@level2name=N'MAP_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_DOOR', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'比例位置X' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_DOOR', @level2type=N'COLUMN',@level2name=N'LOCATION_X'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'比例位置Y' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_DOOR', @level2type=N'COLUMN',@level2name=N'LOCATION_Y'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'绝对宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_DOOR', @level2type=N'COLUMN',@level2name=N'WIDTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'绝对高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_DOOR', @level2type=N'COLUMN',@level2name=N'HEIGHT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子地图门关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_MAP_DOOR'
GO
/****** Object:  Table [dbo].[SMT_LOG_INFO]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_LOG_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[LOG_TYPE] [varchar](50) NOT NULL,
	[LOG_LEVEL] [smallint] NOT NULL,
	[OPR_USERID] [decimal](18, 0) NOT NULL,
	[OPR_REALNAME] [nvarchar](100) NOT NULL,
	[OPR_TIME] [datetime] NOT NULL,
	[OPR_CONTENT] [nvarchar](400) NOT NULL,
 CONSTRAINT [PK_SMT_LOG_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_LOG_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志类型：用户自定义，如：用户管理日志，服务器日志，角色管理日志等' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_LOG_INFO', @level2type=N'COLUMN',@level2name=N'LOG_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志级别，0 ERROR 异常错误日志，1 WARN警告日志，2 INFO消息记录日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_LOG_INFO', @level2type=N'COLUMN',@level2name=N'LOG_LEVEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_LOG_INFO', @level2type=N'COLUMN',@level2name=N'OPR_USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_LOG_INFO', @level2type=N'COLUMN',@level2name=N'OPR_REALNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_LOG_INFO', @level2type=N'COLUMN',@level2name=N'OPR_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_LOG_INFO', @level2type=N'COLUMN',@level2name=N'OPR_CONTENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作日志表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_LOG_INFO'
GO
/****** Object:  Table [dbo].[SMT_FUN_MENUPOINT]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_FUN_MENUPOINT](
	[ID] [decimal](18, 0) NOT NULL,
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
/****** Object:  Table [dbo].[SMT_DOOR_INFO]    Script Date: 01/04/2017 22:32:54 ******/
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
	[OPEN_STATE] [tinyint] NOT NULL,
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门禁状态：0 关门 1 打开 2 离线' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO', @level2type=N'COLUMN',@level2name=N'OPEN_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_INFO'
GO
/****** Object:  Table [dbo].[SMT_DEPT_USER]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_DEPT_USER](
	[DEPT_ID] [decimal](18, 0) NOT NULL,
	[USER_ID] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_SMT_DEPT_USER] PRIMARY KEY CLUSTERED 
(
	[DEPT_ID] ASC,
	[USER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DEPT_USER', @level2type=N'COLUMN',@level2name=N'DEPT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DEPT_USER', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门用户权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DEPT_USER'
GO
/****** Object:  Table [dbo].[SMT_DATADICTIONARY_INFO]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_DATADICTIONARY_INFO](
	[DATA_TYPE] [varchar](20) NOT NULL,
	[DATA_KEY] [varchar](40) NOT NULL,
	[DATA_VALUE] [nvarchar](500) NOT NULL,
	[DATA_NAME] [nvarchar](80) NULL,
	[DATA_CONTENT] [nvarchar](500) NULL,
 CONSTRAINT [PK_SMT_DATADICTIONARY_INFO] PRIMARY KEY CLUSTERED 
(
	[DATA_TYPE] ASC,
	[DATA_KEY] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_KEY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_VALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_CONTENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据字典管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO'
GO
/****** Object:  Table [dbo].[SMT_CTRLR_TASK]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_CTRLR_TASK](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[TASK_NO] [varchar](20) NOT NULL,
	[TASK_NAME] [nvarchar](200) NOT NULL,
	[VALID_STARTDATE] [date] NOT NULL,
	[VALID_ENDDATE] [date] NOT NULL,
	[ACTION_TIME] [time](7) NOT NULL,
	[MON_STATE] [bit] NOT NULL,
	[TUE_STATE] [bit] NOT NULL,
	[THI_STATE] [bit] NOT NULL,
	[WES_STATE] [bit] NOT NULL,
	[FRI_STATE] [bit] NOT NULL,
	[SAT_STATE] [bit] NOT NULL,
	[SUN_STATE] [bit] NOT NULL,
	[DOOR_ID] [varchar](5000) NOT NULL,
	[CTRL_STYLE] [tinyint] NOT NULL,
	[TASK_DESC] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_SMT_CTRLR_TASK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'TASK_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'TASK_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效期开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'VALID_STARTDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效期结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'VALID_ENDDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'触发时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'ACTION_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期一状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'MON_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期二状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'TUE_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期三状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'THI_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期四状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'WES_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期五状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'FRI_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期六状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'SAT_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星期日状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'SUN_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门ID列表，逗号隔开：-1 表示所有门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'CTRL_STYLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK', @level2type=N'COLUMN',@level2name=N'TASK_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制定时任务表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CTRLR_TASK'
GO
/****** Object:  Table [dbo].[SMT_CONTROLLER_ZONE]    Script Date: 01/04/2017 22:32:54 ******/
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
/****** Object:  Table [dbo].[SMT_CONTROLLER_INFO]    Script Date: 01/04/2017 22:32:54 ******/
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
/****** Object:  Table [dbo].[SMT_CARD_RECORDS]    Script Date: 01/04/2017 22:32:54 ******/
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
	[RECORD_DATE] [datetime] NULL,
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
/****** Object:  Table [dbo].[SMT_CARD_INFO]    Script Date: 01/04/2017 22:32:54 ******/
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
/****** Object:  Table [dbo].[SMT_ALARM_SETTING]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_ALARM_SETTING](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CTRL_ID] [decimal](18, 0) NOT NULL,
	[CTRL_FORCE_PWD] [varchar](10) NULL,
	[ENABLE_FORCE_PWD] [bit] NOT NULL,
	[NOT_CLOSED_TIMEOUT] [tinyint] NULL,
	[ENABLE_CLOSED_TIMEOUT] [bit] NOT NULL,
	[ENABLE_FORCE_ACCESS] [bit] NOT NULL,
	[ENABLE_FORCE_CLOSE] [bit] NOT NULL,
	[ENABLE_INVALID_CARD] [bit] NOT NULL,
	[ENABLE_FIRE] [bit] NOT NULL,
	[ENABLE_STEAL] [bit] NOT NULL,
	[ENABLE_FORCE_CARD] [bit] NOT NULL,
 CONSTRAINT [PK_SMT_ALARM_SETTING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器ID号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'CTRL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'胁迫密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'CTRL_FORCE_PWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用胁迫密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FORCE_PWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门长时间未关超时时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'NOT_CLOSED_TIMEOUT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用门长时间未关报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_CLOSED_TIMEOUT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用强行闯入报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FORCE_ACCESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用强制关门报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FORCE_CLOSE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用无效刷卡报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_INVALID_CARD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用火警报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FIRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用防盗报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_STEAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用胁迫必须刷合法卡' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FORCE_CARD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警信息配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING'
GO
/****** Object:  Table [dbo].[SMT_ALARM_INFO]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_ALARM_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[ALARM_TYPE] [tinyint] NOT NULL,
	[ALARM_NAME] [nvarchar](50) NULL,
	[ALARM_CONTENT] [nvarchar](200) NULL,
	[ALARM_TIME] [datetime] NOT NULL,
	[RECORD_ID] [decimal](18, 0) NULL,
	[CARD_NO] [varchar](100) NULL,
	[CTRLR_DOOR_INDEX] [tinyint] NULL,
	[CTRLR_ID] [decimal](18, 0) NULL,
	[DOOR_ID] [decimal](18, 0) NULL,
	[STAFF_ID] [decimal](18, 0) NULL,
 CONSTRAINT [PK_SMT_ALARM_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ALARM_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ALARM_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ALARM_CONTENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ALARM_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'RECORD_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录的卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'CARD_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'于控制器的上门序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'CTRLR_DOOR_INDEX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的控制器ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'CTRLR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的职员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'STAFF_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO'
GO
/****** Object:  Table [dbo].[SMT_ALARM_CONNECT]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_ALARM_CONNECT](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CTRL_ID] [decimal](18, 0) NOT NULL,
	[OUT_PORT] [tinyint] NOT NULL,
	[DOOR_ID] [tinyint] NOT NULL,
	[ENB_FORCE_PWD_EVENT] [bit] NOT NULL,
	[ENB_UNCLOSED_EVENT] [bit] NOT NULL,
	[ENB_FORCE_ACCESS_EVENT] [bit] NOT NULL,
	[ENB_FORCE_CLOSE_EVENT] [bit] NOT NULL,
	[ENB_INVALID_CARD_EVENT] [bit] NOT NULL,
	[ENB_FIRE_EVENT] [bit] NOT NULL,
	[ENB_RELAY_EVENT] [bit] NOT NULL,
	[ENB_CONNECT_ITEM] [tinyint] NOT NULL,
	[ENB_FIXED_TIME] [tinyint] NOT NULL,
 CONSTRAINT [PK_SMT_ALARM_CONNECT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'CTRL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输出端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'OUT_PORT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'触发源（门禁ID）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发胁迫报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FORCE_PWD_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发门长时间未关报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_UNCLOSED_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发强行闯入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FORCE_ACCESS_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发强制锁门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FORCE_CLOSE_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发无效刷卡' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_INVALID_CARD_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发火警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FIRE_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发门继电器动作' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_RELAY_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联动选项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_CONNECT_ITEM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定延时时长(秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FIXED_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警联动输出配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT'
GO
/****** Object:  Table [dbo].[IMS_VEHICLE_RECORD]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMS_VEHICLE_RECORD](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[PlateNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Depart] [varchar](50) NULL,
	[AccessChannel] [varchar](50) NULL,
	[ThroughForward] [tinyint] NULL,
	[ThroughTime] [datetime] NULL,
	[ThroughResult] [tinyint] NULL,
	[CapturePic] [varchar](500) NULL,
 CONSTRAINT [PK_IMS_VEHICLE_RECORD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_VEHICLE_INFO]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMS_VEHICLE_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[PlateNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Depart] [varchar](50) NULL,
	[IsGrant] [tinyint] NULL,
	[GrantAccess] [varchar](100) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_IMS_VEHICLE_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_PEOPLE_RECORD]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMS_PEOPLE_RECORD](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CardType] [tinyint] NULL,
	[CardNo] [varchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Depart] [nvarchar](100) NULL,
	[AccessChannel] [nvarchar](100) NULL,
	[ThroughForward] [tinyint] NULL,
	[ThroughTime] [datetime] NULL,
	[ThroughResult] [tinyint] NULL,
	[CapturePic] [varchar](500) NULL,
	[OriginPic] [varchar](500) NULL,
	[CompareResult] [tinyint] NULL,
	[Similarity] [numeric](18, 0) NULL,
	[FacePosition] [nvarchar](100) NULL,
 CONSTRAINT [PK_IMS_PEOPLE_RECORD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_FACE_CAMERA]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMS_FACE_CAMERA](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CameraName] [varchar](50) NULL,
	[CameraIP] [varchar](50) NULL,
	[CameraPort] [varchar](50) NULL,
	[CameraUser] [varchar](50) NULL,
	[CameraPwd] [varchar](50) NULL,
 CONSTRAINT [PK_IMS_FACE_CAMERA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_FACE_BLACKLIST]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMS_FACE_BLACKLIST](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Sex] [tinyint] NULL,
	[FacePic] [varchar](500) NULL,
	[Description] [varbinary](500) NULL,
 CONSTRAINT [PK_IMS_FACE_BLACKLIST] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_DATA_CONFIG]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMS_DATA_CONFIG](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[DataType] [varchar](50) NULL,
	[DataKey] [varchar](50) NULL,
	[DataValue] [varchar](500) NULL,
	[DataDesc] [varchar](500) NULL,
 CONSTRAINT [PK_IMS_DATA_CONFIG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_SMT_USER_INFO_IS_ENABLE]    Script Date: 01/04/2017 22:32:54 ******/
ALTER TABLE [dbo].[SMT_USER_INFO] ADD  CONSTRAINT [DF_SMT_USER_INFO_IS_ENABLE]  DEFAULT ((1)) FOR [IS_ENABLE]
GO
/****** Object:  Default [DF_SMT_USER_INFO_IS_DELETE]    Script Date: 01/04/2017 22:32:54 ******/
ALTER TABLE [dbo].[SMT_USER_INFO] ADD  CONSTRAINT [DF_SMT_USER_INFO_IS_DELETE]  DEFAULT ((0)) FOR [IS_DELETE]
GO
/****** Object:  Default [DF_SMT_ORG_INFO_PAR_ID]    Script Date: 01/04/2017 22:32:54 ******/
ALTER TABLE [dbo].[SMT_ORG_INFO] ADD  CONSTRAINT [DF_SMT_ORG_INFO_PAR_ID]  DEFAULT ((1)) FOR [PAR_ID]
GO
/****** Object:  Default [DF_SMT_DOOR_INFO_OPEN_STATE]    Script Date: 01/04/2017 22:32:54 ******/
ALTER TABLE [dbo].[SMT_DOOR_INFO] ADD  CONSTRAINT [DF_SMT_DOOR_INFO_OPEN_STATE]  DEFAULT ((0)) FOR [OPEN_STATE]
GO
/****** Object:  Default [DF_SMT_CONTROLLER_ZONE_PAR_ID]    Script Date: 01/04/2017 22:32:54 ******/
ALTER TABLE [dbo].[SMT_CONTROLLER_ZONE] ADD  CONSTRAINT [DF_SMT_CONTROLLER_ZONE_PAR_ID]  DEFAULT ((0)) FOR [PAR_ID]
GO
