using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_AppoinmentDeatils
    {
        Dal_AppoinmentDeatils DP = new Dal_AppoinmentDeatils();
        public PatientDetails GetAppoinment(string CasePaperNo)
        {
            return DP.GetAppoinment(CasePaperNo);
        }
    }
}
