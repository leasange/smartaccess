
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Li.Access.Core.FaceDevice.FY
{
    public static class FACE_SDK
    {
		public const string DLL_PATH = "FYFACE_SDK\\FACE_SDK.dll";

		/**
		 * @brief  设备搜索结果回调
		 *
		 * @param strDeviceIp               搜索结果，JSON格式，具体见协议文档
		 * @param pUser                        用户数据
		 */
		public delegate void DeviceSearchEventHandler(IntPtr pSearchRespDataBuffer, IntPtr pUser);

		/**
		 * @brief  设备在线状态回调
		 *
		 * @param strDeviceIp               设备IP地址
		 * @param deviceStatus              设备在线状态，1:在线；2:离线；3:未知
		 * @param pUser                        用户数据
		 */
		public delegate void DeviceStatusEventHandler(IntPtr strDeviceIp, int deviceStatus, IntPtr pUser);

		/**
		 * @brief  人脸识别结果回调
		 *
		 * @param pDeviceDataBuffer   人脸识别结果数据，JSON格式，具体见协议文档
		 * @param dataLen                     数据大小
		 * @param pUser                        用户数据
		 */
		public delegate void FaceRecognitionResultEventHandle(IntPtr pDeviceDataBuffer, int dataLen, IntPtr pUser);

		/**
		 * @brief  拍照回调
		 *
		 * @param pDeviceDataBuffer   图片数据，BASE64编码，JPG格式
		 * @param dataLen                     图片大小
		 * @param pUser                        用户数据
		 */
		public delegate void SnapPhotoEventHandle(IntPtr pDeviceDataBuffer, int dataLen, IntPtr pUser);

		/**
		 * @brief  升级进度回调
		 *
		 * @param updateProgress   升级进度，范围 0-100
		 * @param updateResult       升级状态，0:正常；其他:异常
		 * @param pUser                  用户数据
		 */
		public delegate void DeviceUpdateEventHandle(int updateProgress, int updateResult, IntPtr pUser);

		/**
		 * @brief  心跳回调
		 *
		 * @param pHeatbeatBuffer   心跳
		 * @param dataLen               
		 * @param pUser                  用户数据
		 */
		public delegate void HeatBeatEventHandle(IntPtr pHeatbeatBuffer, IntPtr sn, IntPtr pUser);
		/**
		 * @brief SDK资源初始化
		 *
		 * @return true on success
		 *               false on fail
		 */

		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_Initialize();

		/**
		 * @brief SDK资源销毁
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_UnInitialize();

		/**
		 * @brief 使能SDK调试日志
		 *
		 * @param enable   使能标记，0：关闭，1：使能
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SaveSdkLog(int enable);

		/**
		 * @brief  设置设备在线状态回调
		 *
		 * @param pDeviceStatusCallBack   状态回调函数
		 * @param pUser                               用户数据
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetDeviceStatusCallBack(
															DeviceStatusEventHandler pDeviceStatusCallBack, IntPtr pUser);

		/**
		 * @brief  设置设备搜索结果回调
		 *
		 * @param pSearchDataCallBack     搜索回调函数
		 * @param pUser                               用户数据
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetDeviceSearchCallback(
															 DeviceSearchEventHandler pSearchDataCallBack, IntPtr pUser);

		/**
		 * @brief  设置人脸识别结果回调
		 *
		 * @param pFaceRecognitionResultCallBack     人脸识别结果回调函数
		 * @param pUser                                                 用户数据
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetFaceRecognitionResultCallBack(
															 FaceRecognitionResultEventHandle pFaceRecognitionResultCallBack, IntPtr pUser);

		/**
		 * @brief  设置照片抓拍回调
		 *
		 * @param pSnapPhotoEventHandle      抓拍回调函数
		 * @param pUser                                    用户数据
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetSnapPhotoCallBack(
															SnapPhotoEventHandle pSnapPhotoEventHandle, IntPtr pUser);

		/**
		 * @brief  设置设备升级进度回调
		 *
		 * @param pDeviceUpdateEventHandle     升级进度回调函数
		 * @param pUser                                        用户数据
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetDeviceUpdateCallBack(
															 DeviceUpdateEventHandle pDeviceUpdateEventHandle, IntPtr pUser);

		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetHeatBeatCallBack(
															 HeatBeatEventHandle pHeatBeatEventHandle, IntPtr pUser);

		/**
		 * @brief  搜索设备
		 *
		 * @param timeoutms      调用超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_DeviceSearch(int timeoutms);

		/**
		 * @brief 连接指定设备
		 *
		 * @param strDeviceIp     设备IP地址
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_Connect(string strDeviceIp);

		/**
		 * @brief 断开指定设备
		 *
		 * @param strDeviceIp     设备IP地址
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_Disconnect(string strDeviceIp);

		/**
		 * @brief    断开所有设备
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_DisconnectAll();

		/**
		 * @brief    播放视频
		 *
		 * @param strDeviceIp     设备IP地址
		 * @param hParentWnd      句柄,画面比例：3:4(宽：长)
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_StartPlay(string strDeviceIp, IntPtr hParentWnd);

		/**
		 * @brief    停止播放视频
		 *
		 * @param strDeviceIp     设备IP地址
		 * @param hParentWnd      句柄
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_StopPlay(string strDeviceIp, IntPtr hParentWnd);

		/**
		 * @brief    设备升级
		 *
		 * @param strDeviceIp          设备IP地址
		 * @param strUpgradeFile       升级文件路径名
		 * @param updateType           升级类型，0：文件系统；1：应用程序；3：内核系统
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_StartDeviceUpdate(IntPtr strDeviceIp, IntPtr strUpgradeFile, int updateType);

		/**
		 * @brief    停止升级
		 *
		 * @param strDeviceIp          设备IP地址
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetStopUpdate(IntPtr strDeviceIp);

		/**
		 * @brief    注册人员信息及照片
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param pRegisterPersonInfo               人员注册信息，JSON格式，具体参照协议文档
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_RegisterPersonInfoAndPhoto(
															 IntPtr strDeviceIp, IntPtr pRegisterPersonInfo, int timeoutms);

		/**
		 * @brief    删除注册人员信息及照片
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param idNumber                          人员idNumber
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_DeletePersonInfoAndPhoto(IntPtr strDeviceIp, IntPtr idNumber, int timeoutms);

		/**
		 * @brief    删除所有注册人员
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_DeleteAllPersonInfoAndPhoto(IntPtr strDeviceIp, int timeoutms);

		/**
		 * @brief   按排序获取注册人员信息
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param index                             序号，从0到总数-1
		 * @param strRegisterInfo                   返回的人员信息，JSON格式，具体消息见协议文档
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_GetPersonInfoAndPhotoByIndex(
															 IntPtr strDeviceIp, int index, IntPtr strRegisterInfo, int timeoutms);

		/**
		 * @brief   按idNumber获取注册人员信息
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param idNumber                          人员ID
		 * @param strRegisterInfo                   返回的人员信息，JSON格式，具体消息见协议文档
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_GetPersonInfoAndPhotoByIdNumber(
															IntPtr strDeviceIp, IntPtr idNumber, IntPtr strRegisterInfo, int timeoutms);

		/**
		 * @brief   获取注册人员总数
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return 注册人员总数
		 */
		[DllImport(DLL_PATH)]
		public static extern int FACE_DEVICE_NET_API_GetPersonTotalNumber(IntPtr strDeviceIp, int timeoutms);

		/**
		 * @brief   获取设备抓拍图片
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param snapType                          抓拍类型，0: 带人脸图片;1：随机抓拍图片
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_GetSnapPicture(
															 IntPtr strDeviceIp, int snapType, int timeoutms);

		/**
		 * @brief   按时间段删除通行记录
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param snapTimeStart                     开始时间，17位，格式为：年月日时分秒毫秒（%04d%02d%02d%02d%02d%02d%03d）
													如"20191108130551021"
		 * @param snapTimeEnd                       结束时间，17位，格式为：年月日时分秒毫秒（%04d%02d%02d%02d%02d%02d%03d）
													如"20201108130551021"
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_DeleteRecordByTime(
															IntPtr strDeviceIp, IntPtr snapTimeStart, IntPtr snapTimeEnd, int timeoutms);

		/**
		 * @brief   删除所有通行记录
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_DeleteAllRecord(IntPtr strDeviceIp, int timeoutms);

		/**
		 * @brief   按时间段获取通行记录信息
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param snapTimeStart                     开始时间，17位，格式为：年月日时分秒毫秒（%04d%02d%02d%02d%02d%02d%03d）
												    如"20191108130551021"
		 * @param snapTimeEnd                       结束时间，17位，格式为：年月日时分秒毫秒（%04d%02d%02d%02d%02d%02d%03d）
													如"20201108130551021"
		 * @param index                             该时间段内序号
		 * @param strRecord                         返回的通行记录具体信息，JSON格式，具体见协议文档
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_GetRecordByTime(
															IntPtr strDeviceIp, IntPtr snapTimeStart, IntPtr snapTimeEnd, int index, IntPtr strRecord, int timeoutms);

		/**
		 * @brief   按时间段获取通行记录总数
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param snapTimeStart                     开始时间，17位，格式为：年月日时分秒毫秒（%04d%02d%02d%02d%02d%02d%03d）
													如"20191108130551021"
		 * @param snapTimeEnd                       结束时间，17位，格式为：年月日时分秒毫秒（%04d%02d%02d%02d%02d%02d%03d）
													如"20201108130551021"
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return 总数
		 */
		[DllImport(DLL_PATH)]
		public static extern int FACE_DEVICE_NET_API_GetRecordCountByTime(
														  IntPtr strDeviceIp, IntPtr snapTimeStart, IntPtr snapTimeEnd, int timeoutms);
		/**
		 * @brief   按序号获取通行记录信息
		 *
		 * @param strDeviceIp                      设备IP地址
		 * @param index                                序号(0-总数-1)
		 * @param strRecord                         返回的通行记录具体信息，JSON格式，具体见协议文档
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern int FACE_DEVICE_NET_API_GetRecord(
															IntPtr strDeviceIp, int index, IntPtr strRecord, int timeoutms);

		/**
		 * @brief   获取所有通行记录总数
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return 总数
		 */
		[DllImport(DLL_PATH)]
		public static extern int FACE_DEVICE_NET_API_GetRecordAllCount(IntPtr strDeviceIp, int timeoutms);

		/**
		 * @brief   获取设备时间
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param strDeviceTime                     设备返回时间，格式为 年-月-日 时:分:秒，如：2020-04-09 12:01:20
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_GetDeviceTime(IntPtr strDeviceIp, IntPtr strDeviceTime, int timeoutms);

		/**
		 * @brief   设置设备时间
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param strtimeStamp                      设置时间，格式为 年-月-日 时:分:秒，如：2020-04-09 12:01:20
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetDeviceTime(IntPtr strDeviceIp, IntPtr strDeviceTime, int timeoutms);

		/**
		 * @brief   开闸
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_DeviceOpen(IntPtr strDeviceIp, int timeoutms);

		/**
		 * @brief   播报语音
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param strVoice                          语音信息，UTF8格式
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SendDeviceRawVoice(IntPtr strDeviceIp, IntPtr strVoice, int timeoutms);

		/**
		 * @brief   设备重置
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param restoreFlag                       重置类型，0:所有设置；1:除网络设置；2:仅网络设置
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_RestoreDeviceParam(IntPtr strDeviceIp, int restoreFlag, int timeoutms);

		/**
		 * @brief   获取设备设置信息
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param strDeviceParam                    返回设备设置信息，JSON格式，具体见协议文档
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_GetDeviceParam(string strDeviceIp, IntPtr strDeviceParam, int timeoutms);

		/**
		 * @brief   设置设备设置信息
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param strDeviceParam                    设备设置信息，JSON格式，具体见协议文档
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_SetDeviceParam(IntPtr strDeviceIp, IntPtr strDeviceParam, int timeoutms);

		/**
		 * @brief   获取设备版本信息
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param strDeviceVersion                  返回设备版本信息，JSON格式，具体见协议文档
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_GetDeviceVersion(IntPtr strDeviceIp, IntPtr strDeviceVersion, int timeoutms);

		/**
		 * @brief   设备重启
		 *
		 * @param strDeviceIp                       设备IP地址
		 * @param timeoutms                         接口超时时间，单位毫秒
		 *
		 * @return true on success
		 *               false on fail
		 */
		[DllImport(DLL_PATH)]
		public static extern bool FACE_DEVICE_NET_API_DeviceReboot(IntPtr strDeviceIp, int timeoutms);

	}
}
