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
    public class Dal_EnquiryDetails
    {
        public int ManageEnquiryDetails(EnquiryDetails ED)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@Name", ED.Name);
                sqlparam[1] = new SqlParameter("@Email", ED.Email);
                sqlparam[2] = new SqlParameter("@ContactNumbar", ED.ContactNumbar);
                sqlparam[3] = new SqlParameter("@Note", ED.Note);
             
                return CommonFunction.Save("USP_Set_EnqueryDetails", sqlparam, "");
            }
            catch (Exception ex)
            {

                throw ;
            }
        }
    }
}
