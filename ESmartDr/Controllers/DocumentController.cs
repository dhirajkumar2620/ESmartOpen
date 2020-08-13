using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class DocumentController : Controller
    {

        Bal_ExpensesDetails BL = new Bal_ExpensesDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDocument()
        {
            AdminDetails objAdminDetails = new AdminDetails();
           // objAdminDetails.FirstName = Session["name"].ToString();

            AdminDetails admObj = (AdminDetails)Session["User"];

            objAdminDetails.HostClincName = admObj.HostClincName;
            objAdminDetails.FirstName = admObj.FirstName;
            objAdminDetails.HospClinicAddess = admObj.HospClinicAddess;
            objAdminDetails.Holiday = admObj.Holiday;
            objAdminDetails.FirmInTime1 = admObj.FirmInTime1 + " : " + admObj.FirmOutTime1 + "-" + admObj.FirmInTime2 + " : " + admObj.FirmOutTime2;
            objAdminDetails.OtherNumber = admObj.HospClinicNumber + "" + admObj.OtherNumber;
            if (admObj.HospClinicNumber != null)

            {
                objAdminDetails.HospClinicNumber = admObj.HospClinicNumber;
            }
            else
            {
                objAdminDetails.HospClinicNumber = admObj.OtherNumber;
            }



            objAdminDetails.FirstName = admObj.FirstName;
            objAdminDetails.Education = admObj.Education;
            objAdminDetails.RegNumber = admObj.RegNumber;
            objAdminDetails.Speciality = admObj.Speciality;


            objAdminDetails.WhatsAppNumber = admObj.WhatsAppNumber;












            return View("Document", objAdminDetails);
        }

       
    }
}