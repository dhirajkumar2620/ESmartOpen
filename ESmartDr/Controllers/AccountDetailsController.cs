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
                ED.ExDate = v.ExDate.Substring(0, v.ExDate.ToString().IndexOf(" ") + 1).TrimEnd();
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

        //Expenses Details
        public ActionResult ExportToExcelExpenses()
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
               
                DataTable dt = BL.Get_ExportToExcel(6, admObj.HospitalId);
                string attachment = "attachment; filename=Expenses Details.xls";
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
        //Income Details
        public ActionResult ExportToExcelIncome()
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                int flag = 0;
                if (admObj.HospitalId == 0)
                {
                    flag = 3;
                }
                else
                {
                    flag = 2;
                }
                DataTable dt = BL.Get_ExportToExcel(7, admObj.HospitalId);
                string attachment = "attachment; filename=Income Details.xls";
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
        //Invice Details
        public ActionResult ExportToExcelInvice()
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                int flag = 0;
                if (admObj.HospitalId == 0)
                {
                    flag = 3;
                }
                else
                {
                    flag = 2;
                }
                DataTable dt = BL.Get_ExportToExcel(8, admObj.HospitalId);
                string attachment = "attachment; filename=Invice Details.xls";
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
        public ActionResult PrintBill(string CPno, int QueueID)
        {
            try
            {
                BillPrint bill = new BillPrint();
                bill = BL.PrintBill(QueueID, CPno);
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult PrintView(string CPno, int QueueID)
        {
            BillPrint bill = new BillPrint();
            bill = BL.PrintBill(QueueID, CPno);
            return PartialView("PrintBill", bill);
        }
    }
}