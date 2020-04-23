USE [SmartAccess]
GO

/****** Object:  View [dbo].[V_VISITOR_INFO]    Script Date: 12/26/2019 11:02:08 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_VISITOR_INFO]'))
DROP VIEW [dbo].[V_VISITOR_INFO]
GO

USE [SmartAccess]
GO

/****** Object:  View [dbo].[V_VISITOR_INFO]    Script Date: 12/26/2019 11:02:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_VISITOR_INFO]
AS
SELECT     dbo.SMT_STAFF_INFO.ID, dbo.SMT_STAFF_INFO.ORG_ID, dbo.SMT_STAFF_INFO.STAFF_NO_TEMPLET, dbo.SMT_STAFF_INFO.STAFF_NO, dbo.SMT_STAFF_INFO.REAL_NAME, 
                      dbo.SMT_STAFF_INFO.SEX, dbo.SMT_STAFF_INFO.JOB, dbo.SMT_STAFF_INFO.BIRTHDAY, dbo.SMT_STAFF_INFO.POLITICS, dbo.SMT_STAFF_INFO.MARRIED, dbo.SMT_STAFF_INFO.SKIIL_LEVEL, 
                      dbo.SMT_STAFF_INFO.CER_NAME, dbo.SMT_STAFF_INFO.CER_NO, dbo.SMT_STAFF_INFO.TELE_PHONE, dbo.SMT_STAFF_INFO.CELL_PHONE, dbo.SMT_STAFF_INFO.NATIVE, 
                      dbo.SMT_STAFF_INFO.NATION, dbo.SMT_STAFF_INFO.RELIGION, dbo.SMT_STAFF_INFO.EDUCATIONAL, dbo.SMT_STAFF_INFO.EMAIL, dbo.SMT_STAFF_INFO.VALID_STARTTIME, 
                      dbo.SMT_STAFF_INFO.VALID_ENDTIME, dbo.SMT_STAFF_INFO.ENTRY_TIME, dbo.SMT_STAFF_INFO.ABORT_TIME, dbo.SMT_STAFF_INFO.ADDRESS, dbo.SMT_STAFF_INFO.PHOTO, 
                      dbo.SMT_STAFF_INFO.CER_PHOTO_FRONT, dbo.SMT_STAFF_INFO.CER_PHOTO_BACK, dbo.SMT_STAFF_INFO.PRINT_TEMPLET_ID, dbo.SMT_STAFF_INFO.IS_FORBIDDEN, 
                      dbo.SMT_STAFF_INFO.IS_DELETE, dbo.SMT_STAFF_INFO.REG_TIME, dbo.SMT_STAFF_INFO.DEL_TIME, dbo.SMT_STAFF_INFO.FORBIDDEN_TIME, dbo.SMT_STAFF_INFO.ENABLE_TIME, 
                      dbo.SMT_STAFF_INFO.MODIFY_TIME, dbo.SMT_STAFF_INFO.STAFF_TYPE, dbo.SMT_ORG_INFO.ORG_NAME, dbo.SMT_ORG_INFO.ORG_CODE
FROM         dbo.SMT_ORG_INFO RIGHT OUTER JOIN
                      dbo.SMT_STAFF_INFO ON dbo.SMT_ORG_INFO.ID = dbo.SMT_STAFF_INFO.ORG_ID
WHERE     (dbo.SMT_STAFF_INFO.IS_DELETE = 0) AND (dbo.SMT_STAFF_INFO.STAFF_TYPE IS NOT NULL) AND (dbo.SMT_STAFF_INFO.STAFF_TYPE <> 'STAFF') AND 
                      (LEN(dbo.SMT_STAFF_INFO.STAFF_TYPE) > 0)

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[5] 2[35] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -525
      End
      Begin Tables = 
         Begin Table = "SMT_ORG_INFO"
            Begin Extent = 
               Top = 6
               Left = 693
               Bottom = 197
               Right = 854
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SMT_STAFF_INFO"
            Begin Extent = 
               Top = 6
               Left = 465
               Bottom = 209
               Right = 655
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 40
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2190
         Alias = 900
         Table = 2400
         Output = 720
         Append = 140' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VISITOR_INFO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'0
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 2475
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VISITOR_INFO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VISITOR_INFO'

GO
/****** Object:  View [dbo].[V_VISITOR_DOOR_INFO]    Script Date: 12/26/2019 09:10:41 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_VISITOR_DOOR_INFO]'))
DROP VIEW [dbo].[V_VISITOR_DOOR_INFO]
GO

USE [SmartAccess]
GO

/****** Object:  View [dbo].[V_VISITOR_DOOR_INFO]    Script Date: 12/26/2019 09:10:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_VISITOR_DOOR_INFO]
AS
SELECT     SDI.ID AS DOOR_ID, SDI.DOOR_NAME, SCI.AREA_ID
FROM         dbo.SMT_DOOR_INFO AS SDI INNER JOIN
                      dbo.SMT_CONTROLLER_INFO AS SCI ON SDI.CTRL_ID = SCI.ID
WHERE     (SDI.IS_ALLOW_VISITOR = 1) AND (SDI.IS_ENABLE = 1) AND (SCI.IS_ENABLE = 1)

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -166
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SDI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "SCI"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 246
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 14
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VISITOR_DOOR_INFO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VISITOR_DOOR_INFO'
GO
/****** Object:  View [dbo].[V_ORG_INFO]    Script Date: 12/26/2019 09:11:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_ORG_INFO]'))
DROP VIEW [dbo].[V_ORG_INFO]
GO

USE [SmartAccess]
GO

/****** Object:  View [dbo].[V_ORG_INFO]    Script Date: 12/26/2019 09:11:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_ORG_INFO]
AS
SELECT     ID, PAR_ID, ORG_CODE, ORG_NAME, ORDER_VALUE
FROM         dbo.SMT_ORG_INFO

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SMT_ORG_INFO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_ORG_INFO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_ORG_INFO'
GO


/****** Object:  View [dbo].[V_AREA_INFO]    Script Date: 12/26/2019 09:11:12 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_AREA_INFO]'))
DROP VIEW [dbo].[V_AREA_INFO]
GO

USE [SmartAccess]
GO

/****** Object:  View [dbo].[V_AREA_INFO]    Script Date: 12/26/2019 09:11:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_AREA_INFO]
AS
SELECT     ID, PAR_ID, ZONE_NAME AS AREA_NAME, ZONE_DESC AS AREA_DESC, ORDER_VALUE
FROM         dbo.SMT_CONTROLLER_ZONE

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SMT_CONTROLLER_ZONE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_AREA_INFO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_AREA_INFO'
GO




