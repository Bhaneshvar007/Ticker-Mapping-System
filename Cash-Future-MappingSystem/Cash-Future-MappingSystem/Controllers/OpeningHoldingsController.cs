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
    public class OpeningHoldingsController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
 
        public ActionResult EquityHoldingsUpload()
        {
            return View();
        }
        public ActionResult EquityHoldings()
        {
            return View();
        }

        public ActionResult GetEquityHoldingsGrid()
        {
            OpeningHoldings openingHoldings = new OpeningHoldings();

            return new JsonNetResult(openingHoldings.GetEquityOpeningHoldingsData());
        }



        public ActionResult FutureHoldingsUpload()
        {
            return View();
        }
        public ActionResult FutureHoldings()
        {
            return View();
        }

        public ActionResult GetFutureHoldingsGrid()
        {
            OpeningHoldings openingHoldings = new OpeningHoldings();

            return new JsonNetResult(openingHoldings.GetFutureOpeningHoldingsData());
        }

        public ContentResult EquityHoldings_UploadFile()
        {

            string path = Server.MapPath("~/Uploadfiles/OpeningHoldings/EquityHoldings/");
 

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                postedFile.SaveAs(path + postedFile.FileName);
            }
            
            return Content("Success");
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult GetUploadEquityFile(DateTime FROM_DATE, string xlFile)
        {

            uploadfileRepository recon = new uploadfileRepository();


            return new JsonNetResult(recon.GetUploadEquityyFile(FROM_DATE, xlFile));

        }
 

        public ContentResult FutureHoldings_UploadFile()
        {

             string path = Server.MapPath("~/Uploadfiles/OpeningHoldings/FutureHoldings/");


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                postedFile.SaveAs(path + postedFile.FileName);
            }
            
            return Content("Success");
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult GetFutureUploadFile(DateTime FROM_DATE, string xlFile)
        {

            uploadfileRepository recon = new uploadfileRepository();


            return new JsonNetResult(recon.GetUploadFutureFile(FROM_DATE, xlFile));

        }



        public ActionResult JoinOpeningHoldings()
        {
            return View();
        }
        public ActionResult GetJoinOpeningHoldingsGrid()
        {
            OpeningHoldings openingHoldings = new OpeningHoldings();

            return new JsonNetResult(openingHoldings.GetJoinOpeningHoldingsData());
        }
    }
}