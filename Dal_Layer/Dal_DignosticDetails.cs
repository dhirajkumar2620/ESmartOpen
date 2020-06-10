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
   public class Dal_DignosticDetails
    {
        Dal_DignosticDetails DP = new Dal_DignosticDetails();

        public int ManageDignosticDetails(DignosticDetails DD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[10];
                //sqlparam[0] = new SqlParameter("@MedicineId", MD.MedicineId);
                //sqlparam[1] = new SqlParameter("@MedicineName", MD.MedicineName);
                //sqlparam[2] = new SqlParameter("@MedicineType", MD.MedicineType);
                //sqlparam[3] = new SqlParameter("@GenericName", MD.GenericName);
                //sqlparam[4] = new SqlParameter("@CompanyName", MD.CompanyName);
                //sqlparam[5] = new SqlParameter("@Range", MD.Range);
                //sqlparam[6] = new SqlParameter("@Other", MD.Other);
                //sqlparam[7] = new SqlParameter("@CreatedBy", MD.CreatedBy);
                ////sqlparam[8] = new SqlParameter("@CreatedDate",null);
                //sqlparam[8] = new SqlParameter("@ModifiedBy", MD.ModifiedBy);
                ////sqlparam[9] = new SqlParameter("@ModifiedDate", null);
                //sqlparam[9] = new SqlParameter("@IsAcive", 1);
                ////sqlparam[10] = new SqlParameter("@IsDelete", 0);

                return CommonFunction.Save("USP_DiagnosisDetails", sqlparam, "");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
