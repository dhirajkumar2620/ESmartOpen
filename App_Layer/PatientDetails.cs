using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class PatientDetails
    {
        // by shital
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string CasePapaerNo { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string BloodGroup { get; set; }
        public string WhatsAppNo { get; set; }
        public string OtherNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string ReferedByDoctor { get; set; }
        public string AppliedForMediclam { get; set; }
        public string MediClmCompany { get; set; }
        public int CasePaperFees { get; set; }
        public string Role { get; set; }
        public string Age { get; set; }           //New
        public string DoctorAddress { get; set; } //New
        public string MaritalStatus { get; set; } //New
        public string HospitalId { get; set; }
        public int DoctorReceptionId { get; set; }
        public string IsActive { get; set; }
        public string IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ImagePath { get; set; }
        public List <PatientDetails> lst { get; set; }
    }
}
