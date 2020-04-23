use SmartAccess;
go
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'smt_custom' AND type = 'R')
exec sp_addrole 'smt_custom';
go
grant select on V_VISITOR_INFO to smt_custom;
grant select on V_VISITOR_DOOR_INFO to smt_custom;
grant select on V_ORG_INFO to smt_custom;
grant select on V_AREA_INFO to smt_custom;
grant select,insert,delete,update on SMT_AUTO_ACCESS to smt_custom;
go
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'smtcustom')
exec sp_addlogin 'smtcustom','smtcustom','SmartAccess';
go
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'smtcustom')
exec sp_adduser 'smtcustom','smtcustom','smt_custom';