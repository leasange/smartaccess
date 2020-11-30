using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class OnlineGetRegisterByIdNumberMsgResp : BaseMsgWithError
    {
        public string idNumber;// 人员编号 string 32 Y 如：20001，该编号每个人员唯一
        public string normalNumber;// IC卡号 string 32 N 如：8899,绑定IC卡或预约身份证时下发
        public string name;// 人员姓名 string 32 Y 如：张三
        public string sex;// 人员性别 string 32 Y 如：男
        public string birthday;// 人员生日 string 32 Y 如：1997年4月3日
        public string phone;// 手机号码 string 16 Y 如：18868681819
        public string validDateStart;// 有效期开始时间 string 32 Y 如：2019_08_09
        public string validDateEnd;// 有效期结束时间 string 32 Y 如：2029_08_09
        public string priority;// 通行权限 string 2 N 0:代表允许通行时段内通行字符 1:代表禁止通行(黑名单) 2:代表任意通行(vip)
        public string registerPhoto1;// 发行照片 1 string 不限 Y Base64 格式，建议限制在 400K内
        public string registerPhotoID1;// 发行照片 1 编号 string 32 Y 如：654321,6 位的随机数，必须是数字转string
        public string registerPhoto2;// 发行照片 2 string 不限 N Base64 格式，建议限制在400K内
        public string RegisterPhotoID2;// 发行照片 2 编号 string 32 N 如：654322,6 位的随机数，必须是数字转string
        public string RegisterPhoto3;// 发行照片 3 string 不限 N Base64 格式，建议限制在400K内
        public string registerPhotoID3;// 发行照片 3 编号 string 32 N 如：654323,6 位的随机数，必须是数字转string
        public string voiceSpecialMode;// 个性化播报模式 string 8 N 0:禁止个性化播报（默认）1:播报姓名+个性化语音2:播报姓名3：播报个性化语音4：播报固定语音5：播报姓名+固定语音
        public string voiceNameSexEnable;// 个性化播报姓名称谓模式（先生，女士）string 8 N 0:不带称谓（默认）1:带称谓
        public string visitorVoiceTextBeforeName;//播报姓名前附加个性化语音string 30 N 如“亲爱的”
        public string visitorVoiceText;// 播报姓名后附加个性化语音string 30 N 如“欢迎您的参观”
        public string displaySpecialMode;// 个性化显示模式 string 8 N 0:禁止个性化显示（默认）1:显示姓名+个性化文字2:显示姓名3：显示个性化文字4：显示固定文字5：显示姓名+固定文字
        public string displayNameSexEnable;//个性化显示姓名称谓模式（先生，女士）string 8 N 0:不带称谓（默认）1:带称谓
        public string visitordisplayTextBeforeName;// 显示姓名前附加个性化文字string 30 N 如“亲爱的”
        public string visitordisplayText;// 显示姓名后附加个性化文字string 30 N 如“欢迎您的参观”
        public string passTime1;// 周一有效通行时段 string 256 N 如：”xx_xx,xx_xx”xx_xx表示：时_分依次为有效开始时间和有效结束时间，每个时间用“,”分割，每两个对应一个时间段，最多支持5个段时间,不填默认全天有效
        public string passTime2;//周二有效通行时段 string 256N 如：”xx_xx,xx_xx”xx_xx表示：时_分依次为有效开始时间和有效结束时间，每个时间用“,”分割，每两个对应一个时间段，最多支持5个段时间,不填默认全天有效
        public string passTime3;//周三有效通行时段 string 256N 如：”xx_xx,xx_xx”xx_xx表示：时_分依次为有效开始时间和有效结束时间，每个时间用“,”分割，每两个对应一个时间段，最多支持5个段时间,不填默认全天有效
        public string passTime4;//周四有效通行时段 string 256N 如：”xx_xx,xx_xx”xx_xx表示：时_分依次为有效开始时间和有效结束时间，每个时间用“,”分割，每两个对应一个时间段，最多支持5个段时间,不填默认全天有效
        public string passTime5;
        public string passTime6;
        public string passTime7;
    }
}
