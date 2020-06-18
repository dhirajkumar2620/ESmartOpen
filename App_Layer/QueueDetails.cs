using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class QueueDetails
    {
        public int Id { get; set; }
        public string CasePaperNo { get; set; }
        public string PatientName { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public int InQuee { get; set; }
        public string ReferedBy { get; set; }
        public string CreatedBy { get; set; }
        public int DoctorReceptionId { get; set; }
        public int HospitalId { get; set; }

        public string Gender { get; set; }
        public bool IsAppoinment { get; set; }
     
        public string Age { get; set; }
        public string WhatsAppNo { get; set; }
        public string ReferedByDoctor { get; set; }

        public string FirstName { get; set; }
        public string AppoinmentDate { get; set; }
    }
}
