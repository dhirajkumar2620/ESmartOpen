using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class MyOPDController : Controller
    {
        // GET: MyOPD
        BAL_MyOPD BM = new BAL_MyOPD();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Observation(Observation Ob)
        {
            try
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult OpdPrescription()
        {
            return View("Prescription");
        }
        public ActionResult OpdPatientDetails()
        {
            return View("PatientDetails");
        }
        public ActionResult PrecObservation()
        {
            Observation ob = new Observation();
            ob= BM.GetObservationDetails();
            return View("Observation", ob);
        }
        public ActionResult MedicationPrec()
        {
            Medication MD = new Medication();
            MD = BM.GetMedicationDetails();
            return View("PrecMedication", MD);
        }
        public ActionResult PatientMedicalDetails()
        {
            return View("MedicalInformation");
        }
        public ActionResult PatientLifeStyleDetails()
        {
            return View("LifeStyle");
        }
        public ActionResult PatientVitalInformation()
        {
            return View("VitalInformation");
        }
        
        public ActionResult CommonPrec()
        {
            return View("PrecCommon");
        }
    }
}