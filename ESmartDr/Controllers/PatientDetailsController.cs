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
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                List<PatientDetails> LST = new List<PatientDetails>();
                LST = BP.GetPatientDetails(admObj.HospitalId);
                return View("AllPatient", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult ManagePatientDetails(PatientDetails PD)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PD.CreatedBy = admObj.FirstName;
                PD.HospitalId = admObj.HospitalId.ToString();
                PD.HospitalName = admObj.HostClincName;
                PD.DoctorReceptionId = admObj.UserId;
                string str = admObj.HostClincName.Substring(0, 3);
                PD.CasePapaerNo = str;
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

        public ActionResult SetPatientAppoinment(int  Id)
        {
            try
            {
                List<PatientDetails> LST = new List<PatientDetails>();
                LST = BP.SetPatientAppoinment(Id);
                return RedirectToAction("GetQueueList", "PatientDetails") ;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult GetQueueList()
        {
            try
            {
                int hospitalId;
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                hospitalId = admObj.HospitalId;
                List<QueueDetails> LST = new List<QueueDetails>();
                LST = BP.GetQueueList(hospitalId);
                return View("PatientAppoinment", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult DeleteAppoinment(int Id)
        {
            try
            {
                int hospitalId;
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                hospitalId = admObj.HospitalId;

                List<QueueDetails> LST = new List<QueueDetails>();
                LST = BP.DeleteAppoinment(hospitalId, Id);
                return View("PatientAppoinment", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}