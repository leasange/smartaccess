using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    public class UserInfoHelper
    {
        public static Maticsoft.Model.SMT_USER_INFO UserInfo = null;
        public static string OldPwd = "";
        public static decimal UserID {
            get {
                if (UserInfo!=null)
                {
                    return UserInfo.ID;
                }
                return -1;
            }
        }


        public static bool IsManager
        {
            get
            {
                if (UserInfoHelper.UserInfo==null)
                {
                    return false;
                }
                if (UserInfoHelper.UserInfo.USER_NAME == "admin" || PrivateMgr.FUN_POINTS.Contains(SYS_FUN_POINT.USER_PRIVATE_CONFIG))
                {
                    return true;
                }
                return false;
            }
        }

    }
}
