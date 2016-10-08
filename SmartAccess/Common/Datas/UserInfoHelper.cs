using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    public class UserInfoHelper
    {
        public static Maticsoft.Model.SMT_USER_INFO UserInfo = null;
        public static decimal UserID {
            get {
                if (UserInfo!=null)
                {
                    return UserInfo.ID;
                }
                return -1;
            }
        }
    }
}
