using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ESmartDr.Controllers
{
    public class LoginDetailsController : Controller
    {
        Bal_AdminDetails BP = new Bal_AdminDetails();
        // GET: LoginDetails
        public ActionResult Index()
        {
            return View("LoginDetails");
        }
        //[HttpPost]
        //public ActionResult User(AdminDetails AD)
        //{
        //    List<AdminDetails> LST = new List<AdminDetails>();

        //    LST = BP.GetAllAdminDetails();
        //    bool isValid = LST.Any(x => x.WhatsAppNumber == AD.WhatsAppNumber && x.Passwod1 == AD.Passwod1);
        //    if (isValid)
        //    {
               
        //    var user = LST.Where(x => x.UserId == AD.UserId);
                
        //        FormsAuthentication.SetAuthCookie(AD.WhatsAppNumber, false);
        //        return RedirectToAction("ViewAllPatient","PatientDetails");
        //    }
            
        //    ModelState.AddModelError("", "Invalid username and password");
        //    return View("LoginDetails");
        //}

        [HttpPost]
        public ActionResult Login(AdminDetails AD)
        {
            AdminDetails ad = new AdminDetails();
            ad = BP.GetLoginUserDetails(AD);
        
            if (ad.UserId.ToString() != null && ad.UserId != 0)
            {
                Session["UserDetails"] = ad;
                FormsAuthentication.SetAuthCookie(AD.WhatsAppNumber, false);
                return RedirectToAction("ViewAllPatient", "PatientDetails");
            }

            ModelState.AddModelError("", "Invalid username and password");
            return View("LoginDetails");
        }
        public ActionResult ViewAllAdmin()
        {
            try
            {
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails();
                return View("AllPatient", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}