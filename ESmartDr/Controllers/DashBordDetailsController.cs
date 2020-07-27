using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class DashBordDetailsController : Controller
    {
        // GET: DashBordDetails
        Bal_DashBord BL = new Bal_DashBord();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDashbord()
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                Dashbord LST = new Dashbord();
                LST = BL.ViewDashbord(admObj.HospitalId.ToString());

                int hospitalId;
                // DateTime date = Convert.ToDateTime( Request["txtDate"].ToString());
                hospitalId = admObj.HospitalId;

                ModelState.Clear();
                List<QueueDetails> LST1 = new List<QueueDetails>();
                if (admObj.RoleId == "AHE")
                {
                    int UserId = 99999;
                    LST1 = BL.GetFeatureAppoinmentList(hospitalId, UserId, "NNN");
                }
                if (admObj.RoleId == "ADM")
                {
                    LST1 = BL.GetFeatureAppoinmentList(hospitalId, admObj.UserId, "NNN");
                }
                LST.Qlst = LST1;
                return View("Dashbord", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult ViewFeedback(int hId)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                FeedbackDetails LST = new FeedbackDetails();
                LST = BL.ViewFeedback(admObj.HospitalId);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult GetFeatureAppoinmentList()
        {
            try
            {
                int hospitalId;
                // DateTime date = Convert.ToDateTime( Request["txtDate"].ToString());
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                hospitalId = admObj.HospitalId;
                
                ModelState.Clear();
                List<QueueDetails> LST = new List<QueueDetails>();
                if (admObj.RoleId == "AHE")
                {
                    int UserId = 99999;
                    LST = BL.GetFeatureAppoinmentList(hospitalId, UserId, "NNN");
                }
                if (admObj.RoleId == "ADM")
                {
                    LST = BL.GetFeatureAppoinmentList(hospitalId, admObj.UserId, "NNN");
                }
                return View("Dashbord", LST);

                //return View("PatientAppoinment", LST);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult DeleteAppoinment(int Id, string Note, string CPno, string MbNo)
        {
            Bal_PatientDetails BP = new Bal_PatientDetails();
            SMS sms = new SMS();
            try
            {
                int hospitalId;
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                hospitalId = admObj.HospitalId;

                List<QueueDetails> LST = new List<QueueDetails>();

                LST = BP.DeleteAppoinment(hospitalId, Id, Note, admObj.RoleId);
                if (true)
                {
                    string message = "Your appoinment has been cancellled, CP no: " + CPno + ". Download 'Meet My Doctor' app to manage your health records -  http://esmartdoctor.com";
                    sms.SendSMS(MbNo, message);
                }

               // PatientCount(admObj.HospitalId, admObj.UserId);
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}