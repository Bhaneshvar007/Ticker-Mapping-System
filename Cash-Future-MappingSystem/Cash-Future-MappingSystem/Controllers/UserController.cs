using Cash_Future_MappingSystem.BAL;
using CRMITStaffing.CustomHelper;
using Cylsys.Common;

using System.Web.Mvc;

namespace Cash_Future_MappingSystem.Controllers
{
    [CustomAuthorize]
    public class UserController : Controller
    {
        // GET: User
        [CustomAuthorize]
        public ActionResult Index()
        {
            //UserMaster userMaster = new UserMaster();
            //userMaster.GetUserData();
            return View();
        }
       
        public ActionResult GetUser()
        {
            UserMaster userMaster = new UserMaster();
            return new JsonNetResult(userMaster.GetUserData());
      
        }
        
        public ActionResult AddUser()
        {
            Role role = new Role();
            
            var res = role.GetRoleData();
            ViewBag.roleData = res; 
            return View();
        }
        [HttpPost]
       
        public JsonResult SaveUser(UserModel userModel)
        {
           
                UserMaster userMaster = new UserMaster();
                var user = userMaster.AddUserData(userModel);

          
                return Json(new { success = true, message = "User created successfully!" });
            
        }
       
        public ActionResult GetUserGrid()
        {
            return View();
        }


       
        [Route("/User/UpdateUser/{id}")]
        public ActionResult UpdateUser(int? id)
        {

            Role role = new Role();
            var res = role.GetRoleData();
            ViewBag.roleData = res;


            UserMaster userMaster = new UserMaster();
            var user = userMaster.GetUserById(id);
            ViewBag.UserData = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            
            return View();
        }
        
        public ActionResult UpdateUserSave(UserModel model)
        {
            UserMaster userMaster = new UserMaster();
            var user = userMaster.AddUserData(model);


            return Json(new { success = true, message = "User updated successfully!" });
        }



        
    }
}