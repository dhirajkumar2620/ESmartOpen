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

                PatientCount(admObj.HospitalId);
               

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
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PatientDetails pd = new PatientDetails();
                pd = BP.GetDetailsById(Id);
                pd.BloodGroup.Trim();
                PatientCount(admObj.HospitalId);
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
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                List<PatientDetails> LST = new List<PatientDetails>();
                LST = BP.SetPatientAppoinment(Id);
                PatientCount(admObj.HospitalId);
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
               
                PatientCount(hospitalId);

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
                PatientCount(admObj.HospitalId);
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

        public void PatientCount(int Hid)
        {
            DataSet ds = BP.CountForCards(Hid);
            if (ds.Tables[0].Rows[0][0].ToString() == null)
            {
                Session["TodayAppointment"] = "0";
            }
            else
            {
                Session["TodayAppointment"] = ds.Tables[0].Rows[0][0].ToString();
            }

            if (ds.Tables[1].Rows[0][0].ToString() == null)
            {
                Session["TodayNewPatient"] = "0";
            }
            else
            {
                Session["TodayNewPatient"] = ds.Tables[1].Rows[0][0].ToString();
            }

            if (ds.Tables[2].Rows[0][0].ToString() == null)
            {
                Session["YesterdayPatients"] = "0";
            }
            else
            {
                Session["YesterdayPatients"] = ds.Tables[2].Rows[0][0].ToString();
            }
            if (ds.Tables[3].Rows[0][0].ToString() == null)
            {
                Session["TotalPatientCount"] = "0";
            }
            else
            {
                Session["TotalPatientCount"] = ds.Tables[3].Rows[0][0].ToString();
            }
            if (ds.Tables[4].Rows[0][0].ToString() == null)
            {
                Session["TodaysNewPatientCount"] = "0";
            }
            else
            {
                Session["TodaysNewPatientCount"] = ds.Tables[4].Rows[0][0].ToString();
            }

        }
    }

}