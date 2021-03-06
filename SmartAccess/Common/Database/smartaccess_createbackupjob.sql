USE [msdb]
GO

/****** Object:  Job [backup_smart_access]    Script Date: 01/03/2017 23:35:30 ******/
IF  EXISTS (SELECT job_id FROM msdb.dbo.sysjobs_view WHERE name = N'backup_smart_access')
EXEC msdb.dbo.sp_delete_job @job_name = N'backup_smart_access', @delete_unused_schedule=1
GO

USE [msdb]
GO

/****** Object:  Job [backup_smart_access]    Script Date: 01/03/2017 23:35:30 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [Database Maintenance]    Script Date: 01/03/2017 23:35:30 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'Database Maintenance' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Database Maintenance'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'backup_smart_access', 
		@enabled=${ENABLE}, 
		@notify_level_eventlog=2, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@category_name=N'Database Maintenance', 
		@owner_login_name=N'sa', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [备份脚本执行]    Script Date: 01/03/2017 23:35:30 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'备份脚本执行', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'DECLARE @filename VARCHAR(500)
DECLARE @date DATETIME
DECLARE @OLD_DATE DATETIME
SET @date=GETDATE()
SET @OLD_DATE=GETDATE()-${DAYS} --超过${DAYS}天的备份即将被删除
SET @FILENAME = ''${PATH}\smartaccess-''+CAST(DATEPART(YYYY,@DATE) AS VARCHAR(10))+''-''+CAST(DATEPART(MM,@DATE) AS VARCHAR(10))+''-''+CAST(DATEPART(DD,@DATE) AS VARCHAR(10))+''.bak''
BACKUP DATABASE [SmartAccess] TO DISK = @filename WITH NOFORMAT, NOINIT,  NAME = ''SmartAccess-完整 数据库 备份'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
EXECUTE master.dbo.xp_delete_file 0,N''${PATH}'',N''bak'',@OLD_DATE,1
GO', 
		@database_name=N'SmartAccess', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'执行周期', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20170103, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, 
		@schedule_uid=N'd523ffea-3b57-48e2-9f68-ac2d333e7030'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO

