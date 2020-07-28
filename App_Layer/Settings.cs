using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class Settings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Language { get; set; }
        public string VitalInformation { get; set; }
        public string Complaints { get; set; }
        public string Test { get; set; }
        public string Diagnosis { get; set; }
        public string Medication { get; set; }
        public string Observation { get; set; }
        public string NextVisit { get; set; }
        public string Printer { get; set; }
        public string Template { get; set; }
        public List<Settings> lst { get; set; }

    }
}
