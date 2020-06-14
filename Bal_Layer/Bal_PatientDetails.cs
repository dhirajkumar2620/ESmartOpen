﻿using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    
    public class Bal_PatientDetails
    {
        Dal_PatientDetails DP = new Dal_PatientDetails();

        public int ManagePatientDetails(PatientDetails PD)
        {
            return DP.ManagePatientDetails(PD);
        }

        public List<PatientDetails> GetPatientDetails(int HospitalId)
        {
            return DP.GetPatientDetails(HospitalId);
        }

        public PatientDetails GetDetailsById(int id)
        {
            return DP.GetPatientDetailsById(id);
        }

        public List<PatientDetails> SetPatientAppoinment(int Id)
        {
            return DP.SetPatientAppoinment(Id);
        }
        public List<QueueDetails> GetQueueList(int hospitalId)
        { 
            return DP.GetQueueList(hospitalId);
        }

    }
}
