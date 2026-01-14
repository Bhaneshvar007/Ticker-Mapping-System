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
    public class PageAccessLogController : Controller
    {
        // GET: PageAccessLog    
        public ActionResult Index()
        {
            Reports reports = new Reports();
            var PageAccessLogFilData = reports.PageAccessLogFilterDatas();
            ViewBag.PageAccessLogList = PageAccessLogFilData;
            return View();
        }
         
        public ActionResult GetPageAccessLog()
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
            PageAccessLog pageAccessLog = new PageAccessLog();
            return new JsonNetResult(pageAccessLog.GetPageAccessLogsData(data));
        }
    }
}