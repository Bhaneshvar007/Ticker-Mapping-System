using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Cylsys.Common
{
    public class QueryHandlerBase
    {

        static List<RecordException> RECORDED_ERR_LIST = new List<RecordException>();
        public static List<MenuRoleMappingModel> GetAssignedMenuToRole(DataTable DT)
        {
            List<MenuRoleMappingModel> REM_LIST2 = new List<MenuRoleMappingModel>();


            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;
                MenuRoleMappingModel REM = new MenuRoleMappingModel();
                try
                {
                    REM.ID = string.IsNullOrWhiteSpace(drow["id"].ToString()) ? 0 : Convert.ToInt32(drow["id"].ToString());
                    REM.menu_id = string.IsNullOrWhiteSpace(drow["menuid"].ToString()) ? 0 : Convert.ToInt32(drow["menuid"]);
                    REM.role_id = string.IsNullOrWhiteSpace(drow["roleid"].ToString()) ? 0 : Convert.ToInt32(drow["roleid"]);
                    REM.is_active = string.IsNullOrWhiteSpace(drow["isactive"].ToString()) ? false : Convert.ToBoolean(drow["isactive"].ToString());
                    REM_LIST2.Add(REM);
                }
                catch (Exception ex)
                {
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return REM_LIST2;
        }

        /* Kapil Code Start*/
        public static List<LovCategoryModel> GetLovCategoryGridList(DataTable DT)
        {
            List<LovCategoryModel> REM_LIST2 = new List<LovCategoryModel>();
            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;
                LovCategoryModel REM = new LovCategoryModel();
                try
                {
                    REM.ID = string.IsNullOrWhiteSpace(drow["id"].ToString()) ? 0 : Convert.ToInt32(drow["id"].ToString());
                    REM.Code = string.IsNullOrWhiteSpace(drow["code"].ToString()) ? "" : drow["code"].ToString();
                    REM.Name = string.IsNullOrWhiteSpace(drow["name"].ToString()) ? "" : drow["name"].ToString();
                    REM.isactive = string.IsNullOrWhiteSpace(drow["is_active"].ToString()) ? false : Convert.ToBoolean(drow["is_active"]);
                    REM_LIST2.Add(REM);
                }
                catch (Exception ex)
                {
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return REM_LIST2;
        }

        public static List<LovModel> GetLovGridList(DataTable DT)
        {
            List<LovModel> REM_LIST2 = new List<LovModel>();
            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;
                LovModel REM = new LovModel();
                // try
                {
                    REM.ID = string.IsNullOrWhiteSpace(drow["id"].ToString()) ? 0 : Convert.ToInt32(drow["id"].ToString());
                    REM.CategoryId = string.IsNullOrWhiteSpace(drow["Category_Id"].ToString()) ? 0 : Convert.ToInt32(drow["Category_Id"].ToString());
                    REM.Code = string.IsNullOrWhiteSpace(drow["code"].ToString()) ? "" : drow["code"].ToString();
                    REM.Name = string.IsNullOrWhiteSpace(drow["name"].ToString()) ? "" : drow["name"].ToString();
                    REM.Isactive = string.IsNullOrWhiteSpace(drow["is_active"].ToString()) ? false : Convert.ToBoolean(drow["is_active"]);
                    REM_LIST2.Add(REM);
                }
                //catch (Exception ex)
                //{
                //    if (RecordCount < 1)
                //    {
                //        RecordException RException = new RecordException();
                //        RException.FILE_NAME = null;
                //        RException.ERR_MSG = ex.Message;
                //        RECORDED_ERR_LIST.Add(RException);
                //    }
                //}

            }
            return REM_LIST2;
        }

        public static List<MenuModel> GetMenuRoleGridList(DataTable DT)
        {
            List<MenuModel> REM_LIST2 = new List<MenuModel>();


            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;
                MenuModel REM = new MenuModel();
                try
                {
                    REM.ID = string.IsNullOrWhiteSpace(drow["id"].ToString()) ? 0 : Convert.ToInt32(drow["id"].ToString());
                    REM.title = string.IsNullOrWhiteSpace(drow["title"].ToString()) ? "" : drow["title"].ToString();
                    REM.is_active = string.IsNullOrWhiteSpace(drow["isactive"].ToString()) ? false : Convert.ToBoolean(drow["isactive"].ToString());
                    REM_LIST2.Add(REM);
                }
                catch (Exception ex)
                {
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return REM_LIST2;
        }
        public static List<OrderManagementModel> GetOrderManagementGridList(DataTable DT)
        {
            List<OrderManagementModel> REM_LIST2 = new List<OrderManagementModel>();


            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;
                OrderManagementModel REM = new OrderManagementModel();
                try
                {
                    REM.ID = string.IsNullOrWhiteSpace(drow["id"].ToString()) ? 0 : Convert.ToInt32(drow["id"].ToString());
                    REM.system_date = string.IsNullOrWhiteSpace(drow["system_date"].ToString()) ? Convert.ToDateTime(DateTime.Now.ToString("1900-01-01")) : Convert.ToDateTime(drow["system_date"]);
                    REM.system_time = string.IsNullOrWhiteSpace(drow["system_time"].ToString()) ? Convert.ToDateTime(DateTime.Now.ToString("1900-01-01")) : Convert.ToDateTime(drow["system_time"]);
                    REM.scheme_ids = string.IsNullOrWhiteSpace(drow["scheme_ids"].ToString()) ? "" : drow["scheme_ids"].ToString();
                    REM.scheme_name = string.IsNullOrWhiteSpace(drow["scheme_name"].ToString()) ? "" : drow["scheme_name"].ToString();
                    REM.security_name = string.IsNullOrWhiteSpace(drow["security_name"].ToString()) ? "" : drow["security_name"].ToString();
                    REM.security_type_id = string.IsNullOrWhiteSpace(drow["security_type_id"].ToString()) ? 0 : Convert.ToInt32(drow["security_type_id"]);
                    REM.other_security_type = string.IsNullOrWhiteSpace(drow["other_security_type"].ToString()) ? "" : drow["other_security_type"].ToString();
                    REM.security_type = string.IsNullOrWhiteSpace(drow["security_type"].ToString()) ? "" : drow["security_type"].ToString();
                    REM.toggle_id = string.IsNullOrWhiteSpace(drow["toggle_id"].ToString()) ? 0 : Convert.ToInt32(drow["toggle_id"]);
                    REM.toggle = string.IsNullOrWhiteSpace(drow["toggle"].ToString()) ? "" : drow["toggle"].ToString();
                    REM.amount = string.IsNullOrWhiteSpace(drow["amount"].ToString()) ? 0 : Convert.ToDecimal(drow["amount"]);
                    REM.price_yield_id = string.IsNullOrWhiteSpace(drow["price_yield_id"].ToString()) ? 0 : Convert.ToInt32(drow["price_yield_id"]);
                    REM.price_yield = string.IsNullOrWhiteSpace(drow["price_yield"].ToString()) ? 0 : Convert.ToDecimal(drow["price_yield"]);
                    REM.created_by = string.IsNullOrWhiteSpace(drow["username"].ToString()) ? "" : drow["username"].ToString();
                    REM.IsActive = string.IsNullOrWhiteSpace(drow["isactive"].ToString()) ? false : Convert.ToBoolean(drow["isactive"]);

                    REM_LIST2.Add(REM);
                }
                catch (Exception ex)
                {
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return REM_LIST2;
        }
        /* Kapil Code End*/

        public static List<RoleModel> GetRoleGridList(DataTable DT)
        {
            List<RoleModel> REM_LIST2 = new List<RoleModel>();


            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;
                RoleModel REM = new RoleModel();
                try
                {
                    REM.ID = string.IsNullOrWhiteSpace(drow["ID"].ToString()) ? 0 : Convert.ToInt32(drow["ID"].ToString());
                    REM.Code = string.IsNullOrWhiteSpace(drow["Code"].ToString()) ? "" : drow["Code"].ToString();
                    REM.Name = string.IsNullOrWhiteSpace(drow["Name"].ToString()) ? "" : drow["Name"].ToString();
                    REM.Created_By = string.IsNullOrWhiteSpace(drow["Created_By"].ToString()) ? "" : drow["Created_By"].ToString();
                    REM.Created_Date = (DateTime)(drow["Created_Date"] != DBNull.Value
                                                       ? Convert.ToDateTime(drow["Created_Date"])
                                                       : (DateTime?)null);
                    REM.IsActive = string.IsNullOrWhiteSpace(drow["IsActive"].ToString()) ? false : Convert.ToBoolean(drow["IsActive"]);

                    REM_LIST2.Add(REM);
                }
                catch (Exception ex)
                {
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return REM_LIST2;
        }
        public static List<SchemeModel> GetSchemeGridList(DataTable DT)
        {
            List<SchemeModel> REM_LIST2 = new List<SchemeModel>();


            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;
                SchemeModel REM = new SchemeModel();
                try
                {
                    REM.ID = string.IsNullOrWhiteSpace(drow["id"].ToString()) ? 0 : Convert.ToInt32(drow["id"].ToString());
                    REM.Code = string.IsNullOrWhiteSpace(drow["code"].ToString()) ? "" : drow["code"].ToString();
                    REM.Name = string.IsNullOrWhiteSpace(drow["name"].ToString()) ? "" : drow["name"].ToString();
                    REM.IsActive = string.IsNullOrWhiteSpace(drow["isactive"].ToString()) ? false : Convert.ToBoolean(drow["isactive"]);

                    REM_LIST2.Add(REM);
                }
                catch (Exception ex)
                {
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return REM_LIST2;
        }

        public static UserDetailsModel GetUserDetails(DataTable DT)
        {
            UserDetailsModel bll = new UserDetailsModel();


            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;

                try
                {
                    bll.Code = string.IsNullOrWhiteSpace(drow["Code"].ToString()) ? "" : drow["Code"].ToString();
                    bll.Name = string.IsNullOrWhiteSpace(drow["Name"].ToString()) ? "" : drow["Name"].ToString();
                    bll.Email = string.IsNullOrWhiteSpace(drow["Email"].ToString()) ? "" : drow["Email"].ToString();
                    bll.FullAccess = string.IsNullOrWhiteSpace(drow["fullaccess"].ToString()) ? false : Convert.ToBoolean(drow["fullaccess"]);
                }
                catch (Exception ex)
                {
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return bll;

        }


        public static FileMasterModel GetFilesDetails(DataTable DT)
        {
            FileMasterModel bll = new FileMasterModel();


            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;

                try
                {
                    bll.Id = string.IsNullOrWhiteSpace(drow["id"].ToString()) ? 0 : Convert.ToInt32(drow["id"].ToString());
                    bll.FileName = string.IsNullOrWhiteSpace(drow["filename"].ToString()) ? "" : drow["filename"].ToString();
                    bll.UplodedBy = string.IsNullOrWhiteSpace(drow["uploadby"].ToString()) ? "" : drow["uploadby"].ToString();
                    bll.TotalRecord = string.IsNullOrWhiteSpace(drow["totalrec"].ToString()) ? 0 : Convert.ToInt32(drow["totalrec"].ToString());
                    bll.UplodedDate = string.IsNullOrWhiteSpace(drow["uploaded_date"].ToString()) ? Convert.ToDateTime(drow["uploaded_date"]) : Convert.ToDateTime(drow["uploaded_date"]);

                }
                catch (Exception ex)
                {
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return bll;

        }



        public static List<ClientMoodel> GetUserGridList(DataTable DT)
        {
            List<ClientMoodel> REM_LIST2 = new List<ClientMoodel>();

            int ind = 0;
            int RecordCount = 0;
            foreach (DataRow drow in DT.Rows)
            {
                RecordCount++;
                ClientMoodel REM = new ClientMoodel();
                try
                {
                    //REM.Client_ID = string.IsNullOrWhiteSpace(drow["Client_ID"].ToString()) ? 0 : Convert.ToInt32(drow["Client_ID"].ToString());
                    REM.Client_ID = ++ind;
                    REM.Quantity = string.IsNullOrWhiteSpace(drow["Quantity"].ToString()) ? 0 : Convert.ToInt32(drow["Quantity"].ToString());
                    REM.ClientName = string.IsNullOrWhiteSpace(drow["ClientName"].ToString()) ? "" : drow["ClientName"].ToString();
                    REM.AccountNo = string.IsNullOrWhiteSpace(drow["AccountNo"].ToString()) ? "" : drow["AccountNo"].ToString();
                    REM.Broker = string.IsNullOrWhiteSpace(drow["Broker"].ToString()) ? "" : drow["Broker"].ToString();
                    REM.Security = string.IsNullOrWhiteSpace(drow["security"].ToString()) ? "" : drow["security"].ToString();

                    REM.Created_Date = string.IsNullOrWhiteSpace(drow["Created_Date"].ToString()) ? Convert.ToDateTime(drow["Created_Date"]) : Convert.ToDateTime(drow["Created_Date"]);
                    REM.isactive = string.IsNullOrWhiteSpace(drow["isactive"].ToString()) ? false : Convert.ToBoolean(drow["isactive"]);
                    REM_LIST2.Add(REM);
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("get Client " + ex.Message);
                    if (RecordCount < 1)
                    {
                        RecordException RException = new RecordException();
                        RException.FILE_NAME = null;
                        RException.ERR_MSG = ex.Message;
                        RECORDED_ERR_LIST.Add(RException);
                    }
                }

            }
            return REM_LIST2;
        }




        // abhay new 0409025
        public static List<SecurityModel> GetSecurityGridList(DataTable DT)
        {
            int ind = 0;
            List<SecurityModel> list = new List<SecurityModel>();
            foreach (DataRow row in DT.Rows)
            {
                var model = new SecurityModel
                {
                    //Security_ID = Convert.ToInt32(row["Security_ID"]),
                    Security_ID = ++ind,
                    Parent_Ticker = row["Parent_Ticker"] != DBNull.Value ? row["Parent_Ticker"].ToString() : null,
                    NSE_CODE = row["NSE_CODE"] != DBNull.Value ? row["NSE_CODE"].ToString() : null,
                    NSE_Ticker = row["NSE_Ticker"] != DBNull.Value ? row["NSE_Ticker"].ToString() : null,
                    BSE_Ticker = row["BSE_Ticker"] != DBNull.Value ? row["BSE_Ticker"].ToString() : null,
                    Common_Ticker = row["Common_Ticker"] != DBNull.Value ? row["Common_Ticker"].ToString() : null,
                    CurrentMonth = row["CurrentMonth"] != DBNull.Value ? row["CurrentMonth"].ToString() : null,
                    CurrentMonth_BBG = row["CurrentMonth_BBG"] != DBNull.Value ? row["CurrentMonth_BBG"].ToString() : null,
                    NextMonth = row["NextMonth"] != DBNull.Value ? row["NextMonth"].ToString() : null,
                    NextMonth_BBG = row["NextMonth_BBG"] != DBNull.Value ? row["NextMonth_BBG"].ToString() : null,
                    FarMonth = row["FarMonth"] != DBNull.Value ? row["FarMonth"].ToString() : null,
                    FarMonth_BBG = row["FarMonth_BBG"] != DBNull.Value ? row["FarMonth_BBG"].ToString() : null,
                    Created_By = row["Created_By"] != DBNull.Value ? row["Created_By"].ToString() : null
                };


                if (row["CurrentMonth_LotSize"] != DBNull.Value)
                    model.CurrentMonth_LotSize = Convert.ToDecimal(row["CurrentMonth_LotSize"]);
                else
                    model.CurrentMonth_LotSize = null;

                if (row["NextMonth_LotSize"] != DBNull.Value)
                    model.NextMonth_LotSize = Convert.ToDecimal(row["NextMonth_LotSize"]);
                else
                    model.NextMonth_LotSize = null;

                if (row["FarMonth_LotSize"] != DBNull.Value)
                    model.FarMonth_LotSize = Convert.ToDecimal(row["FarMonth_LotSize"]);
                else
                    model.FarMonth_LotSize = null;

                if (row["Created_Date"] != DBNull.Value)
                    model.Created_Date = Convert.ToDateTime(row["Created_Date"]);
                else
                    model.Created_Date = null;

                if (row["IsActive"] != DBNull.Value)
                    model.IsActive = Convert.ToBoolean(row["IsActive"]);
                else
                    model.IsActive = null;

                if (row["Updated_Date"] != DBNull.Value)
                    model.Updated_Date = Convert.ToDateTime(row["Updated_Date"]);
                else
                    model.Updated_Date = null;

                list.Add(model);
            }

            return list;
        }


        // abhay 1-09-2025
        public static List<TradeConfirmation> GetConfirmationbrokerGridList(DataTable dt)
        {
            int ind = 0;
            var list = new List<TradeConfirmation>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TradeConfirmation
                {
                    //Id = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
                    Id = ++ind,
                    Account = row["Account"] != DBNull.Value ? row["Account"].ToString().Trim() : "",
                    Security = row["Security"] != DBNull.Value ? row["Security"].ToString().Trim() : "",
                    Price = row["Price"] != DBNull.Value ? row["Price"].ToString().Trim() : "",
                    Side = row["Side"] != DBNull.Value ? row["Side"].ToString().Trim() : "",
                    Quantity = row["Quantity"] != DBNull.Value ? row["Quantity"].ToString().Trim() : "",
                    Broker = row["Broker"] != DBNull.Value ? row["Broker"].ToString().Trim() : "",
                    Reason = row["Reason"] != DBNull.Value ? row["Reason"].ToString().Trim() : "",
                    LongNote1 = row["LongNote1"] != DBNull.Value ? row["LongNote1"].ToString().Trim() : "",
                    CreatedDate = row["CreatedDate"] != DBNull.Value
                        ? Convert.ToDateTime(row["CreatedDate"])
                        : (DateTime?)null



                });
            }
            Helper.WriteLog("Broker Data Count " + list.Count);
            return list;
        }



        public static List<TickerMappingModel> GetTickerMappingDatas(DataTable dt)
        {
            var list = new List<TickerMappingModel>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TickerMappingModel
                {
                    TickerId = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
                    Broker = row["Broker"] != DBNull.Value ? row["Broker"].ToString().Trim() : "",
                    Account = row["Account"] != DBNull.Value ? row["Account"].ToString().Trim() : "",
                    Security = row["Security"] != DBNull.Value ? row["Security"].ToString().Trim() : "",
                    Common_ParentTicker = row["Common_ParentTicker"] != DBNull.Value ? row["Common_ParentTicker"].ToString().Trim() : "",
                    Side = row["Side"] != DBNull.Value ? row["Side"].ToString().Trim() : "",
                    Quantity = row["Quantity"] != DBNull.Value ? Convert.ToInt32(row["Quantity"]) : 0,
                    Price = row["Price"] != DBNull.Value ? row["Price"].ToString().Trim() : "",
                    DVD = row["DVD_Trade"] != DBNull.Value ? row["DVD_Trade"].ToString().Trim() : "",
                    TotalPrice = row["TotalPrice"] != DBNull.Value ? row["TotalPrice"].ToString().Trim() : "",
                    QuantityMatching = row["QuantityMatching"] != DBNull.Value ? row["QuantityMatching"].ToString().Trim() : "",
                    HoldingsCheck = row["HoldingsCheck"] != DBNull.Value ? row["HoldingsCheck"].ToString().Trim() : "",
                    ProcessDate = row["ProcessDate"] != DBNull.Value
                                    ? Convert.ToDateTime(row["ProcessDate"])
                                    : (DateTime?)null,
                    TransactionType = row["TransactionType"] != DBNull.Value ? row["TransactionType"].ToString().Trim() : "",
                    BrokerLongNote = row["BrokerLongNote"] != DBNull.Value ? row["BrokerLongNote"].ToString().Trim() : "",
                    TickerLongNote = row["TickerLongNote"] != DBNull.Value ? row["TickerLongNote"].ToString().Trim() : "",
                    WeightedSpread = row["WeightedSpread"] != DBNull.Value ? row["WeightedSpread"].ToString().Trim() : "",
                    Spread = row["Spread"] != DBNull.Value ? row["Spread"].ToString().Trim() : "",
                    Comment = row["Comment"] != DBNull.Value ? row["Comment"].ToString().Trim() : "",
                    ConvertedSide = row["ConvertedSide"] != DBNull.Value ? row["ConvertedSide"].ToString().Trim() : "",

                });
            }
            return list;
        }


        public static List<UserPageAccessLogsModel> GetUserPageAccessLogs(DataTable dt)
        {
            var list = new List<UserPageAccessLogsModel>();

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new UserPageAccessLogsModel
                    {
                        ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                        UserName = row["Username"] != DBNull.Value ? row["Username"].ToString().Trim() : "",
                        EmailID = row["EmailID"] != DBNull.Value ? row["EmailID"].ToString().Trim() : "",
                        AccessTime = row["AccessTime"] != DBNull.Value ? row["AccessTime"].ToString().Trim() : "",
                        PageName = row["PageName"] != DBNull.Value ? row["PageName"].ToString().Trim() : "",
                        LoginTime = row["LoginTime"] != DBNull.Value ? row["LoginTime"].ToString().Trim() : "",
                        SessionId = row["SessionID"] != DBNull.Value ? row["SessionID"].ToString().Trim() : "",
                        IpAddress = row["IpAddress"] != DBNull.Value ? row["IpAddress"].ToString().Trim() : "",
                        total_records = row["total_records"] != DBNull.Value ? Convert.ToInt32(row["total_records"]) : 0
                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("Get pageaces error " + ex + "DT" + dt);
            }

            return list;
        }

        public static List<UserModel> GetUsersData(DataTable dt)
        {
            var list = new List<UserModel>();

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new UserModel
                    {
                        ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                        Code = row["Code"] != DBNull.Value ? row["Code"].ToString().Trim() : "",
                        Name = row["Name"] != DBNull.Value ? row["Name"].ToString().Trim() : "",
                        Email = row["Email"] != DBNull.Value ? row["Email"].ToString().Trim() : "",
                        Password = row["Password"] != DBNull.Value ? row["Password"].ToString().Trim() : "",
                        role_id = row["RoleID"] != DBNull.Value ? Convert.ToInt32(row["RoleID"]) : 0,
                        role_Name = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString().Trim() : "",
                        CreatedDate = (DateTime)(row["Created_Date"] != DBNull.Value
                                    ? Convert.ToDateTime(row["Created_Date"])
                                    : (DateTime?)null),
                        UpdatedBy = row["Modify_By"] != DBNull.Value ? row["Modify_By"].ToString().Trim() : "",
                        UpdatedDate = row["Modify_Date"] != DBNull.Value
                                        ? Convert.ToDateTime(row["Modify_Date"]).ToString("yyyy-MM-dd")
                                        : ""


                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("Get User error " + ex + "DT" + dt);
            }
            Helper.WriteLog("User Data count " + list.Count);
            return list;
        }


        public static List<TickerMappingModel> GetDailyMatchedSummryReportData(DataTable dt)
        {

            var list = new List<TickerMappingModel>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new TickerMappingModel
                    {
                        TickerId = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
                        Broker = row["Broker"] != DBNull.Value ? row["Broker"].ToString().Trim() : "",
                        Account = row["Account"] != DBNull.Value ? row["Account"].ToString().Trim() : "",
                        Security = row["Security"] != DBNull.Value ? row["Security"].ToString().Trim() : "",
                        Common_ParentTicker = row["Common_ParentTicker"] != DBNull.Value ? row["Common_ParentTicker"].ToString().Trim() : "",
                        Side = row["Side"] != DBNull.Value ? row["Side"].ToString().Trim() : "",
                        Quantity = row["Quantity"] != DBNull.Value ? Convert.ToInt32(row["Quantity"]) : 0,
                        Price = row["Price"] != DBNull.Value ? row["Price"].ToString().Trim() : "",
                        DVD = row["DVD_Trade"] != DBNull.Value ? row["DVD_Trade"].ToString().Trim() : "",
                        TotalPrice = row["TotalPrice"] != DBNull.Value ? row["TotalPrice"].ToString().Trim() : "",
                        QuantityMatching = row["QuantityMatching"] != DBNull.Value ? row["QuantityMatching"].ToString().Trim() : "",
                        HoldingsCheck = row["HoldingsCheck"] != DBNull.Value ? row["HoldingsCheck"].ToString().Trim() : "",
                        ProcessDate = row["ProcessDate"] != DBNull.Value
                                    ? Convert.ToDateTime(row["ProcessDate"])
                                    : (DateTime?)null,
                        TransactionType = row["TransactionType"] != DBNull.Value ? row["TransactionType"].ToString().Trim() : "",
                        BrokerLongNote = row["BrokerLongNote"] != DBNull.Value ? row["BrokerLongNote"].ToString().Trim() : "",
                        TickerLongNote = row["TickerLongNote"] != DBNull.Value ? row["TickerLongNote"].ToString().Trim() : "",
                        WeightedSpread = row["WeightedSpread"] != DBNull.Value ? row["WeightedSpread"].ToString().Trim() : "",
                        Spread = row["Spread"] != DBNull.Value ? row["Spread"].ToString().Trim() : "",
                        Comment = row["Comment"] != DBNull.Value ? row["Comment"].ToString().Trim() : "",
                        ConvertedSide = row["ConvertedSide"] != DBNull.Value ? row["ConvertedSide"].ToString().Trim() : "",

                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("DailyMatchedSummryReport " + ex.Message);
            }
            return list;
        }



        //public static List<TickerMappingModel> GetBrokerwiseMatchingReportData(DataTable dt)
        //{
        //    var list = new List<TickerMappingModel>();
        //    try
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            list.Add(new TickerMappingModel
        //            {
        //                TickerId = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
        //                Broker = row["Broker"] != DBNull.Value ? row["Broker"].ToString().Trim() : "",
        //                Account = row["Account"] != DBNull.Value ? row["Account"].ToString().Trim() : "",
        //                Security = row["Security"] != DBNull.Value ? row["Security"].ToString().Trim() : "",
        //                Common_ParentTicker = row["Common_ParentTicker"] != DBNull.Value ? row["Common_ParentTicker"].ToString().Trim() : "",
        //                //ParentTicker = row["ParentTicker"] != DBNull.Value ? row["ParentTicker"].ToString().Trim() : "",
        //                Side = row["Side"] != DBNull.Value ? row["Side"].ToString().Trim() : "",
        //                Quantity = row["Quantity"] != DBNull.Value ? Convert.ToInt32(row["Quantity"]) : 0,
        //                Price = row["Price"] != DBNull.Value ? row["Price"].ToString().Trim() : "",
        //                //TotalPrice = row["TotalPrice"] != DBNull.Value ? row["TotalPrice"].ToString().Trim() : "",
        //                QuantityMatching = row["QuantityMatching"] != DBNull.Value ? row["QuantityMatching"].ToString().Trim() : "",
        //                HoldingsCheck = row["HoldingsCheck"] != DBNull.Value ? row["HoldingsCheck"].ToString().Trim() : "",
        //                //Comment = row["Comment"] != DBNull.Value ? row["Comment"].ToString().Trim() : "",
        //                //Instrument_Type = row["Instrument_Type"] != DBNull.Value ? row["Instrument_Type"].ToString().Trim() : "",
        //                ProcessDate = row["ProcessDate"] != DBNull.Value
        //                            ? Convert.ToDateTime(row["ProcessDate"])
        //                            : (DateTime?)null,
        //                TickerLongNote = row["TickerLongNote"] != DBNull.Value ? row["TickerLongNote"].ToString().Trim() : "",
        //                TransactionType = row["TransactionType"] != DBNull.Value ? row["TransactionType"].ToString().Trim() : "",
        //                BrokerLongNote = row["BrokerLongNote"] != DBNull.Value ? row["BrokerLongNote"].ToString().Trim() : "",
        //                Spread = row["Spread"] != DBNull.Value ? row["Spread"].ToString().Trim() : ""

        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.WriteLog("DailyMatchedSummryReport " + ex.Message);
        //    }
        //    return list;
        //}

        public static List<BrokerAccountLevelMatchingModel> GetBrokerwiseMatchingReportData(DataTable dt)
        {
            var list = new List<BrokerAccountLevelMatchingModel>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new BrokerAccountLevelMatchingModel
                    {
                        Broker = row["Broker"] != DBNull.Value ? row["Broker"].ToString().Trim() : "",
                        Account = row["Account"] != DBNull.Value ? row["Account"].ToString().Trim() : "",
                        CashTradeValue = row["CashTradeValue"] != DBNull.Value ? row["CashTradeValue"].ToString().Trim() : "",
                        FutureTradeValue = row["FutureTradeValue"] != DBNull.Value ? row["FutureTradeValue"].ToString().Trim() : "",
                        NetTradeValue = row["NetTradeValue"] != DBNull.Value ? row["NetTradeValue"].ToString().Trim() : "",
                        QuantityStatus = row["QuantityStatus"] != DBNull.Value ? row["QuantityStatus"].ToString().Trim() : "",
                        Spread = row["Spread"] != DBNull.Value ? row["Spread"].ToString().Trim() : ""

                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("DailyMatchedSummryReport " + ex.Message);
            }
            return list;
        }


        public static List<TickerMappingModel> GetUnmatchedTradesReportData(DataTable dt)
        {
            var list = new List<TickerMappingModel>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new TickerMappingModel
                    {
                        TickerId = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
                        Broker = row["Broker"] != DBNull.Value ? row["Broker"].ToString().Trim() : "",
                        Account = row["Account"] != DBNull.Value ? row["Account"].ToString().Trim() : "",
                        Security = row["Security"] != DBNull.Value ? row["Security"].ToString().Trim() : "",
                        Common_ParentTicker = row["Common_ParentTicker"] != DBNull.Value ? row["Common_ParentTicker"].ToString().Trim() : "",
                        //ParentTicker = row["ParentTicker"] != DBNull.Value ? row["ParentTicker"].ToString().Trim() : "",
                        Side = row["Side"] != DBNull.Value ? row["Side"].ToString().Trim() : "",
                        Quantity = row["Quantity"] != DBNull.Value ? Convert.ToInt32(row["Quantity"]) : 0,
                        Price = row["Price"] != DBNull.Value ? row["Price"].ToString().Trim() : "",
                        //TotalPrice = row["TotalPrice"] != DBNull.Value ? row["TotalPrice"].ToString().Trim() : "",
                        QuantityMatching = row["QuantityMatching"] != DBNull.Value ? row["QuantityMatching"].ToString().Trim() : "",
                        HoldingsCheck = row["HoldingsCheck"] != DBNull.Value ? row["HoldingsCheck"].ToString().Trim() : "",
                        //Comment = row["Comment"] != DBNull.Value ? row["Comment"].ToString().Trim() : "",
                        //Instrument_Type = row["Instrument_Type"] != DBNull.Value ? row["Instrument_Type"].ToString().Trim() : "",
                        ProcessDate = row["ProcessDate"] != DBNull.Value
                                    ? Convert.ToDateTime(row["ProcessDate"])
                                    : (DateTime?)null,
                        TickerLongNote = row["TickerLongNote"] != DBNull.Value ? row["TickerLongNote"].ToString().Trim() : "",
                        TransactionType = row["TransactionType"] != DBNull.Value ? row["TransactionType"].ToString().Trim() : "",
                        BrokerLongNote = row["BrokerLongNote"] != DBNull.Value ? row["BrokerLongNote"].ToString().Trim() : "",
                        Spread = row["Spread"] != DBNull.Value ? row["Spread"].ToString().Trim() : ""

                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("DailyMatchedSummryReport " + ex.Message);
            }
            return list;
        }


        public static List<TradeWiseReportModel> GetTradewiseMatchingLogReportData(DataTable dt)
        {
            int ind = 1;
            var list = new List<TradeWiseReportModel>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new TradeWiseReportModel
                    {
                        Id = ind++,
                        Broker = row["Broker"] != DBNull.Value ? row["Broker"].ToString().Trim() : "",
                        Account = row["Account"] != DBNull.Value ? row["Account"].ToString().Trim() : "",
                        TransactionType = row["TransactionType"] != DBNull.Value ? row["TransactionType"].ToString().Trim() : "",
                        CashPrice = row["CashTotalPrice"] != DBNull.Value ? row["CashTotalPrice"].ToString().Trim() : "",
                        FuturePrice = row["FutureTotalPrice"] != DBNull.Value ? row["FutureTotalPrice"].ToString().Trim() : "",
                        WeightedSpread = row["WeightedSpread"] != DBNull.Value ? row["WeightedSpread"].ToString().Trim() : ""

                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("DailyMatchedSummryReport " + ex.Message);
            }
            return list;
        }





        public static List<FilterDataModel> GetBrokerFilterData(DataTable dt)
        {
            var list = new List<FilterDataModel>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new FilterDataModel
                    {
                        BrokerName = row["Broker"] != DBNull.Value ? row["Broker"].ToString().Trim() : ""


                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("GetBrokerFilterData" + ex.Message);
            }
            return list;
        }
        public static List<FilterDataModel> GetAccountFilterData(DataTable dt)
        {
            var list = new List<FilterDataModel>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new FilterDataModel
                    {
                        AccountName = row["accountno"] != DBNull.Value ? row["accountno"].ToString().Trim() : "",

                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("GetAccountFilterData" + ex.Message);
            }
            return list;
        }

        public static List<FilterDataModel> GetPageAccessLogFilterData(DataTable dt)
        {
            var list = new List<FilterDataModel>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new FilterDataModel
                    {
                        EmailId = row["EmailID"] != DBNull.Value ? row["EmailID"].ToString().Trim() : "",
                        UserId = row["UserId"] != DBNull.Value ? Convert.ToInt32(row["UserId"]) : 0,

                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("GetAccountFilterData" + ex.Message);
            }
            return list;
        }

        public static List<FileMasterModel> GetFileData(DataTable dt)
        {
            var list = new List<FileMasterModel>();

            int ind = 0;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new FileMasterModel
                    {
                        //Id = row["id"] != DBNull.Value ? Convert.ToInt32(row["id"]) : 0,
                        Id = ++ind,
                        FileName = row["filename"] != DBNull.Value ? row["filename"].ToString().Trim() : "",
                        Email = row["Email"] != DBNull.Value ? row["Email"].ToString().Trim() : "",
                        FileRef = row["file_Ref"] != DBNull.Value ? row["file_Ref"].ToString().Trim() : "",
                        UplodedBy = row["uploadby"] != DBNull.Value ? row["uploadby"].ToString().Trim() : "",
                        TotalRecord = row["totalrec"] != DBNull.Value ? Convert.ToInt32(row["totalrec"]) : 0,
                        UplodedDate = (DateTime)(row["uploaded_date"] != DBNull.Value
                                    ? Convert.ToDateTime(row["uploaded_date"])
                                    : (DateTime?)null)

                    });
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog("GetFileData error " + ex + "DT" + dt);
            }

            return list;
        }




        public static List<EquityHoldingsUploadModel> GetEquityHoldingsUploadDatas(DataTable dt)
        {
            var list = new List<EquityHoldingsUploadModel>();
            int ind = 0;
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new EquityHoldingsUploadModel
                {
                    EquityHoldingsId = ++ind,
                    DisplayName = row["DisplayName"]?.ToString().Trim() ?? "",
                    Issuer = row["Issuer"]?.ToString().Trim() ?? "",
                    Position = row["Position"]?.ToString().Trim() ?? "",
                    Saleable = row["Saleable"]?.ToString().Trim() ?? "",
                    UnderlyingEquivalentPosition = row["UnderlyingEquivalentPosition"]?.ToString().Trim() ?? "",
                    IndustrySector = row["IndustrySector"]?.ToString().Trim() ?? "",
                    Price = row["Price"]?.ToString().Trim() ?? "",
                    PreviousEODPrice = row["PreviousEODPrice"]?.ToString().Trim() ?? "",
                    PreviousDay_Futures = row["PreviousDay_Futures"]?.ToString().Trim() ?? "",
                    CumAvgCost = row["CumAvgCost"]?.ToString().Trim() ?? "",
                    SecurityDescription = row["SecurityDescription"]?.ToString().Trim() ?? "",
                    AssetType = row["AssetType"]?.ToString().Trim() ?? "",
                    GrossExp_NAV = row["GrossExp_NAV"]?.ToString().Trim() ?? "",
                    Industry = row["Industry"]?.ToString().Trim() ?? "",
                    A_Cost_Local = row["A_Cost_Local"]?.ToString().Trim() ?? "",
                    Change = row["Change"]?.ToString().Trim() ?? "",
                    AccruedInterest = row["AccruedInterest"]?.ToString().Trim() ?? "",
                    TotalPL = row["TotalPL"]?.ToString().Trim() ?? "",
                    GrossMV = row["GrossMV"]?.ToString().Trim() ?? "",
                    ISIN = row["ISIN"]?.ToString().Trim() ?? "",
                    ACCRINT = row["ACCRINT"]?.ToString().Trim() ?? "",
                    ParentCompanyName = row["ParentCompanyName"]?.ToString().Trim() ?? "",
                    AccountName = row["AccountName"]?.ToString().Trim() ?? "",
                    Cusip = row["Cusip"]?.ToString().Trim() ?? "",
                    Previous_Day_Perc = row["Previous_Day_Perc"]?.ToString().Trim() ?? "",
                    IsClosed = row["IsClosed"] == DBNull.Value ? "0" : (Convert.ToBoolean(row["IsClosed"]) ? "1" : "0"),
                    CreatedDate = DateTime.TryParse(row["CreatedDate"]?.ToString(), out DateTime created)
              ? created
              : (DateTime?)null,
                });
            }
            return list;
        }

        public static List<FutureHoldingsUploadModel> GetFutureHoldingsUploadDatas(DataTable dt)
        {
            var list = new List<FutureHoldingsUploadModel>();
            int ind = 0;
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new FutureHoldingsUploadModel
                {
                    FutureHoldingsId = ++ind,
                    DisplayName = row["DisplayName"]?.ToString().Trim() ?? "",
                    AccountCode = row["AccountCode"]?.ToString().Trim() ?? "",
                    AccountName = row["AccountName"]?.ToString().Trim() ?? "",
                    Name = row["Name"]?.ToString().Trim() ?? "",
                    SecurityDescription = row["SecurityDescription"]?.ToString().Trim() ?? "",
                    Position = row["Position"]?.ToString().Trim() ?? "",
                    UnderlyingEquivalentPosition = row["UnderlyingEquivalentPosition"]?.ToString().Trim() ?? "",
                    A_MarketValueLocal = row["A_MarketValueLocal"]?.ToString().Trim() ?? "",
                    Price = row["Price"]?.ToString().Trim() ?? "",
                    ExpirationDate = row["ExpirationDate"]?.ToString().Trim() ?? "",
                    Issuer = row["Issuer"]?.ToString().Trim() ?? "",
                    IsClosed = row["IsClosed"] == DBNull.Value ? "0" : (Convert.ToBoolean(row["IsClosed"]) ? "1" : "0"),
                    CreatedDate = DateTime.TryParse(row["CreatedDate"]?.ToString(), out DateTime created)
              ? created
              : (DateTime?)null,
                });
            }
            return list;
        }

        public static List<JoinOpeningHoldingModel> GetJoinOpeningHoldings(DataTable dt)
        {
            var list = new List<JoinOpeningHoldingModel>();
            int ind = 0;

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new JoinOpeningHoldingModel
                {
                    Id = ++ind, // auto increment for grid display
                    EquityDisplayName = row["EquityDisplayName"] != DBNull.Value ? row["EquityDisplayName"].ToString().Trim() : "",
                    FutureDisplayName = row["FutureDisplayName"] != DBNull.Value ? row["FutureDisplayName"].ToString().Trim() : "",
                    AccountCode = row["AccountCode"] != DBNull.Value ? row["AccountCode"].ToString().Trim() : "",
                    AccountName = row["AccountName"] != DBNull.Value ? row["AccountName"].ToString().Trim() : "",
                    Issuer = row["Issuer"] != DBNull.Value ? row["Issuer"].ToString().Trim() : "",
                    EquityPosition = row["EquityPosition"] != DBNull.Value ? row["EquityPosition"].ToString().Trim() : "",
                    Saleable = row["Saleable"] != DBNull.Value ? row["Saleable"].ToString().Trim() : "",

                    FuturePosition_Lots = row["FuturePosition_Lots"] != DBNull.Value ? row["FuturePosition_Lots"].ToString().Trim() : "",
                    FuturePosition = row["FuturePosition"] != DBNull.Value ? row["FuturePosition"].ToString().Trim() : ""
                });
            }

            return list;
        }


    }
}