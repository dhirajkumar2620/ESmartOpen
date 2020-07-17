using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class BAL_Billing
    {
        DAL_MYOPD DM = new DAL_MYOPD();
        //public BillingDetails GetBillDetails(int QueueId, string CPno)
        //{
        //    return DM.GetBillDetails(QueueId, CPno);
        //}
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
            return DM.DeleteBilling(Id, QueueId);
        }
    }
}
