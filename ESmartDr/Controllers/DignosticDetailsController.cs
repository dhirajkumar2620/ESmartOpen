using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class DignosticDetailsController : Controller
    {
        // GET: DignosticDetails
        Bal_DignosticDetails BL = new Bal_DignosticDetails();

        public ActionResult DignosticDetails()
        {
            DignosticDetails d = new DignosticDetails();
           // d = BL.GetDignosticDetails(1);
            return View("DignosticDetails",d);
        }
        [HttpPost]
        public ActionResult ManageDignosticDetails(DignosticDetails MD)
        {
            try
            {

                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
                ModelState.Clear();
                MD.HospitalId = Convert.ToInt32(patientDETAILS.HospitalId);
                //MD.cr = admObj.UserId;
                MD.ParientId = patientDETAILS.Id;
                int Flag = BL.ManageDignosticDetails(MD);
                return View("DignosticDetails");
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}