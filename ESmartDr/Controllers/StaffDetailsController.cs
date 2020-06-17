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
    public class StaffDetailsController : Controller
    {
        // GET: StaffDetails
        Bal_StaffDetails BP = new Bal_StaffDetails();
        Bal_PatientDetails c = new Bal_PatientDetails();
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

                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                DataSet ds = c.CountForCards(admObj.HospitalId);
                Session["TotalStaffCount"] = ds.Tables[8].Rows[0][0].ToString();
                Session["TotalActiveStaffCount"] = ds.Tables[9].Rows[0][0].ToString();
                Session["TotalInActiveStaffCount"] = ds.Tables[10].Rows[0][0].ToString();

                LST = BP.GetStaffDetails(admObj.HospitalId);
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
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                PD.CreatedBy = admObj.FirstName;
                PD.HospitalId = admObj.HospitalId;
                PD.HostClincName = admObj.HostClincName;
                PD.HospClinicAddess = admObj.HospClinicAddess;
                PD.HospClinicNumber = admObj.HospClinicNumber;
                PD.ParentId = admObj.UserId;
                PD.CreatedBy = admObj.FirstName;
                //string str = admObj.HostClincName.Substring(0, 3);
                //PD.CasePapaerNo = str;
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