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
        SMS sms = new SMS();
       

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PatientDetails()
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
           
            IList<AdminDetails> drList = new List<AdminDetails>(); 
            drList = BP.GetDoctorListByHID(admObj.HospitalId).ToList();
            
           ViewBag.Organisations = drList;
            return View("PatientRegistration");
        }

        //public IEnumerable<AdminDetails> GetMobileList()
        //{
        //    AdminDetails admObj = (AdminDetails)Session["UserDetails"];
        //    AdminDetails ad = new AdminDetails();
        //    List<AdminDetails> d = new List<AdminDetails>();
        //    d = BP.GetDoctorListByHID(admObj.HospitalId);
        //    var result = d;
        //    return result;
        //}
        public ActionResult ViewAllPatient()
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                List<PatientDetails> LST = new List<PatientDetails>();
                PatientCount(admObj.HospitalId, admObj.UserId);
                if (admObj.RoleId == "ADM")
                {
                    if (LST.Count > 0)
                    {
                        foreach (var item in LST)
                        {
                            item.CpExpiryDate = Convert.ToDateTime(item.CpExpiryDate).Date.ToString("dd/MM/yyyy");
                        }
                    }
                    LST = BP.GetPatientDetails(admObj.RoleId, admObj.HospitalId, admObj.UserId);
                }
                if (admObj.RoleId == "AHE")
                {
                    foreach (var item in LST)
                    {
                        item.CpExpiryDate = Convert.ToDateTime(item.CpExpiryDate).ToString("dd/MM/yyyy");
                    }
                    LST = BP.GetPatientDetails(admObj.RoleId, admObj.HospitalId, admObj.UserId);
                }


                if (Session["DivViewAllPatient"].ToString() == "true")
                {
                    return View("AllPatient", LST);
                }
                else
                {
                    foreach (var item in LST)
                    {
                        if (item.OtherNo == null)
                        {
                            item.OtherNo = "";
                        }
                        item.CpExpiryDate = Convert.ToDateTime(item.CpExpiryDate).ToString("dd/MM/yyyy");

                    }
                    Session["DivViewAllPatient"] = "true";
                    return Json(LST, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult ManagePatientDetails(PatientDetails PD)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                AdminDetails drObj = new AdminDetails();
                drObj = BP.GetDoctorDetailsById(PD.DoctorReceptionId);
                //Session["DoctorDetails"] = drObj;
                PD.CreatedBy = drObj.FirstName;
                PD.HospitalId = drObj.HospitalId.ToString();
                PD.HospitalName = drObj.HostClincName;
                PD.DoctorReceptionId = drObj.UserId;
                //string str = admObj.HostClincName.Substring(0, 3);
                PD.CasePapaerNo = drObj.AlphanumericPrefix.Trim();
                int Flag = BP.ManagePatientDetails(PD);
                if (Flag != 0)
                {
                    return RedirectToAction("ViewAllPatient", "PatientDetails");
                }
                PatientCount(admObj.HospitalId, admObj.UserId);
                if (PD.Id == 0)
                {
                    List<PatientDetails> LST = new List<PatientDetails>();
                    LST = BP.GetPatientDetails(admObj.RoleId, admObj.HospitalId, admObj.UserId);

                    var CPNo = LST.Where(x
                                 => x.HospitalId == PD.HospitalId
                                 && x.WhatsAppNo == PD.WhatsAppNo
                                 )
                             .OrderByDescending(x => x.Id)
                             .Take(1)
                             .Select(x => x.CasePapaerNo)
                             .ToList()
                             .FirstOrDefault();

                   
                    string message = "You are added to " + admObj.FirstName + ", your CP No. is " + CPNo + ". Download 'Meet My Doctor' app to manage your health records - https://esmartdoctor.com";
                    sms.SendSMS(PD.WhatsAppNo, message);
                }
                Session["Msg"] = "1";
                return RedirectToAction("ViewAllPatient", "PatientDetails");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult GetDetailsById(int Id)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PatientDetails pd = new PatientDetails();
                pd = BP.GetDetailsById(Id);
                IList<AdminDetails> drList = new List<AdminDetails>();
                drList = BP.GetDoctorListByHID(admObj.HospitalId).ToList();
                //pd.DOB = pd.DOB.Substring(0, pd.DOB.IndexOf(" ") + 1).TrimEnd();
                //pd.CpExpiryDate = pd.CpExpiryDate.Substring(0, pd.CpExpiryDate.IndexOf(" ") + 1).TrimEnd();
                ViewBag.Organisations = drList;
                PatientCount(admObj.HospitalId, admObj.UserId);
                return View("PatientRegistration", pd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        public ActionResult SetPatientAppoinment(string CPno, DateTime AppoinmentDate, string AppoinmentTime, string Note)
        {
            try
            {
                //DateTime AppoinmentDate = DateTime.Now;
                ////string dt = AppoinmentDate.ToString("dd/MM/yyyy");
                //string AppoinmentTime = AppoinmentDate.ToString("h:mm");
                //string Note = "Appoinment fixed";
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                List<PatientDetails> LST = new List<PatientDetails>();
                LST = BP.SetPatientAppoinment(CPno, AppoinmentDate, AppoinmentTime, Note);
                //if (LST != null)
                //{
                //    SMS sms = new SMS();
                //    sms.SendSMS(admObj.WhatsAppNumber,"Dear "+admObj.FirstName+", your appoinment booked sucecessfuly "+ AppoinmentDate + " at "+ AppoinmentTime + "against Case Paper no "+ CPno + ", Download app for better helth ...");
                //}
                PatientCount(admObj.HospitalId, admObj.UserId);
                return Json("1", JsonRequestBehavior.AllowGet);
                //return RedirectToAction("GetQueueList", "PatientDetails");
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
               // DateTime date = Convert.ToDateTime( Request["txtDate"].ToString());
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                hospitalId = admObj.HospitalId;
                //cards counts

                PatientCount(hospitalId, admObj.UserId);
                ModelState.Clear();
                List<QueueDetails> LST = new List<QueueDetails>();
                if (admObj.RoleId =="AHE")
                {
                    int UserId = 99999;
                    LST = BP.GetQueueList(hospitalId, UserId ,"XXX");
                }
                if (admObj.RoleId =="ADM")
                {
                    LST = BP.GetQueueList(hospitalId,admObj.UserId ,"XXX");
                }
                
                
                return View("PatientAppoinment", LST);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult QueueList(QueueDetails Ob)
        {
            try
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult GetQueueListByDate(string Date)
        {
            try
            {
                string todaysdate;
                int hospitalId;
                // DateTime date = Convert.ToDateTime( Request["txtDate"].ToString());
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                hospitalId = admObj.HospitalId;
                //cards counts

                PatientCount(hospitalId, admObj.UserId);
                ModelState.Clear();
                List<QueueDetails> LST = new List<QueueDetails>();
                if (admObj.RoleId == "AHE")
                {
                    //todaysdate = DateTime.Now.ToString("yyyy/MM/dd"); ;
                    //if (todaysdate == Date)
                    //{
                    //    return RedirectToAction("GetQueueList", "PatientDetails");
                    //}
                    int UserId = 99999;
                    LST = BP.GetQueueList(hospitalId, UserId, Date);
                }
                if (admObj.RoleId == "ADM")
                {
                    //todaysdate = DateTime.Now.ToString("yyyy/MM/dd"); 
                    //if (todaysdate == Date)
                    //{
                    //    return RedirectToAction("GetQueueList", "PatientDetails");
                    //}
                    LST = BP.GetQueueList(hospitalId, admObj.UserId, Date);

                }

                return Json(LST, JsonRequestBehavior.AllowGet);
                //return View("PatientAppoinment", LST);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult DeleteAppoinment(int Id, string Note ,string CPno, string MbNo)
        {
            try
            {
                int hospitalId;
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                hospitalId = admObj.HospitalId;

                List<QueueDetails> LST = new List<QueueDetails>();
               
                    LST = BP.DeleteAppoinment(hospitalId, Id, Note, admObj.RoleId);
                if (true)
                {
                    string message = "Your appoinment has been cancellled, CP no: " + CPno + ". Download 'Meet My Doctor' app to manage your health records -  https://esmartdoctor.com";
                    sms.SendSMS(MbNo, message);
                }
                
                PatientCount(admObj.HospitalId, admObj.UserId);
                return Json("1", JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult SetStatus(int Qid,string CPno, float Bill, float paidBill, string Status)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                List<PatientDetails> LST = new List<PatientDetails>();
                int flag = BP.SetStatus(Qid, CPno, Bill, paidBill, Status);
                if (flag != 0)
                {
                    return RedirectToAction("GetQueueList", "PatientDetails");
                }
                PatientCount(admObj.HospitalId, admObj.UserId);
                return RedirectToAction("GetQueueList", "PatientDetails");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult SetDueAmount(string CPno, float PaidDue)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                List<PatientDetails> LST = new List<PatientDetails>();
                int flag = BP.SetDueAmount(CPno, PaidDue);
                if (flag != 0)
                {
                    return Json("1", JsonRequestBehavior.AllowGet);

                }

                PatientCount(admObj.HospitalId, admObj.UserId);
                return RedirectToAction("GetQueueList", "PatientDetails");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult SetDueAmountfor(string CPno, float PaidDue)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                List<PatientDetails> LST = new List<PatientDetails>();
                int flag = BP.SetDueAmount(CPno, PaidDue);
                if (flag != 0)
                {
                    Session["DivViewAllPatient"] = "false";
                    // return Json("1", JsonRequestBehavior.AllowGet);
                    return RedirectToAction("ViewAllPatient", "PatientDetails");
                    // return Json(LST, JsonRequestBehavior.AllowGet);
                }

                PatientCount(admObj.HospitalId, admObj.UserId);
                return RedirectToAction("ViewAllPatient", "PatientDetails");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void PatientCount(int Hid , int UserId)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            int flag = 1;
            if (admObj.RoleId == "AHE")
            {
                flag = 2;
            }
            else
            {
                flag = 1;
            }
            DataSet ds = BP.CountForCards(Hid, UserId, flag);
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

        public ActionResult ExportToExcel1(string StartDate, string EndDate)
        {
            try
            {
               
                    Session["StartDate"] = StartDate;
                    Session["EndDate"] = EndDate;
                

                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult ExportToExcel()
        {
            try
            {
                string StartDate = Session["StartDate"].ToString();

                string EndDate = Session["EndDate"].ToString();
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
             
                DataTable dt = sms.Get_ExportToExcel(1,admObj.HospitalId, StartDate, EndDate);
                string attachment = "attachment; filename=Patients Details.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        Response.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
                return View("Layout1");
                //return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult GetData(int Qid, string CPno, float Bill, float paidBill, string Status)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            List<PatientDetails> LST = new List<PatientDetails>();
            if (Status == "With Doctor")
            {
                Status = "1";
            }
            else if (Status == "In Queue")
            {
                Status = "2";
            }
            else
            {
                Status = "3";
            }
            int flag = BP.SetStatus(Qid, CPno, Bill, paidBill, Status);
            if (flag != 0)
            {
                //return RedirectToAction("GetQueueList", "PatientDetails");
            }
            PatientCount(admObj.HospitalId, admObj.UserId);
            //return RedirectToAction("GetQueueList", "PatientDetails");
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SendMessage(string MobNo, string message)
        {
            SMS sms = new SMS();
            sms.SendSMS(MobNo, message);
            return RedirectToAction("ViewAllPatient", "PatientDetails");
        }
            
       
    }
   
}