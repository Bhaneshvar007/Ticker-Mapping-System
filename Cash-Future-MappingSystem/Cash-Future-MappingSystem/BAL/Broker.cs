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
    public class Broker
    {


        public List<TradeConfirmation> GetConfirmationBroker()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GETALL") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_finalbroker_temp_CRUD", Params);
            Helper.WriteLog("Broker Data " + DT);
            return QueryHandler.GetConfirmationbrokerGridList(DT);
            
        }

        public TradeConfirmation GetItem(int id)
        {
            SqlParameter[] Params = {
            new SqlParameter("@Action", "GETBYID"),
            new SqlParameter("@Id", id)
        };
            DataTable DT = DataAccess.ExecuteProcedure("sp_finalbroker_temp_CRUD", Params);
            return QueryHandler.GetConfirmationbrokerGridList(DT).FirstOrDefault();
        }

        public string Save(TradeConfirmation model, string action = "UPDATE")
        {
            DbCommonHelper dbcom = new DbCommonHelper();
            SqlParameter[] Params = {
            new SqlParameter("@Action", action),
            new SqlParameter("@Id", model.Id), // For UPDATE, use Id
            new SqlParameter("@Account", model.Account ?? (object)DBNull.Value),
            new SqlParameter("@Security", model.Security ?? (object)DBNull.Value),
            new SqlParameter("@Price", model.Price ?? (object)DBNull.Value),
            new SqlParameter("@Side", model.Side ?? (object)DBNull.Value),
            new SqlParameter("@Quantity", model.Quantity ?? (object)DBNull.Value),
            new SqlParameter("@Broker", model.Broker ?? (object)DBNull.Value),
            new SqlParameter("@Reason", model.Reason ?? (object)DBNull.Value),
            new SqlParameter("@LongNote1", model.LongNote1 ?? (object)DBNull.Value)
            // Removed extra Lot and IsActive parameters as per your instruction
        };
            return dbcom.Save("sp_finalbroker_temp_CRUD", Params);
        }

        public List<TradeConfirmation> GetOldBrokerData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GETALLOLD") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_finalbroker_temp_CRUD", Params);
            Helper.WriteLog("Broker Data " + DT);
            return QueryHandler.GetConfirmationbrokerGridList(DT);

        }

    }
}