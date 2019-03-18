USE [SmartAccess]
--/**升级数据库脚本**/
GO
/****** Object:  Table [dbo].[IMS_VEHICLE_RECORD]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_VEHICLE_RECORD]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[IMS_VEHICLE_INFO]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_VEHICLE_INFO]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[IMS_PEOPLE_RECORD]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_PEOPLE_RECORD]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[IMS_FACE_CAMERA]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_FACE_CAMERA]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[IMS_FACE_BLACKLIST]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_FACE_BLACKLIST]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[IMS_DATA_CONFIG]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_DATA_CONFIG]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[IMS_STAFF_FACE]    Script Date: 03/31/2017 20:42:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_STAFF_FACE]') AND type in (N'U'))
CREATE TABLE [dbo].[IMS_STAFF_FACE](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[PeopleType] [tinyint] NULL,
	[PeopleID] [decimal](18, 0) NULL,
	[Feature] [varchar](max) NULL,
 CONSTRAINT [PK_IMS_STAFF_FACE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SMT_DEPT_USER]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_DEPT_USER]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[SMT_SUPER_PWD]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_SUPER_PWD]') AND type in (N'U'))
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

/****** Object:  Table [dbo].[SMT_DATADICTIONARY_INFO]    Script Date: 01/04/2017 22:44:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_DATADICTIONARY_INFO]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[SMT_ALARM_SETTING]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_ALARM_SETTING]') AND type in (N'U'))
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_ALARM_INFO]') AND type in (N'U'))
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_ALARM_CONNECT]') AND type in (N'U'))
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
/****** Object:  Table [dbo].[SMT_ATTEN_SETTING]    Script Date: 02/26/2017 13:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_ATTEN_SETTING]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_ATTEN_SETTING](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[DUTY_TYPE] [tinyint] NOT NULL,
	[DUTY_LATE_MIN] [int] NOT NULL,
	[DUTY_LATE_MAX] [int] NOT NULL,
	[DUTY_LATE_PUNISH] [float] NOT NULL,
	[DUTY_LEAVE_MIN] [int] NOT NULL,
	[DUTY_LEAVE_MAX] [int] NOT NULL,
	[DUTY_LEAVE_PUNISH] [float] NOT NULL,
	[DUTY_EXTRA_MIN] [int] NOT NULL,
	[DUTY_SWING_TIMES] [tinyint] NOT NULL,
	[DUTY_ON_TIME1] [time](7) NOT NULL,
	[DUTY_OFF_TIME1] [time](7) NOT NULL,
	[DUTY_ON_TIME2] [time](7) NOT NULL,
	[DUTY_OFF_TIME2] [time](7) NOT NULL,
	[DUTY_ONLY_ON] [bit] NOT NULL,
	[DUTY_ON_EARLIEST] [time](7) NOT NULL,
	[DUTY_WORK_LENGTH] [float] NOT NULL,
	[DUTY_FULL_TIME] [bit] NOT NULL,
	[DUTY_SAT_TYPE] [tinyint] NOT NULL,
	[DUTY_SUN_TYPE] [tinyint] NOT NULL,
 CONSTRAINT [PK_SMT_ATTEN_SETTING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤班次类型，0,正常班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'迟到最小范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LATE_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'迟到最大范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LATE_MAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'迟到最大处罚天数，天' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LATE_PUNISH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'早退最小范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LEAVE_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'早退最大范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LEAVE_MAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'早退最大处罚天数，天' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LEAVE_PUNISH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加班范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_EXTRA_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每天刷卡次数，次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_SWING_TIMES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班时间1，time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_ON_TIME1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下班时间1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_OFF_TIME1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班时间2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_ON_TIME2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下班时间2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_OFF_TIME2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'只统计上班刷卡，bool' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_ONLY_ON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班最早刷卡时间，time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_ON_EARLIEST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每天工作时间(h)，时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_WORK_LENGTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'满足工作时间不受约束，bool' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_FULL_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'周六上班方式，0，不上班，1全天上班，2上午上班，下午休息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_SAT_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'周日上班方式，0，不上班，1 全天上班，2 上午上班，下午休息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_SUN_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤班次设置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING'
GO
/****** Object:  Table [dbo].[SMT_ATTEN_REPORT]    Script Date: 02/26/2017 13:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_ATTEN_REPORT]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_ATTEN_REPORT](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[STAFF_ID] [decimal](18, 0) NOT NULL,
	[ATTEN_DATE] [date] NOT NULL,
	[ATTEN_ON_TIME] [time](7) NULL,
	[ATTEN_OFF_TIME] [time](7) NULL,
	[ATTEN_ON_STATE] [nvarchar](20) NULL,
	[ATTEN_OFF_STATE] [nvarchar](20) NULL,
	[ATTEN_LATE_MIN] [int] NULL,
	[ATTEN_LEAVE_MIN] [int] NULL,
	[ATTEN_EXTRA_MIN] [int] NULL,
	[ATTEN_AWAY_DAY] [float] NULL,
	[ATTEN_UNSWIPE_TIMES] [int] NULL,
	[ATTEN_SWIPE_TIMES] [int] NULL,
 CONSTRAINT [PK_SMT_ATTEN_REPORT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'STAFF_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_ON_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下班时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_OFF_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_ON_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下班描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_OFF_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'迟到时间，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_LATE_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'早退时间，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_LEAVE_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加班时间，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_EXTRA_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旷工天数，天' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_AWAY_DAY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未刷卡次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_UNSWIPE_TIMES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应刷次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_SWIPE_TIMES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤信息报表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT'
GO
/****** Object:  Table [dbo].[SMT_CAMERA_INFO]    Script Date: 03/19/2017 21:05:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_CAMERA_INFO]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_CAMERA_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CAMERA_NAME] [nvarchar](100) NULL,
	[CAMERA_IP] [varchar](100) NULL,
	[CAMERA_PORT] [int] NULL,
	[CAMERA_CAP_PORT] [int] NULL,
	[CAMERA_USER] [nvarchar](100) NULL,
	[CAMERA_PWD] [nvarchar](100) NULL,
	[CAMERA_MODEL] [nvarchar](100) NULL,
	[CAMERA_CAP_TYPE] [varchar](50) NULL,
 CONSTRAINT [PK_SMT_CAMERA_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CAMERA_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄像头IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CAMERA_INFO', @level2type=N'COLUMN',@level2name=N'CAMERA_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄像头端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CAMERA_INFO', @level2type=N'COLUMN',@level2name=N'CAMERA_PORT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄像头用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CAMERA_INFO', @level2type=N'COLUMN',@level2name=N'CAMERA_USER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄像头密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CAMERA_INFO', @level2type=N'COLUMN',@level2name=N'CAMERA_PWD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄像头型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CAMERA_INFO', @level2type=N'COLUMN',@level2name=N'CAMERA_MODEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄像头抓拍方式,默认：ONVIF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CAMERA_INFO', @level2type=N'COLUMN',@level2name=N'CAMERA_CAP_TYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄像头表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CAMERA_INFO'
GO

/****** Object:  Table [dbo].[SMT_DOOR_CAMERA]    Script Date: 03/19/2017 21:06:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_DOOR_CAMERA]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_DOOR_CAMERA](
	[DOOR_ID] [decimal](18, 0) NOT NULL,
	[CAMERA_ID] [decimal](18, 0) NOT NULL,
	[ENABLE_CAP] [bit] NOT NULL,
 CONSTRAINT [PK_SMT_DOOR_CAMERA] PRIMARY KEY CLUSTERED 
(
	[DOOR_ID] ASC,
	[CAMERA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门禁ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_CAMERA', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄像头ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_CAMERA', @level2type=N'COLUMN',@level2name=N'CAMERA_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启动抓拍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_CAMERA', @level2type=N'COLUMN',@level2name=N'ENABLE_CAP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门禁摄像头表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DOOR_CAMERA'
GO

/****** Object:  Table [dbo].[SMT_RECORDCAP_IMAGE]    Script Date: 03/19/2017 21:07:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_RECORDCAP_IMAGE]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_RECORDCAP_IMAGE](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CTRL_SN] [varchar](100) NOT NULL,
	[RECORD_INDEX] [decimal](18, 0) NOT NULL,
	[RECORD_TIME] [datetime] NOT NULL,
	[CAP_TIME] [datetime] NOT NULL,
	[CAP_RELATIVE_URL] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_SMT_RECORDCAP_IMAGE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_RECORDCAP_IMAGE', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_RECORDCAP_IMAGE', @level2type=N'COLUMN',@level2name=N'CTRL_SN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录索引号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_RECORDCAP_IMAGE', @level2type=N'COLUMN',@level2name=N'RECORD_INDEX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_RECORDCAP_IMAGE', @level2type=N'COLUMN',@level2name=N'RECORD_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抓拍时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_RECORDCAP_IMAGE', @level2type=N'COLUMN',@level2name=N'CAP_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抓拍相对图片路径（名称）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_RECORDCAP_IMAGE', @level2type=N'COLUMN',@level2name=N'CAP_RELATIVE_URL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'刷卡抓拍记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_RECORDCAP_IMAGE'
GO

IF not exists(select 1 from SYSCOLUMNS where id = object_id('SMT_CONTROLLER_INFO') and name = 'ENABLE_BUTTON_RECORD')
ALTER TABLE SMT_CONTROLLER_INFO ADD ENABLE_BUTTON_RECORD bit
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否打开按钮记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_CONTROLLER_INFO', @level2type=N'COLUMN',@level2name=N'ENABLE_BUTTON_RECORD'
GO

/***更新数据库20170627****/
IF NOT EXISTS (SELECT a.name FROM syscolumns a,sysobjects b
WHERE a.id=b.id
AND LTRIM(a.name)='IS_ALLOW_VISITOR' AND LTRIM(b.name)='SMT_DOOR_INFO')
ALTER TABLE SMT_DOOR_INFO ADD IS_ALLOW_VISITOR bit default 1 NOT NULL
EXECUTE sp_addextendedproperty N'MS_Description', '是否允许访客接入,默认 true', N'user', N'dbo', N'table', N'SMT_DOOR_INFO', N'column', N'IS_ALLOW_VISITOR'
GO

