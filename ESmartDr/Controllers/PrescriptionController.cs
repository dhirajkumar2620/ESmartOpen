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
                ob = BM.GetObservationDetails(patientDETAILS.QueueId,patientDETAILS.CasePapaerNo);
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
                ob = BM.GetMedicationDetails(patientDETAILS.QueueId,patientDETAILS.CasePapaerNo);
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
            co.QueueId = patientDETAILS.QueueId;
            co.HospitalId = patientDETAILS.HospitalId.ToString();
            co.CreatedBy = admObj.UserId.ToString();
            co.PatientId = patientDETAILS.Id.ToString();
            co.CasePaperNo = patientDETAILS.CasePapaerNo;
            int Flag = BM.ManagePrecCommonDetails(co);
            if (Flag > 0)
            {
                Common ob = new Common();
                List<Common> lstObservation = new List<Common>();
                ob = BM.GetCommonDetails(patientDETAILS.QueueId,patientDETAILS.CasePapaerNo);
                lstObservation = ob.lst;
                return Json(lstObservation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult ViewPricripion(int QueueId, string CPno)
        //{
        //    try
        //    {
        //        Bal_Precription p = new Bal_Precription();
        //        AdminDetails admObj = (AdminDetails)Session["UserDetails"];
        //        Precription pd = new Precription();
        //        pd = p.ViewPricripion(QueueId, CPno);

        //        return View("Examination",pd);//, pd);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult StatusChange()
        {
            try
            {
                PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
                int flag = BM.Set_SatatusFlag(patientDETAILS.QueueId,patientDETAILS.CasePapaerNo);
                if (flag != 0)
                {
                    return RedirectToAction("OpdExamination", "MyOPD");
                }
               
                return RedirectToAction("OpdPrescription", "MyOPD");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult  DeleteObservation(int Id)
        {
            try
            {
                BAL_MyOPD BL = new BAL_MyOPD();
                List<Observation> LST = new List<Observation>();
                LST = BL.DeleteObservation(Id);
               
                return View("PatientAppoinment", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult DeleteMedication(int Id)
        {
            try
            {
                BAL_MyOPD BL = new BAL_MyOPD();
                List<Medication> LST = new List<Medication>();
                LST = BL.DeleteMedication(Id);

                return View("PatientAppoinment", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult DeleteCommon(int Id)
        {
            try
            {
                BAL_MyOPD BL = new BAL_MyOPD();
                List<Common> LST = new List<Common>();
                LST = BL.DeleteCommon(Id);

                return View("PatientAppoinment", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}