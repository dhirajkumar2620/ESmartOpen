using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class MedicalInformationDetails
    {
        public int Id { get; set; }
        public bool Diabetes { get; set; }
        public bool Asthma { get; set; }
        public bool ThyroidProblem { get; set; }
        public bool Jaundice { get; set; }
        public bool Migraine { get; set; }
        public bool AIDS { get; set; }
        public bool HeartProblem { get; set; }
        public bool BloodPressure { get; set; }
        public bool TB { get; set; }
        public bool Cancer { get; set; }
        public string Other { get; set; }
        public string Allegies { get; set; }
        public string CasePaperNo { get; set; }
        public int HospitalId { get; set; }
        public int PatientId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifideDate { get; set; }
        public int ModifideBy { get; set; }
        public bool IsActive { get; set; }
       public List<MedicalInformationDetails> lst  { get; set; }
}
}
