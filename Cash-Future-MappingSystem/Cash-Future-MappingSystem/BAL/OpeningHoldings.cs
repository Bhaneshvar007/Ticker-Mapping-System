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
    public class OpeningHoldings
    {
        public List<EquityHoldingsUploadModel> GetEquityOpeningHoldingsData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GetEqData") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_GetEquityHoldings", Params);
            return QueryHandler.GetEquityHoldingsUploadDatas(DT);
        }
        public List<FutureHoldingsUploadModel> GetFutureOpeningHoldingsData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "GetFutData") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_GetFutureHoldings", Params);
            return QueryHandler.GetFutureHoldingsUploadDatas(DT);
        }
        public List<JoinOpeningHoldingModel> GetJoinOpeningHoldingsData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_JoinOpeningHoldings", null);
            return QueryHandler.GetJoinOpeningHoldings(DT);
        }
    }
}