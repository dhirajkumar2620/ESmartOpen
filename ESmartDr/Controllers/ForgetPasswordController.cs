using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class ForgetPasswordController : Controller
    {
        Bal_AdminDetails BP = new Bal_AdminDetails();
        // GET: ForgetPassword
        public ActionResult Index()
        {
            return View("ForgetPassword");
        }
       
        [HttpPost]
        public ActionResult ForgetPassword(AdminDetails AD)
        {
            List<AdminDetails> LST = new List<AdminDetails>();

            LST = BP.GetAllAdminDetails();
            bool isValidWhatsAppNumber = LST.Any(x => x.WhatsAppNumber == AD.WhatsAppNumber);
            bool isValidEmailId = LST.Any(x => x.EmailId == AD.EmailId);
            if (isValidWhatsAppNumber == true || isValidEmailId == true)
            {
                // set mobile number and Send otp -code 
                string result = SendSMS();
                if (result =="success")
                {
                    Session["OTP"] = "123456";
                    //return RedirectToAction("VerifyOTP", "ForgetPassword");
                    return View("VerifyOTP");
                }
                
               
            }
            else
            {
                ModelState.AddModelError("", "Invalid username ");
            }

            //ModelState.AddModelError("", "Invalid username and password");
            return View("ForgetPassword");
        }

        public string SendSMS()
        {
            String result ="success";
            //string apiKey = "your apiKey";
            //string numbers = "918123456789"; // in a comma seperated list
            //string message = "This is your message";
            //string sender = "TXTLCL";

            //String url = "https://api.textlocal.in/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
            ////refer to parameters to complete correct url string

            //StreamWriter myWriter = null;
            //HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            //objRequest.Method = "POST";
            //objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            //objRequest.ContentType = "application/x-www-form-urlencoded";
            //try
            //{
            //    myWriter = new StreamWriter(objRequest.GetRequestStream());
            //    myWriter.Write(url);
            //}
            //catch (Exception e)
            //{
            //    return e.Message;
            //}
            //finally
            //{
            //    myWriter.Close();
            //}

            //HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            //using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            //{
            //    result = sr.ReadToEnd();
            //    // Close and clean up the StreamReader
            //    sr.Close();
            //}
            return result;
        }

        [HttpPost]
        public ActionResult VerifyOTP(string OTP)
        {
           
            bool result = false;
            string SessionOTP = Session["OTP"].ToString();
           
            OTP = "123456";
            if (OTP == SessionOTP)
            {
                return View("ChangePassword");
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ChangePassword(string Password1 , string password2)
        {

            return RedirectToAction("Index", "LoginDetails");
        }
    }
}