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
    public class Dal_Precriptipn
    {

        //public int SavePage(AdultDetails PD)
        //{
        //    try
        //    {
        //        SqlParameter[] sqlparam;
        //        sqlparam = new SqlParameter[24];
        //        sqlparam[0] = new SqlParameter("@Id", PD.Id);
        //        sqlparam[1] = new SqlParameter("@PatientName", PD.PatientName);
        //        sqlparam[2] = new SqlParameter("@Gender", PD.Gender);
        //        if (PD.DOB == null)
        //        {
        //            sqlparam[3] = new SqlParameter("@DOB", DBNull.Value);

        //        }
        //        else
        //        {
        //            sqlparam[3] = new SqlParameter("@DOB", DateTime.ParseExact(PD.DOB, "dd/MM/yyyy", CultureInfo.InvariantCulture));


        //        }
        //        //if (PD.DOB.ToString() == "1/1/0001 12:00:00 AM")
        //        //{
        //        //    PD.DOB = "01/01/9999";
        //        //    sqlparam[3] = new SqlParameter("@DOB", PD.DOB);
        //        //}
        //        //else
        //        //{

        //        //}
        //        sqlparam[4] = new SqlParameter("@Age", PD.Age);
        //        sqlparam[5] = new SqlParameter("@MaritalStatus", PD.MaritalStatus);
        //        sqlparam[6] = new SqlParameter("@BloodGroup", PD.BloodGroup);
        //        sqlparam[7] = new SqlParameter("@WhatsAppNo", PD.WhatsAppNo);
        //        sqlparam[8] = new SqlParameter("@OtherNo", PD.OtherNo);
        //        sqlparam[9] = new SqlParameter("@EmailId", PD.EmailId);
        //        sqlparam[10] = new SqlParameter("@Address", PD.Address);
        //        sqlparam[11] = new SqlParameter("@ReferedByDoctor", PD.ReferedByDoctor);
        //        sqlparam[12] = new SqlParameter("@DoctorAddress", PD.DoctorAddress);
        //        sqlparam[13] = new SqlParameter("@MediClmCompany", PD.MediClmCompany);
        //        if (PD.AppliedForMediclam == "true")
        //        {
        //            sqlparam[14] = new SqlParameter("@AppliedForMediclam", "1");
        //        }
        //        else
        //        {
        //            sqlparam[14] = new SqlParameter("@AppliedForMediclam", "0");
        //        }
        //        sqlparam[15] = new SqlParameter("@CasePaperFees", PD.CasePaperFees);
        //        sqlparam[16] = new SqlParameter("@Role", PD.Role);
        //        sqlparam[17] = new SqlParameter("@HospitalId", PD.HospitalId);
        //        sqlparam[18] = new SqlParameter("@DoctorReceptionId", PD.DoctorReceptionId);
        //        sqlparam[19] = new SqlParameter("@CreatedBy", PD.CreatedBy);
        //        sqlparam[20] = new SqlParameter("@CasePapaerNo", PD.CasePapaerNo);
        //        sqlparam[21] = new SqlParameter("@IsActive", 1);
        //        sqlparam[22] = new SqlParameter("@HospitlName", PD.HospitalName);

        //        //if (PD.CpExpiryDate.ToString() == "1/1/0001 12:00:00 AM" || PD.CpExpiryDate ==null)
        //        //{
        //        //    PD.CpExpiryDate = Convert.ToString("01/01/9999");
        //        //    sqlparam[23] = new SqlParameter("@CpExpiryDate", PD.CpExpiryDate);
        //        //}
        //        //else
        //        //{
        //        // }


        //        if (PD.CpExpiryDate == null)
        //        {
        //            sqlparam[23] = new SqlParameter("@CpExpiryDate", DBNull.Value);
        //        }
        //        else
        //        {
        //            sqlparam[23] = new SqlParameter("@CpExpiryDate", DateTime.ParseExact(PD.CpExpiryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));


        //        }
        //        return CommonFunction.Save("USP_ManagePatientDetails", sqlparam, "");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        public int SavePage(DentalExamination DE)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[43];

               


                sqlparam[0] = new SqlParameter("@Id", DE.Id);
                sqlparam[1] = new SqlParameter("@T1", DE.T1);
                sqlparam[2] = new SqlParameter("@T2", DE.T2);
                sqlparam[3] = new SqlParameter("@T3", DE.T3);
                sqlparam[4] = new SqlParameter("@T4", DE.T4);
                sqlparam[5] = new SqlParameter("@T5", DE.T5);
                sqlparam[6] = new SqlParameter("@T6", DE.T6);
                sqlparam[7] = new SqlParameter("@T7", DE.T7);
                sqlparam[8] = new SqlParameter("@T8", DE.T8);
                sqlparam[9] = new SqlParameter("@T9", DE.T9);
                sqlparam[10] = new SqlParameter("@T10", DE.T10);
                sqlparam[11] = new SqlParameter("@T11", DE.T11);
                sqlparam[12] = new SqlParameter("@T12", DE.T12);
                sqlparam[13] = new SqlParameter("@T13", DE.T13);
                sqlparam[14] = new SqlParameter("@T14", DE.T14);
                sqlparam[15] = new SqlParameter("@T15", DE.T15);
                sqlparam[16] = new SqlParameter("@T16", DE.T16);
                sqlparam[17] = new SqlParameter("@T17", DE.T17);
                sqlparam[18] = new SqlParameter("@T18", DE.T18);
                sqlparam[19] = new SqlParameter("@T19", DE.T19);
                sqlparam[20] = new SqlParameter("@T20", DE.T20);
                sqlparam[21] = new SqlParameter("@T21", DE.T21);
                sqlparam[22] = new SqlParameter("@T22", DE.T22);
                sqlparam[23] = new SqlParameter("@T23", DE.T23);
                sqlparam[24] = new SqlParameter("@T24", DE.T24);
                sqlparam[25] = new SqlParameter("@T25", DE.T25);
                sqlparam[26] = new SqlParameter("@T26", DE.T26);
                sqlparam[27] = new SqlParameter("@T27", DE.T27);
                sqlparam[28] = new SqlParameter("@T28", DE.T28);
                sqlparam[29] = new SqlParameter("@T29", DE.T29);
                sqlparam[30] = new SqlParameter("@T30", DE.T30);
                sqlparam[31] = new SqlParameter("@T31", DE.T31);
                sqlparam[32] = new SqlParameter("@T32", DE.T32);           




                sqlparam[33] = new SqlParameter("@ColorCode", DE.ColorCode);
                sqlparam[34] = new SqlParameter("@ToothProcedure", DE.ToothProcedure);
                sqlparam[35] = new SqlParameter("@Amount", DE.Amount);
                 sqlparam[36] = new SqlParameter("@Notes", DE.Notes);
                 sqlparam[37] = new SqlParameter("@CasePaperNo", DE.CasePaperNo);
                sqlparam[38] = new SqlParameter("@HospitalId", DE.HospitalId);
                sqlparam[39] = new SqlParameter("@PatientId", DE.PatientId);
                sqlparam[40] = new SqlParameter("@CreatedBy", DE.CreatedBy);
                sqlparam[41] = new SqlParameter("@QueueId", DE.QueueId);
                sqlparam[42] = new SqlParameter("@CreatedDate", DE.CreatedDate); 

                return CommonFunction.Save("USP_D_ManageAdultDetails", sqlparam, "");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Precription ViewPricripion(int QueueId ,string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", "7");
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);
                DataSet ds = CommonFunction.GetDataSet("USP_Get_Precription", sqlparam, "");
                Precription p = new Precription();
                if (ds != null && ds.Tables[7].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[7];
                    foreach (DataRow dr in dt.Rows)
                    {

                        CommonFunction.ReflectSingleData(p, dr);

                    }
                }

                List<Observation> olst = new List<Observation>();
                if (ds != null && ds.Tables[3].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[3];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Observation Model = new Observation();
                        CommonFunction.ReflectSingleData(Model, dr);
                        
                        olst.Add(Model);
                    }
                }
                List<Medication> mlst = new List<Medication>();
                if (ds != null && ds.Tables[4].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[4];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Medication Model = new Medication();
                        CommonFunction.ReflectSingleData(Model, dr);

                        mlst.Add(Model);
                    }
                }
                List<Common> clst = new List<Common>();
               
                if (ds != null && ds.Tables[5].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[5];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Common Model = new Common();
                        CommonFunction.ReflectSingleData(Model, dr);

                        clst.Add(Model);
                    }
                }
                List<Common> NextList = new List<Common>();
                if (ds != null && ds.Tables[6].Rows.Count > 0)
                {
                   
                    DataTable dt = ds.Tables[6];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Common Model1 = new Common();
                        CommonFunction.ReflectSingleData(Model1, dr);

                        NextList.Add(Model1);
                    }
                }
                List<NestVisitlst> NextListlst = new List<NestVisitlst>();
                if (ds != null && ds.Tables[6].Rows.Count > 0)
                {

                    DataTable dt = ds.Tables[6];
                    foreach (DataRow dr in dt.Rows)
                    {
                        NestVisitlst Model1 = new NestVisitlst();
                        CommonFunction.ReflectSingleData(Model1, dr);

                        NextListlst.Add(Model1);
                    }
                }
                //List<VitalInformation> vlst = new List<VitalInformation>();
                //if (ds != null && ds.Tables[3].Rows.Count > 0)
                //{
                //    DataTable dt = ds.Tables[3];
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        VitalInformation Model = new VitalInformation();
                //        CommonFunction.ReflectSingleData(Model, dr);

                //        vlst.Add(Model);
                //    }
                //}
                List<VitalInformation> VList = new List<VitalInformation>();
                if (ds != null && ds.Tables[2].Rows.Count > 0)
                {

                    DataTable dt = ds.Tables[2];
                    foreach (DataRow dr in dt.Rows)
                    {
                        VitalInformation Model1 = new VitalInformation();
                        CommonFunction.ReflectSingleData(Model1, dr);

                        VList.Add(Model1);
                    }
                }

                p.vlist = VList;
                p.olist = olst;
                p.mlist = mlst;
                p.clist = clst;
                p.NextList = NextList;
                p.NextListlst = NextListlst;


                return p;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
