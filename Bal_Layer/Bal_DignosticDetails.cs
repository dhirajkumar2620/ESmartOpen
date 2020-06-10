using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_DignosticDetails
    {
        Dal_DignosticDetails DP = new Dal_DignosticDetails();

        public int ManageDignosticDetails(DignosticDetails DD)
        {
            return DP.ManageDignosticDetails(DD);
        }
    }
}
