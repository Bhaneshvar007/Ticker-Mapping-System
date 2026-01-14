using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class Role
    {
        public List<RoleModel> GetRoleData()
        {
            DataTable DT = DataAccess.ExecuteProcedure("sp_GetRole", null);
            return QueryHandler.GetRoleGridList(DT);
        }


        public static string AddRoleData(RoleModel role)
        {

            string Response = string.Empty;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString());
            try
            {

                SqlCommand cmd = new SqlCommand("sp_InsertRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserManager.User.Code);
                cmd.Parameters.AddWithValue("@Code", role.Code);
                cmd.Parameters.AddWithValue("@Name", role.Name);
                


                con.Open();
                cmd.ExecuteNonQuery();
                Helper.WriteLog("Role Added Sucessfully");

            }
            catch (Exception ex)
            {
                Helper.WriteLog("Error Role insert  : " + ex.Message);
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