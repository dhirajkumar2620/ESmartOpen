using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
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
                ob = BM.GetObservationDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
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
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
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
                ob = BM.GetMedicationDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
                lstObservation = ob.lst;
                return Json(lstObservation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ManagePrecCommonDetails(Common co, HttpPostedFileBase imgfile)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            ModelState.Clear();
            co.QueueId = patientDETAILS.QueueId;
            co.HospitalId = patientDETAILS.HospitalId.ToString();
            co.CreatedBy = admObj.UserId.ToString();
            co.PatientId = patientDETAILS.Id.ToString();
            co.CasePaperNo = patientDETAILS.CasePapaerNo;
            

            if (imgfile.FileName!="")
            {
              
                string path;
                string extension = Path.GetExtension(imgfile.FileName);
                string impPath = ConfigurationManager.AppSettings["HistoryDoc"];
                path = Path.Combine(Server.MapPath(impPath), Path.GetFileName(imgfile.FileName));
                imgfile.SaveAs(path);
                co.FileName = imgfile.FileName;
                // path = "/UploadImage/" + Path.GetFileName(imgfile.FileName);
            }
            else
            {
                co.FileName = "";
            }


            int Flag = BM.ManagePrecCommonDetails(co);
            if (Flag > 0)
            {
                Common ob = new Common();
                List<Common> lstObservation = new List<Common>();
                ob = BM.GetCommonDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
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
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                int flag = BM.Set_SatatusFlag(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
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
        public ActionResult DeleteObservation(int Id)
        {
            try
            {
                BAL_MyOPD BL = new BAL_MyOPD();
                List<Observation> LST = new List<Observation>();
                LST = BL.DeleteObservation(Id);

                return Json(LST, JsonRequestBehavior.AllowGet);
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
                return Json(LST, JsonRequestBehavior.AllowGet);
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
                return Json(LST, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            //Note : you can bind same list from database  
            List<City> ObjList = new List<City>()
            {

                new City {Id=1,CityName="Latur" },
                new City {Id=2,CityName="Mumbai" },
                new City {Id=3,CityName="Pune" },
                new City {Id=4,CityName="Delhi" },
                new City {Id=5,CityName="Dehradun" },
                new City {Id=6,CityName="Noida" },
                new City {Id=7,CityName="New Delhi" }

        };
            //Searching records from list using LINQ query  
            var CityList = (from N in ObjList
                            where N.CityName.StartsWith(Prefix)
                            select new { N.CityName });
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }

    }
}
public class City
{
    public int Id { get; set; }
    public string CityName { get; set; }

}