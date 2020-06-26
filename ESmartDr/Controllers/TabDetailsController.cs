using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class TabDetailsController : Controller
    {
        // GET: TabDetails
        public ActionResult Index()
        {
            return View();
        }
        BAL_MyOPD BM = new BAL_MyOPD();
        [HttpPost]
        public ActionResult ManageVitalInformation(VitalInformation VI)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            ModelState.Clear();
            VI.HospitalId = patientDETAILS.HospitalId.ToString();
            VI.CreatedBy = admObj.UserId;
            VI.PatientId = patientDETAILS.Id;
            VI.CasePaperNo = patientDETAILS.CasePapaerNo;

            //Ob.CasePaperNo =
            int Flag = BM.ManageVitalInformation(VI);
            if (Flag > 0)
            {
                List<VitalInformation> vi = new List<VitalInformation>();
                VitalInformation v = new VitalInformation();

                vi = BM.GetVitalInformation(patientDETAILS.CasePapaerNo);
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
                    return View("VitalInformation",v);
                    //return RedirectToAction("OpdPrescription", "MyOPD");
                }
                else {
                    return View("VitalInformation");
                }
               
               
            }
            return View("VitalInformation");
        }

        public ActionResult ManageLifeStyleDetails(LifeStyleDetails LD)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            ModelState.Clear();
            LD.HospitalId = patientDETAILS.HospitalId.ToString();
            LD.CreatedBy = admObj.UserId;
            LD.PatientId = patientDETAILS.Id;
            LD.CasePaperNo = patientDETAILS.CasePapaerNo;

            //Ob.CasePaperNo =
            int Flag = BM.ManageLifeStyleDetails(LD);
            if (Flag > 0)
            {
                LifeStyleDetails ob = new LifeStyleDetails();
                List<LifeStyleDetails> lstVI = new List<LifeStyleDetails>();
                ob = BM.GetLifeStyleDetails(patientDETAILS.CasePapaerNo);
                lstVI = ob.lst;
                return Json(lstVI, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ManageMedicalInfoDetails(MedicalInformationDetails MI)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            ModelState.Clear();
            MI.HospitalId = Convert.ToInt16( patientDETAILS.HospitalId);
            MI.CreatedBy = admObj.UserId;
            MI.PatientId = patientDETAILS.Id;
            MI.CasePaperNo = patientDETAILS.CasePapaerNo;

            //Ob.CasePaperNo =
            int Flag = BM.ManageMedicalInfoDetails(MI);
            if (Flag > 0)
            {
                MedicalInformationDetails ob = new MedicalInformationDetails();
                List<MedicalInformationDetails> lstVI = new List<MedicalInformationDetails>();
                ob = BM.GetMedicalInfoDetails(patientDETAILS.CasePapaerNo);
                lstVI = ob.lst;
                return Json(lstVI, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}