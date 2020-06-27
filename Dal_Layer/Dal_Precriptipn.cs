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
    public class Dal_Precriptipn
    {
        public Precription ViewPricripion(int QueueId ,string CPno)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", "7");
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);
                DataSet ds = CommonFunction.GetDataSet("USP_Get_Precription", sqlparam, "");
                Precription p = new Precription();

               
                List<Observation> olst = new List<Observation>();
                if (ds != null && ds.Tables[3].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[3];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Observation Model = new Observation();
                        CommonFunction.ReflectSingleData(Model, dr);
                        
                        olst.Add(Model);
                    }
                }
                List<Medication> mlst = new List<Medication>();
                if (ds != null && ds.Tables[4].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[4];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Medication Model = new Medication();
                        CommonFunction.ReflectSingleData(Model, dr);

                        mlst.Add(Model);
                    }
                }
                List<Common> clst = new List<Common>();
               
                if (ds != null && ds.Tables[5].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[5];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Common Model = new Common();
                        CommonFunction.ReflectSingleData(Model, dr);

                        clst.Add(Model);
                    }
                }
                List<Common> NextList = new List<Common>();
                if (ds != null && ds.Tables[6].Rows.Count > 0)
                {
                   
                    DataTable dt = ds.Tables[6];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Common Model1 = new Common();
                        CommonFunction.ReflectSingleData(Model1, dr);

                        NextList.Add(Model1);
                    }
                }
                //List<VitalInformation> vlst = new List<VitalInformation>();
                //if (ds != null && ds.Tables[3].Rows.Count > 0)
                //{
                //    DataTable dt = ds.Tables[3];
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        VitalInformation Model = new VitalInformation();
                //        CommonFunction.ReflectSingleData(Model, dr);

                //        vlst.Add(Model);
                //    }
                //}
                p.olist = olst;
                p.mlist = mlst;
                p.clist = clst;
                p.NextList = NextList;


                return p;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
