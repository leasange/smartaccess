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
SET IDENTITY_INSERT [dbo].[IMS_PEOPLE_RECORD] ON
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(999 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA009FB7E4 AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1000 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A1025C AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1001 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A12C8C AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1002 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A1BB84 AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1003 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A3686C AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1004 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A36E48 AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1005 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A39170 AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
SET IDENTITY_INSERT [dbo].[IMS_PEOPLE_RECORD] OFF
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
SET IDENTITY_INSERT [dbo].[IMS_FACE_CAMERA] ON
INSERT [dbo].[IMS_FACE_CAMERA] ([ID], [CameraName], [CameraIP], [CameraPort], [CameraUser], [CameraPwd]) VALUES (CAST(1 AS Decimal(18, 0)), N'测试相机', N'192.168.0.64', N'8000', N'admin', N'admin123')
SET IDENTITY_INSERT [dbo].[IMS_FACE_CAMERA] OFF
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
SET IDENTITY_INSERT [dbo].[IMS_DATA_CONFIG] ON
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(1 AS Decimal(18, 0)), N'IMS_CONFIG', N'FaceMode', N'0', N'人脸模式')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(2 AS Decimal(18, 0)), N'IMS_CONFIG', N'IsBlackMode', N'1', N'黑名单模式')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(3 AS Decimal(18, 0)), N'IMS_CONFIG', N'SwipeMode', N'0', N'刷卡模式')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(4 AS Decimal(18, 0)), N'FACE_1_N', N'Threshold', N'50', N'人脸1：N阈值')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(5 AS Decimal(18, 0)), N'FACE_1_1', N'Threshold', N'50', N'人脸1：1阈值')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(6 AS Decimal(18, 0)), N'FACE_1_LN', N'Threshold', N'50', N'人脸1：n阈值')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(7 AS Decimal(18, 0)), N'STAFF_FACE', N'FilePath', N'c:\LocalFace\StaffFace\', N'员工人脸本地库路径')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(8 AS Decimal(18, 0)), N'BLACK_FACE', N'FilePath', N'c:\LocalFace\BlackFace\', N'黑名单人脸本地库路径')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(9 AS Decimal(18, 0)), N'TEMP_FACE', N'FilePath', N'c:\LocalFace\TempFace\', N'1：n临时人脸本地库')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(10 AS Decimal(18, 0)), N'IMS_CONFIG', N'FaceCamera', N'1', N'人脸相机编号')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(11 AS Decimal(18, 0)), N'IMS_CONFIG', N'Controller', N'1', N'人脸联动控制器编号')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(12 AS Decimal(18, 0)), N'IMS_CONFIG', N'Door', N'1', N'人脸联动门编号')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(13 AS Decimal(18, 0)), N'FACE_BLACK', N'Threshold', N'60', N'黑名单阈值')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(14 AS Decimal(18, 0)), N'FACE_1_LN', N'STORELENGTH', N'15', N'特征库大小')
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(15 AS Decimal(18, 0)), N'FACE_1_LN', N'DELETETICK', N'20', N'删除特征间隔')
SET IDENTITY_INSERT [dbo].[IMS_DATA_CONFIG] OFF


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
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_SUPER_PWD]') AND type in (N'U'))
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