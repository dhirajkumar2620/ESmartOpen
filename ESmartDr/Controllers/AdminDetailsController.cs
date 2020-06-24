using App_Layer;
using Bal_Layer;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ESmartDr.Controllers
{
    public class AdminDetailsController : Controller
    {
        // GET: AdminDetails Added by Dhiraj 
        Bal_AdminDetails BP = new Bal_AdminDetails();
        Bal_PatientDetails c = new Bal_PatientDetails();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminDetails()
        {

            return View("AdminRegistration");
        }

        public ActionResult ViewAllAdmin()
        {
            try
            {
                List<AdminDetails> LST = new List<AdminDetails>();
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                if (admObj.ParentId == 0)
                {
                    CardDetails(admObj.HospitalId);

                    int HId = 0;
                    LST = BP.GetAllAdminDetails_SA(HId);
                }
                else
                {
                    CardDetails(admObj.HospitalId);
                    LST = BP.GetAllAdminDetails_SA(admObj.HospitalId);
                }
                return View("AllAdmin", LST);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult CheckMailId(string Input)
        {
            try
            {
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails();
                bool Email = LST.Any(cus => cus.EmailId == Input);
                int i = 0;
                if (Email)
                {
                    i = 1;
                }
                else
                {

                }
                return Json(i, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult CheckMobile(string Input)
        {
            try
            {
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails();
                bool Mobile = LST.Any(cus => cus.WhatsAppNumber == Input);
                int i = 0;
                if (Mobile)
                {
                    i = 1;
                }
                else
                {

                }
                return Json(i, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult ManageAdminDetails(AdminDetails AD, HttpPostedFileBase imgfile)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];

                AD.ParentId = admObj.UserId;
                AD.ReportingTo = admObj.UserId;
                AD.HospitalId = admObj.HospitalId;
                AD.AlphanumericPrefix = AD.AlphanumericPrefix.TrimEnd();

                string path = UplodaImage(imgfile);
                if (path == "-1")
                {
                    path = "";
                }
                    AD.HospClinicLogo = path; 
                    int Flag = BP.ManagePatientDetails(AD);
                    if (Flag != 1)
                    {
                        return View();
                    }
                
               
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails_SA(admObj.HospitalId);
                if (AD.UserId == 0)
                {

                    var RegNo = LST.Where(x
                                 => x.HospitalId == AD.HospitalId
                                 && x.WhatsAppNumber == AD.WhatsAppNumber
                                 )
                             .OrderByDescending(x => x.UserId)
                             .Take(1)
                             .Select(x => x.UserId)
                             .ToList()
                             .FirstOrDefault();

                    SMS sms = new SMS();
                    string message = "Dear " + AD.FirstName + ", You are added to eSmartDoctor,Your Reg No is ESD " + RegNo + " Download eSmartDoctor app to manage your Firm - http://bit.ly/2RGTEHTR ";
                    sms.SendSMS(AD.WhatsAppNumber, message);
                }

                CardDetails(admObj.HospitalId);
                return View("AllAdmin", LST);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult GetAdminById(int UserId)
        {
            try
            {
                AdminDetails admObj = (AdminDetails)Session["UserDetails"];
                AdminDetails pd = new AdminDetails();
                pd = BP.GetAdminById(UserId);
                CardDetails(admObj.HospitalId);
                return View("AdminRegistration", pd);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void DownloadExcel()
        {
            List<AdminDetails> LST = new List<AdminDetails>();


            var collection = BP.GetAllAdminDetails();


            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Name";
            Sheet.Cells["B1"].Value = "Department";
            //Sheet.Cells["C1"].Value = "Address";
            //Sheet.Cells["D1"].Value = "City";
            //Sheet.Cells["E1"].Value = "Country";
            int row = 2;
            foreach (var item in collection)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.FirstName;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.WhatsAppNumber;
                //Sheet.Cells[string.Format("C{0}", row)].Value = item.Address;
                //Sheet.Cells[string.Format("D{0}", row)].Value = item.City;
                //Sheet.Cells[string.Format("E{0}", row)].Value = item.Country;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }

        public void CardDetails(int Hid)
        {
            DataSet ds = c.CountForCards(Hid);
            if (ds.Tables[5].Rows[0][0].ToString() == null)
            {
                Session["TotalFrimCount"] = "0";
            }
            else
            {
                Session["TotalFrimCount"] = ds.Tables[5].Rows[0][0].ToString();
            }

            if (ds.Tables[6].Rows[0][0].ToString() == null)
            {
                Session["TotalActiveFrimCount"] = "0";
            }
            else
            {
                Session["TotalActiveFrimCount"] = ds.Tables[6].Rows[0][0].ToString();
            }

            if (ds.Tables[7].Rows[0][0].ToString() == null)
            {
                Session["TotalInActiveFrimCount"] = "0";
            }
            else
            {
                Session["TotalInActiveFrimCount"] = ds.Tables[7].Rows[0][0].ToString();
            }

        }


        public ActionResult CheckAlphanumericPrefix(string Input)
        {
            try
            {
                List<AdminDetails> LST = new List<AdminDetails>();
                LST = BP.GetAllAdminDetails();
                bool Alfa = LST.Any(cus => cus.AlphanumericPrefix == Input);
                int i = 0;
                if (Alfa)
                {
                    i = 1;
                }
                else
                {

                }
                return Json(i, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public string UplodaImage(HttpPostedFileBase file)
        {
            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToUpper().Equals(".JPG") || extension.ToUpper().Equals(".JPEG") || extension.ToUpper().Equals(".PNG"))
                {
                    try
                    {
                        if (Path.GetFileName(file.FileName) == admObj.WhatsAppNumber + extension)
                        {
                            path = Path.Combine(Server.MapPath("~/img/"), Path.GetFileName(file.FileName));
                            file.SaveAs(path);
                            path = "/img/" + Path.GetFileName(file.FileName);
                        }
                        else
                        {
                            path = "-1";
                        }
                    
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }

                }
                else
                {
                    path = "-1";
                }
            }
            return path;
        }
    }
}

