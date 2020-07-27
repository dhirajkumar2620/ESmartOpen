using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class Dashbord
    {
        public List<Dashbord1> d1lst { get; set; }
        public List<Dashbord2> d2lst { get; set; }
        public List<InvoiceExpenses> d3lst { get; set; }
        public List<FeedbackDetails> Fedlst { get; set; }
        public List<QueueDetails> Qlst { get; set; }
        

    }
    public class Dashbord1
    {
        public DateTime dates { get; set; }
        public int NewPatientcount { get; set; }
        public int Visitedcount { get; set; }

    }
    public class Dashbord2
    {
        public DateTime dates { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
        public int NewPatientcount { get; set; }
        public int Visitedcount { get; set; }

    }
    public class InvoiceExpenses
    {
        public DateTime dates { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
        public int InvoiceAmount { get; set; }
        public int EspensesAmount { get; set; }

    }
}
