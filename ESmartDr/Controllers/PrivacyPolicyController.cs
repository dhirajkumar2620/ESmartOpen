using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        // GET: PrivacyPolicy
        public ActionResult Index()
        {
            return View("PrivacyPolicy");
        }
        public ActionResult GetPolicy()
        {
            return View("PrivacyPolicy");
        }
    }
}