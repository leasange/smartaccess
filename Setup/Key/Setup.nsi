; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "SmartKey"  ;应用程序名称
!define PRODUCT_SERIES "SMTK1000"
!define PRODUCT_GUID "{B17E3870-7F90-8F4A-EEEE-028E5FB6A755}" ;应用程序编号
!define COMPANY_NAME "SmartProducts"  ;公司名称
!define PRODUCT_ALIAS_NAME "智能卡授权软件(${PRODUCT_SERIES})" ;//应用系统别名
!define PRODUCT_EXE "SmartKey.exe" ;应用程序exe名称
!define PRODUCT_VERSION "1.1.2.0104"  ;版本号
!define PRODUCT_PUBLISHER "SMT,Inc." ;公司名称
!define PRODUCT_WEB_SITE "http://www.beijinghangyingkeji.com" ;网站地址
!define PRODUCT_WEB_NAME "${PRODUCT_ALIAS_NAME}"  ;web名称
!define PRODUCT_HELP_FILE "help.chm" ;帮助文件目录
!define PRODUCT_SYS_ICONS "Icos\ImageSystem.ico" ;系统安装图标

!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\${PRODUCT_EXE}"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_GUID}"
!define PRODUCT_DIR_REGKEY_ROOT "${PRODUCT_UNINST_KEY}"
!define PRODUCT_DIR_REGKEY_LOCATION "InstallLocation" ;路径位置

!define PRODUCT_UNINST_ROOT_KEY "HKLM"
!define PROJECT_FILES_PATH "ProjectFiles" ;项目文件目录
!define PROJECT_LICENSE_PATH "ProjectLicense" ;授权文件和说明文件目录
!define /date PRODUCT_TIME %Y%m%d%H%M%S ;生成时间
!define BUILD_FILES_PATH "Builds\Setup_${PRODUCT_NAME}_v${PRODUCT_VERSION}.exe" ;编译输出文件
!define LICENSE_FILE "${PROJECT_LICENSE_PATH}\License.rtf" ;授权文件
!define PRODUCT_README_FILE "Readme.txt"  ;说明文件
SetCompressor lzma ;设置压缩格式，防止360检测
; MUI 1.67 compatible ------
!include "MUI2.nsh"
!include "InstallThirdPart.nsh"
; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${PRODUCT_SYS_ICONS}"  ;"${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
!insertmacro MUI_PAGE_LICENSE "${LICENSE_FILE}"
;判断是否安装
!define MUI_PAGE_CUSTOMFUNCTION_show Pageshow
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; 安装完成运行的主程序
!define MUI_FINISHPAGE_RUN "$INSTDIR\${PRODUCT_EXE}"
;安装完成显示Readme.txt
!define MUI_FINISHPAGE_SHOWREADME "$INSTDIR\${PRODUCT_README_FILE}"   ;Readme.txt
;!define MUI_FINISHPAGE_SHOWREADME_NOTCHECKED
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "SimpChinese"

; MUI end ------
; 是否允许安装在根目录下 
AllowRootDirInstall false 

Name "${PRODUCT_ALIAS_NAME} ${PRODUCT_VERSION}"
OutFile "${BUILD_FILES_PATH}"
InstallDir "$PROGRAMFILES\${COMPANY_NAME}\${PRODUCT_NAME}"
;InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY_ROOT}" "${PRODUCT_DIR_REGKEY_LOCATION}"

ShowInstDetails show
ShowUnInstDetails show

;判断是否已经安装过
Function Pageshow
   ReadRegStr $0 HKLM "${PRODUCT_UNINST_KEY}" "UninstallString"
   ${If} $0 == ""
   ${Else}
   ;禁用浏览按钮
   FindWindow $0 "#32770" "" $HWNDPARENT
   GetDlgItem $0 $0 1001
   EnableWindow $0 0
   ;禁用编辑的目录
   FindWindow $0 "#32770" "" $HWNDPARENT
   GetDlgItem $0 $0 1019
   EnableWindow $0 0
   FindWindow $0 "#32770" "" $HWNDPARENT
   GetDlgItem $0 $0 1006
   SendMessage $0 ${WM_SETTEXT} 0 "STR:您已经安装过 ${PRODUCT_NAME} ，现在进行的覆盖安装/更新不能更改安装目录，如果您需要更改安装目录，请先卸载已经安装的版本之后再运行此安装程序！"
   ${EndIf}
FunctionEnd

;关闭正在运行的程序
Function .onInit
  Push "${PRODUCT_EXE}"
  Call CloseProcess
FunctionEnd
;安装程序结束
Function AfterInstall

FunctionEnd

Section "MainSection" SEC01
  !insertmacro BadPathsCheck
  Pop $R0
  ${If} $R0 == "1" ;无效路径
  MessageBox MB_ICONINFORMATION|MB_OK "安装路径无效！"
  ;SendMessage $HWNDPARENT 0x408 -1 0
  ;Goto End
  Abort
  ${EndIf}

;安装第三方组件
  Call InstallThirdPart
;安装应用程序
  SetOutPath "$INSTDIR"
  SetOverwrite on
  File /r "${PROJECT_FILES_PATH}\*"
  File /r "${PROJECT_LICENSE_PATH}\*"
;安装程序结束
  Call AfterInstall
;创建快捷方式
  CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\打开 ${PRODUCT_ALIAS_NAME}.lnk" "$INSTDIR\${PRODUCT_EXE}"
  CreateShortCut "$DESKTOP\${PRODUCT_ALIAS_NAME}.lnk" "$INSTDIR\${PRODUCT_EXE}"
  End:
SectionEnd

Section -AdditionalIcons
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\浏览 ${PRODUCT_ALIAS_NAME} 帮助.lnk" "$INSTDIR\${PRODUCT_HELP_FILE}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\浏览 ${PRODUCT_WEB_NAME} 网站.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\卸载 ${PRODUCT_ALIAS_NAME}.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\${PRODUCT_EXE}"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY_ROOT}" "${PRODUCT_DIR_REGKEY_LOCATION}" "$INSTDIR\${PRODUCT_EXE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\${PRODUCT_EXE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd


Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) 已成功地从你的计算机移除。"
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "你确实要完全移除 $(^Name) ，其及所有的组件？" IDYES +2
  Abort
  Push "${PRODUCT_EXE}"
  Call un.CloseProcess
FunctionEnd

Section Uninstall
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  IfFileExists "$INSTDIR\${PRODUCT_EXE}" 0 +3
  Delete "$INSTDIR\${PRODUCT_EXE}" ;删除应用程序
  Delete "$INSTDIR\uninst.exe"
  !insertmacro BadPathsCheck
  Pop $R0
  ${If} $R0 == "1" ;无效路径
  Goto End
  ${EndIf}
  Delete "$INSTDIR\*" ;删除应用程序
  RMDir /r "$INSTDIR"
  
  End:
  Delete "$SMPROGRAMS\${PRODUCT_NAME}\*"
  Delete "$DESKTOP\${PRODUCT_ALIAS_NAME}.lnk"
  Delete "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_ALIAS_NAME}.lnk"

  RMDir "$SMPROGRAMS\${PRODUCT_NAME}"
  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd