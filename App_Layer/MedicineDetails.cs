using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class MedicineDetails
    {

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public string GenericName { get; set; }
        public string CompanyName { get; set; }
        public string Range { get; set; }
        public string Other { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsAcive { get; set; }
        public bool IsDelete { get; set; }
       

    }
}
