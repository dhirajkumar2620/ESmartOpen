using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class VitalInformation
    {
        public int Id { get; set; }
        public string BloodPressure { get; set; }
        public string Temperature { get; set; }
        public string BloodGlucosePostPrandial { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string BloodGlucoseFasting { get; set; }
        public string BloodlucoseRandom { get; set; }
        public string BloodUrea { get; set; }
        public string Creatinine { get; set; }
        public string UricAcidM { get; set; }
        public string HB { get; set; }
        public string PCV { get; set; }
        public string WBCCount { get; set; }
        public string PlateletCount { get; set; }
        public string ESR { get; set; }
        public string RBCCount { get; set; }
        public string MCH { get; set; }
        public string MCHC { get; set; }
        public string Lymphocyte { get; set; }
        public string Eosinophil { get; set; }
        public string SerumBilirubin { get; set; }
        public string SGPTALT { get; set; }
        public string GGPT { get; set; }
        public string TotalProtein { get; set; }
        public string SerumAlbumin { get; set; }
        public string Globulin { get; set; }
        public string AlkalinePhosphatase { get; set; }
        public string SGOT { get; set; }
        public string TotalCholesterol { get; set; }
        public string HDLCholestero { get; set; }
        public string LDLCholesterol { get; set; }
        public string Triglycerides { get; set; }
        public string NonHDL { get; set; }
        public string HbA1c { get; set; }
        public string TSH { get; set; }
        public string SPO2 { get; set; }
        public string RR { get; set; }
        public string HeadCircumference { get; set; }
        public string CasePaperNo { get; set; }
        public string HospitalId { get; set; }
        public int PatientId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifideDate { get; set; }
        public int ModifideBy { get; set; }
        public bool IsActive { get; set; }
        public List<VitalInformation> lst { get; set; }
    }
}
