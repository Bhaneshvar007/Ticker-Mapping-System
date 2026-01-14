using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class SecurityMaster
    {



        public List<SecurityModel> GetSecurityGrid()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GETALL") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_SecurityMaster_CRUD", Params);
            return QueryHandler.GetSecurityGridList(DT);
        }

        public SecurityModel GetItem(int id)
        {
            SqlParameter[] Params = {
            new SqlParameter("@Action", "GETBYID"),
            new SqlParameter("@Security_ID", id)
        };
            DataTable DT = DataAccess.ExecuteProcedure("sp_SecurityMaster_CRUD", Params);
            return QueryHandler.GetSecurityGridList(DT).FirstOrDefault();
        }

        public string Save(SecurityModel model, string action = "UPDATE")
        {
            DbCommonHelper dbcom = new DbCommonHelper();
            SqlParameter[] Params = {
                                new SqlParameter("@Action", action),
                                new SqlParameter("@Security_ID", model.Security_ID),
                                new SqlParameter("@Parent_Ticker", (object)model.Parent_Ticker ?? DBNull.Value),
                                new SqlParameter("@NSE_CODE", (object)model.NSE_CODE ?? DBNull.Value),
                                new SqlParameter("@NSE_Ticker", (object)model.NSE_Ticker ?? DBNull.Value),
                                new SqlParameter("@BSE_Ticker", (object)model.BSE_Ticker ?? DBNull.Value),
                                new SqlParameter("@Common_Ticker", (object)model.Common_Ticker ?? DBNull.Value),
                                new SqlParameter("@CurrentMonth", (object)model.CurrentMonth ?? DBNull.Value),
                                new SqlParameter("@CurrentMonth_BBG", (object)model.CurrentMonth_BBG ?? DBNull.Value),
                                new SqlParameter("@CurrentMonth_LotSize", (object)model.CurrentMonth_LotSize ?? DBNull.Value),
                                new SqlParameter("@NextMonth", (object)model.NextMonth ?? DBNull.Value),
                                new SqlParameter("@NextMonth_BBG", (object)model.NextMonth_BBG ?? DBNull.Value),
                                new SqlParameter("@NextMonth_LotSize", (object)model.NextMonth_LotSize ?? DBNull.Value),
                                new SqlParameter("@FarMonth", (object)model.FarMonth ?? DBNull.Value),
                                new SqlParameter("@FarMonth_BBG", (object)model.FarMonth_BBG ?? DBNull.Value),
                                new SqlParameter("@FarMonth_LotSize", (object)model.FarMonth_LotSize ?? DBNull.Value),
                                new SqlParameter("@IsActive", (object)model.IsActive ?? DBNull.Value),
                                new SqlParameter("@Created_By", (object)model.Created_By ?? "SYSTEM")
                    };
            return dbcom.Save("sp_SecurityMaster_CRUD", Params);
        }



        public List<SecurityModel> GetOldSecurityGrid()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GETALLOLD") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_SecurityMaster_CRUD", Params);
            return QueryHandler.GetSecurityGridList(DT);
        }

    }
}