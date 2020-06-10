using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class LaboratoryDetailsController : Controller
    {
        // GET: LaboratoryDetails
        // GET: DignosticDetails
        Bal_LaboratoryDetails BL = new Bal_LaboratoryDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LaboratoryDetails()
        {
            return View("LaboratoryDetails");
        }
        public ActionResult ManageMedicineDetails(LaboratoryDetails LD)
        {
            try
            {
                int Flag = BL.ManageLaboratoryDetails(LD);
                return View("LaboratoryDetails");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}