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

namespace ESmartDr.Controllers
{
    public class MyOPDController : Controller
    {
        // GET: MyOPD
        BAL_MyOPD BM = new BAL_MyOPD();

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
            return View();
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
                        Advice = Advice + item.AddAdvice  + "," + "  ";
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
                        NextVisit = NextVisit + Convert.ToDateTime(item.NestVisitDate).Date.ToString("dd/MM/yyyy") +"," + "  ";
                    }
                }
            }
            if (pd.clist.Count > 0)
            {
                foreach (var item in pd.clist)
                {
                    if (item.InvSelectTests != "" && item.InvSelectTests != null)
                    {
                        TestBeforeVisit = TestBeforeVisit + item.InvSelectTests + "," +"  " ;
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
            return View("DentalExaminationPage");
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

