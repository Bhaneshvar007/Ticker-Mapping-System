using CRMITStaffing.CustomHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cash_Future_MappingSystem.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ErrorHandling()
        {
            return View();
        }


    }
}