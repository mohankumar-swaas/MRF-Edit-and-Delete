using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_Edit_and_Delete.Models;
using MRF_Edit_and_Delete.Models.MRFscreen;

namespace MRF_Edit_and_Delete.Controllers
{
    public class MRFController : Controller
    {
        MRFDatalayer MRFDB = new MRFDatalayer();
        public ActionResult MRFIndex()
        {
            
            return View();
        }

        public JsonResult Add(MRFModel MRF)
        {
            int result = 0;
            result = MRFDB.Add(MRF);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditMRF(int id,int edit)
        {
            ViewBag.id = id;
            ViewBag.edit = edit;
            return View("MRFIndex");
        }

       
    }
}