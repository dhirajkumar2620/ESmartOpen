﻿using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class DignosticDetailsController : Controller
    {
        // GET: DignosticDetails
        Bal_DignosticDetails BL = new Bal_DignosticDetails();
       
        public ActionResult DignosticDetails( )
        {
           
            return View("DignosticDetails");
        }
        [HttpPost]
        public ActionResult ManageDignosticDetails(DignosticDetails MD)
        {
            try
            {
               
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
               // int Flag = BL.ManageDignosticDetails(MD);
                return View("DignosticDetails");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
    }
}