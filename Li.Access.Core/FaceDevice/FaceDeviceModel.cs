using Li.Access.Core.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Li.Access.Core.FaceDevice
{
    public delegate void FaceRealRecordHandle(IFaceRecg recg, FaceRecgRecord log);
    public enum FaceDeviceModel
    {
        BST,//博思廷人脸识别
        FY,//富盈人脸
    }
    [DataContract]
    public class StaffFace
    {
        [DataMember]
        public string id;
        [DataMember]
        public bool old_upload_state;
        [DataMember]
        public string name;
        private byte[] images;
        public void setImage(byte[] img = null)
        {
            images = img;
        }
        public byte[] getImage()
        {
            return images;
        }
        [DataMember]
        public string base64Image
        {
            get
            {
                return Convert.ToBase64String(images);
            }
            set
            {
                images = Convert.FromBase64String(value);
            }
        }
        [DataMember]
        public string date_begin;
        [DataMember]
        public string date_end;
        [DataMember]
        public string org_name;
        [DataMember]
        public string staff_no;
        [DataMember]
        public string card_no;
        [DataMember]
        public string staff_type;//访客，内部员工
        [DataMember]
        public bool update_result = false;

        //[DataMember]
        // public FaceDeviceModel model;
        // [DataMember]
        // public decimal dev_id;
        // [DataMember]
        // public string dev_ip;
        [DataMember]
        public string sex;
        [DataMember]
        public string birthday;
        [DataMember]
        public string phone;
        [DataMember]
        public bool forceUpload = false;
    }
    public interface IFaceRecg : IDisposable
    {
        bool IsHeartbeating { get; }
        bool IsWGCardNo { get; }
        void BeginHeartbeat();
        bool ClearFaces();
        FaceDeviceModel GetDeviceModel();
        bool AddOrModifyFaces(out string tempMsg, params StaffFace[] staffFace);
        bool DeleteFaces(List<string> deleteprivates);
        bool IsFaceExists(string id);
        bool ModifyTextInfo(out string errorMsg, params StaffFace[] staffFaces);
        void SetRealRecordCallback(FaceRealRecordHandle faceRealRecordHandle);

        bool StartPlayVideo(IntPtr winHandle);

        void StopPlayVideo(IntPtr winHandle);
    }
    public interface IServerFaceRecg
    {
        ContinueRet AddOrModifyFace(ComReq<StaffFace> comReq);
        ContinueRet DeleteFaces(ComReq<List<string>> comReq);
        ContinueRet IsFaceExists(ComReq<string> comReq);
    }

    public class FaceDeviceClass
    {
        public decimal _id;
        public string _sn;
        public string _ip;
        public int _port;
        public int _heartPort;
        public int _dbPort;
        public string _dbName;
        public string _dbUser;
        public string _dbPwd;
        public string _devName;
        public FaceDeviceModel _faceDeviceModel;
    }

    public class FaceRecgRecord
    {
        public string recordId;
        public string staffDevId;
        public DateTime time;//时间
        public string realName;//姓名
        public string cardNo;//证件编号
        public string staffType;//职员类型
        public byte[] photoImage;//照片
        public byte[] videoImage;//视频图片
        public string deptName;//部门名称
        public double compareVal;//比对相似度,0-1

    }
}
