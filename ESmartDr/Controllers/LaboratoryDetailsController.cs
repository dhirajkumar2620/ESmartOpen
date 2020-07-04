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
            LaboratoryDetails L = new LaboratoryDetails();
            return View("LaboratoryDetails",L);
        }
        public ActionResult ManageLaboratoryDetails(LaboratoryDetails LD)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
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