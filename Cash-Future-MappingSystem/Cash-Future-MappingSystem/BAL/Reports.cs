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
    public class Reports
    {
        public List<TickerMappingModel> GetDailyMatchedSummryReports(dynamic data)
        {

            string broker = data?["Broker"] != null ? data["Broker"].ToString() : null;

            string account = data?["accountname"] != null ? data["accountname"].ToString() : null;
            string TransactionType = data?["TransactionType"] != null ? data["TransactionType"].ToString() : null;


            SqlParameter[] Params = {
                                        new SqlParameter("@broker",  broker ),
                                        new SqlParameter( "@Account" , account),
                                        new SqlParameter("@TransactionType",  TransactionType )
                                    };

            DataTable DT = DataAccess.ExecuteProcedure("SP_DailyMatchedSummryReport", Params);
          
            return QueryHandler.GetDailyMatchedSummryReportData(DT);
        }

        public List<BrokerAccountLevelMatchingModel> GetBrokerwiseMatchingReports(dynamic data)
        {
            string broker = data?["Broker"] != null ? data["Broker"].ToString() : null;
            string Account = data?["Account"] != null ? data["Account"].ToString() : null;
            //string TransactionType = data?["TransactionType"] != null ? data["TransactionType"].ToString() : null;
            

            SqlParameter[] Params = {
                                        new SqlParameter("@broker",  broker ),
                                        new SqlParameter("@Account",  Account ),
                                       // new SqlParameter("@TransactionType",  TransactionType ),

                                    };
            //DataTable DT = DataAccess.ExecuteProcedure("sp_BrokerWiseMatchedReport", Params);
            DataTable DT = DataAccess.ExecuteProcedure("sp_BrokerAccountLevelMatchingReport", Params);
            return QueryHandler.GetBrokerwiseMatchingReportData(DT);
        }

        public List<TickerMappingModel> GetUnmatchedTradesReports(dynamic data)
        {
            string broker = data?["Broker"] != null ? data["Broker"].ToString() : null;

            string account = data?["accountname"] != null ? data["accountname"].ToString() : null;
            string TransactionType = data?["TransactionType"] != null ? data["TransactionType"].ToString() : null;


            SqlParameter[] Params = {
                                        new SqlParameter("@broker",  broker ),
                                        new SqlParameter( "@Account" , account),
                                        new SqlParameter("@TransactionType",  TransactionType )
            };

            DataTable DT = DataAccess.ExecuteProcedure("sp_UnMatchedTradeReport", Params);
            return QueryHandler.GetUnmatchedTradesReportData(DT);
        }



        public List<TradeWiseReportModel> GetTradewiseMatchingLogReports(dynamic data)
        {
            string broker = data?["Broker"] != null ? data["Broker"].ToString() : null;

            string account = data?["accountname"] != null ? data["accountname"].ToString() : null;
            string TransactionType = data?["TransactionType"] != null ? data["TransactionType"].ToString() : null;


            SqlParameter[] Params = {
                                        new SqlParameter("@Broker",  broker ),
                                        new SqlParameter( "@Account" , account),
                                        new SqlParameter("@TransactionType",  TransactionType )
            };

            DataTable DT = DataAccess.ExecuteProcedure("sp_TradeWiseMatchingReport", Params);
            return QueryHandler.GetTradewiseMatchingLogReportData(DT);
        }



        public List<FilterDataModel> BrokerFilterDatas()
        {
            SqlParameter[] Params = { new SqlParameter("@FilterName", "Broker") };

            DataTable DT = DataAccess.ExecuteProcedure("sp_FilterData", Params);
            return QueryHandler.GetBrokerFilterData(DT);
        }
        public List<FilterDataModel> AccountFilterDatas()
        {
            SqlParameter[] Params = { new SqlParameter("@FilterName", "Account") };

            DataTable DT = DataAccess.ExecuteProcedure("sp_FilterData", Params);
            return QueryHandler.GetAccountFilterData(DT);
        }
        
        public List<FilterDataModel> PageAccessLogFilterDatas() 
        {
            SqlParameter[] Params = { new SqlParameter("@FilterName", "Pagename") };

            DataTable DT = DataAccess.ExecuteProcedure("sp_FilterData", Params);
            return QueryHandler.GetPageAccessLogFilterData(DT);
        }
    }
}