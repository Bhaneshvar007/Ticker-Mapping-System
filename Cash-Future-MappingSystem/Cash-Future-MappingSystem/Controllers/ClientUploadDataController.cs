using CRMITStaffing.CustomHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cash_Future_MappingSystem.Controllers
{
    public class ClientUploadDataController : Controller
    {
        // GET: ClientUploadData
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}