using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Layer
{
    public class Common
    {
        public int Id                 {get;set;}
        public string InvSelectTests     {get;set;}
        public string InvNotes           {get;set;}
        public string AddAdvice          {get;set;}
        public string AddDiet            {get;set;}
        public string NextVisitAfter     {get;set;}
        public string FrequencyDate      {get;set;}
        public string CasePaperNo        {get;set;}
        public string HospitalId         {get;set;}
        public string PatientId          {get;set;}
        public string CreatedBy          { get; set; }
       
        public string CreatedDate { get; set; }
        public int QueueId { get; set; }
        public string FileName { get; set; }
        public List<Common> lst { get; set; }

}
    public class NestVisitlst
    {
        public string NestVisitDate { get; set; }
    }
    }
