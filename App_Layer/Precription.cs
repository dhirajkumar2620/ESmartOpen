using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class Precription
    {
        public List<VitalInformation> vlist { get; set; }
        public List<Observation> olist { get; set; }
        public List<Medication> mlist { get; set; }
        public List<Common> clist { get; set; }

    }
}
