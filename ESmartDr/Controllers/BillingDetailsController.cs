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
        public JsonResult ManageBilling(List<BillingDetails> item)
        {
            try
            {
                BillingDetails b = new BillingDetails();
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
                if (item == null)
                {
                    item = new List<BillingDetails>();
                }

                //Loop and insert records.
                foreach (BillingDetails customer in item)
                {
                    b.lst.Add(customer);
                }
               
               
                int Flag = BL.ManageBilling(b);
                return Json(Flag);

              
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}