﻿using System;
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
        public string DateOfBirth { get; set; }
        public string Education { get; set; }
        public string WhatsAppNumber { get; set; }
        public string OtherNumber { get; set; }
        public string EmailId { get; set; }
        public string HostClincName { get; set; }
        public string HospClinicNumber { get; set; }
        public string HospClinicLogo { get; set; }
        public string HospClinicAddess { get; set; }
        public string Passwod1 { get; set; }
        public int ReportingTo { get; set; }
        public string RegNumber { get; set; }
        public string AdharNumber { get; set; }
        public string RoleId { get; set; }
        public bool IsActive { get; set; }
        public string ActivationFor { get; set; }
        public string ActivationDate { get; set; }
        public int ActivationPeriod { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int HospitalId { get; set; }
        public string ExpiryDate { get; set; }
        public string FirmInTime1 { get; set; }
        public string FirmOutTime1 { get; set; }
        public string Holiday { get; set; }
        public string AlphanumericPrefix { get; set; }
        public int Age { get; set; }
        public string FirmInTime2 { get; set; }
        public string FirmOutTime2 { get; set; }
        public string Speciality { get; set; }
        public string DrCount { get; set; }
        public List<AdminDetails> lst { get; set; }
        public bool RememberMe { get; set; }
    }
}
