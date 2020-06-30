using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
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
        public ActionResult ManageBilling(BillingDetails BD)
        {
            try
            {

                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
                BD.CasePaperNo = patientDETAILS.CasePapaerNo;
                BD.HospitalId = admObj.HospitalId.ToString();
                BD.PatientId = admObj.UserId;
                BD.CreatedBy = admObj.UserId;
                BD.QueueId = patientDETAILS.QueueId;
                int Flag = BL.ManageBilling(BD);

              
                return View("MedicineDetails");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}