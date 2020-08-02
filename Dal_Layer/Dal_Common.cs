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
    public class Dal_Common
    {

      
        public DataTable Get_ExportToExcel(int flag, int HospitalId, string StartDate, string EndDate)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@Flag", flag);
                sqlparam[1] = new SqlParameter("@HospitalId", HospitalId);
                if (StartDate == "")
                {
                    sqlparam[2] = new SqlParameter("@StartDate", DBNull.Value);
                }
                else
                {
                    sqlparam[2] = new SqlParameter("@StartDate", StartDate);

                }
                if (EndDate == "")
                {

                    sqlparam[3] = new SqlParameter("@EndDate", DBNull.Value);
                }
                else
                {
                    sqlparam[3] = new SqlParameter("@EndDate", EndDate);
                }

                DataTable dt = CommonFunction.GetDataTable("USP_Get_ExportToExcel", sqlparam, "");

                return dt;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
