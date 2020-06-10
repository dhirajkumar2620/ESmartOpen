using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    
    public class Bal_PatientDetails
    {
        Dal_PatientDetails DP = new Dal_PatientDetails();

        public int ManagePatientDetails(PatientDetails PD)
        {
            return DP.ManagePatientDetails(PD);
        }

        public List<PatientDetails> GetPatientDetails()
        {
            return DP.GetPatientDetails();
        }

        public PatientDetails GetDetailsById(int id)
        {
            return DP.GetPatientDetailsById(id);
        }
    }
}
