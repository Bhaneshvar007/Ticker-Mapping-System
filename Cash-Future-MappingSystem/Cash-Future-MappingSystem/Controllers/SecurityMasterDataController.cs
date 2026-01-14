using Cash_Future_MappingSystem.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cylsys.Common;
using CRMITStaffing.CustomHelper;

namespace Cash_Future_MappingSystem.Controllers
{
        [CustomAuthorize]
    public class SecurityMasterDataController : Controller
    {
        // GET: SecurityMasterData
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult GetSecurityGrid()
        {
            SecurityMaster bal = new SecurityMaster();
            return new JsonNetResult(bal.GetSecurityGrid());
        }
         
        public ActionResult UpdateSecurity()
        {
            return View();
        }
         
        public ActionResult GetItem(int Security_ID)
        {
            SecurityMaster bal = new SecurityMaster();
            return new JsonNetResult(bal.GetItem(Security_ID));
        }
       
        public ActionResult Save(SecurityModel model)
        {
            SecurityMaster bal = new SecurityMaster();
            return new JsonNetResult(bal.Save(model));
        }





        public ActionResult OldSecurityData()
        {
            return View();
        }
        
        public ActionResult GetOldSecurity()
        {
            SecurityMaster bal = new SecurityMaster();
            return new JsonNetResult(bal.GetOldSecurityGrid());
        }
    }
}