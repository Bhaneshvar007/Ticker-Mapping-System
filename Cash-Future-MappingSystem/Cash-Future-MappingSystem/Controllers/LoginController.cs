using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Cylsys.Common;
using Cash_Future_MappingSystem.Models;
using Cash_Future_MappingSystem.BAL;
using Login = Cash_Future_MappingSystem.BAL.Login;
using CRMITStaffing.CustomHelper;

namespace Cash_Future_MappingSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
         
        public ActionResult Index()
        {
            Session["UserDetails"] = null;
            Session["LoggedInUser"] = null;
            Session.Abandon();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
         
        public ActionResult Index(LoginViewModel model, string returnUrl)
        {
            Helper.WriteLog("Enter in login controller");
            Login bll = new Login();

            UserDetailsModel objmodel = bll.GetUserDetail(model.UserID, model.Password);
            if (Session["sessionCaptcha"].ToString() == model.CaptchaInputText)
            {

                if (objmodel != null)
                {

                    Session["UserDetails"] = objmodel;
                    Session["LoggedInUser"] = objmodel.Name;
                    Common2 cm2 = new Common2();
                  //  List<MenusModel> menus = cm2.GetMenus();
                   // Session["MenuList"] = menus;
                    Helper.WriteLog("Welcome " + objmodel.Name);
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(Request.Url.AbsoluteUri + returnUrl);
                    }
                    //if (!string.IsNullOrWhiteSpace(objmodel.employee_code.ToString()))
                    //{
                    //    return RedirectToAction("Index", "Home");

                    //}
  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.errorMessage = "Invalid Credentials.";
                }
            }
            else
            {
                if (Session["sessionCaptcha"].ToString() != model.CaptchaInputText)
                {
                    ViewBag.errorMessage = "invalid captcha";
                }
                if (model.CaptchaInputText == null)
                {
                    ViewBag.errorMessage = "please enter captcha";

                }
            }
            return View();

        }

        public ActionResult captacha_image()
        {
            Random random = new Random();
            Bitmap bitmap = new Bitmap(150, 90);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.DrawLine(Pens.Black, random.Next(0, 50), random.Next(10, 30), random.Next(0, 200), random.Next(0, 50));
            graphics.DrawRectangle(Pens.Blue, random.Next(0, 20), random.Next(0, 20), random.Next(50, 80), random.Next(0, 20));
            graphics.DrawLine(Pens.Blue, random.Next(0, 20), random.Next(10, 50), random.Next(100, 200), random.Next(0, 80));
            Brush disignBrush = default(Brush);
            //captcha background style  
            HatchStyle[] bkgStyle = new HatchStyle[]
            {
            HatchStyle.BackwardDiagonal, HatchStyle.Cross, HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal, HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical,
            HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross, HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid, HatchStyle.ForwardDiagonal, HatchStyle.Horizontal,
            HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard, HatchStyle.LargeConfetti, HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal
            };
            //create captcha rectangular area for ui 
            RectangleF rectagleArea = new RectangleF(0, 0, 250, 250);
            disignBrush = new HatchBrush(bkgStyle[random.Next(bkgStyle.Length - 3)], Color.FromArgb((random.Next(100, 255)), (random.Next(100, 255)), (random.Next(100, 255))), Color.White);
            graphics.FillRectangle(disignBrush, rectagleArea);
            //generate captcha code with random code
            string captchaCode = string.Format("{0:X}", random.Next(1000000, 9999999));
            //add catcha code into session for use
            Session["sessionCaptcha"] = captchaCode;
            Font objFont = new Font("Times New Roman", 25, FontStyle.Bold);
            //create image for captcha
            graphics.DrawString(captchaCode, objFont, Brushes.Black, 20, 20);
            //Save the image 
            bitmap.Save(Response.OutputStream, ImageFormat.Gif);
            byte[] array;
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                array = stream.ToArray();
            }

            return File(array, "image/png");
        }
        public ActionResult Logout()
        {
            Session["UserDetails"] = null;
            Session["LoggedInUser"] = null;
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}