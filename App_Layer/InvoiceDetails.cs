using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public string CasePaperNo { get; set; }
        public DateTime Date { get; set; }
        public string PatientName { get; set; }
        public string Bill { get; set; }
        public string Paid { get; set; }
        public string Balance { get; set; }
    }
}
