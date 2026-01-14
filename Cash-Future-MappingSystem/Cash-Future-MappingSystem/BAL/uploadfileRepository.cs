using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class uploadfileRepository
    {
        string Result;
        SqlParameter[] Params;
        public string getClientUploadFile(DateTime Rsdate, string xlFile)
        {

            var supportedTypes = new[] { ".csv" };

            SqlParameter[] Params = {
                                       new SqlParameter("@FileName",xlFile),

                                     };
            Helper.WriteLog("getClientUploadFile");
            

            string FILE_PATH_DIR = ConfigurationManager.AppSettings["clientmaster"].ToString();

            string[] files = Directory.GetFiles((FILE_PATH_DIR));

            //foreach (string filename in files)
            //{
            //  Helper.WriteLog(filename);
            string filenm = Path.GetFileName(xlFile);
            var extension = Path.GetExtension(xlFile);
            if (extension == supportedTypes[0])
            {

                string folderPath = ConfigurationManager.AppSettings["clientmaster"].ToString();
                string Pathfile = Path.Combine(folderPath, xlFile); ;

                Common2 com = new Common2();
                Result = com.UploadClientData(Pathfile, xlFile,Rsdate);


            }
            else
            {
                Result = "File Format not supported";
            }

            return Result;
        }

        // Abhay 23_08_2025

        public string getUploadSecurtyFile(DateTime Rsdate, string xlFile)
        {


            var supportedTypes = new[] { ".csv" };

            SqlParameter[] Params = {
                         new SqlParameter("@FileName",xlFile),

                       };
            //DataTable DT = DataAccess.ExecuteProcedure("", Params);

            /*  if (DT.Rows.Count > 0)
              {
                  Result = "Filename  =  " + xlFile + " is alread Uploaded ...!";
                  Helper.WriteLog("Filename  =  " + xlFile + " is alread Uploaded ...!");
                  return Result;
              }*/

            string FILE_PATH_DIR = ConfigurationManager.AppSettings["SecurityMaster"].ToString();

            string[] files = Directory.GetFiles((FILE_PATH_DIR));

            //foreach (string filename in files)
            //{
            //  Helper.WriteLog(filename);
            string filenm = Path.GetFileName(xlFile);
            var extension = Path.GetExtension(xlFile);
            if (extension == supportedTypes[0])
            {

                //string Pathfile = ConfigurationManager.AppSettings["SecurityMaster"].ToString() + xlFile;
                string folderPath = ConfigurationManager.AppSettings["SecurityMaster"].ToString();
                string fileName = Path.GetFileName(xlFile); // only file name
                string Pathfile = Path.Combine(folderPath, fileName);
                Common2 com = new Common2();
                Result = com.UploadSecurtyData(Pathfile, xlFile);


            }
            else
            {
                Result = "File Format not supported";
            }

            return Result;
        }


       
        public string getUploadConfirmationBrokerFile(DateTime Rsdate, string xlFile)
        {
            try
            {
                var supportedTypes = new[] { ".csv" };
                string Result = "";

                string filenm = Path.GetFileName(xlFile);
                var extension = Path.GetExtension(xlFile);

                if (extension != supportedTypes[0])
                {
                    return "Error: File format not supported. Only .csv is allowed.";
                }

                string folderPath = ConfigurationManager.AppSettings["ConfirmationBroker"].ToString();
                string fileName = Path.GetFileName(xlFile);
                string Pathfile = Path.Combine(folderPath, fileName);

                
                // Load CSV into DataTable
                DataTable dt = Common2.ReadCsvToDataTable(Pathfile);    
                string[] requiredColumns = { "Account", "Security", "Price", "Side", "Quantity", "Broker", "Reason", "LongNote1" };

                // testing for use only
                foreach (DataRow row in dt.Rows)
                {
                    string note = row["LongNote1"].ToString();
                    Console.WriteLine($"Length: {note.Length}, Value: {note}");
                }
                
                //  Check missing columns
                foreach (var col in requiredColumns)
                {
                    if (!dt.Columns.Contains(col))
                    {

                        return $"Error: Missing required column '{col}' in file.";
                    }
                }

                //  Check empty values row by row
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    foreach (var col in requiredColumns)
                    {
                        if (col != "LongNote1")
                        {
                            if (row.IsNull(col) || string.IsNullOrWhiteSpace(row[col].ToString()))
                            {
                                Console.WriteLine($"Inserting LongNote1: {row["LongNote1"]}");
                                System.Web.HttpContext.Current.Response.Write("<script>alert('Inserting LongNote1: " + row["LongNote1"].ToString() + "');</script>");

                                return $"Error: Empty value found at Row {i + 2}, Column '{col}'.";
                            }
                        }
                    }
                }

                //  If all good → upload
                Common2 com = new Common2();
                Result = com.UploadConfirmationBrokerData(Pathfile, xlFile);

                return Result;
            }
            catch (Exception ex)
            {
                return $"Unexpected error while processing file: {ex.Message}";
            }
        }





        public string GetUploadEquityyFile(DateTime Rsdate, string xlFile)
        {

            var supportedTypes = new[] { ".csv" };

            string FILE_PATH_DIR = ConfigurationManager.AppSettings["clientmaster"].ToString();

            string[] files = Directory.GetFiles((FILE_PATH_DIR));

            //foreach (string filename in files)
            //{
            //  Helper.WriteLog(filename);
            string filenm = Path.GetFileName(xlFile);
            var extension = Path.GetExtension(xlFile);
            if (extension == supportedTypes[0])
            {

                string folderPath = ConfigurationManager.AppSettings["EquityHoldings"].ToString();
                string Pathfile = Path.Combine(folderPath, xlFile); 

                Common2 com = new Common2();
                Result = com.UploadEquityHoldingsData(Pathfile, xlFile);


            }
            else
            {
                Result = "File Format not supported";
            }

            return Result;
        }

   
    
        public string GetUploadFutureFile(DateTime Rsdate, string xlFile)
        {

            var supportedTypes = new[] { ".csv" };

            string FILE_PATH_DIR = ConfigurationManager.AppSettings["clientmaster"].ToString();

            string[] files = Directory.GetFiles((FILE_PATH_DIR));

            //foreach (string filename in files)
            //{
            //  Helper.WriteLog(filename);
            string filenm = Path.GetFileName(xlFile);
            var extension = Path.GetExtension(xlFile);
            if (extension == supportedTypes[0])
            {

                string folderPath = ConfigurationManager.AppSettings["FutureHoldings"].ToString();
                string Pathfile = Path.Combine(folderPath, xlFile); 

                Common2 com = new Common2();
                Result = com.UploadFutureHoldingsData(Pathfile, xlFile);


            }
            else
            {
                Result = "File Format not supported";
            }

            return Result;
        }

   
    
    
    }
}