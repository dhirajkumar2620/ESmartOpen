using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class PrescriptionController : Controller
    {
       
        // GET: Prescription
        BAL_MyOPD BM = new BAL_MyOPD();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageObservation(Observation Ob)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            ModelState.Clear();
            Ob.QueueId = patientDETAILS.QueueId;
            Ob.HospitalId = patientDETAILS.HospitalId.ToString();
            Ob.CreatedBy = admObj.UserId.ToString();
            Ob.PatientId = patientDETAILS.Id.ToString();
            Ob.CasePaperNo = patientDETAILS.CasePapaerNo;

            //Ob.CasePaperNo =
            int Flag = BM.ManageObservationDetails(Ob);
            if (Flag > 0)
            {
                Observation ob = new Observation();
                List<Observation> lstObservation = new List<Observation>();
                ob = BM.GetObservationDetails();
                lstObservation = ob.lst;
                return Json(lstObservation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ManageMedication(Medication Ob)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            Ob.QueueId = patientDETAILS.QueueId;
            Ob.HospitalId = patientDETAILS.HospitalId.ToString();
            Ob.CreatedBy = admObj.UserId.ToString();
            Ob.PatientId = patientDETAILS.Id.ToString();
            Ob.CasePaperNo = patientDETAILS.CasePapaerNo;
            ModelState.Clear();
            int Flag = BM.ManageMedicationDetails(Ob);
            if (Flag > 0)
            {
                Medication ob = new Medication();
                List<Medication> lstObservation = new List<Medication>();
                ob = BM.GetMedicationDetails();
                lstObservation = ob.lst;
                return Json(lstObservation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ManagePrecCommonDetails(Common co)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            ModelState.Clear();
            Ob.QueueId = patientDETAILS.QueueId;
            co.HospitalId = patientDETAILS.HospitalId.ToString();
            co.CreatedBy = admObj.UserId.ToString();
            co.PatientId = patientDETAILS.Id.ToString();
            co.CasePaperNo = patientDETAILS.CasePapaerNo;
            int Flag = BM.ManagePrecCommonDetails(co);
            if (Flag > 0)
            {
                Common ob = new Common();
                List<Common> lstObservation = new List<Common>();
                ob = BM.GetCommonDetails();
                lstObservation = ob.lst;
                return Json(lstObservation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}