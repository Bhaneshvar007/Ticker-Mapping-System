using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class Settings
    {
        public List<EquityHoldingsUploadModel> GetOldEquityOpeningHoldingsData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GetBulkEqData") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_GetEquityHoldings", Params);
            return QueryHandler.GetEquityHoldingsUploadDatas(DT);
        }
        public List<FutureHoldingsUploadModel> GetOldFutureOpeningHoldingsData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GetBulkFutData") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_GetFutureHoldings", Params);
            return QueryHandler.GetFutureHoldingsUploadDatas(DT);
        }

        public List<SecurityModel> GetOldSecurityGrid()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GETALLOld") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_SecurityMaster_CRUD", Params);
            return QueryHandler.GetSecurityGridList(DT);
        }
    }
}