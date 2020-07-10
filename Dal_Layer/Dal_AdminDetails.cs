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
    public class Dal_AdminDetails
    {
        public int ManageAdminDetails(AdminDetails AD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[34];
                sqlparam[0] = new SqlParameter("@UserId", AD.UserId);
                sqlparam[1] = new SqlParameter("@Name", AD.FirstName);
                sqlparam[2] = new SqlParameter("@Education", AD.Education);
                sqlparam[3] = new SqlParameter("@RegNo", AD.RegNumber);
                sqlparam[4] = new SqlParameter("@Gender", AD.Gender);
                sqlparam[5] = new SqlParameter("@DateOfBirth", AD.DateOfBirth);
                sqlparam[6] = new SqlParameter("@WhatsAppNumber", AD.WhatsAppNumber);
                sqlparam[7] = new SqlParameter("@OtherNumber", AD.OtherNumber);
                sqlparam[8] = new SqlParameter("@HCDLName", AD.HostClincName);
                sqlparam[9] = new SqlParameter("@HCDLNumber", AD.HospClinicNumber);
                sqlparam[10] = new SqlParameter("@HCDLAddress", AD.HospClinicAddess);
                sqlparam[11] = new SqlParameter("@ActivationFor", AD.ActivationFor);
                sqlparam[12] = new SqlParameter("@ActivationDate", AD.ActivationDate);
                sqlparam[13] = new SqlParameter("@ActivationPeriod", AD.ActivationPeriod);
                sqlparam[14] = new SqlParameter("@ExpiryDate", AD.ExpiryDate);
                sqlparam[15] = new SqlParameter("@Role ", null);
                if (AD.IsActive == true)
                {
                    sqlparam[16] = new SqlParameter("@IsActive", "1");
                }
                else
                {
                    sqlparam[16] = new SqlParameter("@IsActive", "0");
                }
               
                sqlparam[17] = new SqlParameter("@ParentId", AD.ParentId);
                sqlparam[18] = new SqlParameter("@hId", AD.HospitalId);
                sqlparam[19] = new SqlParameter("@CreatedBy", AD.UserId);
                sqlparam[20] = new SqlParameter("@CreatedDate", null);
                sqlparam[21] = new SqlParameter("@ModifiedBy",AD.UserId);
                sqlparam[22] = new SqlParameter("@ModifiedDate", null);
                sqlparam[23] = new SqlParameter("@EmailId", AD.EmailId);
                //sqlparam[21] = new SqlParameter("@ParentId", AD.ParentId); 
                sqlparam[24] = new SqlParameter("@ReportingTo", AD.ParentId);
                sqlparam[25] = new SqlParameter("@FirmInTime1", AD.FirmInTime1);
                sqlparam[26] = new SqlParameter("@FirmOutTime1", AD.FirmOutTime1);
                sqlparam[27] = new SqlParameter("@Holiday", AD.Holiday); 
                sqlparam[28] = new SqlParameter("@AlphanumericPrefix", AD.AlphanumericPrefix.Trim());
                sqlparam[29] = new SqlParameter("@Age", AD.Age);
                sqlparam[30] = new SqlParameter("@FirmInTime2", AD.FirmInTime2);
                sqlparam[31] = new SqlParameter("@FirmOutTime2", AD.FirmOutTime2);
                sqlparam[32] = new SqlParameter("@HospClinicLogo", AD.HospClinicLogo);
                sqlparam[33] = new SqlParameter("@Speciality", AD.Speciality);
                return CommonFunction.Save("USP_ManageAdminDetails", sqlparam, "");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<AdminDetails> GetAllAdminDetails()
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@Flag", "1");

                DataTable ds = CommonFunction.GetDataTable("USP_Get_AdminDetails", sqlparam, "");
                List<AdminDetails> lst = new List<AdminDetails>();
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
        public List<AdminDetails> GetAllAdminDetails_SA(int hID)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@hId", hID);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_AdminDetailsBySA", sqlparam, "");
                List<AdminDetails> lst = new List<AdminDetails>();
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

        public AdminDetails GetLoginUserDetails(AdminDetails ad )
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@username", ad.WhatsAppNumber);
                sqlparam[2] = new SqlParameter("@password", ad.Passwod1);

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

        public AdminDetails GetAdminById(int id)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@Id", id);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_AdminDetails", sqlparam, "");
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

        public int UpdatePassword(AdminDetails ad)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
               // sqlparam[0] = new SqlParameter("@userID", ad.UserId);
                sqlparam[0] = new SqlParameter("@password", ad.Passwod1);
                sqlparam[1] = new SqlParameter("@mobileNo", ad.WhatsAppNumber);

                return CommonFunction.Save("USP_Update_Password", sqlparam, "");
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public int SetOTPForUser(string mobileNumber, string OTP)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@mobileNumber", mobileNumber);
                sqlparam[1] = new SqlParameter("@OTP", OTP);

                int flag = CommonFunction.Save("USP_Set_OTP_App", sqlparam, "");

                return flag;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable Get_ExportToExcel(int flag ,int HospitalId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", flag);
                sqlparam[1] = new SqlParameter("@HospitalId", HospitalId);

                DataTable dt = CommonFunction.GetDataTable("[USP_Get_ExportToExcel]", sqlparam, "");

                return dt;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

    }
}