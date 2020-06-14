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

        [HttpPost]
        public ActionResult Login(AdminDetails AD)
        {
            AdminDetails ad = new AdminDetails();
            ad = BP.GetLoginUserDetails(AD);
        
            if (ad.UserId.ToString() != null && ad.UserId != 0)
            {
                Session["UserDetails"] = ad;
                Session["name"] = ad.FirstName;
                Session["degree"] = ad.Education;
                Session["regNo"] = ad.RegNumber;
                //Session["Photo"] = ad.HospClinicLogo;
                Session["Id"] = ad.UserId;
                FormsAuthentication.SetAuthCookie(AD.WhatsAppNumber, false);
                return RedirectToAction("Apoinment", "Home");
               // return RedirectToAction("ViewAllPatient", "PatientDetails");
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

        //public ActionResult ForgetPassword()
        //{
        //    return View("ForgetPassword");
        //}
        //[HttpPost]
        //public ActionResult ForgetPassword1(AdminDetails AD)
        //{
        //    List<AdminDetails> LST = new List<AdminDetails>();

        //    LST = BP.GetAllAdminDetails();
        //    bool isValidWhatsAppNumber = LST.Any(x => x.WhatsAppNumber == AD.WhatsAppNumber );
        //    bool isValidEmailId = LST.Any(x => x.EmailId == AD.EmailId);
        //    if (isValidWhatsAppNumber ==true || isValidWhatsAppNumber ==true)
        //    {
        //        // set mobile number and Send otp -code 
        //        ViewBag.Visibility = true;
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid username ");
        //    }

        //    ModelState.AddModelError("", "Invalid username and password");
        //    return View("LoginDetails");
        //}
    }
}