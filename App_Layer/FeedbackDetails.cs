using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class FeedbackDetails
    {
        public int Id { get; set; }
        public string Feedback { get; set; }
        public string CPNo { get; set; }
        public int HospitalId { get; set; }
        public DateTime DateTime { get; set; }
        public string Experience { get; set; }
        public string Cleanliness { get; set; }
        public string StaffAttention { get; set; }
        public string MedicalExpertise { get; set; }
        public string ListenGiveTime { get; set; }
        public string Compassionate { get; set; }
        public string BadBehevior { get; set; }
        public List<FeedbackDetails> lst { get; set; }
    }
}
