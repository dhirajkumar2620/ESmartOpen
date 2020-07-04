using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class HistoryDetails
    {
        public HistoryDetails()
        {
            lstHD = new List<HistoryDetails>();
            lstOD = new List<ObservationDetails>();
            lstMD = new List<MedicinesDetails>();
            lstTD = new List<TestDetails>();
        }
        public int QueueId { get; set; }
        public string CasePaperNo { get; set; }
        public string DateTime { get; set; }
        public string InQuee { get; set; }
        public List<HistoryDetails> lstHD { get; set; }
        public List<ObservationDetails> lstOD { get; set; }
        public List<TestDetails> lstTD { get; set; }
        public List<MedicinesDetails> lstMD { get; set; }

    }
    public class ObservationDetails
    {
        public int QueueId { get; set; }
        public string Observation { get; set; }
    }
    public class TestDetails
    {
        public int QueueId { get; set; }
        public string Test { get; set; }
    }
    public class MedicinesDetails
    {
        public int QueueId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineCount { get; set; }
        public string WhenMedicine { get; set; }
        public string SpecialInstruction { get; set; }
    }


}
