using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Xml.Linq;
using System.Configuration;

namespace Cash_Future_MappingSystem.BAL
{
    public class UserMaster
    {
        public List<UserModel> GetUserData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "") };
            Helper.WriteLog("Get User data");
            DataTable DT = DataAccess.ExecuteProcedure("sp_GetUserDetails", null);
            return QueryHandler.GetUsersData(DT);
        }

 
        public List<UserModel> GetUserById(int? id)
        {
            SqlParameter[] Params = { new SqlParameter("@UserId", id) };
            Helper.WriteLog("Get User data");
            DataTable DT = DataAccess.ExecuteProcedure("sp_GetUserDetails", Params);
            return QueryHandler.GetUsersData(DT);
        }

 
        public string AddUserData(UserModel user)
        {
            Helper.WriteLog(user.ToString());
            string Response = string.Empty;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString());
            try
            {
                 
                SqlCommand cmd = new SqlCommand("sp_InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserManager.User.Code);
                cmd.Parameters.AddWithValue("@Id", user.ID);
                 cmd.Parameters.AddWithValue("@Code", user.Code);
                 cmd.Parameters.AddWithValue("@Name", user.Name);
                 cmd.Parameters.AddWithValue("@Email", user.Email);
                 cmd.Parameters.AddWithValue("@RoleID", user.role_id);
                 cmd.Parameters.AddWithValue("@Password", user.Password);
                    

                con.Open();
                cmd.ExecuteNonQuery();
                Helper.WriteLog("User created Sucessfully");

            }
            catch (Exception ex)
            {
                Helper.WriteLog("Error Useramster insert user  : " + ex.Message);
                Response = ex.Message;
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