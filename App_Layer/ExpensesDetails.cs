using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class ExpensesDetails
    {
        public int ExId { get; set; }
        public DateTime ExDate { get; set; }
        public string ExCatagory { get; set; }
        public string ExAmount { get; set; }
        public string ExDetails { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsAcive { get; set; }
        public bool IsDelete { get; set; }
        public int HospitalId { get; set; }
        public List<ExpensesDetails> lst { get; set; }
        public List<IncomeDetails> Inclst { get; set; }
        public List<InvoiceDetails> Invlst { get; set; }
    }
}
