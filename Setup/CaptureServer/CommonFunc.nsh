;CommonFunc.nsh
;通用操作
!macro BadPathsCheck
StrCpy $R0 $INSTDIR "" -1
StrCmp $R0 ":" bad
StrCpy $R0 $INSTDIR "" -2
StrCmp $R0 ":\" bad
StrCpy $R0 $INSTDIR "" -14
StrCmp $R0 "\Program Files" bad
StrCpy $R0 $INSTDIR "" -15
StrCmp $R0 "\Program Files\" bad
StrCpy $R0 $INSTDIR "" -20
StrCmp $R0 "\Program Files (x86)" bad
StrCpy $R0 $INSTDIR "" -21
StrCmp $R0 "\Program Files (x86)\" bad
StrCpy $R0 $INSTDIR "" -8
StrCmp $R0 "\Windows" bad
StrCpy $R0 $INSTDIR "" -9
StrCmp $R0 "\Windows\" bad
StrCpy $R0 $INSTDIR "" -6
StrCmp $R0 "\WinNT" bad
StrCpy $R0 $INSTDIR "" -7
StrCmp $R0 "\WinNT\" bad
StrCpy $R0 $INSTDIR "" -9
StrCmp $R0 "\system32" bad
StrCpy $R0 $INSTDIR "" -10
StrCmp $R0 "\system32\" bad
StrCpy $R0 $INSTDIR "" -7
StrCmp $R0 "\system" bad
StrCpy $R0 $INSTDIR "" -8
StrCmp $R0 "\system\" bad
StrCpy $R0 $INSTDIR "" -8
StrCmp $R0 "\Desktop" bad
StrCpy $R0 $INSTDIR "" -9
StrCmp $R0 "\Desktop\" bad
StrCpy $R0 $INSTDIR "" -22
StrCmp $R0 "\Documents and Settings" bad
StrCpy $R0 $INSTDIR "" -23
StrCmp $R0 "\Documents and Settings\" bad

StrCpy $R0 $INSTDIR "" -4
StrCmp $R0 "\123" bad
StrCpy $R0 $INSTDIR "" -5
StrCmp $R0 "\123\" bad

StrCpy $R0 $INSTDIR "" -13
StrCmp $R0 "\My Documents" bad
StrCpy $R0 $INSTDIR "" -14
StrCmp $R0 "\My Documents\" bad done
bad:
Push "1"
Goto BadPathsCheckEnd
done:
Push "0"
BadPathsCheckEnd:
!macroend



!include CheckDotNetFramework.nsh

;判断是否安装Microsoft .NET Framework
;参数1 版本号， 参数2 执行文件位置
Function InstallDotNetFramework
        ;读取参数
        Pop $R1
        Pop $R0
        Var /GLOBAL DotNetFrameworkVersion
        Var /GLOBAL DotNetFrameworkFile
        StrCpy $DotNetFrameworkVersion $R0
        StrCpy $DotNetFrameworkFile $R1

        DetailPrint "检测是否安装Microsoft .NET Framework $DotNetFrameworkVersion"

        !define DOTNETNAME "Microsoft .NET Framework $DotNetFrameworkVersion"
        Push $DotNetFrameworkVersion
        Call CheckDotNetFramework
        Exch $R0
        ${If} $R0 == "1" ; 没有找到
                DetailPrint "开始安装 ${DOTNETNAME}..."
                DetailPrint "安装 Microsoft .NET Framework $DotNetFrameworkVersion 的时间比较长，请耐心等待！"
                ExecWait '"$DotNetFrameworkFile" /q /norestart /ChainingPackage FullX64Bootstrapper'
                DetailPrint "完成安装 $DotNetFrameworkFile ."
        ${ElseIf} $R0 == "0" ; 找到指定版本的DotNetFramework
                DetailPrint "已安装 ${DOTNETNAME}"
                Delete $DotNetFrameworkFile
        ${Endif}
FunctionEnd

;安装FLashPlayer
Function InstallFlashPlayer
         Pop $R0
         DetailPrint "开始安装 $R0..."
         ExecWait '"$R0" /install'
         DetailPrint "完成安装 $R0."
FunctionEnd

Function InstallSoftware
         Pop $R0
         DetailPrint "开始安装 $R0..."
         ExecWait '"$R0" /Q'
         DetailPrint "完成安装 $R0."
FunctionEnd

Var /GLOBAL ProductExeName
;关闭进程
Function CloseProcess
  Pop $R0
  StrCpy $ProductExeName $R0
  CheckProc:
    Push "$ProductExeName"
    ProcessWork::existsprocess
    Pop $R0
    IntCmp $R0 0 Done
    MessageBox MB_OKCANCEL|MB_ICONSTOP "安装程序检测到 $ProductExeName 正在运行。$\r$\n$\r$\n点击 “确定” 强制关闭 $ProductExeName，继续安装。$\r$\n点击 “取消” 退出安装程序。" IDCANCEL Exit
    Push "$ProductExeName"
    Processwork::KillProcess
    Sleep 1000
    Goto CheckProc
    Exit:
    Abort
    Done:
    ;Pop $R0
FunctionEnd
;关闭进程
Function un.CloseProcess
  Pop $R0
  StrCpy $ProductExeName $R0
  CheckProc:
    Push "$ProductExeName"
    ProcessWork::existsprocess
    Pop $R0
    IntCmp $R0 0 Done
    MessageBox MB_OKCANCEL|MB_ICONSTOP "安装程序检测到 $ProductExeName 正在运行。$\r$\n$\r$\n点击 “确定” 强制关闭 $ProductExeName，继续安装。$\r$\n点击 “取消” 退出安装程序。" IDCANCEL Exit
    Push "$ProductExeName"
    Processwork::KillProcess
    Sleep 1000
    Goto CheckProc
    Exit:
    Abort
    Done:
    ;Pop $R0
FunctionEnd