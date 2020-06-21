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
    public class Dal_ExpensesDetails
    {
        public int ManageExpensesDetails(ExpensesDetails ED)
        {
            try
            {
   
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[11];
                sqlparam[0] = new SqlParameter("@ExId", ED.ExId);
                sqlparam[1] = new SqlParameter("@ExDate", ED.ExDate);
                sqlparam[2] = new SqlParameter("@ExCatagory", ED.ExCatagory);
                sqlparam[3] = new SqlParameter("@ExAmount", ED.ExAmount);
                sqlparam[4] = new SqlParameter("@ExDetails", ED.ExDetails);
                sqlparam[5] = new SqlParameter("@CreatedBy", ED.CreatedBy);
                sqlparam[6] = new SqlParameter("@ModifiedBy", ED.ModifiedBy);
                sqlparam[9] = new SqlParameter("@IsAcive", 1);
                sqlparam[10] = new SqlParameter("@HospitalId", ED.HospitalId);

                return CommonFunction.Save("USP_ManageExpancesDetails", sqlparam, "");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public ExpensesDetails ViewAllExpenses(int hId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                //sqlparam[1] = new SqlParameter("@MedicineId", 0);
                sqlparam[1] = new SqlParameter("@HospitalId", hId);
                DataSet ds = CommonFunction.GetDataSet("USP_Get_ExpancesDetails", sqlparam, "");
                ExpensesDetails ED = new ExpensesDetails();
                List<ExpensesDetails> lst = new List<ExpensesDetails>();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        ExpensesDetails Model = new ExpensesDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                ED.lst = lst;
                return ED;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public int DeleteExpences(int MedicineId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "2");
                sqlparam[1] = new SqlParameter("@MedicineId", MedicineId);


                return CommonFunction.Save("USP_Get_ExpancesDetails", sqlparam, "");


            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
