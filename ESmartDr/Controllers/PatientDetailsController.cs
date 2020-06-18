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


                DataSet ds = BP.CountForCards(admObj.HospitalId);
                Session["TotalPatientCount"] = ds.Tables[3].Rows[0][0].ToString();
                Session["TodaysNewPatientCount"] = ds.Tables[4].Rows[0][0].ToString();
                //Session["YesterdayPatients"] = ds.Tables[2].Rows[0][0].ToString();


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
                PD.CreatedBy = admObj.FirstName ;
                PD.HospitalId = admObj.HospitalId.ToString();
                PD.HospitalName = admObj.HostClincName;
                PD.DoctorReceptionId = admObj.UserId;
                //string str = admObj.HostClincName.Substring(0, 3);
                PD.CasePapaerNo = admObj.AlphanumericPrefix;
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
                //cards counts
                DataSet ds = BP.CountForCards(hospitalId);
                Session["TodayAppointment"] = ds.Tables[0].Rows[0][0].ToString();
                Session["TodayNewPatient"] = ds.Tables[1].Rows[0][0].ToString();
                Session["YesterdayPatients"] = ds.Tables[2].Rows[0][0].ToString();

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

        public string CalculateYourAge(DateTime Dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            Years, Months, Days, Hours, Seconds);
        }
    }
}