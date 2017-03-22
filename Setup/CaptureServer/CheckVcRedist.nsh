!include "Registry.nsh"
;检测是否安装VC运行时
;vcredist_x86
;2005
;2008
;2010
;2012
;2013
;Use
;Push $VcVersion
;ret 0 Installed, 1 not Installed
Function CheckVcRedist
         Pop $R0
         StrCpy $R1 0
         !define ROOT_KEY "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\"
         ${If} $R0 == "2005"
                ${registry::KeyExists} "${ROOT_KEY}{710f4c1c-cc18-4c49-8cbf-51240c89a1a2}" $R1  ;version 8.0.61001
                StrCmp $R1 0 Exist
                ${registry::KeyExists} "${ROOT_KEY}{A49F249F-0C91-497F-86DF-B2585E8E76B7}" $R1  ;version 8.0.50727.42
                StrCmp $R1 0 Exist
                Goto Fail
         ${ElseIf} $R0 == "2008"
                ${registry::KeyExists} "${ROOT_KEY}{3C3D696B-0DB7-3C6D-A356-3DB8CE541918}" $R1  ;9.0.30729
                StrCmp $R1 0 Exist
                ${registry::KeyExists} "${ROOT_KEY}{86CE1746-9EFF-3C9C-8755-81EA8903AC34}" $R1  ;9.0.30729
                StrCmp $R1 0 Exist
                ${registry::KeyExists} "${ROOT_KEY}{9A25302D-30C0-39D9-BD6F-21E6EC160475}" $R1  ;9.0.30729
                StrCmp $R1 0 Exist
                ${registry::KeyExists} "${ROOT_KEY}{1F1C2DFC-2D24-3E06-BCB8-725134ADF989}" $R1  ;9.0.30729.4148
                StrCmp $R1 0 Exist
                ${registry::KeyExists} "${ROOT_KEY}{9BE518E6-ECC6-35A9-88E4-87755C07200F}" $R1  ;9.0.30729.6161
                StrCmp $R1 0 Exist
                Goto Fail
         ${ElseIf} $R0 == "2010"
                ${registry::KeyExists} "${ROOT_KEY}{F0C3E5D1-1ADE-321E-8167-68EF0DE699A5}" $R1  ;version 10.0.40219
                StrCmp $R1 0 Exist
                Goto Fail
         ${ElseIf} $R0 == "2012"
                ${registry::KeyExists} "${ROOT_KEY}{b64ca997-b626-4abb-a046-5ca2d92ed659}" $R1   ;11.0.60610.1
                StrCmp $R1 0 Exist
                ${registry::KeyExists} "${ROOT_KEY}{2F73A7B2-E50E-39A6-9ABC-EF89E4C62E36}" $R1   ;11.0.50727
                StrCmp $R1 0 Exist
                ${registry::KeyExists} "${ROOT_KEY}{BD95A8CD-1D9F-35AD-981A-3E7925026EBB}" $R1   ;11.0.61030
                StrCmp $R1 0 Exist
                Goto Fail
         ${EndIf}
         Exist:
             Push 0
             Goto End
         Fail:
             Push 1
         End:
FunctionEnd