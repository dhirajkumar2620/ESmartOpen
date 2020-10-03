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

                if (LST.Fedlst.Count > 0)
                {
                    foreach (var item in LST.Fedlst)
                    {
                        item.MedicalExpertise = item.MedicalExpertise + ' '+ item.ListenGiveTime + ' ' + item.Compassionate + ' ' + item.BadBehevior;
                        item.MedicalExpertise= item.MedicalExpertise.TrimEnd(',');
                        item.MedicalExpertise = item.MedicalExpertise.TrimStart(',');

                        if (item.BadBehevior != null)
                        {
                            item.BadBehevior = item.BadBehevior.TrimEnd(',');
                        }

                        item.Dates = item.Date.ToString("dd/MM/yyyy");
                    }
                }
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
            catch (Exception ex)
            {

                throw ex;
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
        [HttpPost]
        public JsonResult ViewDashbord1(string Id)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                Dashbord LST = new Dashbord();
                LST = BL.ViewDashbord(admObj.HospitalId.ToString());

                // var date = LST.d1lst[0].dates.ToShortDateString();

                for (int i = 0; i < LST.d1lst.Count; i++)
                {
                    // LST.d1lst[i].date = LST.d1lst[i].dates.ToShortDateString();
                    LST.d1lst[i].date = LST.d1lst[i].dates.ToString("ddd");
                }

                //var output = JsonConvert.SerializeObject(LST.d1lst); //(LST.d1lst, JsonRequestBehavior.AllowGet);
                return Json(LST.d1lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult IncomeExpensesAnalysis(string Id)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                Dashbord LST = new Dashbord();
                LST = BL.ViewDashbord(admObj.HospitalId.ToString());

                // var date = LST.d1lst[0].dates.ToShortDateString();

                for (int i = 0; i < LST.d2lst.Count; i++)
                {
                    // LST.d1lst[i].date = LST.d1lst[i].dates.ToShortDateString();
                    LST.d2lst[i].date = LST.d2lst[i].dates.ToString("MMM");
                }

                //var output = JsonConvert.SerializeObject(LST.d1lst); //(LST.d1lst, JsonRequestBehavior.AllowGet);
                return Json(LST.d2lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult IncomeExpensesAnalysis3(string Id)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                Dashbord LST = new Dashbord();
                LST = BL.ViewDashbord(admObj.HospitalId.ToString());

                // var date = LST.d1lst[0].dates.ToShortDateString();

                for (int i = 0; i < LST.d3lst.Count; i++)
                {
                    //LST.d1lst[i].date = LST.d1lst[i].dates.ToShortDateString();
                    LST.d3lst[i].date = LST.d3lst[i].dates.ToString("MMM");
                }


                for (int i = 0; i < LST.d1lst.Count; i++)
                {
                    
                    LST.d1lst[i].date = LST.d1lst[i].dates.ToString();
                }


                //var output = JsonConvert.SerializeObject(LST.d1lst); //(LST.d1lst, JsonRequestBehavior.AllowGet);
                return Json(LST.d3lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult IncomeExpensesAnalysis4(string Id)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                Dashbord LST = new Dashbord();
                LST = BL.ViewDashbord(admObj.HospitalId.ToString());

                // var date = LST.d1lst[0].dates.ToShortDateString();

                //for (int i = 0; i < LST.d5lst.Count; i++)
                //{
                //    //LST.d1lst[i].date = LST.d1lst[i].dates.ToShortDateString();
                //    LST.d5lst[i].date = LST.d5lst[i].dates.ToString("ddd");
                //}


                for (int i = 0; i < LST.d5lst.Count; i++)
                {

                    LST.d5lst[i].date= LST.d5lst[i].dates.ToString("ddd");
                }


                //var output = JsonConvert.SerializeObject(LST.d1lst); //(LST.d1lst, JsonRequestBehavior.AllowGet);
                return Json(LST.d5lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}