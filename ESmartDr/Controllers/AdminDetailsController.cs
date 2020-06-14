using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class AdminDetailsController : Controller
    {
        // GET: AdminDetails Added by Dhiraj 
        Bal_AdminDetails BP = new Bal_AdminDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminDetails()
        {
            
            return View("AdminRegistration");
        }

        public ActionResult ViewAllAdmin()
        {
            try
            {
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails();
                return View("AllAdmin", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult CheckMailId(string Input)
        {
            try
            {
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails();
                bool Email = LST.Any(cus => cus.EmailId == Input);
                int i = 0;
                if (Email)
                {
                    i = 1;
                }
                else {

                }
                return Json(i, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult CheckMobile(string Input)
        {
            try
            {
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails();
                bool Mobile = LST.Any(cus => cus.WhatsAppNumber == Input);
                int i = 0;
                if (Mobile)
                {
                    i = 1;
                }
                else
                {

                }
                return Json(i, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult ManageAdminDetails(AdminDetails AD)
        {
            try
            {
                int Flag = BP.ManagePatientDetails(AD);
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails();
                return View("AllAdmin", LST);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult GetAdminById(int UserId)
        {
            try
            {
                AdminDetails pd = new AdminDetails();
                pd = BP.GetAdminById(UserId);
               
                return View("AdminRegistration", pd);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
