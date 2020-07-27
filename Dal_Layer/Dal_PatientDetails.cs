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
    public class Dal_PatientDetails
    {
        public int ManagePatientDetails(PatientDetails PD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[24];
                sqlparam[0] = new SqlParameter("@Id", PD.Id);
                sqlparam[1] = new SqlParameter("@PatientName", PD.PatientName);
                sqlparam[2] = new SqlParameter("@Gender", PD.Gender);
                sqlparam[3] = new SqlParameter("@DOB", PD.DOB);
                //if (PD.DOB.ToString() == "1/1/0001 12:00:00 AM")
                //{
                //    PD.DOB = "01/01/9999";
                //    sqlparam[3] = new SqlParameter("@DOB", PD.DOB);
                //}
                //else
                //{

                //}
                sqlparam[4] = new SqlParameter("@Age", PD.Age);
                sqlparam[5] = new SqlParameter("@MaritalStatus", PD.MaritalStatus);
                sqlparam[6] = new SqlParameter("@BloodGroup", PD.BloodGroup);
                sqlparam[7] = new SqlParameter("@WhatsAppNo", PD.WhatsAppNo);
                sqlparam[8] = new SqlParameter("@OtherNo", PD.OtherNo);
                sqlparam[9] = new SqlParameter("@EmailId", PD.EmailId);
                sqlparam[10] = new SqlParameter("@Address", PD.Address);
                sqlparam[11] = new SqlParameter("@ReferedByDoctor", PD.ReferedByDoctor);
                sqlparam[12] = new SqlParameter("@DoctorAddress", PD.DoctorAddress);
                sqlparam[13] = new SqlParameter("@MediClmCompany", PD.MediClmCompany);
                if (PD.AppliedForMediclam == "true")
                {
                    sqlparam[14] = new SqlParameter("@AppliedForMediclam", "1");
                }
                else
                {
                    sqlparam[14] = new SqlParameter("@AppliedForMediclam", "0");
                }
                sqlparam[15] = new SqlParameter("@CasePaperFees", PD.CasePaperFees);
                sqlparam[16] = new SqlParameter("@Role", PD.Role);
                sqlparam[17] = new SqlParameter("@HospitalId", PD.HospitalId);
                sqlparam[18] = new SqlParameter("@DoctorReceptionId", PD.DoctorReceptionId);
                sqlparam[19] = new SqlParameter("@CreatedBy", PD.CreatedBy);
                sqlparam[20] = new SqlParameter("@CasePapaerNo", PD.CasePapaerNo);
                sqlparam[21] = new SqlParameter("@IsActive", 1);
                sqlparam[22] = new SqlParameter("@HospitlName", PD.HospitalName);

                if (PD.CpExpiryDate.ToString() == "1/1/0001 12:00:00 AM")
                {
                    PD.CpExpiryDate = Convert.ToString("01/01/9999");
                    sqlparam[23] = new SqlParameter("@CpExpiryDate", PD.CpExpiryDate);
                }
                else
                {
                    sqlparam[23] = new SqlParameter("@CpExpiryDate", PD.CpExpiryDate);
                }
                return CommonFunction.Save("USP_ManagePatientDetails", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<PatientDetails> GetPatientDetails(string Role, int HospitalId, int UserId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@HospitalId", HospitalId);
                sqlparam[2] = new SqlParameter("@UserId", UserId);
                sqlparam[3] = new SqlParameter("@Role", Role);

                DataTable ds = CommonFunction.GetDataTable("USP_GET_PATIENTDETAILS", sqlparam, "");
                List<PatientDetails> lst = new List<PatientDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        PatientDetails Model = new PatientDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public AdminDetails GetDoctorDetailsById(int UserId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "2");
                sqlparam[1] = new SqlParameter("@HId", UserId);


                DataTable ds = CommonFunction.GetDataTable("USP_Get_DoctorList", sqlparam, "");
                AdminDetails lst = new AdminDetails();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //PatientDetails Model = new PatientDetails();
                        CommonFunction.ReflectSingleData(lst, dr);

                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public PatientDetails GetPatientDetailsById(int id)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@Flag", "2");
                sqlparam[1] = new SqlParameter("@HospitalId", id);
                sqlparam[2] = new SqlParameter("@UserId", "");
                sqlparam[3] = new SqlParameter("@Role", "");
                 
                DataTable ds = CommonFunction.GetDataTable("USP_GET_PATIENTDETAILS", sqlparam, "");
                PatientDetails lst = new PatientDetails();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //PatientDetails Model = new PatientDetails();
                        CommonFunction.ReflectSingleData(lst, dr);

                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<PatientDetails> SetPatientAppoinment(string Id, DateTime AppoinmentDate, string AppoinmentTime, string Note)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@Flag", 1);
                sqlparam[1] = new SqlParameter("@CasePaperNo", Id);
                sqlparam[2] = new SqlParameter("@AppoinmentDate", AppoinmentDate);
                sqlparam[3] = new SqlParameter("@AppoinmentTime", AppoinmentTime);
                sqlparam[4] = new SqlParameter("@Note", Note);

                DataTable ds = CommonFunction.GetDataTable("USP_Set_Apoinment_App", sqlparam, "");
                List<PatientDetails> lst = new List<PatientDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        PatientDetails Model = new PatientDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<QueueDetails> GetQueueList(int hospitalId, int UserId ,string Date)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@HospitalId", hospitalId);
                sqlparam[2] = new SqlParameter("@UserId", UserId);
                sqlparam[3] = new SqlParameter("@Date", Date);

                DataTable ds = CommonFunction.GetDataTable("USP_GET_QUELIST", sqlparam, "");

                List<QueueDetails> lst = new List<QueueDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        QueueDetails Model = new QueueDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public DataSet CountForCards(int hospitalId,int UserId)
        {
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@Flag", "1");
            sqlparam[1] = new SqlParameter("@HospitalId", hospitalId);
            sqlparam[2] = new SqlParameter("@UserId", UserId);  

            DataSet ds = CommonFunction.GetDataSet("USP_Get_Count", sqlparam, "");
            return ds;

        }
        public List<QueueDetails> DeleteAppoinment(int hospitalId, int Id, string Note, string LoginUserRole)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@Flag", "2");
                sqlparam[1] = new SqlParameter("@Id", Id);
                sqlparam[2] = new SqlParameter("@HospitalId", hospitalId);
                sqlparam[3] = new SqlParameter("@Note", Note);
                sqlparam[4] = new SqlParameter("@Role", LoginUserRole);
                DataTable ds = CommonFunction.GetDataTable("USP_GET_QUELIST", sqlparam, "");
                List<QueueDetails> lst = new List<QueueDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        QueueDetails Model = new QueueDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public PatientAllDetails GetPatientDetailsByCPno(string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@CPno", CPno);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_PatientDetailsByCPno", sqlparam, "");
                PatientAllDetails lst = new PatientAllDetails();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //PatientDetails Model = new PatientDetails();
                        CommonFunction.ReflectSingleData(lst, dr);

                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public int SetStatus(int Queueid, string CPno, float Bill, float paidBill, string Status)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@QueueId", Queueid);
                sqlparam[1] = new SqlParameter("@CPno", CPno);
                sqlparam[2] = new SqlParameter("@Bill", Bill);
                sqlparam[3] = new SqlParameter("@paidBill", paidBill);
                sqlparam[4] = new SqlParameter("@Status", Status);

                int flag = CommonFunction.Save("USP_Set_AppStatus", sqlparam, "");

                return flag;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public int SetDueAmount(string CPno, float DueAmount)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@CPno", CPno);
                sqlparam[1] = new SqlParameter("@DueAmount", DueAmount);


                int flag = CommonFunction.Save("USP_Set_DueAmount", sqlparam, "");

                return flag;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public DataTable Get_ExportToExcel(int HospitalId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@HospitalId", HospitalId);

                DataTable dt = CommonFunction.GetDataTable("[USP_Get_ExportToExcel]", sqlparam, "");

                return dt;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public AdminDetails GetDoctorUserDetails(int UserId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "2");
                sqlparam[1] = new SqlParameter("@username", UserId);

                DataTable ds = CommonFunction.GetDataTable("USP_UserDetails", sqlparam, "");
                AdminDetails Model = new AdminDetails();

                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        CommonFunction.ReflectSingleData(Model, dr);
                    }
                }
                return Model;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public IList<AdminDetails> GetDoctorListByHID(int Hid)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@HId", Hid);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_DoctorList", sqlparam, "");
                IList<AdminDetails> lst = new List<AdminDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        AdminDetails Model = new AdminDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public BillPrint PrintBill(int QueueId, string CPno)
        {
            try
            {
         
                  SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", "1");
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);
                DataSet ds = CommonFunction.GetDataSet("USP_Get_PrintBillingDetails", sqlparam, "");
                BillPrint BP = new BillPrint();
                List<Bill> lst = new List<Bill>();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {

                        CommonFunction.ReflectSingleData(BP, dr);
                       
                    }
                    DataTable dt1 = ds.Tables[1];
                    foreach (DataRow dr in dt1.Rows)
                    {
                        Bill Model = new Bill();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                BP.lstBill = lst;
                return BP;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

    }
}
