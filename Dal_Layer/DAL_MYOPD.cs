using App_Layer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Layer
{
    public class DAL_MYOPD
    {
        public int ManageObservationDetails(Observation Ob)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[11];
                sqlparam[0] = new SqlParameter("@Id", Ob.Id);
                sqlparam[1] = new SqlParameter("@PhysicalExamination", Ob.PhysicalExamination);
                sqlparam[2] = new SqlParameter("@Since", Ob.Since);
                sqlparam[3] = new SqlParameter("@Period", Ob.Period);
                sqlparam[4] = new SqlParameter("@Diagnosis", Ob.Diagnosis);
                sqlparam[5] = new SqlParameter("@Complaint", Ob.Complaints);
                sqlparam[6] = new SqlParameter("@CasePaperNo", Ob.CasePaperNo);
                sqlparam[7] = new SqlParameter("@HospitalId", Ob.HospitalId);
                sqlparam[8] = new SqlParameter("@PatientId", Ob.PatientId);
                sqlparam[9] = new SqlParameter("@CreatedBy", Ob.CreatedBy);
                sqlparam[10] = new SqlParameter("@QueueId", Ob.QueueId);
                return CommonFunction.Save("USP_Prec_Observation", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int ManageMedicationDetails(Medication Ob)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[13];
                sqlparam[0] = new SqlParameter("@Id", Ob.Id);
                sqlparam[1] = new SqlParameter("@MedicineName", Ob.MedicineName);
                sqlparam[2] = new SqlParameter("@WhenMedicine", Ob.WhenMedicine);
                sqlparam[3] = new SqlParameter("@RepeatMedicine", Ob.RepeatMedicine);
                sqlparam[4] = new SqlParameter("@ForMedicine", Ob.ForMedicine);
                sqlparam[5] = new SqlParameter("@MedicineDays", Ob.MedicineDays);
                sqlparam[6] = new SqlParameter("@SpecialInstruction", Ob.SpecialInstruction);
                sqlparam[7] = new SqlParameter("@AlternateMedicine", Ob.AlternateMedicine);
                sqlparam[8] = new SqlParameter("@CasePaperNo", Ob.CasePaperNo);
                sqlparam[9] = new SqlParameter("@HospitalId", Ob.HospitalId);
                sqlparam[10] = new SqlParameter("@PatientId", Ob.PatientId);
                sqlparam[11] = new SqlParameter("@CreatedBy", Ob.CreatedBy);
                sqlparam[12] = new SqlParameter("@QueueId", Ob.QueueId);
                return CommonFunction.Save("USP_Prec_Medication", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ManagePrecCommonDetails(Common Ob)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[12];
                sqlparam[0] = new SqlParameter("@Id", Ob.Id);
                sqlparam[1] = new SqlParameter("@InvSelectTests", Ob.InvSelectTests);
                sqlparam[2] = new SqlParameter("@InvNotes", Ob.InvNotes);
                sqlparam[3] = new SqlParameter("@AddAdvice", Ob.AddAdvice);
                sqlparam[4] = new SqlParameter("@AddDiet", Ob.AddDiet);
                sqlparam[5] = new SqlParameter("@NextVisitAfter", Ob.NextVisitAfter);
                sqlparam[6] = new SqlParameter("@FrequencyDate", Ob.FrequencyDate);
                sqlparam[7] = new SqlParameter("@CasePaperNo", Ob.CasePaperNo);
                sqlparam[8] = new SqlParameter("@HospitalId", Ob.HospitalId);
                sqlparam[9] = new SqlParameter("@PatientId", Ob.PatientId);
                sqlparam[10] = new SqlParameter("@CreatedBy", Ob.CreatedBy);
                sqlparam[11] = new SqlParameter("@QueueId", Ob.QueueId);
                return CommonFunction.Save("USP_Prec_Common", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ManageLifeStyleDetails(LifeStyleDetails LD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[11];
                sqlparam[0] = new SqlParameter("@Id", LD.Id);
                sqlparam[1] = new SqlParameter("@Diat", LD.Diat);
                sqlparam[2] = new SqlParameter("@Smoting", LD.Smoting);
                sqlparam[3] = new SqlParameter("@Alcohol", LD.Alcohol);
                sqlparam[4] = new SqlParameter("@Bowel", LD.Bowel);
                sqlparam[5] = new SqlParameter("@Bladder", LD.Bladder);
                sqlparam[6] = new SqlParameter("@Sleep", LD.Sleep);
                sqlparam[7] = new SqlParameter("@CasePaperNo", LD.CasePaperNo);
                sqlparam[8] = new SqlParameter("@HospitalId", LD.HospitalId);
                sqlparam[9] = new SqlParameter("@PatientId", LD.PatientId);
                sqlparam[10] = new SqlParameter("@CreatedBy", LD.CreatedBy);
                return CommonFunction.Save("[USP_PD_LifeStyleDetails]", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ManageMedicalInfoDetails(MedicalInformationDetails MI)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[17];
                sqlparam[0] = new SqlParameter("@Id", MI.Id);
                sqlparam[1] = new SqlParameter("@Diabetes", MI.Diabetes);
                sqlparam[2] = new SqlParameter("@Asthma", MI.Asthma);
                sqlparam[3] = new SqlParameter("@ThyroidProblem", MI.ThyroidProblem);
                sqlparam[4] = new SqlParameter("@Jaundice", MI.Jaundice);
                sqlparam[5] = new SqlParameter("@Migraine", MI.Migraine);
                sqlparam[6] = new SqlParameter("@AIDS", MI.AIDS);
                sqlparam[7] = new SqlParameter("@HeartProblem", MI.HeartProblem);
                sqlparam[8] = new SqlParameter("@BloodPressure", MI.BloodPressure);
                sqlparam[9] = new SqlParameter("@TB", MI.TB);
                sqlparam[10] = new SqlParameter("@Cancer", MI.Cancer);
                sqlparam[11] = new SqlParameter("@Other", MI.Other);
                sqlparam[12] = new SqlParameter("@Allegies", MI.Allegies);
                sqlparam[13] = new SqlParameter("@CasePaperNo", MI.CasePaperNo);
                sqlparam[14] = new SqlParameter("@HospitalId", MI.HospitalId);
                sqlparam[15] = new SqlParameter("@PatientId", MI.PatientId);
                sqlparam[16] = new SqlParameter("@CreatedBy", MI.CreatedBy);
                return CommonFunction.Save("[USP_PD_MedicalInformationDetails]", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ManageVitalInformation(VitalInformation VI)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[45];
                sqlparam[0] = new SqlParameter("@Id", VI.Id);
                sqlparam[1] = new SqlParameter("@BloodPressure ", VI.BloodPressure);
                sqlparam[2] = new SqlParameter("@Temperature ", VI.Temperature);
                sqlparam[3] = new SqlParameter("@BloodGlucosePostPrandial ", VI.BloodGlucosePostPrandial);
                sqlparam[4] = new SqlParameter("@Weight ", VI.Weight);
                sqlparam[5] = new SqlParameter("@Height ", VI.Height);
                sqlparam[6] = new SqlParameter("@BloodGlucoseFasting ", VI.BloodGlucoseFasting);
                sqlparam[7] = new SqlParameter("@BloodlucoseRandom ", VI.BloodlucoseRandom);
                sqlparam[8] = new SqlParameter("@BloodUrea ", VI.BloodUrea);
                sqlparam[9] = new SqlParameter("@Creatinine ", VI.Creatinine);
                sqlparam[10] = new SqlParameter("@UricAcidM ", VI.UricAcidM);
                sqlparam[11] = new SqlParameter("@HB ", VI.HB);
                sqlparam[12] = new SqlParameter("@PCV ", VI.PCV);
                sqlparam[13] = new SqlParameter("@WBCCount ", VI.WBCCount);
                sqlparam[14] = new SqlParameter("@PlateletCount ", VI.PlateletCount);
                sqlparam[15] = new SqlParameter("@ESR ", VI.ESR);
                sqlparam[16] = new SqlParameter("@RBCCount ", VI.RBCCount);
                sqlparam[17] = new SqlParameter("@MCH ", VI.MCH);
                sqlparam[18] = new SqlParameter("@MCHC ", VI.MCHC);
                sqlparam[19] = new SqlParameter("@Lymphocyte ", VI.Lymphocyte);
                sqlparam[20] = new SqlParameter("@Eosinophil ", VI.Eosinophil);
                sqlparam[21] = new SqlParameter("@SerumBilirubin ", VI.SerumBilirubin);
                sqlparam[22] = new SqlParameter("@SGPTALT ", VI.SGPTALT);
                sqlparam[23] = new SqlParameter("@GGPT ", VI.GGPT);
                sqlparam[24] = new SqlParameter("@TotalProtein ", VI.TotalProtein);
                sqlparam[25] = new SqlParameter("@SerumAlbumin ", VI.SerumAlbumin);
                sqlparam[26] = new SqlParameter("@Globulin ", VI.Globulin);
                sqlparam[27] = new SqlParameter("@AlkalinePhosphatase ", VI.AlkalinePhosphatase);
                sqlparam[28] = new SqlParameter("@SGOT ", VI.SGOT);
                sqlparam[29] = new SqlParameter("@TotalCholesterol ", VI.TotalCholesterol);
                sqlparam[30] = new SqlParameter("@HDLCholestero ", VI.HDLCholestero);
                sqlparam[31] = new SqlParameter("@LDLCholesterol ", VI.LDLCholesterol);
                sqlparam[32] = new SqlParameter("@Triglycerides ", VI.Triglycerides);
                sqlparam[33] = new SqlParameter("@NonHDL ", VI.NonHDL);
                sqlparam[34] = new SqlParameter("@HbA1c ", VI.HbA1c);
                sqlparam[35] = new SqlParameter("@TSH ", VI.TSH);
                sqlparam[36] = new SqlParameter("@SPO2 ", VI.SPO2);
                sqlparam[37] = new SqlParameter("@RR ", VI.SPO2);
                sqlparam[38] = new SqlParameter("@HeadCircumference ", VI.HeadCircumference);
                sqlparam[39] = new SqlParameter("@CasePaperNo ", VI.CasePaperNo);
                sqlparam[40] = new SqlParameter("@HospitalId ", VI.HospitalId);
                sqlparam[41] = new SqlParameter("@PatientId ", VI.PatientId);
                sqlparam[42] = new SqlParameter("@CreatedBy ", VI.CreatedBy);
                //sqlparam[43] = new SqlParameter("@CreatedDate ", VI.CreatedDate);
                // sqlparam[44] = new SqlParameter("@ModifideDate ", VI.ModifideDate);
                sqlparam[43] = new SqlParameter("@ModifideBy ", VI.ModifideBy);
                sqlparam[44] = new SqlParameter("@IsActive ", VI.IsActive);

                return CommonFunction.Save("USP_PD_VitalInformation", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public MedicalInformationDetails GetMedicalInfoDetails(string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@flag", "1");
                sqlparam[1] = new SqlParameter("@CPno", CPno);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_Precription", sqlparam, "");
                MedicalInformationDetails Ob = new MedicalInformationDetails();
                List<MedicalInformationDetails> lst = new List<MedicalInformationDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        MedicalInformationDetails Model = new MedicalInformationDetails();
                        CommonFunction.ReflectSingleData(Ob, dr);
                        lst.Add(Model);
                    }
                }
                Ob.lst = lst;
                return Ob;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public LifeStyleDetails GetLifeStyleDetails(string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@flag", 2);
                sqlparam[1] = new SqlParameter("@CPno", CPno);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_Precription", sqlparam, "");
                LifeStyleDetails Ob = new LifeStyleDetails();
                List<LifeStyleDetails> lst = new List<LifeStyleDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        LifeStyleDetails Model = new LifeStyleDetails();
                        CommonFunction.ReflectSingleData(Ob, dr);

                        lst.Add(Model);
                    }
                }
                Ob.lst = lst;
                return Ob;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<VitalInformation> GetVitalInformation(String CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@flag", 3);
                sqlparam[1] = new SqlParameter("@CPno", CPno);

                DataSet ds = CommonFunction.GetDataSet("USP_Get_Precription", sqlparam, "");
                VitalInformation Ob = new VitalInformation();
                List<VitalInformation> lst = new List<VitalInformation>();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        VitalInformation Model = new VitalInformation();
                        CommonFunction.ReflectSingleData(Model, dr);
                        //Ob = Model;
                        lst.Add(Model);
                    }
                }
                //Ob.lst = lst;
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public Observation GetObservationDetails(int QueueId, string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", 4);
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_Precription", sqlparam, "");
                Observation Ob = new Observation();
                List<Observation> lst = new List<Observation>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Observation Model = new Observation();
                        CommonFunction.ReflectSingleData(Model, dr);
                        //Ob = Model;
                        lst.Add(Model);
                    }
                }
                Ob.lst = lst;
                return Ob;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public Medication GetMedicationDetails(int QueueId, string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", 5);
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_Precription", sqlparam, "");
                Medication Ob = new Medication();
                List<Medication> lst = new List<Medication>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Medication Model = new Medication();
                        CommonFunction.ReflectSingleData(Model, dr);
                        // Ob = Model;
                        lst.Add(Model);
                    }
                }
                Ob.lst = lst;
                return Ob;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public Common GetCommonDetails(int QueueId, string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", 6);
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_Precription", sqlparam, "");
                Common Ob = new Common();
                List<Common> lst = new List<Common>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Common Model = new Common();
                        CommonFunction.ReflectSingleData(Model, dr);

                        lst.Add(Model);
                    }
                }
                Ob.lst = lst;
                return Ob;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

    }
}
