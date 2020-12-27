using Li.Access.Core.Datas;
using Li.Access.Core.FaceDevice;
using Li.Access.Core.FaceDevice.FY;
using Li.Access.Core.FaceDevice.FY.Msg;
using SunCreate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.SmartAcsServer.FyFaceService
{
    public class FyServerFaceRecg : IServerFaceRecg
    {
        private static long msgId = 0; 
        private static FyServerFaceRecg _instance;
        public static FyServerFaceRecg Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new FyServerFaceRecg();
                }
                return _instance;
            }
        }

        public ContinueRet AddOrModifyFace(ComReq<StaffFace> comReq)
        {
            var fyClient = FyFaceTaskService.Instance.FaceServer[comReq.dev_ip];
            if (fyClient==null)
            {
                return new ContinueRet()
                {
                     isContinue=false,
                     isSuccess=false,
                     errorMsg="人脸设备未有上线："+ comReq.dev_ip
                };
            }
            RegisterPersonMsg registerPersonMsg = new RegisterPersonMsg()
            {
                msgType = "registerPersonInfo",
                msgID = (++msgId).ToString(),
                personInfoCount= "1",
                personInfoData=new List<PersonInfo>()
            };
            PersonInfo personInfo = new PersonInfo();
            registerPersonMsg.personInfoData.Add(personInfo);
            var staffFace = comReq.data;
            personInfo.idNumber = staffFace.id;
            if (staffFace.old_upload_state)
            {
                if (staffFace.forceUpload)
                {
                    personInfo.operateType = "2";
                    var con = DoSendRegisterPerson(fyClient, registerPersonMsg);
                    if (!con.isContinue)
                    {
                        return con;
                    }
                    personInfo.operateType = "0";
                }
                else
                {
                    personInfo.operateType = "1";
                }
             
            }
            else
            {
                personInfo.operateType = "0";
            }
            string card = Access.Core.DataHelper.ToUintFromHexString(staffFace.card_no).ToString();
            if (card.Length < 10)//需要补足10位
            {
                int l = 10 - card.Length;
                for (int i = 0; i < l; i++)
                {
                    card = "0" + card;
                }
            }
            personInfo.normalNumber = card;
            personInfo.name = staffFace.name;
            personInfo.sex = staffFace.sex;
            DateTime bd;
            DateTime.TryParse(staffFace.birthday, out bd);
            personInfo.birthday = bd.ToString("yyyy年MM月dd日");
            personInfo.phone = staffFace.phone;
            personInfo.validDateStart = staffFace.date_begin.Split(' ')[0].Replace('-', '_');//yyyy-MM-dd HH:mm:ss
            personInfo.validDateEnd = staffFace.date_end.Split(' ')[0].Replace('-', '_');
            personInfo.priority = "2";
            personInfo.registerPhoto1 = staffFace.base64Image;
            personInfo.registerPhotoID1 = "100000";
            personInfo.voiceSpecialMode = "0";
            personInfo.voiceNameSexEnable = "0";
            personInfo.visitordisplayTextBeforeName = "";
            personInfo.visitorVoiceText = "";
            personInfo.displaySpecialMode = "1";
            personInfo.displayNameSexEnable = "0";
            personInfo.visitordisplayTextBeforeName = "";
            personInfo.visitordisplayText = staffFace.org_name;
            //置空值
           /* personInfo.registerPhoto2 = "";
            personInfo.registerPhoto3 = "";
            personInfo.registerPhotoID2 = "";
            personInfo.registerPhotoID3 = "";
            personInfo.passTime1 = "";
            personInfo.passTime2 = "";
            personInfo.passTime3 = "";
            personInfo.passTime4 = "";
            personInfo.passTime5 = "";
            personInfo.passTime6 = "";
            personInfo.passTime7 = "";
            personInfo.visitorVoiceTextBeforeName = "";*/
            return DoSendRegisterPerson(fyClient, registerPersonMsg);
        }
        private ContinueRet DoSendRegisterPerson(FyFaceClient fyFaceClient, RegisterPersonMsg registerPersonMsg)
        {
            try
            {
                RegisterPersonMsgResp resp = fyFaceClient.SendData<RegisterPersonMsgResp>(registerPersonMsg);
                if (resp == null)
                {
                    return new ContinueRet()
                    {
                        isContinue = false,
                        isSuccess = false,
                        errorMsg = "未有数据返回：" + fyFaceClient.ip
                    };
                }
                bool ret = resp.errorCode == "100";
                return new ContinueRet()
                {
                    isContinue = true,
                    isSuccess = ret,
                    errorMsg = ret ? "成功" : resp.msg
                };
            }
            catch (Exception ex)
            {
                return new ContinueRet()
                {
                    isContinue = false,
                    isSuccess = false,
                    errorMsg = "发送未知异常错误：" + ex.Message + "," + fyFaceClient.ip
                };
            }
        }

        private ContinueRet DoSendOnlinePerson(FyFaceClient fyFaceClient, OnlineGetRegisterByIdNumberMsg online)
        {
            try
            {
                OnlineGetRegisterByIdNumberMsgResp resp = fyFaceClient.SendData<OnlineGetRegisterByIdNumberMsgResp>(online);
                if (resp == null)
                {
                    return new ContinueRet()
                    {
                        isContinue = false,
                        isSuccess = false,
                        errorMsg = "未有数据返回：" + fyFaceClient.ip
                    };
                }
                bool ret = resp.errorCode == "100";
                return new ContinueRet()
                {
                    isContinue = true,
                    isSuccess = ret,
                    errorMsg = ret ? "成功" : "失败"
                };
            }
            catch (Exception ex)
            {
                return new ContinueRet()
                {
                    isContinue = false,
                    isSuccess = false,
                    errorMsg = "发送未知异常错误：" + ex.Message + "," + fyFaceClient.ip
                };
            }
        }

        public ContinueRet DeleteFaces(ComReq<List<string>> comReq)
        {
            var fyClient = FyFaceTaskService.Instance.FaceServer[comReq.dev_ip];
            if (fyClient == null)
            {
                return new ContinueRet()
                {
                    isContinue = false,
                    isSuccess = false,
                    errorMsg = "人脸设备未有上线：" + comReq.dev_ip
                };
            }
            RegisterPersonMsg registerPersonMsg = new RegisterPersonMsg()
            {
                msgType = "registerPersonInfo",
                msgID = (++msgId).ToString(),
                personInfoCount = comReq.data.Count.ToString(),
                personInfoData = new List<PersonInfo>()
            };
            foreach (var id in comReq.data)
            {
                PersonInfo personInfo = new PersonInfo();
                registerPersonMsg.personInfoData.Add(personInfo);
                personInfo.idNumber = id;
                personInfo.operateType = "2";
            }
            return DoSendRegisterPerson(fyClient, registerPersonMsg);
        }

        public ContinueRet IsFaceExists(ComReq<string> comReq)
        {
            var fyClient = FyFaceTaskService.Instance.FaceServer[comReq.dev_ip];
            if (fyClient == null)
            {
                return new ContinueRet()
                {
                    isContinue = false,
                    isSuccess = false,
                    errorMsg = "人脸设备未有上线：" + comReq.dev_ip
                };
            }
            OnlineGetRegisterByIdNumberMsg online = new OnlineGetRegisterByIdNumberMsg()
            {
                msgType = "onlineGetRegisterByIdNumber",
                msgID = (++msgId).ToString(),
                idNumber= comReq.data
            };
            return DoSendOnlinePerson(fyClient, online);
        }
    }
}
