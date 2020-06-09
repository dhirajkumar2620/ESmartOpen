using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class AdminDetailsController : Controller
    {
        // GET: AdminDetails Added by Dhiraj 
        Bal_AdminDetails BP = new Bal_AdminDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminDetails()
        {
            return View("AdminRegistration");
        }
        public ActionResult ManageAdminDetails(AdminDetails AD)
        {
            try
            {
                int Flag = BP.ManagePatientDetails(AD);
                return View("AdminRegistration");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
