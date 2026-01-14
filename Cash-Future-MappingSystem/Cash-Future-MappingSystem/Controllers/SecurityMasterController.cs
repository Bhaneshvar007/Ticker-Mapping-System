using Cash_Future_MappingSystem.BAL;
using CRMITStaffing.CustomHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cash_Future_MappingSystem.Controllers
{
    [CustomAuthorize]
    public class SecurityMasterController : Controller
    {
        // GET: SecurityMaster
         
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult UploadSecuritymaster()
        {
            return View();
        }

        
        public ContentResult Upload()
        {

            string path = Server.MapPath("~/Uploadfiles/SecurityMaster/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                postedFile.SaveAs(path + postedFile.FileName);
            }
            //foreach(string filename in fileEntries)
            //{
            //    string name = Path.GetFileName(filename);
            //}
            // return new JsonNetResult(recon.getUploadFile(Rsdate, xlFile));
            return Content("Success");
        }

        [HttpPost]
        
        public ActionResult GetUploadFile(DateTime FROM_DATE, string xlFile)
        {

            uploadfileRepository recon = new uploadfileRepository();


            return new JsonNetResult(recon.getUploadSecurtyFile(FROM_DATE, xlFile));

        }
    }
}