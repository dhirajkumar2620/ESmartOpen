using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            Session["date"] = DateTime.Now.ToString("dd/MM/yyyy");
            DayOfWeek wk = DateTime.Today.DayOfWeek;
            Session["wkday"] = wk.ToString();
            Session["RoleId"] = ad.RoleId;
            Session["Msg"] = "0";
            if (ad.UserId.ToString() != null && ad.UserId != 0)
            {
                if (ad.HospClinicLogo =="")
                {
                    Session["LOGO"] = "/img/avatar-1.jpg";
                }
                else
                {
                    Session["LOGO"] = ad.HospClinicLogo;
                }
                Session["UserDetails"] = ad;
                Session["name"] = ad.FirstName;
                Session["degree"] = ad.Education;
                Session["regNo"] = ad.RegNumber;
                Session["Hid"] = ad.HospitalId;
                Session["Hname"] = ad.HostClincName;

                Session["Haddress"] = ad.HospClinicAddess;
                Session["Hnumber"] = ad.WhatsAppNumber;
                Session["HinTime1"] =ad.FirmInTime1;
                Session["HoutTime1"] = ad.FirmOutTime1;
                Session["HinTime2"] = ad.FirmInTime2;
                Session["HoutTime2"] = ad.FirmOutTime2;
                if (string.IsNullOrEmpty(Session["HinTime1"] as string))
                {
                    Session["HinTime1"] = " ";
                }
                
                if (string.IsNullOrEmpty(Session["HoutTime1"] as string))
                {
                    Session["HoutTime1"] = " ";
                }

                if (string.IsNullOrEmpty(Session["HinTime2"] as string))
                {
                    Session["HinTime2"] = " ";
                }
                else
                {
                    string str = Session["HinTime2"].ToString();
                    str = " & "+ str + "";
                    Session["HinTime2"] = str;
                }
                if (string.IsNullOrEmpty(Session["HoutTime2"] as string))
                {
                    Session["HoutTime2"] = " ";
                }
                else
                {
                    string str2 = Session["HoutTime2"].ToString();
                    str2 = " - " + str2 + "";
                    Session["HoutTime2"] = str2;
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
            TempData["notice"] = "Invalid username and password";
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

        public ActionResult ManageEnquiryDetails(string FirstName, string LastName, string ContactNo, string EmailId, string Message)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                Bal_EnquiryDetails BL = new Bal_EnquiryDetails();
                //string str = admObj.HostClincName.Substring(0, 3);
                //PD.CasePapaerNo = str;
                EnquiryDetails ED = new EnquiryDetails();
                ED.Name = FirstName +" " + LastName;
                ED.LastName = LastName;
                ED.ContactNumbar = ContactNo;
                ED.Email = EmailId;
                ED.Note = Message;
                int Flag = BL.ManageEnquiryDetails(ED);
                if (Flag ==1)
                {
                    string ADMContactNo = ConfigurationManager.AppSettings["ADMnumber"];
                    SMS sms = new SMS();
                    sms.SendSMS(ADMContactNo, "Dear Admin, I am  " + FirstName + " " + LastName + " " + ContactNo + " " + EmailId + " " + Message + "");
                }
                return  RedirectToAction("Index", "LoginDetails");
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