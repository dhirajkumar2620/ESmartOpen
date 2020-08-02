using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class Precription
    {
        public string HospClinicLogo { get; set; }
        public string HostClincName { get; set; }
        public string HospClinicAddess { get; set; }
        public string HospClinicNumber { get; set; }
        public string FirmInTime1 { get; set; }
        public string FirmOutTime1 { get; set; }
        public string FirmInTime2 { get; set; }
        public string FirmOutTime2 { get; set; }
        public string Holiday { get; set; }
        public string DoctorName { get; set; }
        public string Degree { get; set; }
        public string RegNumber { get; set; }
        public string Speciality { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string CasePapaerNo { get; set; }
        public string PatientAddress { get; set; }
        public string PatientWhatsAppNo { get; set; }
        public string InvoiceDate { get; set; }
        public string AdviceNote { get; set; }
        public string Diagnosis { get; set; }
        public string Complaints { get; set; }
        public string NextVisit { get; set; }
        public string TestBeforeVisit { get; set; }
        public string OtherNumber { get; set; }
        

        public List<VitalInformation> vlist { get; set; }
        public List<Observation> olist { get; set; }
        public List<Medication> mlist { get; set; }
        public List<Common> clist { get; set; }
        public List<Common> NextList { get; set; }
        public List<NestVisitlst> NextListlst { get; set; }
    }
}
