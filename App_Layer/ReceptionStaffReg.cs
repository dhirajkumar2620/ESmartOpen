using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class ReceptionStaffReg
    {
        public int ReceptionId { get; set; }
        public int ParentId { get; set; }
        public string HospitalId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string WhatsAppNumber { get; set; }
        public string OtherNumber { get; set; }
        public string Education { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string AdharNo { get; set; }
        public string Address { get; set; }
        public string RoleId { get; set; }
        public string isActive { get; set; }
        public string isDelete { get; set; }
        public string CreatedBy { get; set; }
        public string Createddate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
