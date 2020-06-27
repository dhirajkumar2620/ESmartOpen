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
    public class Tab_PrecreptionController : Controller
    {
        // GET: Tab_Precreption
      
        
        public ActionResult ViewPreription()
        {
            Bal_Precription bp = new Bal_Precription();
            PatientDetails patientDETAILS = (PatientDetails)Session["patientDetails"];
            Medication MD = new Medication();
            //Load lime always null not requird get data'
            Precription pd = new Precription();
            pd = bp.ViewPricripion(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);

            return View("Examination",pd);
        }
    }
}