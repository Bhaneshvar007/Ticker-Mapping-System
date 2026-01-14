using Cash_Future_MappingSystem.BAL;
using CRMITStaffing.CustomHelper;
using Cylsys.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cash_Future_MappingSystem.Controllers
{
    [CustomAuthorize]
    public class clientmasterController : Controller
    {
        
       
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult GetclientGrid()
        {
            Client bll = new Client();
            return new JsonNetResult(bll.GetclientGrid());

        }
      
        public ActionResult updateClient() 
        { 
            return View();
        }
        
        public ActionResult GetItem(int Client_ID)
        {
            Client bll = new Client();
            return new JsonNetResult(bll.GetItem(Client_ID));
        }

        
        public ActionResult Save(ClientMoodel model)
        {
            //UserModel modelObj = Helper.Deserialize<UserModel>(model);
            Client bll = new Client();
            return new JsonNetResult(bll.Save(model));
        }
 
        public ActionResult OldClientData()
        {
            return View();
        }
        public ActionResult OldClientGetData()
        {
            Client bll = new Client();
            return new JsonNetResult(bll.GetclientOldGrid());

        }



    }
}