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
    public class Dal_MedicineDetails
    {
        public int ManageMedicineDetails(MedicineDetails MD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[11];
                sqlparam[0] = new SqlParameter("@MedicineId", MD.MedicineId);
                sqlparam[1] = new SqlParameter("@MedicineName", MD.MedicineName);
                sqlparam[2] = new SqlParameter("@MedicineType", MD.MedicineType);
                sqlparam[3] = new SqlParameter("@GenericName", MD.GenericName);
                sqlparam[4] = new SqlParameter("@CompanyName", MD.CompanyName);
                sqlparam[5] = new SqlParameter("@Range", MD.Range);
                sqlparam[6] = new SqlParameter("@Other", MD.Other);
                sqlparam[7] = new SqlParameter("@CreatedBy", MD.CreatedBy);
                //sqlparam[8] = new SqlParameter("@CreatedDate",null);
                sqlparam[8] = new SqlParameter("@ModifiedBy", MD.ModifiedBy);
                //sqlparam[9] = new SqlParameter("@ModifiedDate", null);
                sqlparam[9] = new SqlParameter("@IsAcive", 1);
                sqlparam[10] = new SqlParameter("@HospitalId", MD.HospitalId);

                return CommonFunction.Save("USP_MedicineDetails", sqlparam, "");
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public MedicineDetails ViewAllMedicine(int hId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                //sqlparam[1] = new SqlParameter("@MedicineId", 0);
                sqlparam[1] = new SqlParameter("@HospitalId", hId);
                DataSet ds = CommonFunction.GetDataSet("USP_Get_MedicineDetails", sqlparam, "");
                MedicineDetails MD = new MedicineDetails();
                List<MedicineDetails> lst = new List<MedicineDetails>();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        MedicineDetails Model = new MedicineDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                MD.lst = lst;
                return MD;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public int DeleteMedicine(int MedicineId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "2");
                sqlparam[1] = new SqlParameter("@MedicineId", MedicineId);


                return CommonFunction.Save("USP_Get_MedicineDetails", sqlparam, "");


            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public int BulkImportMedicines(DataTable dtImportMedicines)
        {
            try
            {
                dtImportMedicines.Columns.Remove("CreatedDate");
                dtImportMedicines.Columns.Remove("ModifiedBy");
                dtImportMedicines.Columns.Remove("ModifiedDate");
                dtImportMedicines.Columns.Remove("MedicineId");
                SqlParameter param = new SqlParameter();
                param.ParameterName = "CustMediDtl";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dtImportMedicines;
                param.Direction = ParameterDirection.Input;
                string dbConnStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("dbo.SaveMedicineDetails");
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
    }
}
