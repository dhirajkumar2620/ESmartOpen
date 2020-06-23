using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class Medication
    {
        public int Id                  {get;set;}
        public string MedicineName        {get;set;}
        public string WhenMedicine        {get;set;}
        public string RepeatMedicine      {get;set;}
        public string ForMedicine         {get;set;}
        public string MedicineDays        {get;set;}
        public string SpecialInstruction  {get;set;}
        public string AlternateMedicine   {get;set;}
        public string CasePaperNo         {get;set;}
        public string HospitalId          {get;set;}
        public string PatientId           { get; set; }
        public string CreatedBy           { get; set; }
        public List<Medication> lst       { get; set; }
    }
}
