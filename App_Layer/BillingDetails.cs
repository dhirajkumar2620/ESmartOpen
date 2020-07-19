using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class BillingDetails
    {
        public BillingDetails()
        {
            lst = new List<BillingDetails>();
        }
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Qty { get; set; }
        public double UnitPrize { get; set; }
        public double Bill { get; set; }
        public double Paid { get; set; }
        public double Balance { get; set; }
        public string CasePaperNo { get; set; }
        public string HospitalId { get; set; }
        public int PatientId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifideBy { get; set; }
        public bool IsActive { get; set; }
        public int QueueId { get; set; }
        public double Discount { get; set; }
        public double NetAmount { get; set; }
        public double TotalBill { get; set; }
        public double TotalPaid { get; set; }
        public double TotalBalance { get; set; }
        public double Total { get; set; }
        public List<BillingDetails> lst { get; set; }
    }
}
