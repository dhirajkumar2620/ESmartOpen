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
        public Observation GetObservationDetails(int QueueId, string CPno)
        {
            return DM.GetObservationDetails(QueueId, CPno);
        }
        public Medication GetMedicationDetails(int QueueId, string CPno)
        {
            return DM.GetMedicationDetails(QueueId, CPno);
        }

        public int ManagePrecCommonDetails(Common Ob)
        {
            return DM.ManagePrecCommonDetails(Ob);
        }

        public Common GetCommonDetails(int QueueId, string CPno)
        {
            return DM.GetCommonDetails(QueueId, CPno);
        }

        public int ManageVitalInformation(VitalInformation VI)
        {
            return DM.ManageVitalInformation(VI);
        }
        public List<VitalInformation> GetVitalInformation(string CPno)
        {
            return DM.GetVitalInformation(CPno);
        }
        public int ManageLifeStyleDetails(LifeStyleDetails LD)
        {
            return DM.ManageLifeStyleDetails(LD);
        }
        public LifeStyleDetails GetLifeStyleDetails(string CPno)
        {
            return DM.GetLifeStyleDetails(CPno);
        }
        public int ManageMedicalInfoDetails(MedicalInformationDetails MI)
        {
            return DM.ManageMedicalInfoDetails(MI);
        }
        public MedicalInformationDetails GetMedicalInfoDetails(string CPno)
        {
            return DM.GetMedicalInfoDetails(CPno);
        }

        public int Set_SatatusFlag(int QueueId, string CPno)
        {
            return DM.Set_SatatusFlag(QueueId, CPno);
        }

    }
}
