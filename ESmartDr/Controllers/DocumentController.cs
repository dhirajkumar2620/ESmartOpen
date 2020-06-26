using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class DocumentController : Controller
    {
         public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDocument()
        {
            return View("Document");
        }
    }
}