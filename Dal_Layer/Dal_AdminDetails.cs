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
                sqlparam = new SqlParameter[21];
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
                sqlparam[15] = new SqlParameter("@Role ", AD.RoleId);
                sqlparam[16] = new SqlParameter("@IsActive", AD.IsActive);
                sqlparam[17] = new SqlParameter("@ParentId", AD.ParentId);
                sqlparam[18] = new SqlParameter("@HospitalId", AD.HospitalId);
                sqlparam[19] = new SqlParameter("@CreatedBy", AD.UserId);
                sqlparam[17] = new SqlParameter("@CreatedDate", null);
                sqlparam[18] = new SqlParameter("@ModifiedBy",AD.UserId);
                sqlparam[19] = new SqlParameter("@ModifiedDate", null);
                sqlparam[20] = new SqlParameter("@EmailId", AD.EmailId);
                //sqlparam[21] = new SqlParameter("@ParentId", AD.ParentId);
                
                return CommonFunction.Save("USP_AdminDetails", sqlparam, "");
            }
            catch (Exception)
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
                sqlparam[0] = new SqlParameter("@userID", ad.UserId);
                sqlparam[1] = new SqlParameter("@password", ad.Passwod1);

                return CommonFunction.Save("USP_AdminDetails", sqlparam, "");
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}