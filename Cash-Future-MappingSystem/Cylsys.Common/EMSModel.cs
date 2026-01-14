using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cylsys.Common
{
    public class EMSModel
    {
    }

    public class TradeConfirmation
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Security { get; set; }
        public string Price { get; set; }
        public string Side { get; set; }
        public string Quantity { get; set; }
        public string Broker { get; set; }
        public string Reason { get; set; }
        public string LongNote1 { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public class SecurityModel
    {
        public int Security_ID { get; set; }
        public string Parent_Ticker { get; set; }
        public string NSE_CODE { get; set; }
        public string NSE_Ticker { get; set; }
        public string BSE_Ticker { get; set; }
        public string Common_Ticker { get; set; }
        public string CurrentMonth { get; set; }
        public string CurrentMonth_BBG { get; set; }
        public decimal? CurrentMonth_LotSize { get; set; } // Nullable decimal for DBNull
        public string NextMonth { get; set; }
        public string NextMonth_BBG { get; set; }
        public decimal? NextMonth_LotSize { get; set; }
        public string FarMonth { get; set; }
        public string FarMonth_BBG { get; set; }
        public decimal? FarMonth_LotSize { get; set; }
        public DateTime? Created_Date { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Updated_Date { get; set; }
        public string Created_By { get; set; }
    }
    public class ClientMoodel
    {
        public int Client_ID { get; set; }
        public string ClientName { get; set; }
        public string AccountNo { get; set; }
        public string SecurityId { get; set; }
        public string Security { get; set; }
        public string Side { get; set; }
        public int Quantity { get; set; }
        public int Broker_Id { get; set; }
        public string Broker { get; set; }
        public DateTime? Created_Date { get; set; }
        public bool? isactive { get; set; }
        public string File_Name_Mast { get; set; }
    }

    public class TickerMappingModel
    {
        public int TickerId { get; set; }
        public int? BrokerId { get; set; }
        public int? SecurityId { get; set; }
        public string Security { get; set; }
        public string Broker { get; set; }
        public string Account { get; set; }
        public string Side { get; set; }
        public string ParentTicker { get; set; }
        public int? Quantity { get; set; }
        public string QuantityMatching { get; set; }
        public string Price { get; set; }
        public string DVD { get; set; }
        public string ConvertedSide { get; set; }
        public string TotalPrice { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string Comment { get; set; }
        public int? ClientId { get; set; }
        public int? Reason { get; set; }
        public decimal? LongNote { get; set; }
        public string Instrument_Type { get; set; }
        public string Common_ParentTicker { get; set; }
        public string Spread { get; set; }
        public string TradeDirection { get; set; }
        public string TransactionType { get; set; }
        public string BrokerLongNote { get; set; }
        public string TickerLongNote { get; set; }
        public string WeightedSpread { get; set; }
        public string HoldingsCheck { get; set; }
    }


    public class UserPageAccessLogsModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string AccessTime { get; set; }
        public string PageName { get; set; }
        public string LoginTime { get; set; }
        public string SessionId { get; set; }
        public string IpAddress { get; set; }
        public int total_records { get; set; }
    }


    public class FilterDataModel
    {
        public string BrokerName { get; set; }
        public string AccountName { get; set; }
        public string CommonTicker { get; set; }
        public string ParentTicker { get; set; }
        public int? SecurityId { get; set; }
        public string PageName { get; set; }
        public string EmailId { get; set; }
        public int? UserId { get; set; }

    }



    public class FileMasterModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Email { get; set; }
        public string FileRef { get; set; }
        public string UplodedBy { get; set; }
        public DateTime? UplodedDate { get; set; }
        public int TotalRecord { get; set; }



    }



    public class EquityHoldingsUploadModel
    {
        public int EquityHoldingsId { get; set; }
        public string DisplayName { get; set; }
        public string Issuer { get; set; }
        public string Position { get; set; }
        public string Saleable { get; set; }
        public string UnderlyingEquivalentPosition { get; set; }
        public string IndustrySector { get; set; }
        public string Price { get; set; }
        public string PreviousEODPrice { get; set; }
        public string PreviousDay_Futures { get; set; }
        public string CumAvgCost { get; set; }
        public string SecurityDescription { get; set; }
        public string AssetType { get; set; }
        public string GrossExp_NAV { get; set; }
        public string Industry { get; set; }
        public string A_Cost_Local { get; set; }
        public string Change { get; set; }
        public string AccruedInterest { get; set; }
        public string TotalPL { get; set; }
        public string GrossMV { get; set; }
        public string ISIN { get; set; }
        public string ACCRINT { get; set; }
        public string ParentCompanyName { get; set; }
        public string AccountName { get; set; }
        public string Cusip { get; set; }
        public string Previous_Day_Perc { get; set; }
        public string IsClosed { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class FutureHoldingsUploadModel
    {
        public int FutureHoldingsId { get; set; }
        public string DisplayName { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string Name { get; set; }
        public string SecurityDescription { get; set; }
        public string Position { get; set; }
        public string UnderlyingEquivalentPosition { get; set; }
        public string A_MarketValueLocal { get; set; }
        public string Price { get; set; }
        public string ExpirationDate { get; set; }
        public string Issuer { get; set; }
        public string IsClosed { get; set; }
        public DateTime? CreatedDate { get; set; }
    }


    public class JoinOpeningHoldingModel
    {
        public int Id { get; set; }
        public string EquityDisplayName { get; set; }
        public string AccountName { get; set; }
        public string Issuer { get; set; }
        public string EquityPosition { get; set; }    
        public string Saleable { get; set; }

        public string FutureDisplayName { get; set; }
        public string AccountCode { get; set; }
        public string FuturePosition_Lots { get; set; }
        public string FuturePosition { get; set; }
    }




    public class TransactionTypeModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }


    public class BrokerAccountLevelMatchingModel
    {
        public string Broker { get; set; }

        public string Account { get; set; }

 
        public string CashTradeValue { get; set; }

        public string FutureTradeValue { get; set; }

        public string NetTradeValue { get; set; }

  
        public string QuantityStatus { get; set; }   // Matched / Mismatched

    
        public string Spread { get; set; }
    }


    public class TradeWiseReportModel
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Broker { get; set; }
        public string TransactionType { get; set; }
        public string CashPrice { get; set; }
        public string FuturePrice { get; set; }
        public string WeightedSpread { get; set; }
 
    }











    public class SchemeModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    public class OrderManagementModel
    {
        public int ID { get; set; }
        public DateTime system_date { get; set; }
        public DateTime system_time { get; set; }
        public int scheme_id { get; set; }
        public string scheme_name { get; set; }
        public string scheme_ids { get; set; }
        public string[] scheme_list { get; set; }
        public string security_name { get; set; }
        public int security_type_id { get; set; }

        public string security_type { get; set; }
        public string other_security_type { get; set; }
        public int toggle_id { get; set; }
        public string toggle { get; set; }
        public decimal? amount { get; set; }
        public decimal? price_yield { get; set; }
        public int price_yield_id { get; set; }
        public string created_by { get; set; }
        public bool IsActive { get; set; }

    }
    public class ExportParaModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }

    public class ExportParaModel24
    {
        public DateTime DownloadFromDate { get; set; }
        public DateTime DownloadToDate { get; set; }
        public string FileTypeId { get; set; }
        public string FileName { get; set; }

    }
    public class ExportParaModel2
    {
        public string GridHtml { get; set; }
    }
    public class UserDetailsModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public bool FullAccess { get; set; }
    }
    public class RecordException
    {
        public int ROW_NUMBER { get; set; }
        public string ACTIVITY_NUMBER { get; set; }
        public string ACTIVITY_NAME { get; set; }
        public string FILE_NAME { get; set; }
        public string ERR_MSG { get; set; }
    }
    public class EmailModel
    {
        public string attached_file_location { get; set; }
        public string attached_file { get; set; }
        public List<string> to_emailids { get; set; }
        public List<string> cc_emailids { get; set; }
        public List<string> attached_files { get; set; }
        public string file_name { get; set; }
        public string email_subject { get; set; }

    }

    public class MenusModel
    {
        public int SeqID { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string css_class { get; set; }
        public int is_active { get; set; }
    }
    public class DDLModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class DDLModel2
    {
        public int emp_code { get; set; }
        public string EmpName { get; set; }
    }
    public class UserModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string role_Name { get; set; }
        public int role_id { get; set; }
        public bool isactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }


    }
    public class RoleModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }

    }
    public class ReportAccessModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool is_send_mail_allowed { get; set; }
        public bool is_download_excel_allowed { get; set; }
    }
    public class MenuRoleMappingModel
    {
        public int ID { get; set; }
        public int role_id { get; set; }
        public string role_name { get; set; }
        public string menu_name { get; set; }
        public int menu_id { get; set; }
        public bool is_active { get; set; }
        public DateTime created_date { get; set; }
        public int created_by { get; set; }
    }

    public class MenuModel
    {
        public int ID { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public bool select_status { get; set; }
        public string css_class { get; set; }
        public int menu_order { get; set; }
        public bool is_active { get; set; }
        public DateTime created_date { get; set; }
    }
    /*  kapil Code start comment on 03-03-2021*/
    public class LovCategoryModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isactive { get; set; }
        public DateTime created_date { get; set; }
    }

    public class LovModel
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public string Category_Code { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Isactive { get; set; }
        public DateTime Created_date { get; set; }

    }
    /* kapil Code End 03-03-2021*/
}

