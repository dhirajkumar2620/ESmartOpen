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
                MD.HospitalId = admObj.HospitalId;
                int Flag = BL.ManageMedicineDetails(MD);

                MD = BL.ViewAllMedicine(admObj.HospitalId);
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
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                MedicineDetails MD = new MedicineDetails();
                MD = BL.ViewAllMedicine(admObj.HospitalId);
                return View("MedicineDetails", MD);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult DeleteMedicine(int Id)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            MedicineDetails MD = new MedicineDetails();
            // MD = BL.ViewAllMedicine();
            int Flag1 = BL.DeleteMedicine(Id);
            MD = BL.ViewAllMedicine(admObj.HospitalId);

            return View("MedicineDetails", MD);
        }

        public ActionResult GetMedicineById(int Id, int hId)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            MedicineDetails MD = new MedicineDetails();
            MD = BL.ViewAllMedicine(hId);
            if (hId != 0)
            {
                var v = MD.lst.FirstOrDefault(x => x.MedicineId == Id);
                MD.MedicineId = v.MedicineId;
                MD.MedicineName = v.MedicineName;
                MD.MedicineType = v.MedicineType;
                MD.GenericName = v.GenericName;
                MD.CompanyName = v.CompanyName;
                MD.Range = v.Range;
                MD.Other = v.Other;
            }

            return View("MedicineDetails", MD);
        }

    }
}