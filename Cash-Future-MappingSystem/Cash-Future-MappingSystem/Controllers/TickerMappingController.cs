using Cash_Future_MappingSystem.BAL;
using CRMITStaffing.CustomHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cash_Future_MappingSystem.Controllers
{
    [CustomAuthorize]
    public class TickerMappingController : Controller
    {
        // GET: TickerMapping
        
        public ActionResult Index()
        {
            return View();
        }

         
        public ActionResult ProcessTickerMapping()
        {
            TickerMapping tickerMapping = new TickerMapping();
            string message = "";
            var result = tickerMapping.ProcessTickerMappingData(out message);

            return Json(new { success = true, message = message, data = result }, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult GetTickerMappingGrid()
        {
            TickerMapping tickerMapping = new TickerMapping();
            return new JsonNetResult(tickerMapping.GetTickerMappingData());
           
        }
    }
}