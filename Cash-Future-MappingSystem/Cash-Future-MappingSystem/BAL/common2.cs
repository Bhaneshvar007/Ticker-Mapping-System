using Cash_Future_MappingSystem.Models;
using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class Common2 : EntityBusinessLogicBase<Common2>
    {
        List<DDLModel> ListModel = new List<DDLModel>();
        

        //public static csvdatatable ConvertCSVtoDataTable(string strFilePath)
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            int rowcount = 0;
            csvdatatable objcsv = new csvdatatable();
            DataTable dt = new DataTable();
            try
            {
                using (StreamReader sr = new StreamReader(strFilePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {

                        // add by abhay
                        string line = sr.ReadLine();
                        string[] rows = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                        //string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            //dr[i] = rows[i];
                            dr[i] = rows[i].Trim('"');
                        }
                        dt.Rows.Add(dr);
                        rowcount++;
                    }

                }
                //objcsv.objdta = dt;
                //return objcsv;
                return dt;
            }
            catch (Exception e)
            {
                Helper.WriteLog(rowcount.ToString());
                objcsv.msg = "Issue in line no. " + rowcount.ToString();
                //return objcsv;
                return dt;
            }
        }



        public string UploadClientData(string path, string fileName, DateTime Rsdate)
        {
            Helper.WriteLog("ClientMaster File Path : " + path);
            bool IsUploaded = false;
            string msg = null;
            string delimiter = "\t";
            int startIndex = 0;
            string[] columns = null;
            DataTable schm_chk = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(path);
            bool isactive = true;
            // Helper.WriteLog("Read Files");
            // DataTable tbl = Get_File_Data(path, delimiter, 0);
            DataTable tbl = ConvertCSVtoDataTable(path);


            DataTable final_dt = tbl.Clone();



            ResponseDataModel res = new ResponseDataModel();
            // res.BatchClose = Convert.ToDateTime(Helper.ToDateFormat(tbl.Rows[0]["value_date"].ToString()));
            //res.BatchClose = Helper.DateFormat3(tbl.Rows[0]["value_date"].ToString());

            res.TRT = "N";

            try
            {
                foreach (DataColumn col in tbl.Columns)
                {
                    col.ColumnName = col.ColumnName.Trim().ToLower();
                    Helper.WriteLog(col.ColumnName);
                }


            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message);
            }
            try
            {
                Helper.WriteLog("Client Tbl " + tbl.Rows.Count);
                if (tbl.Rows.Count > 0)
                {
                    string consString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        con.Open();
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.ClientMasterTemp";

                            try
                            {
                                //sqlBulkCopy.ColumnMappings.Add("clientname", "clientname");
                                sqlBulkCopy.ColumnMappings.Add("accountno", "accountno");

                                sqlBulkCopy.ColumnMappings.Add("quantity", "quantity");
                                //sqlBulkCopy.ColumnMappings.Add("broker", "broker");
                                sqlBulkCopy.ColumnMappings.Add("security", "Security");




                                sqlBulkCopy.BulkCopyTimeout = 10000;
                                sqlBulkCopy.BatchSize = 5000;
                                sqlBulkCopy.WriteToServer(tbl);
                                Helper.WriteLog("Client Data Uploded Successfully");
                                msg = "Data Uploded Successfully";
                                IsUploaded = true;
                            }
                            catch (Exception EX)
                            {
                                Helper.WriteLog(EX + "");
                                DataAccess.ExecuteQuery("TRUNCATE table ClientMasterTemp");
                                msg = "Data not Uploaded,because Column data mismatch..!";
                            }

                            con.Close();
                        }
                    }
                    if (IsUploaded)
                    {
                        SqlParameter[] Params = { new SqlParameter("@para", "null") };
                        DataTable DT = DataAccess.ExecuteProcedure("sp_ClientDataManager", null);

                        DbCommonHelper dbcom = new DbCommonHelper();

                        if (DT.Rows.Count > 0)
                        {
                            string resultMsg = DT.Rows[0]["Message"].ToString();

                            if (resultMsg == "Data inserted successfully")
                            {
                                SqlParameter[] Param =
                                {
                                    new SqlParameter("@filename", fileName),
                                    new SqlParameter("@uplodedBy", Convert.ToInt32(UserManager.User.Code)),
                                    new SqlParameter("@totalRec", Convert.ToInt32(tbl.Rows.Count)),
                                    new SqlParameter("@file_Ref", "Client"),
                                };

                                msg = dbcom.Save("sp_FileMaster", Param);

                                msg = "Data Upload Successfully.";

                                //System.Threading.Thread.Sleep(120000);
                                Helper.WriteLog("Data Upload Successfully. " + fileName);
                            }
                            else
                            {
                                msg = "File Already Uploaded: " + fileName;
                                Helper.WriteLog("File Already Uploaded: " + fileName);
                            }
                        }

                    }
                    else
                    {
                        msg = "Data not Uploaded,because Column data mismatch..!";
                    }
                }
                else
                {
                    msg = "File doesn't have data..!";
                }

                return msg;
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.StackTrace);
                msg = "Data not Uploaded Column data mismatch..!";
                return msg;
            }
        }
        
      

        public string UploadSecurtyData(string path, string fileName)

        {
            bool IsUploaded = false;
            string msg = "successfuly upload ";
            string delimiter = "\t";
            int startIndex = 0;
            string[] columns = null;
            DataTable schm_chk = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(path);

            DataTable tbl = ConvertCSVtoDataTable(path);

            System.Data.DataColumn newColumnfile = new System.Data.DataColumn("file_name_mast", typeof(System.String));

            newColumnfile.DefaultValue = fileName.ToString();

            tbl.Columns.Add(newColumnfile);

            DataTable final_dt = tbl.Clone();


            ResponseDataModel res = new ResponseDataModel();


            res.TRT = "N";

            try

            {
                foreach (DataColumn col in tbl.Columns)

                {
                    col.ColumnName = col.ColumnName.Trim().ToLower();

                }

                var lotSizeCols = tbl.Columns.Cast<DataColumn>()
                    .Where(c => c.ColumnName.ToLower().Contains("lotsize")).ToList();


                foreach (DataColumn col in lotSizeCols)
                {
                    // Naya decimal column banayein temporary name ke saath
                    DataColumn tempCol = new DataColumn(col.ColumnName + "_temp", typeof(decimal));
                    tbl.Columns.Add(tempCol);

                    //  row ka data convert karo
                    foreach (DataRow row in tbl.Rows)
                    {
                        string val = row[col].ToString().Trim().Replace(",", "");
                        if (decimal.TryParse(val, out decimal decVal))
                        {
                            row[tempCol] = decVal;
                        }
                        else
                        {
                            row[tempCol] = DBNull.Value;
                        }
                    }

                    // old column remove aur temp column ko original name do
                    int pos = col.Ordinal;
                    tbl.Columns.Remove(col);
                    tempCol.ColumnName = col.ColumnName;
                    tempCol.SetOrdinal(pos);
                }


            }

            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message);
            }

            try

            {
                //  Helper.WriteLog("tbl add");

                if (tbl.Rows.Count > 0)

                {
                    string consString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(consString))

                    {
                        con.Open();

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))

                        {


                            sqlBulkCopy.DestinationTableName = "tbl_SecurityMasterTemp";

                            try

                            {
                                sqlBulkCopy.ColumnMappings.Add("Parent Ticker", "Parent_Ticker");
                                sqlBulkCopy.ColumnMappings.Add("NSE CODE", "NSE_CODE");
                                sqlBulkCopy.ColumnMappings.Add("NSE Ticker", "NSE_Ticker");
                                sqlBulkCopy.ColumnMappings.Add("BSE Ticker", "BSE_Ticker");
                                sqlBulkCopy.ColumnMappings.Add("Common Ticker", "Common_Ticker");

                                sqlBulkCopy.ColumnMappings.Add("CurrentMonth", "CurrentMonth");
                                sqlBulkCopy.ColumnMappings.Add("CurrentMonth_BBG", "CurrentMonth_BBG");
                                sqlBulkCopy.ColumnMappings.Add("CurrentMonth_lotSize", "CurrentMonth_LotSize");

                                sqlBulkCopy.ColumnMappings.Add("NextMonth", "NextMonth");
                                sqlBulkCopy.ColumnMappings.Add("NextMonth_BBG", "NextMonth_BBG");
                                sqlBulkCopy.ColumnMappings.Add("NextMonth_lotSize", "NextMonth_LotSize");

                                sqlBulkCopy.ColumnMappings.Add("FarMonth", "FarMonth");
                                sqlBulkCopy.ColumnMappings.Add("FarMonth_BBG", "FarMonth_BBG");
                                sqlBulkCopy.ColumnMappings.Add("FarMonth_lotSize", "FarMonth_LotSize");

                                sqlBulkCopy.BulkCopyTimeout = 10000;

                                sqlBulkCopy.BatchSize = 5000;

                                sqlBulkCopy.WriteToServer(tbl);

                                IsUploaded = true;



                            }

                            catch (Exception EX)

                            {
                                Helper.WriteLog(EX.Message);
                                DataAccess.ExecuteQuery("TRUNCATE table tbl_SecurityMasterTemp");
                                msg = "Data not Uploaded,because " + EX.Message;

                            }

                            con.Close();

                        }

                    }

                    if (IsUploaded)

                    {

                        SqlParameter[] Params = { new SqlParameter("@para", "null") };
                        DataTable DT = DataAccess.ExecuteProcedure("sp_SecurityDataManager", null);

                        DbCommonHelper dbcom = new DbCommonHelper();

                        if (DT.Rows.Count > 0)
                        {
                            string resultMsg = DT.Rows[0]["Message"].ToString();

                            if (resultMsg == "Data processed successfully.")
                            {

                                SqlParameter[] Param =
                                        {
                                            new SqlParameter("@filename", fileName),
                                            new SqlParameter("@uplodedBy", Convert.ToInt32(UserManager.User.Code)),
                                            new SqlParameter("@totalRec", Convert.ToInt32(tbl.Rows.Count)),
                                             new SqlParameter("@file_Ref", "Security"),
                                        };

                                msg = dbcom.Save("sp_FileMaster", Param);

                                msg = "Data Upload Successfully.";

                                Helper.WriteLog("Data Upload Successfully. " + fileName);

                            }
                            else
                            {

                            }
                        }

                    }

                    else

                    {

                        msg = "Data not Uploaded,because Column data mismatch..!";

                    }

                }

                else

                {

                    msg = "File doesn't have data..!";

                }

                return msg;

            }

            catch (Exception ex)

            {

                Helper.WriteLog(ex.StackTrace);

                msg = "Data not Uploaded Column data mismatch..!";

                return msg;

            }

        }

 

        public string UploadConfirmationBrokerData(string path, string fileName)
        {
            bool IsUploaded = false;
            string msg = "successfuly upload";
            string delimiter = "\t";
            int startIndex = 0;
            string[] columns = null;
            DataTable schm_chk = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(path);

            DataTable tbl = ConvertCSVtoDataTable(path);
            System.Data.DataColumn newColumnfile = new System.Data.DataColumn("file_name_mast", typeof(System.String));
            newColumnfile.DefaultValue = fileName.ToString();
            tbl.Columns.Add(newColumnfile);
            DataTable final_dt = tbl.Clone();
            ResponseDataModel res = new ResponseDataModel();
            res.TRT = "N";
            try

            {
                foreach (DataColumn col in tbl.Columns)
                {
                    col.ColumnName = col.ColumnName.Trim().ToLower();
                    //col.ColumnName = col.ColumnName.Trim();
                }
            }

            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message);
            }

            try

            {
                //  Helper.WriteLog("tbl add");

                if (tbl.Rows.Count > 0)

                {
                    string consString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(consString))

                    {

                        con.Open();

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))

                        {
                           


                            sqlBulkCopy.DestinationTableName = "dbo.tbl_BrokerMasterTemp";

                            try

                            {

                                sqlBulkCopy.ColumnMappings.Add("Account", "Account");

                                sqlBulkCopy.ColumnMappings.Add("Security", "Security");

                                sqlBulkCopy.ColumnMappings.Add("Price", "Price");

                                sqlBulkCopy.ColumnMappings.Add("Side", "Side");
                                sqlBulkCopy.ColumnMappings.Add("Quantity", "Quantity");
                                sqlBulkCopy.ColumnMappings.Add("Broker", "Broker");
                                sqlBulkCopy.ColumnMappings.Add("Reason", "Reason");
                                sqlBulkCopy.ColumnMappings.Add("LongNote1", "LongNote1");


                                sqlBulkCopy.BulkCopyTimeout = 10000;

                                sqlBulkCopy.BatchSize = 5000;

                                sqlBulkCopy.WriteToServer(tbl);


                                IsUploaded = true;

                            }

                            catch (Exception EX)

                            {

                                Helper.WriteLog(EX.Message);
                                DataAccess.ExecuteQuery("TRUNCATE table tbl_BrokerMasterTemp");
                                msg = "Data not Uploaded,because " + EX.Message;

                            }

                            con.Close();

                        }

                    }

                    if (IsUploaded)
                    {


                        SqlParameter[] Params = { new SqlParameter("@para", "null") };
                        DataTable DT = DataAccess.ExecuteProcedure("sp_BrokerDataManager", null);

                        DbCommonHelper dbcom = new DbCommonHelper();

                        if (DT.Rows.Count > 0)
                        {
                            string resultMsg = DT.Rows[0]["Message"].ToString();

                            if (resultMsg == "Data inserted successfully")
                            {
                                SqlParameter[] Param =
                                {
                                    new SqlParameter("@filename", fileName),
                                    new SqlParameter("@uplodedBy", Convert.ToInt32(UserManager.User.Code)),
                                    new SqlParameter("@totalRec", Convert.ToInt32(tbl.Rows.Count)),
                                     new SqlParameter("@file_Ref", "Broker"),
                                };

                                msg = dbcom.Save("sp_FileMaster", Param);

                                msg = "Data Upload Successfully.";

                                //System.Threading.Thread.Sleep(120000);
                                Helper.WriteLog("Data Upload Successfully. " + fileName);
                            }
                            else
                            {
                                msg = "File Already Uploaded: " + fileName;
                                Helper.WriteLog("File Already Uploaded: " + fileName);
                            }
                        }


                    }

                    else

                    {

                        msg = "Data not Uploaded,because Column data mismatch..!";

                    }

                }

                else

                {

                    msg = "File doesn't have data..!";

                }

                return msg;

            }

            catch (Exception ex)

            {

                Helper.WriteLog(ex.StackTrace);

                msg = "Data not Uploaded Column data mismatch..!";

                return msg;

            }

        }




        public static DataTable ReadCsvToDataTable(string filePath)
        {
            DataTable dt = new DataTable();

            using (var reader = new StreamReader(filePath))
            {
                string headerLine = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(headerLine)) return dt;

                // headers
                string[] headers = Regex.Split(headerLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                foreach (var header in headers)
                {
                    dt.Columns.Add(header.Trim('"', ' '));
                }

                // rows
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] values = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim().Trim('"'); // remove quotes
                    }

                    dt.Rows.Add(values);
                }
            }
            return dt;
        }



        public string UploadEquityHoldingsData(string path, string fileName)
        {
            bool IsUploaded = false;
            string msg = "successfuly upload";
            string delimiter = "\t";
            int startIndex = 0;
            string[] columns = null;
            DataTable schm_chk = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(path);

            DataTable tbl = ConvertCSVtoDataTable(path);
  
            DataTable final_dt = tbl.Clone();
            ResponseDataModel res = new ResponseDataModel();
            res.TRT = "N";
            try

            {
                foreach (DataColumn col in tbl.Columns)
                {
                    col.ColumnName = col.ColumnName.Trim().ToLower();
                    //col.ColumnName = col.ColumnName.Trim();
                }

                if (tbl.Columns.Contains("is closed"))
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        string val = row["is closed"]?.ToString().Trim().ToLower();

                        if (val == "1" || val == "true" || val == "yes" || val == "closed")
                            row["is closed"] = true;
                        else
                            row["is closed"] = false;
                    }
                }
                
                for (int i = tbl.Rows.Count - 1; i >= 0; i--)
                {
                    bool isCashRow = false;

                    foreach (DataColumn col in tbl.Columns)
                    {
                        var val = tbl.Rows[i][col]?.ToString();

                        if (!string.IsNullOrWhiteSpace(val) &&
                            val.Equals("{cash} INR", StringComparison.OrdinalIgnoreCase))
                        {
                            isCashRow = true;
                            break;
                        }
                    }

                    if (isCashRow)
                    {
                        tbl.Rows.RemoveAt(i);
                        
                    }
                }


            }

            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message);
            }

            try

            {
                //  Helper.WriteLog("tbl add");

                if (tbl.Rows.Count > 0)

                {
                    string consString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(consString))

                    {

                        con.Open();

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))

                        {



                            sqlBulkCopy.DestinationTableName = "dbo.tbl_EquityHoldingsTemp";

                            try

                            {
                                //sqlBulkCopy.ColumnMappings.Add("SourceColumn", "DestinationColumn");

                                sqlBulkCopy.ColumnMappings.Add("display name", "DisplayName");
                                sqlBulkCopy.ColumnMappings.Add("issuer", "Issuer");
                                sqlBulkCopy.ColumnMappings.Add("position", "Position");
                                sqlBulkCopy.ColumnMappings.Add("saleable", "Saleable");
                                sqlBulkCopy.ColumnMappings.Add("underlying equivalent position", "UnderlyingEquivalentPosition");

                                sqlBulkCopy.ColumnMappings.Add("industry sector", "IndustrySector");
                                sqlBulkCopy.ColumnMappings.Add("price", "Price");
                                sqlBulkCopy.ColumnMappings.Add("previous eod pr", "PreviousEODPrice");
                                sqlBulkCopy.ColumnMappings.Add("previousday_futures", "PreviousDay_Futures");
                                sqlBulkCopy.ColumnMappings.Add("cum avg cost", "CumAvgCost");

                                sqlBulkCopy.ColumnMappings.Add("security description", "SecurityDescription");
                                sqlBulkCopy.ColumnMappings.Add("asset type", "AssetType");
                                sqlBulkCopy.ColumnMappings.Add("gross exp/nav", "GrossExp_NAV");
                                sqlBulkCopy.ColumnMappings.Add("a:cost local", "A_Cost_Local");
                                sqlBulkCopy.ColumnMappings.Add("industry", "Industry");

                                sqlBulkCopy.ColumnMappings.Add("change", "[Change]");
                                sqlBulkCopy.ColumnMappings.Add("accrued interest", "AccruedInterest");
                                sqlBulkCopy.ColumnMappings.Add("total p&l", "TotalPL");
                                sqlBulkCopy.ColumnMappings.Add("gross mv", "GrossMV");

                                sqlBulkCopy.ColumnMappings.Add("isin", "ISIN");
                                sqlBulkCopy.ColumnMappings.Add("accrint", "ACCRINT");
                                sqlBulkCopy.ColumnMappings.Add("parent company name", "ParentCompanyName");
                                sqlBulkCopy.ColumnMappings.Add("account name", "AccountName");
                                sqlBulkCopy.ColumnMappings.Add("cusip", "Cusip");
                                sqlBulkCopy.ColumnMappings.Add("previous_day_perc", "Previous_Day_Perc");
                                sqlBulkCopy.ColumnMappings.Add("is closed", "IsClosed");

                                sqlBulkCopy.BulkCopyTimeout = 10000;

                                sqlBulkCopy.BatchSize = 5000;

                                sqlBulkCopy.WriteToServer(tbl);


                                IsUploaded = true;

                            }

                            catch (Exception EX)

                            {

                                Helper.WriteLog(EX.Message);
                                DataAccess.ExecuteQuery("TRUNCATE table tbl_EquityHoldingsTemp");
                                msg = "Data not Uploaded,because " + EX.Message;

                            }

                            con.Close();

                        }

                    }

                    if (IsUploaded)
                    {


                        SqlParameter[] Params = { new SqlParameter("@para", "null") };
                        DataTable DT = DataAccess.ExecuteProcedure("sp_EquityHoldingsDataManager", null);

                        DbCommonHelper dbcom = new DbCommonHelper();

                        if (DT.Rows.Count > 0)
                        {
                            string resultMsg = DT.Rows[0]["Message"].ToString();

                            if (resultMsg == "Data inserted successfully")
                            {
                                SqlParameter[] Param =
                                {
                                    new SqlParameter("@filename", fileName),
                                    new SqlParameter("@uplodedBy", Convert.ToInt32(UserManager.User.Code)),
                                    new SqlParameter("@totalRec", Convert.ToInt32(tbl.Rows.Count)),
                                     new SqlParameter("@file_Ref", "EquityHolding"),
                                };

                                msg = dbcom.Save("sp_FileMaster", Param);

                                msg = "Data Upload Successfully.";

                                //System.Threading.Thread.Sleep(120000);
                                Helper.WriteLog("Data Upload Successfully. " + fileName);
                            }
                            else
                            {
                                msg = "File Already Uploaded: " + fileName;
                                Helper.WriteLog("File Already Uploaded: " + fileName);
                            }
                        }


                    }

                    else

                    {

                        msg = "Data not Uploaded,because Column data mismatch..!";

                    }

                }

                else

                {

                    msg = "File doesn't have data..!";

                }

                return msg;

            }

            catch (Exception ex)

            {

                Helper.WriteLog(ex.StackTrace);

                msg = "Data not Uploaded Column data mismatch..!";

                return msg;

            }

        }

        public string UploadFutureHoldingsData(string path, string fileName)
        {
            bool IsUploaded = false;
            string msg = "successfuly upload";
            string delimiter = "\t";
            int startIndex = 0;
            string[] columns = null;
            DataTable schm_chk = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(path);

            DataTable tbl = ConvertCSVtoDataTable(path);

            DataTable final_dt = tbl.Clone();
            ResponseDataModel res = new ResponseDataModel();
            res.TRT = "N";
            try

            {
                foreach (DataColumn col in tbl.Columns)
                {
                    col.ColumnName = col.ColumnName.Trim().ToLower();
                    //col.ColumnName = col.ColumnName.Trim();
                }

                if (tbl.Columns.Contains("is closed"))
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        string val = row["is closed"]?.ToString().Trim().ToLower();

                        if (val == "1" || val == "true" || val == "yes" || val == "closed")
                            row["is closed"] = true;
                        else
                            row["is closed"] = false;
                    }
                }

                if (tbl.Columns.Contains("expiration date"))
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        row["expiration date"] = row["expiration date"]?.ToString().Trim();
                    }
                }

                
            }

            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message);
            }

            try

            {
                //  Helper.WriteLog("tbl add");

                if (tbl.Rows.Count > 0)

                {
                    string consString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(consString))

                    {

                        con.Open();

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))

                        {



                            sqlBulkCopy.DestinationTableName = "dbo.tbl_FutureHoldingsTemp";

                            try

                            {
                                //sqlBulkCopy.ColumnMappings.Add("SourceColumn", "DestinationColumn");


                                sqlBulkCopy.ColumnMappings.Add("display name", "DisplayName");
                                sqlBulkCopy.ColumnMappings.Add("account code", "AccountCode");
                                sqlBulkCopy.ColumnMappings.Add("account name", "AccountName");
                                sqlBulkCopy.ColumnMappings.Add("name", "Name");
                                sqlBulkCopy.ColumnMappings.Add("security description", "SecurityDescription");
                                sqlBulkCopy.ColumnMappings.Add("position", "Position");
                                sqlBulkCopy.ColumnMappings.Add("underlying equivalent position", "UnderlyingEquivalentPosition");
                                sqlBulkCopy.ColumnMappings.Add("a:market value local", "A_MarketValueLocal");
                                sqlBulkCopy.ColumnMappings.Add("price", "Price");
                                sqlBulkCopy.ColumnMappings.Add("expiration date", "ExpirationDate");
                                sqlBulkCopy.ColumnMappings.Add("issuer", "Issuer");
                                sqlBulkCopy.ColumnMappings.Add("is closed", "IsClosed");




                                sqlBulkCopy.BulkCopyTimeout = 10000;

                                sqlBulkCopy.BatchSize = 5000;

                                sqlBulkCopy.WriteToServer(tbl);


                                IsUploaded = true;

                            }

                            catch (Exception EX)

                            {

                                Helper.WriteLog(EX.Message);
                                DataAccess.ExecuteQuery("TRUNCATE table tbl_FutureHoldingsTemp");
                                msg = "Data not Uploaded,because " + EX.Message;

                            }

                            con.Close();

                        }

                    }

                    if (IsUploaded)
                    {


                        SqlParameter[] Params = { new SqlParameter("@para", "null") };
                        DataTable DT = DataAccess.ExecuteProcedure("sp_FutureHoldingsDataManager", null);

                        DbCommonHelper dbcom = new DbCommonHelper();

                        if (DT.Rows.Count > 0)
                        {
                            string resultMsg = DT.Rows[0]["Message"].ToString();

                            if (resultMsg == "Data inserted successfully")
                            {
                                SqlParameter[] Param =
                                {
                                    new SqlParameter("@filename", fileName),
                                    new SqlParameter("@uplodedBy", Convert.ToInt32(UserManager.User.Code)),
                                    new SqlParameter("@totalRec", Convert.ToInt32(tbl.Rows.Count)),
                                     new SqlParameter("@file_Ref", "FutureHolding"),
                                };

                                msg = dbcom.Save("sp_FileMaster", Param);

                                msg = "Data Upload Successfully.";

                                //System.Threading.Thread.Sleep(120000);
                                Helper.WriteLog("Data Upload Successfully. " + fileName);
                            }
                            else
                            {
                                msg = "File Already Uploaded: " + fileName;
                                Helper.WriteLog("File Already Uploaded: " + fileName);
                            }
                        }


                    }

                    else

                    {

                        msg = "Data not Uploaded,because Column data mismatch..!";

                    }

                }

                else

                {

                    msg = "File doesn't have data..!";

                }

                return msg;

            }

            catch (Exception ex)

            {

                Helper.WriteLog(ex.StackTrace);

                msg = "Data not Uploaded Column data mismatch..!";

                return msg;

            }

        }

    

    }
}