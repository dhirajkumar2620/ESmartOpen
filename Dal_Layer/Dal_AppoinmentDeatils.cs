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
    public class Dal_AppoinmentDeatils
    {
        public PatientDetails GetAppoinment(string CasePaperNo)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@CasePaperNo", CasePaperNo);

                DataTable ds = CommonFunction.GetDataTable("USP_GET_PatientApoinment", sqlparam, "");
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
    }
}
