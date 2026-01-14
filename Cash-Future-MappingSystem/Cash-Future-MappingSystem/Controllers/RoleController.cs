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
    public class RoleController : Controller
    {
        // GET: Role

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetRole()
        {
            Role role = new Role();
            return new JsonNetResult(role.GetRoleData());

        }


        
        public ActionResult AddRole()
        {
            return View();
        }


       
        public JsonResult SaveRole(RoleModel model)
        {

            Role role = new Role();
            var user = Role.AddRoleData(model);
            return Json(new { success = true, message = "Role Added successfully!" });

        }
    }
}