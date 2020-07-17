using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class BillPrint
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
        public string TotalAmount { get; set; }
        public string DiscountAmount { get; set; }
        public string NetAmount { get; set; }
        public string PaidAmount { get; set; }
        public string BalanceAmount { get; set; }
      public List<Bill> lstBill { get; set; }

    }
    public class Bill
    {
        public string Description { get; set; }
        public string Qty { get; set; }
        public string UnitPrize { get; set; }
        public string Amount { get; set; }
    }

    }
