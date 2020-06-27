using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsmartDr.Controllers
{
    public class HomeController : Controller
    {
        Bal_PatientDetails PD = new Bal_PatientDetails();
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

        public ActionResult MyOPD(string CPno,int QueueID)
        {

            PatientDetails patientDetails = new PatientDetails();
            patientDetails = PD.GetPatientDetailsByCPno(CPno);
            patientDetails.QueueId = QueueID;
            Session["QueueID"] = QueueID;
            Session["patientDetails"] = patientDetails;
            Session["PatientName"] = patientDetails.PatientName;
            Session["PatientGender"] = patientDetails.Gender;
            Session["CPno"] = CPno;
            DateTime AppoinmentDate = DateTime.Now;
            string dt = AppoinmentDate.ToString("dd/MMM/yyyy");
            Session["AppDate"] = dt;
            if (patientDetails.Age == null || patientDetails.Age == "")
            {
                Session["PatientAge"] = "-";
            }
            else
            {
                Session["PatientAge"] = patientDetails.Age;
            }

            Session["PatientVisit"] = patientDetails.VisitCount;
            if (patientDetails.DueAmount == null || patientDetails.DueAmount == "")
            {
                Session["PatientPrvBalance"] ="0";
            }
            else
            {
                Session["PatientPrvBalance"] = patientDetails.DueAmount;
            }
            if (patientDetails.BloodGroup == null || patientDetails.BloodGroup == "0" || patientDetails.BloodGroup == "Select Blood Group")
            {
                Session["BloodGroup"] = "-";
            }
            else
            {
                Session["BloodGroup"] = patientDetails.BloodGroup;
            }
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
        public ActionResult Error()
        {
            return View("LoginDetails");
        }
        public ActionResult MyOPD1()
        {
            return View("MyOPD1");
        }
    }
}