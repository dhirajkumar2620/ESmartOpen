using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class PrescriptionController : Controller
    {
        // GET: Prescription
        BAL_MyOPD BM = new BAL_MyOPD();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageObservation(Observation Ob)
        {
            ModelState.Clear();
            int Flag = BM.ManageObservationDetails(Ob);
            if (Flag > 0)
            {
                Observation ob = new Observation();
                List<Observation> lstObservation = new List<Observation>();
                ob = BM.GetObservationDetails();
                lstObservation = ob.lst;
                return Json(lstObservation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ManageMedication(Medication Ob)
        {
            ModelState.Clear();
            int Flag = BM.ManageMedicationDetails(Ob);
            if (Flag > 0)
            {
                Medication ob = new Medication();
                List<Medication> lstObservation = new List<Medication>();
                ob = BM.GetMedicationDetails();
                lstObservation = ob.lst;
                return Json(lstObservation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}