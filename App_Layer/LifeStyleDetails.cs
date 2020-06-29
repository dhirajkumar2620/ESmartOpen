using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class LifeStyleDetails
    {
        public int Id { get; set; }
        public string Diat { get; set; }
        public string Smoting { get; set; }
        public string Alcohol { get; set; }
        public string Bowel { get; set; }
        public string Bladder { get; set; }
        public string Sleep { get; set; }
        public string CasePaperNo { get; set; }
        public string HospitalId { get; set; }
        public int PatientId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifideDate { get; set; }
        public int ModifideBy { get; set; }
        public bool IsActive { get; set; }
        public List<LifeStyleDetails> lst { get; set; }
    }
}
