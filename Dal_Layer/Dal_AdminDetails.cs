using App_Layer;
using DataLayer;
using System;
using System.Collections.Generic;
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
                sqlparam = new SqlParameter[20];
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
                sqlparam[17] = new SqlParameter("@Createddate",null);
                sqlparam[18] = new SqlParameter("@ModifiedBy", AD.ModifiedBy);
                sqlparam[19] = new SqlParameter("@ModifiedDate", null);
                sqlparam[20] = new SqlParameter("@ModifiedDate", AD.UserId);
                return CommonFunction.Save("USP_AdminDetails", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}