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
    public class SettingsController : Controller
    {
 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OldSecurityMaster()
        {
            return View();
        }

        public ActionResult GetOldSecurityGrid()
        {
            Settings settings = new Settings();
            return new JsonNetResult(settings.GetOldSecurityGrid());

        }


        public ActionResult OldEquityholdings()
        {
            return View();
        }

        public ActionResult OldEquityholdingsGrid()
        {
            Settings settings = new Settings();
            return new JsonNetResult(settings.GetOldEquityOpeningHoldingsData());

        }
        public ActionResult OldFutureholdings()
        {
            return View();
        }

        public ActionResult OldFutureholdingsGrid()
        {
            Settings settings = new Settings();
            return new JsonNetResult(settings.GetOldFutureOpeningHoldingsData());
        }


    }
}