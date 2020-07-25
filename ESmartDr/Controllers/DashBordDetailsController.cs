using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class DashBordDetailsController : Controller
    {
        // GET: DashBordDetails
        Bal_DashBord BL = new Bal_DashBord();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDashbord()
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                Dashbord LST = new Dashbord();
                LST = BL.ViewDashbord(admObj.HospitalId.ToString());
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}