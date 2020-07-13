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
    public class BillingDetailsController : Controller
    {
        BAL_MyOPD BL = new BAL_MyOPD();
        // GET: BillingDetails
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManageBilling(List<BillingDetails> item)
        {
            try
            {
                ModelState.Clear();
                BillingDetails b = new BillingDetails();
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                DataTable custDT = new DataTable();
                DataColumn col = null;
                col = new DataColumn("Id");
                custDT.Columns.Add(col);
                col = new DataColumn("ServiceName");
                custDT.Columns.Add(col);
                col = new DataColumn("Bill");
                custDT.Columns.Add(col);
                col = new DataColumn("Paid");
                custDT.Columns.Add(col);
                col = new DataColumn("Balance");
                custDT.Columns.Add(col);
                col = new DataColumn("CasePaperNo");
                custDT.Columns.Add(col);
                col = new DataColumn("HospitalId");
                custDT.Columns.Add(col);
                col = new DataColumn("PatientId");
                custDT.Columns.Add(col);
                col = new DataColumn("CreatedBy");
                custDT.Columns.Add(col);
                col = new DataColumn("QueueId");
                custDT.Columns.Add(col);
                foreach (var Details in item)
                {
                    BillingDetails Bill = new BillingDetails();
                    Details.CasePaperNo = patientDETAILS.CasePapaerNo;
                    Details.HospitalId = patientDETAILS.HospitalId;
                    Details.PatientId = patientDETAILS.Id;
                    Details.CreatedBy = patientDETAILS.Id;
                    Details.QueueId = patientDETAILS.QueueId;
                    custDT.Rows.Add(0, Details.ServiceName, Details.Bill, Details.Paid, Details.Balance, Details.CasePaperNo, Details.HospitalId, Details.PatientId, Details.CreatedBy, Details.QueueId);
                }
                int Flag = BL.ManageBilling(custDT);
                ModelState.Clear();
                //return RedirectToAction("OpdBilling", "MyOPD");
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult SetStatus( string Status)
        {
            try
            {
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                List<PatientDetails> LST = new List<PatientDetails>();
                int flag = BL.SetStatus(patientDETAILS.QueueId, Status);
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
        public void PatientCount(int Hid, int UserId)
        {
            Bal_PatientDetails BP = new Bal_PatientDetails();
            DataSet ds = BP.CountForCards(Hid, UserId);
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