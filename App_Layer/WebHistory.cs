using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class WebHistory
    {
        public string Date { get; set; }
        public string Status { get; set; }
        public string Complaints { get; set; }
        public string Since { get; set; }
        public string Period { get; set; }
        public string Observation { get; set; }
        public string Diagnosis { get; set; }
        public string MedicineName { get; set; }
        public string When { get; set; }
        public string Repeat { get; set; }
        public string For { get; set; }
        public string Days { get; set; }
        public string SpecialInstruction { get; set; }
        public string AlternateMedicine { get; set; }
        public string Test { get; set; }
        public string Note { get; set; }
        public string Advice { get; set; }
        public string Diet { get; set; }
        public List<WebHistory> hlst { get; set; }
    }
}
