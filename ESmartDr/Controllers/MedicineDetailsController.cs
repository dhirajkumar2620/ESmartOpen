﻿using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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

        [HttpPost]
        public JsonResult GetMedicineName(string str)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            MedicineDetails MD = new MedicineDetails();
            MD = BL.ViewAllMedicine(admObj.HospitalId);
            var mName = (from x in MD.lst where x.MedicineName.StartsWith(str) select new { label = x.MedicineName }).ToList();
            return Json(mName);
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


        [HttpPost]
        public ActionResult Import(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });
            if (importFile.ContentLength == 0) return Json(new { Status = 0, Message = "Empty File Selected" });


            try
            {
                var recordsImported = BL.ImportAll(importFile.InputStream);
                return Json(new { Status = 1, Message = string.Format("File Imported {0} records successfully ", recordsImported) });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }
    }
}