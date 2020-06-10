using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_LaboratoryDetails
    {
        Dal_LaboratoryDetails DP = new Dal_LaboratoryDetails();

        public int ManageLaboratoryDetails(LaboratoryDetails LD)
        {
            return DP.ManageLaboratoryDetails(LD);
        }
    }
}
