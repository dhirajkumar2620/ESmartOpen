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
                sqlparam = new SqlParameter[10];
                sqlparam[0] = new SqlParameter("@Id", Ob.Id);
                sqlparam[1] = new SqlParameter("@PhysicalExamination", Ob.PhysicalExamination);
                sqlparam[2] = new SqlParameter("@Since", Ob.Since);
                sqlparam[3] = new SqlParameter("@Period", Ob.Period);
                sqlparam[4] = new SqlParameter("@Diagnosis", Ob.Diagnosis);
                sqlparam[5] = new SqlParameter("@Complaint", Ob.Complaints);
                sqlparam[6] = new SqlParameter("@CasePaperNo", "123");
                sqlparam[7] = new SqlParameter("@HospitalId", "1");
                sqlparam[8] = new SqlParameter("@PatientId", "1");
                sqlparam[9] = new SqlParameter("@CreatedBy", "1");

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
                sqlparam = new SqlParameter[12];
                sqlparam[0] = new SqlParameter("@Id", Ob.Id);
                sqlparam[1] = new SqlParameter("@MedicineName", Ob.MedicineName);
                sqlparam[2] = new SqlParameter("@WhenMedicine", Ob.WhenMedicine);
                sqlparam[3] = new SqlParameter("@RepeatMedicine", Ob.RepeatMedicine);
                sqlparam[4] = new SqlParameter("@ForMedicine", Ob.ForMedicine);
                sqlparam[5] = new SqlParameter("@MedicineDays", Ob.MedicineDays);
                sqlparam[6] = new SqlParameter("@SpecialInstruction", Ob.SpecialInstruction);
                sqlparam[7] = new SqlParameter("@AlternateMedicine", Ob.AlternateMedicine);
                sqlparam[8] = new SqlParameter("@CasePaperNo", "1");
                sqlparam[9] = new SqlParameter("@HospitalId", "1");
                sqlparam[10] = new SqlParameter("@PatientId", "1");
                sqlparam[11] = new SqlParameter("@CreatedBy", "1");
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
                sqlparam = new SqlParameter[11];
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
                return CommonFunction.Save("USP_Prec_Common", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Observation GetObservationDetails()
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@UserID", "");

                DataTable ds = CommonFunction.GetDataTable("USP_OPD_GET_PRESCRIPTION", sqlparam, "");
                Observation Ob = new Observation();
                List<Observation> lst = new List<Observation>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Observation Model = new Observation();
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
        public Medication GetMedicationDetails()
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "2");
                sqlparam[1] = new SqlParameter("@UserID", "");

                DataTable ds = CommonFunction.GetDataTable("USP_OPD_GET_PRESCRIPTION", sqlparam, "");
                Medication Ob = new Medication();
                List<Medication> lst = new List<Medication>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Medication Model = new Medication();
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

        public Common GetCommonDetails()
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "3");
                sqlparam[1] = new SqlParameter("@UserID", "");

                DataTable ds = CommonFunction.GetDataTable("USP_OPD_GET_PRESCRIPTION", sqlparam, "");
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
