using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class Observation
    {
        public int Id                      {get;set;}
        public string PhysicalExamination  {get;set;}
        public string Since                {get;set;}
        public string Period               {get;set;}
        public string Diagnosis            {get;set;}
        public string Complaints           { get; set;}
        public string CasePaperNo          {get;set;}
        public string HospitalId           {get;set;}
        public string PatientId            {get;set;}
        public string CreatedBy            {get; set;}
        public  List<Observation> lst      { get; set; }
    }
}
