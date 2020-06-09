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
    public class Dal_MedicineDetails
    {
        public int ManageMedicineDetails(MedicineDetails MD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[13];
                sqlparam[0] = new SqlParameter("@MedicineId", MD.MedicineId);
                sqlparam[1] = new SqlParameter("@MedicineName", MD.MedicineName);
                sqlparam[2] = new SqlParameter("@MedicineType", MD.MedicineType);
                sqlparam[3] = new SqlParameter("@GenericName", MD.GenericName);
                sqlparam[4] = new SqlParameter("@CompanyName", MD.CompanyName);
                sqlparam[5] = new SqlParameter("@Range", MD.Range);
                sqlparam[6] = new SqlParameter("@Other", MD.Other);
                sqlparam[7] = new SqlParameter("@CreatedBy", MD.CreatedBy);
                sqlparam[8] = new SqlParameter("@CreatedDate",null);
                sqlparam[9] = new SqlParameter("@ModifiedBy", MD.ModifiedBy);
                sqlparam[10] = new SqlParameter("@ModifiedDate", null);
                sqlparam[11] = new SqlParameter("@IsAcive", 1);
                sqlparam[12] = new SqlParameter("@IsDelete", 0);

                return CommonFunction.Save("USP_MedicineDetails", sqlparam, "");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
