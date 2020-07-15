using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Data;
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
        public List<HistoryDetails> GetHistory(string mobileNumber, string CPno)
        {
            return DM.GetHistory(mobileNumber,CPno);
        }
        public int ManageBilling(DataTable BD)
        {
            return DM.ManageBilling(BD);
        }

        public List<Observation> DeleteObservation( int Id)
        {
            return DM.DeleteObservation( Id);
        }

        public List<Medication> DeleteMedication( int Id)
        {
            return DM.DeleteMedication( Id);
        }

        public List<Common> DeleteCommon( int Id)
        {
            return DM.DeleteCommon( Id);
        }

        public WebHistory GetWEBHistory( string CPno)
        {
            return DM.GetWEBHistory( CPno);
        }
        public int SetStatus(int Queueid, string Status)
        {
            return DM.SetStatus(Queueid, Status);
        }


        // new billing BAL
        public int ManageBilling(BillingDetails Ob)
        {
            return DM.ManageBilling(Ob);
        }
        public int SetBillAmount(int QueueId, string CasePaperNo, float TotalAmount, float DiscountAmount, float NetBillAmount, float PaidAmountaid)
        {
            return DM.SetBillAmount(QueueId, CasePaperNo, TotalAmount, DiscountAmount, NetBillAmount, PaidAmountaid);
        }
        public List<BillingDetails> DeleteBilling(int Id, int QueueId)
        {
            return DM.DeleteBilling(Id,  QueueId);
        }
    }
}
