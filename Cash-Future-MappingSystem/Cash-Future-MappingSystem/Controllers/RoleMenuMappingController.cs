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
    public class RoleMenuMappingController : Controller
    {
        // GET: RoleMenuMapping

        public ActionResult Index()
        {
            Role role = new Role();

            var res = role.GetRoleData();
            ViewBag.roleData = res;

            return View();
        }
        public ActionResult GetRoleMenuMapping()
        {
            return View();
        }

        public ActionResult MappedMenuWithRole()
        {
            return View();
        }
    }
}