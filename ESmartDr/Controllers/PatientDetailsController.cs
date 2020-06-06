using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class PatientDetailsController : Controller
    {
        // GET: PatientDetails Added by Shital 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PatientDetails()
        {
            return View("PatientRegistration");
        }
    }
}