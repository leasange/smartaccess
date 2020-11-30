using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class UploadRecordMsg: BaseMsgWithIdAndToken
    {
        public string version;// 接口版本 string 32 Y 如：V1.0
        public string snapType;// 识别类型 string 8 Y 0：自动识别1：人证对比（身份证）2：IC 卡对比3：陌生人4：IC 卡
        public string compareResult;// 比对结果 string 8 Y 0：比对成功1：比对失败2：不在通行时间内3：不在有效期内4：未授权
        public string passTime;// 识别时间 string 32 Y 格式：年-月-日：时:分:秒.毫秒2019-11-08 13:05:51.421
        public string idNumber;// 人员编号 string 32 Y 如：20001
        public string name;// 人员姓名 string 32 Y 如：张三
        public string sex;// 人员性别 string 32 Y 如：男
        public string birth;// 人员生日 string 32 Y 人脸识别上报格式：1997年4月3日人证识别上报格式：19970403注意区分
        public string company;// 所属公司 string 32 Y 如：XX 科技有限公司
        public string department;// 所属部门 string 32 Y 如：测试部
        public string phone;// 手机号码 string 16 Y 如：18868681819
        public string validDateStart;// 有效期开始时间 string 32 Y 如：2019_10_8
        public string validDateEnd;// 有效期结束时间 string 32 Y 如：2029_10_8
        public string visitorVoiceText;// 播报内容 string 30 Y 如：欢迎光临
        public string inOutMode;// 出入口模式 string 8 Y 0：未知1：入口2：出口
        public string recognitionPhoto;// 识别图片 string 不限 Y Base64 格式，jpeg图片
        public string comparePhoto;// 比对图片 string 不限 N Base64 格式，jpeg图片，如果识别类型是员工该项必填，如果识别类型是陌生人，该项为空
        public string temperature;// 体温 string 8 N 如36.5
        public string temperatureResult;//体温检测结果 string 8 N 0:没开启此功能1：体温正常2：体温不正常
        public string rfIdNumber;// 身份证号 string 32 N 如果是人证对比，上传该项
        public string ethnicity;// 种族 string 16 N 如果是人证对比，上传该项
        public string address;// 地址 string 64 N 如果是人证对比，上传该项
        public string authority;// 身份证颁证机构 string 32 N 如果是人证对比，上传该项
        public string locationx;// 经度 string 32 N 如：116.481499，小数点后不得超过6位, 有GPS或4G模块时上报
        public string locationy;// 纬度 string 32 N 如：39.990475，小数点后不得超过6位，有GPS或4G模块时上报
        public string normalNumber;// IC卡号 string 32 N 如：8899
        public string offLineRecordNum;// 离线记录数 string 32 Y 如：0
    }
}
