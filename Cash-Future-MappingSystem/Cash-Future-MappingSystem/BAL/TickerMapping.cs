using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Cash_Future_MappingSystem.BAL
{
    public class TickerMapping
    {
        public List<TickerMappingModel> GetTickerMappingData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "Get-Ticker") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_TickerProcessing", Params);
            return QueryHandler.GetTickerMappingDatas(DT);
        }
        public List<TickerMappingModel> ProcessTickerMappingData(out string message)
        {
            message = "";
            SqlParameter[] Params = { new SqlParameter("@Action", "Process-Ticker") };
            DataTable DT = DataAccess.ExecuteProcedure("sp_TickerProcessing", Params);

            if (DT != null && DT.Columns.Contains("Message"))
            {
                message = DT.Rows[0]["Message"].ToString();
                Helper.WriteLog(message);
                return new List<TickerMappingModel>();  
            }
            else
            {
                message = "No message returned.";
                return QueryHandler.GetTickerMappingDatas(DT); 
            }
        }

    }
}