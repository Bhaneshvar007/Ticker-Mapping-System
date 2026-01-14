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
    public class ConfirmationBrokerDataController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetConfirmationBroker()
        {
            Broker bal = new Broker();
            Helper.WriteLog("Broker GetConfirmationBroker");
            return new JsonNetResult(bal.GetConfirmationBroker());
        }
         
        public ActionResult UpdateConfirmationBroker()
        {
            return View();
        }
        
        public ActionResult GetItem(int id)
        {
            Broker bal = new Broker();
            return new JsonNetResult(bal.GetItem(id));
        }
          
        public ActionResult Save(TradeConfirmation model)
        {
            Broker bal = new Broker();
            return new JsonNetResult(bal.Save(model));
        }


        public ActionResult OldBrokerData()
        {
            return View();
        }
         
        public ActionResult GetOldBroker()
        {
            Broker bal = new Broker();
            return new JsonNetResult(bal.GetOldBrokerData());
        }

    }
}