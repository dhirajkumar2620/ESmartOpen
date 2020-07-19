using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Layer
{
    public class DAL_Log
    {
        public int SetLOG(string Action, string Controller, string ActionMethod, string Description)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@Action", Action);
                sqlparam[1] = new SqlParameter("@Controller", Controller);
                sqlparam[2] = new SqlParameter("@ActionMethod", ActionMethod);
                sqlparam[3] = new SqlParameter("@Description", Description);


                int flag = CommonFunction.Save("USP_Set_Log", sqlparam, "");

                return flag;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
