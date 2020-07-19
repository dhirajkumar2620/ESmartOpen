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
        BAL_Billing BL = new BAL_Billing();
        // GET: BillingDetails
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManageBilling(BillingDetails BD)
        {
            BAL_MyOPD BM = new BAL_MyOPD();
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            BD.CasePaperNo = patientDETAILS.CasePapaerNo;
            BD.HospitalId = patientDETAILS.HospitalId;
            BD.PatientId = patientDETAILS.Id;
            BD.CreatedBy = patientDETAILS.Id;
            BD.QueueId = patientDETAILS.QueueId;
            int i = BL.ManageBilling(BD);
            BillingDetails bd = new BillingDetails();
            List<BillingDetails> lst = new List<BillingDetails>();
            bd = BM.GetBillingDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
            lst = bd.lst;
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ManageBilling1(List<BillingDetails> item)
        {
            try
            {
                ModelState.Clear();
                BillingDetails b = new BillingDetails();
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
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
                int Flag = 1;//BL.ManageBilling(custDT);
                ModelState.Clear();
                return RedirectToAction("OpdBilling", "MyOPD");
                //return Json("1",JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult DeleteBilling(int Id)
        {
            try
            {
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                List<BillingDetails> lst = new List<BillingDetails>();
                lst = BL.DeleteBilling(Id, patientDETAILS.QueueId);
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult SetBillAmount(float TotalAmt, float Discount, float NetAmt)
        {
            try
            {
                Discount = TotalAmt - NetAmt;
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                List<BillingDetails> lst = new List<BillingDetails>();
                int i = BL.SetBillAmount(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, TotalAmt, Discount, NetAmt, 0);
                return Json(i, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}