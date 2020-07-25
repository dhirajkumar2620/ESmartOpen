﻿using App_Layer;
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
    public class Dal_DashBord
    {
        public Dashbord ViewDashbord(string HospitalId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@HospitalId", HospitalId);
                DataSet ds = CommonFunction.GetDataSet("USP_GET_DashbordDetails", sqlparam, "");
                Dashbord D = new Dashbord();
              // week
                List<Dashbord1> lst1 = new List<Dashbord1>();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        Dashbord1 Model = new Dashbord1();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst1.Add(Model);
                    }
                }
                //month
                List<Dashbord2> lst2 = new List<Dashbord2>();
                if (ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[1];

                    foreach (DataRow dr in dt.Rows)
                    {
                        Dashbord2 Model = new Dashbord2();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst2.Add(Model);
                    }
                }
                List<InvoiceExpenses> lst3 = new List<InvoiceExpenses>();
                if (ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[1];

                    foreach (DataRow dr in dt.Rows)
                    {
                        InvoiceExpenses Model = new InvoiceExpenses();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst3.Add(Model);
                    }
                }
                // exp_Inv
                D.d1lst = lst1;
                D.d2lst = lst2;
                D.d3lst = lst3;
                return D;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