IF NOT EXISTS (SELECT a.name FROM syscolumns a,sysobjects b
WHERE a.id=b.id
AND LTRIM(a.name)='STAFF_TYPE' AND LTRIM(b.name)='SMT_STAFF_INFO')
ALTER TABLE SMT_STAFF_INFO ADD STAFF_TYPE varchar(20) NULL
EXECUTE sp_addextendedproperty N'MS_Description', '职员类别，类别可查看数据字典表类型为：DATA_TYPE=“STAFF_TYPE” 的 DATA_KEY，显示名称为：DATA_NAME', N'user', N'dbo', N'table', N'SMT_STAFF_INFO', N'column', N'STAFF_TYPE'
GO

IF NOT EXISTS (SELECT a.name FROM syscolumns a,sysobjects b
WHERE a.id=b.id
AND LTRIM(a.name)='ROLE_TYPE' AND LTRIM(b.name)='SMT_ROLE_FUN')
ALTER TABLE SMT_ROLE_FUN ADD ROLE_TYPE tinyint default 1 not NULL
EXECUTE sp_addextendedproperty N'MS_Description', '权限类型,1 菜单功能，2 部门，3 门', N'user', N'dbo', N'table', N'SMT_ROLE_FUN', N'column', N'ROLE_TYPE'
alter table SMT_ROLE_FUN drop PK_SMT_ROLE_FUN
alter table SMT_ROLE_FUN add constraint PK_SMT_ROLE_FUN primary key (ROLE_ID, FUN_ID, ROLE_TYPE)

