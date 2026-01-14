using Cash_Future_MappingSystem.BAL;
using CRMITStaffing.CustomHelper;
using Cylsys.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cash_Future_MappingSystem.Controllers
{
    [CustomAuthorize]
    public class ReportsController : Controller
    {
 
        public ActionResult Index()
        {
            return View();
        }

  
        public ActionResult DailyMatchedSummry()
        {
            Reports reports = new Reports();
            var AccountFilData = reports.AccountFilterDatas();
            var BrokerFilData = reports.BrokerFilterDatas();
            ViewBag.BrokerList = BrokerFilData;
            ViewBag.AccountList = AccountFilData;
            var TransactionData = TransctionTypeGridList();
            ViewBag.TransactionList = TransactionData;
            return View();
        }


 
        public ActionResult GetDailyMatchedSummryReport()
        {
            Request.InputStream.Position = 0;

            // Read the raw JSON data
            string jsonData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                jsonData = reader.ReadToEnd();
            }
            // Deserialize to dynamic object
            dynamic data = JsonConvert.DeserializeObject(jsonData);


            Reports reports = new Reports();
            return new JsonNetResult(reports.GetDailyMatchedSummryReports(data));
        }
         
        public ActionResult BrokerwiseMatchingReport()
        {
            Reports reports = new Reports();
            var BrokerFilData = reports.BrokerFilterDatas();
            ViewBag.BrokerList = BrokerFilData;
            var AccountFilData = reports.AccountFilterDatas();
            ViewBag.AccountList = AccountFilData;
            var TransactionData = TransctionTypeGridList();
            ViewBag.TransactionList = TransactionData;
            return View();

        }
        
        public ActionResult GetBrokerwiseMatchingReport()
        {
            Request.InputStream.Position = 0;

            // Read the raw JSON data
            string jsonData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                jsonData = reader.ReadToEnd();
            }

            // Deserialize to dynamic object
            dynamic data = JsonConvert.DeserializeObject(jsonData);

            Reports reports = new Reports();

            return new JsonNetResult(reports.GetBrokerwiseMatchingReports(data));
        }

       
        public ActionResult UnmatchedTradesReport()
        {
            Reports reports = new Reports();
            var BrokerFilData = reports.BrokerFilterDatas();
            ViewBag.BrokerList = BrokerFilData;
            var AccountFilData = reports.AccountFilterDatas();
            ViewBag.AccountList = AccountFilData;
            var TransactionData = TransctionTypeGridList();
            ViewBag.TransactionList = TransactionData;
            return View();
        }


   
        public ActionResult GetUnmatchedTradesReport()
        {
            Request.InputStream.Position = 0;
            string jsonData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                jsonData = reader.ReadToEnd();
            }
            dynamic data = JsonConvert.DeserializeObject(jsonData);
            Reports reports = new Reports();
            return new JsonNetResult(reports.GetUnmatchedTradesReports(data));
        }

         
        public ActionResult TradewiseMatchingLog()
        {
            Reports reports = new Reports();
            var BrokerFilData = reports.BrokerFilterDatas();
            ViewBag.BrokerList = BrokerFilData;
            var AccountFilData = reports.AccountFilterDatas();
            ViewBag.AccountList = AccountFilData;
            var TransactionData = TransctionTypeGridList();
            ViewBag.TransactionList = TransactionData;
            return View();
        }


       
        public ActionResult GetTradewiseMatchingLogReport()
        {
            Request.InputStream.Position = 0;
            string jsonData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                jsonData = reader.ReadToEnd();
            }
            dynamic data = JsonConvert.DeserializeObject(jsonData);
            Reports reports = new Reports();
            return new JsonNetResult(reports.GetTradewiseMatchingLogReports(data));
        }


        public List<TransactionTypeModel> TransctionTypeGridList()
        {
            return new List<TransactionTypeModel>
                    {
                        new TransactionTypeModel { Code = "FA",      Name = "FA" },
                        new TransactionTypeModel { Code = "RA / UW", Name = "RA / UW" },
                        new TransactionTypeModel { Code = "SR",      Name = "SR" },
                        new TransactionTypeModel { Code = "LR",      Name = "LR" }
                    };
        }



    }
}