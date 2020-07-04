using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Data;
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
            Bal_Precription bp= new Bal_Precription ();
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            Precription pd = new Precription();
            pd = bp.ViewPricripion( patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
            return View("Examination", pd);
        }
        public ActionResult OpdHistory()
        {
            HistoryDetails hd = new HistoryDetails();
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            List<HistoryDetails> Ld = new List<HistoryDetails>();
            Ld = BM.GetHistory(patientDETAILS.WhatsAppNo, patientDETAILS.CasePapaerNo);
            hd.lstHD = Ld;
            ////WebHistory Ld = new WebHistory();
            ////Ld = BM.GetWEBHistory(patientDETAILS.CasePapaerNo);
            return View("History",hd);
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

            return View("PrecMedication", MD);
        }
        public ActionResult PatientMedicalDetails()
        {
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            MedicalInformationDetails MD = new MedicalInformationDetails();
            //Load lime always null not requird get data
            MD = BM.GetMedicalInfoDetails(patientDETAILS.CasePapaerNo);

            return View("MedicalInformation", MD);
        }
        public ActionResult PatientLifeStyleDetails()
        {
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            LifeStyleDetails Ls = new LifeStyleDetails();
            //Load lime always null not requird get data
            Ls = BM.GetLifeStyleDetails(patientDETAILS.CasePapaerNo);
            if (Ls.Diat != null)
                Ls.Diat = Ls.Diat.Trim();
            if (Ls.Alcohol != null)
                Ls.Alcohol = Ls.Alcohol.Trim();
            if (Ls.Bladder != null)
                Ls.Bladder = Ls.Bladder.Trim();
            if (Ls.Bowel != null)
                Ls.Bowel = Ls.Bowel.Trim();
            if (Ls.Sleep != null)
                Ls.Sleep = Ls.Sleep.Trim();
            if (Ls.Smoting != null)
                Ls.Smoting = Ls.Smoting.Trim();
            return View("LifeStyle", Ls);
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
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            Common Cm = new Common();
            //Load lime always null not requird get data
            Cm = BM.GetCommonDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
            return View("PrecCommon", Cm);
        }
    }
}