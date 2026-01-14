using MicroORM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Cylsys.Common;
using System.Configuration;
using WebGrease.Css.Ast;

namespace Cash_Future_MappingSystem.BAL
{
    public class PageAccessLog
    {

        public List<UserPageAccessLogsModel> GetPageAccessLogsData(dynamic data)
        {
            
             
            string emailSearch = data?["emailSearch"] != null ? data["emailSearch"].ToString() : null;
            string toDate = data?["toDate"] != null ? data["toDate"].ToString() : null;
            string fromDate = data?["fromDate"] != null ? data["fromDate"].ToString() : null;

            SqlParameter[] Params = {
                                        new SqlParameter("@from_date",  fromDate ),
                                        new SqlParameter("@to_date",  toDate ),
                                        new SqlParameter("@email_id_search",  emailSearch )

                                    };
            DataTable DT = DataAccess.ExecuteProcedure("sproc_GetPageAccessLogsReport", Params);
            return QueryHandler.GetUserPageAccessLogs(DT);
        }

        public string InsertPageAccessLogsData(string page_name, string sessionId, string Ip_address)
        {
            string Response = string.Empty;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString());
            try
            {
          
                //Helper.WriteLog("Inside the pageacess insert" + page_name);
                SqlCommand cmd = new SqlCommand("sproc_InserttblUserPageAccessLogs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserManager.User.Code);
                cmd.Parameters.AddWithValue("@EmailID", UserManager.User.Email);
                cmd.Parameters.AddWithValue("@AccessDateTime", DateTime.UtcNow.AddMinutes(330));
                cmd.Parameters.AddWithValue("@PageName", page_name);
                cmd.Parameters.AddWithValue("@LoginDateTime", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@SessionID", sessionId);
                cmd.Parameters.AddWithValue("@IpAddress", Ip_address);


                con.Open();
                cmd.ExecuteNonQuery();
               // Helper.WriteLog("inserted PageAcesslog Sucessfully");

            }
            catch (Exception ex)
            {
                Helper.WriteLog("Error PageAccess : "+ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            return Response;
        }


    }
}