using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_MedicineDetails
    {
        Dal_MedicineDetails DP = new Dal_MedicineDetails();

        public int ManageMedicineDetails(MedicineDetails MD)
        {
            return DP.ManageMedicineDetails(MD);
        }
    }
}
