using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class Login : EntityBusinessLogicBase<Login>
    {
        public UserDetailsModel GetUserDetail(string UserID, string Password)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            DataTable DT = DataAccess.ExecuteQuery("select * from cftms_tbl_user_master where code='" + UserID + "'");
            //DataTable DT = DataAccess.ExecuteQuery(
            //    "SELECT * FROM cftms_tbl_user_master " +
            //    "WHERE code = '" + UserID + "' AND Password = '" + Password + "'"
            //);
            Helper.WriteLog("user details" + DT);
            bool IsAdLogin = Convert.ToBoolean(ConfigurationManager.AppSettings["IsADLogin"].ToString());

            if (IsAdLogin)
            {
                if (CheckUser(UserID, Password))
                {
                    umodel = QueryHandler.GetUserDetails(DT);
                    Helper.WriteLog("user details" + umodel.Name);
                }
                else
                {
                    umodel = null;
                }
            }
            else
            {
                if (DT.Rows.Count > 0)
                {
                    umodel = QueryHandler.GetUserDetails(DT);
                }
                else
                {
                    umodel = null;
                }
            }
            return umodel;
        }


        public bool CheckUser(string userid, string password)
        {
            bool status = false;

            DirectoryEntry entry = new DirectoryEntry(ConfigurationManager.AppSettings["ADConnectionString"].ToString(), userid.Trim(), password);
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + userid + ")";

                search.PropertiesToLoad.Add("cn");

                SearchResult result = search.FindOne();

                if (null == result)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
#pragma warning restore CS0168 // Variable is declared but never used
            return status;
        }
    }
}