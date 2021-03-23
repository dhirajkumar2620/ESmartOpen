using App_Layer;
using Bal_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO.IsolatedStorage;
using System.Web.Hosting;
using System.Web.UI;

namespace ESmartDr.Controllers
{
    public class MyOPDController : Controller
    {
        // GET: MyOPD
        BAL_MyOPD BM = new BAL_MyOPD();
        DentalExamination DE = new DentalExamination();

        public enum AnswerType
        {
            Agree,
            Disagree,
            NotSure
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Observation(Observation Ob)
        {
            try
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }



        public ActionResult SaveDentalExaminationPage()



        {


            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }


        }


        public ActionResult GetThootno(string img, string PageDetails)
        {
            try
            {

                Session["Toothno"] = img;
                Session["PageDetails"] = PageDetails;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult GetColorcode(string btnColorcode)
        {
            try
            {
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                DentalExamination MD = new DentalExamination();
                Session["btnColorcode"] = btnColorcode;
                //if (Session["PageDetails"] == null)
                //{
                //    MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "A");
                //    return View("DentalExaminationPage", MD);
                //}
                //else
                //{
                //    if (Session["PageDetails"].ToString() == "A")
                //    {
                //        MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "A");
                //        return View("DentalExaminationPage", MD);
                //    }
                //    else if (Session["PageDetails"].ToString() == "P")
                //    {
                //        MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "P");
                //        return View("DentalExaminationPage", MD);
                //    }
                //}
                //return View("DentalExaminationPage", MD);
                return View();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public ActionResult PageSwitch(string Page)
        {
            try
            {
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                BAL_MyOPD BL = new BAL_MyOPD();
                List<DentalExamination> ObjLST = new List<DentalExamination>();
                DentalExamination MD = new DentalExamination();

                //Session["btnColorcode"] = Page;
                if (Page == null)
                {
                    MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "A");
                    //return View("DentalExaminationPage", MD);
                }
                else
                {
                    if (Page == "A")
                    {
                        MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "A");
                        //return View("DentalExaminationPage", MD);
                    }
                    else if (Page == "P")
                    {
                        MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "P");
                        //return View("DentalExaminationPage", MD);
                    }
                }
                if (MD.lst.Count > 0)
                {
                    foreach (var item in MD.lst)
                    {
                        item.CreatedDate = Convert.ToDateTime(item.CreatedDate).Date.ToString("dd/MM/yyyy");
                    }
                }
                //return View("DentalExaminationPage", MD);
                return Json(MD.lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void AdultToothNumberSet()
        {
            //  DentalExamination ObjDE = new DentalExamination();
            // int retrunVal;
            string img1 = Session["Toothno"].ToString();
            //DentalExamination
            img1 = img1.Substring(3, img1.Length - 3);

            if ("T" + img1.ToString() == "T1")
            {
                DE.T1 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T2")
            {
                DE.T2 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T3")
            {
                DE.T3 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T4")
            {
                DE.T4 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T5")
            {
                DE.T5 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T6")
            {
                DE.T6 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T7")
            {
                DE.T7 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T8")
            {
                DE.T8 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T9")
            {
                DE.T9 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T10")
            {
                DE.T10 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T11")
            {
                DE.T11 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T12")
            {
                DE.T12 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T13")
            {
                DE.T13 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T14")
            {
                DE.T14 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T15")
            {
                DE.T15 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T16")
            {
                DE.T16 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T17")
            {
                DE.T17 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T18")
            {
                DE.T18 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T19")
            {
                DE.T19 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T20")
            {
                DE.T20 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T21")
            {
                DE.T21 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T22")
            {
                DE.T22 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T23")
            {
                DE.T23 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T24")
            {
                DE.T24 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T25")
            {
                DE.T25 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T26")
            {
                DE.T26 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T27")
            {
                DE.T3 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T3")
            {
                DE.T27 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T28")
            {
                DE.T28 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T29")
            {
                DE.T29 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T30")
            {
                DE.T30 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T31")
            {
                DE.T31 = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T32")
            {
                DE.T32 = Convert.ToInt16(img1);
            }
            // return  retrunVal;
        }

        public void PediatricToothNumberSet()
        {
            string img1 = Session["Toothno"].ToString();
            //DentalExamination
            img1 = img1.Substring(3, img1.Length - 3);
            if ("T" + img1.ToString() == "T1")
            {
                DE.A = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T2")
            {
                DE.B = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T3")
            {
                DE.C = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T4")
            {
                DE.D = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T5")
            {
                DE.E = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T6")
            {
                DE.F = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T7")
            {
                DE.G = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T8")
            {
                DE.H = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T9")
            {
                DE.I = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T10")
            {
                DE.J = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T11")
            {
                DE.K = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T12")
            {
                DE.L = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T13")
            {
                DE.M = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T14")
            {
                DE.N = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T15")
            {
                DE.O = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T16")
            {
                DE.P = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T17")
            {
                DE.Q = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T18")
            {
                DE.R = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T19")
            {
                DE.S = Convert.ToInt16(img1);
            }
            else if ("T" + img1.ToString() == "T20")
            {
                DE.T = Convert.ToInt16(img1);
            }
        }

      
        
        public ActionResult SavePage(int Id, string CreatedDate, string ToothProcedure, string Amount, string Notes)
        {
            List<DentalExamination> oblist = new List<DentalExamination>();
            try
            {
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                List<DentalExamination> lst = new List<DentalExamination>();
                Bal_Precription BL = new Bal_Precription();
                string img = Session["Toothno"].ToString();
                if (img == null)
                {
                    //ScriptManager.RegisterClientScriptBlock(, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    return View("DentalExaminationPage");
                }
                if (CreatedDate == null)
                {
                    return View("DentalExaminationPage");
                }
                if (ToothProcedure == null)
                {
                    return View("DentalExaminationPage");
                }
                if (Amount == null)
                {
                    return View("DentalExaminationPage");
                }
                else if (Notes == null)
                {
                    return View("DentalExaminationPage");
                }
                //DentalExamination
                img = img.Substring(3, img.Length - 3);
                string btnColorcode = Session["btnColorcode"].ToString();
                DE.ColorCode = btnColorcode.ToString();
                Session["CreatedDate"] = Convert.ToDateTime( CreatedDate);
                Session["ToothProcedure"] = ToothProcedure;
                Session["Amount"] = Amount;
                Session["Notes"] = Notes;
                DE.CreatedDate = Session["CreatedDate"].ToString();
                DE.ToothProcedure = ToothProcedure;
                DE.Amount = Amount;
                DE.Notes = Notes;
                DE.QueueId = patientDETAILS.QueueId;
                DE.HospitalId = patientDETAILS.HospitalId;
                DE.CasePaperNo = patientDETAILS.CasePapaerNo;
                DE.PatientId = patientDETAILS.Id;
                DE.CreatedBy = patientDETAILS.DoctorReceptionId;
                DE.Id = Id;

                

                if (Session["PageDetails"].ToString()=="A")
                {
                    AdultToothNumberSet();
                    int Flag = BL.SaveAdultDetails(DE);
                    // BAL_MyOPD BM = new BAL_MyOPD();
                    // int Flag = BM.GetDentalExamination(DE);
                  
                    if (Flag > 0)
                    {

                        DentalExamination objDE = new DentalExamination();

                        objDE = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "A");
                        oblist = objDE.lst;
                        if (oblist.Count > 0)
                        {
                            foreach (var item in oblist)
                            {
                                item.CreatedDate = Convert.ToDateTime(item.CreatedDate).Date.ToString("dd/MM/yyyy");
                            }
                        }
                        return Json(oblist, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("", JsonRequestBehavior.AllowGet);
                    }

                    //Bal_Precription bp = new Bal_Precription();

                    //AdultDetails pd = new AdultDetails();


                    //pd.T12 = img;
                    //pd = bp.SavePage(pd); 

                    //return View();
                    // return View("DentalExamination", lstObservation);
                }

                else if (Session["PageDetails"].ToString() == "P")
                {
                    PediatricToothNumberSet();
                    int Flag = BL.SavePediatricDetails(DE);
                    // BAL_MyOPD BM = new BAL_MyOPD();
                    // int Flag = BM.GetDentalExamination(DE);
                    
                    if (Flag > 0)
                    {

                        DentalExamination objDE = new DentalExamination();

                        objDE = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo,"P");
                        oblist = objDE.lst;
                        if (oblist.Count > 0)
                        {
                            foreach (var item in oblist)
                            {
                                item.CreatedDate = Convert.ToDateTime(item.CreatedDate).Date.ToString("dd/MM/yyyy");
                            }
                        }
                        return Json(oblist, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(oblist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public ActionResult OpdPrescription()
        {
            return View("Prescription");
        }
        public ActionResult OpdPatientDetails()
        {

            return View("PatientDetails");

        }
        public ActionResult OpdExamination()
        {

            Bal_Precription bp = new Bal_Precription();
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            Precription pd = new Precription();
            pd = bp.ViewPricripion(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
            var Advice = "";
            var Complaints = "";
            var Diagnosis = "";
            var TestBeforeVisit = "";
            var NextVisit = "";

            if (pd.clist.Count > 0)
            {
                foreach (var item in pd.clist)
                {
                    if (item.AddAdvice != "" && item.AddAdvice != null)
                    {
                        Advice = Advice + item.AddAdvice + "," + "  ";
                    }
                }
            }
            if (pd.clist.Count > 0)
            {
                foreach (var item in pd.olist)
                {
                    if (item.Complaints != "" && item.Complaints != null)
                    {
                        Complaints = Complaints + item.Complaints + "," + "  ";
                    }

                    if (item.Diagnosis != "" && item.Diagnosis != null)
                    {
                        Diagnosis = Diagnosis + item.Diagnosis + "," + "  ";
                    }
                }
            }
            if (pd.clist.Count > 0)
            {
                foreach (var item in pd.NextListlst)
                {
                    if (item.NestVisitDate != "" && item.NestVisitDate != null)
                    {
                        NextVisit = NextVisit + Convert.ToDateTime(item.NestVisitDate).Date.ToString("dd/MM/yyyy") + "," + "  ";
                    }
                }
            }
            if (pd.clist.Count > 0)
            {
                foreach (var item in pd.clist)
                {
                    if (item.InvSelectTests != "" && item.InvSelectTests != null)
                    {
                        TestBeforeVisit = TestBeforeVisit + item.InvSelectTests + "," + "  ";
                    }
                }
            }
            pd.HospClinicNumber = pd.HospClinicNumber + " ,+91 " + pd.OtherNumber;
            pd.HospClinicNumber = pd.HospClinicNumber.TrimEnd(',');
            pd.TestBeforeVisit = TestBeforeVisit.TrimEnd(',');
            pd.NextVisit = NextVisit.TrimEnd(',');

            pd.AdviceNote = Advice.TrimEnd(',');

            pd.Complaints = Complaints.TrimEnd(',');
            pd.Diagnosis = Diagnosis.TrimEnd(',');
            return View("Examination", pd);
        }
        public ActionResult OpdHistory()
        {
            HistoryDetails hd = new HistoryDetails();
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            List<HistoryDetails> Ld = new List<HistoryDetails>();
            Ld = BM.GetHistory(patientDETAILS.WhatsAppNo, patientDETAILS.CasePapaerNo);
            hd.lstHD = Ld;
            ////WebHistory Ld = new WebHistory();
            ////Ld = BM.GetWEBHistory(patientDETAILS.CasePapaerNo);
            return View("History", hd);
        }
        public ActionResult OpdBilling()
        {

            ModelState.Clear();
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            BillingDetails bd = new BillingDetails();
            bd = BM.GetBillingDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
            double TotalBill = 0;
            double TotalPaid = 0;
            double TotalBalance = 0;
            foreach (var item in bd.lst)
            {
                TotalBalance = TotalBalance + item.Balance;
                TotalPaid = TotalPaid + item.Paid;
                TotalBill = TotalBill + item.Bill;
            }
            bd.TotalBalance = TotalBalance;
            bd.TotalBill = TotalBill;
            bd.TotalPaid = TotalPaid;
            bd.Total = TotalBalance + TotalPaid + TotalBill;
            bd.NetAmount = TotalBalance + TotalPaid + TotalBill;
            return View("NewBilling", bd);
        }

        public ActionResult DentalExaminationPage()
        {

            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            DentalExamination MD = new DentalExamination();
            //Load lime always null not requird get data
            // Adult
            //Adult
            if (Session["PageDetails"] ==null)
            {
                MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "A");
            }
            else
            {
                if (Session["PageDetails"].ToString() == "A")
                {
                    MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "A");
                }
                else if (Session["PageDetails"].ToString() == "P")
                {
                    MD = BM.GetDentalExamination(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo, "P");
                }
            }
            

            //foreach (var item in MD)
            //{
            //    item.CpExpiryDate = Convert.ToDateTime(item.\).Date.ToString("dd/MM/yyyy");
            //}

            return View("DentalExaminationPage", MD);


            //return View("DentalExaminationPage");
        }

       
        public ActionResult PrintDentalView(string Print)
        {
            Bal_ExpensesDetails BL = new Bal_ExpensesDetails();
            BillPrint bill = new BillPrint();
           int QueueID = Convert.ToInt16( Session["QueueID"].ToString());
           string CPno = Session["CPno"].ToString();
            bill = BL.PrintBill(QueueID, CPno);
            return PartialView("PrintDental", bill);
        }

        [HttpPost]
        public ActionResult DeleteDentalExamination(int Id)
        {
            try
            {
                PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
                BAL_MyOPD BL = new BAL_MyOPD();
                List<DentalExamination> ObjLST = new List<DentalExamination>();
               //need to check session empty or null
                //if (Session["PageDetails"].ToString() =="" || Session["PageDetails"].ToString() ==null)
                //{
                //    Session["PageDetails"] = "C";
                //}
                //Adult
                if (Session["PageDetails"].ToString() == "A")
                {
                    ObjLST = BL.DeleteDentalExamination(Id, patientDETAILS.QueueId, "A");
                    
                }
                //Pediatric
                else if (Session["PageDetails"].ToString() == "P")
                {
                    ObjLST = BL.DeleteDentalExamination(Id, patientDETAILS.QueueId, "P");
                }
                if (ObjLST.Count > 0)
                {
                    foreach (var item in ObjLST)
                    {
                        item.CreatedDate = Convert.ToDateTime(item.CreatedDate).Date.ToString("dd/MM/yyyy");
                    }
                }
                return Json(ObjLST, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult PrecObservation()
        {
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            string Status = "1";
            Observation ob = new Observation();
            BAL_MyOPD BL = new BAL_MyOPD();
            int flag = BL.SetStatus(patientDETAILS.QueueId, Status);
            if (flag != 0)
            {
                ob = BM.GetObservationDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
                return View("Observation", ob);
            }

            return View("Observation", ob);

        }
        public ActionResult MedicationPrec()
        {
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            Medication MD = new Medication();
            //Load lime always null not requird get data
            MD = BM.GetMedicationDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);

            return View("PrecMedication", MD);
        }
        public ActionResult PatientMedicalDetails()
        {
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            MedicalInformationDetails MD = new MedicalInformationDetails();
            //Load lime always null not requird get data
            MD = BM.GetMedicalInfoDetails(patientDETAILS.CasePapaerNo);

            return View("MedicalInformation", MD);
        }
        public ActionResult PatientLifeStyleDetails()
        {
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            LifeStyleDetails Ls = new LifeStyleDetails();
            //Load lime always null not requird get data
            Ls = BM.GetLifeStyleDetails(patientDETAILS.CasePapaerNo);
            if (Ls.Diat != null)
                Ls.Diat = Ls.Diat.Trim();
            if (Ls.Alcohol != null)
                Ls.Alcohol = Ls.Alcohol.Trim();
            if (Ls.Bladder != null)
                Ls.Bladder = Ls.Bladder.Trim();
            if (Ls.Bowel != null)
                Ls.Bowel = Ls.Bowel.Trim();
            if (Ls.Sleep != null)
                Ls.Sleep = Ls.Sleep.Trim();
            if (Ls.Smoting != null)
                Ls.Smoting = Ls.Smoting.Trim();
            return View("LifeStyle", Ls);
        }
        public ActionResult PatientVitalInformation()
        {
            BAL_MyOPD VI = new BAL_MyOPD();
            List<VitalInformation> vi = new List<VitalInformation>();
            VitalInformation v = new VitalInformation();
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            vi = VI.GetVitalInformation(patientDETAILS.CasePapaerNo);


            var viralInfo = vi.FirstOrDefault(x => x.CasePaperNo == patientDETAILS.CasePapaerNo);
            if (viralInfo != null)
            {
                v.BloodPressure = viralInfo.BloodPressure;
                v.Temperature = viralInfo.Temperature;
                v.BloodGlucosePostPrandial = viralInfo.BloodGlucosePostPrandial;
                v.Weight = viralInfo.Weight;
                v.Height = viralInfo.Height;
                v.BloodGlucoseFasting = viralInfo.BloodGlucoseFasting;
                v.BloodlucoseRandom = viralInfo.BloodlucoseRandom;
                v.BloodUrea = viralInfo.BloodUrea;
                v.Creatinine = viralInfo.Creatinine;
                v.UricAcidM = viralInfo.UricAcidM;
                v.HB = viralInfo.HB;
                v.PCV = viralInfo.PCV;
                v.WBCCount = viralInfo.WBCCount;
                v.PlateletCount = viralInfo.PlateletCount;
                v.ESR = viralInfo.ESR;
                v.RBCCount = viralInfo.RBCCount;
                v.MCH = viralInfo.MCH;
                v.MCHC = viralInfo.MCHC;
                v.Lymphocyte = viralInfo.Lymphocyte;
                v.Eosinophil = viralInfo.Eosinophil;
                v.SerumBilirubin = viralInfo.SerumBilirubin;
                v.SGPTALT = viralInfo.SGPTALT;
                v.GGPT = viralInfo.GGPT;
                v.TotalProtein = viralInfo.TotalProtein;
                v.SerumAlbumin = viralInfo.SerumAlbumin;
                v.Globulin = viralInfo.Globulin;
                v.AlkalinePhosphatase = viralInfo.AlkalinePhosphatase;
                v.SGOT = viralInfo.SGOT;
                v.TotalCholesterol = viralInfo.TotalCholesterol;
                v.HDLCholestero = viralInfo.HDLCholestero;
                v.LDLCholesterol = viralInfo.LDLCholesterol;
                v.Triglycerides = viralInfo.Triglycerides;
                v.NonHDL = viralInfo.NonHDL;
                v.HbA1c = viralInfo.HbA1c;
                v.TSH = viralInfo.TSH;
                v.SPO2 = viralInfo.SPO2;
                v.RR = viralInfo.RR;
                v.HeadCircumference = viralInfo.HeadCircumference;
            }
            return View("VitalInformation", viralInfo);
        }

        public ActionResult CommonPrec()
        {
            PatientAllDetails patientDETAILS = (PatientAllDetails)Session["patientDetails"];
            Common Cm = new Common();
            //Load lime always null not requird get data
            Cm = BM.GetCommonDetails(patientDETAILS.QueueId, patientDETAILS.CasePapaerNo);
            return View("PrecCommon", Cm);
        }
        [HttpPost]
        public ActionResult Med(string Prefix)
        {
            Bal_MedicineDetails BL = new Bal_MedicineDetails();
            MedicineDetails MD = new MedicineDetails();
            List<MedicineDetails> lst = new List<MedicineDetails>();

            AdminDetails admObj = (AdminDetails)Session["UserDetails"];
            MD = BL.ViewAllMedicine(admObj.HospitalId);
            //lst = MD.lst;
            lst = MD.lst.Where(x => x.MedicineName.ToUpper().Contains(Prefix.ToUpper())).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public FileResult Download(string fileName)
        {
            string fullName1 = System.IO.Path.Combine(Server.MapPath("~/Doc"), fileName);

            //string fileName = FileUpload1.FileName;
            //var filepath = System.IO.Path.Combine(Server.MapPath("~/Doc"), fileName);
            //return File(filepath, MimeMapping.GetMimeMapping(filepath), fileName);
            //var path = Server.MapPath(@"~/Doc/030002fb.jpg");
            //var contents = System.IO.File.ReadAllBytes(path);
            //return File(contents, "image/jpeg");

            string fullPath = Path.Combine(Server.MapPath("~/Doc"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
    }
}

//var filepath = System.IO.Path.Combine(Server.MapPath("~/Doc"), fileName);
//return File(filepath, MimeMapping.GetMimeMapping(filepath), fileName);
//var path = Server.MapPath(@"~/Doc/030002fb.jpg");
//var contents = System.IO.File.ReadAllBytes(path);
//return File(contents, "image/jpeg");


//    //Get the temp folder and file path in server
//    string fullPath = Path.Combine(Server.MapPath("~/Doc"), fileName);
//    byte[] fileByteArray = System.IO.File.ReadAllBytes(fullPath);
//    System.IO.File.Delete(fullPath);
//    return File(fileByteArray, "application/vnd.ms-excel", fileName);
//}

