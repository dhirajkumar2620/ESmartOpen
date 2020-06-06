using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsmartDr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("LogIn");
           
        }

        public ActionResult Registration()
        {
            return View("Registration");
        }

         public ActionResult StaffRegistration()
        {
            return View("StaffRegistration");
        }
        public ActionResult PatientRegistration()
        {
            return View("PatientRegistration");
        }

        public ActionResult MyOPD()
        {
            return View("MyOPD");
        }
        public ActionResult AddMedicine()
        {
            return View("AddMedicine");
        }
        public ActionResult CampaignMaster()
        {
            return View("CampaignMaster");
        }
        public ActionResult Apoinment()
        {
            return View("Apoinment");
        }
        public ActionResult AllPatient()
        {
            return View("AllPatient");
        }
        public ActionResult AdminManagement()
        {
            return View("AdminManagement"); 
        }
        public ActionResult ReceptionManagement()
        {
            return View("ReceptionManagement"); 
        }
        public ActionResult Lab1()
        {
            return View("Lab1");
        }
        public ActionResult Lab2()
        {
            return View("Lab2");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}