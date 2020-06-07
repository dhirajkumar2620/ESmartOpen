using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class PatientDetailsController : Controller
    {
        // GET: PatientDetails Added by Shital 
        Bal_PatientDetails BP = new Bal_PatientDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PatientDetails()
        {
            return View("PatientRegistration");
        }
        public ActionResult ManagePatientDetails(PatientDetails PD)
        {
            try
            {
                int Flag = BP.ManagePatientDetails(PD);
                return View("PatientRegistration");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}