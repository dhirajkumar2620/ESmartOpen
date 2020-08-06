using App_Layer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
                sqlparam = new SqlParameter[9];
                sqlparam[0] = new SqlParameter("@ExId", ED.ExId);
                sqlparam[1] = new SqlParameter("@ExDate", DateTime.ParseExact(ED.ExDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));// ED.ExDate);
                sqlparam[2] = new SqlParameter("@ExCatagory", ED.ExCatagory);
                sqlparam[3] = new SqlParameter("@ExAmount", ED.ExAmount);
                sqlparam[4] = new SqlParameter("@ExDetails", ED.ExDetails);
                sqlparam[5] = new SqlParameter("@CreatedBy", ED.CreatedBy);
                sqlparam[6] = new SqlParameter("@ModifiedBy", ED.ModifiedBy);
                sqlparam[7] = new SqlParameter("@IsAcive", 1);
                sqlparam[8] = new SqlParameter("@HospitalId", ED.HospitalId);

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
                //Income
                List<IncomeDetails> Inclst = new List<IncomeDetails>();
                if (ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[1];

                    foreach (DataRow dr in dt.Rows)
                    {
                        IncomeDetails Model = new IncomeDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        Inclst.Add(Model);
                    }
                }
                //Invoice
                List<InvoiceDetails> Invclst = new List<InvoiceDetails>();
                if (ds != null && ds.Tables[2].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[2];

                    foreach (DataRow dr in dt.Rows)
                    {
                        InvoiceDetails Model = new InvoiceDetails();
                        CommonFunction.ReflectSingleData(Model, dr);
                        Invclst.Add(Model);
                    }
                }
                ED.Invlst = Invclst.OrderByDescending(x =>x.Date).ToList();
                ED.Inclst = Inclst.OrderByDescending(x => x.Date).ToList();
                ED.lst = lst.OrderByDescending(x => x.ExId).ToList();
                return ED;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public int DeleteExpences(int ExId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "2");
                sqlparam[1] = new SqlParameter("@ExId", ExId);


                return CommonFunction.Save("USP_Get_ExpancesDetails", sqlparam, "");


            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        //public InvoiceDetails GetInvoice(int hID)
        //{
        //    try
        //    {
        //        SqlParameter[] sqlparam;
        //        sqlparam = new SqlParameter[2];
        //        sqlparam[0] = new SqlParameter("@Flag", "1");
        //        sqlparam[1] = new SqlParameter("@HospitalId", hID);

        //        DataSet ds = CommonFunction.GetDataSet("USP_Get_Invoive", sqlparam, "");
        //        InvoiceDetails MD = new InvoiceDetails();
        //        List<InvoiceDetails> lst = new List<InvoiceDetails>();
        //        if (ds != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            DataTable dt = ds.Tables[0];

        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                InvoiceDetails Model = new InvoiceDetails();
        //                CommonFunction.ReflectSingleData(Model, dr);
        //                lst.Add(Model);
        //            }
        //        }
        //        MD.lst = lst;
        //        return MD;
        //    }
        //    catch (Exception Ex)
        //    {

        //        throw Ex;
        //    }
        //}

        
        public BillPrint PrintBill(int QueueId, string CPno)
        {
            try
            {

                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@flag", "1");
                sqlparam[1] = new SqlParameter("@QueueId", QueueId);
                sqlparam[2] = new SqlParameter("@CPno", CPno);
                DataSet ds = CommonFunction.GetDataSet("USP_Get_PrintBillingDetails", sqlparam, "");
                BillPrint BP = new BillPrint();
                List<Bill> lst = new List<Bill>();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {

                        CommonFunction.ReflectSingleData(BP, dr);

                    }
                    DataTable dt1 = ds.Tables[1];
                    foreach (DataRow dr in dt1.Rows)
                    {
                        Bill Model = new Bill();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                BP.lstBill = lst;
                return BP;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
