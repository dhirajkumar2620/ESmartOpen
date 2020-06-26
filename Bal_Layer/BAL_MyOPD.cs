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

        public int ManagePrecCommonDetails(Common Ob)
        {
            return DM.ManagePrecCommonDetails(Ob);
        }

        public Common GetCommonDetails()
        {
            return DM.GetCommonDetails();
        }

        public int ManageVitalInformation(VitalInformation VI)
        {
            return DM.ManageVitalInformation(VI);
        }
        public VitalInformation GetVitalInformation(string CPno)
        {
            return DM.GetVitalInformation(CPno);
        }
        public int ManageLifeStyleDetails(LifeStyleDetails LD)
        {
            return DM.ManageLifeStyleDetails(LD);
        }
        public LifeStyleDetails GetLifeStyleDetails()
        {
            return DM.GetLifeStyleDetails();
        }
        public int ManageMedicalInfoDetails(MedicalInformationDetails MI)
        {
            return DM.ManageMedicalInfoDetails(MI);
        }
        public MedicalInformationDetails GetMedicalInfoDetails()
        {
            return DM.GetMedicalInfoDetails();
        }

    }
}