GO
IF NOT EXISTS(select * from sys.indexes where name='SMT_DOOR_INFO_CTRL_INDEX') create index SMT_DOOR_INFO_CTRL_INDEX on SMT_DOOR_INFO(CTRL_ID)
GO
IF NOT EXISTS(select * from sys.indexes where name='SMT_STAFF_DOOR_DOOR_ID') create index  SMT_STAFF_DOOR_DOOR_ID on SMT_STAFF_DOOR(DOOR_ID)
GO
IF NOT EXISTS(select * from sys.indexes where name='SMT_STAFF_CARD_CARD_ID') create index SMT_STAFF_CARD_CARD_ID on SMT_STAFF_CARD(CARD_ID)
GO
IF NOT EXISTS(select * from sys.indexes where name='SMT_STAFF_CARD_STAFF_ID') create index SMT_STAFF_CARD_STAFF_ID on SMT_STAFF_CARD(STAFF_ID)
GO
IF NOT EXISTS(select * from sys.indexes where name='SMT_CONTROLLER_INFO_IS_ENABLE') create index SMT_CONTROLLER_INFO_IS_ENABLE on SMT_CONTROLLER_INFO(IS_ENABLE)


GO

/****** Object:  Table [dbo].[SMT_FACE_RECORD]    Script Date: 08/30/2018 23:33:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_FACE_RECORD]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_FACE_RECORD](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[FACEDEV_ID] [decimal](18, 0) NOT NULL,
	[FREC_SRC_ID] [nvarchar](300) NULL,
	[FREC_TIME] [datetime] NOT NULL,
	[FREC_STAFF_NAME] [nvarchar](100) NOT NULL,
	[FREC_VIDEO_IMAGE] [image] NULL,
	[FREC_FACE_IMAGE] [image] NULL,
	[FREC_FACE_LEVEL] [decimal](5, 2) NOT NULL,
	[FREC_AUTHORITY] [nvarchar](8) NULL,
	[FREC_STAFF_NO] [nvarchar](80) NULL,
	[FREC_STAFF_TYPE] [nvarchar](80) NULL,
	[FREC_PARAM3] [nvarchar](80) NULL,
	[FREC_PARAM4] [nvarchar](80) NULL,
	[FREC_STAFF_ID] [decimal](18, 0) NULL,
 CONSTRAINT [PK_SMT_FACE_RECORD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人脸设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FACEDEV_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原始记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_SRC_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_STAFF_NAME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频图像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_VIDEO_IMAGE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人脸图像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_FACE_IMAGE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相似度(0-1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_FACE_LEVEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_AUTHORITY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_STAFF_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员ID（系统使用，参数3）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD', @level2type=N'COLUMN',@level2name=N'FREC_PARAM3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人脸识别记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACE_RECORD'
GO
/****** Object:  Table [dbo].[SMT_FACERECG_DEVICE]    Script Date: 08/30/2018 23:34:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_FACERECG_DEVICE]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_FACERECG_DEVICE](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[FACEDEV_SN] [nvarchar](20) NULL,
	[FACEDEV_NAME] [nvarchar](20) NOT NULL,
	[FACEDEV_IP] [nvarchar](20) NOT NULL,
	[FACEDEV_CTRL_PORT] [int] NOT NULL,
	[FACEDEV_USER] [nvarchar](20) NULL,
	[FACEDEV_PWD] [nvarchar](128) NULL,
	[FACEDEV_DB_NAME] [varchar](50) NOT NULL,
	[FACEDEV_DB_PORT] [int] NOT NULL,
	[FACEDEV_DB_USER] [nvarchar](20) NOT NULL,
	[FACEDEV_DB_PWD] [nvarchar](128) NOT NULL,
	[AREA_ID] [decimal](18, 0) NOT NULL,
	[FACEDEV_IS_ENABLE] [bit] NOT NULL,
	[FACEDEV_HEART_PORT] [int] NOT NULL,
	[FACEDEV_MODE] [nvarchar](20) NULL,
	[FVIDEO_RTSP] [nvarchar](300) NULL,
	[FVIDEO_RTSP2] [nvarchar](300) NULL,
	[FVIDEO_RTSP3] [nvarchar](300) NULL,
	[FVIDEO_RTSP_COUNT] [int] NULL,
	[FVIDEO_FACE_LEVEL] [decimal](5, 2) NULL,
	[FVIDEO_RIO_X] [decimal](5, 2) NULL,
	[FVIDEO_RIO_Y] [decimal](5, 2) NULL,
	[FVIDEO_RIO_H] [decimal](5, 2) NULL,
	[FVIDEO_RIO_W] [decimal](5, 2) NULL,
	[FVIDEO_SINGLE] [varchar](2) NULL,
	[FVIDEO_TITLE1] [nvarchar](50) NULL,
	[FVIDEO_TITLE2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SMT_FACERECG_DEVICE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_SN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_NAME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备控制端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_CTRL_PORT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_USER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_PWD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_DB_NAME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_DB_PORT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_DB_USER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_DB_PWD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属区域ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'AREA_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_IS_ENABLE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'心跳端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_HEART_PORT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FACEDEV_MODE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已上传' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_RTSP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上传时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_RTSP2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_RTSP3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频路数1或3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_RTSP_COUNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分数阈值（0~1）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_FACE_LEVEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检测区域左上角横坐标（0~1）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_RIO_X'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检测区域左上角纵坐标（0~1）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_RIO_Y'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检测区域高度（0~1）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_RIO_H'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'检测区域宽度（0~1）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_RIO_W'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模式选择（Y为单人，N为多人）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_SINGLE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_TITLE1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE', @level2type=N'COLUMN',@level2name=N'FVIDEO_TITLE2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人脸识别设备' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FACERECG_DEVICE'
GO
/****** Object:  Table [dbo].[SMT_STAFF_FACEDEV]    Script Date: 08/30/2018 23:35:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_STAFF_FACEDEV]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_STAFF_FACEDEV](
	[STAFF_ID] [decimal](18, 0) NOT NULL,
	[FACEDEV_ID] [decimal](18, 0) NOT NULL,
	[IS_UPLOAD] [bit] NOT NULL,
	[UPLOAD_TIME] [datetime] NOT NULL,
	[ADD_TIME] [datetime] NOT NULL,
	[START_VALID_TIME] [datetime] NOT NULL,
	[END_VALID_TIME] [datetime] NOT NULL,
	[STAFF_DEV_ID] [varchar](50) NULL,
 CONSTRAINT [PK_SMT_STAFF_FACEDEV] PRIMARY KEY CLUSTERED 
(
	[STAFF_ID] ASC,
	[FACEDEV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV', @level2type=N'COLUMN',@level2name=N'STAFF_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人脸识别设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV', @level2type=N'COLUMN',@level2name=N'FACEDEV_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已上传' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV', @level2type=N'COLUMN',@level2name=N'IS_UPLOAD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上传时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV', @level2type=N'COLUMN',@level2name=N'UPLOAD_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV', @level2type=N'COLUMN',@level2name=N'ADD_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效开始时间，该时间在员工有效期范围内' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV', @level2type=N'COLUMN',@level2name=N'START_VALID_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效结束时间，该时间在员工有效期范围内' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV', @level2type=N'COLUMN',@level2name=N'END_VALID_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上传设备中编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV', @level2type=N'COLUMN',@level2name=N'STAFF_DEV_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工人脸识别设备权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_STAFF_FACEDEV'
GO
/****插入权限数据*****/
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 503 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(503 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), N'FACERECG_DEV_INFO', N'人脸识别设备', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 105 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(105 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'FACERECG_DEV_PRIVATE', N'人脸识别授权', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 308 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(308 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'FACERECG_RECORD', N'人脸识别查询', 1)

GO
IF COL_LENGTH('SMT_MAP_DOOR', 'DOOR_TYPE') IS  NULL    
ALTER TABLE SMT_MAP_DOOR ADD DOOR_TYPE tinyint not NULL default 1
go
--如果已存在主键，则先删除再添加，如果不存在在则不删除
if exists(select * from sysobjects where name='PK_SMT_MAP_DOOR')
alter table SMT_MAP_DOOR drop constraint PK_SMT_MAP_DOOR;
go
alter table SMT_MAP_DOOR add constraint PK_SMT_MAP_DOOR primary key (MAP_ID,DOOR_ID,DOOR_TYPE)

