using Cash_Future_MappingSystem.BAL;
using CRMITStaffing.CustomHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cash_Future_MappingSystem.Controllers
{
    public class FileMasterController : Controller
    {
         
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult GetFiles()
        {
            FileMaster fileMaster = new FileMaster();

            return new JsonNetResult(fileMaster.GetFileData());
        }

        
        public JsonResult DeleteFiles(int id)
        {
            FileMaster fileMaster = new FileMaster();
            var res = fileMaster.DeleteFile(id);

            return Json(new { success = res }, JsonRequestBehavior.AllowGet);
        }

    }
}