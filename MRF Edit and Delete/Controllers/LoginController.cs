using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_Edit_and_Delete.Models;
using MRF_Edit_and_Delete.Models.Loginscreen;

namespace MRF_Edit_and_Delete.Controllers
{
    public class LoginController : Controller
    {
        LoginDatalayer LoginDl = new LoginDatalayer();

        public ActionResult LoginIndex()
        {
            return View();
        }

        //login 1
        public JsonResult Loginvalidation(LoginModel Log)
        {
            Session["Userid"] = Log.Userid;
            return Json(LoginDl.Loginvalidation(Log), JsonRequestBehavior.AllowGet);
        }

    }
}