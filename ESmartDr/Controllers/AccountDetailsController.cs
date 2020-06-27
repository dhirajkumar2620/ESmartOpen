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
    public class AccountDetailsController : Controller
    {
        // GET: AccountDetails
        Bal_ExpensesDetails BL = new Bal_ExpensesDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExpensesDetails()
        {
            return View("AccountDetails");
        }
        public ActionResult ManageExpensesDetails(ExpensesDetails ED)
        {
            try
            {

                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                ED.HospitalId = admObj.HospitalId;
                int Flag = BL.ManageExpensesDetails(ED);

                ED = BL.ViewAllExpenses(admObj.HospitalId);
                ModelState.Clear();
                return View("AccountDetails", ED);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult ViewAllExpenses()
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                ExpensesDetails ED = new ExpensesDetails();
                ED = BL.ViewAllExpenses(admObj.HospitalId);
                return View("AccountDetails", ED);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult DeleteExpenses(int Id)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            ExpensesDetails ED = new ExpensesDetails();
            // ED = BL.ViewAllMedicine();
            int Flag1 = BL.DeleteExpences(Id);
            ED = BL.ViewAllExpenses(admObj.HospitalId);

            return View("AccountDetails", ED);
        }

        public ActionResult GetExpensesById(int Id, int hId)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            ExpensesDetails ED = new ExpensesDetails();
            ED = BL.ViewAllExpenses(hId);
            if (true)
            {
                var v = ED.lst.FirstOrDefault(x => x.ExId == Id);
                ED.ExId = v.ExId;
                ED.ExDate = v.ExDate;
                ED.ExDetails = v.ExDetails;
                ED.ExAmount = v.ExAmount;
                ED.ExCatagory = v.ExCatagory;
                ED.CreatedBy = v.CreatedBy;
              
            }

            return View("AccountDetails", ED);
        }

        public ActionResult ExportToExcel1()
        {
            try
            {


                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult ExportToExcel()
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
               
                DataTable dt = BL.Get_ExportToExcel(6, admObj.HospitalId);
                string attachment = "attachment; filename=TimeSheet.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        Response.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
                return View("Layout1");
                //return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}