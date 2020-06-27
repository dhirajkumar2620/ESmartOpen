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
        public ActionResult OpdExamination()
        {
            return View("Examination");
        }
        public ActionResult OpdHistory()
        {
            return View("History");
        }
        public ActionResult OpdBilling()
        {
            return View("Billing");
        }


        public ActionResult PrecObservation()
        {
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            Observation ob = new Observation();
            ob = BM.GetObservationDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
            return View("Observation", ob);
           
            
        }
        public ActionResult MedicationPrec()
        {
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            Medication MD = new Medication();
            //Load lime always null not requird get data
            MD = BM.GetMedicationDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
           
            return View("PrecMedication",MD);
        }
        public ActionResult PatientMedicalDetails()
        {
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            Medication MD = new Medication();
            //Load lime always null not requird get data
            MD = BM.GetMedicationDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
           
            return View("MedicalInformation");
        }
        public ActionResult PatientLifeStyleDetails()
        {
            return View("LifeStyle");
        }
        public ActionResult PatientVitalInformation()
        {
            BAL_MyOPD VI = new BAL_MyOPD();
            List<VitalInformation> vi= new List<VitalInformation>();
           VitalInformation v = new VitalInformation();
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            vi = VI.GetVitalInformation(patientDETAILS.CasePapaerNo);


            var viralInfo = vi.FirstOrDefault(x => x.CasePaperNo == patientDETAILS.CasePapaerNo);
            if (viralInfo != null)
            {
                v.BloodPressure = viralInfo.BloodPressure;
                v.Temperature = viralInfo.Temperature;
                v.BloodGlucosePostPrandial = viralInfo.BloodGlucosePostPrandial;
                v.Weight = viralInfo.Weight;
                v.Height = viralInfo.Height;
                v.BloodGlucoseFasting = viralInfo.BloodGlucoseFasting;
                v.BloodlucoseRandom = viralInfo.BloodlucoseRandom;
                v.BloodUrea = viralInfo.BloodUrea;
                v.Creatinine = viralInfo.Creatinine;
                v.UricAcidM = viralInfo.UricAcidM;
                v.HB = viralInfo.HB;
                v.PCV = viralInfo.PCV;
                v.WBCCount = viralInfo.WBCCount;
                v.PlateletCount = viralInfo.PlateletCount;
                v.ESR = viralInfo.ESR;
                v.RBCCount = viralInfo.RBCCount;
                v.MCH = viralInfo.MCH;
                v.MCHC = viralInfo.MCHC;
                v.Lymphocyte = viralInfo.Lymphocyte;
                v.Eosinophil = viralInfo.Eosinophil;
                v.SerumBilirubin = viralInfo.SerumBilirubin;
                v.SGPTALT = viralInfo.SGPTALT;
                v.GGPT = viralInfo.GGPT;
                v.TotalProtein = viralInfo.TotalProtein;
                v.SerumAlbumin = viralInfo.SerumAlbumin;
                v.Globulin = viralInfo.Globulin;
                v.AlkalinePhosphatase = viralInfo.AlkalinePhosphatase;
                v.SGOT = viralInfo.SGOT;
                v.TotalCholesterol = viralInfo.TotalCholesterol;
                v.HDLCholestero = viralInfo.HDLCholestero;
                v.LDLCholesterol = viralInfo.LDLCholesterol;
                v.Triglycerides = viralInfo.Triglycerides;
                v.NonHDL = viralInfo.NonHDL;
                v.HbA1c = viralInfo.HbA1c;
                v.TSH = viralInfo.TSH;
                v.SPO2 = viralInfo.SPO2;
                v.RR = viralInfo.RR;
                v.HeadCircumference = viralInfo.HeadCircumference;
            }
            return View("VitalInformation", viralInfo);
        }

        public ActionResult CommonPrec()
        {
            return View("PrecCommon");
        }
    }
}