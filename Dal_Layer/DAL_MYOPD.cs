using App_Layer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                sqlparam = new SqlParameter[14];
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
                sqlparam[13] = new SqlParameter("@Dose", Ob.Dose);
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
                //sqlparam[12] = new SqlParameter("@FileName", Ob.FileName);
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
                sqlparam = new SqlParameter[16];
                sqlparam[0] = new SqlParameter("@Id", VI.Id);
                sqlparam[1] = new SqlParameter("@BloodPressure ", VI.BloodPressure);
                sqlparam[2] = new SqlParameter("@Temperature ", VI.Temperature);
                sqlparam[3] = new SqlParameter("@BloodGlucosePostPrandial ", VI.BloodGlucosePostPrandial);
                sqlparam[4] = new SqlParameter("@Weight ", VI.Weight);
                sqlparam[5] = new SqlParameter("@Height ", VI.Height);
                sqlparam[6] = new SqlParameter("@BloodGlucoseFasting ", VI.BloodGlucoseFasting);
                sqlparam[7] = new SqlParameter("@BloodlucoseRandom ", VI.BloodlucoseRandom);
             
                sqlparam[8] = new SqlParameter("@Pulse ", VI.Pulse);
                //sqlparam[10] = new SqlParameter("@UricAcidM ", VI.UricAcidM);
                //sqlparam[11] = new SqlParameter("@HB ", VI.HB);
                //sqlparam[12] = new SqlParameter("@PCV ", VI.PCV);
                //sqlparam[13] = new SqlParameter("@WBCCount ", VI.WBCCount);
                //sqlparam[14] = new SqlParameter("@PlateletCount ", VI.PlateletCount);
                //sqlparam[15] = new SqlParameter("@ESR ", VI.ESR);
                //sqlparam[16] = new SqlParameter("@RBCCount ", VI.RBCCount);
                //sqlparam[17] = new SqlParameter("@MCH ", VI.MCH);
                //sqlparam[18] = new SqlParameter("@MCHC ", VI.MCHC);
                //sqlparam[19] = new SqlParameter("@Lymphocyte ", VI.Lymphocyte);
                //sqlparam[20] = new SqlParameter("@Eosinophil ", VI.Eosinophil);
                //sqlparam[21] = new SqlParameter("@SerumBilirubin ", VI.SerumBilirubin);
                //sqlparam[22] = new SqlParameter("@SGPTALT ", VI.SGPTALT);
                //sqlparam[23] = new SqlParameter("@GGPT ", VI.GGPT);
                //sqlparam[24] = new SqlParameter("@TotalProtein ", VI.TotalProtein);
                //sqlparam[25] = new SqlParameter("@SerumAlbumin ", VI.SerumAlbumin);
                //sqlparam[26] = new SqlParameter("@Globulin ", VI.Globulin);
                //sqlparam[27] = new SqlParameter("@AlkalinePhosphatase ", VI.AlkalinePhosphatase);
                //sqlparam[28] = new SqlParameter("@SGOT ", VI.SGOT);
                //sqlparam[29] = new SqlParameter("@TotalCholesterol ", VI.TotalCholesterol);
                //sqlparam[30] = new SqlParameter("@HDLCholestero ", VI.HDLCholestero);
                //sqlparam[31] = new SqlParameter("@LDLCholesterol ", VI.LDLCholesterol);
                //sqlparam[32] = new SqlParameter("@Triglycerides ", VI.Triglycerides);
                //sqlparam[33] = new SqlParameter("@NonHDL ", VI.NonHDL);
                //sqlparam[34] = new SqlParameter("@HbA1c ", VI.HbA1c);
                //sqlparam[35] = new SqlParameter("@TSH ", VI.TSH);
                //sqlparam[36] = new SqlParameter("@SPO2 ", VI.SPO2);
                //sqlparam[37] = new SqlParameter("@RR ", VI.SPO2);
                //sqlparam[38] = new SqlParameter("@HeadCircumference ", VI.HeadCircumference);
                sqlparam[9] = new SqlParameter("@CasePaperNo ", VI.CasePaperNo);
                sqlparam[10] = new SqlParameter("@HospitalId ", VI.HospitalId);
                sqlparam[11] = new SqlParameter("@PatientId ", VI.PatientId);
                sqlparam[12] = new SqlParameter("@CreatedBy ", VI.CreatedBy);
                //sqlparam[43] = new SqlParameter("@CreatedDate ", VI.CreatedDate);
                // sqlparam[44] = new SqlParameter("@ModifideDate ", VI.ModifideDate);
                sqlparam[13] = new SqlParameter("@ModifideBy ", VI.ModifideBy);
                sqlparam[14] = new SqlParameter("@IsActive ", VI.IsActive);
                sqlparam[15] = new SqlParameter("@BloodUrea ", VI.BloodUrea);
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

        public int Set_SatatusFlag(int QueueId, string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@QueueId", QueueId);
                sqlparam[1] = new SqlParameter("@CPno", CPno);

                int flag = CommonFunction.Save("USP_Set_SatatusFlag", sqlparam, "");

                return flag;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public List<HistoryDetails> GetHistory(string mobileNumber, string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@mobileNumber", mobileNumber);
                sqlparam[1] = new SqlParameter("@CPno", CPno);
                DataSet ds = CommonFunction.GetDataSet("USP_Get_HistoryByMobile_App", sqlparam, "");

                List<HistoryDetails> HD = new List<HistoryDetails>();
                List<ObservationDetails> OD = new List<ObservationDetails>();
                List<TestDetails> TD = new List<TestDetails>();
                List<MedicinesDetails> MD = new List<MedicinesDetails>();
                List<HistoryFile> HF = new List<HistoryFile>();
                //History 
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    foreach (DataRow dr in dt1.Rows)
                    {
                        HistoryDetails histrydetails = new HistoryDetails();
                        // HistoryDetails lstHD = new HistoryDetails();
                        CommonFunction.ReflectSingleData(histrydetails, dr);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            DataTable dt0 = ds.Tables[0];
                            foreach (DataRow dr0 in dt0.Rows)
                            {
                                if (Convert.ToInt32(dr0["QueueId"]) == histrydetails.QueueId)
                                {
                                    HistoryDetails lstHD = new HistoryDetails();
                                    CommonFunction.ReflectSingleData(lstHD, dr0);
                                    histrydetails.lstHD.Add(lstHD);
                                }

                            }
                        }


                        //Observation
                        if (ds != null && ds.Tables[1].Rows.Count > 0)
                        {
                            DataTable dt2 = ds.Tables[1];
                            foreach (DataRow dr1 in dt2.Rows)
                            {
                                if (Convert.ToInt32(dr1["QueueId"]) == histrydetails.QueueId)
                                {
                                    ObservationDetails lstOD = new ObservationDetails();
                                    CommonFunction.ReflectSingleData(lstOD, dr1);
                                    histrydetails.lstOD.Add(lstOD);
                                }

                            }
                        }
                        //Test
                        if (ds != null && ds.Tables[2].Rows.Count > 0)
                        {
                            DataTable dt3 = ds.Tables[2];
                            foreach (DataRow dr2 in dt3.Rows)
                            {
                                if (Convert.ToInt32(dr2["QueueId"]) == histrydetails.QueueId)
                                {
                                    TestDetails lstOD = new TestDetails();
                                    CommonFunction.ReflectSingleData(lstOD, dr2);
                                    histrydetails.lstTD.Add(lstOD);
                                }

                            }
                        }
                        //Medicine
                        if (ds != null && ds.Tables[3].Rows.Count > 0)
                        {
                            DataTable dt4 = ds.Tables[3];
                            foreach (DataRow dr3 in dt4.Rows)
                            {
                                if (Convert.ToInt32(dr3["QueueId"]) == histrydetails.QueueId)
                                {
                                    MedicinesDetails lstMD = new MedicinesDetails();
                                    CommonFunction.ReflectSingleData(lstMD, dr3);
                                    histrydetails.lstMD.Add(lstMD);
                                }

                            }
                        }

                        //
                        if (ds != null && ds.Tables[4].Rows.Count > 0)
                        {
                            DataTable dt5 = ds.Tables[4];
                            foreach (DataRow dr4 in dt5.Rows)
                            {
                                if (Convert.ToInt32(dr4["QueueId"]) == histrydetails.QueueId)
                                {
                                    HistoryFile lstHF = new HistoryFile();
                                    CommonFunction.ReflectSingleData(lstHF, dr4);
                                    histrydetails.lstHF.Add(lstHF);
                                }

                            }
                        }
                        HD.Add(histrydetails);
                    }
                }
                // HD.lstOD = OD;
                //histrydetails.lstHD = HD;
                //histrydetails.lstOD = OD;
                //histrydetails.lstTD = TD;
                //histrydetails.lstMD = MD;
                return HD;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public int ManageBilling(DataTable BD)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "CustBillDtl";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = BD;
                param.Direction = ParameterDirection.Input;
                string dbConnStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("dbo.SaveBillingDetails");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);
                    sqlCmd.ExecuteNonQuery();
                }
                //SqlParameter[] sqlparam;
                //sqlparam = new SqlParameter[10];
                //sqlparam[0] = new SqlParameter("@Id", BD.Id);
                //sqlparam[1] = new SqlParameter("@ServiceName", BD.ServiceName);
                //sqlparam[2] = new SqlParameter("@Bill", BD.Bill);
                //sqlparam[3] = new SqlParameter("@Paid", BD.Paid);
                //sqlparam[4] = new SqlParameter("@Balance", BD.Balance);
                //sqlparam[5] = new SqlParameter("@CasePaperNo", BD.CasePaperNo);
                //sqlparam[6] = new SqlParameter("@HospitalId", BD.HospitalId);
                //sqlparam[7] = new SqlParameter("@PatientId", BD.PatientId);
                //sqlparam[8] = new SqlParameter("@CreatedBy", BD.CreatedBy);
                //sqlparam[9] = new SqlParameter("@QueueId", BD.QueueId);


                //int flag = CommonFunction.Save("USP_ManageBilling", sqlparam, "");

                return 1;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public List<Observation> DeleteObservation(int Id)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@flag", 1);
                sqlparam[1] = new SqlParameter("@Id", Id);
                DataTable ds = CommonFunction.GetDataTable("USP_delete_Precription", sqlparam, "");
                List<Observation> olst = new List<Observation>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Observation Model = new Observation();
                        CommonFunction.ReflectSingleData(Model, dr);
                        olst.Add(Model);
                    }
                }


                return olst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public List<Medication> DeleteMedication(int Id)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@flag", 2);
                sqlparam[1] = new SqlParameter("@Id", Id);
                DataTable ds = CommonFunction.GetDataTable("USP_delete_Precription", sqlparam, "");
                List<Medication> mlst = new List<Medication>();



                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Medication Model = new Medication();
                        CommonFunction.ReflectSingleData(Model, dr);
                        mlst.Add(Model);
                    }
                }


                return mlst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public List<Common> DeleteCommon( int Id)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@flag", 3);
                sqlparam[1] = new SqlParameter("@Id", Id);
                DataTable ds = CommonFunction.GetDataTable("USP_delete_Precription", sqlparam, "");
                List<Common> clst = new List<Common>();



                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Common Model = new Common();
                        CommonFunction.ReflectSingleData(Model, dr);
                        clst.Add(Model);
                    }
                }

                return clst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public WebHistory GetWEBHistory(string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@CpNo", CPno);
                DataTable ds = CommonFunction.GetDataTable("USP_GET_HistoryForWeb", sqlparam, "");
                List<WebHistory> lst = new List<WebHistory>();
                WebHistory wh = new WebHistory();


                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        WebHistory Model = new WebHistory();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }

                 wh.hlst = lst;
                return wh;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public int SetStatus(int Queueid ,string Status)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@QueueId", Queueid);
               
                sqlparam[1] = new SqlParameter("@Status", Status);

                int flag = CommonFunction.Save("USP_Set_FinalStatus", sqlparam, "");

                return flag;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }


        //billing DAl
        //public BillingDetails GetBillDetails(int QueueId, string CPno)
        //{
        //    try
        //    {
        //        SqlParameter[] sqlparam;
        //        sqlparam = new SqlParameter[3];
        //        sqlparam[0] = new SqlParameter("@flag", 8);
        //        sqlparam[1] = new SqlParameter("@QueueId", QueueId);
        //        sqlparam[2] = new SqlParameter("@CPno", CPno);

        //        DataTable ds = CommonFunction.GetDataTable("USP_Get_Precription", sqlparam, "");
        //        BillingDetails Ob = new BillingDetails();
        //        List<BillingDetails> lst = new List<BillingDetails>();
        //        if (ds != null && ds.Rows.Count > 0)
        //        {
        //            DataTable dt = ds;
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                BillingDetails Model = new BillingDetails();
        //                CommonFunction.ReflectSingleData(Model, dr);
        //                //Ob = Model;
        //                lst.Add(Model);
        //            }
        //        }
        //        Ob.lst = lst;
        //        return Ob;
        //    }
        //    catch (Exception Ex)
        //    {

        //        throw Ex;
        //    }
        //}
        public int ManageBilling(BillingDetails Ob)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[11];
                sqlparam[0] = new SqlParameter("@Id", Ob.Id);
                sqlparam[1] = new SqlParameter("@ServiceName", Ob.ServiceName);
                sqlparam[2] = new SqlParameter("@Qty", Ob.Qty);
                sqlparam[3] = new SqlParameter("@UnitPrize", Ob.UnitPrize);
                sqlparam[4] = new SqlParameter("@Bill", Ob.Bill);
                sqlparam[5] = new SqlParameter("@Paid", Ob.Paid);
                //sqlparam[4] = new SqlParameter("@Balance", ob.Balance);
                sqlparam[6] = new SqlParameter("@CasePaperNo", Ob.CasePaperNo);
                sqlparam[7] = new SqlParameter("@HospitalId", Ob.HospitalId);
                sqlparam[8] = new SqlParameter("@PatientId", Ob.PatientId);
                sqlparam[9] = new SqlParameter("@CreatedBy", Ob.CreatedBy);
                sqlparam[10] = new SqlParameter("@QueueId", Ob.QueueId);
                return CommonFunction.Save("USP_ManageBillingForPatient", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int SetBillAmount(int QueueId, string CasePaperNo, float TotalAmount, float DiscountAmount, float NetBillAmount, float PaidAmountaid)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[6];
                sqlparam[0] = new SqlParameter("@QueueId", QueueId);
                sqlparam[1] = new SqlParameter("@CasePaperNo", CasePaperNo);
                sqlparam[2] = new SqlParameter("@TotalAmount", TotalAmount);
                sqlparam[3] = new SqlParameter("@DiscountAmount", DiscountAmount);
                sqlparam[4] = new SqlParameter("@NetBillAmount", NetBillAmount);
                sqlparam[5] = new SqlParameter("@PaidAmount", PaidAmountaid);


                return CommonFunction.Save("USP_Set_Bill", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<BillingDetails> DeleteBilling(int Id, int QueueId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@flag", 4);
                sqlparam[1] = new SqlParameter("@Id", Id);
                sqlparam[2] = new SqlParameter("@QueueId", QueueId);
                DataTable ds = CommonFunction.GetDataTable("USP_delete_Precription", sqlparam, "");
                List<BillingDetails> olst = new List<BillingDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        BillingDetails Model = new BillingDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        olst.Add(Model);
                    }
                }


                return olst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public BillingDetails GetBillingDetails(int queueId, string casePapaerNo)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", 8);
                sqlparam[1] = new SqlParameter("@QueueId", queueId);
                sqlparam[2] = new SqlParameter("@CPno", casePapaerNo);
                DataTable ds = CommonFunction.GetDataTable("USP_Get_Precription", sqlparam, "");
                BillingDetails Ob = new BillingDetails();
                List<BillingDetails> lst = new List<BillingDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        BillingDetails Model = new BillingDetails();
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
        public int UploadFile(HistoryFileDetails historyFileDetails)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[6];
                sqlparam[0] = new SqlParameter("@QueueId", historyFileDetails.QueueId);
                sqlparam[1] = new SqlParameter("@FileName", historyFileDetails.FileName);
                sqlparam[2] = new SqlParameter("@CasePaperNo", historyFileDetails.CasePaperNo);
                sqlparam[3] = new SqlParameter("@HospitalId", historyFileDetails.HospitalId);
                sqlparam[4] = new SqlParameter("@PatientId", historyFileDetails.PatientId); 
                sqlparam[5] = new SqlParameter("@CreatedBy", historyFileDetails.Id);
                return CommonFunction.Save("USP_Set_HistoryFileDetails", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }




        public DentalExamination GetDentalExamination(int QueueId, string CPno, string TableName)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@flag", 9);
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);
                sqlparam[3] = new SqlParameter("@TableName", TableName);
                DataTable ds = CommonFunction.GetDataTable("USP_Get_Precription", sqlparam, "");
                DentalExamination Ob = new DentalExamination();
                List<DentalExamination> lst = new List<DentalExamination>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DentalExamination Model = new DentalExamination();
                        CommonFunction.ReflectSingleData(Model, dr);
                        //if (Model.ColorCode == "1")
                        //{
                        //    Model.ColorCode = "Red";
                        //}
                        // Ob = Model;
                        lst.Add(Model);
                    }
                }
               // return lst;
                Ob.lst = lst;
                return Ob;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }




        public List<DentalExamination> DeleteDentalExamination(int Id,int QueueId, string TableName)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@flag", 5);
                sqlparam[1] = new SqlParameter("@Id", Id);
                sqlparam[2] = new SqlParameter("@QueueId", QueueId);
                sqlparam[3] = new SqlParameter("@TableName", TableName);
                DataTable ds = CommonFunction.GetDataTable("USP_delete_Precription", sqlparam, "");
               List<DentalExamination> lstDE = new List<DentalExamination>();

               DentalExamination objDE = new DentalExamination();



                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DentalExamination Model = new DentalExamination();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lstDE.Add(Model);
                    }
                }

                return lstDE;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

    }
}