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
        public ActionResult ViewAllPatient()
        {
            try
            {
                List<PatientDetails> LST = new List<PatientDetails>();
                LST = BP.GetPatientDetails();
                return View("AllPatient", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult s(PatientDetails PD)
        {
            try
            {
                int Flag = BP.ManagePatientDetails(PD);
                return RedirectToAction("ViewAllPatient", "PatientDetails");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult GetDetailsById(int  Id)
        {
            try
            {
                PatientDetails pd = new PatientDetails();
                pd = BP.GetDetailsById(Id);
                pd.BloodGroup.Trim();
                return View("PatientRegistration", pd);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}