using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_Edit_and_Delete.Models;
using MRF_Edit_and_Delete.Models.User;

namespace MRF_Edit_and_Delete.Controllers
{
    public class UserController : Controller
    {
        UserDatalayer UserDB = new UserDatalayer();

        public ActionResult UserIndex()                       
        { 
            return View();

        }
        public JsonResult List(string Userid)       
        {
    
            return Json(UserDB.ListAll(Userid), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var User = UserDB.MRFdetails().Find(x => x.id.Equals(ID));
            return Json(User, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(MRFModel user)
        {
            return Json(UserDB.Update(user), JsonRequestBehavior.AllowGet);
        } 
        public JsonResult Delete(int ID)
        {
            return Json(UserDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }


    }
}