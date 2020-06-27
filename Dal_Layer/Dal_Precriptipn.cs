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
    public class Dal_Precriptipn
    {
        public DataSet ViewPricripion(int QueueId ,string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", "7");
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);
                DataSet ds = CommonFunction.GetDataSet("USP_Get_Precription", sqlparam, "");
              
                return ds;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
