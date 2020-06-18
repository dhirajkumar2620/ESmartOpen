using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class AdminDetails
    {
        public int UserId { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }
        public string WhatsAppNumber { get; set; }
        public string OtherNumber { get; set; }
        public string EmailId { get; set; }
        public string HostClincName { get; set; }
        public string HospClinicNumber { get; set; }
        public byte[] HospClinicLogo { get; set; }
        public string HospClinicAddess { get; set; }
        public string Passwod1 { get; set; }
        public int ReportingTo { get; set; }
        public string RegNumber { get; set; }
        public string AdharNumber { get; set; }
        public string RoleId { get; set; }
        public bool IsActive { get; set; }
        public string ActivationFor { get; set; }
        public DateTime ActivationDate { get; set; }
        public int ActivationPeriod { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int HospitalId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string FirmInTime { get; set; }
        public string FirmOutTime { get; set; }
        public string Holiday { get; set; }
        public string AlphanumericPrefix { get; set; }
        public int Age { get; set; }

        public List<AdminDetails> lst { get; set; }
    }
}
