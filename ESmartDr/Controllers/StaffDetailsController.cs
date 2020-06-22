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
                if (admObj.ParentId == 0)
                {
                    StaffCount(admObj.HospitalId);
                   
                    int HId = 0;
                    LST = BP.GetStaffDetails(HId);
                }
                else
                {
                    StaffCount(admObj.HospitalId);
                   
                    LST = BP.GetStaffDetails(admObj.HospitalId);
                }
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
                if (Flag != 1)
                {
                    return View();
                }
               
                StaffCount(admObj.HospitalId);
                if (PD.ReceptionId == 0)
                {
                    //List<ReceptionStaffReg> LST = new List<ReceptionStaffReg>();
                    //LST = BP.GetStaffDetails(admObj.HospitalId);

                    //var StaffRegNo = LST.Where(x
                    //             => x.HospitalId == PD.HospitalId
                    //             && x.WhatsAppNumber == PD.WhatsAppNumber
                    //              && x.Name == PD.Name
                    //             )
                    //         .OrderByDescending(x => x.Id)
                    //         .Take(1)
                    //         .Select(x => x.CasePapaerNo)
                    //         .ToList()
                    //         .FirstOrDefault();


                    SMS sms = new SMS();
                    string message = "Dear "+PD.Name+", You are added to  " + admObj.HostClincName + ", Download eSmartDoctor app to manage - http://bit.ly/2RGTEHTR ";
                    sms.SendSMS(PD.WhatsAppNumber, message);
                }
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
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                ReceptionStaffReg pd = new ReceptionStaffReg();
                pd = BP.GetStaffDetailsByAdmId(ReceptionId);
                StaffCount(admObj.HospitalId);
                return View("StaffRegistration", pd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void StaffCount(int Hid)
        {
            DataSet ds = c.CountForCards(Hid);
            if (ds.Tables[8].Rows[0][0].ToString() == null)
            {
                Session["TotalStaffCount"] = "0";
            }
            else
            {
                Session["TotalStaffCount"] = ds.Tables[8].Rows[0][0].ToString();
            }

            if (ds.Tables[9].Rows[0][0].ToString() == null)
            {
                Session["TotalActiveStaffCount"] = "0";
            }
            else
            {
                Session["TotalActiveStaffCount"] = ds.Tables[9].Rows[0][0].ToString();
            }

            if (ds.Tables[10].Rows[0][0].ToString() =="0" || ds.Tables[10].Rows[0][0].ToString() == null)
            {
                Session["TotalInActiveStaffCount"] = "0";
            }
            else
            {
                Session["TotalInActiveStaffCount"] = ds.Tables[10].Rows[0][0].ToString();
            }
        }
        
    }
}