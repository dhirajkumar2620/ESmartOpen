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
                

                VI = BM.GetVitalInformation(patientDETAILS.CasePapaerNo);
                return View("VitalInformation", VI);
                //return RedirectToAction("OpdPrescription", "MyOPD");
            }
            else
            {
                return RedirectToAction("OpdPrescription", "MyOPD");
            }
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
                ob = BM.GetLifeStyleDetails();
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
                ob = BM.GetMedicalInfoDetails();
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