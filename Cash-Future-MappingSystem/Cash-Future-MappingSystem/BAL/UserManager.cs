using Cylsys.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class UserManager
    {

        public static UserDetailsModel User
        {
            get
            {
                return (UserDetailsModel)HttpContext.Current.Session["UserDetails"];
            }
        }
        public static string GetUserID
        {
            get
            {
                return User.Code;
            }
        }

    }
}