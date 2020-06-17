﻿using App_Layer;
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
                Session["Hid"] = ad.HospitalId;
                Session["Hname"] = ad.HostClincName;

                Session["Haddress"] = ad.HospClinicAddess;
                Session["Hnumber"] = ad.WhatsAppNumber;
                Session["HinTime"] =ad.FirmInTime;

                if (string.IsNullOrEmpty(Session["HinTime"] as string))
                {
                    Session["HinTime"] = "10:00";
                }
                Session["HoutTime"] = ad.FirmOutTime;
                if (string.IsNullOrEmpty(Session["HoutTime"] as string))
                {
                    Session["HoutTime"] = "07:00";
                }
                Session["Holiday"] = ad.Holiday;
                if (string.IsNullOrEmpty(Session["Holiday"] as string))
                {
                    Session["Holiday"] = "Non";
                }
                //Session["Photo"] = ad.HospClinicLogo;
                Session["Id"] = ad.UserId;
                FormsAuthentication.SetAuthCookie(AD.WhatsAppNumber, false);
                return RedirectToAction("GetQueueList", "PatientDetails");
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

        public ActionResult ManageEnquiryDetails(EnquiryDetails ED)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                Bal_EnquiryDetails BL = new Bal_EnquiryDetails();
                //string str = admObj.HostClincName.Substring(0, 3);
                //PD.CasePapaerNo = str;
                int Flag = BL.ManageEnquiryDetails(ED);
                return RedirectToAction("Index", "LoginDetails");
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