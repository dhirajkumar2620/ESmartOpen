﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class BillingDetails
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Bill { get; set; }
        public string Paid { get; set; }
        public string Balance { get; set; }
        public string CasePaperNo { get; set; }
        public string HospitalId { get; set; }
        public int PatientId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifideDate { get; set; }
        public int ModifideBy { get; set; }
        public bool IsActive { get; set; }
        public int QueueId { get; set; }
        List<BillingDetails> lst { get; set; }
    } 
}
