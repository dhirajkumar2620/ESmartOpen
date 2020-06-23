using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class BAL_MyOPD
    {
        DAL_MYOPD DM = new DAL_MYOPD();
        public int ManageObservationDetails(Observation Ob)
        {
            return DM.ManageObservationDetails(Ob);
        }
        public int ManageMedicationDetails(Medication Ob)
        {
            return DM.ManageMedicationDetails(Ob);
        }
        public Observation GetObservationDetails()
        {
            return DM.GetObservationDetails();
        }
        public Medication GetMedicationDetails()
        {
            return DM.GetMedicationDetails();
        }
    }
}
