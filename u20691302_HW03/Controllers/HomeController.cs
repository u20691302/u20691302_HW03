using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u20691302_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        //Declaring variable to storage file path
        string StorageFilePath = "";

        //Action result to store files in correct location
        [HttpPost]
        public ActionResult Home(FormCollection frm, HttpPostedFileBase Files)
        {
            int RadioValue = int.Parse(frm["FileType"]);
            switch (RadioValue)
            {
                case 1:
                    StorageFilePath = "~/Resources/Files";
                    break;
                case 2:
                    StorageFilePath = "~/Resources/Images";
                    break;
                case 3:
                    StorageFilePath = "~/Resources/Videos";
                    break;
            }

            if (Files != null && Files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(Files.FileName);
                var path = Path.Combine(Server.MapPath(StorageFilePath), fileName);
                Files.SaveAs(path);
            }
            return RedirectToAction("Home");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}