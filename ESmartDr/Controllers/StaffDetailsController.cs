using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class StaffDetailsController : Controller
    {
        // GET: StaffDetails
        Bal_StaffDetails BP = new Bal_StaffDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StaffDetails()
        {
            return View("StaffRegistration");
        }
        public ActionResult ViewAllStaff()
        {
            try
            {
                List<ReceptionStaffReg> LST = new List<ReceptionStaffReg>();
                LST = BP.GetStaffDetails();
                return View("AllStaff", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult ManageStaffDetails(ReceptionStaffReg PD)
        {
            try
            {
                int Flag = BP.ManageStaffDetails(PD);
                return RedirectToAction("ViewAllStaff", "StaffDetails");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult GetStaffById(int ReceptionId)
        {
            try
            {
                ReceptionStaffReg pd = new ReceptionStaffReg();
                pd = BP.GetStaffDetailsByAdmId(ReceptionId);

                return View("StaffRegistration", pd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}