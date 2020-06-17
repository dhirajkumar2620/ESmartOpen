using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_EnquiryDetails
    {
        Dal_EnquiryDetails DP = new Dal_EnquiryDetails();
        public int ManageEnquiryDetails(EnquiryDetails ED)
        {
            return DP.ManageEnquiryDetails(ED);
        }
    }
}
