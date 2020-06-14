using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class MedicineDetailsController : Controller
    {
        // GET: Created by Dhiraj
        Bal_MedicineDetails BL = new Bal_MedicineDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MedicineDetails()
        {
            return View("MedicineDetails");
        }
        public ActionResult ManageMedicineDetails(MedicineDetails MD)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                MD.CreatedBy = admObj.UserId.ToString();
                int Flag = BL.ManageMedicineDetails(MD);
                
                MD = BL.ViewAllMedicine();
                ModelState.Clear();
                return View("MedicineDetails", MD);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult ViewAllMedicine()
        {
            try
            {
                MedicineDetails MD = new MedicineDetails();
                MD = BL.ViewAllMedicine();
                return View("MedicineDetails", MD);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult DeleteMedicine(int Id)
        {
            MedicineDetails MD = new MedicineDetails();
            // MD = BL.ViewAllMedicine();
            int Flag1 = BL.DeleteMedicine(Id);
            MD = BL.ViewAllMedicine();
           
            return View("MedicineDetails", MD);
        }
    }
}