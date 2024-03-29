﻿using App_Layer;
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
                if (AD.WhatsAppNumber ==null)
                {
                    AD.WhatsAppNumber = Session["NoForChangePassword"].ToString();
                }
                Session["NoForChangePassword"]= AD.WhatsAppNumber;
                // set mobile number and Send otp -code 
                String otp =RandomOTP();
                int flag = BP.SetOTPForUser(AD.WhatsAppNumber, otp);
                SMS sms = new SMS();
                //string message = "Dear Customer, " + otp + " is OTP for your request initiated through eSmartDoctor. DO NOT disclose it to anyone.";
                string message = "Dear Customer, your OTP for esmartdoctor.com login is  " + otp + ". Do not disclose it to anyone - TECHBULB";

                sms.SendOTP(AD.WhatsAppNumber, message);
               
                    Session["OTP"] = otp;
                    //return RedirectToAction("VerifyOTP", "ForgetPassword");
                    return View("VerifyOTP");
               
                
               
            }
            else
            {
                TempData["notice"] = "Invalid mobile number";
            }

            //ModelState.AddModelError("", "Invalid username and password");
            return View("ForgetPassword");
        }
        public string RandomOTP()
        {

            Random generator = new Random();
            String newOTP = generator.Next(0, 999999).ToString("D6");
            return newOTP;
        }
        public string SendSMS()
        {
            //SMS sms = new SMS();
            //string message = "You are added to " + PD.HostClincName + ", Download eSmartDoctor app to manage - http://bit.ly/2RGTEHTR ";
            //sms.SendSMS(PD.WhatsAppNumber, message);
            return "";
        }

        [HttpPost]
        public ActionResult VerifyOTP(AdminDetails AD)
        {
           
            
            string SessionOTP = Session["OTP"].ToString();
           
            if (AD.WhatsAppNumber == SessionOTP)
            {
                return View("ChangePassword");
            }
            else
            {
                TempData["noticeOTP"] = "Invalid OTP.";
            }
            return View("VerifyOTP");
        }

        [HttpPost]
        public ActionResult ChangePassword(AdminDetails ad)
        {
            if (ad.Passwod1 == ad.OtherNumber)
            {
                string mobileNo = Session["NoForChangePassword"].ToString();
                ad.WhatsAppNumber = mobileNo;
                int Flag = BP.UpdatePassword(ad);
                if (Flag >=1)//if (Flag ==1)
                {
                    SMS sms = new SMS();
                    //string message = "Dear , You are password has been updatedd successfully Username : "+ad.WhatsAppNumber+" & Password: "+ad.Passwod1+" .Download eSmartDoctor app to manage your Firm -  http://esmartdoctor.com ";
                    string message = "Dear Customer, this is to inform you that your password of esmartdoctor.com is updated successfully. Username : "+ad.WhatsAppNumber+" & Password : " +ad.Passwod1+" - TECHBULB";
                    sms.SendSMS(ad.WhatsAppNumber , message);
                    return RedirectToAction("Index", "LoginDetails");
                }
                
            }
            else
            {
                TempData["noticeCP"] = "Password & confirm Password should be same.";
               
            }
            return View("ChangePassword");
        }
        
        public ActionResult ResendOTP()
        {
            List<AdminDetails> LST = new List<AdminDetails>();
            string mbNO = Session["NoForChangePassword"].ToString();
            LST = BP.GetAllAdminDetails();
            bool isValidWhatsAppNumber = LST.Any(x => x.WhatsAppNumber == mbNO);
            bool isValidEmailId = LST.Any(x => x.EmailId == mbNO);
            if (isValidWhatsAppNumber == true || isValidWhatsAppNumber == true)
            {
                // set mobile number and Send otp -code 
                String otp = RandomOTP();
                int flag = BP.SetOTPForUser(mbNO, otp);
                SMS sms = new SMS();
                //  string message = "Dear Customer, " + otp + " is OTP for your request initiated through eSmartDoctor. DO NOT disclose it to anyone.";
                string message = "Dear Customer, your OTP for esmartdoctor.com login is  " + otp + ". Do not disclose it to anyone - TECHBULB";
                
                sms.SendOTP(mbNO, message);

                Session["OTP"] = otp;
                //ViewBag.Visibility = true;
                TempData["noticeOTP"] = "OTP send sucessfully";
                return View("VerifyOTP");
               
            }
            else
            {
                ModelState.AddModelError("", "OTP send sucessfully");
            }

            //ModelState.AddModelError("", "Invalid username and password");
            return View("VerifyOTP");
        }
    }
}